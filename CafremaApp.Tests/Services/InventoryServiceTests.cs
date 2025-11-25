using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using AutoMapper;
using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Application.DTOs.Inventory;
using CafremaApp.Application.Services;
using CafremaApp.Core.Entities;
using CafremaApp.Core.Enums;
using CafremaApp.Core.Interfaces;
using FluentAssertions;
using Xunit;

namespace CafremaApp.Tests.Services
{
    public class InventoryServiceTests
    {
        private readonly Mock<IGenericRepository<Inventory>> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly InventoryService _inventoryService;
        
        public InventoryServiceTests()
        {
            _repoMock = new Mock<IGenericRepository<Inventory>>();
            _mapperMock = new Mock<IMapper>();
            _inventoryService = new InventoryService(_repoMock.Object, _mapperMock.Object);
        }
        
        // Happy path for GetAllInventory
        [Fact]
        public async Task GetAllInventory_ReturnsMappedDTOs()
        {
            // Arrange
            var list = new List<Inventory> 
            { 
                new Inventory("eksempelType", Condition.Dårlig)
                {
                    Id = Guid.NewGuid(),
                    InstallationDate = new DateOnly(2024, 1, 1),
                    NeedsRepair = false
                },
                new Inventory("eksempelType2", Condition.Dårlig)
                {
                    Id = Guid.NewGuid(),
                    InstallationDate = new DateOnly(2020, 10, 6),
                    NeedsRepair = true
                }
            };

            var dtoList = new List<InventoryDto> 
            { 
                new InventoryDto
                {
                    Id = list[0].Id,
                    Type = list[0].Type,
                    InstallationDate = list[0].InstallationDate,
                    Condition = list[0].Condition,
                    NeedsRepair = list[0].NeedsRepair,
                    CommentInfo = null
                },
                new InventoryDto
                {
                    Id = list[1].Id,
                    Type = list[1].Type,
                    InstallationDate = list[1].InstallationDate,
                    Condition = list[1].Condition,
                    NeedsRepair = list[1].NeedsRepair,
                    CommentInfo = new CommentInfoDto
                    {
                        Id = new Guid(),
                        Text = "Skal udskiftes.",
                        LastEdited = new DateTime(2020, 10, 6),
                        InventoryId = list[1].Id,
                    }
                }
            };

            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(list);
            _mapperMock.Setup(m => m.Map<List<InventoryDto>>(list)).Returns(dtoList);

            // Act
            var result = await _inventoryService.GetAllInventory();

            // Assert
            result.Should().BeEquivalentTo(dtoList);
        }
        
        [Fact]
        public async Task GetAllInventory_RepositoryThrowsException_ExceptionIsBubbled()
        {
            // Arrange
            _repoMock
                .Setup(r => r.GetAllAsync())
                .ThrowsAsync(new Exception("Database failure"));

            // Act
            Func<Task> act = async () => await _inventoryService.GetAllInventory();

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Database failure");

            _repoMock.Verify(r => r.GetAllAsync(), Times.Once);

            // Mapper must NOT be called when repo fails
            _mapperMock.Verify(
                m => m.Map<List<InventoryDto>>(It.IsAny<List<Inventory>>()),
                Times.Never);
        }
        
        [Fact]
        public async Task GetAllInventory_MapperThrows_ExceptionIsBubbled()
        {
            // Arrange
            var list = new List<Inventory>
            {
                new Inventory("Test", Condition.God)
            };

            _repoMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(list);

            _mapperMock
                .Setup(m => m.Map<List<InventoryDto>>(list))
                .Throws(new Exception("Mapper failed"));

            // Act
            Func<Task> act = async () => await _inventoryService.GetAllInventory();

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Mapper failed");

            _repoMock.Verify(r => r.GetAllAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<InventoryDto>>(list), Times.Once);
        }
        
        // Happy path for GetInventoryItem
        [Fact]
        public async Task GetInventoryItem_ReturnsMappedDTO()
        {
            // Arrange
            var id = Guid.NewGuid();

            var inventoryEntity = new Inventory("eksempelType", Condition.God)
            {
                Id = id,
                InstallationDate = new DateOnly(2024, 1, 1),
                NeedsRepair = false
            };

            var expectedDto = new InventoryDto
            {
                Id = id,
                Type = inventoryEntity.Type,
                InstallationDate = inventoryEntity.InstallationDate,
                Condition = inventoryEntity.Condition,
                NeedsRepair = inventoryEntity.NeedsRepair,
                CommentInfo = null
            };

            _repoMock
                .Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(inventoryEntity);

            _mapperMock
                .Setup(m => m.Map<InventoryDto>(inventoryEntity))
                .Returns(expectedDto);

            // Act
            var result = await _inventoryService.GetInventoryItem(id);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }
        
