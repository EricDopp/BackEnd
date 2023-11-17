using System.ComponentModel.DataAnnotations;

namespace RestaurantFaves.Models;

public class Order
{
    public int id { get; set; }
    public string description { get; set; }
    public string restaurant { get ; set; }
    [Range (1, 5)]
    public int rating { get; set; }
    public bool orderAgain { get; set; }
}
