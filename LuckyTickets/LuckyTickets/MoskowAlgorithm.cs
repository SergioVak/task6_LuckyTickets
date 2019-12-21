using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class MoskowAlgorithm : ITicketAlgorithm
    {
        public bool IsLucky(Ticket currentTicket)
        {
            if (currentTicket == null)
            {
                throw new ArgumentNullException("textmessage.error");
            }

            int leftPart = 0;
            int rightPart = 0;

            for (int i = 0; i < currentTicket.Size / 2; ++i)
            {
                rightPart += currentTicket[i];
            }

            for (int i = (currentTicket.Size / 2) + (currentTicket.Size % 2); i < currentTicket.Size; ++i)
            {
                leftPart += currentTicket[i];
            }

            return leftPart == rightPart;
        }
    }
}
