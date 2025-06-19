using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Barbearia.Repositories
{
	public class BarbersRepository
	{
		private readonly string _connectionString;
		public BarbersRepository()
		{
			_connectionString = Configurations.Configurations.GetConnString();
		}
		public async Task<List<Models.Barber>> GetAll()
		{
			List<Models.Barber> BarberList = new List<Models.Barber>();
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				await conn.OpenAsync();
				using (SqlCommand cmd = new SqlCommand("SELECT * FROM Barber;",conn))
				{
					using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
					{
                         BarberList.Add(new Models.Barber
                        {
                            Id = dr.GetInt32(dr.GetOrdinal("Id")),
							Name = dr.GetString(dr.GetOrdinal("Name")),
							Phone = dr.GetString(dr.GetOrdinal("Phone")),
							StartTimeWork = dr.GetTimeSpan(dr.GetOrdinal("StartTimeWork")),
                            EndTimeWork = dr.GetTimeSpan(dr.GetOrdinal("EndTimeWork")),
                            DefaultDurationService = dr.GetInt32(dr.GetOrdinal("DefaultDurationService"))
                        });
                    }
				}
			}
			return BarberList;
        }
	}
}