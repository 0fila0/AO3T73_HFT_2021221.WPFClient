// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <inheritdoc/>
    internal class MainShopLogic : IMainShopLogic
    {
        static RestService rest;

        /// <inheritdoc/>
        public List<AruhazVM> ApiGetAruhaz()
        {
            rest = new RestService("http://localhost:54068/", "shop");
            List<AruhazVM> shops = rest.Get<AruhazVM>("shop");

            return shops;
        }

        /// <inheritdoc/>
        public void ApiDelAruhaz(AruhazVM aruhaz, ObservableCollection<AruhazVM> list)
        {
            rest.Delete(aruhaz.AruhazNeve, "shop");
            list.Remove(aruhaz);
        }

        /// <inheritdoc/>
        public void EditAruhaz(Products.Data.Models.Aruhaz aruhaz, RestCollection<Products.Data.Models.Aruhaz> list, Func<Products.Data.Models.Aruhaz, bool> editorFunc)
        {
            Products.Data.Models.Aruhaz clone = new Products.Data.Models.Aruhaz();
            string regiNev = string.Empty;
            if (aruhaz != null)
            {
                clone.Adoszam = aruhaz.Adoszam;
                clone.Kozpont = aruhaz.Kozpont;
                clone.EMail = aruhaz.EMail;
                clone.Telefon = aruhaz.Telefon;
                clone.Honlap = aruhaz.Honlap;
                regiNev = aruhaz.AruhazNeve;
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (aruhaz != null)
                {
                    rest.Put(clone, "shop");
                }
                else
                {
                    rest.Post(clone, "shop");
                }
            }
        }
    }
}
