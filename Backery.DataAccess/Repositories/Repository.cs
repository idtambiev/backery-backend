using Bakery.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DataAccess.Repositories
{
    public class Repository: IRepository
    {
        public BakeryDbContext Context { get; set; }
        public Repository(BakeryDbContext context)
        {
            Context = context;
        }
    }
}
