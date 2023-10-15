namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public long OwnerRecordId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public int Type { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string CommentDate { get; set; } = string.Empty;

    }
}