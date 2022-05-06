namespace Aruhaz.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// asd.
    /// </summary>
    internal class MainProductLogic : IMainProductLogic
    {
        static RestService rest;

        public void ApiDelTermek(TermekVM termek, ObservableCollection<TermekVM> list)
        {
            rest.Delete(termek.TermekID.ToString(), "product");
            list.Remove(termek);
        }

        public List<TermekVM> ApiGetTermek()
        {
            rest = new RestService("http://localhost:54068/", "product");
            List<TermekVM> products = rest.Get<TermekVM>("product");

            return products;
        }

        public void EditTermek(TermekVM termek, ObservableCollection<TermekVM> list, Func<TermekVM, bool> editorFunc)
        {
            TermekVM clone = new TermekVM();
            decimal regiNev = -1;
            if (termek != null)
            {
                clone.CopyFrom(termek);
                regiNev = termek.TermekID;
            }

            bool? success = editorFunc?.Invoke(clone);
            if (success == true)
            {
                if (termek != null)
                {
                    rest.Put(clone, "product");
                    int index = list.IndexOf(termek);
                    list[index] = clone;
                }
                else
                {
                    rest.Post(clone, "product");
                    list.Add(clone);
                }
            }
        }
    }
}
