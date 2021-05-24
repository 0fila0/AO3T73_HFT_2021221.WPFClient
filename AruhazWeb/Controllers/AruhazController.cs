// <copyright file="AruhazController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AruhazWeb.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Products.Logic;

    /// <summary>
    /// Shop controller.
    /// </summary>
    public class AruhazController : Controller
    {
        private ILogic logic;
        private IMapper mapper;
        private AruhazListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="AruhazController"/> class.
        /// </summary>
        /// <param name="logic"> Logic. </param>
        /// <param name="mapper"> Mapper. </param>
        public AruhazController(ILogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
            this.vm = new AruhazListViewModel();
            this.vm.EditedAruhaz = new Models.Aruhaz();
            var aruhazak = this.logic.GetAllShops();
            this.vm.ListOfAruhaz = this.mapper.Map<IEnumerable<Products.Data.Models.Aruhaz>, List<Models.Aruhaz>>(aruhazak);
        }

        /// <summary>
        /// IActionResult method.
        /// </summary>
        /// <returns>A view.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("AruhazIndex", this.vm);
        }

        /// <summary>
        /// Show shop's details.
        /// </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> View with shop's details. </returns>
        public IActionResult Details(string id)
        {
            return this.View("AruhazDetails", this.GetAruhazModel(id));
        }

        /// <summary>
        /// Delete one shop.
        /// </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> A new view. </returns>
        public IActionResult Remove(string id)
        {
            this.TempData["editResult"] = "Delete failed";
            if (this.logic.DeleteShop(id))
            {
                this.TempData["editResult"] = "Delete ok";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Show to be edited shop.
        /// </summary>
        /// <param name="id"> Shop's name. </param>
        /// <returns> A new view. </returns>
        public IActionResult Edit(string id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedAruhaz = this.GetAruhazModel(id);
            return this.View("AruhazIndex", this.vm);
        }

        /// <summary>
        /// Add a new shop or edit a shop.
        /// </summary>
        /// <param name="shop"> Add/Edit this shop. </param>
        /// <param name="editAction"> Add or edit. </param>
        /// <returns> A new view. </returns>
        [HttpPost]
        public IActionResult Edit(Models.Aruhaz shop, string editAction)
        {
            if (this.ModelState.IsValid && shop != null)
            {
                this.TempData["editResult"] = "Edit ok";
                if (editAction == "AddNew")
                {
                    Products.Data.Models.Aruhaz addShop = this.logic.GetOneShop(shop.AruhazNeve);
                    if (addShop == null)
                    {
                        try
                        {
                            this.logic.AddShop(shop.AruhazNeve, shop.Email, shop.Honlap, shop.Kozpont, decimal.Parse(shop.Telefon), decimal.Parse(shop.Adoszam), shop.Kijelolt);
                        }
                        catch (ArgumentException ex)
                        {
                            this.TempData["editResult"] = "Edit failed: " + ex.Message;
                        }
                    }
                    else
                    {
                        this.TempData["editResult"] = "Edit failed: this shop already exists.";
                    }
                }
                else
                {
                    if (!this.logic.UpdateShopWeb(shop.RegiNev, shop.AruhazNeve, shop.Email, shop.Honlap, shop.Kozpont, decimal.Parse(shop.Telefon), decimal.Parse(shop.Adoszam), shop.Kijelolt))
                    {
                        this.TempData["editResult"] = "Edit failed";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedAruhaz = shop;
                return this.View("AruhazIndex", this.vm);
            }
        }

        private Models.Aruhaz GetAruhazModel(string id)
        {
            Products.Data.Models.Aruhaz oneShop = this.logic.GetOneShop(id);
            return this.mapper.Map<Products.Data.Models.Aruhaz, Models.Aruhaz>(oneShop);
        }
    }
}
