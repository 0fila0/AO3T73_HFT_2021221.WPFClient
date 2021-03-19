// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using Products.GUI.Data;

    /// <summary>
    /// asd.
    /// </summary>
    internal class EditorViewModel : ViewModelBase
    {
        private Aruhaz aruhaz;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.aruhaz = new Aruhaz();
            if (this.IsInDesignMode)
            {
                this.aruhaz.AruhazNeve = "új áruház";
                this.aruhaz.Email = "új e-mail";
                this.aruhaz.Honlap = "új honlap";
                this.aruhaz.Kozpont = "új központ";
                this.aruhaz.Adoszam = 0011223344;
                this.aruhaz.Telefon = 0620307090;
            }
        }

        /// <summary>
        /// Gets or sets Shop entity.
        /// </summary>
        public Aruhaz Aruhaz
        {
            get { return this.aruhaz; }
            set { this.Set(ref this.aruhaz, value); }
        }
    }
}
