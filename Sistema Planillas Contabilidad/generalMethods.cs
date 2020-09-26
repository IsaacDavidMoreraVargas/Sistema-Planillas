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
            char flagStart = flag[0];
            int stopIndex = 0;
            int sizeString = 0;
            bool found = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == flagStart && found == false)
                {
                    int advance = i;
                    stopIndex = i;
                    for (int x = 0; x < flag.Length; x++)
                    {
                        if (flag[x] == value[advance])
                        {
                            ++advance;
                            ++sizeString;
                        }
                        else
                        {
                            --sizeString;
                            if (sizeString == flag.Length)
                            {
                                found = true;
                                break;
                            }
                            else
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

        public string eraseFirstWhiteSpace(string value)
        {
            if (value[0] == ' ')
            {
                string storageString = "";
                for (int letter = 1; letter < value.Length; letter++)
                {

                    storageString += value[letter];
                }
                return storageString;
            }
            else
            {
                return value;
            }

        }

        public string[] getFoldersOFWeeks(string number)
        {
            int maximun = Int32.Parse(number);
            int endWeek = 7;
            int limit = 0;
            string maximunNumberFolder = "";

            for (int start = 1; start < maximun; start++)
            {
                if (start == endWeek)
                {
                    if (limit < 3)
                    {
                        maximunNumberFolder += start.ToString() + ",";
                        endWeek += 7;
                        ++limit;
                    }
                }
            }

            string[] storageStart = maximunNumberFolder.Split(',');
            string[] returnFolders = new string[4];
            returnFolders[0] = (Int32.Parse(storageStart[0]) - 6) + "-" + storageStart[0]; //1-7
            returnFolders[1] = (Int32.Parse(storageStart[1]) - 6) + "-" + storageStart[1]; //8-14
            returnFolders[2] = (Int32.Parse(storageStart[2]) - 6) + "-" + storageStart[2]; //15-21
            returnFolders[3] = (Int32.Parse(storageStart[2]) + 1) + "-" + number; //22-
            return returnFolders;
        }

        public string[] orderingMonth(string[] arrayOfMonth, string[] months)
        {
            List<int> positionNumber = new List<int>();
            for (int firstDate = 0; firstDate < months.Length; firstDate++)
            {
                for (int secondDate = 0; secondDate < arrayOfMonth.Length; secondDate++)
                {
                    if (arrayOfMonth[secondDate] == months[firstDate])
                    {
                        positionNumber.Add(firstDate);
                        break;
                    }
                }
            }
            string[] sendMonth = new string[positionNumber.Count];
            int indexToMove = 0;
            foreach (int number in positionNumber)
            {
                sendMonth[indexToMove] = months[number];
                ++indexToMove;
            }
            return sendMonth;
        }

        public bool findDataInArray(string[] arrayReceived, string valueToFind)
        {
            bool found = false;
            foreach (string data in arrayReceived)
            {
                if(data == valueToFind)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public bool findDataInList(List<string> arrayReceived, string valueToFind)
        {
            bool found = false;
            foreach (string data in arrayReceived)
            {
                if (data == valueToFind)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
