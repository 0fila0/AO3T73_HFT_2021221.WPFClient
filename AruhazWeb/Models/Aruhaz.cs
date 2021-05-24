// <copyright file="Aruhaz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    /// <summary>
    /// Aruhaz web model.
    /// </summary>
    public class Aruhaz
    {
        /// <summary>
        /// Gets or sets shop's name.
        /// </summary>
        [Display(Name = "Áruház neve")]
        [Required]
        public string AruhazNeve
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shop's old name.
        /// </summary>
        [JsonIgnore]
        public string RegiNev
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets website.
        /// </summary>
        [Display(Name = "Weboldal")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Honlap
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        [Display(Name = "E-mail címe")]
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Email
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [Display(Name = "Telefonszám")]
        [Required]
        public string Telefon
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets center.
        /// </summary>
        [Display(Name = "Központ")]
        [Required]
        public string Kozpont
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets tax number.
        /// </summary>
        [Display(Name = "Adószám")]
        [Required]
        public string Adoszam
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether selected.
        /// </summary>
        [Display(Name = "Kijelölt")]
        [Required]
        public bool Kijelolt
        {
            get; set;
        }
    }
}
