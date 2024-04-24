using _0_FrameWork.Infrasutructure;

namespace AccountManagement.Application.Contracts.Role
{
    public class EditRole : CreateRole
    {
        public long Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }

        public EditRole()
        {
            MappedPermissions = new List<PermissionDto>();
            Permissions = new List<int>();
        }
    }
}
