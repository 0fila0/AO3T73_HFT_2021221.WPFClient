// <copyright file="Aruhaz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace Products.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Auto generated entity class for Aruhaz.
    /// </summary>
    public partial class Aruhaz
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aruhaz"/> class.
        /// </summary>
        public Aruhaz()
        {
            this.IdKapcsolos = new HashSet<IDKapcsolo>();
        }

        /// <summary>
        /// Gets or sets AruhazNeve.
        /// </summary>
        public string AruhazNeve { get; set; }

        /// <summary>
        /// Gets or sets Honlap.
        /// </summary>
        public string Honlap { get; set; }

        /// <summary>
        /// Gets or sets EMail.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets Telefon.
        /// </summary>
        public decimal? Telefon { get; set; }

        /// <summary>
        /// Gets or sets Kozpont.
        /// </summary>
        public string Kozpont { get; set; }

        /// <summary>
        /// Gets or sets Adoszam.
        /// </summary>
        public decimal Adoszam { get; set; }

        /// <summary>
        /// Gets IdKapcsolos.
        /// </summary>
        public virtual ICollection<IDKapcsolo> IdKapcsolos { get; }
    }
}
