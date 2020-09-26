using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
   
    public partial class GUI_ELEGIR_COPIAR_COLUMNA : Form
    {
        string pathOnTime = "";
        string departmentOnTime = "";
        string monthOnTime = "";
        string weekOnTime = "";
        string dataOnTime = "";
        string replaceOnTime = "";
        bool department = false;
        bool month = false;
        bool week= false;
        bool data = false;
        bool replace = false;
        string startString = "-----";
        string separator1 = "-----------";
        string separator2 = "+++++++++++";
        string path = "";
        string dataStorage = "";
        string avoid1="configuration";
        string avoid2="exclusiveData";
        string avoid3="Sits";
        public GUI_ELEGIR_COPIAR_COLUMNA()
        {
            InitializeComponent();
        }

        private void GUI_ELEGIR_COPIAR_Load(object sender, EventArgs e)
        {
            chargeData();
        }
        
        private void chargeData()
        {
            string[] storagePath = path.Split('\\');
            int maximunPath = storagePath.Length;
            string addPath = "";
            maximunPath -= 4;
            for (int path = 0; path < maximunPath; path++)
            {
                addPath += storagePath[path] + "\\";
            }
            pathOnTime = addPath;
            string[] storageDepartments = Directory.GetDirectories(addPath);
            foreach (string dept in storageDepartments)
            {
                string erase = dept.Replace(addPath,"");
                erase = erase.Replace("_"," ");
                if(erase==avoid1||erase==avoid2||erase==avoid3)
                {
                
                }else
                {
                  comboBoxDepartment.Items.Add(erase);
                }
            }
        }

        private void LoadDepartment(object sender, EventArgs e)
        {
            comboBoxMonth.Items.Clear();
            department = true;
            departmentOnTime = comboBoxDepartment.Text;
            departmentOnTime = departmentOnTime.Replace(" ","_");
            string search = pathOnTime + "\\"+ departmentOnTime;
            string[] storageMonth = Directory.GetDirectories(search);
            foreach (string month in storageMonth)
            {
                string erase = month.Replace(search, "");
                erase = erase.Replace("_", " ");
                erase = erase.Replace("\\", "");
                comboBoxMonth.Items.Add(erase);
            }
        }

        private void LoadMonth(object sender, EventArgs e)
        {
            comboBoxWeek.Items.Clear();
            month = true;
            monthOnTime = comboBoxMonth.Text;
            monthOnTime = monthOnTime.Replace(" ", "_");
            string search = pathOnTime + "\\" + departmentOnTime + "\\" + monthOnTime;
            string[] storageWeek = Directory.GetDirectories(search);
            foreach (string week in storageWeek)
            {
                string erase = week.Replace(search, "");
                erase = erase.Replace("_", " ");
                erase = erase.Replace("\\", "");
                comboBoxWeek.Items.Add(erase);
            }
        }
        private void LoadWeek(object sender, EventArgs e)
        {
            comboBoxData.Items.Clear();
            week = true;
            weekOnTime = comboBoxWeek.Text;
            weekOnTime = weekOnTime.Replace(" ", "_");
            string search = pathOnTime + "\\" + departmentOnTime + "\\" + monthOnTime + "\\" + weekOnTime;
            string[] storageData = Directory.GetFiles(search);
            if (File.Exists(storageData[0]))
            {
                string[] lines = File.ReadAllLines(storageData[0]);
                foreach (string line in lines)
                {
                    if (line == separator1)
                    {
                        break;
                    }
                    else
                    {
                        comboBoxData.Items.Add(line);
                    }
                }
            }
            else 
            {
                MessageBox.Show("EL ARCHIVO QUE BUSCAS NO EXISTE");
            }
            
        }

        private void LoadData(object sender, EventArgs e)
        {
            comboBoxReplace.Items.Clear();
            comboBoxReplace.Items.Add("NUEVA COLUMNA");
            data = true;
            dataOnTime = comboBoxData.Text;
            if (File.Exists(path))
            {
                string[] storageData = dataStorage.Split('\n');
                foreach (string item in storageData)
                {
                    comboBoxReplace.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("EL ARCHIVO QUE BUSCAS NO EXISTE");
            }
        }

        private void LoadReplace(object sender, EventArgs e)
        {
            replace = true;
            replaceOnTime = comboBoxReplace.Text;
        }

        private void buttonImportData_Click(object sender, EventArgs e)
        {
            string falseAswer = "NO SE PUEDE REALIZAR LA IMPORTACION DE DATOS";
            if (department == false || comboBoxDepartment.Text == startString)
            {
                falseAswer += "\n-DEPARTAMENTO NO SLECCIONADO";
            }
            else if (month == false || comboBoxMonth.Text == startString)
            {
                falseAswer += "\n-MES NO SLECCIONADO";
            }
            else if (week == false || comboBoxWeek.Text == startString)
            {
                falseAswer += "\n-SEMANA NO SLECCIONADA";
            }
            else if (data == false || comboBoxWeek.Text == startString)
            {
                falseAswer += "\n-DATO NO SLECCIONADA";
            }
            else if (replace == false || comboBoxWeek.Text == startString)
            {
                falseAswer += "\n-'A' NO SLECCIONADA";
            }

            if (falseAswer == "NO SE PUEDE REALIZAR LA IMPORTACION DE DATOS")
            {
                List<string> storageLines = new List<string>();
                string search = pathOnTime + "\\" + departmentOnTime + "\\" + monthOnTime + "\\" + weekOnTime;
                string[] storageData = Directory.GetFiles(search);
                int indexFindData = 0;
                string[] lines = File.ReadAllLines(storageData[0]);
                int headSeparator1=0;
                int bodySeparator2 = 0;
                foreach (string line in lines)
                {
                    if (line == separator1)
                    {
                        ++bodySeparator2;
                        break;
                    }

                    if (line == dataOnTime)
                    {
                        indexFindData = headSeparator1;
                    }
                    ++headSeparator1;
                }

                foreach (string line in lines)
                {
                    if (line == separator2)
                    {
                        ++bodySeparator2;
                    }
                }
                ++bodySeparator2;
                string[,] linesStorage = new string [bodySeparator2,headSeparator1];
                bodySeparator2 = 0;
                headSeparator1 = 0;
                for (int line = 0; line < lines.Length; line++)
                {
                    if (lines[line] == separator1 || lines[line] == separator2)
                    {
                        //++line;
                        headSeparator1 = 0;
                        ++bodySeparator2;
                    }

                    if (lines[line] == separator2)
                    {
                    }
                    else
                    {
                        linesStorage[bodySeparator2, headSeparator1] = lines[line];
                    }
                    ++headSeparator1;
                }
                for (int line = 1; line < linesStorage.GetLength(0); line++)
                {
                    for (int line2 = 0; line2 < linesStorage.GetLength(1); line2++)
                    {
                        if (line2 == indexFindData)
                        {
                            storageLines.Add(linesStorage[line, line2]);
                        }
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                listR = storageLines;
                Head = replaceOnTime;
            }
            else
            {
                MessageBox.Show(falseAswer);
            }
        }


        List<string> keepList;
        string keepHead = "";
        public string Head
        {
            get
            {
                return keepHead;
            }

            set
            {
                keepHead = value;
            }
        }

        public List<string> listR
        {
            get
            {
                return keepList;
            }

            set
            {
                keepList = value;
            }
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PathToSave(string pathReceive)
        {
            path = pathReceive;
        }

        public void dataToSave(string dataReceive)
        {
            dataStorage = dataReceive;
        }
    }
}
