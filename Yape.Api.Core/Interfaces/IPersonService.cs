using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Yape.Api.Core.Models;

namespace Yape.Api.Core.Interfaces
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        Task<List<Client>> GetPersonsByPhone(string cellPhoneNumber);
    }
}
