using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyBirthday
{
    public class Program
    {
 	// why static?
        // color of regular text
        static void writeText(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }
        // color of wishes
        static void writeWishes(string wishes)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(wishes);
        }
        // color of error
        static void writeError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
        }
        static string getName(string name)
        {
            writeText(name);
            return Console.ReadLine();
        }
        static string getBirthDate(string date)
        {
            writeText(date);
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            string name;
            int numDays;
            int age;
            string date;
            DateTime dateParse;
            DateTime today = DateTime.Today;
            DateTime nearestBirthday;

            Random random = new Random();

            // get user name
            do
            {
                name = getName("Podaj swoje imię: ");
                if (name.Length == 0)
                {
                    writeError("Nie podałeś imienia!");
                }
            }
            while (name.Length == 0);


            // get user date of birth
            do
            {
            Label: date = getBirthDate("Podaj datę swoich urodzin: ");
                if (date.Length != 0)
                {
                    try
                    {
                        dateParse = DateTime.Parse(date);
                        if (dateParse.CompareTo(today) > 0)
                        {
                            writeError("Nie możesz podać daty, która dopiero się wydarzy!\nNo chyba, że jesteś z przyszłośći.");
                        }
                        else if (dateParse.CompareTo(today) == 0)
                        {
                            writeError("Podałeś dzisiejszą datę, niesamowite!\nDziś się urodziłeś i już piszesz na klawiaturze?");
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                    catch (FormatException)
                    {
                        writeError("Niepoprawny format daty! (dzień, miesiąc, rok - możesz użyć dowolnego separatora)");
                        goto Label;
                    }
                }
                else
                {
                    writeError("Nie podałeś daty!");
                    goto Label;
                }
            }
            while (date.Length == 0 || (dateParse.CompareTo(today) == 0) || (dateParse.CompareTo(today) > 0));

            // calculates how many days left to birthday

            DateTime next = new DateTime(today.Year, dateParse.Month, dateParse.Day);
            if (next < today)
            {
                next = next.AddYears(1);
            }
            numDays = (next - today).Days;

            // list of wishes
            string[] wishes =
            {
                "W dniu tak pięknym i radosnym,\nniczym kwiat w promieniach wiosny,\nżyczę Ci dużo szczęścia i radości.\nW każdej chwili codzienności\nbądź szczęśliwy i radosny.",
                "Niech wiatr zawsze wieje Ci w plecy,\na słońce świeci w twarz.\nNiech dobry los da Ci zatańczyć\nwśród najjaśniejszych gwiazd!",
                "Dużo zdrowia i miłości,\nmoc uśmiechu i słodkości,\nmało smutku, trudów, łez,\nniech się spełni to, co chcesz!",
            };

            // making wishes
            if (numDays == 0)
            {
                // calculate how old user is
                age = today.Year - dateParse.Year;

                writeText(name + ", dziś są Twoje " + age + " urodziny!");
                Console.WriteLine();

                // chose random wishes
                int index = random.Next(wishes.Length);
                writeWishes(wishes[index]);

                // signature
                // personalized by name user
                if (name == "Filip")
                {
                    Console.WriteLine();
                    writeText("Pamiętaj! Życie zaczyna się po 30-tce\nŻyczy Michał i Ania z córka.");
                }
                // for all users
                else
                {
                    Console.WriteLine();
                    writeText("Wszystkiego najlepszego " + name + "!\nŻyczy autor programu.");
                }
            }
            // come back later
            else if (numDays > 0)
            {
                // calculates when user should back - nearest birthday
                nearestBirthday = today.AddDays(numDays);

                Console.Clear();
                writeText(name + ", dziś jest " + today.ToString("D") + ", a Twoje urodziny są za " + numDays + " dni.");
                // tip about leap year
                if ((DateTime.IsLeapYear(dateParse.Year)) && (dateParse.Month == 02) && (dateParse.Day == 29))
                {
                    writeError("Urodziłeś się w dniu przestępnym. Powinieneś urodziny obchodzić co 4 lata!");
                }
                else if (DateTime.IsLeapYear(dateParse.Year))
                {
                    writeError("Urodziłeś się w roku przestęnym!");
                }
                writeText("Proszę wróć " + nearestBirthday.ToString("d"));
                writeText("\nDo zobaczenia!!");
            }
            else
            {
                writeText("Program nie obsługuje takiego przypadku. \n" +
                    "Widzisz ten tekst? Zgłoś błąd autorowi.");
            }

            Console.WriteLine(dateParse);
            Console.ReadKey();
            Console.WriteLine();

            // dedication
            writeText("\nProgram napisany z okazji urodzin Filipa.\n                 I jest on mu dedykowany.\n");
            Console.ReadKey();
        }
    }
}
