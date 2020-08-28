using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    class generalDataAndAvoidData
    {
        string[] listAvoidItem = { "configuration", "exclusiveData", "Sits", "DEPARTAMENTOS"};

        public bool compareAndFindAvoidItems(string itemToCompare)
        {
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
