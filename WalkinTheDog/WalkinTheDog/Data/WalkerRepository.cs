using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WalkinTheDog.Models;

namespace WalkinTheDog.Data
{
    public class WalkerRepository
    {
        public SqlConnection Connection
        {
            get
            {
                string _connectionString = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=DogWalking; Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }

        public List<Walker> GetAllWalkers()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, w.[Name], w.NeighborhoodId, n.Id, n.[Name] AS 'Neighborhood Name'
                        FROM Walker w
                        LEFT JOIN Neighborhood n
                        ON w.NeighborhoodId = n.Id";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walker> allWalkers = new List<Walker>();

                    while(reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int nameColumnPosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(nameColumnPosition);

                        int neighborhoodIdColumnPosition = reader.GetOrdinal("Id");
                        int neighborhoodValue = reader.GetInt32(neighborhoodIdColumnPosition);

                        int neighborhoodNameColumn = reader.GetOrdinal("Neighborhood Name");
                        string neighborhoodNameValue = reader.GetString(neighborhoodNameColumn);

                        Walker walker = new Walker()
                        {
                            Id = idValue,
                            Name = nameValue,
                            NeighborhoodId = neighborhoodValue,
                            Neighborhood = new Neighborhood()
                            {
                                Id = neighborhoodValue,
                                Name = neighborhoodNameValue
                            }
                        };

                        allWalkers.Add(walker);
                    }

                    reader.Close();

                    return allWalkers;
                }
            }
        }
    }
}
