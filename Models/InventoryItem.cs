using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Models;

public class InventoryItem
{
    [Key]
    public int ItemId {get;set;}
    [Required]
    public string Nombre {get;set;}
    public int Cantidad {get;set;}
    [Required]
    public string Ubicacion {get;set;}
    public int OrderId { get; set; }

    public Order Order { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Artículo: {Nombre} | Cantidad: {Cantidad} | Ubicación: {Ubicacion}");
    }
}
