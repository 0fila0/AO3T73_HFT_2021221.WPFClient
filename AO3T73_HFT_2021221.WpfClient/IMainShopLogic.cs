// <copyright file="IMainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for MainLogic (IoC).
    /// </summary>
    public interface IMainShopLogic
    {
        /// <summary>
        /// Get a shop.
        /// </summary>
        /// <returns>Get this shop.</returns>
        List<AruhazVM> ApiGetAruhaz();

        /// <summary>
        /// Delete a shop.
        /// </summary>
        /// <param name="aruhaz">Delete this shop.</param>
        /// <param name="list">list.</param>
        void ApiDelAruhaz(AruhazVM aruhaz, ObservableCollection<AruhazVM> list);

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="aruhaz"> Edit this shop. </param>
        /// <param name="list">List.</param>
        /// <param name="editorFunc"> Edit function. </param>
        void EditAruhaz(Products.Data.Models.Aruhaz aruhaz, RestCollection<Products.Data.Models.Aruhaz> list, Func<Products.Data.Models.Aruhaz, bool> editorFunc);
    }
}
