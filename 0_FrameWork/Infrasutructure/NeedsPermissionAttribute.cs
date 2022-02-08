namespace _0_FrameWork.Infrasutructure
{
    public class NeedsPermissionAttribute
    {
        public int Permission { get; set; }

        public NeedsPermissionAttribute(int permission)
        {
            Permission = permission;
        }
    }
}
