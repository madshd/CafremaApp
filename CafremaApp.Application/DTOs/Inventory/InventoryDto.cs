using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.Inventory;

public record InventoryDto
{
    public Guid Id { get; init; }
    public string Type { get; init; } = string.Empty;
    public DateOnly InstallationDate { get; init; }
    public Condition Condition { get; init; } = default!;
    public bool NeedsRepair { get; init; }
    public CommentInfoDto? CommentInfo { get; init; }
}