using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTickets
{
    class TicketsApp
    {
        private const int MIN_VALUE_FOR_TICKET = 1;
        private const int MAX_VALUE_FOR_TICKET = 999999;

        private readonly TicketsUI _userInterface;
        private ITicketAlgorithm _ticketAlgorithm;

        public TicketsApp()
        {
            _userInterface = new TicketsUI();
        }

        public void Start()
        {
            do
            {
                try
                {
                    string path = _userInterface.GetUserPath();

                    Algorithm algorithmType  = GetAlgorithmType(path);

                    int result = 0;

                    switch (algorithmType)
                    {
                        case Algorithm.Moskow:

                            _ticketAlgorithm = new MoskowAlgorithm();
                            result = CountLucky(_ticketAlgorithm, MIN_VALUE_FOR_TICKET, MAX_VALUE_FOR_TICKET);
                            break;

                        case Algorithm.Piter:

                            _ticketAlgorithm = new PiterAlgorithm();
                            result = CountLucky(_ticketAlgorithm, MIN_VALUE_FOR_TICKET, MAX_VALUE_FOR_TICKET);
                            break;

                        default:

                            //Log.Logger.Error($"LuckyTiketApp.Run({runMode}) default:");

                            throw new ArgumentException("Can't switch mode");
                    }

                    _userInterface.ShowResult(result.ToString());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                    //Log.Logger.Error($"{ex.Message} EnvelopeApp.Start");
                }
            }
            while (_userInterface.RunAgain());
        }

        private Algorithm GetAlgorithmType(string path)
        {
            Algorithm algorithm;

            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();

            switch (line.ToLower())
            {
                case TextMessages.MOSKOW:

                    algorithm = Algorithm.Moskow;
                    break;

                case TextMessages.PITER:

                    algorithm = Algorithm.Piter;
                    break;

                default:

                    //Log.Logger.Debug($"GetMode() default: cant read mode in {line}");

                    throw new ArgumentException(TextMessages.WRONG_ALGORITHM_NAME);

            }

            return algorithm;
        }

        private int CountLucky(ITicketAlgorithm ticketAlgorithm, int minValue, int maxValue)
        {
            int result = 0;

            for (int index = minValue; index <= maxValue; index++)
            {
                if (ticketAlgorithm.IsLucky(new Ticket(index)))
                {
                    result++;
                }
            }

            return result;
        }





    }
}
