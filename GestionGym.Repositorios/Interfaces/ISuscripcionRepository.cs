﻿using GestionGym.Dto.Request.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
    public interface ISuscripcionRepository : IBaseRepository<Suscripcion>
    {
        Task<List<Preciossuscripcion>> ListarPreciosTipoSuscripcion(int idTipoSuscripcion);
        Task<Suscripcion> Registrar(Suscripcion request, Cliente cliente, DateTime FechaInicio, int IdObjetivo, int IdNivel);
    }
}