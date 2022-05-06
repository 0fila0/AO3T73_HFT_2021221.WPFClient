// <copyright file="IMainProductLogic.cs" company="PlaceholderCompany">
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
    public interface IMainProductLogic
    {
        /// <summary>
        /// Get a shop.
        /// </summary>
        /// <returns>Get this shop.</returns>
        List<TermekVM> ApiGetTermek();

        /// <summary>
        /// Delete a shop.
        /// </summary>
        /// <param name="termek">Delete this shop.</param>
        /// <param name="list">list.</param>
        void ApiDelTermek(TermekVM termek, ObservableCollection<TermekVM> list);

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="termek"> Edit this shop. </param>
        /// <param name="list">List.</param>
        /// <param name="editorFunc"> Edit function. </param>
        void EditTermek(TermekVM termek, ObservableCollection<TermekVM> list, Func<TermekVM, bool> editorFunc);
    }
}
