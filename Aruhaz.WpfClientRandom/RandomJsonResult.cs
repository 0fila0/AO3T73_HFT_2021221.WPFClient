// <copyright file="RandomJsonResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Aruhaz.WpfClientRandom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// What Random controller send back that will be the result.
    /// </summary>
    public class RandomJsonResult
    {
        /// <summary>
        /// Gets or sets the action's success.
        /// </summary>
        public string Success { get; set; }

        /// <summary>
        /// Gets or sets selected shops number.
        /// </summary>
        public int Selected { get; set; }

        /// <summary>
        /// Gets or sets unselected shops number.
        /// </summary>
        public int Unselected { get; set; }
    }
}
