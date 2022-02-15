using System.Collections.Generic;

namespace _0_FrameWork.Infrasutructure
{
    public interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
