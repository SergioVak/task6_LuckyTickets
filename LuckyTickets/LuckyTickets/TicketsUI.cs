using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTickets
{
    class TicketsUI
    {
        public string GetUserPath()
        {
            bool isExist = false;
            string input = string.Empty;

            while (!isExist)
            {
                Console.WriteLine("Input path");

                input = Console.ReadLine();

                isExist = File.Exists(input);

                if (isExist)
                {
                    break;
                }

                //Log.Logger.Debug($"User input incorrect path: {input}");
                Console.WriteLine("File not exist");
            }

            return input;
        }

        public bool RunAgain()
        {
            bool reAsk = false;
            bool result = false;

            do
            {
                string input = string.Empty;

                Console.WriteLine(TextMessages.RUN_AGAIN);
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case TextMessages.YES:
                    case TextMessages.Y:
                        result = true;
                        reAsk = false;

                        break;

                    case TextMessages.NO:
                    case TextMessages.N:
                        result = false;
                        reAsk = false;

                        break;

                    default:
                        //Log.Logger.Information($"UI default. RunAgain {input}");
                        Console.WriteLine(TextMessages.WRONG_INPUT);
                        Console.WriteLine();

                        reAsk = true;

                        break;
                }
            }
            while (reAsk);

            return result;
        }

        public void ShowResult(string result)
        {
            Console.WriteLine("Count of Lucky tickets = " + result);
        }


    }
}
