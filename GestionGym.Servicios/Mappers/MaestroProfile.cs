using AutoMapper;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Mappers
{
    public class MaestroProfile : Profile
    {
        public MaestroProfile()
        {
            CreateMap<MaestroDetalleInfo, DetalleMaestroResponse>();
            CreateMap<Maestro, ListaMaestrosResponse>();
            CreateMap<MaestroRequest, Maestro>();
            CreateMap<Maestro, MaestroResponse>();
            CreateMap<MaestroDetalleRequest, Maestrodetalle>();
            CreateMap<Maestrodetalle, MaestroDetalleResponse>();
            CreateMap<MaestroDetalleInfo, ListaMaestroDetalleResponse>();
        }
    }
}
