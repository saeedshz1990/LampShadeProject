using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public class CreateRole
    {
        public CreateRole()
        {
            Permissions = new List<int>();
        }

        public string Name { get; set; } = string.Empty;
        public List<int> Permissions { get; set; }

    }
}
