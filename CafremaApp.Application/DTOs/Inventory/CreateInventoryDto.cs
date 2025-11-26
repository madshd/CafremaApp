using CafremaApp.Application.DTOs.CommentInfo;
using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.Inventory;

public record CreateInventoryDto
{
    public string Type { get; init; } = string.Empty;
    public DateOnly InstallationDate { get; init; }
    public Condition Condition { get; init; }
    public bool NeedsRepair { get; init; }
    public CreateCommentInfoDto? CommentInfo { get; init; }
}