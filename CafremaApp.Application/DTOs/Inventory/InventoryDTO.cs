using CafremaApp.Core.Enums;
using CafremaApp.Core.ValueObjects;

namespace CafremaApp.Application.DTOs.CommentInfo;

public record class InventoryDTO
{
    public Guid Id { get; init; }
    public string Type { get; init; } = string.Empty;
    public DateOnly InstallationDate { get; init; }
    public Condition Condition { get; init; } = default!;
    public bool NeedsRepair { get; init; }
    public CommentInfoDTO? CommentInfo { get; init; }
}