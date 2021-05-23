// <copyright file="IMainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for MainLogic (IoC).
    /// </summary>
    public interface IMainLogic
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
        void ApiDelAruhaz(AruhazVM aruhaz);

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="aruhaz"> Edit this shop. </param>
        /// <param name="editorFunc"> Edit function. </param>
        void EditAruhaz(AruhazVM aruhaz, Func<AruhazVM, bool> editorFunc);
    }
}
