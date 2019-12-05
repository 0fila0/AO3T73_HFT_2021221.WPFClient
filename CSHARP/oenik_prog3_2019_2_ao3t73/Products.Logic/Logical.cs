// <copyright file="Logical.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using Products.Repository;

    /// <summary>
    /// This interface describes what methods should be implemented in Logic class.
    /// </summary>
    public class Logical : ILogic
    {

        private IRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logical"/> class.
        /// </summary>
        /// <param name="repo">Repository parameter.</param>
        public Logical(IRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// This method adds a new link entity to the database.
        /// </summary>
        /// <param name="param"> Link that user intend to add. </param>
        public void AddLink(ID_Kapcsolo param)
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

        /// <summary>
        /// This method finds the cheapest shop.
        /// </summary>
        /// <returns>A shop entity which is the cheapest.</returns>
        public Aruhaz CheapestShop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method deletes a link entity from database.
        /// </summary>
        /// <param name="param"> Link that user intend to delete. </param>
        public void DeleteLink(ID_Kapcsolo param)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method deletes a manufacturer entity from database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to delete. </param>
        public void DeleteManufacturer(Gyarto param)
        {
            List<Gyarto> listOfManufacturers = this.repo.GetAllManufacturers();
            Gyarto item = listOfManufacturers.Find(x => x.Gyarto_neve.Contains(param.Gyarto_neve));

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
            List<Termek> listOfProducts = this.repo.GetAllProducts();
            Termek item = listOfProducts.Find(x => x.Termek_ID == param.Termek_ID);

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
            List<Aruhaz> listOfShops = this.repo.GetAllShops();
            Aruhaz item = listOfShops.Find(x => x.Aruhaz_neve.Contains(param.Aruhaz_neve));

            if (item != null)
            {
                this.repo.DeleteShop(item);
            }
        }

        /// <summary>
        /// This method returns all link entities.
        /// </summary>
        /// <returns> A list with all link entities. </returns>
        public List<ID_Kapcsolo> GetAllLinks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method returns all manufacturer entities.
        /// </summary>
        /// <returns> A list with all manufacturer entities. </returns>
        public List<Gyarto> GetAllManufacturers()
        {
            List<Gyarto> listOfManufacturers = this.repo.GetAllManufacturers();
            return listOfManufacturers;
        }

        /// <summary>
        /// This method returns all product entities.
        /// </summary>
        /// <returns> A list with all product entities. </returns>
        public List<Termek> GetAllProducts()
        {
            List<Termek> listOfProducts = this.repo.GetAllProducts();
            return listOfProducts;
        }

        /// <summary>
        /// This method returns all shop entities.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        public List<Aruhaz> GetAllShops()
        {
            List<Aruhaz> listOfShops = this.repo.GetAllShops();
            return listOfShops;
        }

        /// <summary>
        /// This method lists all of products which can be found in Osan.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        public List<Termek> OsanProducts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method finds that shop where the product with the highest price can be found.
        /// </summary>
        /// <returns>A shop entity where the product with the highest price can be found.</returns>
        public Aruhaz PlaceOfMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method lists the lowest price of products.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        public List<Termek> TheLowestPrices()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method changes an existing manufacturer entity's property/properties.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to modify. </param>
        public void UpdateManufacturer(Gyarto param)
        {
            List<Gyarto> listOfManufacturers = this.GetAllManufacturers();
            Gyarto manufacturerFound = listOfManufacturers.Find(x => x.Gyarto_neve == param.Gyarto_neve);

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
            List<Termek> listOfProducts = this.GetAllProducts();
            Termek productFound = listOfProducts.Find(x => x.Termek_ID == param.Termek_ID);

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
            List<Aruhaz> listOfShops = this.GetAllShops();
            Aruhaz shopFound = listOfShops.Find(x => x.Aruhaz_neve == param.Aruhaz_neve);

            // If parameter is null then nothing happens.
            if (shopFound != null)
            {
                this.repo.UpdateShop(param);
            }
        }
    }
}
