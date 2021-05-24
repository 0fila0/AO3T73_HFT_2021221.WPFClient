// <copyright file="MyIOCRandom.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// This is an individual MyIOCRandom for bugfix purposes.
    /// </summary>
    public class MyIOCRandom : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets instance.
        /// </summary>
        public static MyIOCRandom Instance { get; private set; } = new MyIOCRandom();
    }
}
