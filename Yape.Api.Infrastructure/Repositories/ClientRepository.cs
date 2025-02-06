using MySql.Data.MySqlClient;
using Dapper;
using Yape.Api.Core.Interfaces;
using Yape.Api.Core.Models;

namespace Yape.Api.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(string connectionString) => _connectionString = connectionString;

        public async Task AddClientAsync(Client client)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = "INSERT INTO persons (Name, LastName, CellPhoneNumber, DocumentType, DocumentNumber) VALUES (@Name, @LastName, @CellPhoneNumber, @DocumentType, @DocumentNumber)";
            await connection.ExecuteAsync(query, client);
        }

        public async Task<bool> ExistsByDocumentAsync(string documentType, string documentNumber)
        {
            using var connection = new MySqlConnection(_connectionString);
            var query = "SELECT COUNT(1) FROM persons WHERE DocumentType = @DocumentType AND DocumentNumber = @DocumentNumber";
            var count = await connection.ExecuteScalarAsync<int>(query, new { DocumentType = documentType, DocumentNumber = documentNumber });
            return count > 0;
        }
    }
}