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

    //using GalaSoft.MvvmLight;

    /// <summary>
    /// Main view model class.
    /// </summary>
    internal class MainManufacturerVM : ObservableRecipient
    {
        private IMainManufacturerLogic logic;
        private Products.Data.Models.Gyarto selectedGyarto;
        // private ObservableCollection<GyartoVM> allGyarto;

        public RestCollection<Products.Data.Models.Gyarto> Manufacturers { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MainManufacturerVM"/> class.
        /// </summary>
        /// <param name="logic">Main logic.</param>
        public MainManufacturerVM(IMainManufacturerLogic logic)
        {
            this.logic = logic;

            //this.LoadCmd = new RelayCommand(() => this.AllGyarto = new ObservableCollection<GyartoVM>(this.logic.ApiGetGyarto()));
            //this.DelCmd = new RelayCommand(() => this.logic.ApiDelGyarto(this.selectedGyarto, this.AllGyarto));
            //this.AddCmd = new RelayCommand(() => this.logic.EditGyarto(null, this.AllGyarto, this.EditorFunc));
            //this.ModCmd = new RelayCommand(() => this.logic.EditGyarto(this.selectedGyarto, this.AllGyarto, this.EditorFunc));
        }

        public MainManufacturerVM()
        {
            if (!IsInDesignMode)
            {
                ManufacturerCommands();
            }
        }

        public void ManufacturerCommands()
        {
            this.Manufacturers = new RestCollection<Products.Data.Models.Gyarto>("http://localhost:54068/", "gyarto", "hub");
            this.AddCmd = new RelayCommand(() => {
                if (this.Manufacturers.FirstOrDefault(x => x.GyartoNeve == SelectedGyarto.GyartoNeve) == null)
                {
                    this.Manufacturers.Add(new Products.Data.Models.Gyarto()
                    {
                        GyartoNeve = this.SelectedGyarto.GyartoNeve,
                        Honlap = this.SelectedGyarto.Honlap,
                        Kozpont = this.SelectedGyarto.Kozpont,
                        EMail = this.SelectedGyarto.EMail,
                        Adoszam = this.SelectedGyarto.Adoszam,
                        Telefon = this.SelectedGyarto.Telefon,
                    });
                }
            });

            this.ModCmd = new RelayCommand(() =>
            {
                if (this.Manufacturers.FirstOrDefault(x => x.GyartoNeve == SelectedGyarto.GyartoNeve) != null)
                {
                    this.Manufacturers.Update(this.selectedGyarto);
                }
                else
                {
                    this.Manufacturers.Add(new Products.Data.Models.Gyarto()
                    {
                        GyartoNeve = this.SelectedGyarto.GyartoNeve,
                        Honlap = this.SelectedGyarto.Honlap,
                        Kozpont = this.SelectedGyarto.Kozpont,
                        EMail = this.SelectedGyarto.EMail,
                        Adoszam = this.SelectedGyarto.Adoszam,
                        Telefon = this.SelectedGyarto.Telefon,
                    });
                }
            });

            this.DelCmd = new RelayCommand(() =>
            {
                this.Manufacturers.Delete(this.selectedGyarto.GyartoNeve);
            },
            () =>
            {
                return this.SelectedGyarto != null;
            });

            this.SelectedGyarto = new Products.Data.Models.Gyarto();
        }

        /// <summary>
        /// Gets or sets selected shop.
        /// </summary>
        public Products.Data.Models.Gyarto SelectedGyarto
        {
            get
            {
                return this.selectedGyarto;
            }

            set
            {
                if (value != null)
                {
                    selectedGyarto = new Products.Data.Models.Gyarto()
                    {
                        GyartoNeve = value.GyartoNeve,
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
