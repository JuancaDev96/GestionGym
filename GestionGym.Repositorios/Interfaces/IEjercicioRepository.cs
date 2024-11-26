using GestionGym.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
    public interface IEjercicioRepository: IBaseRepository<Ejercicio>
    {
        Task Registrar(Ejercicio request, List<Rutinaejercicio> rutina);
        Task<List<Rutinaejercicio>> ObtenerRutinaByIdEjercicio(int idEjercicio);
        Task<Recursosejercicio> RegistrarRecurso(Recursosejercicio request);
    }
}