        [Fact]
        public async Task GetInventoryItem_RepositoryThrows_ExceptionIsBubbled()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repoMock
                .Setup(r => r.GetByIdAsync(id))
                .ThrowsAsync(new Exception("Database failure"));

            // Act
            Func<Task> act = async () => await _inventoryService.GetInventoryItem(id);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Database failure");

            _mapperMock.Verify(m => m.Map<InventoryDto>(It.IsAny<Inventory>()), Times.Never);
        }

        [Fact]
        public async Task GetInventoryItem_MapperThrows_ExceptionIsBubbled()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new Inventory("test", Condition.God);

            _repoMock.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(entity);

            _mapperMock
                .Setup(m => m.Map<InventoryDto>(entity))
                .Throws(new Exception("Mapper failed"));

            // Act
            Func<Task> act = async () => await _inventoryService.GetInventoryItem(id);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Mapper failed");
        }
        
        // Happy path for CreateInventoryItem
        [Fact]
        public async Task CreateInventoryItem_CreatesCorrectEntityAndCallsRepositoryOnce()
        {
            // Arrange
            var dto = new CreateInventoryDto
            {
                Type = "Østvendt væg",
                Condition = Condition.God,
                InstallationDate = new DateOnly(2024, 1, 1),
            };

            var mappedEntity = new Inventory(dto.Type, dto.Condition)
            {
                InstallationDate = dto.InstallationDate,
                NeedsRepair = false
            };

            Inventory? capturedEntity = null;

            _mapperMock
                .Setup(m => m.Map<Inventory>(dto))
                .Returns(mappedEntity);

            _repoMock
                .Setup(r => r.CreateAsync(It.IsAny<Inventory>()))
                .Callback<Inventory>(inv => capturedEntity = inv)
                .ReturnsAsync(mappedEntity);

            // Act
            await _inventoryService.CreateInventoryItem(dto);

            // Assert — mapping & repo calls
            _mapperMock.Verify(m => m.Map<Inventory>(dto), Times.Once);
            _repoMock.Verify(r => r.CreateAsync(mappedEntity), Times.Once);

            // Assert — entity correctness
            capturedEntity.Should().NotBeNull();
            capturedEntity.Should().BeEquivalentTo(mappedEntity);
        }
        
        [Fact]
        public async Task CreateInventoryItem_MapperThrows_ExceptionIsBubbledAndRepositoryNotCalled()
        {
            // Arrange
            var dto = new CreateInventoryDto
            {
                Type = "TestType",
                Condition = Condition.God,
                InstallationDate = new DateOnly(2024, 1, 1)
            };

            _mapperMock
                .Setup(m => m.Map<Inventory>(dto))
                .Throws(new Exception("Mapper failed"));

            // Act
            Func<Task> act = async () => await _inventoryService.CreateInventoryItem(dto);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Mapper failed");

            _repoMock.Verify(r => r.CreateAsync(It.IsAny<Inventory>()), Times.Never);
        }

        [Fact]
        public async Task CreateInventoryItem_RepositoryThrows_ExceptionIsBubbled()
        {
            // Arrange
            var dto = new CreateInventoryDto();

            _repoMock
                .Setup(r => r.CreateAsync(It.IsAny<Inventory>()))
                .ThrowsAsync(new Exception("Database failure"));

            // Act
            Func<Task> act = async () => await _inventoryService.CreateInventoryItem(dto);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Database failure");

            _repoMock.Verify(r => r.CreateAsync(It.IsAny<Inventory>()), Times.Once);
        }

        // Happy path UpdateInventoryItem
        [Fact]
        public async Task UpdateInventoryItem_ReturnsMappedDTO()
        {
            // Arrange
            var dto = new InventoryDto { Type = "Test", Condition = Condition.God };

            var mappedEntity = new Inventory(dto.Type, dto.Condition);
            var updatedEntity = new Inventory(dto.Type, dto.Condition);

            var returnedDto = new InventoryDto { Type = dto.Type, Condition = dto.Condition };

            _mapperMock.Setup(m => m.Map<Inventory>(dto)).Returns(mappedEntity);
            _repoMock.Setup(r => r.UpdateAsync(mappedEntity)).ReturnsAsync(updatedEntity);
            _mapperMock.Setup(m => m.Map<InventoryDto>(updatedEntity)).Returns(returnedDto);

            // Act
            var result = await _inventoryService.UpdateInventoryItem(dto);

            // Assert
            result.Should().BeEquivalentTo(returnedDto);
        }
        
        [Fact]
        public async Task UpdateInventoryItem_MapperInputThrows_ExceptionIsBubbled()
        {
            var dto = new InventoryDto();

            _mapperMock
                .Setup(m => m.Map<Inventory>(dto))
                .Throws(new Exception("Mapper failed"));

            Func<Task> act = async () => await _inventoryService.UpdateInventoryItem(dto);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Mapper failed");

            _repoMock.Verify(r => r.UpdateAsync(It.IsAny<Inventory>()), Times.Never);
        }

        [Fact]
        public async Task UpdateInventoryItem_RepositoryThrows_ExceptionIsBubbled()
        {
            var dto = new InventoryDto();
            var entity = new Inventory("Test", Condition.God);

            _mapperMock.Setup(m => m.Map<Inventory>(dto)).Returns(entity);

            _repoMock.Setup(r => r.UpdateAsync(entity))
                .ThrowsAsync(new Exception("Database failure"));

            Func<Task> act = async () => await _inventoryService.UpdateInventoryItem(dto);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Database failure");

            _mapperMock.Verify(m => m.Map<InventoryDto>(It.IsAny<Inventory>()), Times.Never);
        }

        [Fact]
        public async Task UpdateInventoryItem_MapperOutputThrows_ExceptionIsBubbled()
        {
            var dto = new InventoryDto();
            var entity = new Inventory("Test", Condition.God);

            _mapperMock.Setup(m => m.Map<Inventory>(dto)).Returns(entity);

            _repoMock.Setup(r => r.UpdateAsync(entity)).ReturnsAsync(entity);

            _mapperMock.Setup(m => m.Map<InventoryDto>(entity))
                .Throws(new Exception("Output map failed"));

            Func<Task> act = async () => await _inventoryService.UpdateInventoryItem(dto);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Output map failed");
        }

        // Happy path for DeleteInventoryItem
        [Fact]
        public async Task DeleteInventoryItem_ReturnsMappedDTO()
        {
            // Arrange
            var id = Guid.NewGuid();
            var deletedEntity = new Inventory("Test", Condition.God)
            {
                Id = id
            };

            var expectedDto = new InventoryDto
            {
                Id = id,
                Type = deletedEntity.Type,
                Condition = deletedEntity.Condition,
                InstallationDate = deletedEntity.InstallationDate,
                NeedsRepair = deletedEntity.NeedsRepair,
                CommentInfo = null
            };

            _repoMock.Setup(r => r.DeleteAsync(id))
                .ReturnsAsync(deletedEntity);

            _mapperMock.Setup(m => m.Map<InventoryDto>(deletedEntity))
                .Returns(expectedDto);

            // Act
            var result = await _inventoryService.DeleteInventoryItem(id);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }

        [Fact]
        public async Task DeleteInventoryItem_RepositoryThrowsException_ExceptionIsBubbled()
        {
            // Arrange
            var id = Guid.NewGuid();

            _repoMock.Setup(r => r.DeleteAsync(id)).ThrowsAsync(new Exception("Database failure"));

            // Act
            Func<Task> act = async () => await _inventoryService.DeleteInventoryItem(id);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Database failure");

            _mapperMock.Verify(m => m.Map<InventoryDto>(It.IsAny<Inventory>()), Times.Never);
        }
        
        [Fact]
        public async Task DeleteInventoryItem_MapperThrows_ExceptionIsBubbled()
        {
            // Arrange
            var id = Guid.NewGuid();

            var deletedEntity = new Inventory("Test", Condition.God);

            _repoMock.Setup(r => r.DeleteAsync(id)).ReturnsAsync(deletedEntity);

            _mapperMock.Setup(m => m.Map<InventoryDto>(deletedEntity)).Throws(new Exception("Mapper failed"));

            // Act
            Func<Task> act = async () => await _inventoryService.DeleteInventoryItem(id);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Mapper failed");
        }
    }
}