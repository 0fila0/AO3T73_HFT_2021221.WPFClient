﻿// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;

    /// <summary>
    /// This interface describes what methods should be implemented in Logic class.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// This method returns all manufacturer entities.
        /// </summary>
        /// <returns> A list with all manufacturer entities. </returns>
        List<Gyarto> GetAllManufacturers();

        /// <summary>
        /// This method returns all shop entities.
        /// </summary>
        /// <returns> A list with all shop entities. </returns>
        List<Aruhaz> GetAllShops();

        /// <summary>
        /// This method returns all product entities.
        /// </summary>
        /// <returns> A list with all product entities. </returns>
        List<Termek> GetAllProducts();

        /// <summary>
        /// This method returns all link entities.
        /// </summary>
        /// <returns> A list with all link entities. </returns>
        List<ID_Kapcsolo> GetAllLinks();

        /// <summary>
        /// This method adds a new shop entity to the database.
        /// </summary>
        /// <param name="param"> Shop that user intend to add. </param>
        void AddShop(Aruhaz param);

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
        void AddLink(ID_Kapcsolo param);

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="param"> Shop that user intend to modify. </param>
        void UpdateShop(Aruhaz param);

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
        void DeleteLink(ID_Kapcsolo param);

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
        Aruhaz CheapestShop();

        /// <summary>
        /// This method finds that shop where the product with the highest price can be found.
        /// </summary>
        /// <returns>A shop entity where the product with the highest price can be found.</returns>
        Aruhaz PlaceOfMostExpensiveProduct();

        /// <summary>
        /// This method lists the lowest price of products.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        List<Termek> TheLowestPrices();

        /// <summary>
        /// This method lists all of products which can be found in Osan.
        /// </summary>
        /// <returns>A list consist of products.</returns>
        List<Termek> OsanProducts();
    }
}
