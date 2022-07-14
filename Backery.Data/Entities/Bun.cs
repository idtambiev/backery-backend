using Bakery.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Data.Entities
{
    public class Bun
    {
        public int Id { get; set; }
        public int StartPrice { get; set; }
        public int CurrentPrice { get; set; }
        public BunTypes Type { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
