using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace GestionGym.Ui.Shared;

public partial class Grilla<TItem>
{
    private Grid<TItem> Grid { get; set; } = default!;

    [Parameter] public string Titulo { get; set; } = nameof(TItem).Equals("") ? "" : $"Lista de {nameof(TItem)}";
    [Parameter] public string ClassTitulo { get; set; } = "mb-5 text-uppercase";
    

    [Parameter] public TItem Item { get; set; } = default!;

    [Parameter] public RenderFragment? Filtros { get; set; }

    [Parameter] public RenderFragment? ColumnasAdicionales { get; set; } = default!;

    [Parameter] public GridDataProviderDelegate<TItem> ProveedorData { get; set; } = default!;

    [Parameter] public bool MultiSelect { get; set; } = false;

    [Parameter] public Alignment HeaderAlign { get; set; }

    [Parameter] public Alignment TextAlign { get; set; }

    [Parameter] public EventCallback<TItem> OnSelectedCheckEvent { get; set; }

    [Parameter] public bool ColumnasAutomaticas { get; set; } = true;

    public async Task ActualizarGrid()
    {
        await Grid.RefreshDataAsync();
    }
}