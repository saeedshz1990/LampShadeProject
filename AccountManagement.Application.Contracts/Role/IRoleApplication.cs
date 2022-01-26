using _0_FrameWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(CreateRole command);
        OperationResult Edit (EditRole command);
        EditRole GetDetails(long id);
        List<RoleViewModel> List();
    }
}
