// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using Products.Logic;
    using Products.Repository;

    /// <summary>
    /// This is the StartUp project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method communicates with the user, this is the User Interface.
        /// </summary>
        public static void Main()
        {
            Logical logic = new Logical(new Repository());

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
                    Console.WriteLine("\t\t*** Listázás ***");
                    Console.WriteLine("\n");
                    Console.WriteLine("1: Termékek listázása");
                    Console.WriteLine("2: Üzletek listázása");
                    Console.WriteLine("3: Gyártók listázása");
                    Console.WriteLine("\nEgyéb gombra visszatér a főmenübe.");
                    Console.WriteLine();

                    controller = string.Empty;
                    controller = Console.ReadLine();

                    Console.Clear();
                    switch (controller)
                    {
                        case "1":
                            List<Termek> listP = new List<Termek>();    // listP = listProduct
                            listP = logic.GetAllProducts();
                            foreach (var item in listP)
                            {
                                Console.WriteLine(item.Megnevezes);
                            }

                            Console.ReadLine();
                            break;

                        case "2":
                            List<Aruhaz> listS = new List<Aruhaz>();    // listS = listShop
                            listS = logic.GetAllShops();
                            foreach (var item in listS)
                            {
                                Console.WriteLine(item.Aruhaz_neve);
                            }

                            Console.ReadLine();
                            break;

                        case "3":
                            List<Gyarto> listM = new List<Gyarto>();    // listM = listManufacturer
                            listM = logic.GetAllManufacturers();
                            foreach (var item in listM)
                            {
                                Console.WriteLine(item.Gyarto_neve);
                            }

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

        private static void Write_ModifyProductID(int updateProductID)
        {
            Console.WriteLine("A módosítandó termék azonosítója: " + updateProductID);
            Console.WriteLine();
        }

        private static void Write_ModifyShopName(string updateShopName)
        {
            Console.WriteLine("A módosítandó üzlet neve: " + updateShopName);
            Console.WriteLine();
        }

        private static void Write_ModifyManufacturerName(string updateManufacturerName)
        {
            Console.WriteLine("A módosítandó gyártó neve: " + updateManufacturerName);
            Console.WriteLine();
        }
    }
}
