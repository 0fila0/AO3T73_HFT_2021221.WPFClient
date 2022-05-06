// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using CommonServiceLocator;
    using Microsoft.Toolkit.Mvvm.ComponentModel;
    using Microsoft.Toolkit.Mvvm.Input;

    // using GalaSoft.MvvmLight;
    // using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// Main view model class.
    /// </summary>
    public class MainShopVM : ObservableRecipient // ViewModelBase
    {
        private IMainShopLogic logic;
        private Products.Data.Models.Aruhaz selectedAruhaz;
        //private ObservableCollection<AruhazVM> allAruhaz;

        public RestCollection<Products.Data.Models.Aruhaz> Shops { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainShopVM"/> class.
        /// </summary>
        /// <param name="logic">Main logic.</param>
        public MainShopVM(IMainShopLogic logic)
        {
            this.logic = logic;

            //this.LoadCmd = new RelayCommand(() => this.AllAruhaz = new ObservableCollection<AruhazVM>(this.logic.ApiGetAruhaz()));
            //this.DelCmd = new RelayCommand(() => this.logic.ApiDelAruhaz(this.selectedAruhaz, this.AllAruhaz));
            //this.AddCmd = new RelayCommand(() => this.logic.EditAruhaz(null, this.AllAruhaz, this.EditorFunc));
            //this.ModCmd = new RelayCommand(() => this.logic.EditAruhaz(this.selectedAruhaz, this.AllAruhaz, this.EditorFunc));
        }

        public MainShopVM()
        {
            if (!IsInDesignMode)
            {
                ShopCommands();
            }
        }

        public void ShopCommands()
        {
            this.Shops = new RestCollection<Products.Data.Models.Aruhaz>("http://localhost:54068/", "aruhaz", "hub");
            this.AddCmd = new RelayCommand(() => {
                if (this.Shops.FirstOrDefault(x => x.AruhazNeve == SelectedAruhaz.AruhazNeve) == null)
                {
                    this.Shops.Add(new Products.Data.Models.Aruhaz()
                    {
                        AruhazNeve = this.SelectedAruhaz.AruhazNeve,
                        Honlap = this.SelectedAruhaz.Honlap,
                        Kozpont = this.SelectedAruhaz.Kozpont,
                        EMail = this.SelectedAruhaz.EMail,
                        Adoszam = this.SelectedAruhaz.Adoszam,
                        Telefon = this.SelectedAruhaz.Telefon,
                    });
                }
            });

            this.ModCmd = new RelayCommand(() =>
            {
                if (this.Shops.FirstOrDefault(x => x.AruhazNeve == SelectedAruhaz.AruhazNeve) != null)
                {
                    this.Shops.Update(this.selectedAruhaz);
                }
                else
                {
                    this.Shops.Add(new Products.Data.Models.Aruhaz()
                    {
                        AruhazNeve = this.SelectedAruhaz.AruhazNeve,
                        Honlap = this.SelectedAruhaz.Honlap,
                        Kozpont = this.SelectedAruhaz.Kozpont,
                        EMail = this.SelectedAruhaz.EMail,
                        Adoszam = this.SelectedAruhaz.Adoszam,
                        Telefon = this.SelectedAruhaz.Telefon,
                    });
                }
            });

            this.DelCmd = new RelayCommand(() =>
            {
                this.Shops.Delete(this.selectedAruhaz.AruhazNeve);
            },
            () =>
            {
                return this.SelectedAruhaz != null;
            });

            this.SelectedAruhaz = new Products.Data.Models.Aruhaz();
        }

        ///// <summary>
        ///// Gets or sets all shops.
        ///// </summary>
        //public ObservableCollection<AruhazVM> AllAruhaz
        //{
        //    get { return this.allAruhaz; }
        //    set { this.Set(ref this.allAruhaz, value); }
        //}

        /// <summary>
        /// Gets or sets selected shop.
        /// </summary>
        public Products.Data.Models.Aruhaz SelectedAruhaz
        {
            get
            {
                return this.selectedAruhaz;
            }

            set
            {
                if (value != null)
                {
                    selectedAruhaz = new Products.Data.Models.Aruhaz()
                    {
                        AruhazNeve = value.AruhazNeve,
                        EMail = value.EMail,
                        Honlap = value.Honlap,
                        Kozpont = value.Kozpont,
                        Adoszam = value.Adoszam,
                        Telefon = value.Telefon,
                    };
                }

                this.OnPropertyChanged();
                (this.DelCmd as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        /// <summary>
        /// Gets add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets modifiy command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets load command.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}
