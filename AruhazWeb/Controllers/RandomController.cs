// <copyright file="RandomController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using AruhazWeb.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Products.Data.Models;
    using Products.Logic;

    /// <summary>
    /// Random controller class.
    /// </summary>
    public class RandomController : Controller
    {
        private ILogic logic;
        private IMapper mapper;
        private Random rnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomController"/> class.
        /// </summary>
        /// <param name="logic"> Logic class. </param>
        /// <param name="mapper"> Mapper class. </param>
        public RandomController(ILogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
            this.rnd = new Random();
        }

        /// <summary>
        /// Create a random shop and save it to the database.
        /// </summary>
        /// <returns> A new shop. </returns>
        public Models.Aruhaz GetOne()
        {
            int randomEmailLength = new Random().Next(5, 21);
            int randomEmailServerLength = new Random().Next(3, 6);
            int randomEmailLocation = new Random().Next(0, 2);
            string[] randomCenter = new string[10];
            randomCenter[0] = "Németország";
            randomCenter[1] = "Magyarország";
            randomCenter[2] = "Hollandia";
            randomCenter[3] = "Csehország";
            randomCenter[4] = "Spanyolország";
            randomCenter[5] = "Szlovákia";
            randomCenter[6] = "Horvátország";
            randomCenter[7] = "Svédország";
            randomCenter[8] = "Szerbia";
            randomCenter[9] = "Lengyelország";

            string numbers = "0123456789";
            string abc = "abcdefghijklmnopqrstuvwxyz";
            string adoszam = string.Empty;
            string telefon = string.Empty;
            string email = string.Empty;
            string aruhazNeve = string.Empty;
            string honlap = string.Empty;
            string kozpont = string.Empty;
            bool kijelolt = false;
            for (int i = 0; i < 11; i++)
            {
                int randomNumber = new Random().Next(0, 10);
                adoszam += numbers[randomNumber];
                randomNumber = new Random().Next(0, 10);
                telefon += numbers[randomNumber];
            }

            for (int i = 0; i < randomEmailLength; i++)
            {
                int randomChar = new Random().Next(0, 26);
                email += abc[randomChar];
            }

            honlap = email + "site";
            aruhazNeve = email;
            email += "@";

            for (int i = 0; i < randomEmailServerLength; i++)
            {
                int randomChar = new Random().Next(0, 26);
                email += abc[randomChar];
            }

            if (randomEmailLocation == 0)
            {
                email += ".hu";
                honlap += ".hu";
                kozpont = randomCenter[1];
            }
            else
            {
                email += ".com";
                honlap += ".com";
                int randomCenterPick = new Random().Next(0, 10);
                kozpont = randomCenter[randomCenterPick];
            }

            Products.Data.Models.Aruhaz randomShop = this.logic.GetAllShops().Select(x => x).Where(x => x.AruhazNeve == aruhazNeve).FirstOrDefault();

            while (randomShop != null)
            {
                aruhazNeve = string.Empty;
                for (int i = 0; i < randomEmailLength; i++)
                {
                    int randomChar = new Random().Next(0, 26);
                    aruhazNeve += abc[randomChar];
                }

                randomShop = this.logic.GetAllShops().Select(x => x).Where(x => x.AruhazNeve == aruhazNeve).FirstOrDefault();
            }

            this.logic.AddShop(aruhazNeve, email, honlap, kozpont, decimal.Parse(telefon), decimal.Parse(adoszam), kijelolt);
            return this.mapper.Map<Products.Data.Models.Aruhaz, Models.Aruhaz>(this.logic.GetOneShop(aruhazNeve));
        }

        /// <summary> Select or unselect shop. </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> Result (success, selected shops, unselected shops). </returns>
        [HttpGet]
        [ActionName("Select")]
        public ApiResult SelectId(string id)
        {
            Products.Data.Models.Aruhaz shop = this.logic.GetOneShop(id);
            bool success = false;
            try
            {
                if (shop != null && shop.Kijelolt == false)
                {
                    this.logic.UpdateShopWeb(shop.AruhazNeve, shop.AruhazNeve, shop.EMail, shop.Honlap, shop.Kozpont, shop.Telefon ?? 0, shop.Adoszam, true);
                    success = true;
                }
            }
            catch (ArgumentException)
            {
            }

            int selected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == true).Count();
            int unselected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == false).Count();

            return new ApiResult() { OperationResult = success, SelectedShops = selected, UnselectedShops = unselected };
        }

        /// <summary> Unselect shop. </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> Result (success, selected shops, unselected shops). </returns>
        [HttpGet]
        [ActionName("Unselect")]
        public ApiResult UnselectId(string id)
        {
            Products.Data.Models.Aruhaz shop = this.logic.GetOneShop(id);
            bool success = false;
            try
            {
                if (shop != null && shop.Kijelolt == true)
                {
                    this.logic.UpdateShopWeb(shop.AruhazNeve, shop.AruhazNeve, shop.EMail, shop.Honlap, shop.Kozpont, shop.Telefon ?? 0, shop.Adoszam, false);
                    success = true;
                }
            }
            catch (ArgumentException)
            {
            }

            int selected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == true).Count();
            int unselected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == false).Count();

            return new ApiResult() { OperationResult = success, SelectedShops = selected, UnselectedShops = unselected };
        }

        /// <summary>
        /// Show shop's details.
        /// </summary>
        /// <returns> View with shop's details. </returns>
        public IActionResult Selections()
        {
            List<Models.Aruhaz> selected = new List<Models.Aruhaz>();
            List<Models.Aruhaz> unselected = new List<Models.Aruhaz>();

            foreach (var shop in this.logic.GetAllShops())
            {
                Models.Aruhaz randomShop = new Models.Aruhaz();
                randomShop.AruhazNeve = shop.AruhazNeve;
                randomShop.Email = shop.EMail;
                randomShop.Honlap = shop.Honlap;
                randomShop.Kozpont = shop.Kozpont;
                randomShop.Telefon = shop.Telefon.ToString();
                randomShop.Adoszam = shop.Adoszam.ToString();
                randomShop.Kijelolt = shop.Kijelolt;
                randomShop.RegiNev = shop.AruhazNeve;

                if (shop.Kijelolt == true)
                {
                    selected.Add(randomShop);
                }
                else
                {
                    unselected.Add(randomShop);
                }
            }

            RandomAruhazListViewModel vm = new RandomAruhazListViewModel(selected, unselected);
            return this.View("RandomView", vm);
        }
    }
}
