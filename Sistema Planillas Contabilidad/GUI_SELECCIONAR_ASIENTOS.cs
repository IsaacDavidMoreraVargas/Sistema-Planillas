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
using System.Drawing.Drawing2D;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Security.Policy;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_SELECCIONAR_ASIENTOS : Form
    {
        public GUI_SELECCIONAR_ASIENTOS()
        {
            InitializeComponent();
        }
        string separator2 = "+++++++++++";
        string defaultData = "----";
        string tipo1 = "ASIENTO";
        string tipo2 = "CELDA";
        string opcion1 = "LOCAL";
        string opcion2 = "GLOBAL";
        string opcion3 = "LOCAL-GLOBAL";
        string debit = "DEBIT";
        string credit = "CREDIT";
        string pathListIn = "";
        string pathListMedium = "";
        string pathSit = "";
        string pathListIn1 = "";
        string pathListMedium1 = "";
        string pathSit1 = "";
        string actualPath = "";
        string flag1 = "NOMBRES";
        string avoid1 = "CEDULA";
        string avoid2 = "FECHA INGRESO";
        string avoid3 = "APELLIDO 1";
        string avoid4 = "NOMBRE";
        string avoid5 = "APELLIDO 2";
        List<string> receivedHeads = new List<string>();
        List<string> receivedDeparments = new List<string>();
        string[,] arrayReceive;
        List<string[]> bodyOnTime = new List<string[]>();
        List<string[]> headOnTime = new List<string[]>();
        int indexAfterNames = 0;
        bool location1 = false;
        bool location2 = false;
        string actual = Directory.GetCurrentDirectory();
        private void GUI_SELECCIONAR_ASIENTOS_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            comboBox2.Items.Add(opcion1);
            comboBox2.Items.Add(opcion2);
            comboBox2.Items.Add(opcion3);
            comboBox4.Items.Add(debit);
            comboBox4.Items.Add(credit);
            foreach (string item in receivedHeads)
            {
                comboBox1.Items.Add(item);
            }
            string actualPath = actual.Replace("\\bin\\Debug", "\\Companies");
            actualPath += "\\" + company + "\\Sits";
            if (!Directory.Exists(actualPath))
            {
                Directory.CreateDirectory(actualPath);
            }
            actualPath = actual.Replace("\\bin\\Debug", "\\configuration");
            actualPath+= "\\Sits";
            if (!Directory.Exists(actualPath))
            {
                Directory.CreateDirectory(actualPath);
            }
        }

        private void loadComBoBox()
        {
            textBox2.Text = "";
            if (File.Exists(pathListMedium))
            {
                if (File.Exists(pathListIn))
                {
                    checkedListBox2.Items.Clear();
                    checkedListBox1.Items.Clear();
                    string[] lines1 = File.ReadAllLines(pathListMedium);
                    string[] lines2 = File.ReadAllLines(pathListIn);
                    foreach (string item in lines1)
                    {
                        bool found = false;
                        foreach (string item2 in lines2)
                        {
                            if (item2 == item)
                            {
                                found = true;
                            }

                        }
                        if (found == true)
                        {
                            Invoke(new Action(() => checkedListBox1.Items.Add(item, true)));
                        }
                        else
                        {
                            Invoke(new Action(() => checkedListBox1.Items.Add(item, false)));
                        }
                    }
                }
                else
                {
                    checkedListBox2.Items.Clear();
                    checkedListBox1.Items.Clear();
                    string[] lines = File.ReadAllLines(pathListMedium);
                    foreach (string item in lines)
                    {
                        Invoke(new Action(() => checkedListBox1.Items.Add(item, true)));
                    }
                }
            }
            checkedListBox2.Items.Clear();
            foreach (string item in checkedListBox1.CheckedItems)
            {
                Invoke(new Action(() => checkedListBox2.Items.Add(item, true)));
            }
            comboBox3.Items.Clear();
            foreach (string item in checkedListBox1.Items)
            {
                comboBox3.Items.Add(item);
            }

            
        }
        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == opcion1)
            {
                location1 = true;
                location2 = false;
                actualPath = actual.Replace("\\bin\\Debug", "\\Companies");
                pathListIn = actualPath + "\\" + company + "\\Sits\\ListIn.txt";
                pathListMedium = actualPath + "\\" + company + "\\Sits\\ListMedium.txt";
                pathSit = actualPath+"\\" + company + "\\Sits\\sit.txt";
                loadComBoBox();
            }
            else if (comboBox2.Text == opcion2)
            {
                location1 = false;
                location2 = true;
                actualPath = actual.Replace("\\bin\\Debug", "\\configuration");
                pathListIn = actualPath + "\\Sits\\ListIn.txt";
                pathListMedium = actualPath + "\\Sits\\ListMedium.txt";
                pathSit = actualPath + "\\Sits\\sit.txt";
                loadComBoBox();
            }
            else if (comboBox2.Text == opcion3)
            {
                location1 = true;
                location2 = true;
                actualPath = actual.Replace("\\bin\\Debug", "\\Companies");
                pathListIn = actualPath + "\\" + company + "\\Sits\\ListIn.txt";
                pathListMedium = actualPath + "\\" + company + "\\Sits\\ListMedium.txt";
                pathSit = actualPath+"\\" + company + "\\Sits\\sit.txt";

                actualPath = actual.Replace("\\bin\\Debug", "\\configuration");
                pathListIn1 = actualPath + "\\Sits\\ListIn.txt";
                pathListMedium1 = actualPath + "\\Sits\\ListMedium.txt";
                pathSit1 = actualPath+ "\\Sits\\sit.txt";
            }
        }

        string storage = "";
        public void receivedArray(List<string[,]>  arrayReceived)
        {
            string[] head = { };
            List<string[,]> arrayReceiveList = arrayReceived;
            foreach (string[,] arrayReceive in arrayReceiveList)
            {
                if (arrayReceive[0, 0] != "JUMPER")
                {
                    int maximunRows = arrayReceive.GetLength(0);
                    int maximunColumns = arrayReceive.GetLength(1);
                    head = new string[maximunColumns];

                    for (int column = 0; column < maximunColumns; column++)
                    {
                        head[column] = arrayReceive[0, column];
                        if (arrayReceive[0, column] == avoid1 || arrayReceive[0, column] == avoid2 || arrayReceive[0, column] == avoid3 || arrayReceive[0, column] == avoid4 || arrayReceive[0, column] == avoid5)
                        {
                            storage+= "FALSE" + "<";
                        }
                        else
                        {
                            decimal sumNumber = 0;
                            bool isLetter = false;
                            for (int row = 1; row < maximunRows; row++)
                            {
                                if (arrayReceive[row, column] == null || arrayReceive[row, column] == "" || arrayReceive[row, column] == " ")
                                {
                                    storage += "0" + "<";
                                }
                                else
                                {
                                    try
                                    {
                                        string change = arrayReceive[row, column];
                                        sumNumber += decimal.Parse(change);
                                    }
                                    catch (Exception)
                                    {
                                        isLetter = true;
                                        break;
                                    }
                                }

                            }
                            if (isLetter == true)
                            {
                                storage += "FALSE" + "<";
                            }
                            else
                            {
                                storage += sumNumber.ToString() + "<";
                            }
                           
                        }
                    }
                    //MessageBox.Show(storage);
                    storage = storage.TrimEnd('<');
                    storage += "?";
                }
                else
                {
                    //MessageBox.Show("JIJIJI "+arrayReceive[0, 0]);

                    List<string[]> splitOnSecond = new List<string[]>();
                    storage = storage.TrimEnd('?');
                    //MessageBox.Show(storage);
                    string[] splitData = storage.Split('?');
                    foreach (string item in splitData)
                    {
                        MessageBox.Show(item);
                        string[] splitArray= item.Split('<');
                        splitOnSecond.Add(splitArray); 
                    }
                    string[] body= { };
                    for (int item = 0; item < splitOnSecond.Count; item++)
                    {
                        //body = new string[splitOnSecond[item].Length];
                        string[] arr = splitOnSecond[item];
                        int max = arr.Length;
                        body = new string[max];
                        //head = new string[max];
                        for (int col=0; col< max; col++)
                        {
                            //head[col] = arrayReceive[0, col];
                            //MessageBox.Show(head[col]+"<--->" +body[col]);
                            if (arr[col] == "FALSE")
                            {
                                body[col] = arr[col];
                            }
                            else
                            {
                                decimal sum = 0;
                                sum += Convert.ToDecimal(arr[col]);
                                for (int item2 = 1; item2 < splitOnSecond.Count; item2++)
                                {
                                    string[] arr2 = splitOnSecond[item2];
                                    sum += Convert.ToDecimal(arr2[col]);
                                }
                                body[col] = sum.ToString();
                            }
                        }
                        break;
                    }
                    headOnTime.Add(head);
                    bodyOnTime.Add(body);
                    storage = "";
                }
                
            }
            
        }

        public void receivedData(List<string> listReceived, List<string> listReceivedDeparments)
        {
            receivedHeads = listReceived;
            receivedDeparments = listReceivedDeparments;
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
            if (location1==true && location2 == true)
            {
                rewriteInMedium(pathListMedium, pathListIn);
                rewriteInMedium(pathListMedium1, pathListIn1);
            }
            else if(location1 == true || location2 == true)
            {
                rewriteInMedium(pathListMedium, pathListIn);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        public void rewriteInMedium(string pathListMedium, string pathListIn)
        {
            if (File.Exists(pathListMedium))
            {
                File.Delete(pathListMedium);
                FileStream fs = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox1.Items)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
            else
            {
                FileStream fs = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox1.Items)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }

            if (File.Exists(pathListIn))
            {
                File.Delete(pathListIn);
                FileStream fs = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
            else
            {
                FileStream fs = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("NOMBRE ASIENTO VACIO");
            }
            else if (textBox2.Text == " " || textBox2.Text == "")
            {
                MessageBox.Show("FORMULA VACIA");
            }
            else if (comboBox2.Text == defaultData)
            {
                MessageBox.Show("IMPOSIBLE CREAR ASIENTO, SELECCION NO VALIDA");
            } else if (comboBox2.Text == opcion3)
            {
                MessageBox.Show("IMPOSIBLE CREAR ASIENTO, LOCAL O GLOBAL");
            } else if (comboBox4.Text == defaultData)
            {
                MessageBox.Show("IMPOSIBLE CREAR ASIENTO, DEBE O HABE NO ELEGIDO PARA ASIENTO");
            }
            else
            {

                if (File.Exists(pathSit))
                {
                    string[] lines = File.ReadAllLines(pathSit);
                    List<string> studyDataHead = new List<string>();
                    List<string> studyDataBody = new List<string>();
                    string storageFinal = "";
                    for (int line = 0; line < lines.Length; line++)
                    {
                        if (lines[line] == separator2)
                        {
                            indexAfterNames = line;
                            ++indexAfterNames;
                            break;
                        } else if (lines[line] == flag1)
                        {

                        }
                        else
                        {
                            studyDataHead.Add(lines[line]);
                        }
                    }
                    bool foundBody = false;
                    string evaluate = textBox2.Text;
                    evaluate = evaluate.Replace("\n", "");
                    for (int line = indexAfterNames; line < lines.Length; line++)
                    {
                        string evalaute = storageFinal.Replace("\n", "");
                        if (lines[line] == separator2)
                        {
                            if (evalaute == evaluate)
                            {
                                foundBody = true;
                            }
                            studyDataBody.Add(storageFinal);
                            studyDataBody.Add(separator2);
                            storageFinal = "";
                        }
                        else if (lines[line] == debit || lines[line] == credit)
                        {
                            storageFinal +=lines[line]+"\n";
                        }
                        else
                        { 
                            foreach (char letter in lines[line])
                            {
                                if (letter == '(' || letter == ')' || letter == '+' || letter == '-' || letter == '*' || letter == '/' || letter == '=')
                                {
                                    storageFinal += "\n" + letter + "\n";
                                }
                                else
                                {
                                    storageFinal += letter;
                                }
                            }

                        }
                    }
                    bool foundHead = false;
                    string formula = textBox1.Text;
                    formula = formula.ToUpper();
                    foreach (string item in studyDataHead)
                    {
                        if (item == formula)
                        {
                            foundHead = true;
                            break;
                        }
                    }
                    formula = textBox2.Text;
                    formula = formula.Replace("\n", "");
                    if (foundHead == true)
                    {
                        MessageBox.Show("EL NOMBRE DE ESTE ASIENTO YA EXISTE");
                    }
                    else if (foundBody == true)
                    {
                        MessageBox.Show("ESTA FORMULA YA EXISTE");
                    }
                    else
                    {
                        File.Delete(pathSit);
                        FileStream fs = new FileStream(pathSit, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        writer.WriteLine(flag1);
                        foreach (string line in studyDataHead)
                        {
                            writer.WriteLine(line);
                        }
                        string stringUpper = textBox1.Text;
                        stringUpper = stringUpper.ToUpper();
                        writer.WriteLine(stringUpper);
                        writer.WriteLine(separator2);
                        foreach (string line in studyDataBody)
                        {
                            string[] storageData = line.Split('\n');
                            foreach (string item in storageData)
                            {
                                writer.WriteLine(item);
                            }

                        }
                        storageFinal = "";
                        foreach (char letter in formula)
                        {
                            if (letter == '(' || letter == ')' || letter == '+' || letter == '-' || letter == '*' || letter == '/' || letter == '=')
                            {
                                storageFinal += "\n" + letter + "\n";
                            }
                            else
                            {
                                storageFinal += letter;
                            }
                        }
                        storageFinal += "\n" + separator2 + "\n";
                        writer.WriteLine(comboBox4.Text);
                        writer.WriteLine(storageFinal);
                        writer.Close();
                        Invoke(new Action(() => checkedListBox1.Items.Add(textBox1.Text, false)));
                        MessageBox.Show("ASIENTO CREADO EXITOSAMENTE");
                    }
                }
                else
                {
                    string formula = textBox1.Text;
                    formula = formula.ToUpper();
                    FileStream fs = new FileStream(pathSit, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    writer.WriteLine(flag1);
                    writer.WriteLine(formula);
                    writer.WriteLine(separator2);
                    formula = textBox2.Text;
                    //formula = formula.Replace(" ", "");
                    formula = formula.Replace("\n", "");
                    string storageFinal = "";
                    foreach (char letter in formula)
                    {
                        if (letter == '(' || letter == ')' || letter == '+' || letter == '-' || letter == '*' || letter == '/' || letter == '=')
                        {
                            storageFinal += "\n" + letter + "\n";
                        }
                        else
                        {
                            storageFinal += letter;
                        }
                    }
                    storageFinal += "\n" + separator2 + "\n";
                    writer.WriteLine(comboBox4.Text);
                    writer.WriteLine(storageFinal);
                    writer.Close();
                    Invoke(new Action(() => checkedListBox1.Items.Add(textBox1.Text, false)));
                    MessageBox.Show("ASIENTO CREADO EXITOSAMENTE");
                }

                if (File.Exists(pathListMedium))
                {
                    File.Delete(pathListMedium);
                    FileStream fs = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string item in checkedListBox1.Items)
                    {
                        string itemChange = item;
                        itemChange = itemChange.ToUpper();
                        writer.WriteLine(itemChange);
                    }
                    writer.Close();
                }
                else
                {
                    FileStream fs = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string item in checkedListBox1.Items)
                    {
                        string itemChange = item;
                        itemChange = itemChange.ToUpper();
                        writer.WriteLine(itemChange);
                    }
                    writer.Close();
                }

                if (File.Exists(pathListIn))
                {
                    File.Delete(pathListIn);
                    FileStream fs = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string item in checkedListBox1.CheckedItems)
                    {
                        string itemChange = item;
                        itemChange = itemChange.ToUpper();
                        writer.WriteLine(itemChange);
                    }
                    writer.Close();
                }
                else
                {
                    FileStream fs = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string item in checkedListBox1.CheckedItems)
                    {
                        string itemChange = item;
                        itemChange = itemChange.ToUpper();
                        writer.WriteLine(itemChange);
                    }
                    writer.Close();
                }

                comboBox3.Items.Clear();
                foreach (string item in checkedListBox1.Items)
                {
                    comboBox3.Items.Add(item);
                }
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == " ")
            {
                MessageBox.Show("NO SE PUEDE ACTUALIZAR EL ASIENTO, NO EXISTEN FORMULAS");
            }
            else if (location1 == true || location2 == true)
            {
                string storageFinal = "";
                
                if (File.Exists(pathSit))
                {
                    string[] storageData = File.ReadAllLines(pathSit);
                    File.Delete(pathSit);
                    FileStream fs = new FileStream(pathSit, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string item in storageData)
                    {
                        if (item == separator2)
                        {
                            writer.WriteLine(item);
                            break;
                        }
                        else
                        {
                            writer.WriteLine(item);
                        }
                       
                    }
                    writer.Close();
                }
                using (StreamWriter writer1 = File.AppendText(pathSit))
                foreach (string line in textBox2.Lines)
                {
                    if (line == separator2)
                    {
                        writer1.WriteLine(storageFinal);
                        writer1.WriteLine(separator2);
                        storageFinal = "";
                    }if (line==debit || line == credit)
                    {
                        writer1.WriteLine(line);
                        storageFinal = "";
                    }
                    else
                    {
                        foreach (char letter in line)
                        {
                            if (letter == '(' || letter == ')' || letter == '+' || letter == '-' || letter == '*' || letter == '/' || letter == '=')
                            {
                                storageFinal += "\n" + letter + "\n";
                            }
                            else
                            {
                                storageFinal += letter;
                            }
                        }
                    }
                }
               
                if (File.Exists(pathListIn))
                {
                    File.Delete(pathListIn);
                }
                FileStream fs2 = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer2 = new StreamWriter(fs2);
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    writer2.WriteLine(item);
                }
                writer2.Close();

                if (File.Exists(pathListMedium))
                {
                    File.Delete(pathListMedium);
                }
                FileStream fs3 = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer3 = new StreamWriter(fs3);
                foreach (string item in checkedListBox1.Items)
                {
                    writer3.WriteLine(item);
                }
                writer3.Close();
                
                MessageBox.Show("FORMULAS ACTUALIZADAS CORRECTAMENTE");
            }
            else
            {
                MessageBox.Show("ELIJE UNA LOCALIZACION VALIDA PARA ACTUALIZAR, LOCAL O GLOBAL");
            }
        }

        private void buttonReGenerate_Click(object sender, EventArgs e)
        {
            //headOnTime
            //bodyOnTime
            if (comboBox2.Text == defaultData)
            {
                MessageBox.Show("IMPOSIBLE GENERAR, SELECCIONA EL ORIGEN DE LOS ASIENTOS, LOCAL O GLOBAL");
            }
            else
            {
                if (File.Exists(pathSit))
                {
                    string[] storageFormulas = File.ReadAllLines(pathSit);
                    List<string> listOfCheckItemsBoxList2 = new List<string>();
                    List<int> listIndexOfCheckItemsBoxList2 = new List<int>();
                    int index = 0;
                    foreach (string item in checkedListBox2.Items)
                    {
                        if (checkedListBox2.GetItemCheckState(index) == CheckState.Checked)
                        {
                            listOfCheckItemsBoxList2.Add(item);
                            listIndexOfCheckItemsBoxList2.Add(index);
                        }
                        ++index;
                    }
                    index = 0;
                    List<string> listOfFormulasDEBIT = new List<string>();
                    List<string[]> listOfHeadDEBIT = new List<string[]>();
                    List<string> listOfFormulasCREDIT = new List<string>();
                    List<string[]> listOfHeadCREDIT = new List<string[]>();
                    int indexOfHead = 0;
                    string storageHeadDedit = "";
                    string storageHeadCredit = "";
                    for (int formula = 0; formula < storageFormulas.Length; formula++)
                    {
                        if (storageFormulas[formula] == separator2)
                        {
                            bool found = false;
                            foreach (int headToCompare in listIndexOfCheckItemsBoxList2)
                            {
                                if (headToCompare == index)
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found == true)
                            {
                                ++formula;
                                string storageData = "";
                                for (int formulaPart2 = formula; formulaPart2 < storageFormulas.Length; formulaPart2++)
                                {
                                    if (storageFormulas[formulaPart2] == separator2)
                                    {
                                        if (storageData.Contains("DEBIT"))
                                        {
                                            listOfFormulasDEBIT.Add(storageData);
                                            storageHeadDedit+= listOfCheckItemsBoxList2[indexOfHead]+"\n";
                                            ++indexOfHead;
                                        }
                                        else if (storageData.Contains("CREDIT"))
                                        {
                                            listOfFormulasCREDIT.Add(storageData);
                                            storageHeadCredit += listOfCheckItemsBoxList2[indexOfHead] + "\n";
                                            ++indexOfHead;
                                        }
                                        
                                        break;
                                    }
                                    else
                                    {
                                        storageData += storageFormulas[formulaPart2] + "\n";
                                    }
                                }
                            }
                            ++index;
                        }

                    }
                    storageHeadDedit = storageHeadDedit.TrimEnd('\n');
                    string[] splitByOneMoment = storageHeadDedit.Split('\n');
                    foreach (string item in receivedDeparments)
                    {
                        //MessageBox.Show(item);
                        listOfHeadDEBIT.Add(splitByOneMoment);
                    }
                    storageHeadCredit = storageHeadCredit.TrimEnd('\n');
                    splitByOneMoment = storageHeadCredit.Split('\n');
                    listOfHeadCREDIT.Add(splitByOneMoment);
                   
                    List<string> resultOfList = new List<string>();
                    index = 0;
                    //int indexFormula = 0;
                    List<string> repeatForumla = new List<string>();
                    foreach (string []head in listOfHeadDEBIT)
                    {
                        string add = "";
                        foreach (string formula in listOfFormulasDEBIT)
                        {
                            if (formula.Contains("DEBIT"))
                            {
                                add += "?"+ formula;
                            }
                            else
                            {
                                add += formula;
                            }
                        }
                        repeatForumla.Add(add);
                    }
                    listOfFormulasDEBIT = repeatForumla;
                    
                    for (int arrayHeads = 0; arrayHeads < listOfHeadDEBIT.Count; arrayHeads++)
                    {
                        resultOfList.Add("DEPARTAMENTO");
                        resultOfList.Add("DEBIT");
                        resultOfList.Add(receivedDeparments[index]);
                        resultOfList.Add(separator2);
                        string[] storageHead = headOnTime[arrayHeads];
                        //string[] replaceStorageHead = headOnTime[arrayHeads];
                        string[] storageBody = bodyOnTime[arrayHeads];
                        string copyFormula = listOfFormulasDEBIT[arrayHeads];
                            
                        for (int findHead = 0; findHead < storageHead.Length; findHead++)
                        {
                            string sumData = "";
                            string[] storageByMoment = copyFormula.Split('\n');
                            foreach (string item in storageByMoment)
                            {
                                if (item == storageHead[findHead])
                                {
                                    sumData += storageBody[findHead] + "\n";
                                }
                                else
                                {
                                    sumData += item + "\n";
                                }
                            }
                            sumData = sumData.TrimEnd('\n');
                            copyFormula = sumData;
                        }
                        string nameDebitCredit = "";
                        if (copyFormula.Contains("DEBIT"))
                        {
                            nameDebitCredit = "DEBIT";
                            copyFormula = copyFormula.Replace("DEBIT", "");
                        }
                        else if (copyFormula.Contains("CREDIT"))
                        {
                            nameDebitCredit = "CREDIT";
                            copyFormula = copyFormula.Replace("CREDIT", "");
                        }
                        string[] storageSplitData = copyFormula.Split('?');
                        int sizeFormula = storageSplitData.Length;
                        string result = "";
                        int indexHead = 0;
                        calculateSystem callToCalculate = new calculateSystem();
                        splitByOneMoment = listOfHeadDEBIT[indexHead];
                        for (int i= 0; i < sizeFormula; i++)
                        {
                            if(storageSplitData[i] != "")
                            {
                                resultOfList.Add(splitByOneMoment[indexHead]);
                                resultOfList.Add(nameDebitCredit);
                                string[] storageFormula = storageSplitData[i].Split('\n');
                                string sumn = "";
                                foreach(string g in storageFormula)
                                {
                                    if(g!="")
                                    {
                                        sumn += g+ "\n";
                                    }
                                      
                                }
                                sumn = sumn.TrimEnd('\n');
                                storageFormula = sumn.Split('\n');
                                result = callToCalculate.recieveArray(storageFormula);
                                resultOfList.Add(result);
                                resultOfList.Add(separator2);
                                string add = "";
                                foreach (string h in storageSplitData)
                                {
                                    string[] storageFormula2 = h.Split('\n');
                                    foreach (string piece in storageFormula2)
                                    {
                                        if (piece == listOfCheckItemsBoxList2[indexHead])
                                        {
                                            add += result+ "\n";
                                        }else
                                        {
                                            add += piece+ "\n";
                                        }
                                    }
                                    add = add.TrimEnd('\n');
                                    add += "\n?";
                                }
                                add = add.TrimEnd('?');
                                storageSplitData = add.Split('?');
                                //MessageBox.Show(add);
                                ++indexHead;
                            }
                        }
                        ++index;
                        //here
                    }

                    string firstHead = "";
                    foreach (string[] h in headOnTime)
                    {
                        foreach (string j in h)
                        {
                            firstHead += j+ "\n";
                        }
                        break;
                    }

                    firstHead = firstHead.TrimEnd('\n');
                    //MessageBox.Show(firstHead);
                    string []splitData = firstHead.Split('\n');
                    headOnTime.Clear();
                    headOnTime.Add(splitData);
                    int sizeHeads = headOnTime[0].Length;
                    string []readHeads = headOnTime[0];
                    string saveBody = "";
                    for (int head = 0; head < sizeHeads; head++)
                    {
                        decimal sum = 0;
                        if(readHeads[head]== "CEDULA" || readHeads[head] == "NOMBRE" || readHeads[head] == "APELLIDO 1" || readHeads[head] == "APELLIDO 2" || readHeads[head] == "FECHA INGRESO")
                        {
                            saveBody +="FALSE"+"\n";
                        }else
                        {
                            foreach (string[] h in bodyOnTime)
                            {
                                sum+= Decimal.Parse(h[head]);
                            }
                            string study = sum.ToString();
                            /*
                            if (study.Contains(","))
                            {
                                string change = "";
                                foreach(char letter in study)
                                {
                                    /*
                                    if(letter==',')
                                    {
                                        break;
                                    }else
                                    {
                                        change += letter;
                                    }
                                }
                            }
                            */
                            saveBody += study + "\n";
                        }
                        MessageBox.Show(saveBody);
                    }
                    saveBody = saveBody.TrimEnd('\n');
                    splitData = saveBody.Split('\n');
                    bodyOnTime.Clear();
                    bodyOnTime.Add(splitData);
                    string c = "jeuejuejeu";
                    decimal gaga = 0;
                    /*
                    foreach (string []h in headOnTime)
                    {
                        int size = h.Length;
                        for (int head=0; head<size; head++)
                        {
                            if (h[head] == "SALARIO NETO")
                            {
                                string am = "";
                                foreach(string []body in bodyOnTime)
                                {
                                    gaga += Convert.ToDecimal(body[head]);
                                    am += body[head]+ "\n";
                                    MessageBox.Show(am);
                                }
                                //MessageBox.Show(am);
                            }
                        }
                    }
                    //MessageBox.Show(gaga.ToString());
                    */
                    for (int arrayHeads = 0; arrayHeads < listOfHeadCREDIT.Count; arrayHeads++)
                    {
                        string[] storageHead = headOnTime[arrayHeads];
                        string[] replaceStorageHead = headOnTime[arrayHeads];
                        string[] storageBody = bodyOnTime[arrayHeads];
                        for (int formulas = 0; formulas < listOfFormulasCREDIT.Count; formulas++)
                        {
                            string copyFormula = listOfFormulasCREDIT[formulas];

                            for (int findHead = 0; findHead < storageHead.Length; findHead++)
                            {
                               // MessageBox.Show(storageHead[findHead]);
                                string sumData = "";
                                string[] storageByMoment = copyFormula.Split('\n');
                                foreach (string item in storageByMoment)
                                {
                                    if (item == storageHead[findHead])
                                    {
                                        sumData += storageBody[findHead] + "\n";
                                    }
                                    else
                                    {
                                        sumData += item + "\n";
                                    }
                                }
                                sumData = sumData.TrimEnd('\n');
                                copyFormula = sumData;

                            }
                            string nameDebitCredit = "";
                            if (copyFormula.Contains("DEBIT"))
                            {
                                nameDebitCredit = "DEBIT";
                                copyFormula = copyFormula.Replace("DEBIT", "");
                            }
                            else if (copyFormula.Contains("CREDIT"))
                            {
                                nameDebitCredit = "CREDIT";
                                copyFormula = copyFormula.Replace("CREDIT", "");
                            }
                            string[] storageSplitData = copyFormula.Split('\n');
                            string stringSorageData = "";
                            for (int spaceFormula = 0; spaceFormula < storageSplitData.Length; spaceFormula++)
                            {
                                if (storageSplitData[spaceFormula].Contains("."))
                                {
                                    string change = storageSplitData[spaceFormula];
                                    //change = change.Replace(",", "");
                                    //change = change.Replace(".", ",");
                                    stringSorageData += change + "\n";
                                }
                                else
                                {
                                    string change = storageSplitData[spaceFormula];
                                    if (change.Length == 7 && change[3] == ',' && storageSplitData.Length == 4)
                                    {
                                        if (storageSplitData[2].Contains("*"))
                                        { }
                                        else
                                        {
                                            //change = change.Replace(",", "");
                                        }
                                    }
                                    stringSorageData += change + "\n";
                                }
                            }
                            stringSorageData = stringSorageData.TrimStart('\n');
                            stringSorageData = stringSorageData.TrimEnd('\n');
                            copyFormula = stringSorageData;
                            
                            storageSplitData = copyFormula.Split('\n');
                            calculateSystem callToCalculate = new calculateSystem();
                            string result = callToCalculate.recieveArray(storageSplitData);
                            //MessageBox.Show(result+"="+copyFormula);
                            //MessageBox.Show(listOfFormulasCREDIT[formulas] + "\n"+ result + "="+copyFormula);
                            /*
                            string g = "";
                            foreach (string a in storageSplitData)
                            {
                                g += a+ "\n";
                            }
                            MessageBox.Show(result+"= "+g);
                            */
                            splitByOneMoment = listOfHeadCREDIT[arrayHeads];
                            resultOfList.Add(splitByOneMoment[formulas]);
                            resultOfList.Add(nameDebitCredit);
                            string resultString = "";
                            if (result.ToString().Length >7)
                            {
                                resultString = result.ToString();
                            }
                            else
                            {
                                resultString = result.ToString();
                            }
                            resultOfList.Add(resultString);
                            resultOfList.Add(separator2);

                            List<string> storageFormulasByMoment = new List<string>();
                            foreach (string changeFormula in listOfFormulasCREDIT)
                            {
                                string[] changes = changeFormula.Split('\n');
                                string change = "";
                                foreach (string item in changes)
                                {
                                    if (item == listOfCheckItemsBoxList2[formulas])
                                    {
                                        change += result.ToString() + "\n";
                                    }
                                    else
                                    {
                                        change += item + "\n";
                                    }
                                }
                                change = change.TrimEnd('\n');
                                storageFormulasByMoment.Add(change);
                            }
                            listOfFormulasCREDIT = storageFormulasByMoment;
                        }
                    }
                    
                    GUI_VISTA_ASIENTOS callingViewSits = new GUI_VISTA_ASIENTOS();
                    callingViewSits.PathToSave(company, deparment, month, week, file, path);
                    callingViewSits.receiveArray(resultOfList);
                    callingViewSits.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("IMPOSIBLE GENERAR, NO EXISTEN FORMULAS PARA CALCULAR");
                }
            }
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Text == opcion1)
            {
                location1 = true;
                if (File.Exists(pathSit))
                {
                    string[] lines = File.ReadAllLines(pathSit);
                    for(int line=0; line<lines.Length; line++)
                    {
                        if (lines[line] == separator2)
                        {
                            ++line;
                            for (int line2 = line; line2 < lines.Length; line2++)
                            {
                                //MessageBox.Show(lines[line2]);
                                if (lines[line2] == separator2)
                                {
                                    textBox2.Text += Environment.NewLine + separator2 + Environment.NewLine;
                                }
                                else if (lines[line2] == debit || lines[line2] == credit)
                                {
                                    textBox2.Text +=lines[line2] + Environment.NewLine;
                                }
                                else
                                {
                                    textBox2.Text += lines[line2];
                                }
                            }
                            break;
                        }
                    }
                } else
                {
                    MessageBox.Show("NO EXISTEN ASIENTOS LOCALES A CARGAR");
                }

            }
            else if (comboBox2.Text == opcion2)
            {
                if (File.Exists(pathSit))
                {
                    location2 = true;
                    string[] lines = File.ReadAllLines(pathSit);
                    for (int line = 0; line < lines.Length; line++)
                    {
                        if (lines[line] == separator2)
                        {
                            ++line;
                            for (int line2 = line; line2 < lines.Length; line2++)
                            {
                                //MessageBox.Show(lines[line2]);
                                if (lines[line2] == separator2)
                                {
                                    textBox2.Text += Environment.NewLine + separator2 + Environment.NewLine;
                                }
                                else if (lines[line2] == debit || lines[line2] == credit)
                                {
                                    textBox2.Text +=lines[line2] + Environment.NewLine;
                                }
                                else
                                {
                                    textBox2.Text += lines[line2];
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("NO EXISTEN ASIENTOS GLOBALES A CARGAR");
                }
            } else if (comboBox2.Text == opcion3)
            { 
                MessageBox.Show("NO SE PUEDE CARGAR O LOCAL O GLOBAL");
            }

        }

    private void comboBox1ValueChanged(object sender, EventArgs e)
    {
        textBox2.Text += comboBox1.Text;
        comboBox3.Items.Clear();
        foreach (string item in checkedListBox1.Items)
        {
            comboBox3.Items.Add(item);
        }
    }

        private void buttonKey1_Click(object sender, EventArgs e)
        {
            //(
            textBox2.Text += "(";
        }

        private void buttonKey2_Click(object sender, EventArgs e)
        {
            //=
            textBox2.Text += "=";
        }

        private void buttonKey3_Click(object sender, EventArgs e)
        {
            //+
            textBox2.Text += "+";
        }

        private void buttonKey4_Click(object sender, EventArgs e)
        {
            //*
            textBox2.Text += "*";
        }

        private void buttonKey5_Click(object sender, EventArgs e)
        {
            //-
            textBox2.Text += "-";
        }

        private void buttonKey6_Click(object sender, EventArgs e)
        {
            // /
            textBox2.Text += "/";
        }

        private void buttonKey8_Click(object sender, EventArgs e)
        {
            textBox2.Text += "%";
        }

        private void buttonKey7_Click(object sender, EventArgs e)
        {
            //)
            textBox2.Text += ")";
        }

        private void buttonRecharge_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void comboBox3ValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || comboBox3.Text == " ")
            {
                
            }
            else
            {
                comboBox3.Items.Clear();
                foreach (string item in checkedListBox1.Items)
                {
                    comboBox3.Items.Add(item);
                }
                textBox2.Text += comboBox3.Text;
            }
        }

        private void buttonEliminate_Click(object sender, EventArgs e)
        {
            if (File.Exists(pathSit))
            {
                DialogResult elimnate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR LAS FORMULAS SELECCIONADAS? \nNO PODRAN SER RECUPERADAS", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                switch (elimnate)
                {
                    case DialogResult.Yes:
                        //ITEMS TO ELIMINATE
                        List<string> itemsCkeck = new List<string>();
                        List<int> indexOfCheck = new List<int>();
                        List<string> keepHeadSits = new List<string>();
                        List<string> keepDataSits = new List<string>();
                        List<string> keepListMedium = new List<string>();
                        List<string> keepListIn = new List<string>();

                        foreach (string item in checkedListBox1.CheckedItems)
                        {
                            itemsCkeck.Add(item);
                        }
                        string[] storageData = File.ReadAllLines(pathSit);
                        foreach (string item in storageData)
                        {
                            if (item == separator2)
                            {
                                keepHeadSits.Add(item);
                                break;
                            }
                            else
                            {

                                bool found = false;
                                foreach (string find in itemsCkeck)
                                {
                                    if (item == find)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (found == false)
                                {
                                    keepHeadSits.Add(item);
                                }
                            }
                        }

                        int indexStudy = 0;
                        foreach (string item in storageData)
                        {
                            if (item == separator2)
                            {
                                break;
                            }
                            else
                            {
                                foreach (string eliminate in itemsCkeck)
                                {
                                    if (item == separator2)
                                    {
                                        break;
                                    }
                                    if (item == eliminate)
                                    {
                                        indexOfCheck.Add(indexStudy);
                                    }
                                }
                                ++indexStudy;
                            }
                        }
                        storageData = File.ReadAllLines(pathListMedium);
                        for (int head = 0; head < storageData.Length; head++)
                        {
                            bool found = false;
                            if (storageData[head] == separator2)
                            {
                                keepListMedium.Add(storageData[head]);
                                break;
                            }
                            else
                            {
                                foreach (string item in itemsCkeck)
                                {
                                    if (storageData[head] == item)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (found == false)
                                {
                                    keepListMedium.Add(storageData[head]);
                                }
                            }
                            
                        }

                        int indexAvoid = 0;
                        storageData = File.ReadAllLines(pathSit);
                        for (int head = 0; head < storageData.Length; head++)
                        {
                            if (storageData[head] == separator2)
                            {
                                ++indexAvoid;
                            }
                            bool found = false;
                            foreach (int item in indexOfCheck)
                            {
                                if (indexAvoid == item)
                                {
                                    ++head;
                                    for (int head2 = head; head2 < storageData.Length; head2++)
                                    {
                                        if (storageData[head2] == separator2)
                                        {
                                            ++indexAvoid;
                                            break;
                                        }
                                        else
                                        {
                                            ++head;
                                        }
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            if (found == false)
                            {
                                ++head;
                                for (int head2 = head; head2 < storageData.Length; head2++)
                                {
                                    if (storageData[head2] == separator2)
                                    {
                                        keepDataSits.Add(storageData[head2]);
                                        ++indexAvoid;
                                        break;
                                    }
                                    else
                                    {
                                        keepDataSits.Add(storageData[head2]);
                                        ++head;
                                    }
                                }
                            }
                        }
                        storageData = File.ReadAllLines(pathListIn);
                        foreach (string item2 in storageData)
                        {
                            bool found = false;
                            foreach (string item in itemsCkeck)
                            {
                                if (item == item2)
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found == false)
                            {

                                keepListIn.Add(item2);
                            }
                        }
                        if (File.Exists(pathSit))
                        {
                            File.Delete(pathSit);
                            FileStream fs = new FileStream(pathSit, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            //MessageBox.Show("separator2\n" + "keepHeadSits" + "\nseparator2");
                            foreach (string item in keepHeadSits)
                            {
                                //MessageBox.Show(item);
                                writer.WriteLine(item);
                            }
                            //MessageBox.Show("separator2\n" + "keepDataSits" + "\nseparator2");
                            for (int items = 0; items < keepDataSits.Count; items++)
                            {
                                if (keepDataSits[items] == separator2)
                                {
                                    ++items;
                                    for (int items2 = items; items2 < keepDataSits.Count; items2++)
                                    {
                                        //MessageBox.Show(keepDataSits[items2]);
                                        writer.WriteLine(keepDataSits[items2]);
                                    }
                                    break;
                                }

                            }
                            writer.Close();
                        }
                        if (File.Exists(pathListMedium))
                        {
                            File.Delete(pathListMedium);
                            FileStream fs = new FileStream(pathListMedium, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            //MessageBox.Show("separator2\n" + "keepListMedium" + "\nseparator2");
                            foreach (string item in keepListMedium)
                            {
                                writer.WriteLine(item);
                                //MessageBox.Show(item);
                            }
                            writer.Close();
                        }
                        if (File.Exists(pathListIn))
                        {
                            File.Delete(pathListIn);
                            FileStream fs = new FileStream(pathListIn, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            //MessageBox.Show("separator2\n" + "keepListIn" + "\nseparator2");
                            foreach (string item in keepListIn)
                            {
                                writer.WriteLine(item);
                                //MessageBox.Show(item);
                            }
                            writer.Close();
                        }
                        loadComBoBox();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                MessageBox.Show("NO EXISTEN FORMULAS QUE ELIMINAR");
            }
        }

        private void comboCheckListValueChanged(object sender, ItemCheckEventArgs e)
        {
            checkedListBox2.Items.Clear();
            foreach (string item in checkedListBox1.CheckedItems)
            {
                Invoke(new Action(() => checkedListBox2.Items.Add(item, true)));
            }
        }

       
    }
}
