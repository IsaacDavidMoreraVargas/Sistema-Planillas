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
    public partial class GUI_EDITAR_PLANTILLA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_PLANILLA
    {
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27" };
        int locationCell = 0;

        bool AllowedUpdateAction = false;
        bool AllowedOnlyOnce = false;
        bool optionMenu;
        int cellsNumber = 0;
        int rowNumber = 0;
        string path = "";
        string finalPath = Directory.GetCurrentDirectory();

        public GUI_EDITAR_PLANTILLA()
        {
            InitializeComponent();
        }

        private void GUI_EDITAR_PLANTILLA_Load(object sender, EventArgs e)
        {
            if (optionMenu == true)
            {
                LoadDataStart();
            }
            else
            {
                buttonUpdateTemplate.Text = "Guardar plantilla";
            }
          
        }

        private void LoadDataStart()
        {
            dataGridView1.Columns.Add("", "");
            path = path.Replace(" ", "_");
           
            finalPath = finalPath.Replace("\\bin\\Debug", "\\configuration\\Templates\\" + path + ".txt");
            using (StreamReader file = new StreamReader(finalPath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "-----------")
                    {
                        break;
                    }
                    else
                    {
                        dataGridView1.Columns.Add(alphabet[cellsNumber], alphabet[cellsNumber]);
                        ++cellsNumber;
                    }
                }
                file.Close();
            }
            dataGridView1.Rows.Add(rowNumber.ToString());
            cellsNumber = 1;
            using (StreamReader file = new StreamReader(finalPath))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line == "-----------")
                    {
                        break;
                    }
                    else
                    {
                        dataGridView1.Rows[rowNumber].Cells[cellsNumber].Value = line;
                        ++cellsNumber;
                    }
                    
                }
                file.Close();
            }
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            
            object ColumToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA:");
            dataGridView1.Columns.Add(alphabet[cellsNumber], alphabet[cellsNumber]);
            dataGridView1.Rows[rowNumber].Cells[cellsNumber].Value = ColumToEnter;
            AllowedUpdateAction = true;
            ++cellsNumber;
            
        }

        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            if (locationCell > 1)
            {
                int rowNumberSave = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;

                    for (int cell = 0; cell < maximunCells; cell++)
                    {
                        if (locationCell == cell)
                        {
                            int indexToMove = locationCell;
                            try
                            {
                                object dataActual = dataGridView1.Rows[rowNumberSave].Cells[cell].Value;
                                object dataBefore = dataGridView1.Rows[rowNumberSave].Cells[--cell].Value;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Value = dataBefore;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Style.BackColor = Color.White;
                                dataGridView1.Rows[rowNumberSave].Cells[--indexToMove].Value = dataActual;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Style.BackColor = Color.LightGreen;
                                dataGridView1.Update();
                                AllowedUpdateAction = true;
                                --locationCell;
                                goto endLoop;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("SUCEDIO UN PROBLEMA MOVIENDO LA COLUMNA");
                                break;
                            }

                        }
                    }
                }
                endLoop:;
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL INICIO");
            }
            
        }

        private void buttonMoveNextColumn_Click(object sender, EventArgs e)
        {
            int end = dataGridView1.Columns.Count;
            --end;
            if (locationCell < end)
            {
                int rowNumberSave = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;

                    for (int cell = 0; cell < maximunCells; cell++)
                    {
                        if (locationCell == cell)
                        {
                            int indexToMove = locationCell;
                            try
                            {
                                object dataBefore = dataGridView1.Rows[rowNumberSave].Cells[cell].Value;
                                object dataAfter = dataGridView1.Rows[rowNumberSave].Cells[++cell].Value;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Value = dataAfter;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Style.BackColor = Color.White;
                                dataGridView1.Rows[rowNumberSave].Cells[++indexToMove].Value = dataBefore;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Style.BackColor = Color.LightGreen;
                                dataGridView1.Update();
                                AllowedUpdateAction = true;
                                ++locationCell;
                                goto endLoop;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("SUCEDIO UN PROBLEMA MOVIENDO LA COLUMNA");
                                break;
                            }

                        }
                    }
                }
                endLoop:;
            }
            else 
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
            }
        }

        private void buttonEraseColumn_Click(object sender, EventArgs e)
        {
            
            int rowNumberSave = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int maximunCells = row.Cells.Count;
                int indexActual = 0;
                int indexToMove = 0;
                for (int cell = 0; cell < maximunCells; cell++)
                {
                    if (locationCell == cell)
                    {
                        try
                        {
                            for (indexActual = ++cell; indexActual < maximunCells; indexActual++)
                            {
                                indexToMove = indexActual;
                                --indexToMove;
                                object dataActual = dataGridView1.Rows[rowNumberSave].Cells[indexActual].Value;
                                dataGridView1.Rows[rowNumberSave].Cells[indexToMove].Value = dataActual;
                            }

                            int maximunColumns = dataGridView1.Columns.Count;
                            dataGridView1.Columns.RemoveAt(--maximunColumns);
                            dataGridView1.Update();
                            --cellsNumber;
                            AllowedUpdateAction = true;
                            goto endLoop;
                        }
                        catch (Exception)
                        { 
                            MessageBox.Show("SUCEDIO UN PROBLEMA ELIMINANDO COLUMNAS");
                            break;
                        }
                    }
                }
            }
            endLoop:;
        }
        
        private void buttonUpdateTemplate_Click(object sender, EventArgs e)
        {
            if (optionMenu == false)
            {
                if (AllowedUpdateAction == true)
                {
                    string nameToSave = Microsoft.VisualBasic.Interaction.InputBox("-SE ESPECIFICO PARA UNA MEJOR COMPRENSION FUTURA \n-NO USES SIMBOLOS ESPECIALES \nDAME EL NOMBRE DE LA PLANTILLA:");
                    if(nameToSave==null)
                    {
                        MessageBox.Show("DEBES ELEGIR UN NOMBRE VALIDO");
                    }else
                    {
                        string path = nameToSave.ToString();
                        path = path.Replace(" ", "_");
                        finalPath = finalPath.Replace("\\bin\\Debug", "\\configuration\\Templates\\" + path + ".txt");
                        //MessageBox.Show(finalPath);
                        int rowNumberSave = 0;
                        if (!File.Exists(finalPath))
                        {
                            FileStream fs = new FileStream(finalPath, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                int maximunCells = row.Cells.Count;
                                for (int cell = 0; cell < maximunCells; cell++)
                                {
                                    object data = dataGridView1.Rows[rowNumberSave].Cells[cell].Value;
                                    writer.WriteLine(data.ToString());
                                }
                            }
                            writer.WriteLine("-----------");
                            writer.Close();
                            MessageBox.Show("GUARDADO EXITOSAMENTE");
                        } else
                        {
                            MessageBox.Show("YA EXISTE UNA PLANTILLA CON ESTE NOMBRE \n-ELIMINALA \n-TRATA OTRO NOMBRE");
                        }
                    }
                   
                }else
                {
                    MessageBox.Show("CREE ALGUNA COLUMNA PARA PODER GUARDAR");
                }
            }
            else
            {
                if (AllowedUpdateAction == true)
                {
                    int rowNumberSave = 0;
                    if (File.Exists(finalPath))
                    {
                        File.Delete(finalPath);
                    }
                    FileStream fs = new FileStream(finalPath, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    int maximunRows = dataGridView1.Rows.Count;
                    --maximunRows;
                    int maximunCells = dataGridView1.Columns.Count;
                    for (int rows = 0; rows < maximunRows; rows++)
                    {
                        for (int cell = 1; cell < maximunCells; cell++)
                        {
                            object data = dataGridView1.Rows[rowNumberSave].Cells[cell].Value;
                            writer.WriteLine(data.ToString());
                        }
                    }
                    writer.WriteLine("-----------");
                    writer.Close();
                    MessageBox.Show("ACTUALIZADO EXITOSAMENTE");
                }
                else
                {
                    MessageBox.Show("CAMBIE PRIMERO ALGO ANTES DE ACTUALIZARLO");
                }
            }
            
        }

        private void buttonReturnScreen_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_EDITAR_PLANTILLA llamadoMenuPlantilla = new GUI_MENU_EDITAR_PLANTILLA();
            llamadoMenuPlantilla.ShowDialog();
            this.Close();
        }

        private void CellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;

                    for (int cell = 0; cell < maximunCells; cell++)
                    {
                        dataGridView1.Rows[row.Index].Cells[cell].Style.BackColor = Color.White;
                    }
                }

            }
            catch (Exception)
            { }

            try
            {
                AllowedUpdateAction = true;
                locationCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { 
              MessageBox.Show("HUBO ALGUN PROBLEMA SELECCIONANDO LA COLUMNA"); 
            }
            
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PathToSave(string pathReceive)   // property
        {
            path = pathReceive;
        }

        public void menuAction(bool option)
        {
            optionMenu = option;
        }
    }
}