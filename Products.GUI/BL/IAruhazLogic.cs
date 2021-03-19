// <copyright file="IAruhazLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.GUI.Data;

    /// <summary>
    /// GUI's logic interface.
    /// </summary>
    internal interface IAruhazLogic
    {
        /// <summary>
        /// Add a shop to database.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        void AddAruhaz(IList<Aruhaz> list);

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="aruhazToModify"> Should be edited. </param>
        void ModAruhaz(Aruhaz aruhazToModify);

        /// <summary>
        /// Delete a shop from database.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        /// <param name="aruhaz"> Should be deleted. </param>
        void DelAruhaz(IList<Aruhaz> list, Aruhaz aruhaz);

        /// <summary>
        /// Gets all shops from database.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        void GetAllAruhaz(IList<Aruhaz> list);

        // Szinkronizálás: UI és DB.
    }
}
