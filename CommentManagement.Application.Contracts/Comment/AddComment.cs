namespace CommentManagement.Application.Contracts.Comment
{
    public class AddComment
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public long OwnerRecordId { get; set; }
        public int Type { get; set; }
        public long ParentId { get; set; }


    }
}