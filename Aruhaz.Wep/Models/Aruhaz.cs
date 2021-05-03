// <copyright file="Aruhaz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Aruhaz web model.
    /// </summary>
    public class Aruhaz
    {
        private string aruhazNeve;
        private string honlap;
        private string email;
        private decimal telefon;
        private string kozpont;
        private decimal adoszam;

        /// <summary>
        /// Gets or sets shop's name.
        /// </summary>
        [Display(Name = "Shop Name")]
        [Required]
        public string AruhazNeve
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets website.
        /// </summary>
        [Display(Name = "Shop Website")]
        [Required]
        [StringLength(50, MinimumLength = 7)]
        public string Honlap
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        [Display(Name = "Shop Email")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Email
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [Display(Name = "Shop Phone")]
        [Required]
        public decimal Telefon
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets center.
        /// </summary>
        [Display(Name = "Shop Center")]
        [Required]
        public string Kozpont
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets tax number.
        /// </summary>
        [Display(Name = "Shop Tax")]
        [Required]
        public decimal Adoszam
        {
            get; set;
        }
    }
}
