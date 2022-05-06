namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Products viewmodel.
    /// </summary>
    public class TermekVM : ObservableObject
    {
        private decimal termekId;
        private string tipus;
        private string megnevezes;
        private string kiszereles;
        private decimal ar;
        private string leiras;

        /// <summary>
        /// Gets or sets shop's name.
        /// </summary>
        public decimal TermekID
        {
            get { return this.termekId; }
            set { this.Set(ref this.termekId, value); }
        }

        /// <summary>
        /// Gets or sets website.
        /// </summary>
        public string Tipus
        {
            get { return this.tipus; }
            set { this.Set(ref this.tipus, value); }
        }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        public string Megnevezes
        {
            get { return this.megnevezes; }
            set { this.Set(ref this.megnevezes, value); }
        }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string Kiszereles
        {
            get { return this.kiszereles; }
            set { this.Set(ref this.kiszereles, value); }
        }

        /// <summary>
        /// Gets or sets center.
        /// </summary>
        public decimal Ar
        {
            get { return this.ar; }
            set { this.Set(ref this.ar, value); }
        }

        /// <summary>
        /// Gets or sets tax number.
        /// </summary>
        public string Leiras
        {
            get { return this.leiras; }
            set { this.Set(ref this.leiras, value); }
        }

        /// <summary>
        /// Cloning a shop in order to modify.
        /// </summary>
        /// <param name="other"> Shop that will be cloned. </param>
        public void CopyFrom(TermekVM other)
        {
            if (other == null)
            {
                return;
            }

            this.TermekID = other.TermekID;
            this.Megnevezes = other.Megnevezes;
            this.Leiras = other.Leiras;
            this.Tipus = other.Tipus;
            this.Kiszereles = other.Kiszereles;
            this.Ar = other.Ar;

            // this.GetType().GetProperties().ToList().ForEach(prop => prop.SetValue(this, prop.GetValue(other)));
        }
    }
}
