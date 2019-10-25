using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string controller = string.Empty;
            while (controller.ToLower() != "q")
            {
                Console.Clear();
                Console.WriteLine("**********************   Főmenü   ********************\n");
                Console.WriteLine("A programról röviden:\n\nA program által lehetőségünk van különböző műveleteket, lekérdezéseket végezni egy olyan adatbázisban, mely termékekről tárol bizonyos információkat, többek között azt, hogy melyik áruházban milyen áron kapható az adott árucikk, és hogy az melyik gyártótól származik.");
                Console.WriteLine("\n******************************************************\n");
                Console.WriteLine("Parancsok:\n");

                Console.WriteLine("0: Adatok listázása");
                Console.WriteLine("1: Termék hozzáadása");
                Console.WriteLine("2: Termék törlése");
                Console.WriteLine("3: Termék módosítása");
                Console.WriteLine("4: Üzlet hozzáadása");
                Console.WriteLine("5: Üzlet törlése");
                Console.WriteLine("6: Üzlet módosítása");
                Console.WriteLine("7: Gyártó hozzáadása");
                Console.WriteLine("8: Gyártó törlése");
                Console.WriteLine("9: Gyártó módosítása");
                Console.WriteLine("A: Legolcsóbb áruház");
                Console.WriteLine("S: Legdrágább termék helye");
                Console.WriteLine("D: Ugyanazon termékek elérhetősége a legkisebb áron");
                Console.WriteLine("F: Osan áruház termékei");
                Console.WriteLine("Q: Kilépés a programból");
                Console.WriteLine();

                controller = Console.ReadLine();

                if (controller.ToLower() == "q")
                {
                    Console.Clear();
                    Console.WriteLine("A program leáll...");
                }
                else if (controller == "0")
                {
                    Console.Clear();
                    Console.WriteLine("\t\t*** Lekérdezések azonosító alapján ***");
                    Console.WriteLine("\n");
                    Console.WriteLine("1: Termék lekérdezése");
                    Console.WriteLine("2: Üzlet lekérdezése");
                    Console.WriteLine("3: Gyártó lekérdezése");
                    Console.WriteLine("\nEgyéb gombra visszatér a főmenübe.");
                    Console.WriteLine();

                    controller = string.Empty;
                    controller = Console.ReadLine();

                    Console.Clear();
                    switch (controller)
                    {
                        case "1":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;

                        case "3":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                    }

                    controller = string.Empty;
                }
                else
                {
                    Console.Clear();
                    switch (controller.ToLower())
                    {
                        case "1":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "2":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "3":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "4":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "5":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "6":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "7":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "8":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "9":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "a":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "s":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "d":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                        case "f":
                            Console.WriteLine("Ez még nincs kész.");
                            Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
}
