using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketsApp _app = new TicketsApp();

            //Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
            //   .WriteTo.File("log.txt").CreateLogger();

            try
            {
                _app.Start();
            }
            catch (Exception ex)
            {
               // Log.Logger.Error($"{ex.Message} Main");
            }
        }
    }
}
