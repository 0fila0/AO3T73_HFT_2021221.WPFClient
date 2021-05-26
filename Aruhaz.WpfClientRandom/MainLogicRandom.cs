// <copyright file="MainLogicRandom.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <inheritdoc/>
    internal class MainLogicRandom : IMainLogicRandom
    {
        private string url = "http://localhost:5000/Random/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <inheritdoc/>
        public void NewSecondWindow(int getOneCalls)
        {
            Collection<AruhazVMRandom> randomShops = this.GetOneCalls(getOneCalls);
            SelectedWindow window = new SelectedWindow(randomShops);
            window.ShowDialog();
        }

        /// <inheritdoc/>
        public void Delete(List<string> aruhazNeve)
        {
            string url = "http://localhost:5000/AruhazApi/";
            for (int i = 0; i < aruhazNeve.Count; i++)
            {
                string json = this.client.GetStringAsync(url + "del/" + aruhazNeve[i]).Result;
            }
        }

        /// <inheritdoc/>
        public List<AruhazVMRandom> GetAll()
        {
            string url = "http://localhost:5000/AruhazApi/";
            string json = this.client.GetStringAsync(url + "all").Result;
            var list = JsonSerializer.Deserialize<List<AruhazVMRandom>>(json, this.jsonOptions);
            return list;
        }

        private Collection<AruhazVMRandom> GetOneCalls(int getOneCalls)
        {
            Collection<AruhazVMRandom> list = new Collection<AruhazVMRandom>();
            for (int i = 0; i < getOneCalls; i++)
            {
                string json = this.client.GetStringAsync(this.url + "GetOne").Result;
                list.Add(JsonSerializer.Deserialize<AruhazVMRandom>(json, this.jsonOptions));
            }

            return list;
        }
    }
}
