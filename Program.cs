using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartotekaLINQ;
using System.Globalization;

namespace KartotekaLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            bool isOver = false;
            DateTime now = DateTime.Now;

            while (!isOver)
            {
                Console.WriteLine("1 - Add person");
                Console.WriteLine("2 - Delete person");
                Console.WriteLine("3 - Show persons");
                Console.WriteLine("4 - Count of women");
                Console.WriteLine("5 - Who is the oldest?");
                Console.WriteLine("0 - The End");

                int choosenNumber = Convert.ToInt32(Console.ReadLine());

                switch (choosenNumber)
                {
                    case 0:
                        isOver = true;
                        break;
                    case 1:
                        Person johnDoe = new Person();
                        Console.Write("Input the name: ");
                        johnDoe.Name = Console.ReadLine();
                        Console.Write("Input the surname: ");
                        johnDoe.Surname = Console.ReadLine();
                        Console.Write("Input the bitrh date: ");
                        string birthDate = Console.ReadLine();
                                              
                        if(!DateTime.TryParse(birthDate, out johnDoe.BirthDate))
                        {
                            Console.WriteLine("Wronly set the date time");
                        }
                        
                        persons.Add(johnDoe);
                        break;
                    case 2:
                        Console.WriteLine("Write index item for clear: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        persons.RemoveAt(index);
                        break;
                    case 3:
                        int i = 0;
                        foreach (Person onePerson in persons)
                        {
                            Console.WriteLine($"{i}\t{onePerson.Name}\t\t{onePerson.Surname}\t\t{onePerson.BirthDate}");
                            i++;
                        }
                        break;

                    //Pocet zen diky pripone ova /2 zpusoby
                    case 4:
                        var query = from p in persons where (p.Surname.EndsWith("ova")) select p.Name;
                        Console.WriteLine($"Pocet zen: {query.Count()}.");

                        Console.WriteLine($"Women count: {persons.Count(per => per.Surname.EndsWith("ova"))}.");
                        break;
                    //Vyhodnoceni, kdo je nejstarsi a vypis
                    case 5:
                        
                        Console.WriteLine($"The oldest person is {persons.Min(p => p.BirthDate)}");
                        break;
                }



            }



            //Console.ReadLine();


        }
    }
}
