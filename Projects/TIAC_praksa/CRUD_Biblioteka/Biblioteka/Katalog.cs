using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class Katalog
    {
        static int lastBookId = 0;
        static int lastStripId = 0;
        static List<Knjiga> bookList = new List<Knjiga>();
        static List<Strip> stripList = new List<Strip>();
        //static List<Knjiga> users = new List<Knjiga>();

        public string LogIn()
        {
            Console.WriteLine("Unesite vase ime i prezime: ");
            string imeIPrezime = Console.ReadLine();
            return imeIPrezime;
        }

        public void KnjigaM()
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Modify Book");
            Console.WriteLine("4. Display Books");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddBook(bookList);
                    break;
                case 2:
                    //Katalog katalog = new Katalog();
                    //katalog.RemoveBook(bookList);
                    RemoveBook(bookList);
                    break;
                case 3:
                    //Katalog katalog = new Katalog();
                    ModifyBooks(bookList);
                    break;
                case 4:
                    //Katalog katalog = new Katalog();
                    DisplayBooks(bookList);
                    break;
                case 5:
                    //keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        public void AddBook(List<Knjiga> bookList)
        {
            //int lastBookId = 1;
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            //Random r = new Random(1, 101);

            Knjiga newBook = new Knjiga
            {
                ID = ++lastBookId,
                Naslov = title,
                Autor = author,
                ISBN = isbn
            };
            //lastBookId++;
            bookList.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }
        public void RemoveBook(List<Knjiga> bookList)
        {
            DisplayBooks(bookList);
            Console.Write("Enter ISBN of the book to remove: ");
            int isbnToRemove = int.Parse(Console.ReadLine());

            Knjiga bookToRemove = bookList.Find(book => book.ISBN == isbnToRemove);
            if (bookToRemove != null)
            {
                bookList.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DisplayBooks(List<Knjiga> bookList)
        {
            Console.WriteLine("Knjige:");

            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {bookList[i].Naslov}, ISBN: {bookList[i].ISBN}, ID: {bookList[i].ID}, Author: {bookList[i].Autor:C}");
            }
        }
        public void ModifyBooks(List<Knjiga> bookList)
        {
            DisplayBooks(bookList);
            Console.WriteLine("Choose the ID in front of book which you want to modify: ");
            int idToModify = int.Parse(Console.ReadLine());
            Knjiga bookToModify = bookList.Find(book => book.ID == idToModify);
            if (bookToModify != null)
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Enter ISBN: ");
                int isbn = int.Parse(Console.ReadLine());

                bookToModify.Naslov = title;
                bookToModify.Autor = author;
                bookToModify.ISBN = isbn;
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void StripM()
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add Strip");
            Console.WriteLine("2. Remove Strip");
            Console.WriteLine("3. Modify Strip");
            Console.WriteLine("4. Display Strip");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice5 = int.Parse(Console.ReadLine());

            switch (choice5)
            {
                case 1:
                    AddStrip(stripList);
                    break;
                case 2:
                    //Katalog katalog = new Katalog();
                    //katalog.RemoveBook(bookList);
                    RemoveStrip(stripList);
                    break;
                case 3:
                    //Katalog katalog = new Katalog();
                    ModifyStrips(stripList);
                    break;
                case 4:
                    //Katalog katalog = new Katalog();
                    DisplayStrips(stripList);
                    break;
                case 5:
                    //keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void AddStrip(List<Strip> stripList)
        {
            //int lastBookId = 1;
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            //Random r = new Random(1, 101);

            Strip newStrip = new Strip
            {
                ID = ++lastStripId,
                Naslov = title,
                Autor = author
            };
            //lastBookId++;
            stripList.Add(newStrip);
            Console.WriteLine("Book added successfully!");
        }

        public void RemoveStrip(List<Strip> stripList)
        {
            DisplayStrips(stripList);
            Console.Write("Enter ID of the strip to remove: ");
            int idToRemove = int.Parse(Console.ReadLine());

            Strip stripToRemove = stripList.Find(strip => strip.ID == idToRemove);
            if (stripToRemove != null)
            {
                stripList.Remove(stripToRemove);
                Console.WriteLine("Book removed successfully!");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void DisplayStrips(List<Strip> stripList)
        {
            Console.WriteLine("Stripovi:");

            for (int i = 0; i < stripList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Name: {stripList[i].Naslov}, ID: {stripList[i].ID}, Author: {stripList[i].Autor:C}");
            }
        }

        public void ModifyStrips(List<Strip> stripList)
        {
            DisplayStrips(stripList);
            Console.WriteLine("Choose the ID in front of strip which you want to modify: ");
            int idToModifyS = int.Parse(Console.ReadLine());
            Strip stripToModify = stripList.Find(strip => strip.ID == idToModifyS);
            if (stripToModify != null)
            {
                Console.Write("Enter Title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                stripToModify.Naslov = title;
                stripToModify.Autor = author;
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

    }
}
