using AutoMapper;
using GestionGym.Dto.Request.Suscripciones;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Entidades.Response.Suscripcion;
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
            CreateMap<DetalleSuscripcionInfo, DetalleSuscripcionResponse>();
            CreateMap<ClienteInfo, ClienteResponse>();
            CreateMap<FichaClienteInfo, FichaClienteResponse>();
        }
    }
}
