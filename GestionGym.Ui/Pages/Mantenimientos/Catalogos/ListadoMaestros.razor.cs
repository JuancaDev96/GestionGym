using BlazorBootstrap;
using Blazored.Toast.Services;
using GestionGym.Comun;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Dto.Response.Maestros;
using GestionGym.Ui.Proxys.Interfaces;
using GestionGym.Ui.Shared;
using Microsoft.AspNetCore.Components;

namespace GestionGym.Ui.Pages.Mantenimientos.Catalogos
{
    public partial class ListadoMaestros
    {
        [Inject] public IMaestroProxy Proxy { get; set; } = default!;
        [Inject] public NavigationManager navigator { get; set; } = default!;
        [Inject] public IToastService ToastService { get; set; } = default!;

        public bool isLoading { get; set; } = false;

        Grilla<ListaMaestrosResponse> GrillaMaestros { get; set; } = default!;
        public BusquedaMaestroRequest RequestBusqueda { get; set; } = new() { Pagina = 1, Filas = 10 };

        public Modal ModalCatalogoForm { get; set; } = default!;
        public MaestroRequest RequestCatalogo { get; set; } = new();

        private async Task<GridDataProviderResult<ListaMaestrosResponse>> ProveedorMaestros(GridDataProviderRequest<ListaMaestrosResponse> request)
        {
            isLoading = true;
            try
            {
                RequestBusqueda.Pagina = request.PageNumber;
                RequestBusqueda.Filas = request.PageSize;
                var response = await Proxy.ListarMaestros(RequestBusqueda);
                if (response is { Success: true })
                {
                    return await Task.FromResult(new GridDataProviderResult<ListaMaestrosResponse>()
                    {
                        Data = response.Collection,
                        TotalCount = response.TotalRegistros
                    });
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowWarning($"Error al registrar datos personales:{ex.Message}");
            }
            finally
            {
                isLoading = false;
                StateHasChanged();
            }
            return await Task.FromResult(new GridDataProviderResult<ListaMaestrosResponse>());
        }

        private async Task OnBuscar()
        {
            await GrillaMaestros.ActualizarGrid();
        }

        private async Task OnRefrescar()
        {
            RequestBusqueda = new() { Pagina = 1, Filas = 10 };
            await GrillaMaestros.ActualizarGrid();
        }

        private async Task OnNuevoMaestro()
        {
            await ModalCatalogoForm.ShowAsync();
        }

        private async Task GuardarCatalogo()
        {
            try
            {
                isLoading = true;
                RequestCatalogo.IdEstablecimiento = Constantes.IdEstablecimientoDefault;


                if(RequestCatalogo.Id != 0)
                {
                    var resultado = await Proxy.ActualizarCatalogo(RequestCatalogo);
                    if (resultado is { Success: false })
                    {
                        ToastService.ShowWarning($"Error al actualizar catalogo:{resultado.Message}");
                    }
                    else
                    {
                        ToastService.ShowSuccess($"Catalogo actualizado");
                        await GrillaMaestros.ActualizarGrid();
                        await OnCancelar();
                    }
                }
                else
                {
                    var resultado = await Proxy.GuardarCatalogo(RequestCatalogo);
                    if (resultado is { Success: false })
                    {
                        ToastService.ShowWarning($"Error al registrar catalogo:{resultado.Message}");
                    }
                    else
                    {
                        ToastService.ShowSuccess($"Catalogo registrado");
                        await GrillaMaestros.ActualizarGrid();
                        await OnCancelar();
                    }
                }

                
            }
            catch (Exception ex)
            {
                ToastService.ShowWarning($"Error al registrar datos personales:{ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task OnCancelar()
        {
            RequestCatalogo = new();
            await ModalCatalogoForm.HideAsync();
        }

        private async void OnEditarMaestro(ListaMaestrosResponse item)
        {
            try
            {
                var resultado = await Proxy.BuscarCatalogoPorId(item.Id);

                if(resultado is not null && resultado.Data is not null)
                {
                    Utils.Map(resultado.Data, RequestCatalogo);
                    await ModalCatalogoForm.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                ToastService.ShowWarning($"Error al registrar datos personales:{ex.Message}");
            }
            
        }

        private void OnVerElementos(ListaMaestrosResponse item)
        {
            navigator.NavigateTo($"/catalogos/detalles/{item.Id}");
        }
    }
}
