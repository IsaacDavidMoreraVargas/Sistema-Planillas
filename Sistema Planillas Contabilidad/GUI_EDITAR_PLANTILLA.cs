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
        int indexColumn = 0;

        string optionMenu = "";
        string nameTemplate="";

        public GUI_EDITAR_PLANTILLA()
        {
            InitializeComponent();
        }

        string pathOfCompany = "";
        string SelectedCompany = "";

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

        string coreExtraConfiguration = "";
        string threeLine = "";
        string deparmentValue = "";
        string configuration = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";

        string startHead ="";
        string endHead ="";

        SpecificAndCorePaths startThePaths;
        TagsAndDefaultValues startTheTagsAndDefaults;
        FoldersInsideCompany startFoldersInsideCompany;
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
            //CorePathOfPicturesFolderSistemaPlanillas = startThePaths.CorePathOfPicturesFolderSistemaPlanillas;
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
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            configuration = startFoldersInsideCompanyReceived.isConfiguration;
            exclusiveData = startFoldersInsideCompanyReceived.isExclusiveData;
            sits = startFoldersInsideCompanyReceived.isSits;
            template = startFoldersInsideCompany.isTemplate;
            //default tags
            startHead = startTheTagsAndDefaultsReceived.isTagStartHead;
            endHead = startTheTagsAndDefaultsReceived.isTagEndHead;
        }

        private void GUI_EDITAR_PLANTILLA_Load(object sender, EventArgs e)
        {
            if (optionMenu == "EDITAR")
            {
                startChargeData();
            }
            else if (optionMenu == "NUEVO")
            {
                buttonUpdateTemplate.Text = "Guardar plantilla";
            }
          
        }

        private void startChargeData()
        {
            string []pathToReadTemplate = File.ReadAllLines(SpecificPathOfFolderConfigurationTemplates + nameTemplate + ".txt");
            foreach(string line in pathToReadTemplate)
            {
                string changeString = line;
                changeString = changeString.ToUpper();
                if (line == endHead)
                {
                    break;
                }
                else if (line != startHead)
                {
                    dataGridView1.Columns.Add(changeString, changeString);
                }
            }
        }

        
        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            string dataToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA:");
            dataToEnter = dataToEnter.ToUpper();
            if (optionMenu == "NUEVO")
            {
                dataGridView1.Columns.Add(dataToEnter,dataToEnter);
                colorateTheCells();
                ++indexColumn;
            }else if (optionMenu == "EDITAR")
            {
                generalMultiArrayMethods callArrayMethods = new generalMultiArrayMethods();
                string[,] multiArrayReceived = callArrayMethods.addColum(dataGridView1, dataToEnter, indexColumn, 1);
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                //int numberOfRows = multiArrayReceived.GetLength(0);
                int numberOfColumns = multiArrayReceived.GetLength(1);
                for (int column = 0; column < numberOfColumns; column++)
                {
                    dataGridView1.Columns.Add(multiArrayReceived[0, column], multiArrayReceived[0, column]);
                }
                colorateTheCells();
                ++indexColumn;
            }
            
        }

        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            if (indexColumn > 0)
            {
                generalMultiArrayMethods callArrayMethods = new generalMultiArrayMethods();
                string[,] multiArrayReceived = callArrayMethods.MoveBackColum(dataGridView1, indexColumn);
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                //int numberOfRows = multiArrayReceived.GetLength(0);
                int numberOfColumns = multiArrayReceived.GetLength(1);
                for (int column = 0; column < numberOfColumns; column++)
                {
                    dataGridView1.Columns.Add(multiArrayReceived[0,column], multiArrayReceived[0, column]);
                }
                --indexColumn;
                colorateTheCells();
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL INICIO");
            }
        }

        private void buttonMoveNextColumn_Click(object sender, EventArgs e)
        {
            if (indexColumn < dataGridView1.Columns.Count-1)
            {
                generalMultiArrayMethods callArrayMethods = new generalMultiArrayMethods();
                string[,] multiArrayReceived = callArrayMethods.MoveNextColum(dataGridView1, indexColumn);
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                //int numberOfRows = multiArrayReceived.GetLength(0);
                int numberOfColumns = multiArrayReceived.GetLength(1);
                for (int column = 0; column < numberOfColumns; column++)
                {
                    dataGridView1.Columns.Add(multiArrayReceived[0, column], multiArrayReceived[0, column]);
                }
                ++indexColumn;
                colorateTheCells();
            }
            else 
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
            }
        }

        private void buttonEraseColumn_Click(object sender, EventArgs e)
        {
            generalMultiArrayMethods callArrayMethods = new generalMultiArrayMethods();
            string[,] multiArrayReceived = callArrayMethods.eraseColum(dataGridView1, indexColumn,1);
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            //int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int column = 0; column < numberOfColumns; column++)
            {
                dataGridView1.Columns.Add(multiArrayReceived[0, column], multiArrayReceived[0, column]);
            }
            colorateTheCells();
        }
        
        private void buttonUpdateTemplate_Click(object sender, EventArgs e)
        {
            if(optionMenu=="NUEVO")
            {
                string nameToSave = Microsoft.VisualBasic.Interaction.InputBox("-SE ESPECIFICO PARA UNA MEJOR COMPRENSION FUTURA \n-NO USES SIMBOLOS ESPECIALES \nDAME EL NOMBRE DE LA PLANTILLA:");
                nameToSave = nameToSave.ToUpper();
                nameToSave = nameToSave.Replace(" ", "_");
                nameTemplate = nameToSave;
            }
            else if (optionMenu == "EDITAR")
            {

            }

            string pathToEraseAndAdd = SpecificPathOfFolderConfigurationTemplates + nameTemplate + ".txt";
            if(File.Exists(pathToEraseAndAdd))
            {
                File.Delete(pathToEraseAndAdd);
            }

            FileStream fs = new FileStream(pathToEraseAndAdd, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(startHead);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                writer.WriteLine(column.HeaderText);
            }
            writer.WriteLine(endHead);
            writer.Close();
            MessageBox.Show("GUARDADO EXITOSAMENTE");
        }

        private void colorateTheCells()
        {
            int sizeColumns = dataGridView1.Columns.Count;
            for (int cell = 0; cell < sizeColumns; cell++)
            {
                if (cell == indexColumn)
                {
                    dataGridView1.Columns[cell].DefaultCellStyle.BackColor = Color.LightGreen;
                }else
                {
                    dataGridView1.Columns[cell].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void CellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexColumn = dataGridView1.Columns[e.ColumnIndex].Index;
                colorateTheCells();
            }catch (Exception)
            { 
              MessageBox.Show("HUBO ALGUN PROBLEMA SELECCIONANDO LA COLUMNA"); 
            }
            
        }

        public void nameOFTemplate(string nameTemplateReceived)
        {
            nameTemplate = nameTemplateReceived;
            nameTemplate = nameTemplate.Replace(" ", "_");
        }

        public void menuNewOrUpdate(string option)
        {
            optionMenu = option;
        }

        private void buttonReturnScreen_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_EDITAR_PLANTILLA llamadoMenuPlantilla = new GUI_MENU_EDITAR_PLANTILLA();
            llamadoMenuPlantilla.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            llamadoMenuPlantilla.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}