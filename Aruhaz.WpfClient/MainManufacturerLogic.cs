namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class MainManufacturerLogic : IMainManufacturerLogic
    {
        static RestService rest;

        public void ApiDelGyarto(GyartoVM gyarto, ObservableCollection<GyartoVM> list)
        {
            rest.Delete(gyarto.GyartoNeve, "manufacturer");
            list.Remove(gyarto);
        }

        public List<GyartoVM> ApiGetGyarto()
        {
            rest = new RestService("http://localhost:54068/", "manufacturer");
            List<GyartoVM> manufacturers = rest.Get<GyartoVM>("manufacturer");

            return manufacturers;
        }

        public void EditGyarto(GyartoVM gyarto, ObservableCollection<GyartoVM> list, Func<GyartoVM, bool> editorFunc)
        {
            GyartoVM clone = new GyartoVM();
            string regiNev = string.Empty;
            if (gyarto != null)
            {
                clone.CopyFrom(gyarto);
                regiNev = gyarto.GyartoNeve;
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (gyarto != null)
                {
                    rest.Put(clone, "manufacturer");
                    int index = list.IndexOf(gyarto);
                    list[index] = clone;
                }
                else
                {
                    rest.Post(clone, "manufacturer");
                    list.Add(clone);
                }
            }
        }
    }
}
