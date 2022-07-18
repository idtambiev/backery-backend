using AutoMapper;
using Bakery.Data.Entities;
using Bakery.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Services.AutoMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Bun, GetBunDto>();

        }
    }
}
