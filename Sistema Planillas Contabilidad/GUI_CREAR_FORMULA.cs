using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_CREATE_FORMULA : Form
    {
        public GUI_CREATE_FORMULA()
        {
            InitializeComponent();
        }
        string separator2 = "+++++++++++";
        string defaultData="----";
        //string tipo1 = "ASIENTO";
        //string tipo2 = "CELDA";
        string opcion1 = "LOCAL";
        string opcion2 = "GLOBAL";
        string opcion3 = "LOCAL-GLOBAL";
        string actualPathOut = "";
        string actualPathIn = "";
        List<string> receivedHeads = new List<string>();
        string actual = Directory.GetCurrentDirectory();
        private void GUI_CREATE_FORMULA_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            //comboBoxType.Items.Add(tipo1);
            //comboBoxType.Items.Add(tipo2);
            foreach (string item in receivedHeads)
            {
                comboBox1.Items.Add(item);
            }
            //turnOffComboBox();
            //turnOffButton();
            textBox1.Text = "";
            comboBoxCharge.Items.Clear();
            comboBoxSave.Items.Clear();
            comboBoxUpdate.Items.Clear();
            comboBoxCharge.Items.Add("LOCAL");
            comboBoxCharge.Items.Add("GLOBAL");
            comboBoxSave.Items.Add("LOCAL");
            comboBoxSave.Items.Add("GLOBAL");
            comboBoxSave.Items.Add("LOCAL-GLOBAL");
            comboBoxUpdate.Items.Add("LOCAL");
            comboBoxUpdate.Items.Add("GLOBAL");
        }

        private void turnOnComboBox()
        {
            comboBoxSave.Enabled = true;
            comboBoxCharge.Enabled = true;
            comboBoxUpdate.Enabled = true;
            comboBoxEliminate.Enabled = true;
        }

        private void turnOffComboBox()
        {
            comboBoxSave.Enabled = false;
            comboBoxCharge.Enabled = false;
            comboBoxUpdate.Enabled = false;
            comboBoxEliminate.Enabled = false;
        }

        private void turnOnButton()
        {
            buttonNew.Enabled = true;
            buttonSave.Enabled = true;
            buttonCharge.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonEliminate.Enabled = true;
        }

        private void turnOffButton()
        {
            buttonNew.Enabled = false;
            buttonSave.Enabled = false;
            buttonCharge.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonEliminate.Enabled = false;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBoxCharge.Items.Clear();
            comboBoxSave.Items.Clear();
            comboBoxUpdate.Items.Clear();
            comboBoxCharge.Items.Add("LOCAL");
            comboBoxCharge.Items.Add("GLOBAL");
            comboBoxSave.Items.Add("LOCAL");
            comboBoxSave.Items.Add("GLOBAL");
            comboBoxSave.Items.Add("LOCAL-GLOBAL");
            comboBoxUpdate.Items.Add("LOCAL");
            comboBoxUpdate.Items.Add("GLOBAL");
        }
        
        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combox1Add(object sender, EventArgs e)
        {
            textBox1.Text += comboBox1.Text;
        }

        public void receivedData(List<string> listReceived)
        {
            receivedHeads = listReceived;
        }

        private void buttonCloseProgram_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                MessageBox.Show("IMPOSIBLE GUARDAR, FORMULA ESTA VACIO");
            }
            else if (comboBoxSave.Text == defaultData)
            {
                MessageBox.Show("IMPOSIBLE GUARDAR, UBICACION GUARDADO NO ELEGIDA");
            }
            else if (comboBoxSave.Text == opcion2)//global
            {
                if (!File.Exists(actualPathOut))
                {
                    MessageBox.Show(actualPathOut);
                    string storageFinal = "";
                    foreach (string line in textBox1.Lines)
                    {
                        string lineTextStudy = line;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }

                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            foreach (char letter in lineTextStudy)
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
                        }
                    }
                    storageFinal = storageFinal.ToString();
                    string[] splitData = storageFinal.Split('\n');
                    FileStream fs = new FileStream(actualPathOut, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in splitData)
                    {
                        writer.WriteLine(line);
                    }
                    //writer.WriteLine(separator2);
                    writer.Close();
                    MessageBox.Show("FORMULA GUARDADA EXITOSAMENTE");
                }
                else
                {
                    string[] lines = File.ReadAllLines(actualPathOut);
                    string storage = "";
                    bool allowedWrite = false;
                    foreach (string lineTextBox in textBox1.Lines)
                    {
                        string lineTextStudy = lineTextBox;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2,"");
                        }

                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            for (int line = 0; line < lines.Length; line++)
                            {
                                if (lines[line] == separator2)
                                {
                                    storage = storage.Replace("\n", "");
                                    if (storage == lineTextStudy)
                                    {
                                        allowedWrite = true;
                                        break;
                                    }
                                    storage = "";
                                }
                                else
                                {
                                    storage += lines[line];
                                }
                            }
                            if (allowedWrite == false)
                            {
                                string storageFinal = "";
                                foreach (char letter in lineTextStudy)
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
                                storageFinal = storageFinal.ToString();
                                string[] splitData = storageFinal.Split('\n');
                                TextWriter writer = new StreamWriter(actualPathOut, true);
                                foreach (string line in splitData)
                                {
                                    writer.WriteLine(line);
                                }
                                writer.WriteLine(separator2);
                                writer.Close();
                                MessageBox.Show("FORMULA GUARDADA EXITOSAMENTE");
                            }
                            else
                            {
                                MessageBox.Show("NO SE PUEDE AÑADIR FORMULA A GLOBAL, YA EXISTE");
                            }
                        }
                    }
                }
            }
            else if (comboBoxSave.Text == opcion1)//local
            {
                MessageBox.Show(actualPathIn);
                if (!File.Exists(actualPathIn))
                {
                    string storageFinal = "";
                    foreach (string line in textBox1.Lines)
                    {
                        string lineTextStudy = line;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }
                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            foreach (char letter in lineTextStudy)
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
                        }
                    }
                    storageFinal = storageFinal.ToString();
                    string[] splitData = storageFinal.Split('\n');
                    FileStream fs = new FileStream(actualPathIn, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in splitData)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                    MessageBox.Show("FORMULA CREADA EXITOSAMENTE");
                }
                else
                {
                    string[] lines = File.ReadAllLines(actualPathIn);
                    string storage = "";
                    bool allowedWrite = false;
                    foreach (string lineTextBox in textBox1.Lines)
                    {
                        string lineTextStudy = lineTextBox;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }

                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else 
                        {
                            for (int line = 0; line < lines.Length; line++)
                            {
                                if (lines[line] == separator2)
                                {
                                    storage = storage.Replace("\n", "");
                                    if (storage == lineTextStudy)
                                    {
                                        allowedWrite = true;
                                        break;
                                    }
                                    storage = "";
                                }
                                else
                                {
                                    storage += lines[line];
                                }
                            }
                            if (allowedWrite == false)
                            {
                                string storageFinal = "";
                                foreach (char letter in lineTextStudy)
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
                                storageFinal = storageFinal.ToString();
                                string[] splitData = storageFinal.Split('\n');
                                TextWriter writer = new StreamWriter(actualPathIn, true);
                                foreach (string line in splitData)
                                {
                                    writer.WriteLine(line);
                                }
                                writer.WriteLine(separator2);
                                writer.Close();
                                MessageBox.Show("FORMULA AGREGADA EXITOSAMENTE");
                            }
                            else
                            {
                                MessageBox.Show("NO SE PUEDE AÑADIR FORMULA A LOCAL, YA EXISTE");
                            }
                        }
                    }
                }
            }
            else if (comboBoxSave.Text == opcion3)//LOCAL-GLOBAL
            {
                if (!File.Exists(actualPathOut))
                {
                    string storageFinal = "";
                    foreach (string line in textBox1.Lines)
                    {
                        string lineTextStudy = line;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }
                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            foreach (char letter in lineTextStudy)
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
                        }
                    }
                    storageFinal = storageFinal.ToString();
                    string[] splitData = storageFinal.Split('\n');
                    FileStream fs = new FileStream(actualPathOut, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in splitData)
                    {
                        writer.WriteLine(line);
                    }
                    //writer.WriteLine(separator2);
                    writer.Close();
                    MessageBox.Show("FORMULA CREADA EXITOSAMENTE");
                }
                else
                {
                    string[] lines = File.ReadAllLines(actualPathOut);
                    string storage = "";
                    bool allowedWrite = false;
                    foreach (string lineTextBox in textBox1.Lines)
                    {
                        string lineTextStudy = lineTextBox;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }

                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            for (int line = 0; line < lines.Length; line++)
                            {
                                if (lines[line] == separator2)
                                {
                                    storage = storage.Replace("\n", "");
                                    if (storage == lineTextStudy)
                                    {
                                        allowedWrite = true;
                                        break;
                                    }
                                    storage = "";
                                }
                                else
                                {
                                    storage += lines[line];
                                }
                            }
                            if (allowedWrite == false)
                            {
                                string storageFinal = "";
                                foreach (char letter in lineTextStudy)
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
                                storageFinal = storageFinal.ToString();
                                string[] splitData = storageFinal.Split('\n');
                                TextWriter writer = new StreamWriter(actualPathOut, true);
                                foreach (string line in splitData)
                                {
                                    writer.WriteLine(line);
                                }
                                writer.WriteLine(separator2);
                                writer.Close();
                                MessageBox.Show("FORMULA AGREGADA EXITOSAMENTE");
                            }
                            else
                            {
                                MessageBox.Show("NO SE PUEDE AÑADIR FORMULA A GLOBAL, YA EXISTE");
                            }
                        }
                    }
                }

                if (!File.Exists(actualPathIn))
                {
                    string storageFinal = "";
                    foreach (string line in textBox1.Lines)
                    {
                        string lineTextStudy = line;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }
                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            foreach (char letter in lineTextStudy)
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
                        }
                    }
                    storageFinal = storageFinal.ToString();
                    string[] splitData = storageFinal.Split('\n');
                    FileStream fs = new FileStream(actualPathIn, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in splitData)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                    MessageBox.Show("FORMULA CREADA EXITOSAMENTE");
                }
                else
                {
                    string[] lines = File.ReadAllLines(actualPathIn);
                    string storage = "";
                    bool allowedWrite = false;
                    foreach (string lineTextBox in textBox1.Lines)
                    {
                        string lineTextStudy = lineTextBox;
                        if (lineTextStudy.Contains(separator2))
                        {
                            lineTextStudy = lineTextStudy.Replace(separator2, "");
                        }

                        if (lineTextStudy == " " || lineTextStudy == "")
                        {

                        }
                        else
                        {
                            for (int line = 0; line < lines.Length; line++)
                            {
                                if (lines[line] == separator2)
                                {
                                    storage = storage.Replace("\n", "");
                                    if (storage == lineTextStudy)
                                    {
                                        allowedWrite = true;
                                        break;
                                    }
                                    storage = "";
                                }
                                else
                                {
                                    storage += lines[line];
                                }
                            }
                            if (allowedWrite == false)
                            {
                                string storageFinal = "";
                                foreach (char letter in lineTextStudy)
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
                                storageFinal = storageFinal.ToString();
                                string[] splitData = storageFinal.Split('\n');
                                TextWriter writer = new StreamWriter(actualPathIn, true);
                                foreach (string line in splitData)
                                {
                                    writer.WriteLine(line);
                                }
                                writer.WriteLine(separator2);
                                writer.Close();
                                MessageBox.Show("FORMULA AGREGADA EXITOSAMENTE");
                            }
                            else
                            {
                                MessageBox.Show("NO SE PUEDE AÑADIR FORMULA A LOCAL, YA EXISTE");
                            }
                        }
                    }
                }
            }
        }

        private void buttonKey1_Click(object sender, EventArgs e)
        {
            //(
            textBox1.Text += "(";
        }

        private void buttonKey2_Click(object sender, EventArgs e)
        {
            //=
            textBox1.Text += "=";
        }

        private void buttonKey3_Click(object sender, EventArgs e)
        {
            //+
            textBox1.Text += "+";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //x
            textBox1.Text += "*";
        }

        private void buttonKey5_Click(object sender, EventArgs e)
        {
            //-
            textBox1.Text += "-";
        }

        private void buttonKey6_Click_1(object sender, EventArgs e)
        {
            // /
            textBox1.Text += "/";
        }

        private void buttonKey6_Click(object sender, EventArgs e)
        {
            //)
            textBox1.Text += ")";
        }

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            restarComponents();
        }

        private void buttonCharge_Click(object sender, EventArgs e)
        {
            if (comboBoxCharge.Text == defaultData)
            {
                MessageBox.Show("IMPOSIBLE CARGAR, UBICACION CARGAR NO ELEGIDA");
            }else if (comboBoxCharge.Text == opcion2)
            {
                textBox1.Text = "";
                if (File.Exists(actualPathOut))
                {
                    string[] lines = File.ReadAllLines(actualPathOut);
                    string storage = "";
                    foreach (string line in lines)
                    {
                        if (line == separator2)
                        {
                            textBox1.Text += storage + Environment.NewLine + separator2 + Environment.NewLine;
                            storage = "";
                        }
                        else
                        {
                            storage += line;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUEDEN CARGAR FORMULAS, YA QUE NO EXISTE NINGUN ARCHIVO DE FORMULAS");
                }
            }
            else if (comboBoxCharge.Text == opcion1)
            {
                textBox1.Text = "";
                if (File.Exists(actualPathIn))
                {
                    string[] lines = File.ReadAllLines(actualPathIn);
                    string storage = "";
                    foreach (string line in lines)
                    {
                        if (line == separator2)
                        {
                            textBox1.Text += storage + Environment.NewLine + separator2 + Environment.NewLine;
                            storage = "";
                        }
                        else
                        {
                            storage += line;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("NO SE PUEDEN CARGAR FORMULAS, YA QUE NO EXISTE NINGUN ARCHIVO DE FORMULAS");
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult elimnate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR EL ARCHIVO CON ESTAS FORMULAS Y REESCRIBIRLO CON LAS FORMULAS EN PANTALLA? \nNO PODRAN SER RECUPERADAS LAS FORMULAS ANTERIORES", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (elimnate)
            {
                case DialogResult.Yes:
                    if (comboBoxUpdate.Text == defaultData)
                    {
                        MessageBox.Show("IMPOSIBLE ACTUALIZAR, UBICACION ACTUALIZAR NO ELEGIDA");
                    }
                    else if (comboBoxUpdate.Text == opcion2)
                    {
                        if (comboBoxUpdate.Text.Contains(separator2))
                        {

                        }
                        else
                        {
                            comboBoxUpdate.Text += Environment.NewLine + separator2;
                        }
                        if (File.Exists(actualPathOut))
                        {
                            File.Delete(actualPathOut);
                            FileStream fs = new FileStream(actualPathOut, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            string storageFinal = "";
                            int maximunLines = textBox1.Lines.Length;
                            for (int line = 0; line < maximunLines; line++)
                            {
                                if (textBox1.Lines[line] == separator2)
                                {
                                    storageFinal = storageFinal.Replace(Environment.NewLine, "");
                                    writer.WriteLine(storageFinal);
                                    writer.WriteLine(separator2);
                                    storageFinal = "";
                                }
                                else
                                {
                                    foreach (char letter in textBox1.Lines[line])
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
                            writer.Close();
                            MessageBox.Show("FORMULA GLOBAL ACTUALIZADA EXITOSAMENTE");
                        }
                        else
                        {
                            if (comboBoxUpdate.Text.Contains(separator2))
                            {

                            }
                            else
                            {
                                comboBoxUpdate.Text += Environment.NewLine + separator2;
                            }
                            FileStream fs = new FileStream(actualPathOut, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            string storageFinal = "";
                            int maximunLines = textBox1.Lines.Length;
                            for (int line = 0; line < maximunLines; line++)
                            {
                                if (textBox1.Lines[line] == separator2)
                                {
                                    storageFinal = storageFinal.Replace(Environment.NewLine, "");
                                    writer.WriteLine(storageFinal);
                                    writer.WriteLine(separator2);
                                    storageFinal = "";
                                }
                                else
                                {
                                    foreach (char letter in textBox1.Lines[line])
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
                            writer.Close();
                            MessageBox.Show("FORMULA GLOBAL ACTUALIZADA EXITOSAMENTE");
                        }
                    }
                    else if (comboBoxUpdate.Text == opcion1)
                    {
                        if (File.Exists(actualPathIn))
                        {
                            File.Delete(actualPathIn);
                            FileStream fs = new FileStream(actualPathIn, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            string storageFinal = "";
                            int maximunLines = textBox1.Lines.Length;
                            for (int line = 0; line < maximunLines; line++)
                            {
                                if (textBox1.Lines[line] == separator2)
                                {
                                    storageFinal = storageFinal.Replace(Environment.NewLine, "");
                                    writer.WriteLine(storageFinal);
                                    writer.WriteLine(separator2);
                                    storageFinal = "";
                                }
                                else
                                {
                                    foreach (char letter in textBox1.Lines[line])
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
                            writer.Close();
                            MessageBox.Show("FORMULA LOCAL ACTUALIZADA EXITOSAMENTE");
                        }
                        else
                        {
                            FileStream fs = new FileStream(actualPathIn, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            string storageFinal = "";
                            int maximunLines = textBox1.Lines.Length;
                            for (int line = 0; line < maximunLines; line++)
                            {
                                if (textBox1.Lines[line] == separator2)
                                {
                                    storageFinal = storageFinal.Replace(Environment.NewLine, "");
                                    writer.WriteLine(storageFinal);
                                    writer.WriteLine(separator2);
                                    storageFinal = "";
                                }
                                else
                                {
                                    foreach (char letter in textBox1.Lines[line])
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
                            writer.Close();
                            MessageBox.Show("FORMULA LOCAL ACTUALIZADA EXITOSAMENTE");
                        }
                    }
                    break;
                    case DialogResult.No:
                    break;
            }
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

        private void restarComponents()
        {
            comboBoxCharge.Items.Clear();
            comboBoxSave.Items.Clear();
            comboBoxUpdate.Items.Clear();
            comboBoxEliminate.Items.Clear();
            textBox1.Text = "";
            comboBoxCharge.Text = defaultData;
            comboBoxCharge.Items.Add(opcion1);
            comboBoxCharge.Items.Add(opcion2);
            comboBoxSave.Text = defaultData;
            comboBoxSave.Items.Add(opcion1);
            comboBoxSave.Items.Add(opcion2);
            comboBoxSave.Items.Add(opcion3);
            comboBoxUpdate.Text = defaultData;
            comboBoxUpdate.Items.Add(opcion1);
            comboBoxUpdate.Items.Add(opcion2);
            comboBoxEliminate.Text = defaultData;
            comboBoxEliminate.Items.Add(opcion1);
            comboBoxEliminate.Items.Add(opcion2);
            comboBoxEliminate.Items.Add(opcion3);
            comboBoxSave.Enabled = true;
            buttonSave.Enabled = true;
            comboBoxCharge.Enabled = true;
            buttonCharge.Enabled = true;
            comboBoxUpdate.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void CellChangedSave(object sender, EventArgs e)
        {
            comboBoxCharge.Enabled = false;
            buttonCharge.Enabled = false;
            comboBoxUpdate.Enabled = false;
            buttonUpdate.Enabled = false;
            if (comboBoxSave.Text == opcion1)
            {
                //local
                actualPathIn = actual.Replace("\\bin\\Debug", "\\Companies");
                actualPathIn +="\\" + company + "\\configuration\\formula.txt";
                //chargeComponentes();
                comboBoxUpdate.Enabled = false;
                buttonUpdate.Enabled = false;
            }
            else if (comboBoxSave.Text == opcion2)
            {
                //global
                actualPathOut = actual.Replace("\\bin\\Debug", "\\configuration");
                actualPathOut += "\\Formulas\\formula.txt";
                //chargeComponentes();
                comboBoxUpdate.Enabled = false;
                buttonUpdate.Enabled = false;
            }
        }

        private void CellChangedUpdate(object sender, EventArgs e)
        {
            comboBoxSave.Enabled = false;
            buttonSave.Enabled = false;
            comboBoxCharge.Enabled = false;
            buttonCharge.Enabled = false;
            if (comboBoxCharge.Text == opcion1)
            {
                actualPathIn = actual.Replace("\\bin\\Debug", "\\Companies");
                actualPathIn += "\\" + company + "\\configuration\\formula.txt";
                //MessageBox.Show(actualPathIn);
            }
            else if (comboBoxCharge.Text == opcion2)
            {
                actualPathOut = actual.Replace("\\bin\\Debug", "\\configuration");
                actualPathOut += "\\Formulas\\formula.txt";
            }
        }

        private void CellChangedCharge(object sender, EventArgs e)
        {
            //comboBoxSave.Enabled = false;
            //buttonSave.Enabled = false;
            comboBoxUpdate.Enabled = true;
            buttonUpdate.Enabled = true;
            if (comboBoxCharge.Text == opcion1)
            {
                actualPathIn = actual.Replace("\\bin\\Debug", "\\Companies");
                actualPathIn += "\\" + company + "\\configuration\\formula.txt";
                //MessageBox.Show(actualPathIn);
            }
            else if (comboBoxCharge.Text == opcion2)
            {
                actualPathOut = actual.Replace("\\bin\\Debug", "\\configuration");
                actualPathOut += "\\Formulas\\formula.txt";
            }
        }

        private void buttonRestar_Click(object sender, EventArgs e)
        {
            restarComponents();
        }

        private void buttonEliminate_Click(object sender, EventArgs e)
        {
            DialogResult elimnate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR EL ARCHIVO CON ESTAS FORMULAS?  \nNO PODRA SER RECUPERADO", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (elimnate)
            {
                case DialogResult.Yes:
                    if (comboBoxEliminate.Text == defaultData)
                    {
                        MessageBox.Show("IMPOSIBLE ELIMINAR, UBICACION ELIMINAR NO ELEGIDA");
                    }
                    else if (comboBoxEliminate.Text == opcion1)
                    {
                        if (File.Exists(actualPathIn))
                        {
                            File.Delete(actualPathIn);
                            MessageBox.Show("ELIMINADO FORMULAS LOCALES EXITOSAMENTE");
                        }
                        else
                        {
                            MessageBox.Show("ELIMINAR FORMULAS LOCALES FALLIDO, ARCHIVO NO EXISTE");
                        }

                    }
                    else if (comboBoxEliminate.Text == opcion2)
                    {
                        if (File.Exists(actualPathOut))
                        {
                            File.Delete(actualPathOut);
                            MessageBox.Show("ELIMINADO FORMULAS GLOBALES EXITOSAMENTE");
                        }
                        else
                        {
                            MessageBox.Show("ELIMINAR FORMULAS GLOBALES FALLIDO, ARCHIVO NO EXISTE");
                        }
                    }
                    else if (comboBoxEliminate.Text == opcion3)
                    {
                        if (File.Exists(actualPathIn))
                        {
                            File.Delete(actualPathIn);
                            MessageBox.Show("ELIMINADO FORMULAS LOCALES EXITOSAMENTE");
                        }
                        else
                        {
                            MessageBox.Show("ELIMINAR FORMULAS LOCALES FALLIDO, ARCHIVO NO EXISTE");
                        }
                        if (File.Exists(actualPathOut))
                        {
                            File.Delete(actualPathOut);
                            MessageBox.Show("ELIMINADO FORMULAS GLOBALES EXITOSAMENTE");
                        }
                        else
                        {
                            MessageBox.Show("ELIMINAR FORMULAS GLOBALES FALLIDO, ARCHIVO NO EXISTE");
                        }
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void chargeComponentes()
        {
            comboBoxSave.Items.Clear();
            comboBoxCharge.Items.Clear();
            comboBoxUpdate.Items.Clear();
            comboBoxEliminate.Items.Clear();
            comboBoxSave.Text = defaultData;
            comboBoxCharge.Text = defaultData;
            comboBoxUpdate.Text = defaultData;
            comboBoxEliminate.Text = defaultData;
            turnOnComboBox();
            //turnOffComboBox();
            turnOnButton();
            //turnOffButton();
            comboBoxSave.Items.Add(opcion1);
            comboBoxSave.Items.Add(opcion2);
            comboBoxSave.Items.Add(opcion3);
            comboBoxCharge.Items.Add(opcion1);
            comboBoxCharge.Items.Add(opcion2);
            comboBoxUpdate.Items.Add(opcion1);
            comboBoxUpdate.Items.Add(opcion2);
            comboBoxEliminate.Items.Add(opcion1);
            comboBoxEliminate.Items.Add(opcion2);
            comboBoxEliminate.Items.Add(opcion3);
        }
        private void buttonType_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
