// <copyright file="MainProductVM.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// .
    /// </summary>
    public class MainProductVM : ObservableRecipient // ViewModelBase
    {
        private IMainProductLogic logic;
        private Products.Data.Models.Termek selectedTermek;
        public RestCollection<Products.Data.Models.Termek> Products { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainProductVM"/> class.
        /// </summary>
        /// <param name="logic">Main logic.</param>
        public MainProductVM(IMainProductLogic logic)
        {
            this.logic = logic;
            //this.LoadCmd = new RelayCommand(() => this.AllTermek = new ObservableCollection<TermekVM>(this.logic.ApiGetTermek()));
            //this.DelCmd = new RelayCommand(() => this.logic.ApiDelTermek(this.selectedTermek, this.AllTermek));
            //this.AddCmd = new RelayCommand(() => this.logic.EditTermek(null, this.AllTermek, this.EditorFunc));
            //this.ModCmd = new RelayCommand(() => this.logic.EditTermek(this.selectedTermek, this.AllTermek, this.EditorFunc));
        }

        ///// <summary>
        ///// Initializes a new instance of the <see cref="MainProductVM"/> class.
        ///// </summary>
        //public MainProductVM()
        //    : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainProductLogic>())
        //{
        //}

        public MainProductVM()
        {
            if (!IsInDesignMode)
            {
                ProductCommands();
            }
        }

        public void ProductCommands()
        {
            this.Products = new RestCollection<Products.Data.Models.Termek>("http://localhost:54068/", "termek", "hub");
            this.AddCmd = new RelayCommand(() => {
                if (this.Products.FirstOrDefault(x => x.TermekID == SelectedTermek.TermekID) == null)
                {
                    this.Products.Add(new Products.Data.Models.Termek()
                    {
                        TermekID = this.SelectedTermek.TermekID,
                        Ar = this.SelectedTermek.Ar,
                        Kiszereles = this.SelectedTermek.Kiszereles,
                        Megnevezes = this.SelectedTermek.Megnevezes,
                        Leiras = this.SelectedTermek.Leiras,
                        Tipus = this.SelectedTermek.Tipus,
                    });
                }
            });

            this.ModCmd = new RelayCommand(() =>
            {
                if (this.Products.FirstOrDefault(x => x.TermekID == SelectedTermek.TermekID) != null)
                {
                    this.Products.Update(this.selectedTermek);
                }
                else
                {
                    this.Products.Add(new Products.Data.Models.Termek()
                    {
                        TermekID = this.SelectedTermek.TermekID,
                        Ar = this.SelectedTermek.Ar,
                        Kiszereles = this.SelectedTermek.Kiszereles,
                        Megnevezes = this.SelectedTermek.Megnevezes,
                        Leiras = this.SelectedTermek.Leiras,
                        Tipus = this.SelectedTermek.Tipus,
                    });
                }
            });

            this.DelCmd = new RelayCommand(() =>
            {
                this.Products.Delete(this.selectedTermek.TermekID.ToString());
            },
            () =>
            {
                return this.SelectedTermek != null;
            });

            this.SelectedTermek = new Products.Data.Models.Termek();
        }

        ///// <summary>
        ///// Gets or sets all shops.
        ///// </summary>
        //public ObservableCollection<TermekVM> AllTermek
        //{
        //    get { return this.Products; }
        //    set { this.Set(ref this.Products, value); }
        //}

        /// <summary>
        /// Gets or sets selected shop.
        /// </summary>
        public Products.Data.Models.Termek SelectedTermek
        {
            get
            {
                return this.selectedTermek;
            }

            set
            {
                if (value != null)
                {
                    selectedTermek = new Products.Data.Models.Termek()
                    {
                        TermekID = value.TermekID,
                        Ar = value.Ar,
                        Kiszereles = value.Kiszereles,
                        Megnevezes = value.Megnevezes,
                        Leiras = value.Leiras,
                        Tipus = value.Tipus,
                    };
                }

                this.OnPropertyChanged();
                (this.DelCmd as RelayCommand).NotifyCanExecuteChanged();
            }
            //get { return this.selectedTermek; }
            //set { this.Set(ref this.selectedTermek, value); }
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
