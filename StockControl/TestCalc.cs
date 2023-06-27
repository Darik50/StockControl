using Microsoft.Data.SqlClient;
using NUnit.Framework;

namespace StockControl
{
    [TestFixture]
    public class TestCalc
    {
        [Test]
        [Description("Проверяет, что ведется правильный подсчет количества паллет.")]
        public void Test_Count_Pallets()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80),
                    (2, 80, 90, 70),
                    (3, 120, 110, 90),
                    (4, 70, 80, 60),
                    (5, 90, 100, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, NULL, '2023-02-15', 25, 15, 8, 35, 2),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 3),
                    (4, NULL, '2023-03-20', 20, 10, 6, 30, 2),
                    (5, '2023-07-01', NULL, 28, 18, 9, 38, 1),
                    (6, NULL, '2023-01-10', 33, 23, 11, 43, 4),
                    (7, '2023-06-15', NULL, 18, 8, 5, 28, 3),
                    (8, NULL, '2023-03-05', 38, 28, 14, 48, 5),
                    (9, '2023-07-15', NULL, 15, 5, 3, 25, 5),
                    (10, NULL, '2023-02-01', 40, 30, 15, 50, 4),
                    (11, '2023-06-05', NULL, 32, 22, 11, 42, 1),
                    (12, NULL, '2023-01-20', 27, 17, 9, 37, 2),
                    (13, '2023-06-20', NULL, 37, 27, 13, 47, 3),
                    (14, NULL, '2023-02-10', 22, 12, 7, 32, 2),
                    (15, '2023-07-05', NULL, 29, 19, 10, 39, 1),
                    (16, NULL, '2023-01-15', 34, 24, 12, 44, 4),
                    (17, '2023-06-25', NULL, 19, 9, 6, 29, 3),
                    (18, NULL, '2023-02-20', 39, 29, 15, 49, 5),
                    (19, '2023-07-10', NULL, 16, 6, 4, 26, 5),
                    (20, NULL, '2023-02-05', 42, 32, 16, 52, 4),
                    (21, '2023-06-06', NULL, 31, 21, 10, 41, 1),
                    (22, NULL, '2023-01-25', 26, 16, 9, 36, 2),
                    (23, '2023-06-11', NULL, 36, 26, 13, 46, 3),
                    (24, NULL, '2023-03-01', 21, 11, 7, 31, 2),
                    (25, '2023-07-02', NULL, 27, 17, 8, 37, 1),
                    (26, NULL, '2023-01-12', 32, 22, 11, 42, 4),
                    (27, '2023-06-17', NULL, 17, 7, 5, 27, 3),
                    (28, NULL, '2023-02-08', 37, 27, 14, 47, 5),
                    (29, '2023-07-12', NULL, 14, 4, 3, 24, 5),
                    (30, NULL, '2023-02-03', 39, 29, 15, 49, 4);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            Assert.AreEqual(5, pallets.Count);
        }
        [Test]
        [Description("Проверяет, что ведется правильный подсчет количества коробок.")]
        public void Test_Count_Boxs()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80),
                    (2, 80, 90, 70),
                    (3, 120, 110, 90),
                    (4, 70, 80, 60),
                    (5, 90, 100, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, NULL, '2023-02-15', 25, 15, 8, 35, 2),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 3),
                    (4, NULL, '2023-03-20', 20, 10, 6, 30, 2),
                    (5, '2023-07-01', NULL, 28, 18, 9, 38, 1),
                    (6, NULL, '2023-01-10', 33, 23, 11, 43, 4),
                    (7, '2023-06-15', NULL, 18, 8, 5, 28, 3),
                    (8, NULL, '2023-03-05', 38, 28, 14, 48, 5),
                    (9, '2023-07-15', NULL, 15, 5, 3, 25, 5),
                    (10, NULL, '2023-02-01', 40, 30, 15, 50, 4),
                    (11, '2023-06-05', NULL, 32, 22, 11, 42, 1),
                    (12, NULL, '2023-01-20', 27, 17, 9, 37, 2),
                    (13, '2023-06-20', NULL, 37, 27, 13, 47, 3),
                    (14, NULL, '2023-02-10', 22, 12, 7, 32, 2),
                    (15, '2023-07-05', NULL, 29, 19, 10, 39, 1),
                    (16, NULL, '2023-01-15', 34, 24, 12, 44, 4),
                    (17, '2023-06-25', NULL, 19, 9, 6, 29, 3),
                    (18, NULL, '2023-02-20', 39, 29, 15, 49, 5),
                    (19, '2023-07-10', NULL, 16, 6, 4, 26, 5),
                    (20, NULL, '2023-02-05', 42, 32, 16, 52, 4),
                    (21, '2023-06-06', NULL, 31, 21, 10, 41, 1),
                    (22, NULL, '2023-01-25', 26, 16, 9, 36, 2),
                    (23, '2023-06-11', NULL, 36, 26, 13, 46, 3),
                    (24, NULL, '2023-03-01', 21, 11, 7, 31, 2),
                    (25, '2023-07-02', NULL, 27, 17, 8, 37, 1),
                    (26, NULL, '2023-01-12', 32, 22, 11, 42, 4),
                    (27, '2023-06-17', NULL, 17, 7, 5, 27, 3),
                    (28, NULL, '2023-02-08', 37, 27, 14, 47, 5),
                    (29, '2023-07-12', NULL, 14, 4, 3, 24, 5),
                    (30, NULL, '2023-02-03', 39, 29, 15, 49, 4);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            int countBoxs = 0;
            foreach(var pallet in pallets)
            {
                countBoxs += pallet.Boxes.Count;
            }
            Assert.AreEqual(30, countBoxs);
        }
        [Test]
        [Description("Проверяет, что id паллет выводится в правильном порядке после группировки.")]
        public void Test_Result_1()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80),
                    (2, 80, 90, 70),
                    (3, 120, 110, 90),
                    (4, 70, 80, 60),
                    (5, 90, 100, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, NULL, '2023-02-15', 25, 15, 8, 35, 2),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 3),
                    (4, NULL, '2023-03-20', 20, 10, 6, 30, 2),
                    (5, '2023-07-01', NULL, 28, 18, 9, 38, 1),
                    (6, NULL, '2023-01-10', 33, 23, 11, 43, 4),
                    (7, '2023-06-15', NULL, 18, 8, 5, 28, 3),
                    (8, NULL, '2023-03-05', 38, 28, 14, 48, 5),
                    (9, '2023-07-15', NULL, 15, 5, 3, 25, 5),
                    (10, NULL, '2023-02-01', 40, 30, 15, 50, 4),
                    (11, '2023-06-05', NULL, 32, 22, 11, 42, 1),
                    (12, NULL, '2023-01-20', 27, 17, 9, 37, 2),
                    (13, '2023-06-20', NULL, 37, 27, 13, 47, 3),
                    (14, NULL, '2023-02-10', 22, 12, 7, 32, 2),
                    (15, '2023-07-05', NULL, 29, 19, 10, 39, 1),
                    (16, NULL, '2023-01-15', 34, 24, 12, 44, 4),
                    (17, '2023-06-25', NULL, 19, 9, 6, 29, 3),
                    (18, NULL, '2023-02-20', 39, 29, 15, 49, 5),
                    (19, '2023-07-10', NULL, 16, 6, 4, 26, 5),
                    (20, NULL, '2023-02-05', 42, 32, 16, 52, 4),
                    (21, '2023-06-06', NULL, 31, 21, 10, 41, 1),
                    (22, NULL, '2023-01-25', 26, 16, 9, 36, 2),
                    (23, '2023-06-11', NULL, 36, 26, 13, 46, 3),
                    (24, NULL, '2023-03-01', 21, 11, 7, 31, 2),
                    (25, '2023-07-02', NULL, 27, 17, 8, 37, 1),
                    (26, NULL, '2023-01-12', 32, 22, 11, 42, 4),
                    (27, '2023-06-17', NULL, 17, 7, 5, 27, 3),
                    (28, NULL, '2023-02-08', 37, 27, 14, 47, 5),
                    (29, '2023-07-12', NULL, 14, 4, 3, 24, 5),
                    (30, NULL, '2023-02-03', 39, 29, 15, 49, 4);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            var groupedPallet = pallets.GroupBy(p => p.BeforeDate).OrderBy(p => p.Key);
            string result = "";
            foreach (var group in groupedPallet)
            {                
                var groupOrder = group.OrderBy(p => p.Weight);
                foreach (var pallet in groupOrder)
                {
                    result += pallet.Id.ToString();
                }

                Console.WriteLine();
            }
            Assert.AreEqual("42513", result);
        }
        [Test]
        [Description("Проверяет, что id паллет выводится в правильном порядке после сортировки по объему.")]
        public void Test_Result_2()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80),
                    (2, 80, 90, 70),
                    (3, 120, 110, 90),
                    (4, 70, 80, 60),
                    (5, 90, 100, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, NULL, '2023-02-15', 25, 15, 8, 35, 2),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 3),
                    (4, NULL, '2023-03-20', 20, 10, 6, 30, 2),
                    (5, '2023-07-01', NULL, 28, 18, 9, 38, 1),
                    (6, NULL, '2023-01-10', 33, 23, 11, 43, 4),
                    (7, '2023-06-15', NULL, 18, 8, 5, 28, 3),
                    (8, NULL, '2023-03-05', 38, 28, 14, 48, 5),
                    (9, '2023-07-15', NULL, 15, 5, 3, 25, 5),
                    (10, NULL, '2023-02-01', 40, 30, 15, 50, 4),
                    (11, '2023-06-05', NULL, 32, 22, 11, 42, 1),
                    (12, NULL, '2023-01-20', 27, 17, 9, 37, 2),
                    (13, '2023-06-20', NULL, 37, 27, 13, 47, 3),
                    (14, NULL, '2023-02-10', 22, 12, 7, 32, 2),
                    (15, '2023-07-05', NULL, 29, 19, 10, 39, 1),
                    (16, NULL, '2023-01-15', 34, 24, 12, 44, 4),
                    (17, '2023-06-25', NULL, 19, 9, 6, 29, 3),
                    (18, NULL, '2023-02-20', 39, 29, 15, 49, 5),
                    (19, '2023-07-10', NULL, 16, 6, 4, 26, 5),
                    (20, NULL, '2023-02-05', 42, 32, 16, 52, 4),
                    (21, '2023-06-06', NULL, 31, 21, 10, 41, 1),
                    (22, NULL, '2023-01-25', 26, 16, 9, 36, 2),
                    (23, '2023-06-11', NULL, 36, 26, 13, 46, 3),
                    (24, NULL, '2023-03-01', 21, 11, 7, 31, 2),
                    (25, '2023-07-02', NULL, 27, 17, 8, 37, 1),
                    (26, NULL, '2023-01-12', 32, 22, 11, 42, 4),
                    (27, '2023-06-17', NULL, 17, 7, 5, 27, 3),
                    (28, NULL, '2023-02-08', 37, 27, 14, 47, 5),
                    (29, '2023-07-12', NULL, 14, 4, 3, 24, 5),
                    (30, NULL, '2023-02-03', 39, 29, 15, 49, 4);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();            
            string result = "";
            var orderPallet = pallets.OrderByDescending(p => p.BeforeDate).Take(3).OrderBy(p => p.Volume);
            foreach (var pallet in orderPallet)
            {
                result += pallet.Id.ToString();
            }
            Assert.AreEqual("513", result);
        }
        [Test]
        [Description("Проверяет, что коробки не могут быть больше паллет.")]
        public void Test_Error()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, NULL, '2023-02-15', 250, 150, 8, 35, 1),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 1);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            Exception exception = Assert.Throws<Exception>(() => {
                List<Pallet> pallets = dataAccess.GetAllPallets();
                throw new Exception("Каждая коробка не должна превышать по размерам паллету!");
            });
            Assert.AreEqual("Каждая коробка не должна превышать по размерам паллету!", exception.Message);
        }
        [Test]
        [Description("Проверяет, что срок годности паллеты вычисляется верно.")]
        public void Test_Date()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, '2023-06-03', NULL, 25, 15, 8, 35, 1),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 1);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            Assert.AreEqual("2023-06-01", pallets[0].BeforeDate.Value.ToString("yyyy-MM-dd"));
        }
        [Test]
        [Description("Проверяет, что объем паллеты вычисляется верно.")]
        public void Test_Volume_Pallet()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, '2023-06-03', NULL, 25, 15, 8, 35, 1),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 1);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            Assert.AreEqual(1036500, pallets[0].Volume);
        }
        [Test]
        [Description("Проверяет, что объем коробки вычисляется верно.")]
        public void Test_Volume_Box()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            Assert.AreEqual(24000, pallets[0].Boxes[0].Volume);
        }
        [Test]
        [Description("Проверяет, что вес паллеты вычисляется верно.")]
        public void Test_Weight()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string palletsQuery = @"
                DELETE FROM Boxes;
                DELETE FROM Pallets;
                INSERT INTO Pallets (Id, Width, Height, Depth)
                VALUES
                    (1, 100, 120, 80);
            ";

                SqlCommand palletsCommand = new SqlCommand(palletsQuery, connection);
                palletsCommand.ExecuteNonQuery();
                string boxesQuery = @"                
                INSERT INTO Boxes (Id, Before_date, Date_creation, Height, Depth, Weight, Width, Id_pallet)
                VALUES
                    (1, '2023-06-01', NULL, 30, 20, 10, 40, 1),
                    (2, '2023-06-03', NULL, 25, 15, 8, 35, 1),
                    (3, '2023-06-10', NULL, 35, 25, 12, 45, 1);
            ";

                SqlCommand boxesCommand = new SqlCommand(boxesQuery, connection);
                boxesCommand.ExecuteNonQuery();
            }
            DataAccess dataAccess = new DataAccess(connectionString);
            List<Pallet> pallets = dataAccess.GetAllPallets();
            Assert.AreEqual(60, pallets[0].Weight);
        }
    }
}
