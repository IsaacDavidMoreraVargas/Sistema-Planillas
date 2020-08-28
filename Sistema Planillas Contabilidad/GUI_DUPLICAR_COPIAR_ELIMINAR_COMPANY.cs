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
        bool AllowEdit = false;
        string FinalPath = "";
        string pathRead = "";
        string SelectDirectory = "";
        public GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY()
        {
            InitializeComponent();
        }

        private void GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY_Load(object sender, EventArgs e)
        {
            ChargeData();
        }

        private void ChargeData()
        {
            listView1.Items.Clear();
            FinalPath = Directory.GetCurrentDirectory();
            FinalPath = FinalPath.Replace("\\bin\\Debug", "\\Companies");
            string[] filename = Directory.GetDirectories(FinalPath);
            foreach (string x in filename)
            {
                string addItem = x.Replace(FinalPath + "\\", "");
                addItem = addItem.Replace(".txt", "");
                addItem = addItem.Replace("_", " ");
                if (addItem == "" || addItem == " " || addItem == "_")
                {
                    //donothing
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
            if (AllowEdit == true)
            {
                object duplicateCopany = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE QUE LE PONDRAS A LA COMPAÑIA:");
                string nameCompany = duplicateCopany.ToString();
                if (nameCompany == "" || nameCompany == " " || nameCompany.Length==0)
                {
                    MessageBox.Show("NO SE DUPLICARA, YA QUE EL NOMBRE ES INVALIDO");
                }
                else
                {
                    nameCompany = nameCompany.Replace(" ", "_");
                    string[] directory1 = Directory.GetDirectories(pathRead);
                    List<string> listDeparment = new List<string>();
                    for (int path = 0; path < directory1.Length; path++)
                    {
                        string[] directory2 = Directory.GetDirectories(directory1[path]);
                        for (int path2 = 0; path2 < directory2.Length; path2++)
                        {
                            listDeparment.Add(directory2[path2]);
                        }
                    }

                    List<string> listMonth = new List<string>();
                    foreach (string path in listDeparment)
                    {
                        string[] directory2 = Directory.GetDirectories(path);
                        for (int path2 = 0; path2 < directory2.Length; path2++)
                        {
                            listMonth.Add(directory2[path2]);
                        }
                    }

                    List<string> listFilesOrigin = new List<string>();
                    foreach (string path in listMonth)
                    {
                        string[] directory2 = Directory.GetFiles(path);
                        for (int path2 = 0; path2 < directory2.Length; path2++)
                        {
                            listFilesOrigin.Add(directory2[path2]);
                        }
                    }

                    List<string> listFilesCreate = new List<string>();
                    listFilesCreate.Add(FinalPath + "\\" + nameCompany);
                    foreach (string path in directory1)
                    {
                        string replaceString = path.Replace(SelectDirectory, nameCompany);
                        listFilesCreate.Add(replaceString);
                    }
                    foreach (string path in listDeparment)
                    {
                        string replaceString = path.Replace(SelectDirectory, nameCompany);
                        listFilesCreate.Add(replaceString);
                    }
                    foreach (string path in listMonth)
                    {
                        string replaceString = path.Replace(SelectDirectory, nameCompany);
                        listFilesCreate.Add(replaceString);
                    }

                    //FILEORIGIN CONTIENE LOS PATH CON LOS TXT
                    //LISTA QUE CONTIENE LOS PATH A CREAR
                    foreach (string path in listFilesCreate)
                    {
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                    }

                    for (int path = 0; path < listFilesOrigin.Count; path++)
                    {
                        string writePath = listFilesOrigin[path].Replace(pathRead, FinalPath + "\\" + nameCompany + "\\");
                        string[] lines = File.ReadAllLines(listFilesOrigin[path]);
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
                    ChargeData();
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

            if (AllowEdit == true)
            {
                DialogResult eliminate = MessageBox.Show("¿ESTAS SEGURO DE ELIMINAR "+ SelectDirectory+ " ?\nESTA EMPRESA NO PODRA SER RECUPERADA", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                switch (eliminate)
                {
                    case DialogResult.Yes:
                        try
                        {
                            DirectoryInfo directory = new DirectoryInfo(pathRead);
                            directory.Delete(true);
                            ChargeData();
                            AllowEdit = false;
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
            if (AllowEdit == true)
            {
                string extractPath = "";
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                      extractPath = fbd.SelectedPath;
                    }
                }
                extractPath += "\\" + SelectDirectory+ ".zip";
                if (!File.Exists(extractPath))
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(pathRead, extractPath);
                        MessageBox.Show("COPIA SEGURIDAD GENERADA EXITOSAMENTE");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("SUCEDIO UN PROBLEMA GENERANDO COPIA SEGURIDAD");
                    }
                }
                else 
                {
                    MessageBox.Show("ARCHIVO EXISTE, NO SE GENERARA COPIA SEGURIDAD NUEVA");
                    DialogResult answer = MessageBox.Show("¿DESEA ELIMINAR ARCHIVO Y GENERAR NUEVA COPIA?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                    switch (answer)
                    {
                        case DialogResult.Yes:
                        try
                        {
                            File.Delete(extractPath);
                            ZipFile.CreateFromDirectory(pathRead, extractPath);
                            MessageBox.Show("COPIA SEGURIDAD GENERADA, DE NUEVO, EXITOSAMENTE");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("SUCEDIO UN PROBLEMA GENERANDO COPIA SEGURIDAD");
                        }
                        break;
                        case DialogResult.No:
                            MessageBox.Show("ACCION ABORTADA");
                        break;
                    }
                }
                AllowEdit = false;
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE CREAR COPIA SEGURIDAD");
            }
        }

        private void buttonChargeSafeCopy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ELIGE LA COPIA A CARGAR");
            string extractPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    extractPath = Path.GetFullPath(fileName);
                    string nameFile = Path.GetFileName(fileName);
                    if (extractPath.Contains(".zip"))
                    {
                        try
                        {
                            nameFile = nameFile.Replace(".zip","");
                            string createPath =  FinalPath+ "\\" + nameFile;
                            if (Directory.Exists(createPath))
                            {
                                DialogResult answer = MessageBox.Show("ESTA EMPRESA YA EXISTE, PARA CARGARLO NECESITO BORRAR LA EXISTENTE, ¿PROCEDO?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                                switch (answer)
                                {
                                    case DialogResult.Yes:
                                        DirectoryInfo directory = new DirectoryInfo(createPath);
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
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("SUCEDIO UN PROBLEMA CARGANDO COPIA SEGURIDAD");
                        }
                    }
                    else
                    {
                        MessageBox.Show("NO SE CARGARA COPIA SEGURIDAD, ELIGE UN ARCHIVO VALIDO");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("NO SE CARGARA ARCHIVO, SUCEDIO ALGUN PROBLEMA");
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
            this.Close();
        }

       
        int IndexViewList = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null)
            {
                return;
            }
            else
            {
                IndexViewList = listView1.FocusedItem.Index;
            }

            if (listView1.Items[IndexViewList].Text == "" || listView1.Items[IndexViewList].Text == "EMPRESAS")
            {
                MessageBox.Show("SELECCIONA UNA PLANTILLA VALIDA PARA ELIMINAR");
            }
            else
            {
                AllowEdit = true;
                SelectDirectory = listView1.Items[IndexViewList].Text;
                SelectDirectory = SelectDirectory.Replace(" ", "_");
                pathRead = FinalPath + "\\" + SelectDirectory;
            }
        }

        private void buttonCreateCompanySystem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_CREAR_EMPRESA callingCreateCompany = new GUI_CREAR_EMPRESA();
            callingCreateCompany.optionMenu(false);
            callingCreateCompany.receivedNameCompany(SelectDirectory);
            callingCreateCompany.ShowDialog();
            this.Close();
        }

        private void buttonEditCompany_Click(object sender, EventArgs e)
        {
            if (AllowEdit == true)
            {
                this.Hide();
                GUI_CREAR_EMPRESA callingCreateCompany = new GUI_CREAR_EMPRESA();
                callingCreateCompany.optionMenu(true);
                callingCreateCompany.receivedNameCompany(SelectDirectory);
                callingCreateCompany.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("SELECCIONA ALGO PRIMERO ANTES DE EDITAR");
            }
        }
    }
}
