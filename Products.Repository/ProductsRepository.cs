// <copyright file="ProductsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using Products.Data.Models;

    /// <summary>
    /// This is an individual repository for database operations.
    /// </summary>
    public class ProductsRepository : IRepository
    {
        private readonly ProductsContext dataBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsRepository"/> class.
        /// </summary>
        /// <param name="productsContext"> Ancestor repository. </param>
        public ProductsRepository(ProductsContext productsContext)
        {
            this.dataBase = productsContext;
        }

        /// <summary>
        /// This method adds a new link entity to the database.
        /// </summary>
        /// <param name="param"> Link that user intend to add. </param>
        public void AddLink(IDKapcsolo param)
        {
            this.dataBase.IDKapcsolo.Add(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method adds a new manufacturer entity to the database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to add. </param>
        public void AddManufacturer(Gyarto param)
        {
            this.dataBase.Gyarto.Add(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method adds a new product entity to the database.
        /// </summary>
        /// <param name="param"> Product that user intend to add. </param>
        public void AddProduct(Termek param)
        {
            this.dataBase.Termek.Add(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method adds a new shop entity to the database.
        /// </summary>
        /// <param name="param"> Shop that user intend to add. </param>
        public void AddShop(Aruhaz param)
        {
            this.dataBase.Aruhaz.Add(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a link entity from database.
        /// </summary>
        /// <param name="param"> Link that user intend to delete. </param>
        public void DeleteLink(IDKapcsolo param)
        {
            this.dataBase.IDKapcsolo.Remove(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a manufacturer entity from database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to delete. </param>
        public void DeleteManufacturer(Gyarto param)
        {
            foreach (var item in this.dataBase.Termek)
            {
                if (param != null)
                {
                    if (item.GyartoNeve == param.GyartoNeve)
                    {
                        item.GyartoNeve = null;    // ON DELETE SET NULL  ON UPDATE CASCADE
                    }
                }
            }

            this.dataBase.Gyarto.Remove(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a product entity from database.
        /// </summary>
        /// <param name="param"> Product that user intend to delete. </param>
        public void DeleteProduct(Termek param)
        {
            this.dataBase.Termek.Remove(param);
            var removeLink = from remove in this.dataBase.IDKapcsolo
                             where remove.TermekID == param.TermekID
                             select remove;
            this.dataBase.IDKapcsolo.RemoveRange(removeLink);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="param"> Shop that user intend to delete. </param>
        public void DeleteShop(Aruhaz param)
        {
            this.dataBase.Aruhaz.Remove(param);
            var removeLink = from remove in this.dataBase.IDKapcsolo
                             where remove.AruhazNeve == param.AruhazNeve
                             select remove;
            this.dataBase.IDKapcsolo.RemoveRange(removeLink);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method returns all link entities.
        /// </summary>
        /// <returns> A list with all link entities. </returns>
        public IEnumerable<IDKapcsolo> GetAllLinks()
        {
            List<IDKapcsolo> listOfLinks = new ();
            foreach (var item in this.dataBase.IDKapcsolo)
            {
                listOfLinks.Add(item);
            }

            return listOfLinks;
        }

        /// <summary>
        /// This method returns all manufacturer entities.
        /// </summary>
        /// <returns> A list with all manufacturer entities. </returns>
        public IEnumerable<Gyarto> GetAllManufacturers()
        {
            List<Gyarto> listOfManufacturers = new List<Gyarto>();
            foreach (var item in this.dataBase.Gyarto)
            {
                listOfManufacturers.Add(item);
            }

            return listOfManufacturers;
        }

        /// <summary>
        /// This method returns all product entities.
        /// </summary>
        /// <returns> A list with all product entities. </returns>
        public IEnumerable<Termek> GetAllProducts()
        {
            List<Termek> listOfProducts = new List<Termek>();
            foreach (var item in this.dataBase.Termek)
            {
                listOfProducts.Add(item);
            }

            return listOfProducts;
        }

        /// <summary>
        /// This method returns all shop entities.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        public IEnumerable<Aruhaz> GetAllShops()
        {
            List<Aruhaz> listOfShops = new List<Aruhaz>();
            foreach (var item in this.dataBase.Aruhaz)
            {
                listOfShops.Add(item);
            }

            return listOfShops;
        }

        /// <summary>
        /// This method changes an existing manufacturer entity's property/properties.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to modify. </param>
        public void UpdateManufacturer(Gyarto param)
        {
            if (param != null)
            {
                Gyarto updateThisManufacturer = this.dataBase.Gyarto.Single(x => x.GyartoNeve == param.GyartoNeve);
                updateThisManufacturer.EMail = param.EMail;
                updateThisManufacturer.Adoszam = param.Adoszam;
                updateThisManufacturer.Honlap = param.Honlap;
                updateThisManufacturer.Kozpont = param.Kozpont;
                updateThisManufacturer.Telefon = param.Telefon;
                this.dataBase.SaveChanges();
            }
        }

        /// <summary>
        /// This method changes an existing product entity's property/properties.
        /// </summary>
        /// <param name="param"> Product that user intend to modify. </param>
        public void UpdateProduct(Termek param)
        {
            if (param != null)
            {
                Termek updateThisProduct = this.dataBase.Termek.Single(x => x.TermekID == param.TermekID);
                updateThisProduct.Ar = param.Ar;
                updateThisProduct.Kiszereles = param.Kiszereles;
                updateThisProduct.Megnevezes = param.Megnevezes;
                updateThisProduct.Tipus = param.Tipus;
                updateThisProduct.Leiras = param.Leiras;
                this.dataBase.SaveChanges();
            }
        }

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="param"> Shop that user intend to modify. </param>
        public void UpdateShop(Aruhaz param)
        {
            if (param != null)
            {
                Aruhaz updateThisShop = this.dataBase.Aruhaz.Where(x => x.AruhazNeve == param.AruhazNeve).FirstOrDefault();
                updateThisShop.AruhazNeve = param.AruhazNeve;
                updateThisShop.EMail = param.EMail;
                updateThisShop.Adoszam = param.Adoszam;
                updateThisShop.Honlap = param.Honlap;
                updateThisShop.Kozpont = param.Kozpont;
                updateThisShop.Telefon = param.Telefon;
                updateThisShop.Kijelolt = param.Kijelolt;
                this.dataBase.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void UpdateShop(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam, bool kijelolt)
        {
            Aruhaz updateThisShop = this.dataBase.Aruhaz.FirstOrDefault(x => x.AruhazNeve == regiNev);
            this.DeleteShop(updateThisShop);
            updateThisShop.AruhazNeve = ujNev;
            updateThisShop.EMail = email;
            updateThisShop.Adoszam = adoszam;
            updateThisShop.Honlap = honlap;
            updateThisShop.Kozpont = kozpont;
            updateThisShop.Telefon = telefon;
            updateThisShop.Kijelolt = kijelolt;
            this.AddShop(updateThisShop);
            this.dataBase.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateManufacturer(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam)
        {
            Gyarto updateThisManufacturer = this.dataBase.Gyarto.FirstOrDefault(x => x.GyartoNeve == regiNev);
            this.DeleteManufacturer(updateThisManufacturer);
            updateThisManufacturer.GyartoNeve = ujNev;
            updateThisManufacturer.EMail = email;
            updateThisManufacturer.Adoszam = adoszam;
            updateThisManufacturer.Honlap = honlap;
            updateThisManufacturer.Kozpont = kozpont;
            updateThisManufacturer.Telefon = telefon;
            this.AddManufacturer(updateThisManufacturer);
            this.dataBase.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateProduct(decimal regiId, decimal ujId, string tipus, string megnevezes, string kiszereles, decimal ar, string leiras)
        {
            Termek updateThisProduct = this.dataBase.Termek.FirstOrDefault(x => x.TermekID == regiId);
            this.DeleteProduct(updateThisProduct);
            updateThisProduct.TermekID = ujId;
            updateThisProduct.Tipus = tipus;
            updateThisProduct.Megnevezes = megnevezes;
            updateThisProduct.Kiszereles = kiszereles;
            updateThisProduct.Ar = ar;
            updateThisProduct.Leiras = leiras;
            this.AddProduct(updateThisProduct);
            this.dataBase.SaveChanges();
        }
    }
}
