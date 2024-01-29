using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdministracijaStudenta
{
    class Administracija
    {

        static List<Student> studenti = new List<Student>();
        static List<Predmet> predmeti = new List<Predmet>();
        static List<Ocena> ocene = new List<Ocena>();

        public static void Run()
        {
            while (true)
            {

                Console.WriteLine("Izaberite opciju:");
                Console.WriteLine("1. Unos studenta");
                Console.WriteLine("2. Brisanje studenta");
                Console.WriteLine("3. Azuriranje studenta");
                Console.WriteLine("4. Unos predmeta");
                Console.WriteLine("5. Brisanje predmeta");
                Console.WriteLine("6. Azuriranje predmeta");
                Console.WriteLine("7. Dodavanje ocene studentu");
                Console.WriteLine("8. Azuriranje ocene studenta");
                Console.WriteLine("9. Prikaz svih ocena studenta");
                Console.WriteLine("10. Pretraga studenata");
                Console.WriteLine("0. Izlaz");

                string opcija = Console.ReadLine();

                try
                {
                    switch (opcija)
                    {
                        case "1":
                            UnesiStudenta();
                            break;
                        case "2":
                            ObrisiStudenta();
                            break;
                        case "3":
                            AzurirajStudenta();
                            break;
                        case "4":
                            UnesiPredmet();
                            break;
                        case "5":
                            ObrisiPredmet();
                            break;
                        case "6":
                            AzurirajPredmet();
                            break;
                        case "7":
                            DodajOcenu();
                            break;
                        case "8":
                            AzurirajOcenu();
                            break;
                        case "9":
                            PrikaziOceneStudenta();
                            break;
                        case "10":
                            PretraziStudente();
                            break;
                        case "0":
                            DateTime currentTime = DateTime.Now;
                            Console.WriteLine("Vreme izlazska iz aplikacije: " + currentTime);
                            string hostName = Dns.GetHostName();
                            Console.WriteLine(hostName);
                            // Get the IP from GetHostByName method of dns class.
                            string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
                            Console.WriteLine("IP Address is : " + IP);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Nepoznata opcija.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number to finish.");
                }


            }
        }

        static void UnesiStudenta()
        {
            
            try
            {
                Console.WriteLine("Unesite ID studenta:");
                int id = int.Parse(Console.ReadLine());

                if (StudentPostoji(studenti, id))
                {
                    Console.WriteLine("ID vec postoji. Molim Vas pokusajte drugi.");
                }
                else
                {
                    Console.WriteLine("Unesite ime studenta:");
                    string ime = Console.ReadLine();

                    Console.WriteLine("Unesite prezime studenta:");
                    string prezime = Console.ReadLine();

                    Console.WriteLine("Unesite broj indeksa:");
                    string brojIndeksa = Console.ReadLine();

                    Console.WriteLine("Unesite datum upisa (yyyy-MM-dd):");
                    DateTime datumUpisa = DateTime.Parse(Console.ReadLine());

                    studenti.Add(new Student
                    {
                        ID = id,
                        Ime = ime,
                        Prezime = prezime,
                        BrojIndeksa = brojIndeksa,
                        DatumUpisa = datumUpisa
                    });
                    DateTime currentTime = DateTime.Now;
                    Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
                    Console.WriteLine("Student uspešno unet.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number to finish.");
            }

        }

        static bool StudentPostoji(List<Student> studenti, int id)
        {
            foreach (var student in studenti)
            {
                if (student.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        static void ObrisiStudenta()
        {

            Console.WriteLine("Studenti:");

            for (int i = 0; i < studenti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Ime: {studenti[i].Ime}, Prezime: {studenti[i].Prezime}, ID: {studenti[i].ID}, Datum Upisa: {studenti[i].DatumUpisa.ToString("yyyy-MM-dd")}");
            }

            Console.WriteLine("Unesite ID studenta za brisanje:");
            int id = int.Parse(Console.ReadLine());

            Student student = studenti.FirstOrDefault(s => s.ID == id);

            if (student != null)
            {
                studenti.Remove(student);
                ocene.RemoveAll(o => o.IDStudenta == id);
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
                Console.WriteLine("Student uspešno obrisan.");
            }
            else
            {
                Console.WriteLine("Student nije pronađen.");
            }
        }

        static void AzurirajStudenta()
        {
            Console.WriteLine("Studenti:");

            for (int i = 0; i < studenti.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Ime: {studenti[i].Ime}, Prezime: {studenti[i].Prezime}, ID: {studenti[i].ID}, Datum Upisa: {studenti[i].DatumUpisa.ToString("yyyy-MM-dd")}");
            }

            Console.WriteLine("Unesite ID studenta za ažuriranje:");
            int id = int.Parse(Console.ReadLine());

            Student student = studenti.FirstOrDefault(s => s.ID == id);

            if (student != null)
            {
                Console.WriteLine("Unesite novo ime studenta:");
                student.Ime = Console.ReadLine();

                Console.WriteLine("Unesite novo prezime studenta:");
                student.Prezime = Console.ReadLine();

                Console.WriteLine("Unesite novi broj indeksa:");
                student.BrojIndeksa = Console.ReadLine();

                Console.WriteLine("Unesite novi datum upisa (yyyy-MM-dd):");
                student.DatumUpisa = DateTime.Parse(Console.ReadLine());

                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);

                Console.WriteLine("Student uspešno ažuriran.");
            }
            else
            {
                Console.WriteLine("Student nije pronađen.");
            }
        }

        static void UnesiPredmet()
        {
            Console.WriteLine("Unesite ID predmeta:");
            int id = int.Parse(Console.ReadLine());

            if (PredmetPostoji(predmeti, id))
            {
                Console.WriteLine("ID vec postoji. Molim Vas pokusajte drugi.");
            }
            else
            {
                Console.WriteLine("Unesite naziv predmeta:");
                string naziv = Console.ReadLine();

                Console.WriteLine("Unesite ESPB predmeta:");
                int espb = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite ime predavača:");
                string predavac = Console.ReadLine();

                predmeti.Add(new Predmet
                {
                    ID = id,
                    Naziv = naziv,
                    ESPB = espb,
                    Predavac = predavac
                });
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
                Console.WriteLine("Predmet uspešno unet.");
            }
        }

        static bool PredmetPostoji(List<Predmet> predmeti, int id)
        {
            foreach (var predment in predmeti)
            {
                if (predment.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        static void ObrisiPredmet()
        {
            Console.WriteLine("Unesite ID predmeta za brisanje:");
            int id = int.Parse(Console.ReadLine());

            Predmet predmet = predmeti.FirstOrDefault(p => p.ID == id);

            if (predmet != null)
            {
                predmeti.Remove(predmet);
                ocene.RemoveAll(o => o.IDPredmeta == id);
                Console.WriteLine("Predmet uspešno obrisan.");
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
            }
            else
            {
                Console.WriteLine("Predmet nije pronađen.");
            }
        }

        static void AzurirajPredmet()
        {
            Console.WriteLine("Unesite ID predmeta za ažuriranje:");
            int id = int.Parse(Console.ReadLine());

            Predmet predmet = predmeti.FirstOrDefault(p => p.ID == id);

            if (predmet != null)
            {
                Console.WriteLine("Unesite novi naziv predmeta:");
                predmet.Naziv = Console.ReadLine();

                Console.WriteLine("Unesite novi ESPB predmeta:");
                predmet.ESPB = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite ime novog predavača:");
                predmet.Predavac = Console.ReadLine();

                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
                Console.WriteLine("Predmet uspešno ažuriran.");
            }
            else
            {
                Console.WriteLine("Predmet nije pronađen.");
            }
        }

        static void DodajOcenu()
        {
            Console.WriteLine("Unesite ID studenta:");
            int idStudenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite ID predmeta:");
            int idPredmeta = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite ocenu:");
            int ocena = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite datum polaganja (yyyy-MM-dd):");
            DateTime datumPolaganja = DateTime.Parse(Console.ReadLine());

            ocene.Add(new Ocena
            {
                IDStudenta = idStudenta,
                IDPredmeta = idPredmeta,
                DatumPolaganja = datumPolaganja,
                Ocena1 = ocena
            });
            DateTime currentTime = DateTime.Now;
            Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
            Console.WriteLine("Ocena uspešno dodata.");
        }

        static void AzurirajOcenu()
        {
            Console.WriteLine("Unesite ID studenta:");
            int idStudenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Unesite ID predmeta:");
            int idPredmeta = int.Parse(Console.ReadLine());

            Ocena ocena = ocene.FirstOrDefault(o => o.IDStudenta == idStudenta && o.IDPredmeta == idPredmeta);

            if (ocena != null)
            {
                Console.WriteLine("Unesite novu ocenu:");
                ocena.Ocena1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Unesite novi datum polaganja (yyyy-MM-dd):");
                ocena.DatumPolaganja = DateTime.Parse(Console.ReadLine());
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
                Console.WriteLine("Ocena uspešno ažurirana.");
            }
            else
            {
                Console.WriteLine("Ocena nije pronađena.");
            }
        }

        static void PrikaziOceneStudenta()
        {
            Console.WriteLine("Unesite ID studenta:");
            int idStudenta = int.Parse(Console.ReadLine());

            List<Ocena> oceneStudenta = ocene.Where(o => o.IDStudenta == idStudenta).ToList();

            if (oceneStudenta.Any())
            {
                Console.WriteLine($"Ocene za studenta ID {idStudenta}:");

                foreach (var ocena in oceneStudenta)
                {
                    Console.WriteLine($"Predmet ID: {ocena.IDPredmeta}, Ocena: {ocena.Ocena1}, Datum polaganja: {ocena.DatumPolaganja}");
                }
            }
            else
            {
                Console.WriteLine("Nema ocena za ovog studenta.");
            }
        }

        static void PretraziStudente()
        {
            Console.WriteLine("Unesite kriterijum za pretragu (ime, prezime, indeks, predmet):");
            string kriterijum = Console.ReadLine().ToLower();

            Console.WriteLine("Unesite vrednost za pretragu:");
            string vrednost = Console.ReadLine().ToLower();

            List<Student> rezultati = new List<Student>();

            switch (kriterijum)
            {
                case "ime":
                    rezultati = studenti.Where(s => s.Ime.ToLower().Contains(vrednost)).ToList();
                    break;
                case "prezime":
                    rezultati = studenti.Where(s => s.Prezime.ToLower().Contains(vrednost)).ToList();
                    break;
                case "indeks":
                    rezultati = studenti.Where(s => s.BrojIndeksa.ToLower().Contains(vrednost)).ToList();
                    break;
                case "predmet":
                    int idPredmeta = int.Parse(vrednost);
                    rezultati = ocene.Where(o => o.IDPredmeta == idPredmeta).Select(o => studenti.FirstOrDefault(s => s.ID == o.IDStudenta)).Distinct().ToList();
                    break;
                default:
                    Console.WriteLine("Nepoznat kriterijum za pretragu.");
                    return;
            }

            if (rezultati.Any())
            {
                Console.WriteLine("Rezultati pretrage:");

                foreach (var student in rezultati)
                {
                    Console.WriteLine($"ID: {student.ID}, Ime: {student.Ime}, Prezime: {student.Prezime}, Broj indeksa: {student.BrojIndeksa}, Datum upisa: {student.DatumUpisa}");
                }
                DateTime currentTime = DateTime.Now;
                Console.WriteLine("Vreme izmene aplikacije: " + currentTime);
            }
            else
            {
                Console.WriteLine("Nema rezultata za datu pretragu.");
            }
        }

    }
}
