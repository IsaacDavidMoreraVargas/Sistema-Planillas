using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_MENU_EDITAR_PLANTILLA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {
        string FinalPath = "";
        bool AllowEdit = false;
        public GUI_MENU_EDITAR_PLANTILLA()
        {
            InitializeComponent();
        }

        private void GUI_MENU_EDITAR_PLANTILLA_Load(object sender, EventArgs e)
        {
            ChargeData();
        }

        private void ChargeData()
        {
            LISTEMPLATE.Items.Clear();
            FinalPath = Directory.GetCurrentDirectory();
            FinalPath = FinalPath.Replace("\\bin\\Debug", "\\configuration\\Templates");
            string[]filename = Directory.GetFiles(FinalPath);
            foreach(string x in filename)
            {
                string addItem = x.Replace(FinalPath+ "\\", "");
                addItem = addItem.Replace(".txt","");
                addItem = addItem.Replace("_", " ");
                if (addItem == "" || addItem == " " || addItem == "_")
                {
                    //donothing
                }
                else
                {
                    LISTEMPLATE.Items.Add(addItem);
                }

            }

            LISTEMPLATE.View = View.Details;
            LISTEMPLATE.Columns[0].Width = LISTEMPLATE.Width;
            LISTEMPLATE.Columns[0].Text = "PLANTILLAS";
            LISTEMPLATE.Columns[0].TextAlign = HorizontalAlignment.Center;
        }

        private void buttonGoEditTemplate_Click(object sender, EventArgs e)
        {
            if (AllowEdit == true)
            {
                this.Hide();
                GUI_EDITAR_PLANTILLA callEditTemplate = new GUI_EDITAR_PLANTILLA();
                callEditTemplate.menuAction(true);
                callEditTemplate.PathToSave(SelectFile);
                callEditTemplate.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("SELECCIONE ALGUNA PLANTILLA PRIMERO");
            }
        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_INICIO callMenuTemplate = new GUI_MENU_INICIO();
            callMenuTemplate.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string SelectFile = "";
        int IndexViewList = 0;
        private void LISTAPLANTILLAS_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LISTEMPLATE.FocusedItem == null)
            {
                return;
            }else
            {
                IndexViewList = LISTEMPLATE.FocusedItem.Index;
            }

            if (LISTEMPLATE.Items[IndexViewList].Text == "" || LISTEMPLATE.Items[IndexViewList].Text == "PLANTILLAS")
            {
                MessageBox.Show("SELECCIONA UNA PLANTILLA VALIDA PARA ELIMINAR");
            }
            else
            {
                AllowEdit = true;
                SelectFile = LISTEMPLATE.Items[IndexViewList].Text;
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
                this.Hide();
                GUI_EDITAR_PLANTILLA callEditTemplate = new GUI_EDITAR_PLANTILLA();
                callEditTemplate.menuAction(false);
                callEditTemplate.PathToSave(SelectFile);
                callEditTemplate.ShowDialog();
                this.Close();
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            if (AllowEdit == true)
            {
                object duplicateFile = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE QUE LE PONDRAS A LA PLANTILLA DUPLICADA:");
                string modificationName = duplicateFile.ToString();
                modificationName = modificationName.Replace(" ", "_");
                string readPath = SelectFile;
                readPath = SelectFile.Replace(" ", "_");
                readPath = FinalPath + "\\" + readPath + ".txt";
                string[] lines = File.ReadAllLines(readPath);
                string writePath = FinalPath + "\\" + modificationName + ".txt";
                if (!File.Exists(writePath))
                {
                    FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                    MessageBox.Show("DUPLICADO EXITOSAMENTE");
                    ChargeData();
                }
                else
                {
                    MessageBox.Show("YA EXISTE UNA PLANTILLA CON ESTE NOMBRE \n-ELIMINALA \n-TRATA OTRO NOMBRE");
                }
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE DUPLICAR");
            }
        }

        private void buttonEliminateFile_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR ESTA PLANTILLA?, NO PODRA SER RECUPERADA", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (answer)
            {
                case DialogResult.Yes:
                    try
                    {
                        string readPath = SelectFile;
                        readPath = FinalPath + "\\" + readPath + ".txt";
                        File.Delete(readPath);
                        MessageBox.Show("ELIMINANDO EXITOSAMENTE");
                        ChargeData();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("HUBO UN PROBLEMA ELIMINANDO LA PLANTILLA");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }
    }
}
