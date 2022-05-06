namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for MainLogic (IoC).
    /// </summary>
    public interface IMainManufacturerLogic
    {
        /// <summary>
        /// Get a shop.
        /// </summary>
        /// <returns>Get this shop.</returns>
        List<GyartoVM> ApiGetGyarto();

        /// <summary>
        /// Delete a shop.
        /// </summary>
        /// <param name="gyarto">Delete this shop.</param>
        /// <param name="list">list.</param>
        void ApiDelGyarto(GyartoVM gyarto, ObservableCollection<GyartoVM> list);

        /// <summary>
        /// Edit a shop.
        /// </summary>
        /// <param name="gyarto"> Edit this shop. </param>
        /// <param name="list">List.</param>
        /// <param name="editorFunc"> Edit function. </param>
        void EditGyarto(GyartoVM gyarto, ObservableCollection<GyartoVM> list, Func<GyartoVM, bool> editorFunc);
    }
}
