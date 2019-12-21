using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    interface ITicketAlgorithm
    {
        bool IsLucky(Ticket ticket);
    }
}
