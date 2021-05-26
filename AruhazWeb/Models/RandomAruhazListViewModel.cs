// <copyright file="RandomAruhazListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Shop list view model.
    /// </summary>
    public class RandomAruhazListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomAruhazListViewModel"/> class.
        /// </summary>
        /// <param name="selectedShops"> Selected shops list. </param>
        /// <param name="unselectedShops"> Unselected shops list. </param>
        public RandomAruhazListViewModel(ICollection<Aruhaz> selectedShops, ICollection<Aruhaz> unselectedShops)
        {
            this.SelectedShops = selectedShops;
            this.UnselectedShops = unselectedShops;
        }

        /// <summary>
        /// Gets SelectedShops.
        /// </summary>
        public ICollection<Aruhaz> SelectedShops { get; }

        /// <summary>
        /// Gets UnselectedShops.
        /// </summary>
        public ICollection<Aruhaz> UnselectedShops { get; }
    }
}
