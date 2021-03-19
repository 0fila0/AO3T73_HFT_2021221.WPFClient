// <copyright file="Aruhaz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// GUI's data entity.
    /// </summary>
    public class Aruhaz : ObservableObject
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
        public string AruhazNeve
        {
            get { return this.aruhazNeve; }
            set { this.Set(ref this.aruhazNeve, value); }
        }

        /// <summary>
        /// Gets or sets website.
        /// </summary>
        public string Honlap
        {
            get { return this.honlap; }
            set { this.Set(ref this.honlap, value); }
        }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        public string Email
        {
            get { return this.email; }
            set { this.Set(ref this.email, value); }
        }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public decimal Telefon
        {
            get { return this.telefon; }
            set { this.Set(ref this.telefon, value); }
        }

        /// <summary>
        /// Gets or sets center.
        /// </summary>
        public string Kozpont
        {
            get { return this.kozpont; }
            set { this.Set(ref this.kozpont, value); }
        }

        /// <summary>
        /// Gets or sets tax number.
        /// </summary>
        public decimal Adoszam
        {
            get { return this.adoszam; }
            set { this.Set(ref this.adoszam, value); }
        }

        /// <summary>
        /// Cloning a shop in order to modify.
        /// </summary>
        /// <param name="other"> Shop that will be cloned. </param>
        public void CopyFrom(Aruhaz other)
        {
            this.GetType().GetProperties().ToList().ForEach(prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
