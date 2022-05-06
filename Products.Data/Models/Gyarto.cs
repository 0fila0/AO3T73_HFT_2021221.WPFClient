// <copyright file="Gyarto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace Products.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Manufacturer entity class.
    /// </summary>
    public partial class Gyarto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gyarto"/> class.
        /// </summary>
        public Gyarto()
        {
            this.Termek = new HashSet<Termek>();
        }

        /// <summary>
        /// Gets or sets manufacturer's name.
        /// </summary>
        public string GyartoNeve { get; set; }

        /// <summary>
        /// Gets or sets manufacturer's website.
        /// </summary>
        public string Honlap { get; set; }

        /// <summary>
        /// Gets or sets manufacturer's email address.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets manufacturer's phone number.
        /// </summary>
        public decimal? Telefon { get; set; }

        /// <summary>
        /// Gets or sets manufacturer's center.
        /// </summary>
        public string Kozpont { get; set; }

        /// <summary>
        /// Gets or sets manufacturer's tax number.
        /// </summary>
        public decimal Adoszam { get; set; }

        /// <summary>
        /// Gets manufacturer's products.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Termek> Termek { get; }
    }
}
