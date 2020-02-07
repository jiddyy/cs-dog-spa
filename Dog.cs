namespace Gagoya
{
    class Dog
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Dog(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}