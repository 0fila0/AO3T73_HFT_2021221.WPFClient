// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using Products.Data.Models;

    /// <summary>
    /// This interface describes what methods should be implemented in Logic class.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// This method returns all manufacturer entities.
        /// </summary>
        /// <returns> A list with all manufacturer entities. </returns>
        IEnumerable<Gyarto> GetAllManufacturers();

        /// <summary>
        /// This method returns all shop entities.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        IEnumerable<Aruhaz> GetAllShops();

        /// <summary>
        /// This method returns all product entities.
        /// </summary>
        /// <returns> A list with all product entities. </returns>
        IEnumerable<Termek> GetAllProducts();

        /// <summary>
        /// This method returns all link entities.
        /// </summary>
        /// <returns> A list with all link entities. </returns>
        IEnumerable<IDKapcsolo> GetAllLinks();

        /// <summary>
        /// This method adds a new shop entity to the database.
        /// </summary>
        /// <param name="param"> Shop that user intend to add. </param>
        void AddShop(Aruhaz param);

        /// <summary>
        /// This method adds a new shop entity to the database.
        /// </summary>
        /// <param name="nev"> Shop's name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        /// <param name="kijelolt"> Shop is selected or not. </param>
        public void AddShop(string nev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam, bool kijelolt);

        /// <summary>
        /// This method adds a new manufacturer entity to the database.
        /// </summary>
        /// <param name="nev"> Shop's name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        public void AddManufacturer(string nev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam);

        /// <summary>
        /// This method adds a new product entity to the database.
        /// </summary>
        /// <param name="id"> Shop's new name. </param>
        /// <param name="tipus"> Shop's email address. </param>
        /// <param name="megnevezes"> Shop's website. </param>
        /// <param name="kiszereles"> Shop's center. </param>
        /// <param name="ar"> Shop's phone number. </param>
        /// <param name="leiras"> Shop's tax number. </param>
        public void AddProduct(decimal id, string tipus, string megnevezes, string kiszereles, decimal ar, string leiras);

        /// <summary>
        /// This method adds a new product entity to the database.
        /// </summary>
        /// <param name="param"> Product that user intend to add. </param>
        void AddProduct(Termek param);

        /// <summary>
        /// This method adds a new manufacturer entity to the database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to add. </param>
        void AddManufacturer(Gyarto param);

        /// <summary>
        /// This method adds a new link entity to the database.
        /// </summary>
        /// <param name="param"> Link that user intend to add. </param>
        void AddLink(IDKapcsolo param);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="param"> Shop that user intend to modify. </param>
        void UpdateShop(Aruhaz param);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="regiNev"> Shop's old name. </param>
        /// <param name="ujNev"> Shop's new name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        /// <param name="kijelolt"> Shop is selected or not. </param>
        void UpdateShop(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam, bool kijelolt);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="regiNev"> Shop's old name. </param>
        /// <param name="ujNev"> Shop's new name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        void UpdateManufacturer(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam);

        /// <summary>
        /// Update the database.
        /// </summary>
        /// <param name="regiId"> Shop's older name. </param>
        /// <param name="ujId"> Shop's new name. </param>
        /// <param name="tipus"> Shop's email address. </param>
        /// <param name="megnevezes"> Shop's website. </param>
        /// <param name="kiszereles"> Shop's center. </param>
        /// <param name="ar"> Shop's phone number. </param>
        /// <param name="leiras"> Shop's tax number. </param>
        void UpdateProduct(decimal regiId, decimal ujId, string tipus, string megnevezes, string kiszereles, decimal ar, string leiras);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="regiNev"> Shop's old name. </param>
        /// <param name="ujNev"> Shop's new name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        /// <param name="kijelolt"> Shop is selected or not. </param>
        /// <returns> False if update failed. </returns>
        bool UpdateShopWeb(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam, bool kijelolt);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="regiNev"> Shop's old name. </param>
        /// <param name="ujNev"> Shop's new name. </param>
        /// <param name="email"> Shop's email address. </param>
        /// <param name="honlap"> Shop's website. </param>
        /// <param name="kozpont"> Shop's center. </param>
        /// <param name="telefon"> Shop's phone number. </param>
        /// <param name="adoszam"> Shop's tax number. </param>
        /// <returns> False if update failed. </returns>
        bool UpdateManufacturerWeb(string regiNev, string ujNev, string email, string honlap, string kozpont, decimal telefon, decimal adoszam);

        /// <summary>
        /// Update the database.
        /// </summary>
        /// <param name="regiId"> Shop's older name. </param>
        /// <param name="ujId"> Shop's new name. </param>
        /// <param name="tipus"> Shop's email address. </param>
        /// <param name="megnevezes"> Shop's website. </param>
        /// <param name="kiszereles"> Shop's center. </param>
        /// <param name="ar"> Shop's phone number. </param>
        /// <param name="leiras"> Shop's tax number. </param>
        /// <returns> False if update failed. </returns>
        bool UpdateProductWeb(decimal regiId, decimal ujId, string tipus, string megnevezes, string kiszereles, decimal ar, string leiras);

        /// <summary>
        /// This method changes an existing product entity's property/properties.
        /// </summary>
        /// <param name="param"> Product that user intend to modify. </param>
        void UpdateProduct(Termek param);

        /// <summary>
        /// This method changes an existing manufacturer entity's property/properties.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to modify. </param>
        void UpdateManufacturer(Gyarto param);

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="param"> Shop that user intend to delete. </param>
        void DeleteShop(Aruhaz param);

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="nev"> Shop's name user intend to delete. </param>
        /// <returns> True if deleted happened. </returns>
        bool DeleteShop(string nev);

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="nev"> Shop's name user intend to delete. </param>
        /// <returns> True if deleted happened. </returns>
        bool DeleteManufacturer(string nev);

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="id"> Shop's name user intend to delete. </param>
        /// <returns> True if deleted happened. </returns>
        bool DeleteProduct(int id);

        /// <summary>
        /// This method deletes a product entity from database.
        /// </summary>
        /// <param name="param"> Product that user intend to delete. </param>
        void DeleteProduct(Termek param);

        /// <summary>
        /// This method deletes a manufacturer entity from database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to delete. </param>
        void DeleteManufacturer(Gyarto param);

        /// <summary>
        /// This method deletes a link entity from database.
        /// </summary>
        /// <param name="param"> Link that user intend to delete. </param>
        void DeleteLink(IDKapcsolo param);

        /*
           Legolcsóbb áruház
           Legdrágább termékek helye
           Ugyanazon termékek elérhetősége a legkisebb áron
           Osan áruház termékei
        */

        /// <summary>
        /// This method finds the cheapest shop.
        /// </summary>
        /// <returns>A shop entity which is the cheapest.</returns>
        string CheapestShop();

        /// <summary>
        /// This method finds that shop where the product with the highest price can be found.
        /// </summary>
        /// <returns>A shop entity where the product with the highest price can be found.</returns>
        IEnumerable<string> PlaceOfMostExpensiveProduct();

        /// <summary>
        /// This method lists the lowest price of products.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        Collection<Termek> TheLowestPrices();

        /// <summary>
        /// This method lists all of products which can be found in Osan.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        IQueryable<object> OsanProducts();

        /// <summary>
        /// This method returns one shop entity.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        /// <param name="id"> Shop's id. </param>
        public Aruhaz GetOneShop(string id);

        /// <summary>
        /// This method returns one shop entity.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        /// <param name="id"> Shop's id. </param>
        public Gyarto GetOneManufacturer(string id);

        /// <summary>
        /// This method returns one shop entity.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        /// <param name="id"> Shop's id. </param>
        public Termek GetOneProduct(string id);
    }
}
