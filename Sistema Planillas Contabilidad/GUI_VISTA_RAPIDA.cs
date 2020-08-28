using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_VISTA_RAPIDA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_PLANILLA
    {
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] avoidData = { "INDEX", "CEDULA", "NOMBRE", "APELLIDO", "ORD DIU", "EXT DIU", "ORD NOC", "EXT NOC", "PRE HOR", "TOT ORD", "TOT EXT", "TOTAL SALAR" };
        string path = "";
        string separator1 = "-----------";
        string separator2 = "+++++++++++";
        public GUI_VISTA_RAPIDA()
        {
            InitializeComponent();
        }
        
        private void GUI_VISTA_RAPIDA_Load(object sender, EventArgs e)
        {
            LoadDataStart();
        }

        private void LoadDataStart()
        {
            string[] lines = File.ReadAllLines(path);
            int columnNumber = 0;
            int rowNumber = 0;
            int numberHeads = 0;

            for (int line = 0; line < lines.Length; line++)
            {
                if (lines[line] == separator1)
                {
                    numberHeads = columnNumber;
                }
                else if (lines[line] == separator2)
                {
                    ++rowNumber;
                }
                ++columnNumber;
            }

            //ADD COLUMNS
            for (int line = 0; line < numberHeads; line++)
            {
                if (lines[line] == separator1)
                {
                    break;
                }
                else
                {
                    try
                    {
                        dataGridView1.Columns.Add(lines[line].ToString(), lines[line].ToString());
                    }catch (Exception){}
                }
            }

            //ADD ROWS
            for (int line = 0; line < rowNumber; line++)
            {
                dataGridView1.Rows.Add(line.ToString());
            }

            int jumpRow = 0; //indexRow
            int cell = 1; //indexCell
            ++numberHeads; //indexStartReadLines
            for (int line = numberHeads; line < lines.Length; line++)
            {
                if (lines[line] == separator2)
                {
                    ++jumpRow;
                    ++line;
                    cell = 1;
                }
                try
                {
                    dataGridView1.Rows[jumpRow].Cells[cell].Value = lines[line];
                }
                catch (Exception)
                { }
                ++cell;
            }
        }
        public void PathToSave(string pathReceive) 
        {
            path = pathReceive;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
