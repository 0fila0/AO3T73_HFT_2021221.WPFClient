// <copyright file="AruhazLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Products.GUI.BL
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Messaging;
    using Products.GUI.Data;
    using Products.Logic;

    /// <summary>
    /// GUI's Logic.
    /// </summary>
    internal class AruhazLogic : IAruhazLogic
    {
        private IEditorService editorService;
        private IMessenger messengerService;
        private ILogic logic;

        /// <summary>
        /// Initializes a new instance of the <see cref="AruhazLogic"/> class.
        /// </summary>
        /// <param name="editorService"> IEditorservice parameter. </param>
        /// <param name="messengerService"> IMessenger parameter. </param>
        /// <param name="logic"> ILogic parameter for Logical. </param>
        public AruhazLogic(IEditorService editorService, IMessenger messengerService, ILogic logic)
        {
            this.editorService = editorService;
            this.messengerService = messengerService;
            this.logic = logic;
        }

        /// <summary>
        /// Add a shop to database and to GUI.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        public void AddAruhaz(IList<Aruhaz> list)
        {
            Aruhaz newAruhaz = new Aruhaz();
            if (this.editorService.EditAruhaz(newAruhaz) == true)
            {
                list.Add(newAruhaz);
                this.logic.AddShop(newAruhaz.AruhazNeve, newAruhaz.Email, newAruhaz.Honlap, newAruhaz.Kozpont, newAruhaz.Telefon, newAruhaz.Adoszam, false);

                // Hozzáadni az adatbázishoz is (logic crud műveletét meghívni).
                this.messengerService.Send("ADD OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("ADD CANCELLED", "LogicResult");
            }
        }

        /// <summary>
        /// Delete a shop from database and GUI.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        /// <param name="aruhaz"> Should be deleted. </param>
        public void DelAruhaz(IList<Aruhaz> list, Aruhaz aruhaz)
        {
            if (aruhaz != null && list.Remove(aruhaz))
            {
                this.logic.DeleteShop(aruhaz.AruhazNeve);
                this.messengerService.Send("DELETE OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("DELETE FAILED", "LogicResult");
            }
        }

        /// <summary>
        /// Get all shops from database.
        /// </summary>
        /// <param name="list"> List's of shops. </param>
        public void GetAllAruhaz(IList<Aruhaz> list)
        {
            foreach (var item in this.logic.GetAllShops())
            {
                Aruhaz newAruhaz;
                string nev = item.AruhazNeve;
                if (!list.Where(x => x.AruhazNeve == nev).Any())
                {
                    newAruhaz = new Aruhaz
                    {
                        AruhazNeve = item.AruhazNeve,
                        Email = item.EMail,
                        Honlap = item.Honlap,
                        Kozpont = item.Kozpont,
                        Telefon = item.Telefon ?? 0,
                        Adoszam = item.Adoszam,
                    };
                    list.Add(newAruhaz);
                }
            }
        }

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="aruhazToModify"> Should be edited. </param>
        public void ModAruhaz(Aruhaz aruhazToModify)
        {
            if (aruhazToModify == null)
            {
                this.messengerService.Send("EDIT FAILED", "LogicResult");
                return;
            }

            Aruhaz clone = new Aruhaz();
            clone.CopyFrom(aruhazToModify);
            if (this.editorService.EditAruhaz(clone))
            {
                this.logic.UpdateShop(aruhazToModify.AruhazNeve, clone.AruhazNeve, clone.Email, clone.Honlap, clone.Kozpont, clone.Telefon, clone.Adoszam, false);
                aruhazToModify.CopyFrom(clone);
                this.messengerService.Send("EDIT OK", "LogicResult");
            }
            else
            {
                this.messengerService.Send("EDIT CANCELLED", "LogicResult");
            }
        }
    }
}
