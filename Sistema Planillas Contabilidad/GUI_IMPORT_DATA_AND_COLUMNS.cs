using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_IMPORT_DATA_AND_COLUMNS : Form
    {
        bool clickOnListView1 = false;
        bool clickOnListView2 = false;
        int indexColumn = 0;
        string allColumn = "-TODAS COLUMNAS-";
        string allRows = "-TODAS FILAS-";

        string replaceColumns = "-REEMPLAZAR COLUMNAS-";
        string newColumns = "-AÑADIR COLUMNAS-";
        string startColumns = "-NUEVAS COLUMNAS-";

        string replaceRows = "-REEMPLAZAR FILAS-";
        string newRows = "-AÑADIR FILAS-";
        string startRows = "-NUEVAS FILAS-";
        string tableGlobal = "";

        List<string []> listDataGridRowGlobal = new List<string[]>();
        string orderRowGlobal = "";
        List<string[]> listDataGridColumnGlobal = new List<string[]>();
        string orderColumnGlobal = "";
        public GUI_IMPORT_DATA_AND_COLUMNS()
        {
            InitializeComponent();
        }

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

        string threeLine = "";
        string deparmentValue = "";

        string coreExtraConfiguration = "";
        string formula = "";
        string exclusiveData = "";
        string sits = "";
        string template = "";
        string tagStartHEad = "";
        string tagEndHEad = "";
        string tagStartLine = "";
        string tagEndLine = "";
        string tagStartFormula = "";
        string tagEndFormula = "";
        string tagStartDataGrid1 = "";
        string tagEndDataGrid1 = "";
        string tagStartDataGrid2 = "";
        string tagEndDataGrid2 = "";
        string tagStartDataGrid3 = "";
        string tagEndDataGrid3 = "";
        string tagStartDataGrid4 = "";
        string tagEndDataGrid4 = "";
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
            tagStartHEad = startTheTagsAndDefaults.isTagStartHead;
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
            tagStartLine = startTheTagsAndDefaults.isTagStartLine;
            tagEndLine = startTheTagsAndDefaults.isTagEndLine;
            tagStartFormula = startTheTagsAndDefaults.tagStartFormula;
            tagEndFormula = startTheTagsAndDefaults.tagEndFormula;
            tagStartDataGrid1 = startTheTagsAndDefaults.tagStartDataGrid1;
            tagEndDataGrid1 = startTheTagsAndDefaults.tagEndDataGrid1;
            tagStartDataGrid2 = startTheTagsAndDefaults.tagStartDataGrid2;
            tagEndDataGrid2 = startTheTagsAndDefaults.tagEndDataGrid2;
            tagStartDataGrid3 = startTheTagsAndDefaults.tagStartDataGrid3;
            tagEndDataGrid3 = startTheTagsAndDefaults.tagEndDataGrid3;
            tagStartDataGrid4 = startTheTagsAndDefaults.tagStartDataGrid4;
            tagEndDataGrid4 = startTheTagsAndDefaults.tagEndDataGrid4;
            //folders inside folders
            coreExtraConfiguration = startFoldersInsideCompany.isCoreExtraConfigurations;
            formula = startFoldersInsideCompany.isFormula;
            exclusiveData = startFoldersInsideCompany.isExclusiveData;
            sits = startFoldersInsideCompany.isSits;
            template = startFoldersInsideCompany.isTemplate;

        }


        string path = "";
        private void GUI_IMPORT_DATA_AND_COLUMNS_Load(object sender, EventArgs e)
        {
            loadDataStart();
        }

        private void loadDataStart()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("COLUMNAS");
            listView1.Columns[0].Width = listView1.Width;
            listView2.View = View.Details;
            listView2.Columns.Add("FILAS");
            listView2.Columns[0].Width = listView1.Width;
            if (File.Exists(path))
            {
               
                comboBox3.Items.Add(replaceRows);
                comboBox3.Items.Add(startRows);
                comboBox3.Items.Add(newRows);
                
                comboBox4.Items.Add(replaceColumns);
                comboBox4.Items.Add(startColumns);
                comboBox4.Items.Add(newColumns);

                comboBox5.Items.Add("TABLA 1");
                comboBox5.Items.Add("TABLA 2");
                comboBox5.Items.Add("TABLA 3");
                comboBox5.Items.Add("TABLA 4");
                //
                dataGridView1.EnableHeadersVisualStyles = false;
                string[] storageLines = File.ReadAllLines(path);
                int index = 0;
                int indexColor = 0;
                for (int head = 0; head < storageLines.Length; head++)
                {
                    if (storageLines[head] == tagEndHEad)
                    {
                        ++head;
                        int indexOfLine = 0;
                        for (int line = head; line < storageLines.Length; line++)
                        {
                            if (storageLines[line] == tagStartLine)
                            {
                                ++line;
                                dataGridView1.Rows.Add(indexOfLine.ToString());
                                for (int column = 0; column < dataGridView1.Columns.Count; column++)
                                {
                                    if ((indexColor % 2) == 0)
                                    {
                                        dataGridView1.Rows[indexOfLine].Cells[column].Style.BackColor = Color.LightSteelBlue;
                                    }
                                    dataGridView1.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                    ++line;
                                }
                                ++indexColor;
                                ++indexOfLine;
                            }

                        }
                        break;
                    }
                    else if (storageLines[head] != tagStartHEad)
                    {
                        dataGridView1.Columns.Add(storageLines[head], storageLines[head]);
                        dataGridView1.Columns[index].HeaderCell.Style.BackColor = Color.LightGray;// SystemColors.ActiveCaption;
                        ++index;
                    }
                }
                //string chooseColumn = "--ELEGIR TODAS COLUMNAS--";
                //string chooseRows = "--ELEGIR TODAS FILAS--";

                comboBox1.Items.Add(allColumn);
                for (int column = 0; column < dataGridView1.Columns.Count; column++)
                {
                    comboBox1.Items.Add(dataGridView1.Columns[column].HeaderText);
                }
                comboBox2.Items.Add(allRows);
                for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                {
                    comboBox2.Items.Add(dataGridView1.Rows[row].Cells[0].Value.ToString());
                }

                //paint(listView1,"COLOR");
                //paint(listView2, "COLOR");
            }
            else
            {
                MessageBox.Show("NO SE CARGARA DATA, NO EXISTE");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickOnListView1 = true;
            clickOnListView2 = false;
            indexColumn = listView1.FocusedItem.Index;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            clickOnListView1 = false;
            clickOnListView2 = true;
            indexColumn = listView2.FocusedItem.Index;
        }

        private void paint(ListView listToStudy, string order)
        {
            int index = 0;
            for (int column = 0; column < listToStudy.Items.Count; column++)
            {
                if ((index % 2) == 0)
                {
                    if (order == "WHITE")
                    {
                        listToStudy.Items[column].BackColor = Color.White;
                    }
                    else if (order == "COLOR")
                    {
                        listToStudy.Items[column].BackColor = Color.LightBlue;
                    }
                }
                ++index;
            }
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (clickOnListView1 == true || clickOnListView2 == true)
            {
                ListView listToStudy = new ListView();
                if (clickOnListView1 == true)
                {
                    listToStudy = listView1;
                }
                else if (clickOnListView2 == true)
                {
                    listToStudy = listView2;
                }
                if (listToStudy.Items.Count >= 0)
                {
                    listToStudy.Items.RemoveAt(indexColumn);
                    clickOnListView1 = false;
                    clickOnListView2 = false;
                    paint(listToStudy, "WHITE");
                    paint(listToStudy, "COLOR");
                    indexColumn = 0;
                }
            } else
            {
                MessageBox.Show("SELECCIONA ALGO ANTES DE ELIMINARLO");
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Add(comboBox1.Text);
            paint(listView1, "WHITE");
            paint(listView1, "COLOR");
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Add(comboBox2.Text);
            paint(listView2, "WHITE");
            paint(listView2, "COLOR");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == replaceColumns && listView1.Items.Count == 0)
            {
                MessageBox.Show("NO SE PUEDE IMPORTAR, SE ELIGIO REEMPLAZAR COLUMNAS ESPECIFICAS, PERO NO HAY FILAS COLUMNAS");
            }
            else if (comboBox2.Text == replaceRows && listView2.Items.Count == 0)
            {
                MessageBox.Show("NO SE PUEDE IMPORTAR, SE ELIGIO REEMPLAZAR FILAS ESPECIFICAS, PERO NO HAY FILAS ELEGIDAS");
            }
            else if(comboBox5.Text == threeLine)
            {
                MessageBox.Show("NO SE PUEDE IMPORTAR, NO SE HA DECIDIO CUAL TABLA MODIFICAR");
            }
            else
            {
                /*
                string chooseColumn = "-TODAS COLUMNAS-";
                string chooseRows = "-TODAS FILAS-";
                string replaceColumns = "-REEMPLZAR COLUMNAS-";
                string newColumns = "-NUEVAS COLUMNAS-";
                string replaceRows = "-REEMPLZAR FILAS-";
                string newRows = "-NUEVAS FILAS-";
                */
                if (comboBox1.Text == allColumn)
                {
                    List<string[]> listDataGridColumn = new List<string[]>();
                    for (int column = 0; column < dataGridView1.Columns.Count; column++)
                    {
                        string sumData = dataGridView1.Columns[column].HeaderText + "?";
                        for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                        {
                            sumData += dataGridView1.Rows[row].Cells[column].Value.ToString() + "?";
                        }
                        sumData = sumData.TrimEnd('?');
                        string[] splitData = sumData.Split('?');
                        listDataGridColumn.Add(splitData);
                    }
                    setListColumns(listDataGridColumn);
                    setOrderColumns(comboBox4.Text);
                }
                else
                {
                    List<string[]> listDataGridColumn = new List<string[]>();
                    for (int item = 0; item < listView1.Items.Count; item++)
                    {
                        for (int compare = 0; compare < dataGridView1.Columns.Count; compare++)
                        {
                            if (listView1.Items[item].Text == dataGridView1.Columns[compare].HeaderText)
                            {
                                string sumData = dataGridView1.Columns[compare].HeaderText + "?";
                                for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                                {
                                    sumData += dataGridView1.Rows[row].Cells[compare].Value.ToString() + "?";
                                }
                                sumData = sumData.TrimEnd('?');
                                string[] splitData = sumData.Split('?');
                                listDataGridColumn.Add(splitData);
                                break;
                            }
                        }
                    }
                    setListColumns(listDataGridColumn);
                    setOrderColumns(comboBox4.Text);
                }

                if (comboBox2.Text == allRows)
                {
                    List<string[]> listDataGridRow = new List<string[]>();
                    for (int row = 0; row < dataGridView1.Rows.Count-1; row++)
                    {
                        string sumData = "";
                        for (int column = 0; column < dataGridView1.Columns.Count; column++)
                        {
                            sumData += dataGridView1.Rows[row].Cells[column].Value.ToString() + "?";
                        }
                        sumData = sumData.TrimEnd('?');
                        string[] splitData = sumData.Split('?');
                        listDataGridRow.Add(splitData);
                    }
                    setListRows(listDataGridRow);
                    setOrderRows(comboBox3.Text);
                }
                else
                {
                    List<string[]> listDataGridRow = new List<string[]>();
                    for (int item = 0; item < listView2.Items.Count; item++)
                    {
                        for (int compare = 0; compare < dataGridView1.Rows.Count-1; compare++)
                        {
                            if (listView2.Items[item].Text == dataGridView1.Rows[compare].Cells[0].Value.ToString())
                            {
                                string sumData = "";
                                for (int column = 0; column < dataGridView1.Columns.Count; column++)
                                {
                                    sumData += dataGridView1.Rows[compare].Cells[column].Value.ToString() + "?";
                                }
                                sumData = sumData.TrimEnd('?');
                                string[] splitData = sumData.Split('?');
                                listDataGridRow.Add(splitData);
                                break;
                            }
                        }
                    }
                    setListRows(listDataGridRow);
                    setOrderRows(comboBox3.Text);
                }
                setTable(comboBox5.Text);
                this.Close();
            }
        }

        private void setListColumns(List<string []> listRecevied)
        {
            listDataGridColumnGlobal = listRecevied;
        }

        public List<string []> getListColumns()
        {
            return listDataGridColumnGlobal;
        }

        private void setOrderColumns(string orderRecevied)
        {
            orderColumnGlobal = orderRecevied;
        }

        public string getOrderColumns()
        {
            return orderColumnGlobal;
        }
        private void setListRows(List<string[]> listRecevied)
        {
            listDataGridRowGlobal = listRecevied;
        }

        public List<string[]> getListRows()
        {
            return listDataGridRowGlobal;
        }

        public void setOrderRows(string orderRecevied)
        {
            orderRowGlobal = orderRecevied;
        }

        public string getOrderRows()
        {
            return orderRowGlobal;
        }

        public void setTable(string orderTable)
        {
            tableGlobal = orderTable;
        }

        public string getTable()
        {
            return tableGlobal;
        }
        //tableGlobal = "";
        public void pathToChargeCompany(string pathReceived)
        {
            path = pathReceived;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
