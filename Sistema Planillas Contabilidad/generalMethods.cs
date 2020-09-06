using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    class generalMethods
    {
        public bool isLowerCase(string value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public string eraseStringUntilFlag(string value, string flag)
        {
            string storageLetters = "";
            char flagStart=flag[0];
            int stopIndex = 0;
            int sizeString = 0;
            bool found = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i]==flagStart && found==false)
                {
                    int advance = i;
                    stopIndex = i;
                    for (int x = 0; x < flag.Length; x++)
                    {
                        if(flag[x]== value[advance])
                        {
                            ++advance;
                            ++sizeString;
                        }
                        else
                        {
                            --sizeString;
                            if (sizeString==flag.Length)
                            {
                                found = true;
                                break;
                            }else
                            {
                                i = advance;
                                stopIndex = 0;
                                sizeString = 0;
                            }
                        }
                    }
                }
                if (found == true)
                {
                    break;
                }
                ++stopIndex;
            }

            if (found == true)
            {
                for (int a = 0; a < stopIndex; a++)
                {
                    storageLetters += value[a];
                }
                storageLetters = storageLetters.Replace(flag, "");
            }
            else
            {
                storageLetters = value;
            }
            
            return storageLetters;
        }
    }
}
