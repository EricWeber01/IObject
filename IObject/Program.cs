using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository shop = new Repository();
            shop.Add("имя_товара1", 200, 2);
            shop.Add("имя_товара2", 300, 2);
            shop.Add("имя_товара3", 100, 2);
            shop.Add("имя_товара4", 50, 2);
            shop.Add("имя_товара5", 150, 2);
            shop.Add("имя_товара6", 10, 2);
            Repository shop2 = (Repository)shop.Clone();
            shop.Sort(new PriceComparer());
            foreach (Good item in shop2)
            {
                Console.WriteLine(item);
            }
            Good g = new Good("Главный", 2, 3);
            Good g2 = (Good)g.Clone();
            g2.Name = "Клон";
            Console.WriteLine(g);
            Console.WriteLine(g2);
        }
    }
}
