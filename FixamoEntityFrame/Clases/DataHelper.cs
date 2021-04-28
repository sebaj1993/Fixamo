using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixamoEntityFrame.Clases
{
    public static class DataHelper
    {
        public static AutoCompleteStringCollection LoadAutoComplete(List<string> lista)
        {
            List<string> dt = lista;

            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (string nombre in dt)
            {
                stringCol.Add(nombre);
            }

            return stringCol;
        }
    }
}
