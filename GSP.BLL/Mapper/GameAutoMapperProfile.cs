﻿using System;
using System.Collections.Generic;
using AutoMapper;
using GSP.BLL.Dto.Game;
using GSP.BLL.Dto.Rate;
using GSP.Domain.Games;

namespace GSP.BLL.Mapper
{
    public class GameAutoMapperProfile : Profile
    {
        public GameAutoMapperProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(x => x.Photo, p => p.MapFrom(t => $"data:image/png;base64,{Convert.ToBase64String(t.Photo)}"))
                .ForMember(x => x.Rates, p => p.MapFrom(t => AutoMapper.Mapper.Map<ICollection<Rate>, List<RateDto>>(t.Rates)))
                .ForMember(x => x.CategoryName, p => p.MapFrom(t => t.Category.Name));

            CreateMap<CreateGameDto, Game>()
                .ForMember(x => x.Rates, p => p.Ignore())
                .ForMember(x => x.Orders, p => p.Ignore())
                .ForMember(x => x.Category, p => p.Ignore())
                .ForMember(x => x.IsDeleted, p => p.UseValue(false));
        }
    }
}