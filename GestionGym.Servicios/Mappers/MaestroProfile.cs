using AutoMapper;
using GestionGym.Dto.Response.Maestros;
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
            CreateMap<MaestroDetalleResponse, DetalleMaestroResponse>();
        }
    }
}
