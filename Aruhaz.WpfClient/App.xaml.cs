// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            //ServiceLocator.SetLocatorProvider(() => MyIOC.Instance);

            //MyIOC.Instance.Register<IMainShopLogic, MainShopLogic>();
            //MyIOC.Instance.Register<IMainManufacturerLogic, MainManufacturerLogic>();
            //MyIOC.Instance.Register<IMainProductLogic, MainProductLogic>();
        }
    }
}
