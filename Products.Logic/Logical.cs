// <copyright file="Logical.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using Products.Data.Models;
    using Products.Repository;

    /// <summary>
    /// This interface describes what methods should be implemented in Logic class.
    /// </summary>
    public class Logical : ILogic
    {
        private readonly IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logical"/> class.
        /// </summary>
        /// <param name="repo">Repository parameter.</param>
        public Logical(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// This method returns all link entities.
        /// </summary>
        /// <returns> A list with all link entities. </returns>
        public IEnumerable<IDKapcsolo> GetAllLinks()
        {
            List<IDKapcsolo> listOfLinks = this.repo.GetAllLinks() as List<IDKapcsolo>;
            return listOfLinks;
        }

        /// <summary>
        /// This method returns all manufacturer entities.
        /// </summary>
        /// <returns> A list with all manufacturer entities. </returns>
        public IEnumerable<Gyarto> GetAllManufacturers()
        {
            List<Gyarto> listOfManufacturers = this.repo.GetAllManufacturers() as List<Gyarto>;
            return listOfManufacturers;
        }

        /// <summary>
        /// This method returns all product entities.
        /// </summary>
        /// <returns> A list with all product entities. </returns>
        public IEnumerable<Termek> GetAllProducts()
        {
            List<Termek> listOfProducts = this.repo.GetAllProducts() as List<Termek>;
            return listOfProducts;
        }

        /// <summary>
        /// This method returns all shop entities.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        public IEnumerable<Aruhaz> GetAllShops()
        {
            List<Aruhaz> listOfShops = this.repo.GetAllShops() as List<Aruhaz>;
            return listOfShops;
        }

        /// <inheritdoc/>
        public Aruhaz GetOneShop(string id)
        {
            Aruhaz oneShop = this.repo.GetAllShops().Where(x => x.AruhazNeve == id).FirstOrDefault();
            return oneShop;
        }

        /// <summary>
        /// This method adds a new link entity to the database.
        /// </summary>
        /// <param name="param"> Link that user intend to add. </param>
        public void AddLink(IDKapcsolo param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method adds a new manufacturer entity to the database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to add. </param>
        public void AddManufacturer(Gyarto param)
        {
            this.repo.AddManufacturer(param);
        }

        /// <summary>
        /// This method adds a new product entity to the database.
        /// </summary>
        /// <param name="param"> Product that user intend to add. </param>
        public void AddProduct(Termek param)
        {
            this.repo.AddProduct(param);
        }

        /// <summary>
        /// This method adds a new shop entity to the database.
        /// </summary>
        /// <param name="param"> Shop that user intend to add. </param>
        public void AddShop(Aruhaz param)
        {
            this.repo.AddShop(param);
        }

        /// <inheritdoc/>
        public void AddShop(string nev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam)
        {
            Aruhaz newAruhaz = new Aruhaz()
            {
                AruhazNeve = nev,
                EMail = email,
                Kozpont = kozpont,
                Honlap = honlap,
                Telefon = telefon,
                Adoszam = adoszam,
            };
            this.repo.AddShop(newAruhaz);
        }

        /// <summary>
        /// This method deletes a link entity from database.
        /// </summary>
        /// <param name="param"> Link that user intend to delete. </param>
        public void DeleteLink(IDKapcsolo param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method deletes a manufacturer entity from database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to delete. </param>
        public void DeleteManufacturer(Gyarto param)
        {
            List<Gyarto> listOfManufacturers = this.repo.GetAllManufacturers() as List<Gyarto>;
            Gyarto item = listOfManufacturers.Find(x => x.GyartoNeve.Contains(param.GyartoNeve, StringComparison.Ordinal));

            if (item != null)
            {
                this.repo.DeleteManufacturer(item);
            }
        }

        /// <summary>
        /// This method deletes a product entity from database.
        /// </summary>
        /// <param name="param"> Product that user intend to delete. </param>
        public void DeleteProduct(Termek param)
        {
            List<Termek> listOfProducts = this.repo.GetAllProducts() as List<Termek>;
            Termek item = listOfProducts.Find(x => x.TermekID == param.TermekID);

            if (item != null)
            {
                this.repo.DeleteProduct(item);
            }
        }

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="param"> Shop that user intend to delete. </param>
        public void DeleteShop(Aruhaz param)
        {
            List<Aruhaz> listOfShops = this.repo.GetAllShops() as List<Aruhaz>;
            Aruhaz item = listOfShops.Find(x => x.AruhazNeve.Contains(param.AruhazNeve, StringComparison.Ordinal));

            if (item != null)
            {
                this.repo.DeleteShop(item);
            }
        }

        /// <inheritdoc/>
        public bool DeleteShop(string nev)
        {
            Aruhaz shop = this.repo.GetAllShops().Where(x => x.AruhazNeve == nev).Select(x => x).FirstOrDefault();
            if (shop != null)
            {
                this.repo.DeleteShop(this.repo.GetAllShops().Where(x => x.AruhazNeve == nev).FirstOrDefault());
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method changes an existing manufacturer entity's property/properties.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to modify. </param>
        public void UpdateManufacturer(Gyarto param)
        {
            List<Gyarto> listOfManufacturers = this.GetAllManufacturers() as List<Gyarto>;
            Gyarto manufacturerFound = listOfManufacturers.Find(x => x.GyartoNeve == param.GyartoNeve);

            // If parameter is null then nothing happens.
            if (manufacturerFound != null)
            {
                this.repo.UpdateManufacturer(param);
            }
        }

        /// <summary>
        /// This method changes an existing product entity's property/properties.
        /// </summary>
        /// <param name="param"> Product that user intend to modify. </param>
        public void UpdateProduct(Termek param)
        {
            List<Termek> listOfProducts = this.GetAllProducts() as List<Termek>;
            Termek productFound = listOfProducts.Find(x => x.TermekID == param.TermekID);

            // If parameter is null then nothing happens.
            if (productFound != null)
            {
                this.repo.UpdateProduct(param);
            }
        }

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="param"> Shop that user intend to modify. </param>
        public void UpdateShop(Aruhaz param)
        {
            List<Aruhaz> listOfShops = this.GetAllShops() as List<Aruhaz>;
            Aruhaz shopFound = listOfShops.Find(x => x.AruhazNeve == param.AruhazNeve);

            // If parameter is null then nothing happens.
            if (shopFound != null)
            {
                this.repo.UpdateShop(param);
            }
        }

        /// <inheritdoc/>
        public void UpdateShop(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam)
        {
            this.repo.UpdateShop(regiNev, ujNev, email, honlap, kozpont, telefon, adoszam);
        }

        /// <inheritdoc/>
        public bool UpdateShopWeb(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam)
        {
            Aruhaz shop = this.repo.GetAllShops().Where(x => x.AruhazNeve == ujNev).Select(x => x).FirstOrDefault();
            if (shop == null || regiNev != null || ujNev != null)
            {
                this.repo.UpdateShop(regiNev, ujNev, email, honlap, kozpont, telefon, adoszam);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method lists all of products which can be found in Osan.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        public IQueryable<object> OsanProducts()
        {
            var allProductsIDInOsan = from x in this.repo.GetAllLinks()
                                      where x.AruhazNeve.Contains("Osan", StringComparison.Ordinal)
                                      select x.TermekID;

            var allOsanProducts = from x in this.repo.GetAllProducts()
                                  join y in allProductsIDInOsan on x.TermekID equals y
                                  select x;

            return allOsanProducts.AsQueryable<object>();
        }

        /// <summary>
        /// This method finds that shop where the product with the highest price can be found.
        /// </summary>
        /// <returns>A shop entity where the product with the highest price can be found.</returns>
        public IEnumerable<string> PlaceOfMostExpensiveProduct()
        {
            var products = from x in this.repo.GetAllProducts()
                           select x;

            var mostExpensiveProductID = products.OrderByDescending(price => price.Ar).FirstOrDefault();

            var thatShop = from x in this.repo.GetAllLinks()
                           where x.TermekID.Equals(mostExpensiveProductID.TermekID)
                           select x.AruhazNeve;

            return thatShop;
        }

        /// <summary>
        /// This method finds the cheapest shop.
        /// </summary>
        /// <returns>A shop entity which is the cheapest.</returns>
        public string CheapestShop()
        {
            var averagePricesOfShops = from x in this.repo.GetAllProducts()
                                       join y in this.repo.GetAllLinks()
                                       on x.TermekID equals y.TermekID
                                       join z in this.repo.GetAllShops()
                                       on y.AruhazNeve equals z.AruhazNeve
                                       group x by z.AruhazNeve into g
                                       select new
                                       {
                                           name = g.Key,
                                           averagePrice = g.Average(price => price.Ar),
                                       };

            var thatCheapestShop = averagePricesOfShops.OrderBy(x => x.averagePrice).First();

            return thatCheapestShop.name;
        }

        /// <summary>
        /// This method lists the lowest price of products.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        public Collection<Termek> TheLowestPrices()
        {
            throw new NotImplementedException();
        }
    }
}
