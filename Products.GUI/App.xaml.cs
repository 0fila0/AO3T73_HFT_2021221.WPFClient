// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI
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
    using Products.Data.Models;
    using Products.GUI.BL;
    using Products.GUI.UI;
    using Products.Logic;
    using Products.Repository;

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
            ServiceLocator.SetLocatorProvider(() => MyIOC.Instance);

            MyIOC.Instance.Register<IEditorService, EditorServiceViaWindow>();
            MyIOC.Instance.Register<IMessenger>(() => Messenger.Default);
            MyIOC.Instance.Register<ProductsContext>(() => ProductsContext.Instance);
            MyIOC.Instance.Register<IAruhazLogic, AruhazLogic>();
            MyIOC.Instance.Register<ILogic, Logical>();
            MyIOC.Instance.Register<IRepository, ProductsRepository>();
        }
    }
}
