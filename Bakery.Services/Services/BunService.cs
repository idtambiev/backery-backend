using Bakery.Common.Enums;
using Bakery.Data.Entities;
using Bakery.DataAccess.Interfaces;
using Bakery.Services.DTOs;
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

        public async Task<ResultDto> GetAll(int count)
        {

            List<Bun> buns = new List<Bun>();

            for (int i = 0; i < count; i++)
            {
                Bun bun = new Bun()
                {
                    CreatedDate = DateTime.Now,
                    SalesDeadline = DateTime.Now.AddDays(1),
                    NumberOfHours = 5,
                    StartPrice = 90,
                    CurrentPrice = 90,
                    Type = BunTypes.Baguette
                };
                buns.Add(bun);
            }

            await _repo.Context.Buns.AddRangeAsync(buns);
            _repo.Context.SaveChanges();

            var resultDto = new ResultDto();
            resultDto.Success = true;
            return resultDto;
        }
    }
}
