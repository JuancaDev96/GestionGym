using AutoMapper;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClientePaginadoInfo, ListaClientesResponse>();
            CreateMap<DatosPersonalesRequest, Cliente>();
            CreateMap<ControlFisicoClienteInfo, ListaControlFisicoClienteResponse>();
            CreateMap<Cliente, InformacionClienteResponse>();
            CreateMap<ParametroClienteRequest, ControlfisicoCliente>();
            CreateMap<ControlFisicoClienteRequest, ControlfisicoCliente>();
            CreateMap<HistorialMedicoClienteInfo, ListaHistorialMedicoClienteResponse>();
            CreateMap<ParametroClienteRequest, HistorialmedicoCliente>();
            CreateMap<HistorialMedicoClienteRequest, HistorialmedicoCliente>();
        }
    }
}
