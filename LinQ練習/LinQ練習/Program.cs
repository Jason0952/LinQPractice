using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LinQ練習
{
    class Program
    {
        static void Main( string[] args )
        {
            //Normal
            //int[] Number1 = new int[] { 0, 9, 5, 7, 4, 3, 1, 6, 2 };
            List<ConvertMoney> result = new List<ConvertMoney>();

            List<ConvertMoney> Dic1 = new List<ConvertMoney>();
            Dic1.Add(new ConvertMoney()
            {
                Date = new DateTime(2021, 7, 1),
                Currency = 27.5m,
                Price = 150.7
            });
            Dic1.Add(new ConvertMoney()
            {
                Date = new DateTime(2021, 7, 2),
                Currency = 27.5m,
                Price = 140.7
            });

            List<ConvertMoney> Dic2 = new List<ConvertMoney>();
            Dic2.Add(new ConvertMoney()
            {
                Date = new DateTime(2021, 6, 29),
                Currency = 27m,
                Price = 150.7
            });
            Dic2.Add(new ConvertMoney()
            {
                Date = new DateTime(2021, 7, 1),
                Currency = 27m,
                Price = 140.7
            });

            foreach (var item in Dic1.Union(Dic2).OrderBy(x => x.Date))
            {
                result.Add(new ConvertMoney()
                {
                    Date = item.Date,
                    Currency = Dic1.Union(Dic2).Where(x => x.Currency == item.Currency).OrderBy(x => x.Date).Select(x => x.Currency).Sum(),
                    Price = Dic1.Union(Dic2).Where(x => x.Price == item.Price).OrderBy(x => x.Date).Select(x => x.Price).Sum()
                });
            }

            foreach (var item in result)
            {
                Console.Write("Date : " + item.Date + "\n");
                Console.Write("Currency : " + item.Currency + "\n");
                Console.Write("Price : " + item.Price + "\n");
            }
            Console.ReadLine();
        }
    }
}
