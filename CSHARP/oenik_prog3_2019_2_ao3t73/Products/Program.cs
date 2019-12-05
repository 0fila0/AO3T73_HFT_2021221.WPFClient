// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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
        private static object lockObject = new object();

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
                MainMenu();                                     // MainMenu(): This method display to user all options that user can use.
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
                            Write_EntityDatas(listP);
                            break;

                        case "2":
                            List<Aruhaz> listS = new List<Aruhaz>();    // listS = listShop
                            listS = logic.GetAllShops();
                            Write_EntityDatas(listS);
                            break;

                        case "3":
                            List<Gyarto> listM = new List<Gyarto>();    // listM = listManufacturer
                            listM = logic.GetAllManufacturers();
                            Write_EntityDatas(listM);
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
                            string entityP = "termék";
                            string propertiesP = "típus#megnevezés#kiszerelés#ár#leírás#gyártó neve";
                            Write_NewEntity(entityP, propertiesP);

                            string newProductParameters = Console.ReadLine();
                            Termek newProduct = new Termek()
                            {
                                Megnevezes = newProductParameters.Split('#')[0],
                                Tipus = newProductParameters.Split('#')[1],
                                Kiszereles = newProductParameters.Split('#')[2],
                                Ar = int.Parse(newProductParameters.Split('#')[3]),
                                Leiras = newProductParameters.Split('#')[4],
                                Gyarto_neve = newProductParameters.Split('#')[5],
                            };
                            List<Termek> listOfProducts = logic.GetAllProducts();
                            int newID = (int)ProductIDFinder(listOfProducts);
                            newProduct.Termek_ID = newID;
                            logic.AddProduct(newProduct);
                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.WriteLine("Add meg a termék azonosítóját, amit ki szeretnél törölni!");
                            string deleteProductID = Console.ReadLine();
                            Termek deleteProduct = new Termek()
                            {
                                Termek_ID = int.Parse(deleteProductID),
                            };
                            logic.DeleteProduct(deleteProduct);
                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "3":
                            Console.WriteLine("Add meg a módosítandó termék azonosítóját!");
                            int updateProductID = int.Parse(Console.ReadLine());
                            listOfProducts = logic.GetAllProducts();
                            Termek thisPropertyShouldNotBeModified_P = new Termek();
                            thisPropertyShouldNotBeModified_P = listOfProducts.Find(x => x.Termek_ID == updateProductID);

                            Console.Clear();
                            Write_ModifyProductID(updateProductID);  // Prints on the screen the product's ID which the user wants to modify.

                            Console.WriteLine("Add meg a termék azon tulajdonságát, amit módosítani szeretnél!\n");
                            Console.WriteLine("0: Vissza a főmenübe\n\n1: Típus\n2: Megnevezés\n3: Kiszerelés\n4: Ár\n5: Leírás\n");
                            controller = Console.ReadLine();

                            Console.Clear();
                            Write_ModifyProductID(updateProductID);  // Prints on the screen the product's ID which the user wants to modify.
                            switch (controller)
                            {
                                case "0":
                                    break;
                                case "1":
                                    Console.WriteLine("Add meg a termék új típusát!");
                                    string updateProductType = Console.ReadLine();
                                    Termek updateProduct_T = new Termek
                                    {
                                        Termek_ID = updateProductID,
                                        Tipus = updateProductType,
                                        Megnevezes = thisPropertyShouldNotBeModified_P.Megnevezes,
                                        Kiszereles = thisPropertyShouldNotBeModified_P.Kiszereles,
                                        Ar = thisPropertyShouldNotBeModified_P.Ar,
                                        Leiras = thisPropertyShouldNotBeModified_P.Leiras,
                                        Gyarto = thisPropertyShouldNotBeModified_P.Gyarto,
                                        Gyarto_neve = thisPropertyShouldNotBeModified_P.Gyarto_neve,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_P.ID_Kapcsolo,
                                    };
                                    logic.UpdateProduct(updateProduct_T);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.WriteLine("Add meg a termék új nevét!");
                                    string updateProductName = Console.ReadLine();
                                    Termek updateProduct_N = new Termek
                                    {
                                        Termek_ID = updateProductID,
                                        Megnevezes = updateProductName,
                                        Tipus = thisPropertyShouldNotBeModified_P.Tipus,
                                        Kiszereles = thisPropertyShouldNotBeModified_P.Kiszereles,
                                        Ar = thisPropertyShouldNotBeModified_P.Ar,
                                        Leiras = thisPropertyShouldNotBeModified_P.Leiras,
                                        Gyarto = thisPropertyShouldNotBeModified_P.Gyarto,
                                        Gyarto_neve = thisPropertyShouldNotBeModified_P.Gyarto_neve,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_P.ID_Kapcsolo,
                                    };
                                    logic.UpdateProduct(updateProduct_N);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Console.WriteLine("Add meg a termék új kiszerelését!");
                                    string updateProductPack = Console.ReadLine();
                                    Termek updateProduct_P = new Termek
                                    {
                                        Termek_ID = updateProductID,
                                        Kiszereles = updateProductPack,
                                        Megnevezes = thisPropertyShouldNotBeModified_P.Megnevezes,
                                        Tipus = thisPropertyShouldNotBeModified_P.Tipus,
                                        Ar = thisPropertyShouldNotBeModified_P.Ar,
                                        Leiras = thisPropertyShouldNotBeModified_P.Leiras,
                                        Gyarto = thisPropertyShouldNotBeModified_P.Gyarto,
                                        Gyarto_neve = thisPropertyShouldNotBeModified_P.Gyarto_neve,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_P.ID_Kapcsolo,
                                    };
                                    logic.UpdateProduct(updateProduct_P);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("Add meg a termék új árát!");
                                    string updateProductCost = Console.ReadLine();
                                    Termek updateProduct_C = new Termek
                                    {
                                        Termek_ID = updateProductID,
                                        Ar = int.Parse(updateProductCost),
                                        Megnevezes = thisPropertyShouldNotBeModified_P.Megnevezes,
                                        Kiszereles = thisPropertyShouldNotBeModified_P.Kiszereles,
                                        Tipus = thisPropertyShouldNotBeModified_P.Tipus,
                                        Leiras = thisPropertyShouldNotBeModified_P.Leiras,
                                        Gyarto = thisPropertyShouldNotBeModified_P.Gyarto,
                                        Gyarto_neve = thisPropertyShouldNotBeModified_P.Gyarto_neve,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_P.ID_Kapcsolo,
                                    };
                                    logic.UpdateProduct(updateProduct_C);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    Console.WriteLine("Add meg a termék új leírását!");
                                    string updateProductDescription = Console.ReadLine();
                                    Termek updateProduct_D = new Termek
                                    {
                                        Termek_ID = updateProductID,
                                        Leiras = updateProductDescription,
                                        Megnevezes = thisPropertyShouldNotBeModified_P.Megnevezes,
                                        Kiszereles = thisPropertyShouldNotBeModified_P.Kiszereles,
                                        Ar = thisPropertyShouldNotBeModified_P.Ar,
                                        Tipus = thisPropertyShouldNotBeModified_P.Tipus,
                                        Gyarto = thisPropertyShouldNotBeModified_P.Gyarto,
                                        Gyarto_neve = thisPropertyShouldNotBeModified_P.Gyarto_neve,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_P.ID_Kapcsolo,
                                    };
                                    logic.UpdateProduct(updateProduct_D);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                            }

                            controller = string.Empty;
                            break;

                        case "4":
                            string entityS = "üzlet";
                            string propertiesS = "név#honlap#email#telefon#központ#adószám";
                            Write_NewEntity(entityS, propertiesS);

                            string newShopParameters = Console.ReadLine();
                            Aruhaz newShop = new Aruhaz()
                            {
                                Aruhaz_neve = newShopParameters.Split('#')[0],
                                Honlap = newShopParameters.Split('#')[1],
                                E_mail = newShopParameters.Split('#')[2],
                                Telefon = int.Parse(newShopParameters.Split('#')[3]),
                                Kozpont = newShopParameters.Split('#')[4],
                                Adoszam = int.Parse(newShopParameters.Split('#')[5]),
                            };
                            List<Aruhaz> listOfShops = logic.GetAllShops();
                            Aruhaz item = listOfShops.Find(x => x.Aruhaz_neve.Contains(newShop.Aruhaz_neve));

                            if (item == null)
                            {
                                logic.AddShop(newShop);
                            }
                            else
                            {
                                Console.WriteLine("Már van ilyen üzlet!");
                            }

                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "5":
                            Console.WriteLine("Add meg az üzlet nevét, amit ki szeretnél törölni!");
                            string deleteShopID = Console.ReadLine();
                            Aruhaz deleteShop = new Aruhaz()
                            {
                                Aruhaz_neve = deleteShopID,
                            };
                            logic.DeleteShop(deleteShop);
                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "6":
                            Console.WriteLine("Add meg a módosítandó üzlet nevét!");
                            string updateShopName = Console.ReadLine();
                            listOfShops = logic.GetAllShops();
                            Aruhaz thisPropertyShouldNotBeModified_S = new Aruhaz();
                            thisPropertyShouldNotBeModified_S = listOfShops.Find(x => x.Aruhaz_neve == updateShopName);

                            Console.Clear();
                            Write_ModifyShopName(updateShopName);  // Prints on the screen the shop's name which the user wants to modify.

                            Console.WriteLine("Add meg az üzlet azon tulajdonságát, amit módosítani szeretnél!\n");
                            Console.WriteLine("0: Vissza a főmenübe\n\n1: Honlap\n2: Email\n3: Telefon\n4: Központ\n5: Adószám\n");
                            controller = Console.ReadLine();

                            Console.Clear();
                            Write_ModifyShopName(updateShopName);  // Prints on the screen the shop's name which the user wants to modify.
                            switch (controller)
                            {
                                case "0":
                                    break;
                                case "1":
                                    Console.WriteLine("Add meg az üzlet új honlapját!");
                                    string updateShopWeb = Console.ReadLine();
                                    Aruhaz updateShop_W = new Aruhaz
                                    {
                                        Aruhaz_neve = updateShopName,
                                        Honlap = updateShopWeb,
                                        E_mail = thisPropertyShouldNotBeModified_S.E_mail,
                                        Telefon = thisPropertyShouldNotBeModified_S.Telefon,
                                        Kozpont = thisPropertyShouldNotBeModified_S.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_S.Adoszam,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_S.ID_Kapcsolo,
                                    };
                                    logic.UpdateShop(updateShop_W);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.WriteLine("Add meg az üzlet új email címét!");
                                    string updateShopEmail = Console.ReadLine();
                                    Aruhaz updateShop_E = new Aruhaz
                                    {
                                        Aruhaz_neve = updateShopName,
                                        E_mail = updateShopEmail,
                                        Honlap = thisPropertyShouldNotBeModified_S.Honlap,
                                        Telefon = thisPropertyShouldNotBeModified_S.Telefon,
                                        Kozpont = thisPropertyShouldNotBeModified_S.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_S.Adoszam,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_S.ID_Kapcsolo,
                                    };
                                    logic.UpdateShop(updateShop_E);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Console.WriteLine("Add meg az üzlet új telefonszámát!");
                                    int updateShopPhone = int.Parse(Console.ReadLine());
                                    Aruhaz updateShop_P = new Aruhaz
                                    {
                                        Aruhaz_neve = updateShopName,
                                        Telefon = updateShopPhone,
                                        Honlap = thisPropertyShouldNotBeModified_S.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_S.E_mail,
                                        Kozpont = thisPropertyShouldNotBeModified_S.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_S.Adoszam,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_S.ID_Kapcsolo,
                                    };
                                    logic.UpdateShop(updateShop_P);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("Add meg az üzlet új központját!");
                                    string updateShopCenter = Console.ReadLine();
                                    Aruhaz updateShop_C = new Aruhaz
                                    {
                                        Aruhaz_neve = updateShopName,
                                        Kozpont = updateShopCenter,
                                        Honlap = thisPropertyShouldNotBeModified_S.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_S.E_mail,
                                        Telefon = thisPropertyShouldNotBeModified_S.Telefon,
                                        Adoszam = thisPropertyShouldNotBeModified_S.Adoszam,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_S.ID_Kapcsolo,
                                    };
                                    logic.UpdateShop(updateShop_C);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    Console.WriteLine("Add meg az üzlet új adószámát!");
                                    int updateShopTax = int.Parse(Console.ReadLine());
                                    Aruhaz updateShop_T = new Aruhaz
                                    {
                                        Aruhaz_neve = updateShopName,
                                        Adoszam = updateShopTax,
                                        Honlap = thisPropertyShouldNotBeModified_S.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_S.E_mail,
                                        Kozpont = thisPropertyShouldNotBeModified_S.Kozpont,
                                        Telefon = thisPropertyShouldNotBeModified_S.Telefon,
                                        ID_Kapcsolo = thisPropertyShouldNotBeModified_S.ID_Kapcsolo,
                                    };
                                    logic.UpdateShop(updateShop_T);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                            }

                            controller = string.Empty;
                            break;

                        case "7":
                            string entityM = "gyártó";
                            string propertiesM = "név#honlap#email#telefon#központ#adószám";
                            Write_NewEntity(entityM, propertiesM);

                            string newManufacturerParameters = Console.ReadLine();
                            Gyarto newManufacturer = new Gyarto()
                            {
                                Gyarto_neve = newManufacturerParameters.Split('#')[0],
                                Honlap = newManufacturerParameters.Split('#')[1],
                                E_mail = newManufacturerParameters.Split('#')[2],
                                Telefon = int.Parse(newManufacturerParameters.Split('#')[3]),
                                Kozpont = newManufacturerParameters.Split('#')[4],
                                Adoszam = int.Parse(newManufacturerParameters.Split('#')[5]),
                            };
                            List<Gyarto> listOfManufacturers = logic.GetAllManufacturers();
                            Gyarto item_M = listOfManufacturers.Find(x => x.Gyarto_neve.Contains(newManufacturer.Gyarto_neve));

                            if (item_M == null)
                            {
                                logic.AddManufacturer(newManufacturer);
                            }
                            else
                            {
                                Console.WriteLine("Már van ilyen gyártó!");
                            }

                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "8":
                            Console.WriteLine("Add meg a gyártó nevét, amit ki szeretnél törölni!");
                            string deleteManufacturerID = Console.ReadLine();
                            Gyarto deleteManufacturer = new Gyarto()
                            {
                                Gyarto_neve = deleteManufacturerID,
                            };
                            logic.DeleteManufacturer(deleteManufacturer);
                            Console.WriteLine("\nA folytatáshoz nyomj entert!");
                            Console.ReadLine();
                            break;

                        case "9":
                            Console.WriteLine("Add meg a módosítandó gyártó nevét!");
                            string updateManufacturerName = Console.ReadLine();
                            listOfManufacturers = logic.GetAllManufacturers();
                            Gyarto thisPropertyShouldNotBeModified_M = new Gyarto();
                            thisPropertyShouldNotBeModified_M = listOfManufacturers.Find(x => x.Gyarto_neve == updateManufacturerName);

                            Console.Clear();
                            Write_ModifyManufacturerName(updateManufacturerName);  // Prints on the screen the manufacturer's name which the user wants to modify.

                            Console.WriteLine("Add meg a gyártó azon tulajdonságát, amit módosítani szeretnél!\n");
                            Console.WriteLine("0: Vissza a főmenübe\n\n1: Honlap\n2: Email\n3: Telefon\n4: Központ\n5: Adószám\n");
                            controller = Console.ReadLine();

                            Console.Clear();
                            Write_ModifyManufacturerName(updateManufacturerName);  // Prints on the screen the manufacturer's name which the user wants to modify.
                            switch (controller)
                            {
                                case "0":
                                    break;
                                case "1":
                                    Console.WriteLine("Add meg a gyártó új honlapját!");
                                    string updateManufacturerWeb = Console.ReadLine();
                                    Gyarto updateManufacturer_W = new Gyarto
                                    {
                                        Gyarto_neve = updateManufacturerName,
                                        Honlap = updateManufacturerWeb,
                                        E_mail = thisPropertyShouldNotBeModified_M.E_mail,
                                        Telefon = thisPropertyShouldNotBeModified_M.Telefon,
                                        Kozpont = thisPropertyShouldNotBeModified_M.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_M.Adoszam,
                                    };
                                    logic.UpdateManufacturer(updateManufacturer_W);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "2":
                                    Console.WriteLine("Add meg a gyártó új email címét!");
                                    string updateManufacturerEmail = Console.ReadLine();
                                    Gyarto updateManufacturer_E = new Gyarto
                                    {
                                        Gyarto_neve = updateManufacturerName,
                                        E_mail = updateManufacturerEmail,
                                        Honlap = thisPropertyShouldNotBeModified_M.Honlap,
                                        Telefon = thisPropertyShouldNotBeModified_M.Telefon,
                                        Kozpont = thisPropertyShouldNotBeModified_M.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_M.Adoszam,
                                    };
                                    logic.UpdateManufacturer(updateManufacturer_E);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "3":
                                    Console.WriteLine("Add meg a gyártó új telefonszámát!");
                                    int updateManufacturerPhone = int.Parse(Console.ReadLine());
                                    Gyarto updateManufacturer_P = new Gyarto
                                    {
                                        Gyarto_neve = updateManufacturerName,
                                        Telefon = updateManufacturerPhone,
                                        Honlap = thisPropertyShouldNotBeModified_M.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_M.E_mail,
                                        Kozpont = thisPropertyShouldNotBeModified_M.Kozpont,
                                        Adoszam = thisPropertyShouldNotBeModified_M.Adoszam,
                                    };
                                    logic.UpdateManufacturer(updateManufacturer_P);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "4":
                                    Console.WriteLine("Add meg a gyártó új központját!");
                                    string updateManufacturerCenter = Console.ReadLine();
                                    Gyarto updateManufacturer_C = new Gyarto
                                    {
                                        Gyarto_neve = updateManufacturerName,
                                        Kozpont = updateManufacturerCenter,
                                        Honlap = thisPropertyShouldNotBeModified_M.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_M.E_mail,
                                        Telefon = thisPropertyShouldNotBeModified_M.Telefon,
                                        Adoszam = thisPropertyShouldNotBeModified_M.Adoszam,
                                    };
                                    logic.UpdateManufacturer(updateManufacturer_C);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                                case "5":
                                    Console.WriteLine("Add meg a gyártó új adószámát!");
                                    int updateManufacturerTax = int.Parse(Console.ReadLine());
                                    Gyarto updateManufacturer_T = new Gyarto
                                    {
                                        Gyarto_neve = updateManufacturerName,
                                        Adoszam = updateManufacturerTax,
                                        Honlap = thisPropertyShouldNotBeModified_M.Honlap,
                                        E_mail = thisPropertyShouldNotBeModified_M.E_mail,
                                        Kozpont = thisPropertyShouldNotBeModified_M.Kozpont,
                                        Telefon = thisPropertyShouldNotBeModified_M.Telefon,
                                    };
                                    logic.UpdateManufacturer(updateManufacturer_T);
                                    Console.WriteLine("\nA folytatáshoz nyomj entert!");
                                    Console.ReadLine();
                                    break;
                            }

                            controller = string.Empty;
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

        private static void Write_EntityDatas(IEnumerable<object> list)
        {
            foreach (var item in list)
            {
                PropertyInfo[] props = item.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetCustomAttribute<DontWriteToTheStandardOutput>() == null)
                    {
                        if (prop.GetValue(item) == null)
                        {
                            Console.WriteLine(prop.Name + ": ---");
                        }
                        else
                        {
                            Console.WriteLine(prop.Name + ": " + prop.GetValue(item));
                        }
                    }
                }

                Console.WriteLine("\n************************\n");
            }

            Console.WriteLine("\nNyomj entert a folytatáshoz!");
            Console.ReadLine();
        }

        private static void Write_EntityDatasS(IEnumerable<string> list)
        {
            foreach (var item in list)
            {
                if (item == null)
                {
                    Console.WriteLine("---");
                }
                else
                {
                    Console.WriteLine("Áruház neve: " + item);
                }

                Console.WriteLine("\n************************\n");
            }

            Console.WriteLine("\nNyomj entert a folytatáshoz!");
            Console.ReadLine();
        }

        private static void Write_EntityDatasCheapestShop(string cheapestShop)
        {
            if (cheapestShop == null || cheapestShop == string.Empty)
            {
                Console.WriteLine("---");
            }
            else
            {
                Console.WriteLine("Áruház neve: " + cheapestShop);
            }

            Console.WriteLine("\n************************\n");

            Console.WriteLine("\nNyomj entert a folytatáshoz!");
            Console.ReadLine();
        }

        private static void Write_EntityDatasQ(IQueryable<object> list)
        {
            foreach (var item in list)
            {
                PropertyInfo[] props = item.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetCustomAttribute<DontWriteToTheStandardOutput>() == null)
                    {
                        if (prop.GetValue(item) == null)
                        {
                            Console.WriteLine(prop.Name + ": ---");
                        }
                        else
                        {
                            Console.WriteLine(prop.Name + ": " + prop.GetValue(item));
                        }
                    }
                }

                Console.WriteLine("\n************************\n");
            }

            Console.WriteLine("\nNyomj entert a folytatáshoz!");
            Console.ReadLine();
        }

        private static void Write_NewEntity(string entity, string properties)
        {
            Console.WriteLine("Add meg a " + entity + " paramétereit '#' karakterrel elválasztva!");
            Console.WriteLine();
            Console.WriteLine(properties);
            Console.WriteLine();
            Console.WriteLine("Minden adatot kötelező megadni!\n\n");
        }

        /// <summary>
        /// This method finds the first ID which is not assigned.
        /// </summary>
        /// <returns> ID's number. </returns>
        /// <param name="list"> List contains all of products. </param>
        private static decimal ProductIDFinder(List<Termek> list)
        {
            decimal newProductID = 1;
            foreach (var item in list)
            {
                PropertyInfo[] props = item.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    lock (lockObject)
                    {
                        if (prop.GetCustomAttribute<ThisIsAnID>() != null)
                        {
                            decimal lastIDInList = (decimal)prop.GetValue(item);
                            if (newProductID < lastIDInList)
                            {
                                return newProductID;
                            }

                            newProductID++;
                        }
                    }
                }
            }

            return newProductID;
        }

        private static void MainMenu()
        {
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
        }
    }
}
