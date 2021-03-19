// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.GUI.BL;
    using Products.GUI.Data;

    /// <summary>
    /// EditorService class.
    /// </summary>
    internal class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// Make a new Editor window with the shop's data.
        /// </summary>
        /// <param name="aruh"> Should be edited. </param>
        /// <returns> True: shop's data has been edited. </returns>
        public bool EditAruhaz(Aruhaz aruh)
        {
            EditorWindow win = new EditorWindow(aruh);
            return win.ShowDialog() ?? false;
        }
    }
}
