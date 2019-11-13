// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;

    /// <summary>
    /// This interface describes what methods should be implemented in Repository class.
    /// </summary>
    public interface IRepository
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
        /// This method changes an existing link entity's property/properties.
        /// </summary>
        /// <param name="param"> Link that user intend to modify. </param>
        void UpdateLink(ID_Kapcsolo param);

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

        /// <summary>
        /// This method displays that shop's details, if it exists, which has been entered by user.
        /// </summary>
        /// <param name="key_param"> Shop that user's looking for. </param>
        /// <returns> The shop that user looked for. </returns>
        Aruhaz FindShop(string key_param);

        /// <summary>
        /// This method displays that product's details, if it exists, which has been entered by user.
        /// </summary>
        /// <param name="key_param"> Product that user's looking for. </param>
        /// <returns> The product that user looked for. </returns>
        Termek FindProduct(string key_param);

        /// <summary>
        /// This method displays that manufacturer's details, if it exists, which has been entered by user.
        /// </summary>
        /// <param name="key_param"> Manufacturer that user's looking for. </param>
        /// <returns> The manufacturer that user looked for. </returns>
        Gyarto FindManufaceturer(string key_param);

        /// <summary>
        /// This method displays that link's details, if it exists, which has been entered by user.
        /// </summary>
        /// <param name="key_param"> Link that user's looking for. </param>
        /// <returns> The link that user looked for. </returns>
        ID_Kapcsolo FindLink(string key_param);
    }
}
