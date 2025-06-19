using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Barbearia.Repositories
{
	public class ClientRepository
	{
		private readonly string _connectionString;
		public ClientRepository()
		{
			_connectionString = ConfigurationManager.ConnectionStrings["BarbeariaDB"].ConnectionString;
		}
        public async Task<List<Models.Client>> GetAllClients()
		{
			List<Models.Client> ClientList = new List<Models.Client>();
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM Client;",conn))
				{
					using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
					{
                        while (await dr.ReadAsync())
                        {
                            ClientList.Add(new Models.Client
                            {
                                Id = dr.GetInt32(dr.GetOrdinal("Id")),
                                Name = dr.GetString(dr.GetOrdinal("Name")),
                                Phone = dr.GetString(dr.GetOrdinal("Phone"))
                            });
                        }
                    }
                }
			}
            return ClientList;
        }
	
		public async Task<Models.Client> GetClientByName(string name)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM Client WHERE Name LIKE '%'@name'%';",conn))
				{
					cmd.Parameters.AddWithValue("@name", name);
					using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
					{
                        if (await dr.ReadAsync())
                        {
                            return new Models.Client
                            {
                                Id = dr.GetInt32(dr.GetOrdinal("Id")),
                                Name = dr.GetString(dr.GetOrdinal("Name")),
                                Phone = dr.GetString(dr.GetOrdinal("Phone"))
                            };
                        }
                    }
                }
			}
            return null;
        }
	
		public async Task<Models.Client> GetClientByPhone(string phone)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM Client WHERE Phone = @phone;",conn))
				{
					cmd.Parameters.AddWithValue("@phone", phone);
					using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
					{
                        if (await dr.ReadAsync())
                        {
                            return new Models.Client
                            {
                                Id = dr.GetInt32(dr.GetOrdinal("Id")),
                                Name = dr.GetString(dr.GetOrdinal("Name")),
                                Phone = dr.GetString(dr.GetOrdinal("Phone"))
                            };
                        }
                    }
                }
			}
            return null;
        }
	
		public async Task<bool> CreateClient(Models.Client client)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("INSERT INTO Client (Name,Phone) VALUES(@Name,@Phone);",conn))
				{
					cmd.Parameters.AddWithValue("@Name", client.Name);
					cmd.Parameters.AddWithValue("@Phone", client.Phone);

                    if (await cmd.ExecuteNonQueryAsync() > 0)
                    {
						return true;
                    }

					return false;
                }
			}
		}
		
		public async Task<bool> EditClient(Models.Client client)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("UPDATE Client SET (Name = @Name,Phone = @Phone) WHERE Id = @Id",conn))
				{
                    cmd.Parameters.AddWithValue("@Id", client.Id);
                    cmd.Parameters.AddWithValue("@Name", client.Name);
					cmd.Parameters.AddWithValue("@Phone", client.Phone);

                    if (await cmd.ExecuteNonQueryAsync() > 0)
                    {
						return true;
                    }

					return false;
                }
			}
		}
	
		public async Task<bool> DeleteClient(int id)
		{
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("DELETE FROM Client WHERE Id = @Id;",conn))
				{
					cmd.Parameters.AddWithValue("@Id", id);

                    if (await cmd.ExecuteNonQueryAsync() > 0)
                    {
						return true;
                    }

					return false;
                }
			}
		}
	}
}