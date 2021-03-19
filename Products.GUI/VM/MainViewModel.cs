// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.VM
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Products.GUI.BL;
    using Products.GUI.Data;

    /// <summary>
    /// MainViewModel class.
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        private IAruhazLogic logic;
        private Aruhaz aruhazSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="logic"> An ILogic parameter. </param>
        public MainViewModel(IAruhazLogic logic)
        {
            this.logic = logic;
            this.Aruhazak = new ObservableCollection<Aruhaz>();

            if (this.IsInDesignMode)
            {
                Aruhaz a = new Aruhaz() { Adoszam = 123123123, AruhazNeve = "áruház", Email = "kukacok", Honlap = "www.asd.hu", Kozpont = "központ", Telefon = 061703020 };
                this.Aruhazak.Add(a);
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddAruhaz(this.Aruhazak));
            this.ModCmd = new RelayCommand(() => this.logic.ModAruhaz(this.AruhazSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DelAruhaz(this.Aruhazak, this.AruhazSelected));
            this.ShowCmd = new RelayCommand(() => this.logic.GetAllAruhaz(this.Aruhazak));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IAruhazLogic>())
        {
        }

        /// <summary>
        /// Gets a collection to shops.
        /// </summary>
        public ObservableCollection<Aruhaz> Aruhazak { get; private set; }

        /// <summary>
        /// Gets or sets selected shop item.
        /// </summary>
        public Aruhaz AruhazSelected
        {
            get { return this.aruhazSelected; }
            set { this.Set(ref this.aruhazSelected, value); }
        }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets edit command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets getAll command.
        /// </summary>
        public ICommand ShowCmd { get; private set; }
    }
}
