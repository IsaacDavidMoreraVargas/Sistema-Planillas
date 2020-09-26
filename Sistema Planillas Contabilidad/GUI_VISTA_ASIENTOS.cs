using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_VISTA_ASIENTOS : Form
    {
        public GUI_VISTA_ASIENTOS()
        {
            InitializeComponent();
        }

        string CorePathOfFolderSistemaPlanillas = "";
        string CorePathOfFolderCompaniesSistemaPlanillas = "";
        string CorePathOfCoreConfigurationFolderSistemaPlanillas = "";

        string SpecificPathOfFolderConfigurationAvoidData = "";
        string SpecificPathOfFolderConfigurationCodesSits = "";
        string SpecificPathOfFolderConfigurationDaysOfMoths = "";
        string SpecificPathOfFolderConfigurationFormulas = "";
        string SpecificPathOfFolderConfigurationSits = "";
        string SpecificPathOfFolderConfigurationTemplates = "";
        string SpecificPathOfFolderConfigurationPictures = "";

        string threeLine = "";
        string deparmentValue = "";

        string coreExtraConfiguration = "";
        string formula = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";
        string tagEndHEad = "";

        string tagStartFormula = "";
        string tagEndFormula = "";
        string tagStartChargeFormula = "";
        string tagEndChargeFormula = "";
        string tagStartDebitFormula = "";
        string tagEndDebitFormula = "";
        string tagStartCreditFormula = "";
        string tagEndCreditFormula = "";

        SpecificAndCorePaths startThePaths;
        TagsAndDefaultValues startTheTagsAndDefaults;
        FoldersInsideCompany startFoldersInsideCompany;
        //generalMethods callToGeneralMethods = new generalMethods();

        public void MethodToReceivedAccesToObject(SpecificAndCorePaths startThePathsReceived, TagsAndDefaultValues startTheTagsAndDefaultsReceived, FoldersInsideCompany startFoldersInsideCompanyReceived)
        {
            //receiving object reference
            startThePaths = startThePathsReceived;
            startTheTagsAndDefaults = startTheTagsAndDefaultsReceived;
            startFoldersInsideCompany = startFoldersInsideCompanyReceived;
            //core paths
            CorePathOfFolderSistemaPlanillas = startThePaths.CorePathOfFolderSistemaPlanillas;
            CorePathOfFolderCompaniesSistemaPlanillas = startThePaths.CorePathOfCompaniesFolderSistemaPlanillas;
            CorePathOfCoreConfigurationFolderSistemaPlanillas = startThePaths.CorePathOfConfigurationFolderSistemaPlanillas;
            //specific paths
            SpecificPathOfFolderConfigurationAvoidData = startThePaths.SpecificPathOfConfigurationFolderAvoidData;
            SpecificPathOfFolderConfigurationCodesSits = startThePaths.SpecificPathOfConfigurationFolderCodesSits;
            SpecificPathOfFolderConfigurationDaysOfMoths = startThePaths.SpecificPathOfConfigurationFolderDaysOfMoths;
            SpecificPathOfFolderConfigurationFormulas = startThePaths.SpecificPathOfConfigurationFolderFormulas;
            SpecificPathOfFolderConfigurationSits = startThePaths.SpecificPathOfConfigurationFolderSits;
            SpecificPathOfFolderConfigurationTemplates = startThePaths.SpecificPathOfConfigurationFolderTemplates;
            SpecificPathOfFolderConfigurationPictures = startThePaths.SpecificPathOfConfigurationFolderPictures;
            //default values
            threeLine = startTheTagsAndDefaults.tripleLine;
            deparmentValue = startTheTagsAndDefaults.isDeparment;
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
            tagStartFormula = startTheTagsAndDefaults.tagStartFormula;
            tagEndFormula = startTheTagsAndDefaults.tagEndFormula;
            tagStartChargeFormula = startTheTagsAndDefaults.tagStartChargeFormula;
            tagEndChargeFormula = startTheTagsAndDefaults.tagEndChargeFormula;
            tagStartDebitFormula = startTheTagsAndDefaults.tagStartDebitFormula;
            tagEndDebitFormula = startTheTagsAndDefaults.tagEndDebitFormula;
            tagStartCreditFormula = startTheTagsAndDefaults.tagStartCreditFormula;
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            formula = startFoldersInsideCompany.isFormula;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;
        }

        private void GUI_VISTA_ASIENTOS_Load(object sender, EventArgs e)
        {
            loadDefaultData();
        }

        string debit = "DEBIT";
        string credit = "CREDIT";
        string option1 = "LOCAL";
        string option2 = "MEDIO";
        string option3 = "GLOBAL";
        string orderLocalOrGlobal = "";
        string[] storageCodes = new string[0];
        string departamento = "DEPART";
        private void loadDefaultData()
        {
            labelCompany.Text = company;
            //
            string pathOfHeadsAndFormulas = "";
            List<string> chargeFormulas = new List<string>();
            List<string> copyChargeFormulas = new List<string>();
            List<string> formulasDebitGlobal = new List<string>();
            List<string> formulasCreditGlobal = new List<string>();
            List< List<string>> formulasDebit = new List<List<string>>();
            List<List<string>> formulasCredit = new List<List<string>>();

            bool allowFormulas = false;
            bool allowCodes = false;
            if (orderLocalOrGlobal == option2)
            {
                pathOfHeadsAndFormulas = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + sits + "\\" + "CORE-FORMULAS-SITS.txt";
            }
            else if (orderLocalOrGlobal == option3)
            {
                pathOfHeadsAndFormulas = SpecificPathOfFolderConfigurationSits + "GLOBAL-FORMULAS-SITS.txt";
            }

            if (orderLocalOrGlobal == option1)
            {
                foreach (string formulas in receivedListOfFormulas)
                {
                    string[] storageHeadsAndFormulas = File.ReadAllLines(formulas);
                    List<string> chargeFormulasPhase2 = new List<string>();
                    List<string> copyChargeFormulasPhase2 = new List<string>();
                    foreach (string formula in storageHeadsAndFormulas)
                    {
                        if (formula == tagEndChargeFormula)
                        {
                            break;
                        }
                        else if (formula != tagStartChargeFormula)
                        {
                            chargeFormulasPhase2.Add(formula);
                            copyChargeFormulasPhase2.Add(formula);
                        }
                    }

                    foreach(string comparePhase1 in chargeFormulasPhase2)
                    {
                        bool found = false;
                        foreach (string comparePhase2 in chargeFormulas)
                        {
                            if(comparePhase1==comparePhase2)
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            chargeFormulas.Add(comparePhase1);
                            copyChargeFormulas.Add(comparePhase1);
                        }
                    }
                    formulasDebit.Add(setFormulasDebit(chargeFormulas, storageHeadsAndFormulas));
                    formulasCredit.Add(setFormulasCredit(chargeFormulas, storageHeadsAndFormulas));
                }
                allowFormulas = true;
            }else if(orderLocalOrGlobal == option2 || orderLocalOrGlobal == option3)
            {
                if(File.Exists(pathOfHeadsAndFormulas))
                {
                    string[] storageHeadsAndFormulas = File.ReadAllLines(pathOfHeadsAndFormulas);
                    foreach (string formula in storageHeadsAndFormulas)
                    {
                        if (formula == tagEndChargeFormula)
                        {
                            break;
                        }
                        else if (formula != tagStartChargeFormula)
                        {
                            chargeFormulas.Add(formula);
                            copyChargeFormulas.Add(formula);
                        }
                    }
                    formulasDebitGlobal=setFormulasDebit(chargeFormulas, storageHeadsAndFormulas);
                    formulasCreditGlobal=setFormulasCredit(chargeFormulas, storageHeadsAndFormulas);
                }
                allowFormulas = true;
            }
            //MessageBox.Show(pathOfHeadsAndFormulas);
            string pathOfID = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + exclusiveData + "\\" + "exclusive.txt";
            if (File.Exists(pathOfID))
            {
                string[] storageID = File.ReadAllLines(pathOfID);
                labelID.Text = storageID[0];
            }
            //MessageBox.Show(pathOfID);
            string pathOfCodesSits = SpecificPathOfFolderConfigurationCodesSits + "codes.txt";
            if (File.Exists(pathOfCodesSits))
            {
                storageCodes = File.ReadAllLines(pathOfCodesSits);
                allowCodes = true;
            }

            if (allowCodes == true && allowFormulas == true && receivedListOfFiles.Count != 0)
            {
                generalMultiArrayMethods callToGetArrays = new generalMultiArrayMethods();
                callToGetArrays.MethodToReceivedAccesToObject(startTheTagsAndDefaults);
                List<string[,]> listArrays = callToGetArrays.methodToGetListOfArray(receivedListOfFiles);
                List<string> listResultsDebit = new List<string>();
                List<string> listResultsCredit = new List<string>();
                string[,] results = new string[listArrays[0].GetLength(0), listArrays[0].GetLength(1)];
                for (int item = 0; item < listArrays.Count; item++)
                {
                    string[] splitName = receivedListOfFiles[item].Split('\\');
                    string resultTotal = departamento + "?"+splitName[splitName.Length-3]+"?"+" "+"?"+" "+"\n";
                    string[,] storageStudy = listArrays[item];
                    if (orderLocalOrGlobal == option2 || orderLocalOrGlobal == option3)
                    {
                        resultTotal += fullFormulasDebit(formulasDebitGlobal, chargeFormulas, copyChargeFormulas, storageStudy);
                    }
                    else if (orderLocalOrGlobal == option1)
                    {
                        resultTotal += fullFormulasDebit(formulasDebit[item], chargeFormulas, copyChargeFormulas, storageStudy);
                    }
                    //MessageBox.Show(resultTotal);
                    listResultsDebit.Add(resultTotal);
                }
                // MessageBox.Show(resultTotal);
                /////////////////////////no borrar se necesita la suma para el debito
                for (int item = 0; item < listArrays.Count; item++)
                {
                    string[,] storageStudy = listArrays[item];
                    for (int column = 0; column < storageStudy.GetLength(1); column++)
                    {
                        results[0, column] = storageStudy[0, column];
                        decimal sum = 0;
                        try
                        {
                            for (int row = 1; row < storageStudy.GetLength(0); row++)
                            {
                                if (storageStudy[row, column].Contains("-"))
                                {
                                    sum -= Convert.ToDecimal(storageStudy[row, column]);
                                }
                                else
                                {
                                    sum += Convert.ToDecimal(storageStudy[row, column]);
                                }
                            }
                            if (listArrays.Count > 1)
                            {
                                for (int itemPhase2 = 1; itemPhase2 < listArrays.Count; itemPhase2++)
                                {
                                    string[,] storageStudyPhase2 = listArrays[itemPhase2];
                                    for (int columnPhase2 = 0; columnPhase2 < storageStudyPhase2.GetLength(1); columnPhase2++)
                                    {
                                        if (storageStudy[0, column] == storageStudyPhase2[0, columnPhase2])
                                        {
                                            for (int rowPhase2 = 1; rowPhase2 < storageStudyPhase2.GetLength(0); rowPhase2++)
                                            {
                                                if (storageStudyPhase2[rowPhase2, columnPhase2].Contains("-"))
                                                {
                                                    sum -= Convert.ToDecimal(storageStudyPhase2[rowPhase2, columnPhase2]);
                                                }
                                                else
                                                {
                                                    sum += Convert.ToDecimal(storageStudyPhase2[rowPhase2, columnPhase2]);
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            //MessageBox.Show(results[0, column]+"<>"+sum.ToString());
                            results[1, column] = Math.Round(sum).ToString();
                        }
                        catch (Exception)
                        {
                            results[0, column] = "FALSE";
                            results[1, column] = "FALSE";
                        }
                    }
                    if (orderLocalOrGlobal == option2 || orderLocalOrGlobal == option3)
                    {
                        string resultTotal = fullFormulasCredit(formulasCreditGlobal, chargeFormulas, copyChargeFormulas, results);
                        listResultsCredit.Add(resultTotal);
                    }
                    else if (orderLocalOrGlobal == option1)
                    {
                        string resultTotal = fullFormulasCredit(formulasCredit[item], chargeFormulas, copyChargeFormulas, results);
                        listResultsCredit.Add(resultTotal);
                    }
                    break;
                }

                fullFinalRowsWithDebitAndCredit(listResultsDebit, listResultsCredit);
            }
            else
            {
                MessageBox.Show("NO SE CREARAN LOS ASIENTOS \nPOSIBLES PROBLEMAS \n-NO EXISTEN FORMULAS \n-NO EXISTEN CODIGOS PARA ASIENTOS \n-NO EXISTEN TOTALES A CALCULAR");
            }

        }

        List<string> receivedListOfFiles = new List<string>();
        List<string> receivedListOfFormulas = new List<string>();
        public void receiveArrayOfFilesAndFormulas(List<string> receivedList, List<string> receivedFormulas)
        {
            receivedListOfFiles = receivedList;
            receivedListOfFormulas = receivedFormulas;
        }

        private List<string> setFormulasDebit(List<string> chargeFormulas, string[] storageHeadsAndFormulas)
        {
            List<string> returnList = new List<string>();
            List<string> formulasDebit = new List<string>();
            for (int formula = 0; formula < storageHeadsAndFormulas.Length; formula++)
            {
                if (storageHeadsAndFormulas[formula] == tagStartDebitFormula)
                {
                    ++formula;
                    for (int formulaPhase2 = formula; formulaPhase2 < storageHeadsAndFormulas.Length; formulaPhase2++)
                    {
                        if (storageHeadsAndFormulas[formulaPhase2] == tagEndDebitFormula)
                        {
                            break;
                        }
                        else if (storageHeadsAndFormulas[formulaPhase2] != tagStartFormula && storageHeadsAndFormulas[formulaPhase2] != tagEndFormula)
                        {
                            returnList.Add(storageHeadsAndFormulas[formulaPhase2]);
                        }
                    }
                    break;
                }
            }

            foreach (string head in chargeFormulas)
            {
                foreach (string compare in returnList)
                {
                    string[] splitData = compare.Split('=');
                    if (head == splitData[0])
                    {
                        string changeString = compare;
                        changeString = changeString.Replace("+", "?+?");
                        changeString = changeString.Replace("-", "?-?");
                        changeString = changeString.Replace("*", "?*?");
                        changeString = changeString.Replace("/", "?/?");
                        formulasDebit.Add(changeString);
                        break;
                    }
                }
            }

            return formulasDebit;
        }

        private List<string> setFormulasCredit(List<string> chargeFormulas, string[] storageHeadsAndFormulas)
        {
            List<string> returnList = new List<string>();
            List<string> formulasCredit = new List<string>();
            for (int formula = 0; formula < storageHeadsAndFormulas.Length; formula++)
            {
                if (storageHeadsAndFormulas[formula] == tagStartCreditFormula)
                {
                    ++formula;
                    for (int formulaPhase2 = formula; formulaPhase2 < storageHeadsAndFormulas.Length; formulaPhase2++)
                    {
                        if (storageHeadsAndFormulas[formulaPhase2] == tagEndCreditFormula)
                        {
                            break;
                        }
                        else if (storageHeadsAndFormulas[formulaPhase2] != tagStartFormula && storageHeadsAndFormulas[formulaPhase2] != tagEndFormula)
                        {
                            returnList.Add(storageHeadsAndFormulas[formulaPhase2]);
                        }
                    }
                    break;
                }
            }

            foreach (string head in chargeFormulas)
            {
                foreach (string compare in returnList)
                {
                    string[] splitData = compare.Split('=');
                    if (head == splitData[0])
                    {
                        string changeString = compare;
                        changeString = changeString.Replace("+", "?+?");
                        changeString = changeString.Replace("-", "?-?");
                        changeString = changeString.Replace("*", "?*?");
                        changeString = changeString.Replace("/", "?/?");
                        formulasCredit.Add(changeString);
                        break;
                    }
                }
            }

            return formulasCredit;
        }

        private string fullFormulasDebit(List<string> formulasDebit, List<string> formulasHead, List<string> formulasHeadCopy, string[,] storageData)
        {
            calculateSystem callToCalculate = new calculateSystem();
            string returnString = "";
            for (int formula = 0; formula < formulasDebit.Count; formula++)
            {
                string[] splitData = formulasDebit[formula].Split('=');
                string[] splitParts = splitData[1].Split('?');
                for (int part = 0; part < splitParts.Length; part++)
                {
                    for (int partData = 0; partData < storageData.GetLength(1); partData++)
                    {
                        if (storageData[0, partData] == splitParts[part])
                        {
                            splitParts[part] = storageData[1, partData];
                            break;
                        }
                    }
                }
                for (int part = 0; part < splitParts.Length; part++)
                {
                    for (int partData = 0; partData < formulasHead.Count; partData++)
                    {
                        if (formulasHead[partData] == splitParts[part])
                        {
                            splitParts[part] = formulasHeadCopy[partData];
                            break;
                        }
                    }
                }
                string returnNumber = callToCalculate.recieveArray(splitParts);
                //returnNumber = Math.Round(Convert.ToDouble(returnNumber)).ToString();
                string resultCode = findCode(storageCodes, splitData[0]);
                returnString += resultCode+"?"+splitData[0] + "?" + returnNumber + "?" + " "+ "\n";
                for (int part = 0; part < formulasHead.Count; part++)
                {
                    if (formulasHead[part] == splitData[0])
                    {
                        formulasHeadCopy[part] = returnNumber;
                        break;
                    }
                }

            }
            
            return returnString;
        }

        private string fullFormulasCredit(List<string> formulasCredit, List<string> formulasHead, List<string> formulasHeadCopy, string[,] storageData)
        {
            calculateSystem callToCalculate = new calculateSystem();
            string returnString = "";
            for (int formula = 0; formula < formulasCredit.Count; formula++)
            {
                string[] splitData = formulasCredit[formula].Split('=');
                string[] splitParts = splitData[1].Split('?');
                for (int part = 0; part < splitParts.Length; part++)
                {
                    for (int partData = 0; partData < storageData.GetLength(1); partData++)
                    {
                        if (storageData[0, partData] == splitParts[part])
                        {
                            splitParts[part] = storageData[1, partData];
                            break;
                        }
                    }
                }
                for (int part = 0; part < splitParts.Length; part++)
                {
                    for (int partData = 0; partData < formulasHead.Count; partData++)
                    {
                        if (formulasHead[partData] == splitParts[part])
                        {
                            splitParts[part] = formulasHeadCopy[partData];
                            break;
                        }
                    }
                }
                string returnNumber = callToCalculate.recieveArray(splitParts);
                //returnNumber = Math.Round(Convert.ToDouble(returnNumber)).ToString();
                string resultCode = findCode(storageCodes, splitData[0]);
                returnString += resultCode + "?" + splitData[0] + "?" + " "  + "?" + returnNumber+ "\n";
                for (int part = 0; part < formulasHead.Count; part++)
                {
                    if (formulasHead[part] == splitData[0])
                    {
                        formulasHeadCopy[part] = returnNumber;
                        break;
                    }
                }

            }
            return returnString;
        }

        private void fullFinalRowsWithDebitAndCredit(List<string> formulasDebit, List<string> formulasCredit)
        {
            int Row = 0;
            foreach (string formula in formulasDebit)
            {
                string[] storageDebit = formula.Split('\n');
                for (int part = 0; part < storageDebit.Length; part++)
                {
                    string[] storageDebitPhase2 = storageDebit[part].Split('?');
                    if (storageDebitPhase2.Length != 1)
                    {
                        dataGridView1.Rows.Add(Row.ToString());
                        for (int column = 0; column < dataGridView1.Columns.Count; column++)
                        {
                            dataGridView1.Rows[Row].Cells[column].Value = storageDebitPhase2[column];
                        }
                        ++Row;
                    }
                }
            }
            foreach (string formula in formulasCredit)
            {
                string[] storageCredit = formula.Split('\n');
                for (int part = 0; part < storageCredit.Length; part++)
                {
                    string[] storageDebitPhase2 = storageCredit[part].Split('?');
                    if (storageDebitPhase2.Length != 1)
                    {
                        dataGridView1.Rows.Add(Row.ToString());
                        for (int column = 0; column < dataGridView1.Columns.Count; column++)
                        {
                            dataGridView1.Rows[Row].Cells[column].Value = storageDebitPhase2[column];
                        }
                        ++Row;
                    }
                }
            }

            for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
            {
                if (dataGridView1.Rows[row].Cells[0].Value.ToString() == departamento)
                {
                    for (int column = 0; column < dataGridView1.Columns.Count; column++)
                    {
                        dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.LightBlue;
                    }
                }
            }
            string compare1 ="";
            string compare2 ="";
            bool allowCompare1 = false;
            bool allowCompare2 = false;
            calculateSystem callToFormat = new calculateSystem();
            for (int column = 0; column < dataGridView1.Columns.Count; column++)
            {
                if (dataGridView1.Columns[column].HeaderText == "DEBITO"  )
                {
                    allowCompare1 = true;
                }
                else if(dataGridView1.Columns[column].HeaderText == "CREDITO")
                {
                    allowCompare2 = true;
                }
                if(allowCompare1 ==true || allowCompare2 == true)
                { 
                    decimal sum = 0;
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                    {
                        if (dataGridView1.Rows[row].Cells[column].Value == null || dataGridView1.Rows[row].Cells[column].Value.ToString() == " " || dataGridView1.Rows[row].Cells[column].Value.ToString() == "")
                        {
                            sum += 0;
                        }
                        else if ((dataGridView1.Rows[row].Cells[column].Value.ToString().Contains("-")))
                        {
                            sum -= Convert.ToDecimal(dataGridView1.Rows[row].Cells[column].Value.ToString());
                        }
                        else
                        {
                            sum += Convert.ToDecimal(dataGridView1.Rows[row].Cells[column].Value.ToString());
                        }
                    }
                    string change = Math.Round(sum,0).ToString();
                    change = callToFormat.convertAndFormatSHORT(sum.ToString());
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[column].Value = change;
                    if (allowCompare1 == true)
                    {
                        compare1 = change.ToString();
                    }
                    else if (allowCompare2 == true)
                    {
                        compare2 = change.ToString();
                    }
                    allowCompare1 = false;
                    allowCompare2 = false;
                }
            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "TOTAL";
            for (int column = 0; column < dataGridView1.Columns.Count; column++)
            {
                if(compare1==compare2)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[column].Style.BackColor = Color.LightGreen;
                }else
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[column].Style.BackColor = Color.LightSalmon;
                }
            }
        }

        private string findCode(string []arrayReceived, string flag)
        {
            string codeNumber = "";
            for(int code=0; code<arrayReceived.Length; code++)
            {
                if(arrayReceived[code]==flag)
                {
                    ++code;
                    codeNumber = arrayReceived[code];
                    break;
                }
            }
            return codeNumber;
        }

        string company = "";
        public void PathToCompany(string companyReceived)
        {
            company = companyReceived;
        }

        public void orderGlobalOrLocal(string receivedOrder)
        {
            orderLocalOrGlobal = receivedOrder;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
