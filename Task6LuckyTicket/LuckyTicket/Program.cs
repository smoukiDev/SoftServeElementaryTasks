using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            SixDigitTicketGenerator generator = SixDigitTicketGenerator.Create(000005, 000100);
            foreach (var item in generator)
            {
                Console.WriteLine(item.TicketNumber);
            }

            Console.ReadLine();
        }
    }
}
