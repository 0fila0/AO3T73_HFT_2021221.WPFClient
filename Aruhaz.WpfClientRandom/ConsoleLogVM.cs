// <copyright file="ConsoleLogVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Events' text.
    /// </summary>
    public class ConsoleLogVM : ObservableObject
    {
        private string log;

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        public string Log
        {
            get { return this.log; }
            set { this.Set(ref this.log, value); }
        }
    }
}
