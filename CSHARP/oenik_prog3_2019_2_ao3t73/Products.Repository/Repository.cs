﻿// <copyright file="Repository.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// This is an individual repository for database operations.
    /// </summary>
    public class Repository : IRepository
    {
        private ProductsServiceBasedDBEntities dataBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        public Repository()
        {
            this.dataBase = new ProductsServiceBasedDBEntities();
        }

        /// <summary>
        /// This method adds a new link entity to the database.
        /// </summary>
        /// <param name="param"> Link that user intend to add. </param>
        public void AddLink(ID_Kapcsolo param)
        {
            this.dataBase.ID_Kapcsolo.Add(param);
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
        public void DeleteLink(ID_Kapcsolo param)
        {
            this.dataBase.ID_Kapcsolo.Remove(param);
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a manufacturer entity from database.
        /// </summary>
        /// <param name="param"> Manufacturer that user intend to delete. </param>
        public void DeleteManufacturer(Gyarto param)
        {
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
            this.dataBase.SaveChanges();
        }

        /// <summary>
        /// This method deletes a shop entity from database.
        /// </summary>
        /// <param name="param"> Shop that user intend to delete. </param>
        public void DeleteShop(Aruhaz param)
        {
            this.dataBase.Aruhaz.Remove(param);
            this.dataBase.SaveChanges();
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
        public List<Termek> GetAllProducts()
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
        public List<Aruhaz> GetAllShops()
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
            var old = this.dataBase.Gyarto.SingleOrDefault(x => x.Gyarto_neve == param.Gyarto_neve);
            if (old != null)
            {
                foreach (PropertyInfo newProp in param.GetType().GetProperties())
                {
                    if (newProp.GetValue(param) != null && newProp.GetValue(param) != newProp.GetValue(old))
                    {
                        newProp.SetValue(old, newProp.GetValue(param));
                        this.dataBase.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// This method changes an existing product entity's property/properties.
        /// </summary>
        /// <param name="param"> Product that user intend to modify. </param>
        public void UpdateProduct(Termek param)
        {
            var old = this.dataBase.Termek.SingleOrDefault(x => x.Termek_ID == param.Termek_ID);
            if (old != null)
            {
                foreach (PropertyInfo newProp in param.GetType().GetProperties())
                {
                    if (newProp.GetValue(param) != null && newProp.GetValue(param) != newProp.GetValue(old))
                    {
                        newProp.SetValue(old, newProp.GetValue(param));
                        this.dataBase.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// This method changes an existing shop entity's property/properties.
        /// </summary>
        /// <param name="param"> Shop that user intend to modify. </param>
        public void UpdateShop(Aruhaz param)
        {
            var old = this.dataBase.Aruhaz.SingleOrDefault(x => x.Aruhaz_neve == param.Aruhaz_neve);
            if (old != null)
            {
                foreach (PropertyInfo newProp in param.GetType().GetProperties())
                {
                    if (newProp.GetValue(param) != null && newProp.GetValue(param) != newProp.GetValue(old))
                    {
                        newProp.SetValue(old, newProp.GetValue(param));
                        this.dataBase.SaveChanges();
                    }
                }
            }
        }
    }
}
