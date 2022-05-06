namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Gyaro viewmodel.
    /// </summary>
    public class GyartoVM : ObservableObject
    {
        private string gyartoNeve;
        private string honlap;
        private string email;
        private decimal telefon;
        private string kozpont;
        private decimal adoszam;

        /// <summary>
        /// Gets or sets shop's name.
        /// </summary>
        public string GyartoNeve
        {
            get { return this.gyartoNeve; }
            set { this.Set(ref this.gyartoNeve, value); }
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
        public void CopyFrom(GyartoVM other)
        {
            if (other == null)
            {
                return;
            }

            this.GyartoNeve = other.GyartoNeve;
            this.Email = other.Email;
            this.Adoszam = other.Adoszam;
            this.Honlap = other.Honlap;
            this.Telefon = other.Telefon;
            this.Kozpont = other.Kozpont;

            // this.GetType().GetProperties().ToList().ForEach(prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
