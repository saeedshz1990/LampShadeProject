namespace _01_LampShadeQuery.Contracts.Product
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public string WEbsite { get; set; }
        public long ParentId { get; set; }
        public string ParentName { get; set; }
        
    }
}