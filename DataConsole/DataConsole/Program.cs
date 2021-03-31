using System;
using System.Collections.Generic;
using System.IO;

namespace DataConsole
{
    class Program
    {
        public static int count = 0;
        public static string[,] gunData;
        static void Main(string[] args)
        {
            List<string> months = new List<string>();
            List<string> states = new List<string>();
            List<string> totals = new List<string>();
            
            using (var reader = new StreamReader(@"nics-firearm-background-checks.csv"))
            {
              
                Console.WriteLine("Reading data......");
                while (!reader.EndOfStream)
                {
                    count++;
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    months.Add(values[0]);
                    states.Add(values[1]);
                    totals.Add(values[2]);

                }
                Console.WriteLine("Data read into lists");
                gunData = new string[count, count];

                for (int i = 0; i < count; i++)
                {
                    gunData[i,0] = months[i] + states[i];
                    gunData[0,i] = totals[i];
                 

                }


                bool endProgram = false;
                while (!endProgram)
                {
                    // show menu
                    Console.WriteLine("Welcome to the Gun Purchase Analysis Program!");
                    Console.WriteLine("Enter a choice:");
                    Console.WriteLine("1. Search by state");
                    Console.WriteLine("2. Search by year");
                    Console.WriteLine("3. Search by total");
                    Console.WriteLine("4. Exit");
                    // respond to choice
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            SearchByState();
                            break;
                        case "2":
                            Console.WriteLine("Case 2");
                            //SearchByYear
                            break;
                        case "3":
                            Console.WriteLine("Case 3");
                            //SearchByTotal
                            break;
                        case "4":
                            endProgram = true;
                            Console.WriteLine("Thank you for using this program, goodbye!");
                            break;
                        default:
                            Console.WriteLine("Incorrect option, choose again");
                            break;
                    }
                }

               
            }
          
        }
        public static void SearchByState()
        {
            Console.WriteLine("Enter the name of a state:");
            string stateSelected = Console.ReadLine();



            for (int i = 0; i < count; i++)
            {
                string stateMonth = gunData[i, 0];
                if (stateMonth.Contains(stateSelected))
                {
                    Console.WriteLine(gunData[i, 0]);
                    Console.WriteLine(gunData[0, i]);
                }
            }
        }
    }
}
