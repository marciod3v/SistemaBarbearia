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
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BarbeariaDB"].ConnectionString);
        public SqlCommand cmd = new SqlCommand();
		public SqlDataReader dr;

        public async Task<List<Models.Client>> GetAllClients()
		{
			List<Models.Client> ClientList = new List<Models.Client>();
			using (conn)
			{
				await conn.OpenAsync();
				using (cmd)
				{
					cmd.CommandText = "SELECT * FROM Client;";
					dr = await cmd.ExecuteReaderAsync();

                    while (await dr.ReadAsync())
                    {
						ClientList.Add(new Models.Client
						{
							Id = dr.GetInt32(dr.GetOrdinal("Id")),
							Name = dr.GetString(dr.GetOrdinal("Name")),
							Phone = dr.GetString(dr.GetOrdinal("Phone"))
						});
                    }

					return ClientList;
                }
			}
		}
	
		public async Task<Models.Client> GetClientByName(string name)
		{
			using (conn)
			{
				await conn.OpenAsync();
				using (cmd)
				{
					cmd.CommandText = "SELECT * FROM Client WHERE Name LIKE '%'@name'%';";
					cmd.Parameters.AddWithValue("@name", name);
					dr = await cmd.ExecuteReaderAsync();
                    if (await dr.ReadAsync())
                    {
						var client = new Models.Client
						{
							Id = dr.GetInt32(dr.GetOrdinal("Id")),
							Name = dr.GetString(dr.GetOrdinal("Name")),
							Phone = dr.GetString(dr.GetOrdinal("Phone"))
						};

						return client;
                    }

					return null;
                }
			}
		}
	}
}