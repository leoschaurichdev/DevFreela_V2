using DevFreela.Application.DTOs;
using DevFreela.Core.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace DevFreela.Infrastructure.Payments
{
   public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentBaseUrl;
        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> ProcessPayment (PaymentInfoDTO paymentInfoDTO)
        {
            var url = $"{ _paymentBaseUrl}/api/Payments";
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoContent = new StringContent(
                    paymentInfoJson, 
                    Encoding.UTF8,
                    "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Passou por aqui");
            }
                
            return response.IsSuccessStatusCode;
        }
    }
}
