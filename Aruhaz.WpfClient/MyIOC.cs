// <copyright file="MyIOC.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// This is an individual MyIOC for bugfix purposes.
    /// </summary>
    public class MyIOC : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets instance.
        /// </summary>
        public static MyIOC Instance { get; private set; } = new MyIOC();
    }
}