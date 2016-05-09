using ivrdating.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivrdating.Persistent.Repositories
{
    public class AccountRepository
    {
        ivrdating.Domain.ivrdating _context;
        public AccountRepository()
        {
            _context = new ivrdating.Domain.ivrdating();
        }

        public IList<account> GetAll()
        {
            return (from ac in _context.accounts select ac).ToList<account>();
        }
    }
}
