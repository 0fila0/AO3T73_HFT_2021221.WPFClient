// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.GUI.Data;

    /// <summary>
    /// IEditorService interface.
    /// </summary>
    internal interface IEditorService
    {
        /// <summary>
        /// It returns true if the shop have been edited.
        /// </summary>
        /// <param name="aruh"> Should be edited. </param>
        /// <returns> True: shop have been edited. </returns>
        bool EditAruhaz(Aruhaz aruh);
    }
}
