using System;
using System.Collections.Generic;
using System.Net;

namespace Biblioteka
{
    class Program
    {
        static int lastBookId = 0;
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Choose - Book(1) or Strip(2): ");
                try
                {
                    int choice1 = int.Parse(Console.ReadLine());

                    switch (choice1)
                    {
                        case 1:
                            Katalog katalog = new Katalog();
                            katalog.KnjigaM();

                            string hostName = Dns.GetHostName();
                            Console.WriteLine(hostName);
                            // Get the IP from GetHostByName method of dns class.
                            string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                            Console.WriteLine("IP Address is : " + IP);
                            break;
                        case 2:
                            Katalog katalog1 = new Katalog();
                            katalog1.StripM();

                            string hostName1 = Dns.GetHostName();
                            Console.WriteLine(hostName1);
                            // Get the IP from GetHostByName method of dns class.
                            string IP1 = Dns.GetHostByName(hostName1).AddressList[0].ToString();
                            Console.WriteLine("IP Address is : " + IP1);
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number to finish.");
                }


            }
            Console.ReadLine();
        }

    }
}
