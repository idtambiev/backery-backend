using Bakery.DataAccess.Interfaces;
using Bakery.Services.Interfaces;
using Bakery.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.Services
{
    public class BunService: BaseService, IBunService
    {
        public BunService(IRepository repo)
            : base(repo)
        {

        }
    }
}
