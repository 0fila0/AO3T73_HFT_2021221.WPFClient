// <copyright file="MainVMRandom.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// Main view model class.
    /// </summary>
    public class MainVMRandom : ViewModelBase, IMainVMRandom
    {
        private readonly IMainLogicRandom logic;
        private Collection<AruhazVMRandom> shops;
        private ObservableCollection<RandomJsonResult> result;
        private Collection<ConsoleLogVM> logs;
        private string randomShopsNumber;
        private int selected;
        private int unselected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVMRandom"/> class.
        /// </summary>
        /// <param name="logic"> Logic.</param>
        [PreferredConstructorAttribute]
        public MainVMRandom(IMainLogicRandom logic)
        {
            this.logic = logic;
            this.LoadCmd = new RelayCommand(() =>
            {
                this.logic.NewSecondWindow(int.Parse(this.randomShopsNumber));
            });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVMRandom"/> class.
        /// </summary>
        public MainVMRandom()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogicRandom>())
        {
        }

        /// <inheritdoc/>
        public int Selected { get => this.selected; set => this.Set(ref this.selected, value); }

        /// <inheritdoc/>
        public int Unselected { get => this.unselected; set => this.Set(ref this.unselected, value); }

        /// <inheritdoc/>
        public string RandomShopsNumber { get => this.randomShopsNumber; set => this.randomShopsNumber = value; }

        /// <inheritdoc/>
        public Collection<AruhazVMRandom> Shops { get => this.shops; set => this.Set(ref this.shops, value); }

        /// <inheritdoc/>
        public ObservableCollection<RandomJsonResult> Result { get => this.result; set => this.Set(ref this.result, value); }

        /// <inheritdoc/>
        public Collection<ConsoleLogVM> Console { get => this.logs; set => this.Set(ref this.logs, value); }

        /// <inheritdoc/>
        public ICommand LoadCmd { get; set; }
    }
}
