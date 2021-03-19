// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Products.GUI.Data;
    using Products.GUI.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private EditorViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();

            this.vm = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldAruhaz"> Creates an editor window with this old shop's data. </param>
        public EditorWindow(Aruhaz oldAruhaz)
            : this()
        {
            this.vm.Aruhaz = oldAruhaz;
        }

        /// <summary>
        /// Gets viewmodel's shop.
        /// </summary>
        public Aruhaz Aruhaz { get => this.vm.Aruhaz; }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
