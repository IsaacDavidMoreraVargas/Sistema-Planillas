using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    class generalDataAndAvoidData
    {
        

        public bool compareAndFindAvoidItems(string itemToCompare)
        {
            string[] listAvoidItem = { "configuration", "exclusiveData", "Sits", "DEPARTAMENTOS" };
            bool itemFound = false;
            foreach (string item in listAvoidItem)
            {
                if (item.Contains(itemToCompare))
                {
                    itemFound = true;
                    break;
                }
            }
            return itemFound;
        }

        public bool avoidColumns(string itemToCompare)
        {
            string[] listAvoidItem = { "INDEX", "CEDULA","NOMBRE","FECHA INGRESO","APELLIDO 1", "APELLIDO 2" };
            bool itemFound = false;
            foreach (string item in listAvoidItem)
            {
                if (item.Contains(itemToCompare))
                {
                    itemFound = true;
                    break;
                }
            }
            return itemFound;
        }

        public string eraseWhiteSpacesInString(string stringToClean)
        {
            int maximunSizeString = stringToClean.Length;
            string storageLetter = " ";
            for (int letter = 0; letter < maximunSizeString; letter++)
            {
                if (letter == 0 && stringToClean[letter] == ' ' || letter == 0 && stringToClean[letter] == ' ')
                {
                    continue;
                }
                else
                {
                    storageLetter += stringToClean[letter];
                }
            }
            return storageLetter;
        }
    }
}
