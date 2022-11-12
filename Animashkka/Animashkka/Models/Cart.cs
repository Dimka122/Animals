namespace Animashkka.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
