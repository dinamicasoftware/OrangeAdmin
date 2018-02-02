using System;
using AutoMapper;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.Mappings
{
    class Config
    {
        public static MapperConfiguration MapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Client, ClientDTO>();
            cfg.CreateMap<Client, ClientGridDTO>();
        });
    }
}
