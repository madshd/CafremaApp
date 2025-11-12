using CafremaApp.Core.Enums;

namespace CafremaApp.Application.DTOs;

public class CreateInventoryDTO
{
    public string Type { get; set; }
    public DateOnly InstallationDate { get; set; }
    public Condition Condition { get; set; }
    public bool NeedsRepair { get; set; }
    public CreateCommentInfoDTO CommentInfo { get; set; }
}