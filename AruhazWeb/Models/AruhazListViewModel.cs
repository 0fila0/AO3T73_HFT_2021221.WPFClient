// <copyright file="AruhazListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Shop list view model.
    /// </summary>
    public class AruhazListViewModel
    {
        /// <summary>
        /// Gets or sets list of shops.
        /// </summary>
        public List<Aruhaz> ListOfAruhaz { get; set; }

        /// <summary>
        /// Gets or sets shop to be edited.
        /// </summary>
        public Aruhaz EditedAruhaz { get; set; }
    }
}
