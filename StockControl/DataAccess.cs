using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace StockControl
{
    public class DataAccess
    {
        private string connectionString = "";
        /// <summary>
        /// Выполняет подключение к базе данных.
        /// </summary>
        /// <param name="connectionString">Строка подключения.</param>
        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// Выполняет заполнение объетов данными.
        /// </summary>
        /// <returns>Список паллет.</returns>
        public List<Pallet> GetAllPallets()
        {
            List<Pallet> pallets = new List<Pallet>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Width, Height, Depth FROM Pallets";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pallet pallet = new Pallet
                        {
                            Id = (int)reader["Id"],
                            Width = (int)reader["Width"],
                            Height = (int)reader["Height"],
                            Depth = (int)reader["Depth"],
                            Boxes = new List<Box>()
                        };
                        pallets.Add(pallet);
                    }
                }
                foreach (Pallet pallet in pallets)
                {
                    query = "SELECT Id, Before_date, Date_creation, Height, Depth, Weight, Width FROM Boxes WHERE Id_pallet = @IdPallet";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdPallet", pallet.Id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Box box = new Box
                            {
                                Id = (int)reader["Id"],
                                BeforeDate = reader.IsDBNull(reader.GetOrdinal("Before_date")) ? null : (DateTime?)reader["Before_date"],
                                DateCreation = reader.IsDBNull(reader.GetOrdinal("Date_creation")) ? null : (DateTime?)reader["Date_creation"],
                                Height = (int)reader["Height"],
                                Depth = (int)reader["Depth"],
                                Weight = (int)reader["Weight"],
                                Width = (int)reader["Width"],
                                Volume = (int)reader["Height"] * (int)reader["Depth"] * (int)reader["Width"],
                                IdPallet = pallet.Id
                            };
                            if(box.Width <= pallet.Width && box.Depth <= pallet.Depth)
                                pallet.Boxes.Add(box);
                            else
                                throw new Exception("Каждая коробка не должна превышать по размерам паллету!");
                        }
                    }
                    PalletСalculate palletСalculate = new PalletСalculate();
                    pallet.Weight = palletСalculate.WeightСalculate(pallet.Boxes);
                    pallet.BeforeDate = palletСalculate.BeforeDateСalculate(pallet.Boxes);
                    pallet.Volume = pallet.Depth * pallet.Width * pallet.Height + palletСalculate.VolumeСalculate(pallet.Boxes);
                }
            }
            return pallets;
        }
    }
}
