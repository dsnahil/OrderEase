public class Analytics
{
    private DatabaseManager dbManager = new DatabaseManager();

    public int GetTotalSales()
    {
        var orders = dbManager.GetOrders();
        int totalSales = 0;
        foreach (var order in orders)
        {
            totalSales += order.Price * order.Quantity;
        }
        return totalSales;
    }

    public string GetMostPopularItem()
    {
        var orders = dbManager.GetOrders();
        var itemCounts = new Dictionary<string, int>();
        foreach (var order in orders)
        {
            if (itemCounts.ContainsKey(order.ItemName))
            {
                itemCounts[order.ItemName]++;
            }
            else
            {
                itemCounts[order.ItemName] = 1;
            }
        }

        var mostPopular = itemCounts.OrderByDescending(x => x.Value).FirstOrDefault();
        return mostPopular.Key;
    }
}
