using System;
using System.Collections.Generic;
using System.Net;

namespace AdministracijaStudenta
{
    class Program
    {

        static List<Student> studenti = new List<Student>();
        static List<Predmet> predmeti = new List<Predmet>();
        static List<Ocena> ocjene = new List<Ocena>();
        static void Main(string[] args)
        {
            try
            {
                Administracija.Run();
                string hostName = Dns.GetHostName();
                Console.WriteLine(hostName);

                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Current time: " + currentTime);
                // Get the IP from GetHostByName method of dns class.
                string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                Console.WriteLine("IP Address is : " + IP);
                
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number to finish.");
            }
            
        }
    }
}
