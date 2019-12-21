using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class Ticket
    {
        private const int RANK_DEVIDER = 10;
        private readonly int[] splitedTicketNumber;

        public int Size { get; private set; }

        public Ticket(int number)
        {
            Size = GetSizeNumber(number);

            splitedTicketNumber = TicketNumberDigitParser(number);
        }

        public int this[int index]
        {
            get
            {
                if(index < 0)
                {
                    throw new ArgumentOutOfRangeException("message");
                }

                return splitedTicketNumber[index];
            }
        }

        private int[] TicketNumberDigitParser(int ticketNumber)
        {
            int[] result = new int[Size];

            for (int i = Size - 1; ticketNumber != 0; --i)
            {
                result[i] = ticketNumber % RANK_DEVIDER;
                ticketNumber /= RANK_DEVIDER;
            }

            return result;
        }

        private int GetSizeNumber(int ticketNumber)
        {
            string str = ticketNumber.ToString();

            return str.Length;
        }
    }
}
