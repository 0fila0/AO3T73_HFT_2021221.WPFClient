// <copyright file="IMainVMRandom.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Interface for MainVMRandom.
    /// </summary>
    public interface IMainVMRandom
    {
        /// <summary>
        /// Gets or sets selected shops.
        /// </summary>
        int Selected
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets unselected shops.
        /// </summary>
        public int Unselected
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets RandomShopsNumber.
        /// </summary>
        public string RandomShopsNumber
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shops list.
        /// </summary>
        public Collection<AruhazVMRandom> Shops
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets what result of random controller.
        /// </summary>
        public ObservableCollection<RandomJsonResult> Result
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets console text.
        /// </summary>
        public Collection<ConsoleLogVM> Console
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets getOne command.
        /// </summary>
        public ICommand LoadCmd
        {
            get; set;
        }
    }
}
