using AutoMapper;
using Bakery.Common.Enums;
using Bakery.Data.Entities;
using Bakery.DataAccess.Interfaces;
using Bakery.Services.DTOs;
using Bakery.Services.Interfaces;
using Bakery.Services.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.Services
{
    public class BunService: BaseService, IBunService
    {
        private readonly IMapper _mapper;
        public BunService(IRepository repo, IMapper mapper)
            : base(repo)
        {
            _mapper = mapper;
        }

        public async Task<ResultDto> CreateNewBuns(int count)
        {

            List<Bun> buns = new List<Bun>();
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                int price = rnd.Next(50, 100);
                int type = rnd.Next(0, 4);
                int hours = rnd.Next(0, 10);

                Bun bun = new Bun()
                {
                    CreatedDate = DateTime.Now,
                    SalesDeadline = DateTime.Now.AddDays(1),
                    NumberOfHours = hours,
                    StartPrice = price,
                    CurrentPrice = price,
                    Type = (BunTypes)type
                };
                buns.Add(bun);
            }

            await _repo.Context.Buns.AddRangeAsync(buns);
            _repo.Context.SaveChanges();

            var resultDto = new ResultDto();
            resultDto.Success = true;
            return resultDto;
        }

        public async Task<List<GetBunDto>> GetAll()
        {
            DateTime currentDate = DateTime.Now;

            List<Bun> buns = await _repo.Context.Buns
                .Where(x => x.IsActive)
                .ToListAsync();

            List<GetBunDto> dtosList = new List<GetBunDto>();

            foreach (var bun in buns)
            {
                dtosList.Add(CheckDate(bun, currentDate));
            }

            return dtosList;
        }

        private GetBunDto CheckDate(Bun bun, DateTime currentDate)
        {
            GetBunDto dto = _mapper.Map<GetBunDto>(bun);

            DateTime bunDate = bun.CreatedDate.AddHours(bun.NumberOfHours);
            double hoursOfDifference = (currentDate - bunDate).TotalHours;

            if (bun.Type != BunTypes.Pretzel)
            {
                int coefficient = 1;

                if (bun.Type == BunTypes.SourCreamBun) coefficient = (int)hoursOfDifference + 1;

                double sale = (bun.StartPrice * 0.02) * coefficient;

                dto.NextPrice -= sale;
                if (dto.NextPrice < 0)
                {
                    dto.NextPrice = 0;
                }

                dto.NextDate = currentDate.AddHours(coefficient);
            } 
            else
            {
                var diff = (currentDate - bun.SalesDeadline).TotalMinutes;

                if (diff > 0)
                {
                    dto.NextPrice = bun.StartPrice / 2;
                    dto.NextDate = bun.SalesDeadline;
                }
            }
            switch (dto.Type) 
            { 
                case BunTypes.Pretzel:
                    dto.Name = "Крендель";
                    break;
                case BunTypes.Сroissant:
                    dto.Name = "Круассан";
                    break;
                case BunTypes.Baguette:
                    dto.Name = "Багет";
                    break;
                case BunTypes.SourCreamBun:
                    dto.Name = "Сметанник";
                    break;
                case BunTypes.LongLoaf:
                    dto.Name = "Батон";
                    break;
            }


            return dto;

        }

    }
}
