// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
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

    /// <summary>
    /// Main view model class.
    /// </summary>
    internal class MainVM : ViewModelBase
    {
        private IMainLogic logic;
        private AruhazVM selectedAruhaz;
        private ObservableCollection<AruhazVM> allAruhaz;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="logic">Main logic.</param>
        public MainVM(IMainLogic logic)
        {
            this.logic = logic;
            this.LoadCmd = new RelayCommand(() => this.AllAruhaz = new ObservableCollection<AruhazVM>(this.logic.ApiGetAruhaz()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelAruhaz(this.selectedAruhaz));
            this.AddCmd = new RelayCommand(() => this.logic.EditAruhaz(null, this.EditorFunc));
            this.ModCmd = new RelayCommand(() => this.logic.EditAruhaz(this.selectedAruhaz, this.EditorFunc));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogic>())
        {
        }

        /// <summary>
        /// Gets or sets all shops.
        /// </summary>
        public ObservableCollection<AruhazVM> AllAruhaz
        {
            get { return this.allAruhaz; }
            set { this.Set(ref this.allAruhaz, value); }
        }

        /// <summary>
        /// Gets or sets selected shop.
        /// </summary>
        public AruhazVM SelectedAruhaz
        {
            get { return this.selectedAruhaz; }
            set { this.Set(ref this.selectedAruhaz, value); }
        }

        /// <summary>
        /// Gets or sets editor function.
        /// </summary>
        public Func<AruhazVM, bool> EditorFunc { get; set; }

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
