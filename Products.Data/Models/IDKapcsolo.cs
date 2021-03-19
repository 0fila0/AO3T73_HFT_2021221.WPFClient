// <copyright file="IDKapcsolo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable

namespace Products.Data.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// ID connection entity class.
    /// </summary>
    public partial class IDKapcsolo
    {
        /// <summary>
        /// Gets or sets connection.
        /// </summary>
        public decimal KapcsoloId { get; set; }

        /// <summary>
        /// Gets or sets connection's product's ID.
        /// </summary>
        public decimal TermekID { get; set; }

        /// <summary>
        /// Gets or sets connection's shop's name.
        /// </summary>
        public string AruhazNeve { get; set; }

        /// <summary>
        /// Gets or sets connection's shop's name for navigation.
        /// </summary>
        public virtual Aruhaz AruhazNeveNavigation { get; set; }

        /// <summary>
        /// Gets or sets connection's product.
        /// </summary>
        public virtual Termek Termek { get; set; }
    }
}
