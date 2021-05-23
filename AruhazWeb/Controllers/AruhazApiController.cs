// <copyright file="AruhazApiController.cs" company="PlaceholderCompany">
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
    using Products.Logic;

    /// <summary>
    /// API controller.
    /// </summary>
    public class AruhazApiController : Controller
    {
        private ILogic logic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AruhazApiController"/> class.
        /// </summary>
        /// <param name="logic">Logic class.</param>
        /// <param name="mapper">Automapper class.</param>
        public AruhazApiController(ILogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
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
        /// Delete one shop.
        /// </summary>
        /// <param name="id"> This shop will be deleted. </param>
        /// <returns> Operation result. </returns>
        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOneAruhaz(string id)
        {
            return new ApiResult() { OperationResult = this.logic.DeleteShop(id) };
        }

        /// <summary>
        /// Add one shop.
        /// </summary>
        /// <param name="aruhaz"> Add this shop. </param>
        /// <returns> Operation result. </returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneShop(Models.Aruhaz aruhaz)
        {
            bool success = true;
            try
            {
                if (aruhaz != null)
                {
                    this.logic.AddShop(aruhaz.AruhazNeve, aruhaz.Email, aruhaz.Honlap, aruhaz.Kozpont, decimal.Parse(aruhaz.Telefon), decimal.Parse(aruhaz.Adoszam));
                }
            }
            catch (ArgumentException)
            {
                success = false;
            }

            return new ApiResult() { OperationResult = success };
        }

        /// <summary>
        /// Modify a shop.
        /// </summary>
        /// <param name="aruhaz"> Modify this shop. </param>
        /// <returns> Operation result. </returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneShop(Models.Aruhaz aruhaz)
        {
            if (aruhaz != null)
            {
                return new ApiResult() { OperationResult = this.logic.UpdateShopWeb(aruhaz.RegiNev, aruhaz.AruhazNeve, aruhaz.Email, aruhaz.Honlap, aruhaz.Kozpont, decimal.Parse(aruhaz.Telefon), decimal.Parse(aruhaz.Adoszam)) };
            }

            return new ApiResult() { OperationResult = false };
        }
    }
}
