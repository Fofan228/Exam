using Newtonsoft.Json;

namespace JS
{
    enum Categorys
    {
        Chocolate, Soda, Marmalade, Bread, Milk
    }
    enum Sexs
    {
        Male, Female, Helicopter
    }
    struct Customer
    {
        public Customer(string name, Sexs sex, int cockLenght)
        {
            Name = name;
            Sex = sex;
            CockLenght = cockLenght;
        }
        public string Name { get; }
        public Sexs Sex { get; }
        public int CockLenght { get; }
    }
    class Product
    {
        public Product(string name, Categorys category, float price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
        [JsonProperty]
        private int balls = 5;
        public string Name { get; }
        public Categorys Category { get; }
        private float price;
        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value > 0)
                    price = value;
            }
        }
    }
    class Order
    {
        public Customer customer;
        public Product product;
        public int Number;
        public float FullPrice => Number * product.Price;
    }
}
