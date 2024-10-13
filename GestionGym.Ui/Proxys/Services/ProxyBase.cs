using GestionGym.Dto.Response;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Net;
using System.Text.Json;
using System.Text;

namespace GestionGym.Ui.Proxys.Services
{
    public abstract class ProxyBase
    {
        protected readonly HttpClient HttpClient;

        protected string BaseUrl { get; set; }

        protected ProxyBase(string baseUrl, HttpClient httpClient)
        {
            BaseUrl = baseUrl;
            HttpClient = httpClient;
        }

        protected async Task<TOutput?> SendAsync<TInput, TOutput>(TInput request, HttpMethod method, string url)
            where TOutput : BaseResponse
        {
            var separador = url.StartsWith('?') | url.StartsWith('/') ? string.Empty : "/";

            var requestMessage = new HttpRequestMessage(method, $"{BaseUrl}{separador}{url}");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8,
                MediaTypeNames.Application.Json);

            var response = await HttpClient.SendAsync(requestMessage);

            var result = await response.Content.ReadFromJsonAsync<TOutput>();
            if (result != null)
            {
                return result;
            }

            throw new InvalidOperationException($"Error en la solicitud {url}");
        }

        /// <summary>
        /// Metodo Get fuertemente tipado
        /// </summary>
        /// <typeparam name="TOutput">Clase de salida</typeparam>
        /// <param name="url">URL del metodo a consultar (sin incluir el BaseUrl)</param>
        /// <returns>La instancia de <see cref="TOutput"/></returns>
        /// <exception cref="InvalidOperationException">Si existe un error en el metodo se establece la excepcion</exception>
        protected async Task<TOutput> SendAsync<TOutput>(string url)
            where TOutput : BaseResponse
        {
            try
            {
                var separador = url.StartsWith('?') | url.StartsWith('/') ? string.Empty : "/";

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}{separador}{url}");

                var response = await HttpClient.SendAsync(requestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                    throw new InvalidOperationException(errorResponse!.Message);
                }

                var result = await response.Content.ReadFromJsonAsync<TOutput>();
                if (result is not null)
                {
                    return result;
                }

                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error en la solicitud {ex.Message}");
            }
        }

        protected async Task<TOutput> SendAsync<TOutput>(string url, HttpMethod httpMethod)
            where TOutput : BaseResponse
        {
            try
            {
                var separador = url.StartsWith('?') | url.StartsWith('/') ? string.Empty : "/";

                var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}{separador}{url}");

                var response = await HttpClient.SendAsync(requestMessage);

                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<BaseResponse>();
                    throw new InvalidOperationException(errorResponse!.Message);
                }

                var result = await response.Content.ReadFromJsonAsync<TOutput>();
                if (result is not null)
                {
                    return result;
                }

                throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error en la solicitud {ex.Message}");
            }
        }

        /// <summary>
        /// Metodo que crea la URL con los parametros automaticamente basado en una clase DTO
        /// </summary>
        /// <typeparam name="T">Entidad generica</typeparam>
        /// <param name="request">Parametro de tipo generico que recibirá el nombre y valor de los parametros</param>
        /// <returns></returns>
        protected static string QueryStringDto<T>(T request)
        {
            var properties = typeof(T).GetProperties();
            var queryString = new StringBuilder();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(request);
                if (value != null)
                {
                    queryString.Append($"{prop.Name}={Uri.EscapeDataString(value.ToString() ?? string.Empty)}&");
                }
            }

            // Eliminar el último '&' si existe
            if (queryString.Length > 0)
                queryString.Length--;

            return queryString.ToString();
        }

        protected static string QueryStringCollection<T>(string paramName, List<T> values)
        {
            if (!values.Any())
            {
                return string.Empty;
            }

            // Generar la cadena query con los valores del parámetro
            var queryString = string.Join("&", values.Select(value => $"{paramName}={Uri.EscapeDataString(value?.ToString() ?? string.Empty)}"));

            return queryString;
        }
    }
}
