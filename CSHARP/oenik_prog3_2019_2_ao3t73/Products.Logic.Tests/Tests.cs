// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Products.Data;
    using Products.Logic;
    using Products.Repository;

    /// <summary>
    /// Logic.Tests class tests the Logic class with mocked repository.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private Logical logic;

        /// <summary>
        /// Set up the variables and lists.
        /// </summary>
        [SetUp]
        public void Init()
        {
            var mock = new Mock<IRepository>();
            List<Aruhaz> mockedShopsList = new List<Aruhaz>();
            List<Gyarto> mockedManufacturersList = new List<Gyarto>();
            List<Termek> mockedProductsList = new List<Termek>();
            List<ID_Kapcsolo> mockedIDLinksList = new List<ID_Kapcsolo>();

            mockedShopsList.Add(new Aruhaz()
            {
                Aruhaz_neve = "A",
                Honlap = "a-shop.com",
                Telefon = 06200000000,
                Adoszam = 123456789,
                E_mail = "A@shop.com",
                Kozpont = "ALA",
            });
            mockedShopsList.Add(new Aruhaz()
            {
                Aruhaz_neve = "B",
                Honlap = "b-shop.com",
                Telefon = 06301111111,
                Adoszam = 987654321,
                E_mail = "B@shop.com",
                Kozpont = "BLB",
            });
            mockedManufacturersList.Add(new Gyarto()
            {
                Gyarto_neve = "M_1",
                Honlap = "M1-manu.com",
                Telefon = 06901111111,
                Adoszam = 000000000,
                E_mail = "M1@manu.com",
                Kozpont = "MLM1",
            });
            mockedManufacturersList.Add(new Gyarto()
            {
                Gyarto_neve = "M_2",
                Honlap = "M2-manu.com",
                Telefon = 06902222222,
                Adoszam = 111111111,
                E_mail = "M2@manu.com",
                Kozpont = "MLM2",
            });
            mockedProductsList.Add(new Termek()
            {
                Termek_ID = 1,
                Ar = 500,
                Kiszereles = "kg",
                Leiras = "Dedikált",
                Megnevezes = "Léggitár",
                Tipus = "Hangszer",
                Gyarto_neve = "M_2",
            });
            mockedProductsList.Add(new Termek()
            {
                Termek_ID = 2,
                Ar = 1000,
                Kiszereles = "kg",
                Leiras = "Nem dedikált",
                Megnevezes = "Léggitár",
                Tipus = "Hangszer",
                Gyarto_neve = "M_1",
            });
            mockedIDLinksList.Add(new ID_Kapcsolo()
            {
                Kapcsolo_ID = 1,
                Termek_ID = 1,
                Aruhaz_neve = "A",
            });
            mockedIDLinksList.Add(new ID_Kapcsolo()
            {
                Kapcsolo_ID = 2,
                Termek_ID = 2,
                Aruhaz_neve = "B",
            });

            mock.Setup(m => m.GetAllManufacturers()).Returns(mockedManufacturersList);
            mock.Setup(m => m.GetAllProducts()).Returns(mockedProductsList);
            mock.Setup(m => m.GetAllShops()).Returns(mockedShopsList);
            mock.Setup(m => m.GetAllLinks()).Returns(mockedIDLinksList);

            IRepository mockedRepository = mock.Object;

            this.logic = new Logical(mockedRepository);
        }

        /// <summary>
        /// Test GetAllManufacturer method.
        /// </summary>
        [Test]
        public void GetAllManufacturersMethodTest()
        {
            Assert.That(this.logic.GetAllManufacturers() != null);
        }

        /// <summary>
        /// Test GetAllProducts method.
        /// </summary>
        [Test]
        public void GetAllProductsMethodTest()
        {
            Assert.That(this.logic.GetAllProducts() != null);
        }

        /// <summary>
        /// Test GetAllShops method.
        /// </summary>
        [Test]
        public void GetAllShopsMethodTest()
        {
            Assert.That(this.logic.GetAllShops() != null);
        }

        /// <summary>
        /// Test AddManufacturer method.
        /// </summary>
        [Test]
        public void AddManufacturersMethodTest()
        {
            int numberOfElementsBeforeAdd = this.logic.GetAllManufacturers().Count;
            Gyarto mockManufacturer = new Gyarto();
            this.logic.AddManufacturer(mockManufacturer);
            Assert.That(this.logic.GetAllManufacturers().Count == numberOfElementsBeforeAdd);
        }

        /// <summary>
        /// Test AddShop method.
        /// </summary>
        [Test]
        public void AddShopMethodTest()
        {
            int numberOfElementsBeforeAdd = this.logic.GetAllShops().Count;
            Aruhaz mockShop = new Aruhaz();
            this.logic.AddShop(mockShop);
            Assert.That(this.logic.GetAllShops().Count == numberOfElementsBeforeAdd);
        }

        /// <summary>
        /// Test AddProduct method.
        /// </summary>
        [Test]
        public void AddProductMethodTest()
        {
            int numberOfElementsBeforeAdd = this.logic.GetAllProducts().Count;
            Termek mockProduct = new Termek
            {
                Termek_ID = 10,
            };
            this.logic.AddProduct(mockProduct);
            int numberOfElementsAfterAdd = this.logic.GetAllProducts().Count;
            Assert.That(numberOfElementsAfterAdd == numberOfElementsBeforeAdd);
        }

        /// <summary>
        /// Test DeleteManufacturer method.
        /// </summary>
        [Test]
        public void DeleteManufacturerMethodTest()
        {
            int numberOfElementsBeforeDelete = this.logic.GetAllManufacturers().Count;
            Gyarto mockManufacturer = new Gyarto
            {
                Gyarto_neve = "delete",
            };
            this.logic.AddManufacturer(mockManufacturer);
            this.logic.DeleteManufacturer(mockManufacturer);
            Assert.That(this.logic.GetAllManufacturers().Count == numberOfElementsBeforeDelete);
        }

        /// <summary>
        /// Test DeleteShop method.
        /// </summary>
        [Test]
        public void DeleteShopMethodTest()
        {
            int numberOfElementsBeforeDelete = this.logic.GetAllShops().Count;
            Aruhaz mockShop = new Aruhaz
            {
                Aruhaz_neve = "delete",
            };
            this.logic.AddShop(mockShop);
            this.logic.DeleteShop(mockShop);
            Assert.That(this.logic.GetAllShops().Count == numberOfElementsBeforeDelete);
        }

        /// <summary>
        /// Test DeleteProduct method.
        /// </summary>
        [Test]
        public void DeleteProductMethodTest()
        {
            int numberOfElementsBeforeDelete = this.logic.GetAllProducts().Count;
            Termek mockProduct = new Termek
            {
                Termek_ID = 13,
            };
            this.logic.AddProduct(mockProduct);
            this.logic.DeleteProduct(mockProduct);
            Assert.That(this.logic.GetAllProducts().Count == numberOfElementsBeforeDelete);
        }

        /// <summary>
        /// Test UpdateProduct method.
        /// </summary>
        [Test]
        public void UpdateProductMethodTest()
        {
            Termek x = new Termek()
            {
                Termek_ID = 1,
                Ar = 1000,
                Kiszereles = "kg",
                Leiras = "Dedikált",
                Megnevezes = "Léggitár",
                Tipus = "Hangszer",
                Gyarto_neve = "M_2",
            };

            this.logic.UpdateProduct(x);
            Assert.That(this.logic.GetAllProducts().Contains(x) == false);
        }

        /// <summary>
        /// Test UpdateShop method.
        /// </summary>
        [Test]
        public void UpdateShopMethodTest()
        {
            Aruhaz x = new Aruhaz()
            {
                Aruhaz_neve = "A",
                Honlap = "new.web.com",
                Telefon = 06200000000,
                Adoszam = 123456789,
                E_mail = "A@shop.com",
                Kozpont = "ALA",
            };

            this.logic.UpdateShop(x);
            Assert.That(this.logic.GetAllShops().Contains(x) == false);
        }

        /// <summary>
        /// Test UpdateShop method.
        /// </summary>
        [Test]
        public void UpdateManufacturerMethodTest()
        {
            Gyarto x = new Gyarto()
            {
                Gyarto_neve = "M_2",
                Honlap = "M2-manu.com",
                Telefon = 061555669,
                Adoszam = 111111111,
                E_mail = "M2@manu.com",
                Kozpont = "MLM2",
            };

            this.logic.UpdateManufacturer(x);
            Assert.That(this.logic.GetAllManufacturers().Contains(x) == false);
        }

        /// <summary>
        /// Test OsanProducts method.
        /// </summary>
        [Test]
        public void OsanProductsTest()
        {
            IQueryable<object> productsOsanIsNot = this.logic.OsanProducts();
            Assert.That(productsOsanIsNot.Count() == 0);

            List<Aruhaz> mockedShopsList = new List<Aruhaz>();
            List<Termek> mockedProductsList = new List<Termek>();
            List<ID_Kapcsolo> mockedIDLinksList = new List<ID_Kapcsolo>();

            mockedProductsList.Add(new Termek()
            {
                Termek_ID = 2,
                Ar = 1000,
                Kiszereles = "kg",
                Leiras = "Nem dedikált",
                Megnevezes = "Léggitár",
                Tipus = "Hangszer",
                Gyarto_neve = "M_1",
            });
            mockedIDLinksList.Add(new ID_Kapcsolo()
            {
                Kapcsolo_ID = 1,
                Termek_ID = 2,
                Aruhaz_neve = "Osan",
            });
            mockedShopsList.Add(new Aruhaz()
            {
                Aruhaz_neve = "Osan",
                Honlap = "a-shop.com",
                Telefon = 06200000000,
                Adoszam = 123456789,
                E_mail = "A@shop.com",
                Kozpont = "ALA",
            });

            IQueryable<object> productsOsanIs = this.logic.OsanProducts();
            Assert.That(productsOsanIs != null);
        }

        /// <summary>
        /// Test CheapestShop method.
        /// </summary>
        [Test]
        public void CheapestShopTest()
        {
            string cheapestShop = this.logic.CheapestShop();
            Assert.That(cheapestShop == "A");
        }

        /// <summary>
        /// Test OsanProducts method.
        /// </summary>
        [Test]
        public void PlaceOfMostExpensiveProductsTest()
        {
            IEnumerable<string> thatShopEnu = this.logic.PlaceOfMostExpensiveProduct();
            string thatShop = thatShopEnu.First();
            Assert.That(thatShop == "B");
        }
    }
}
