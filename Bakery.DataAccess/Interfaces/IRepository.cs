using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DataAccess.Interfaces
{
    public interface IRepository
    {
        BackeryDbContext Context { get; }
    }
}
