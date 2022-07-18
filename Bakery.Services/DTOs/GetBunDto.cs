using Bakery.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.DTOs
{
    public class GetBunDto
    {
        public int Id { get; set; }
        public double StartPrice { get; set; }
        public double CurrentPrice { get; set; }
        public double NextPrice { get; set; }
        public string Name { get; set; }
        public BunTypes Type { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
