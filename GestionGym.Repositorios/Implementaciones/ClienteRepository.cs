using GestionGym.AccesoDatos.Contexto;
using GestionGym.Entidades;
using GestionGym.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Implementaciones
{
    public class ClienteRepository: BaseRepository<Cliente>, IClienteRepository
    {
        private readonly BdGymContext _contexto;
        public ClienteRepository(BdGymContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
