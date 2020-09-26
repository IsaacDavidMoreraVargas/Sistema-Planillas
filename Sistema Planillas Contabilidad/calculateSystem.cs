using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    class calculateSystem
    {
        public string recieveArray(string[] arrayReceived)
        {
            decimal numberData = 0;
            decimal numberStudy = 0;
            for (int item = 0; item < arrayReceived.Length; item++)
            {
                if (item == 0)
                {
                    if (arrayReceived[item] == null || arrayReceived[item] == " " || arrayReceived[item] == "")
                    {
                        numberStudy += 0;
                    }
                    else
                    {
                        if (arrayReceived[item].Contains("%"))
                        {
                            string evaluate = arrayReceived[item];
                            evaluate = evaluate.Replace("%", "");
                            evaluate = evaluate.Replace(".", ",");
                            decimal parseAgain = decimal.Parse(evaluate);
                            numberStudy += parseAgain / 100;
                        }
                        else 
                        {
                            try
                            {
                                string evaluate = arrayReceived[item];
                                numberStudy += decimal.Parse(evaluate);
                            }
                            catch (Exception)
                            {
                                numberStudy+=0;
                                break;
                            }
                           
                        }
                        
                    }
                }
                else
                {
                    switch (arrayReceived[item])
                    {
                        case "+":
                            try
                            {
                                ++item;
                                if (arrayReceived[item] == null || arrayReceived[item] == " " || arrayReceived[item] == "")
                                {
                                    numberData = 0;
                                }
                                else
                                {
                                    if (arrayReceived[item].Contains("%"))
                                    {
                                        string evaluate = arrayReceived[item];
                                        evaluate = evaluate.Replace(".", ",");
                                        numberData = decimal.Parse(evaluate.Replace("%", "")) / 100;
                                    }
                                    else
                                    {
                                        string evaluate = arrayReceived[item];
                                        numberData = decimal.Parse(evaluate);
                                    }
                                }

                            }
                            catch (Exception)
                            { numberData = 0; }

                            numberStudy += numberData;

                            break;
                        case "-":
                            try
                            {
                                ++item;
                                if (arrayReceived[item] == null || arrayReceived[item] == " " || arrayReceived[item] == "")
                                {
                                    numberData = 0;
                                }
                                else
                                {
                                    if (arrayReceived[item].Contains("%"))
                                    {
                                        string evaluate = arrayReceived[item];
                                        evaluate = evaluate.Replace(".", ",");
                                        numberData = decimal.Parse(evaluate.Replace("%", "")) / 100;
                                    }
                                    else
                                    {
                                        string evaluate = arrayReceived[item];
                                        numberData = decimal.Parse(evaluate);
                      
                                    }
                                }
                            }
                            catch (Exception)
                            { numberData = 0;}

                            numberStudy -= numberData;

                            break;
                        case "/":
                            try
                            {
                                ++item;
                                if (arrayReceived[item] == null || arrayReceived[item] == " " || arrayReceived[item] == "")
                                {
                                    numberData = 0;
                                }
                                else
                                {
                                    if (arrayReceived[item].Contains("%"))
                                    {
                                        string evaluate = arrayReceived[item];
                                        evaluate = evaluate.Replace(".",",");
                                        numberData = decimal.Parse(evaluate.Replace("%", "")) / 100;
                                    }
                                    else
                                    {
                                        string evaluate = arrayReceived[item];
                                        numberData = decimal.Parse(evaluate);

                                    }
                                }
                            }
                            catch (Exception)
                            { numberData = 1; }
                            
                            numberStudy /= numberData;
                            
                            break;
                        case "*":
                            try
                            {
                                ++item;
                                if (arrayReceived[item] == null || arrayReceived[item] == " " || arrayReceived[item] == "")
                                {
                                    numberData = 0;
                                }
                                else
                                {
                                    if (arrayReceived[item].Contains("%"))
                                    {
                                        string evaluate = arrayReceived[item];
                                        evaluate = evaluate.Replace(".", ",");
                                        numberData = decimal.Parse(evaluate.Replace("%", "")) / 100;
                                    }
                                    else
                                    {
                                        string evaluate = arrayReceived[item];
                                        numberData = decimal.Parse(evaluate);
                                    }
                                }
                            }
                            catch (Exception)
                            { numberData = 0; }

                            numberStudy *= numberData;

                            break;
                     }
                }
               
            }
            if (numberStudy < 0)
            {
                return "0";
            }
            else
            {
                numberStudy = Math.Round(numberStudy, 2);
                //string numberStudySend = string.Format("{0:#,00}", numberStudy);
                //return numberStudySend;
                return numberStudy.ToString();
            }
        }

        public string correctString(string sendData)
        {
            string unNumero = "false";
            int lastPoint = 0;
            int findPoint = 0;
            string saveString = "";
            bool allowChange = false;
            foreach (char letter in sendData)
            {
                if (letter == ',')
                {
                    ++lastPoint;
                }
            }

            for (int addPoint = 0; addPoint < sendData.Length; addPoint++)
            {
                if (sendData[addPoint] == ',')
                {
                    saveString += sendData[addPoint];
                    ++addPoint;
                    ++findPoint;
                    if (findPoint == lastPoint)
                    {
                        int end = sendData.Length - addPoint;
                        if (end > 3)
                        {
                            int end2 = addPoint + 3;
                            for (int addPoint2 = addPoint; addPoint2 < end2; addPoint2++)
                            {
                                saveString += sendData[addPoint2];
                            }
                            try
                            {
                                saveString += ".";
                                addPoint += 3;
                                for (int addPoint2 = addPoint; addPoint2 < sendData.Length; addPoint2++)
                                {
                                    saveString += sendData[addPoint2];
                                }
                                allowChange = true;
                            }
                            catch (Exception) { }
                            break;
                        }
                    }
                }
                saveString += sendData[addPoint];
            }
            if (allowChange == true)
            {
                unNumero = saveString;
            }
            return unNumero;
        }

        public string convertAndFormat(string numberReceived)
        {
            string unNumero = "false";
            try
            {
                if (numberReceived.Contains("."))
                {
                    numberReceived = numberReceived.Replace(",","");
                    numberReceived = numberReceived.Replace(".", ",");
                }
                  
                decimal tryConvert = decimal.Parse(numberReceived);
                //MessageBox.Show(numberReceived);
                unNumero = string.Format("{0:0,0.00}", tryConvert);
            }
            catch (Exception)
            {}
            return unNumero;
        }

        public string convertAndFormatSHORT(string numberReceived)
        {
            string unNumero = "false";
            try
            {
                /*
                if (numberReceived.Contains("."))
                {
                    numberReceived = numberReceived.Replace(",","");
                    numberReceived = numberReceived.Replace(".", ",");
                }
                  */
                decimal tryConvert = decimal.Parse(numberReceived);
                unNumero = string.Format("{0:0,0}", tryConvert);
            }
            catch (Exception)
            {}
            return unNumero;
        }
        public string convertAndFormatLONG(string numberReceived)
        {
            string unNumero = "false";
            try
            {
                if (numberReceived.Contains("."))
                {
                    numberReceived = numberReceived.Replace(",","");
                    numberReceived = numberReceived.Replace(".", ",");
                }
                  
                decimal tryConvert = decimal.Parse(numberReceived);
                unNumero = string.Format("{0:0,0.00}", tryConvert);
            }
            catch (Exception)
            {}
            return unNumero;
        }
    }
}
