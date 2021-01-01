using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module15
{
    class Program
    {    
        class Delivery
        {
            public string Address;         
        }

        class Courier<T3>
        {
            public T3 IdCourier;                                             
        }
            
        class HomeDelivery<T1, T2> : Delivery
        {           
            public string Name;
            public int Price;
            
            public HomeDelivery(string name, int price)
            {
                Name = name;
                Price = price;
            }                                       
        }

        class PickPointDelivery : Delivery
        {
            public string Company;
            public PickPointDelivery(string company)
            {
                Company = company;
            }                    
        }

        class ShopDelivery : Delivery
        {        
            //public  int DeliveryCount;
            public virtual int Counthange
            {
                get;
                set;
            }      
        }
        class Counter: ShopDelivery
        {
            public int counter;
            private static int MinValue = 0;
            public override int Counthange
            {
                get
                {
                    if (counter > MinValue)
                    {
                        return ++counter;
                    }
                    else return default;
                }
                set
                {
                    
                }
            }
        }
   
        public class Order
        {
            private Delivery delivery;

            public Order()
            {
                delivery = new Delivery();
            }
            public void OrderCheck()
            {
                Console.WriteLine("Введите адрес");
                delivery.Address = Console.ReadLine();
                Console.WriteLine("Доставили ли заказ в пункт назначения?");
                string answer = Console.ReadLine();
                if (answer == "да")
                {
                    Console.WriteLine($"Заказ доставлен по адресу {delivery.Address}");
                }
                else Console.WriteLine("Заказ еще в пути");
            }
        }
        
        static void Main(string[] args)
        {
            //Доставка на дом         
            Courier<string> courier = new Courier<string>();

            Console.WriteLine("Айди курьера");
            courier.IdCourier = Console.ReadLine();
            
            HomeDelivery<string, int> homeDelivery = new HomeDelivery<string, int>("qwe", 2500);
           
            Console.WriteLine("Адрес доставки");
            homeDelivery.Address = Console.ReadLine();
            
            Console.WriteLine("Данные о заказе на дом:");           
            Console.WriteLine($"{courier.IdCourier} доставил заказ по адресу {homeDelivery.Address} клиенту с именем {homeDelivery.Name} заказ на сумму {homeDelivery.Price}");

            //Доставка в пункт выдачи
            PickPointDelivery pickPointDelivery = new PickPointDelivery("company");
           
            Console.WriteLine($"Введите адрес пункта выдачи");       
            pickPointDelivery.Address = Console.ReadLine();
            
            Console.WriteLine($"Введите компанию, находящуюся по адресу {pickPointDelivery.Address}");
            pickPointDelivery.Company = Console.ReadLine();
           
            Console.WriteLine($"{pickPointDelivery.Address}: {pickPointDelivery.Company}");

            //В розницу
            Counter shop = new Counter();
            Console.WriteLine("Адрес");
            shop.Address = Console.ReadLine();
            
            Console.WriteLine("Введите текущее кол-во заказов");
            shop.counter = int.Parse(Console.ReadLine());
            string answ;
            do
            {
                Console.WriteLine($"Теперь заказов {shop.Counthange}, увеличить еще?");
                answ = Console.ReadLine();
                shop.counter = shop.Counthange - 1;
            } while (answ == "да");


            Order order = new Order();
            Console.WriteLine();
            order.OrderCheck();

            Console.ReadKey();
        }
    }
}
