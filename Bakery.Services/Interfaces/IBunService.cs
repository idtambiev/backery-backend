using Bakery.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.Interfaces
{
    public interface IBunService
    {
        Task<ResultDto> GetAll(int count);
    }
}
