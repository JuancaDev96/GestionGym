using AutoMapper;
using GestionGym.Dto.Request.Suscripciones;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Mappers
{
    public class SuscripcionProfile : Profile
    {
        public SuscripcionProfile()
        {
            CreateMap<Preciossuscripcion, ListaPreciosTipoSuscripcionResponse>();
            CreateMap<SuscripcionRequest, Suscripcion>();
            CreateMap<SuscripcionRequest, Cliente>();
        }
    }
}
