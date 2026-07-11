namespace LogiTrack.Models;

public class Order
{
    public int OrderId {get;set;}
    public string CustomerName {get;set;}
    public DateTime DatePlaced {get;set;}
    public List<InventoryItem> Items {get;set;}

    public void AddItem(InventoryItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        Items.Remove(item);
    }

    public void GetOrderSummary()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine($"Customer Name: {CustomerName}");
        Console.WriteLine($"Date Placed: {DatePlaced}");
        Console.WriteLine("Items in Order:");
        foreach (var item in Items)
        {
            Console.WriteLine($"- {item.Nombre} (Quantity: {item.Cantidad})");
        }
    }
}