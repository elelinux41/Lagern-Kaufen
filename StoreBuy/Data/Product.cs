namespace StoreBuy.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Costumer> Costumers { get; } = new();
        public string getPrice()
        {
            return this.Price + "€";
        }
    }
}
