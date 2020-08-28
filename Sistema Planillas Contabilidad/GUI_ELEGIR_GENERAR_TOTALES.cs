using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_ELEGIR_GENERAR_TOTALES : Form
    {
        public GUI_ELEGIR_GENERAR_TOTALES()
        {
            InitializeComponent();
        }
        List<string> listHeads = new List<string>();
        List<string> listHeadsCompare = new List<string>();
        bool fillorNot;
        string avoid1 = "CEDULA";
        string avoid2 = "FECHA INGRESO";
        string avoid3 = "configuration";
        string avoid4 = "exclusiveData";
        string avoid5 = "Sits";
        string[,] receivedStorage;
        string[] weeks = { "SEMANA 1", "SEMANA 2", "SEMANA 3", "SEMANA 4", "MOSTRAR" };
        string[] avoidHeads = { "CEDULA", "NOMBRE", "APELLIDO 1", "APELLIDO 2", "FECHA INGRESO" };
        string path = "";
        string company = "";
        string deparment = "";
        string month = "";
        string week = "";
        string file = "";
        string actual = Directory.GetCurrentDirectory();
        string separator1 = "-----------";
        string separator2 = "+++++++++++";
        string typeOfWork = "";
        string typeTotal = "Totals";
        string typeSits = "Sits";

        private void GUI_ELEGIR_GENERAR_TOTALES_Load(object sender, EventArgs e)
        {
            if (typeOfWork == typeTotal)
            {
                LoadDataInCheckBoxTotal();
            } else if (typeOfWork == typeSits)
            {
                
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                int frameSize = this.Width;
                int dataGridView1Size = dataGridView1.Width;
                int checkedListBox1Size = checkedListBox1.Width;
                int newSizeFrame = frameSize - dataGridView1Size - checkedListBox1Size - 6;
                dataGridView1.Dispose();
                checkedListBox1.Dispose();
                this.Width = newSizeFrame;
                int newPositionButtonClose = this.Width;
                newPositionButtonClose = newPositionButtonClose - (checkedListBox2.Height / 2);
                buttonCloseProgram.Left = newPositionButtonClose;
                LoadDataInCheckBoxSits();
                overrideList();
            }
        }

        private void LoadDataInCheckBoxTotal()
        {
            actual = actual.Replace("\\bin\\Debug", "\\Companies");
            string actualPath = actual + "\\" + company;
            string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\sits.txt";
            string[] HeadsToCompare = { };
            if (File.Exists(pathOfCheckHeads))
            {
                HeadsToCompare = File.ReadAllLines(pathOfCheckHeads);
            }
            string[] departMents = Directory.GetDirectories(actualPath);
            foreach (string dept in departMents)
            {
                string change = dept;
                change = change.Replace(actualPath, " ");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
                int maximunLetter = change.Length;
                string evaluate = "";
                for (int letter = 0; letter < maximunLetter; letter++)
                {
                    if (letter == 0 && change[letter] == ' ' || letter == 1 && change[letter] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        evaluate += change[letter];
                    }
                }
                change = evaluate;
                if (change == avoid3 || change == avoid4 || change == avoid5)
                {
                    continue;
                }
                else
                {
                    bool headFound = false;
                    foreach (string itemToCompare in HeadsToCompare)
                    {
                        if (itemToCompare.Contains(change))
                        {
                            headFound = true;
                            break;
                        }
                    }
                    if (headFound == true)
                    {
                        Invoke(new Action(() => checkedListBox4.Items.Add(change, true)));
                    }
                    else
                    {
                        Invoke(new Action(() => checkedListBox4.Items.Add(change, false)));
                    }

                }
            }

            foreach (string dept in checkedListBox4.Items)
            {
                int maximunLetter = dept.Length;
                string evaluate = "";
                for (int letter = 0; letter < maximunLetter; letter++)
                {
                    if (letter == 0 && dept[letter] == ' ' || letter == 1 && dept[letter] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        evaluate += dept[letter];
                    }
                }
                actualPath = actual + "\\" + company + "\\" + evaluate + "\\";
                string[] months = Directory.GetDirectories(actualPath);
                foreach (string month in months)
                {
                    string change = month;
                    change = change.Replace(actualPath, " ");
                    change = change.Replace("_", " ");
                    change = change.Replace("\\", " ");
                    maximunLetter = change.Length;
                    evaluate = "";
                    for (int letter = 0; letter < maximunLetter; letter++)
                    {
                        if (change[letter] == ' ' && letter == 0 || change[letter] == ' ' && letter == 1)
                        {
                            continue;
                        }
                        else
                        {
                            evaluate += change[letter];
                        }
                    }
                    change = evaluate;
                    bool found = false;
                    foreach (string item in checkedListBox3.Items)
                    {
                        string change2 = item.Replace(" ", "");
                        if (change2 == change)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        bool headFound = false;
                        foreach (string itemToCompare in HeadsToCompare)
                        {
                            if (itemToCompare.Contains(change))
                            {
                                headFound = true;
                                break;
                            }
                        }
                        if (headFound == true)
                        {
                            Invoke(new Action(() => checkedListBox3.Items.Add(change, true)));
                        }
                        else
                        {
                            Invoke(new Action(() => checkedListBox3.Items.Add(change, false)));
                        }
                    }
                }
            }
            foreach (string item in weeks)
            {
                bool headFound = false;
                foreach (string itemToCompare in HeadsToCompare)
                {
                    if (itemToCompare.Contains(item))
                    {
                        headFound = true;
                        break;
                    }
                }
                if (headFound == true)
                {
                    Invoke(new Action(() => checkedListBox2.Items.Add(item, true)));
                }
                else
                {
                    Invoke(new Action(() => checkedListBox2.Items.Add(item, false)));
                }
            }
        }

        private void LoadDataInCheckBoxSits()
        {
            actual = actual.Replace("\\bin\\Debug", "\\Companies");
            string actualPath = actual + "\\" + company;
            string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\sits.txt";
            string[] HeadsToCompare = { };
            if (File.Exists(pathOfCheckHeads))
            {
                HeadsToCompare = File.ReadAllLines(pathOfCheckHeads);
            }
            string[] departMents = Directory.GetDirectories(actualPath);
            foreach (string dept in departMents)
            {
                string change = dept;
                change = change.Replace(actualPath, " ");
                change = change.Replace("_", " ");
                change = change.Replace("\\", " ");
                int maximunLetter = change.Length;
                string evaluate = "";
                for (int letter = 0; letter < maximunLetter; letter++)
                {
                    if (letter == 0 && change[letter] == ' ' || letter == 1 && change[letter] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        evaluate += change[letter];
                    }
                }
                change = evaluate;
                if (change == avoid3 || change == avoid4 || change == avoid5)
                {
                    continue;
                }
                else
                {
                    bool headFound = false;
                    foreach (string itemToCompare in HeadsToCompare)
                    {
                        if (itemToCompare.Contains(change))
                        {
                            headFound = true;
                            break;
                        }
                    }
                    if (headFound == true)
                    {
                        Invoke(new Action(() => checkedListBox4.Items.Add(change, true)));
                    }
                    else
                    {
                        Invoke(new Action(() => checkedListBox4.Items.Add(change, false)));
                    }

                }
            }

            foreach (string dept in checkedListBox4.Items)
            {
                int maximunLetter = dept.Length;
                string evaluate = "";
                for (int letter = 0; letter < maximunLetter; letter++)
                {
                    if (letter == 0 && dept[letter] == ' ' || letter == 1 && dept[letter] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        evaluate += dept[letter];
                    }
                }
                
                actualPath = actual + "\\" + company + "\\" + evaluate + "\\";
                //MessageBox.Show(actualPath);
                string[] months = Directory.GetDirectories(actualPath);
                foreach (string month in months)
                {
                    string change = month;
                    change = change.Replace(actualPath, " ");
                    change = change.Replace("_", " ");
                    change = change.Replace("\\", " ");
                    maximunLetter = change.Length;
                    evaluate = "";
                    for (int letter = 0; letter < maximunLetter; letter++)
                    {
                        if (change[letter] == ' ' && letter == 0 || change[letter] == ' ' && letter == 1)
                        {
                            continue;
                        }
                        else
                        {
                            evaluate += change[letter];
                        }
                    }
                    change = evaluate;
                    bool found = false;
                    foreach (string item in checkedListBox3.Items)
                    {
                        string change2 = item.Replace(" ", "");
                        if (change2 == change)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        bool headFound = false;
                        foreach (string itemToCompare in HeadsToCompare)
                        {
                            if (itemToCompare.Contains(change))
                            {
                                headFound = true;
                                break;
                            }
                        }
                        if (headFound == true)
                        {
                            Invoke(new Action(() => checkedListBox3.Items.Add(change, true)));
                        }
                        else
                        {
                            Invoke(new Action(() => checkedListBox3.Items.Add(change, false)));
                        }
                    }
                }
                
            }
            foreach (string item in weeks)
            {
                bool headFound = false;
                foreach (string itemToCompare in HeadsToCompare)
                {
                    if (itemToCompare.Contains(item))
                    {
                        headFound = true;
                        break;
                    }
                }
                if (headFound == true)
                {
                    Invoke(new Action(() => checkedListBox2.Items.Add(item, true)));
                }
                else
                {
                    Invoke(new Action(() => checkedListBox2.Items.Add(item, false)));
                }
            }
        }

        List<string> headList = new List<string>();
        List<string> fileList = new List<string>();
        List<string> deparments = new List<string>();
        List<string> weeksList = new List<string>();
        List<string> monthList = new List<string>();

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int indexDeparments = 0;
            int numberDept = 0;
            int numberMonth = 0;
            int numberWeek = 0;
            int numberHeads = 0;
            if (typeOfWork == typeTotal)
            {
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    ++numberHeads;
                }
                foreach (string item in checkedListBox2.CheckedItems)
                {
                    ++numberWeek;
                }
                foreach (string item in checkedListBox3.CheckedItems)
                {
                    ++numberMonth;
                }
                foreach (string item in checkedListBox4.CheckedItems)
                {
                    ++numberDept;
                }

                if (numberDept == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUN DEPARTAMENTO PARA GENERAR LOS TOTALES");
                }
                else if (numberMonth == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUN MES PARA GENERAR LOS TOTALES");
                }
                else if (numberWeek == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUNA SEMANA PARA GENERAR LOS TOTALES");
                }
                else if (numberHeads == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUNA COLUMNA PARA GENERAR LOS TOTALES");
                }
                else
                {
                    overrideList();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    List<string[,]> listArrays = new List<string[,]>();
                    //int indexDepartment = 0;
                    foreach (string data in fileList)
                    {
                        string[] lines = File.ReadAllLines(data);
                        int maximunColumns = 0;
                        int maximunRows = 0;
                        foreach (string line in lines)
                        {
                            if (line == separator1)
                            {
                                ++maximunRows;
                                break;
                            }
                            else
                            {
                                ++maximunColumns;
                            }
                        }
                        foreach (string line in lines)
                        {
                            if (line == separator2)
                            {
                                ++maximunRows;
                            }
                        }
                        string[,] storageData = new string[maximunRows, maximunColumns];
                        int indexColum = 0;
                        int indexRow = 0;
                        for (int line = 0; line < lines.Length; line++)
                        {
                            if (lines[line] == separator1)
                            {
                                ++indexRow;
                                ++line;
                                for (int line2 = line; line2 < lines.Length; line2++)
                                {
                                    if (lines[line2] == separator2)
                                    {
                                        ++indexRow;
                                        indexColum = 0;
                                    }
                                    else
                                    {
                                        storageData[indexRow, indexColum] = lines[line2];
                                        ++indexColum;
                                    }

                                }
                                break;
                            }
                            else
                            {
                                storageData[indexRow, line] = lines[line];
                            }
                        }

                        listArrays.Add(storageData);
                    }

                    int numbeRow = 0;
                    List<string> headAlloweds = new List<string>();
                    headAlloweds.Add("INDEX");
                    foreach (string head in checkedListBox1.CheckedItems)
                    {
                        if (head == "INDEX")
                        { continue; }
                        else
                        {
                            headAlloweds.Add(head);
                        }
                    }
                    int indexRow2 = 0;
                    int indexSum = 0;
                    foreach (string[,] item in listArrays)
                    {
                        int rows = item.GetLength(0);
                        int colums = item.GetLength(1);
                        List<int> indexHead = new List<int>();
                        int maximunColumnsDataGrid = dataGridView1.ColumnCount;
                        for (int col = 0; col < colums; col++)
                        {
                            for (int compare = 0; compare < headAlloweds.Count; compare++)
                            {
                                if (headAlloweds[compare] == item[0, col])
                                {
                                    if (headAlloweds[compare] != "INDEX")
                                    {
                                        --col;
                                        indexHead.Add(col);
                                        ++col;
                                    }
                                    bool found = false;
                                    for (int compare2 = 0; compare2 < maximunColumnsDataGrid; compare2++)
                                    {
                                        if (dataGridView1.Columns[compare2].HeaderText == item[0, col])
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (found == false)
                                    {
                                        dataGridView1.Columns.Add(item[0, col], item[0, col]);
                                    }
                                }
                            }
                        }

                        dataGridView1.Rows.Add(deparments[indexDeparments]);

                        try
                        {
                            dataGridView1.Rows[indexRow2].Cells[1].Value = monthList[indexDeparments];
                        }
                        catch (Exception) { }
                        try
                        {
                            dataGridView1.Rows[indexRow2].Cells[2].Value = weeksList[indexDeparments];
                        }
                        catch (Exception) { }

                        ++indexDeparments;
                        for (int row = 1; row < rows; row++)
                        {
                            dataGridView1.Rows.Add(numbeRow.ToString());
                            ++numbeRow;
                        }
                        ++indexRow2;
                        for (int row = 1; row < rows; row++)
                        {
                            int indexColum = 1;
                            foreach (int number in indexHead)
                            {
                                for (int col = 0; col < colums; col++)
                                {
                                    if (col == number)
                                    {
                                        dataGridView1.Rows[indexRow2].Cells[indexColum].Value = item[row, col];
                                    }

                                }
                                ++indexColum;
                            }
                            ++indexRow2;
                        }

                        int maximunRowsColor = dataGridView1.Rows.Count;
                        for (int col = 0; col < 1; col++)
                        {
                            for (int row = 0; row < maximunRowsColor; row++)
                            {
                                try
                                {
                                    if (dataGridView1.Rows[row].Cells[col].Value != null)
                                    {
                                        int tryParseNumber = int.Parse(dataGridView1.Rows[row].Cells[col].Value.ToString());
                                    }
                                }
                                catch (Exception)
                                {
                                    if (dataGridView1.Rows[row].Cells[col].Value.ToString() == "TOTAL")
                                    {

                                    }
                                    else
                                    {
                                        for (int colColor = 0; colColor < maximunColumnsDataGrid; colColor++)
                                        {
                                            dataGridView1.Rows[row].Cells[colColor].Style.BackColor = Color.Orange;
                                        }
                                    }
                                }
                            }
                        }


                        dataGridView1.Rows.Add("TOTAL");
                        ++indexRow2;

                        int writeRow = dataGridView1.Rows.Count;
                        writeRow -= 2;
                        int maximunRows = dataGridView1.Rows.Count;
                        maximunRows -= 2;
                        int maximunColumns = dataGridView1.Columns.Count;
                        for (int col = 1; col < maximunColumns; col++)
                        {
                            bool foundHead = false;
                            for (int compare = 0; compare < headAlloweds.Count; compare++)
                            {
                                if (headAlloweds[compare] == dataGridView1.Columns[col].HeaderText)
                                {
                                    foundHead = true;
                                    break;
                                }
                            }

                            //bool isHorOrExt = false;
                            if (dataGridView1.Columns[col].HeaderText.Contains("ORD") || dataGridView1.Columns[col].HeaderText.Contains("EXT"))
                            {
                                //isHorOrExt = true;
                            }

                            if (foundHead == true)
                            {
                                bool found = false;
                                for (int compare = 0; compare < avoidHeads.Length; compare++)
                                {
                                    if (avoidHeads[compare] == dataGridView1.Columns[col].HeaderText)
                                    {
                                        found = true;
                                        break;
                                    }
                                }

                                
                                if (found == false)
                                {
                                    decimal sum = 0;
                                    calculateSystem callToCalculate = new calculateSystem();
                                    for (int row = indexSum; row < maximunRows; row++)
                                    {
                                        if (dataGridView1.Rows[row].Cells[col].Value == null || dataGridView1.Rows[row].Cells[col].Value.ToString() == "" || dataGridView1.Rows[row].Cells[col].Value.ToString() == " ")
                                        {
                                            sum += 0;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                string replace = dataGridView1.Rows[row].Cells[col].Value.ToString();
                                                if (replace.Contains("."))
                                                {
                                                    replace = replace.Replace(",", "#");
                                                    replace = replace.Replace(".", "");
                                                    replace = replace.Replace("#", ",");
                                                }
                                                else
                                                {
                                                    /*
                                                    if(replace.Length>=5)
                                                    {
                                                        replace = replace.Replace(",", "");
                                                    }
                                                    */
                                                    //
                                                }
                                                sum += decimal.Parse(replace);
                                            }
                                            catch (Exception) { }
                                        }
                                    }
                                    string change = sum.ToString();
                                    if (change.Length <= 4 && change.Contains(",") || change=="0")
                                    {

                                    }
                                    else
                                    {
                                        /*
                                        if (isHorOrExt == false)
                                        {
                                            change = callToCalculate.convertAndFormatSHORT(change);
                                        }
                                        */
                                    }

                                    dataGridView1.Rows[writeRow].Cells[col].Value = change;
                                }
                            }
                        }

                        indexSum = indexRow2;

                        for (int col = 0; col < maximunColumns; col++)
                        {
                            if (dataGridView1.Rows[writeRow].Cells[col].Value == null || dataGridView1.Rows[writeRow].Cells[col].Value.ToString() == "" || dataGridView1.Rows[writeRow].Cells[col].Value.ToString() == " ")
                            {
                                dataGridView1.Rows[writeRow].Cells[col].Style.BackColor = Color.Black;
                            }
                            else
                            {
                                dataGridView1.Rows[writeRow].Cells[col].Style.BackColor = Color.LightBlue;
                            }

                        }

                    }

                    //final loops
                    dataGridView1.Rows.Add("TOTAL FINAL");
                    int maximunRowsFinalR = dataGridView1.Rows.Count;
                    maximunRowsFinalR -= 2;
                    int maximunRowsFinalW = dataGridView1.Rows.Count;
                    maximunRowsFinalW -= 2;
                    int maximunColumnFinal = dataGridView1.Columns.Count;
                    for (int col = 1; col < maximunColumnFinal; col++)
                    {
                        bool number = false;
                        decimal sum = 0;
                        for (int row = 1; row < maximunRowsFinalR; row++)
                        {
                            if (dataGridView1.Rows[row].Cells[col].Style.BackColor == Color.LightBlue)
                            {
                                number = true;
                                string change = dataGridView1.Rows[row].Cells[col].Value.ToString();
                                if (change.Contains("."))
                                {
                                    change = change.Replace(",", "");
                                    change = change.Replace(".", ",");
                                }
                                try
                                {
                                    sum += decimal.Parse(change);
                                }
                                catch (Exception) { }
                            }
                        }
                        if (number == true)
                        {
                            string change = sum.ToString();
                            change = Regex.Replace(change, @"\p{C}+", string.Empty);
                            if (change == "0" || change.Length <=4)
                            {

                            }
                            else
                            {
                                if (!change.Contains(",")&& !change.Contains("."))
                                {
                                    calculateSystem callingToCalculate = new calculateSystem();
                                    change = callingToCalculate.convertAndFormat(change);
                                }
                            }
                            dataGridView1.Rows[maximunRowsFinalW].Cells[col].Value = change;
                        }
                    }
                    for (int col = 0; col < maximunColumnFinal; col++)
                    {
                        dataGridView1.Rows[maximunRowsFinalW].Cells[col].Style.BackColor = Color.LightGreen;
                    }
                }
            }
            else if (typeOfWork == typeSits)
            {
                foreach (string item in checkedListBox2.CheckedItems)
                {
                    ++numberWeek;
                }
                foreach (string item in checkedListBox3.CheckedItems)
                {
                    ++numberMonth;
                }
                foreach (string item in checkedListBox4.CheckedItems)
                {
                    ++numberDept;
                }

                if (numberDept == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUN DEPARTAMENTO PARA GENERAR LOS TOTALES");
                }
                else if (numberMonth == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUN MES PARA GENERAR LOS TOTALES");
                }
                else if (numberWeek == 0)
                {
                    MessageBox.Show("DEBES ELEGIR ALGUNA SEMANA PARA GENERAR LOS TOTALES");
                }else
                {
                    overrideList();
                    List<string> deparments = new List<string>();
                    foreach (string item in checkedListBox4.CheckedItems)
                    {
                        deparments.Add(item);
                    }
                    List<string[,]> listArrays = new List<string[,]>();
                    List<string> heads = new List<string>();

                    string addHead = "";
                    int indexAvoid = 0;
                    List<string> allowdAparment = new List<string>();

                    foreach (string compare in checkedListBox4.CheckedItems)
                    {
                        allowdAparment.Add(compare);
                    }

                    foreach (string compare in allowdAparment)
                    {
                        addHead = compare;
                        break;
                    }

                    int sizeAllowdAparment = allowdAparment.Count;
                    foreach (string data in fileList)
                    {
                        if (data.Contains(addHead))
                        {
                            //MessageBox.Show("REPEAT: " + addHead);
                            //break;
                        }
                        else
                        {
                            ++indexAvoid;
                            string[,] flag1 = { { "JUMPER", "JUMPER" } };
                            listArrays.Add(flag1);
                            addHead = allowdAparment[indexAvoid];
                            //MessageBox.Show("CHANGE: "+addHead);
                        }

                        string[] lines = File.ReadAllLines(data);
                        int maximunColumns = 0;
                        int maximunRows = 0;
                        foreach (string line in lines)
                        {
                            if (line == separator1)
                            {
                                ++maximunRows;
                                break;
                            }
                            if (line != "INDEX")
                            {
                                bool found = false;
                                foreach (string itemToCompare in heads)
                                {
                                    if (line == itemToCompare)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (found ==false)
                                {
                                    heads.Add(line);
                                }
                                ++maximunColumns;
                            }
                        }
                        foreach (string line in lines)
                        {
                            if (line == separator2)
                            {
                                ++maximunRows;
                            }
                        }
                        string[,] storageDataOfLines = new string[maximunRows, maximunColumns];
                        int index = 1;
                        for (int row = 0; row < maximunRows; row++) 
                        {
                            //int indexHead = 0;
                            for (int column = 0; column < maximunColumns; column++)
                            {
                                if(lines[index]==separator1 || lines[index] == separator2)
                                {
                                    ++index;
                                }

                                if (lines[index] == " " || lines[index] == "" || lines[index] == "  ")
                                {
                                    storageDataOfLines[row, column] = "0";
                                }
                                else
                                {
                                    storageDataOfLines[row, column] = lines[index];
                                }
                                ++index;
                            }
                        }
                        listArrays.Add(storageDataOfLines);
                    }
                    
                    string[,] flag = { { "JUMPER", "JUMPER" } };
                    listArrays.Add(flag);
                    
                    int numberofTry = 0;
                    List<string[,]> secondListArrays = new List<string[,]>();
                    foreach (string [,]arr in listArrays)
                    {
                        if(arr[0,0]=="JUMPER")
                        {
                            secondListArrays.Add(arr);
                            numberofTry = 0;
                            continue;
                        }
                        string[,] a = arr;
                        int b = a.GetLength(0);
                        int c = a.GetLength(1);
                        if (numberofTry == 0)
                        {
                            ++numberofTry;
                           /*
                            string d = "";
                            for (int row = 0; row < b; row++)
                            {
                                for (int column = 0; column < c; column++)
                                {
                                    d += a[row, column] + "<-->";
                                }
                                d += "\n\n";
                                //break;
                            }
                            MessageBox.Show("number1" +d);
                           */
                        }else
                        {
                            List<int> indexOfAvoid = new List<int>();
                            for (int row = 0; row < b; row++)
                            {
                                for (int column = 0; column < c; column++)
                                {
                                    if(a[row, column]=="C.C.S.S" || a[row, column] == "FUNERARIA" || a[row, column] == "VACACIONES" || a[row, column] == "REAJUSTES" || a[row, column] == "INCAPACIDAD" || a[row, column] == "PRESTAMOS" || a[row, column] == "VARIOS" || a[row, column] == "OTRAS DEDUCCIONES")
                                    //if (a[row, column] == "C.C.S.S" || a[row, column] == "FUNERARIA" || a[row, column] == "VACACIONES" || a[row, column] == "REAJUSTES" || a[row, column] == "INCAPACIDAD" || a[row, column] == "VARIOS")
                                    {
                                        indexOfAvoid.Add(column);
                                    }
                                }
                                break;
                            }

                            for (int row = 0; row < b; row++)
                            {
                                for (int column = 0; column < c; column++)
                                {
                                    bool found = false;
                                    foreach (int compare in indexOfAvoid)
                                    {
                                        if(compare==column)
                                        {
                                            found = true;
                                            break;
                                        }
                                    }
                                    if (row > 0)
                                    {
                                        if (found == true)
                                        {
                                            //MessageBox.Show(a[0, column]+ a[row, column]);
                                            a[row, column] = "0";
                                        }
                                    }
                                }
                            }
                            /*
                            string d = "";
                            for (int row = 0; row < b; row++)
                            {
                                for (int column = 0; column < c; column++)
                                {
                                    d += a[row, column] + "<-->";
                                }
                                d += "\n\n";
                                //break;
                            }
                            MessageBox.Show("number2" +d);
                            */
                        }

                        secondListArrays.Add(a);
                    }
                    
                    GUI_SELECCIONAR_ASIENTOS CallToASits = new GUI_SELECCIONAR_ASIENTOS();
                    CallToASits.receivedArray(secondListArrays);
                    CallToASits.receivedData(heads, deparments);
                    foreach(string item in checkedListBox2.CheckedItems)
                    {
                        if(item=="MOSTRAR")
                        {
                          
                        }else
                        {
                           week+=item;
                        }
                    }
                    CallToASits.PathToSave(company, deparment, month, week, file, path);
                    CallToASits.ShowDialog();
                    
                }
            }
        }

        private void overrideList()
        {
            headList.Clear();
            fileList.Clear();
            deparments.Clear();
            monthList.Clear();
            weeksList.Clear();
            string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\totales.txt";
            string[] HeadsToCompare = { };
            if (File.Exists(pathOfCheckHeads))
            {
                HeadsToCompare = File.ReadAllLines(pathOfCheckHeads);
            }

            actual = actual.Replace("\\bin\\Debug", "\\Companies");
            List<string> paths = new List<string>();
            
            foreach (string deparment in checkedListBox4.CheckedItems)
            {
                string change = deparment;
                int maximunLetter = change.Length;
                string evaluate = "";
                for (int letter = 0; letter < maximunLetter; letter++)
                {
                    if (change[letter] == ' ' && letter == 0 || change[letter] == ' ' && letter == 1)
                    {
                        continue;
                    }
                    else
                    {
                        evaluate += change[letter];
                    }
                }
                change = evaluate;
                string saveDeparment = change;
                string nameDepartment = actual + "\\" + company + "\\" + change;

                foreach (string month in checkedListBox3.CheckedItems)
                {
                    evaluate = "";
                    change = month;
                    maximunLetter = change.Length;
                    for (int letter = 0; letter < maximunLetter; letter++)
                    {
                        if (change[letter] == ' ' && letter == 0 || change[letter] == ' ' && letter == 1)
                        {
                            continue;
                        }
                        else
                        {
                            evaluate += change[letter];
                        }
                    }
                    change = evaluate;
                    string saveMonth = change;
                    string deparmentAddMonth = nameDepartment + "\\" + change;

                    foreach (string weeks in checkedListBox2.CheckedItems)
                    {
                        evaluate = "";
                        change = weeks;
                        maximunLetter = change.Length;
                        for (int letter = 0; letter < maximunLetter; letter++)
                        {
                            if (change[letter] == ' ' && letter == 0 || change[letter] == ' ' && letter == 1)
                            {
                                continue;
                            }
                            else
                            {
                                evaluate += change[letter];
                            }
                        }
                        change = evaluate;
                        deparments.Add(saveDeparment);
                        monthList.Add(saveMonth);
                        weeksList.Add(change);
                        string []storageWeeks= Directory.GetDirectories(deparmentAddMonth);
                        string deparmentAddMonthAddWeek = "";
                        foreach (string numberOfWeek in storageWeeks)
                        {
                            if (change.Contains("SEMANA 1") && numberOfWeek.Contains("1-7"))
                            {
                                deparmentAddMonthAddWeek = numberOfWeek;
                            }
                            else if (change.Contains("SEMANA 2") && numberOfWeek.Contains("8-14"))
                            {
                                deparmentAddMonthAddWeek = numberOfWeek;
                            }
                            else if (change.Contains("SEMANA 3") && numberOfWeek.Contains("15-21"))
                            {
                                deparmentAddMonthAddWeek = numberOfWeek;
                            }
                            else if (change.Contains("SEMANA 4") && numberOfWeek.Contains("22"))
                            {
                                deparmentAddMonthAddWeek = numberOfWeek;
                            }
                        }
                        string[] storageFiles = Directory.GetFiles(deparmentAddMonthAddWeek);
                        foreach(string file in storageFiles)
                        {
                            fileList.Add(file);
                        }
                    }
                }
                
                try{
                    foreach (string item in fileList)
                    {
                        string[] storageData = File.ReadAllLines(item);
                        bool found = false;
                        foreach (string head in storageData)
                        {
                            if (head == separator1)
                            {
                                break;
                            }
                            else
                            {
                                foreach (string compare in headList)
                                {
                                    if (compare == head)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }

                            if (found == false)
                            {
                                headList.Add(head);
                            }
                        }
                    }
                }catch (Exception) { }
            }
        }

        private void comboCheckListValueChanged(object sender, ItemCheckEventArgs e)
        {
            
            if (typeOfWork == typeTotal)
            {
                checkedListBox1.Items.Clear();
                overrideList();
                try
                {
                    foreach (string item in fileList)
                    {
                        string[] storageData = File.ReadAllLines(item);
                        bool found = false;
                        foreach (string head in storageData)
                        {
                            if (head == separator1)
                            {
                                break;
                            }
                            else
                            {
                                foreach (string compare in headList)
                                {
                                    if (compare == head)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }

                            if (found == false)
                            {
                                headList.Add(head);
                            }
                        }
                    }
                } catch (Exception) { }
                foreach (string item in headList)
                {
                    Invoke(new Action(() => checkedListBox1.Items.Add(item, false)));
                }
                actual = actual.Replace("\\bin\\Debug", "\\Companies");
                string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\totales.txt";
                string[] HeadsToCompare = { };
                if (File.Exists(pathOfCheckHeads))
                {
                    HeadsToCompare = File.ReadAllLines(pathOfCheckHeads);
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        bool headFound = false;
                        foreach (string itemToCompare in HeadsToCompare)
                        {
                            if (itemToCompare.Contains(checkedListBox1.Items[i].ToString()))
                            {
                                headFound = true;
                                break;
                            }
                        }
                        if (headFound == true)
                        {
                            checkedListBox1.SetItemChecked(i, true);
                        }
                    }
                }
            }else if (typeOfWork == typeSits)
            {
                //overrideList();
                /*
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                dataGridView1.Dispose();
                this.Width = 548;
                LoadDataInCheckBoxSits();
                */
            }

        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            if (typeOfWork == typeTotal)
            {

                string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\totales.txt";
                if (File.Exists(pathOfCheckHeads))
                {
                    File.Delete(pathOfCheckHeads);
                }
                FileStream fs = new FileStream(pathOfCheckHeads, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox4.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                foreach (string item in checkedListBox3.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                foreach (string item in checkedListBox2.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }else if (typeOfWork == typeSits)
            {
                string pathOfCheckHeads = actual + "\\" + company + "\\configuration\\sits.txt";
                if (File.Exists(pathOfCheckHeads))
                {
                    File.Delete(pathOfCheckHeads);
                }
                FileStream fs = new FileStream(pathOfCheckHeads, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs);
                foreach (string item in checkedListBox4.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                foreach (string item in checkedListBox3.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                foreach (string item in checkedListBox2.CheckedItems)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
            this.Close();
        }

        public void receivedWork(string receveivedTypeOfWork)
        {
            typeOfWork = receveivedTypeOfWork;
        }

        public void PathToSave(string companyReceive, string deptReceive, string monthReceive, string weekReceive, string fileReceive)
        {
            //path = pathReceive;
            company = companyReceive;
            company = company.Replace(" ", "_");
            deparment = deptReceive;
            month = monthReceive;
            week = weekReceive;
            file = fileReceive;
        }
        
        private void changeList(object sender, ItemCheckEventArgs e)
        {
            //overrideList();
        }
        
    }
}
