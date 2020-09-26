using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY : Form
    {
       
       

        public GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY()
        {

            InitializeComponent();
        }

        bool AllowAction = false;
        string pathOfCompany = "";
        string SelectedCompany = "";
        string date = DateTime.UtcNow.ToString("MM-dd-yyyy");

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

        private void GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY_Load(object sender, EventArgs e)
        {
            ChargeDataStart();
        }

        private void ChargeDataStart()
        {
            listView1.Items.Clear();
            string[] filename = Directory.GetDirectories(CorePathOfFolderCompaniesSistemaPlanillas);
            foreach (string companyInFolder in filename)
            {
                string addItem = companyInFolder.Replace(CorePathOfFolderCompaniesSistemaPlanillas, "");
                addItem = addItem.Replace(".txt", "");
                addItem = addItem.Replace("_", " ");
                if (addItem == "" || addItem == " " || addItem == "_")
                {
                    //do nothing
                }
                else
                {
                    listView1.Items.Add(addItem);
                }

            }

            listView1.View = View.Details;
            listView1.Columns[0].Width = listView1.Width;
            listView1.Columns[0].Text = "EMPRESAS";
            listView1.Columns[0].TextAlign = HorizontalAlignment.Center;
            
        }

        private void buttonDuplicateCompany_Click(object sender, EventArgs e)
        {
            if (AllowAction == true)
            {
                string nameCompany = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE QUE LE PONDRAS A LA COMPAÑIA:").ToString();
                if (nameCompany == "" || nameCompany == " " || nameCompany.Length==0)
                {
                    MessageBox.Show("NO SE DUPLICARA, YA QUE EL NOMBRE ES INVALIDO");
                }
                else
                {
                    nameCompany = nameCompany.Replace(" ", "_");
                    nameCompany = nameCompany.ToUpper();
                    string[] arrayOfDeparmentsAndExTraConfigurations = Directory.GetDirectories(pathOfCompany);
                    List<string> listOnlyDeparments = new List<string>();
                    List<string> listDeparmentWithMonths = new List<string>();
                    List<string> listExtraConfigurations = new List<string>();
                    List<string> listExtraFolders = new List<string>();   

                    generalMethods callToMethod = new generalMethods();
                    for (int path = 0; path < arrayOfDeparmentsAndExTraConfigurations.Length; path++)
                    {
                        string replaceInString = arrayOfDeparmentsAndExTraConfigurations[path];
                        replaceInString = replaceInString.Replace(pathOfCompany,"");
                        replaceInString = replaceInString.Replace("\\", "");
                        if (replaceInString!=coreExtraConfiguration)
                        {
                            listOnlyDeparments.Add(arrayOfDeparmentsAndExTraConfigurations[path]);
                            string[] arrayOfMonths = Directory.GetDirectories(arrayOfDeparmentsAndExTraConfigurations[path]);
                            for (int path2 = 0; path2 < arrayOfMonths.Length; path2++)
                            {
                                listDeparmentWithMonths.Add(arrayOfMonths[path2]);
                            }
                        }else
                        {
                            listExtraConfigurations.Add(arrayOfDeparmentsAndExTraConfigurations[path]);
                        }
                    }
                    List<string> listFilesOfWeeks = new List<string>();
                    foreach (string path in listDeparmentWithMonths)
                    {
                        string[] directory2 = Directory.GetFiles(path);
                        for (int path2 = 0; path2 < directory2.Length; path2++)
                        {
                            listFilesOfWeeks.Add(directory2[path2]);
                        }
                    }
                    
                    string[] arrayOfExtraFolders = Directory.GetDirectories(listExtraConfigurations[0]);
                    List<string> listFilesOfExtras = new List<string>();
                    foreach (string path in arrayOfExtraFolders)
                    {
                        listExtraFolders.Add(path);
                        string[] directory2 = Directory.GetFiles(path);
                        for (int path2 = 0; path2 < directory2.Length; path2++)
                        {
                            listFilesOfExtras.Add(directory2[path2]);
                        }
                    }

                    List<string> listFoldersCreate = new List<string>();
                    listFoldersCreate.Add(CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);

                    //adding name Deparments
                    foreach (string path in listOnlyDeparments)
                    {
                        string replaceString = path.Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);
                        listFoldersCreate.Add(replaceString);
                    }
                    //adding Months of deparments
                    foreach (string path in listDeparmentWithMonths)
                    {
                        string replaceInString = path;
                        replaceInString = replaceInString.Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);
                        listFoldersCreate.Add(replaceInString);
                    }
                    //adding Extra configuration folder
                    foreach (string path in listExtraConfigurations)
                    {
                        string replaceInString = path;
                        replaceInString = replaceInString.Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);
                        listFoldersCreate.Add(replaceInString);
                    }
                    //adding Extra folders
                    foreach (string path in listExtraFolders)
                    {
                        string replaceInString = path;
                        replaceInString = replaceInString.Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);
                        listFoldersCreate.Add(replaceInString);
                    }
                    //Create all directories
                    foreach (string path in listFoldersCreate)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }
                    //Write Files
                    //files of weeks
                    for (int path = 0; path < listFilesOfWeeks.Count; path++)
                    {
                        string writePath = listFilesOfWeeks[path].Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany + "\\");
                        string[] lines = File.ReadAllLines(listFilesOfWeeks[path]);
                        if (!File.Exists(writePath))
                        {
                            FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            foreach (string line in lines)
                            {
                                writer.WriteLine(line);
                            }
                            writer.Close(); 
                        }
                    }
                    //files of extras
                    for (int path = 0; path < listFilesOfExtras.Count; path++)
                    {
                        string writePath = listFilesOfExtras[path].Replace(pathOfCompany, CorePathOfFolderCompaniesSistemaPlanillas + nameCompany);
                        string[] lines = File.ReadAllLines(listFilesOfExtras[path]);
                        if (!File.Exists(writePath))
                        {
                            FileStream fs = new FileStream(writePath, FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs);
                            foreach (string line in lines)
                            {
                                writer.WriteLine(line);
                            }
                            writer.Close();
                        }
                    }
                    
                    ChargeDataStart();
                    MessageBox.Show("DUPLICADO EXITOSAMENTE");
                }
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE DUPLICAR");
            }
        }

        private void buttoneEliminateCompany_Click(object sender, EventArgs e)
        {

            if (AllowAction == true)
            {
                SelectedCompany = SelectedCompany.Replace("_"," ");
                DialogResult eliminate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR: "+ SelectedCompany + " ?\nESTA EMPRESA NO PODRA SER RECUPERADA", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                switch (eliminate)
                {
                    case DialogResult.Yes:
                        try
                        {
                            DirectoryInfo directory = new DirectoryInfo(pathOfCompany);
                            directory.Delete(true);
                            ChargeDataStart();
                            AllowAction = false;
                            MessageBox.Show("BORRADO EXITOSAMENTE");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("IMPOSIBLE ELIMINAR, SUCEDIO ALGUN ERROR");
                        }
                    break;
                    case DialogResult.No:
                    break;
                }
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE ELIMINAR");
            }
            
        }

        private void buttonSafeCopyCompany_Click(object sender, EventArgs e)
        {
            if (AllowAction == true)
            {
                string pathToSaveCopy = "";
                using (var FormOFBrowser = new FolderBrowserDialog())
                {
                    DialogResult FormpathToSaveCopy = FormOFBrowser.ShowDialog();
                    if (FormpathToSaveCopy == DialogResult.OK && !string.IsNullOrWhiteSpace(FormOFBrowser.SelectedPath))
                    {
                        pathToSaveCopy = FormOFBrowser.SelectedPath;
                    }
                }

                DateTime now = DateTime.Now;
                string hour = now.Hour.ToString();
                string minute = now.Minute.ToString();
                pathToSaveCopy += "\\" + SelectedCompany+"-FECHA-"+ date+"-HORA-"+hour+"-"+minute + ".zip";

                try
                {
                    ZipFile.CreateFromDirectory(pathOfCompany, pathToSaveCopy);
                    MessageBox.Show("COPIA SEGURIDAD GENERADA EXITOSAMENTE");
                }catch (Exception)
                {
                    MessageBox.Show("SUCEDIO UN PROBLEMA GENERANDO COPIA SEGURIDAD");
                }
                AllowAction = false;
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE CREAR COPIA SEGURIDAD");
            }
        }

        private void buttonChargeSafeCopy_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("ELIGE LA COPIA A CARGAR");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
               
                string extractPath = Path.GetFullPath(fileName);
                string nameFile = Path.GetFileName(fileName);
                nameFile = nameFile.Replace(".zip", "");
                generalMethods callTochangeString = new generalMethods();
                nameFile = callTochangeString.eraseStringUntilFlag(nameFile, "-FECHA");
                if (extractPath.Contains(".zip"))
                {
                    try
                    {
                        bool found = false;
                        string pathOfCompany = "";
                        string createPath = CorePathOfFolderCompaniesSistemaPlanillas + nameFile;
                        string []arrowOfCompanies = Directory.GetDirectories(CorePathOfFolderCompaniesSistemaPlanillas);
                        foreach (string company in arrowOfCompanies)
                        {
                            string replaceInString = company;
                            replaceInString = replaceInString.Replace(CorePathOfFolderCompaniesSistemaPlanillas, "");
                            if(replaceInString==nameFile)
                            {
                                pathOfCompany = company;
                                found = true;
                                break;
                            }
                        }
                        if(found==true && Directory.Exists(pathOfCompany))
                        {
                            DialogResult answer = MessageBox.Show("ESTA EMPRESA YA EXISTE, PARA CARGARLO NECESITO BORRAR LA EXISTENTE, ¿PROCEDO?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                            switch (answer)
                            {
                                case DialogResult.Yes:
                                    DirectoryInfo directory = new DirectoryInfo(pathOfCompany);
                                    directory.Delete(true);
                                    Directory.CreateDirectory(createPath);
                                    ZipFile.ExtractToDirectory(extractPath, createPath);
                                    MessageBox.Show("COPIA SEGURIDAD CARGADA CON EXITO");
                                    break;
                                case DialogResult.No:
                                    MessageBox.Show("ACCION ABORTADA");
                                    break;
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(createPath);
                            ZipFile.ExtractToDirectory(extractPath, createPath);
                            MessageBox.Show("COPIA SEGURIDAD CARGADA CON EXITO");
                        }
                    } catch (Exception)
                    {
                        MessageBox.Show("SUCEDIO UN PROBLEMA CARGANDO COPIA SEGURIDAD");
                    }
                }
                else
                {
                    MessageBox.Show("NO SE CARGARA COPIA SEGURIDAD, ELIGE UN ARCHIVO VALIDO");
                }
               
            }
            
        }

        private void buttonCreateCompanySystem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_CREAR_EMPRESA callingCreateCompany = new GUI_CREAR_EMPRESA();
            callingCreateCompany.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callingCreateCompany.optionCreateOrEdit("CREATE");
            callingCreateCompany.receivedNameCompany(SelectedCompany);
            callingCreateCompany.ShowDialog();
            this.Show();
        }

        private void buttonEditCompany_Click(object sender, EventArgs e)
        {
            if (AllowAction == true)
            {
                this.Hide();
                GUI_CREAR_EMPRESA callingCreateCompany = new GUI_CREAR_EMPRESA();
                callingCreateCompany.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                callingCreateCompany.optionCreateOrEdit("EDIT");
                callingCreateCompany.receivedNameCompany(SelectedCompany);
                callingCreateCompany.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE EDITAR");
            }
        }

        int IndexViewList = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.FocusedItem == null)
            {
                AllowAction = false;
            }
            else
            {
                IndexViewList = listView1.FocusedItem.Index;
                if (listView1.Items[IndexViewList].Text == "" || listView1.Items[IndexViewList].Text == "EMPRESAS")
                {
                    MessageBox.Show("SELECCIONA UNA PLANTILLA VALIDA PARA ELIMINAR");
                    AllowAction = false;
                }
                else
                {
                    AllowAction = true;
                    SelectedCompany = listView1.Items[IndexViewList].Text;
                    SelectedCompany = SelectedCompany.Replace(" ", "_");
                    pathOfCompany = CorePathOfFolderCompaniesSistemaPlanillas + SelectedCompany;
                }
            }

        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_INICIO callingMenu = new GUI_MENU_INICIO();
            callingMenu.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
