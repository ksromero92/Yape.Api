using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Yape.Api.Core.Interfaces;
using Yape.Api.Core.Models;

namespace Yape.Api.Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly string _wcfEndpoint;

        public PersonService(string wcfEndpoint) => _wcfEndpoint = wcfEndpoint;

        public async Task<List<Client>> GetPersonsByPhone(string cellPhoneNumber)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(_wcfEndpoint);
            var factory = new ChannelFactory<IPersonService>(binding, endpoint);
            var client = factory.CreateChannel();

            try
            {
                var persons = await client.GetPersonsByPhone(cellPhoneNumber);
                return persons ?? new List<Client>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consumir WCF: {ex.Message}");
                return new List<Client>();
            }
        }
    }
}
