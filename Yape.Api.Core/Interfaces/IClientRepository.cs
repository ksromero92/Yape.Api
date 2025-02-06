using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yape.Api.Core.Models;

namespace Yape.Api.Core.Interfaces
{
    public interface IClientRepository
    {
        Task AddClientAsync(Client client);
        Task<bool> ExistsByDocumentAsync(string documentType, string documentNumber);
    }
}
