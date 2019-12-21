using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class PiterAlgorithm : ITicketAlgorithm
    {
        public bool IsLucky(Ticket currentTicket)
        {
            if(currentTicket == null)
            {
                throw new ArgumentNullException("textmessage.error");
            }

            int oddSum = 0;
            int evenSum = 0;

            for (int i = 0; i < currentTicket.Size; i++)
            {
                if (i % 2 == 0)
                {
                    oddSum += currentTicket[i];
                }
                else
                {
                    evenSum += currentTicket[i];
                }
            }

            return oddSum == evenSum;
        }

    }
}
