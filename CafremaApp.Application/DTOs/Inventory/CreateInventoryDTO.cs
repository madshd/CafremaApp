using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs.CommentInfo;

public record class CreateInventoryDTO
{
    public string Type { get; init; } = string.Empty;
    public DateOnly InstallationDate { get; init; }
    public Condition Condition { get; init; } = Condition.ForefindesIkke!;
    public bool NeedsRepair { get; init; }
    public CreateCommentInfoDTO? CommentInfo { get; init; }
}