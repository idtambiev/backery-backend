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
        public double StartPrice { get; set; }
        public double CurrentPrice { get; set; }
        public int NumberOfHours { get; set; }
        public BunTypes Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SalesDeadline { get; set; }

    }
}
