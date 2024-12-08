using GestionGym.Entidades;
using GestionGym.Entidades.Response.Ejercicios;
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
        Task<List<RecursosEjercicioInfo>> ObtenerRecursosByIdEjercicio(int idEjercicio);
    }
}
