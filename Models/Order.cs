using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Models;

public class Order
{
    [Key]
    public int OrderId {get;set;}

    [Required]
    public string CustomerName {get;set;}
    public DateTime DatePlaced {get;set;}
    public List<InventoryItem> Items {get;set;}

    public void AddItem(InventoryItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(int itemId)
    {
        var item = Items.FirstOrDefault(i => i.ItemId == itemId);

        if (item != null)
            Items.Remove(item);
    }

    public string GetOrderSummary()
    {
         return $"Pedido #{OrderId} para {CustomerName} | Artículos: {Items.Count} | Realizado: {DatePlaced:d}";
    }
}