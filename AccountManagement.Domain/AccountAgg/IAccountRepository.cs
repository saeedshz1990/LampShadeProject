﻿using _0_FrameWork.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string userName);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
