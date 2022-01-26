using _0_FrameWork.Domain;
using AccountManagement.Application.Contracts.Account;
using System.Collections.Generic;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository :IRepository<long , Account>
    {
        Account GetBy(string userName);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchodel searchodel);
    }
}
