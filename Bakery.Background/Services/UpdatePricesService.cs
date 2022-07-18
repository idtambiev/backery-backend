using Bakery.Common.Enums;
using Bakery.Data.Entities;
using Bakery.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Background.Services
{
    public class UpdatePricesService : IUpdatePricesService
    {
        private IServiceProvider _services { get; }
        public UpdatePricesService(IServiceProvider services)
        {
            _services = services;
        }

        public async Task UpdatePrices()
        {
            using (var scope = _services.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetRequiredService<BackeryDbContext>();

                List<Bun> buns = await GetAll(context);
                DateTime currentDate = DateTime.Now;

                foreach (var bun in buns)
                {
                    double hoursDifference = GetDatesDifference(currentDate, bun);

                    if (CheckExpiredBun(hoursDifference, bun))
                    {
                        continue;
                    }

                    switch (bun.Type)
                    {
                        case BunTypes.Pretzel:
                            PretzelAlgorythm(bun, currentDate);
                            break;
                        default:
                            UsuallBunAlgorythm(hoursDifference, bun);
                            break;

                    }
                }

            }

        }

        private async Task<List<Bun>> GetAll(BackeryDbContext context)
        {
            try
            {
                List<Bun> buns = await context.Buns
                    .Where(x => x.IsActive)
                    .ToListAsync();

                return buns;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private double GetDatesDifference(DateTime currentDate, Bun bun)
        {
            DateTime bunDate = bun.CreatedDate.AddHours(bun.NumberOfHours);
            double datesDifference = (currentDate - bunDate).TotalHours;

            return datesDifference;
        }

        private bool CheckExpiredBun(double hoursDifference, Bun bun)
        {

            if (hoursDifference <= 0)
            {
                bun.IsActive = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UsuallBunAlgorythm(double hoursDifference, Bun bun)
        {
            int coefficient = 1;

            if (bun.Type == BunTypes.SourCreamBun) coefficient = (int)hoursDifference;

            double sale = (bun.StartPrice * 0.02) * coefficient;

            bun.CurrentPrice -= sale;

            if (bun.CurrentPrice < 0)
            {
                bun.CurrentPrice = 0;
                bun.IsActive = false;
            }
        }


        private void PretzelAlgorythm(Bun bun, DateTime date)
        {

            var diff = (date - bun.SalesDeadline).TotalMinutes;

            if (diff > 0)
            {
                bun.CurrentPrice = bun.StartPrice / 2;
            }
        }


    }
}
