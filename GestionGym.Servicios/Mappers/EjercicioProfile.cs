using AutoMapper;
using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response.Ejercicios;
using GestionGym.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Mappers
{
    public class EjercicioProfile : Profile
    {
        public EjercicioProfile()
        {
            CreateMap<EjercicioRequest, Ejercicio>();
            CreateMap<RutinaEjercicioRequest, Rutinaejercicio>();
        }
    }
}
