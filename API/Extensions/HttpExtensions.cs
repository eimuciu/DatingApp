using System.Globalization;
using System.Text.Json;
using API.Helpers;

namespace API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            // Because it is a custom header we have to allow this header to be accessed by CORS
            response.Headers.Add("Access-Control-Exponse-Headers", "Pagination");
        }
    }
}