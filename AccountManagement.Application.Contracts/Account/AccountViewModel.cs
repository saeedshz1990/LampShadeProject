namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public long RoleId { get; set; }
        public string Role { get; set; } = string.Empty;
        public string ProfilePhoto { get; set; } = string.Empty;
        public string CreationDate { get; set; } =string.Empty;
    }
}
