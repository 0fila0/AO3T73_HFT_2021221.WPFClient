// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <inheritdoc/>
    internal class MainLogic : IMainLogic
    {
        private string url = "http://localhost:5000/AruhazApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <inheritdoc/>
        public List<AruhazVM> ApiGetAruhaz()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<AruhazVM>>(json, this.jsonOptions);
            return list;
        }

        /// <inheritdoc/>
        public void ApiDelAruhaz(AruhazVM aruhaz)
        {
            bool success = false;
            if (aruhaz != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + aruhaz.AruhazNeve.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <inheritdoc/>
        public void EditAruhaz(AruhazVM aruhaz, Func<AruhazVM, bool> editorFunc)
        {
            AruhazVM clone = new AruhazVM();
            string regiNev = string.Empty;
            if (aruhaz != null)
            {
                clone.CopyFrom(aruhaz);
                regiNev = aruhaz.AruhazNeve;
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (aruhaz != null)
                {
                    success = this.ApiEditAruhaz(clone, regiNev, true);
                }
                else
                {
                    success = this.ApiEditAruhaz(clone, string.Empty, false);
                }
            }

            this.SendMessage(success == true);
        }

        /// <summary>
        /// Send a message.
        /// </summary>
        /// <param name="success">Success or not the operation.</param>
        private void SendMessage(bool success)
        {
            string msg = success ? "Sikeres művelet." : "Sikertelen művelet!";
            Messenger.Default.Send(msg, "AruhazResult");
        }

        private bool ApiEditAruhaz(AruhazVM aruhaz, string regiNev, bool isEditing)
        {
            if (aruhaz == null)
            {
                return false;
            }

            string myUrl = this.url + (isEditing ? "mod" : "add");
            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("regiNev", regiNev);
            }

            postData.Add("aruhazNeve", aruhaz.AruhazNeve.ToString());
            postData.Add("honlap", aruhaz.Honlap.ToString());
            postData.Add("telefon", aruhaz.Telefon.ToString());
            postData.Add("adoszam", aruhaz.Adoszam.ToString());
            postData.Add("kozpont", aruhaz.Kozpont.ToString());
            postData.Add("email", aruhaz.Email.ToString());

            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }
    }
}
