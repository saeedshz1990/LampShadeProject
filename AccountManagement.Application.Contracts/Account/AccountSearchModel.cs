namespace AccountManagement.Application.Contracts.Account
{
    public class AccountSearchModel
    {
        public string Fullname { get; set; }=string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public long RoleId { get; set; }
    }
}
