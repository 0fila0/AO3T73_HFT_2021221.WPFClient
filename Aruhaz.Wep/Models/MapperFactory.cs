// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// Mapper factory.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Create Mapper method.
        /// </summary>
        /// <returns> A config. </returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Products.Data.Models.Aruhaz, AruhazWeb.Models.Aruhaz>()
                .ForMember(dest => dest.AruhazNeve, map => map.MapFrom(src => src.AruhazNeve == null ? string.Empty : src.AruhazNeve))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.EMail == null ? string.Empty : src.EMail))
                .ForMember(dest => dest.Honlap, map => map.MapFrom(src => src.Honlap == null ? string.Empty : src.Honlap))
                .ForMember(dest => dest.Kozpont, map => map.MapFrom(src => src.Kozpont == null ? string.Empty : src.Kozpont))
                .ForMember(dest => dest.Adoszam, map => map.MapFrom(src => src.Adoszam))
                .ForMember(dest => dest.Telefon, map => map.MapFrom(src => src.Telefon == null ? 0 : src.Telefon));
            });

            return config.CreateMapper();
        }
    }
}
