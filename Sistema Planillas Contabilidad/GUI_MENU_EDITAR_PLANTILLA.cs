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
        bool AllowEdit = false;
        public GUI_MENU_EDITAR_PLANTILLA()
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
        string formula = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";

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
            formula = startFoldersInsideCompanyReceived.isFormula;
            exclusiveData = startFoldersInsideCompanyReceived.isExclusiveData;
            sits = startFoldersInsideCompanyReceived.isSits;
            template = startFoldersInsideCompany.isTemplate;
        }

        private void GUI_MENU_EDITAR_PLANTILLA_Load(object sender, EventArgs e)
        {
            startChargeData();
        }

        private void startChargeData()
        {
            LISTEMPLATE.Items.Clear();
            string[]storageTemplates = Directory.GetFiles(SpecificPathOfFolderConfigurationTemplates);
            foreach(string template in storageTemplates)
            {
                string changeString = template.Replace(SpecificPathOfFolderConfigurationTemplates, "");
                changeString = changeString.Replace(".txt", "");
                changeString = changeString.Replace("_", " ");
                LISTEMPLATE.Items.Add(changeString);
            }

            LISTEMPLATE.View = View.Details;
            LISTEMPLATE.Columns[0].Width = LISTEMPLATE.Width;
            LISTEMPLATE.Columns[0].Text = "PLANTILLAS";
            LISTEMPLATE.Columns[0].TextAlign = HorizontalAlignment.Center;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
                this.Hide();
                GUI_EDITAR_PLANTILLA callEditTemplate = new GUI_EDITAR_PLANTILLA();
                callEditTemplate.menuNewOrUpdate("NUEVO");
                callEditTemplate.nameOFTemplate(selectedFile);
                callEditTemplate.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                callEditTemplate.ShowDialog();
                this.Close();
        }

        private void buttonGoEditTemplate_Click(object sender, EventArgs e)
        {
            if (AllowEdit == true)
            {
                this.Hide();
                GUI_EDITAR_PLANTILLA callEditTemplate = new GUI_EDITAR_PLANTILLA();
                callEditTemplate.menuNewOrUpdate("EDITAR");
                callEditTemplate.nameOFTemplate(selectedFile);
                callEditTemplate.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                callEditTemplate.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("SELECCIONE ALGUNA PLANTILLA PRIMERO");
            }
        }

        private void buttonDuplicate_Click(object sender, EventArgs e)
        {
            if (AllowEdit == true)
            {
                //get the new name
                string duplicateFile = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE QUE LE PONDRAS A LA PLANTILLA DUPLICADA:");
                duplicateFile = duplicateFile.ToUpper();
                duplicateFile = duplicateFile.Replace(" ", "_");
                //manipulate the selected name
                string readTemplate = SpecificPathOfFolderConfigurationTemplates + selectedFile + ".txt";
                string[] lines = File.ReadAllLines(readTemplate);
                string pathToWriteTemplate = SpecificPathOfFolderConfigurationTemplates + duplicateFile + ".txt";
                if (!File.Exists(pathToWriteTemplate))
                {
                    FileStream fs = new FileStream(pathToWriteTemplate, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(fs);
                    foreach (string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                    MessageBox.Show("DUPLICADO EXITOSAMENTE");
                    startChargeData();
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
                        string pathToEliminateTemplate = SpecificPathOfFolderConfigurationTemplates + selectedFile + ".txt";
                        File.Delete(pathToEliminateTemplate);
                        MessageBox.Show("ELIMINANDO EXITOSAMENTE");
                        startChargeData();
                    }catch (Exception)
                    {
                        MessageBox.Show("HUBO UN PROBLEMA ELIMINANDO LA PLANTILLA");
                    }
                    break;
                case DialogResult.No:
                    break;
            }
        }

        string selectedFile = "";
        private void LISTAPLANTILLAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexViewList = 0;
            if (LISTEMPLATE.FocusedItem == null)
            {
                MessageBox.Show("SELECCIONA UNA PLANTILLA VALIDA PARA ELIMINAR");
                return;
            }
            else
            {
                indexViewList = LISTEMPLATE.FocusedItem.Index;
                if (LISTEMPLATE.Items[indexViewList].Text == "" || LISTEMPLATE.Items[indexViewList].Text == "PLANTILLAS")
                {
                    MessageBox.Show("SELECCIONA UNA PLANTILLA VALIDA PARA ELIMINAR");
                }
                else
                {
                    AllowEdit = true;
                    selectedFile = LISTEMPLATE.Items[indexViewList].Text;
                    selectedFile = selectedFile.Replace(" ", "_");
                }
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
    }
}
