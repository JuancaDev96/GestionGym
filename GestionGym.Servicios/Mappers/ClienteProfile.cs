﻿using AutoMapper;
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
            CreateMap<ClientePaginadoResponse, ListaClientesResponse>();
            CreateMap<DatosPersonalesRequest, Cliente>();
        }
    }
}