namespace LogiTrack.Models;

public class InventoryItem
{
    public int ItemId {get;set;}
    public string Nombre {get;set;}
    public int Cantidad {get;set;}
    public string Ubicacion {get;set;}

    public void DisplayInfo()
    {
        Console.WriteLine($"Artículo: {Nombre} | Cantidad: {Cantidad} | Ubicación: {Ubicacion}");
    }
}
