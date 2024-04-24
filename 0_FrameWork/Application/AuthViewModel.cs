namespace _0_FrameWork.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {

        }
        public AuthViewModel(long id, long roleId, string fullname, string username,
            string mobile, List<int> permissions)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullname;
            UserName = username;
            Mobile = mobile;
            Permissions = permissions;
        }
    }
}