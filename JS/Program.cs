namespace JS
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = GetOrder(10);
            SaveText(order1);
            var deOrder = DeserelezadeText();
            Console.WriteLine(deOrder.customer.Name);
            Console.WriteLine(deOrder.product.Name);
            Console.WriteLine(deOrder.FullPrice);

        }
        private static Order GetOrder(int number)
        {
            var order = new Order();
            order.customer = new Customer("Петя", Sexs.Male, 7);
            order.Number = number;
            order.product = new Product("Алёнка", Categorys.Chocolate, 42.5f);
            return order;
        }
        private static void SaveText(Order order)
        {
            string path = Environment.CurrentDirectory + "\\JS.json";
            File.Create(path).Dispose();
            string text = JsonConvert.SerializeObject(order);
            File.WriteAllText(path, text);
        }
        private static Order DeserelezadeText()
        {
            string path = Environment.CurrentDirectory + "\\JS.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var orderExit = JsonConvert.DeserializeObject<Order>(json);
                return orderExit;
            }
            else
            {
                return new Order();
            }
        }
    }
}
// Данные получают из файла: товар (название, категория, цена за единицу,),кол-во товара, покупатель (имя, пол, размер члена)
//составить таблицу в которой будет: покупатель, товар, кол-во штук, общая сумма (от большего к меньшему)