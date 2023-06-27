using Microsoft.Data.SqlClient;
using StockControl;
DataAccess dataAccess = new DataAccess(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\StockControl\StockControl\Database.mdf;Integrated Security=True");
List<Pallet> pallets = dataAccess.GetAllPallets();
var groupedPallet = pallets.GroupBy(p => p.BeforeDate).OrderBy(p => p.Key);
foreach (var group in groupedPallet)
{
    Console.WriteLine($"Срок годности: {group.Key.Value.ToString("yyyy.MM.dd")}");
    var groupOrder = group.OrderBy(p => p.Weight);
    foreach (var pallet in groupOrder)
    {
        Console.WriteLine($"Id: {pallet.Id}, Вес: {pallet.Weight}");
    }

    Console.WriteLine();
}
Console.WriteLine("-------------------------------------------------------------");
var orderPallet = pallets.OrderByDescending(p => p.BeforeDate).Take(3).OrderBy(p => p.Volume);
foreach(var pallet in orderPallet)
{
    Console.WriteLine($"Id: {pallet.Id}, Срок годности: {pallet.BeforeDate.Value.ToString("yyyy.MM.dd")}, Объем: {pallet.Volume}");
}

