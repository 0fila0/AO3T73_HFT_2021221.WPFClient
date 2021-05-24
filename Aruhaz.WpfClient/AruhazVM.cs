// <copyright file="AruhazVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// View model class.
    /// </summary>
    public class AruhazVM : ObservableObject
    {
        private string aruhazNeve;
        private string honlap;
        private string email;
        private decimal telefon;
        private string kozpont;
        private decimal adoszam;
        private bool kijelolt;

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
        /// Gets or sets a value indicating whether selected.
        /// </summary>
        public bool Kijelolt
        {
            get { return this.kijelolt; }
            set { this.Set(ref this.kijelolt, value); }
        }

        /// <summary>
        /// Cloning a shop in order to modify.
        /// </summary>
        /// <param name="other"> Shop that will be cloned. </param>
        public void CopyFrom(AruhazVM other)
        {
            if (other == null)
            {
                return;
            }

            this.AruhazNeve = other.AruhazNeve;
            this.Email = other.Email;
            this.Adoszam = other.Adoszam;
            this.Honlap = other.Honlap;
            this.Telefon = other.Telefon;
            this.Kozpont = other.Kozpont;
            this.Kijelolt = other.Kijelolt;

            // this.GetType().GetProperties().ToList().ForEach(prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
