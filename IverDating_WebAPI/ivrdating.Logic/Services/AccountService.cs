using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ivrdating.Persistent.Repositories;
using ivrdating.Domain;
namespace ivrdating.Logic.Services
{
    public class AccountService
    {
        AccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public IList<account> GetAll()
        {
            return _accountRepository.GetAll();
        }
    }
}
