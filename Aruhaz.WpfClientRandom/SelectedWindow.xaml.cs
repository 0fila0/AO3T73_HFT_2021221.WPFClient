// <copyright file="SelectedWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Windows;
    using System.Windows.Threading;
    using AruhazWeb.Controllers;
    using CommonServiceLocator;

    /// <summary>
    /// Interaction logic for SelectedWindow.xaml.
    /// </summary>
    public partial class SelectedWindow : Window
    {
        private string url = "http://localhost:5000/Random/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        private IMainVMRandom vm;
        private IMainLogicRandom logic;
        private Collection<AruhazVMRandom> randomShops;
        private ObservableCollection<AruhazVMRandom> selectedShops;
        private ObservableCollection<AruhazVMRandom> unselectedShops;
        private ObservableCollection<ConsoleLogVM> success;
        private string selectOrUnselectSuccessed;
        private DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedWindow"/> class.
        /// </summary>
        /// <param name="vm"> MainVMRandom class. </param>
        /// <param name="logic"> Logic class. </param>
        public SelectedWindow(IMainVMRandom vm, IMainLogicRandom logic)
        {
            this.vm = vm;
            this.logic = logic;
            this.Closing += this.DeleteAllRandomShops;
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedWindow"/> class.
        /// </summary>
        /// <param name="randomShops"> Random shops list. </param>
        public SelectedWindow(Collection<AruhazVMRandom> randomShops)
            : this(ServiceLocator.Current.GetInstance<IMainVMRandom>(), ServiceLocator.Current.GetInstance<IMainLogicRandom>())
        {
            this.randomShops = randomShops;
            ObservableCollection<AruhazVMRandom> selectList = new ObservableCollection<AruhazVMRandom>();
            ObservableCollection<AruhazVMRandom> unselectList = new ObservableCollection<AruhazVMRandom>();
            ObservableCollection<ConsoleLogVM> console = new ObservableCollection<ConsoleLogVM>();
            foreach (var item in this.randomShops)
            {
                if (item.Kijelolt == true)
                {
                    selectList.Add(item);
                }
                else
                {
                    unselectList.Add(item);
                }
            }

            this.selectedShops = selectList;
            this.unselectedShops = unselectList;
            this.success = console;
            this.vm.Selected = this.selectedShops.Count;
            this.vm.Unselected = this.unselectedShops.Count;
            this.vm.Shops = randomShops;
            this.vm.Console = console;
            this.DataContext = this.vm;
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(2);
            this.timer.Tick += this.SelectUnSelect;
            this.Loaded += this.Window_Loaded;
        }

        private void SelectUnSelect(object sender, EventArgs e)
        {
            int rnd = new Random().Next(0, this.randomShops.Count);
            string name = this.vm.Shops[rnd].AruhazNeve;
            int selectOrNot = new Random().Next(1, 101);
            ApiResult result;
            string json = string.Empty;
            if (selectOrNot <= 50)
            {
                this.selectOrUnselectSuccessed = "select";
                json = this.client.GetStringAsync(this.url + "Select/" + this.vm.Shops[rnd].AruhazNeve).Result;
                result = JsonSerializer.Deserialize<ApiResult>(json, this.jsonOptions);
                this.unselectedShops.Remove(this.vm.Shops[rnd]);
                this.selectedShops.Add(this.vm.Shops[rnd]);
            }
            else
            {
                this.selectOrUnselectSuccessed = "unselect";
                json = this.client.GetStringAsync(this.url + "Unselect/" + this.vm.Shops[rnd].AruhazNeve).Result;
                result = JsonSerializer.Deserialize<ApiResult>(json, this.jsonOptions);
                this.selectedShops.Remove(this.vm.Shops[rnd]);
                this.unselectedShops.Add(this.vm.Shops[rnd]);
            }

            this.vm.Selected = result.SelectedShops;
            this.vm.Unselected = result.UnselectedShops;
            if (result.OperationResult)
            {
                if (this.selectOrUnselectSuccessed == "select")
                {
                    this.success.Add(new ConsoleLogVM { Log = "Shop has been selected!" });
                }
                else
                {
                    this.success.Add(new ConsoleLogVM { Log = "Shop has been unselected!" });
                }
            }
            else
            {
                if (this.selectOrUnselectSuccessed == "select")
                {
                    this.success.Add(new ConsoleLogVM { Log = "Shop is already selected!" });
                }
                else
                {
                    this.success.Add(new ConsoleLogVM { Log = "Shop is already unselected!" });
                }
            }

            Collection<AruhazVMRandom> temp = new Collection<AruhazVMRandom>();
            this.selectedShops.Clear();
            this.unselectedShops.Clear();
            foreach (var item in this.logic.GetAll())
            {
                temp.Add(item);
                if (item.Kijelolt)
                {
                    this.selectedShops.Add(item);
                }
                else
                {
                    this.unselectedShops.Add(item);
                }
            }

            this.vm.Shops = temp;
            this.vm.Console = this.success;
            this.listBoxSelected.ItemsSource = this.selectedShops;
            this.listBoxUnselected.ItemsSource = this.unselectedShops;
            this.consoleLog.ItemsSource = this.success;
            this.InvalidateVisual();
        }

        private void DeleteAllRandomShops(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.timer.Stop();
            List<string> aruhazNeve = new List<string>();
            foreach (var item in this.randomShops)
            {
                aruhazNeve.Add(item.AruhazNeve);
            }

            this.logic.Delete(aruhazNeve);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.timer.Start();
        }
    }
}
