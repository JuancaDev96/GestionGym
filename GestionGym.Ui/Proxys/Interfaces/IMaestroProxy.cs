﻿using GestionGym.Dto.Response.Maestros;
using GestionGym.Dto.Response;
using GestionGym.Dto.Request.Maestros;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IMaestroProxy
    {
        Task<PaginationResponse<DetalleMaestroResponse>> ListarDetalleMaestroByCodigo(ListaDetalleMaestroRequest request);
    }
}