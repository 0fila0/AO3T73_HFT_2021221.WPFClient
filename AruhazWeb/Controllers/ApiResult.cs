// <copyright file="ApiResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AruhazWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// asdasd.
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether operation result.
        /// </summary>
        public bool OperationResult { get; set; }

        /// <summary>
        /// Gets or sets selected shops number.
        /// </summary>
        public int SelectedShops { get; set; }

        /// <summary>
        /// Gets or sets unselected shops number.
        /// </summary>
        public int UnselectedShops { get; set; }
    }
}
