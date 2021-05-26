// <copyright file="IMainLogicRandom.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Interface for MainLogicRandom (IoC).
    /// </summary>
    public interface IMainLogicRandom
    {
        /// <summary>
        /// Open selected window with shops.
        /// </summary>
        /// <param name="getOneCalls"> Call GetOne method getOneCalls times. </param>
        public void NewSecondWindow(int getOneCalls);

        /// <summary>
        /// Delete all random shops.
        /// </summary>
        /// <param name="aruhazNeve"> Shops' names. </param>
        public void Delete(List<string> aruhazNeve);

        /// <summary>
        /// Refresh the shop list.
        /// </summary>
        /// <returns> Updated shop list. </returns>
        public List<AruhazVMRandom> GetAll();
    }
}
