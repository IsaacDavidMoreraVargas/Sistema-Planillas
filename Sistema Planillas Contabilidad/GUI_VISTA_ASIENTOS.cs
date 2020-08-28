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
        List<string> receivedList = new List<string>();
        private void GUI_VISTA_ASIENTOS_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        string actual = Directory.GetCurrentDirectory();
        string separator2 = "+++++++++++";
        string codeHead = "CODIGO";
        string description = "DESCRIPCION";
        string debit = "DEBIT";
        string credit = "CREDIT";

        private void LoadData()
        {
            //dataGridView1.Columns[0].Visible = false;
            string actualPath = actual.Replace("\\bin\\Debug", "\\Companies");
            actualPath += "\\" + company + "\\exclusiveData" + "\\exclusive.txt";
            if (File.Exists(actualPath))
            {
                string[] id = File.ReadAllLines(actualPath);
                string idCompany = "";
                foreach (string item in id)
                {
                    idCompany += item;
                }
                labelID.Text +=": " + idCompany;
            }
            company = company.Replace("_", " ");
            labelCompany.Text = company;
            week = week.Replace("-", " AL ");
            labelWeek.Text = "PLANILLA SEMANAL: " + week;

            string pathCodeSits = Directory.GetCurrentDirectory();
            pathCodeSits = pathCodeSits.Replace("\\bin\\Debug", "\\configuration");
            pathCodeSits += "\\" + "codesSits" + "\\codes.Txt";
            dataGridView1.Rows.Add(dataGridView1.Rows.Count);
            foreach (string item in receivedList)
            {
                if (item == separator2)
                {
                    dataGridView1.Rows.Add("");
                }
            }

            List<string> listCodes = new List<string>();
            if (File.Exists(pathCodeSits))
            {
                string[] storageCodes = File.ReadAllLines(pathCodeSits);
                
                for (int list = 0; list < receivedList.Count; list++)
                {
                    string compare1 = receivedList[list];
                    compare1 = compare1.Replace(" ", "");
                    compare1 = compare1.Replace("\n", "");
                    for (int code = 0; code < storageCodes.Length; code++)
                    {
                        string compare2 = storageCodes[code];
                        compare2 = compare2.Replace(" ", "");
                        compare2 = compare2.Replace("\n", "");
                        if (compare2 == compare1)
                        {
                            listCodes.Add(codeHead);
                            listCodes.Add(storageCodes[++code]);
                            --code;
                            listCodes.Add(storageCodes[code]);
                            ++list;
                            break;
                        }
                    }
                    listCodes.Add(receivedList[list]);
                }
                
                int indexList = 0;
                int indexColum = 0;
                int indexRows = 0;

                for (int list = indexList; list < listCodes.Count; list++)
                {
                    if (listCodes[list] == separator2)
                    {
                        ++indexRows;
                        ++list;
                        indexColum = 0;
                    }
                    else
                    {
                        if (listCodes[list] == codeHead)
                        {
                            ++list;
                        }
                        else if (listCodes[list] == debit)
                        {
                            ++list;
                        }
                        else if (listCodes[list] == credit)
                        {
                            //++indexColum;
                            ++indexColum;
                            ++list;
                        }

                        int indexPoint = 0;
                        bool change = false;
                        string changeString= listCodes[list];
                        foreach (char numb in changeString)
                        {
                            if (numb == ',')
                            {
                                //++indexPoint;
                                change = true;
                                break;
                            }
                            else
                            {
                                ++indexPoint;
                            }
                        }
                        if (change == true)
                        {
                            //indexPoint += 2;
                            string result = "";
                            for (int numb = 0; numb < indexPoint; numb++)
                            {
                                result += changeString[numb];
                            }

                            changeString = result;
                        }
                        dataGridView1.Rows[indexRows].Cells[indexColum].Value = changeString;
                        ++indexColum;
                    }
                }

                int maximunColums = dataGridView1.Columns.Count;
                int maximunRows = dataGridView1.Rows.Count;
                maximunRows-=2;
                int maximunRows2 = dataGridView1.Rows.Count;
                maximunRows2-=2;
                List<int> indexDebtCredit = new List<int>();
                for (int column = 0; column < maximunColums; column++)
                {
                    if (dataGridView1.Columns[column].HeaderText == "DEBITO" || dataGridView1.Columns[column].HeaderText == "CREDITO")
                    {
                        indexDebtCredit.Add(column);
                    }
                }
                
                foreach (int index in indexDebtCredit)
                {
                    decimal sumNumbers = 0; //sum Numbers in array
                    for (int column = 0; column < maximunColums; column++)
                    {
                        if (column == index)
                        {
                            for (int row = 0; row < maximunRows; row++)
                            {
                                if (dataGridView1.Rows[row].Cells[0].Value.ToString() == "DEPARTAMENTO")
                                {
                                    for (int colorCell = 0; colorCell < maximunColums; colorCell++)
                                    {
                                        dataGridView1.Rows[row].Cells[colorCell].Style.BackColor = Color.LightBlue;
                                    }
                                }
                                else
                                {
                                    if (dataGridView1.Rows[row].Cells[column].Value == null || dataGridView1.Rows[row].Cells[column].Value.ToString() == "" || dataGridView1.Rows[row].Cells[column].Value.ToString() == " ")
                                    {
                                        sumNumbers += 0;
                                    }
                                    else
                                    {
                                       // MessageBox.Show(dataGridView1.Rows[row].Cells[column].Value.ToString());
                                        string number = dataGridView1.Rows[row].Cells[column].Value.ToString();
                                        sumNumbers += decimal.Parse(number);
                                    }
                                }
                            }
                        }
                    }
                    
                    calculateSystem callingFormat = new calculateSystem();
                    dataGridView1.Rows[maximunRows2].Cells[index].Value = callingFormat.convertAndFormat(sumNumbers.ToString());
                    //dataGridView1.Rows[maximunRows2].Cells[index].Value = sumNumbers.ToString();
                    //dataGridView1.Rows[maximunRows2].Cells[index].Value = sumNumbers.ToString();
                
                }
                
                
                bool equalData = false;
                foreach (int index in indexDebtCredit)
                {
                    for (int column = 0; column < maximunColums; column++)
                    {
                        if (column == index)
                        {
                            string value1 = dataGridView1.Rows[maximunRows2].Cells[column].Value.ToString();
                            ++column;
                            string value2 = dataGridView1.Rows[maximunRows2].Cells[column].Value.ToString();
                            if (value2 == value1)
                            {
                                equalData = true;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }   
                    }
                    if (equalData == true)
                    {
                        for (int column = 0; column < maximunColums; column++)
                        {
                            dataGridView1.Rows[maximunRows2].Cells[column].Style.BackColor = Color.LightGreen;
                        }
                        break;
                    }
                    else
                    {
                        for (int column = 0; column < maximunColums; column++)
                        {
                            dataGridView1.Rows[maximunRows2].Cells[column].Style.BackColor = Color.LightSalmon;
                        }
                        break;
                    }
                }
                
            }
        }

        public void receiveArray(List<string> receivedArray)
        {
            receivedList = receivedArray;
        }

        string path = "";
        string company = "";
        string deparment = "";
        string month = "";
        string week = "";
        string file = "";
        public void PathToSave(string companyReceive, string deptReceive, string monthReceive, string weekReceive, string fileReceive, string pathReceive)
        {
            path = pathReceive;
            company = companyReceive;
            deparment = deptReceive;
            month = monthReceive;
            week = weekReceive;
            file = fileReceive;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
