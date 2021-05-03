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
            var aruhazak = this.logic.GetAllShops().ToList();
            this.vm.ListOfAruhaz = this.mapper.Map<IList<Products.Data.Models.Aruhaz>, List<Models.Aruhaz>>(aruhazak);
        }

        /// <summary>
        /// IActionResult method.
        /// </summary>
        /// <returns>A view.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View();
        }
    }
}
