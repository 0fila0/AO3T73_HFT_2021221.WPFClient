// <copyright file="RandomController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomController"/> class.
        /// </summary>
        /// <param name="logic"> Logic class. </param>
        /// <param name="mapper"> Mapper class. </param>
        public RandomController(ILogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create a random shop and save it to the database.
        /// </summary>
        [HttpGet]
        [ActionName("Random/GetOne")]
        public void CreateAndSaveRandomShop()
        {
            int randomEmailLength = new Random().Next(5, 21);
            int randomEmailServerLength = new Random().Next(5, 12);
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

            Aruhaz randomShop = this.logic.GetAllShops().Select(x => x).Where(x => x.AruhazNeve == aruhazNeve).FirstOrDefault();

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
            this.GetAll();
        }

        /// <summary>
        /// Get all shops.
        /// </summary>
        /// <returns> All shops. </returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Aruhaz> GetAll()
        {
            var aruhaz = this.logic.GetAllShops();
            return this.mapper.Map<IEnumerable<Products.Data.Models.Aruhaz>, List<Models.Aruhaz>>(aruhaz);
        }

        /// <summary>
        /// Select a random shop.
        /// </summary>
        /// <param name="shop"> Select this shop. </param>
        /// <returns> Operation completed successfully or not. </returns>
        [HttpPost]
        [ActionName("Random/Select/ID")]
        public ApiResult SelectId(Aruhaz shop)
        {
            bool success = true;
            try
            {
                if (shop != null)
                {
                    this.logic.UpdateShopWeb(shop.AruhazNeve, shop.AruhazNeve, shop.EMail, shop.Honlap, shop.Kozpont, shop.Telefon ?? 0, shop.Adoszam, true);
                }
            }
            catch (ArgumentException)
            {
                success = false;
            }

            int selected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == true).Count();
            int unselected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == false).Count();

            return new ApiResult() { OperationResult = success, SelectedShops = selected, UnselectedShops = unselected };
        }

        /// <summary>
        /// Unselect a random shop.
        /// </summary>
        /// <param name="shop"> Unselect this shop. </param>
        /// <returns> Operation completed successfully or not. </returns>
        [HttpPost]
        [ActionName("Random/Unselect/ID")]
        public ApiResult UnselectId(Aruhaz shop)
        {
            bool success = true;
            try
            {
                if (shop != null)
                {
                    this.logic.UpdateShopWeb(shop.AruhazNeve, shop.AruhazNeve, shop.EMail, shop.Honlap, shop.Kozpont, shop.Telefon ?? 0, shop.Adoszam, false);
                }
            }
            catch (ArgumentException)
            {
                success = false;
            }

            int selected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == true).Count();
            int unselected = this.logic.GetAllShops().Select(x => x).Where(x => x.Kijelolt == false).Count();

            return new ApiResult() { OperationResult = success, SelectedShops = selected, UnselectedShops = unselected };
        }

        /// <summary>
        /// Show shop's details.
        /// </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> View with shop's details. </returns>
        [HttpGet]
        [ActionName("Random/Selections")]
        public IActionResult Details(string id)
        {
            return this.View("RandomDetails", this.GetAruhazModel(id));
        }

        private Models.Aruhaz GetAruhazModel(string id)
        {
            Products.Data.Models.Aruhaz oneShop = this.logic.GetOneShop(id);
            return this.mapper.Map<Products.Data.Models.Aruhaz, Models.Aruhaz>(oneShop);
        }
    }
}
