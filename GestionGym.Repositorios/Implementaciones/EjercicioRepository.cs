using Dapper;
using GestionGym.AccesoDatos.Contexto;
using GestionGym.Comun;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Entidades.Response.Suscripcion;
using GestionGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionGym.Repositorios.Implementaciones
{
    public class EjercicioRepository : BaseRepository<Ejercicio>, IEjercicioRepository
    {
        private readonly BdGymContext _contexto;
        public EjercicioRepository(BdGymContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
       
    }
}
