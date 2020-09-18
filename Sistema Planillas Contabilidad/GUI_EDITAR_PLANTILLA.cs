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
            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "CABEZALES";
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
                    listView1.Items.Add(changeString);
                }
            }
        }

        
        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            string dataToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA:");
            if (dataToEnter != "" && dataToEnter != " ")
            {
                dataToEnter = dataToEnter.ToUpper();
                if (optionMenu == "NUEVO")
                {
                    listView1.Items.Add(dataToEnter);
                }
                else if (optionMenu == "EDITAR")
                {
                    List<string> subString = new List<string>();
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Index == indexColumn)
                        {
                            subString.Add(dataToEnter);
                            subString.Add(item.Text);
                        }else
                        {
                            subString.Add(item.Text);
                        }
                    }
                    listView1.Items.Clear();
                    foreach (string item in subString)
                    {
                        listView1.Items.Add(item);
                    }
                }
                colorateTheCells();
            }
        }

        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            if (indexColumn > 0)
            {
                int actualIndex = indexColumn;
                int afterIndex = indexColumn - 1;
                string actualData = listView1.Items[actualIndex].Text;
                string afterData = listView1.Items[afterIndex].Text;
                listView1.Items[actualIndex].Text = afterData;
                listView1.Items[afterIndex].Text = actualData;
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
            if (indexColumn < listView1.Items.Count-1)
            {
                int actualIndex = indexColumn;
                int afterIndex = indexColumn +1;
                string actualData = listView1.Items[actualIndex].Text;
                string afterData = listView1.Items[afterIndex].Text;
                listView1.Items[actualIndex].Text = afterData;
                listView1.Items[afterIndex].Text = actualData;
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
            listView1.Items.RemoveAt(indexColumn);
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
                //change nothing
            }

            string pathToEraseAndAdd = SpecificPathOfFolderConfigurationTemplates + nameTemplate + ".txt";
            if(File.Exists(pathToEraseAndAdd))
            {
                File.Delete(pathToEraseAndAdd);
            }

            FileStream fs = new FileStream(pathToEraseAndAdd, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(startHead);
            foreach (ListViewItem item in listView1.Items)
            {
                writer.WriteLine(item.Text);
            }
            writer.WriteLine(endHead);
            writer.Close();
            MessageBox.Show("GUARDADO EXITOSAMENTE");
        }

        private void colorateTheCells()
        {
            for (int cell = 0; cell < listView1.Items.Count; cell++)
            {
                if (cell == indexColumn)
                {
                    listView1.Items[cell].BackColor = Color.LightGreen;
                }else
                {
                    listView1.Items[cell].BackColor = Color.White;
                }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexColumn = listView1.FocusedItem.Index;
            try
            {
                colorateTheCells();
            }
            catch (Exception) { }
        }
    }
}