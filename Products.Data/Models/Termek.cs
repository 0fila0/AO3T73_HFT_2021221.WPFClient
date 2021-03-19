// <copyright file="Termek.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace Products.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Product entity class.
    /// </summary>
    public partial class Termek
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Termek"/> class.
        /// </summary>
        public Termek()
        {
            this.IDKapcsolo = new HashSet<IDKapcsolo>();
        }

        /// <summary>
        /// Gets or sets product's ID.
        /// </summary>
        public decimal TermekID { get; set; }

        /// <summary>
        /// Gets or sets product's type.
        /// </summary>
        public string Tipus { get; set; }

        /// <summary>
        /// Gets or sets product's name.
        /// </summary>
        public string Megnevezes { get; set; }

        /// <summary>
        /// Gets or sets product's packaging.
        /// </summary>
        public string Kiszereles { get; set; }

        /// <summary>
        /// Gets or sets product's price.
        /// </summary>
        public decimal? Ar { get; set; }

        /// <summary>
        /// Gets or sets product's description.
        /// </summary>
        public string Leiras { get; set; }

        /// <summary>
        /// Gets or sets product's manufactuter's name.
        /// </summary>
        public string GyartoNeve { get; set; }

        /// <summary>
        /// Gets or sets product's manufacturer's name for navigation.
        /// </summary>
        public virtual Gyarto GyartoNeveNavigation { get; set; }

        /// <summary>
        /// Gets product's ID connection.
        /// </summary>
        public virtual ICollection<IDKapcsolo> IDKapcsolo { get; }
    }
}
