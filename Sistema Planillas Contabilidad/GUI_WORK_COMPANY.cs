using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_WORK_COMPANY : Form
    {
        string company = "";
        string deparment = "";
        string month = "";
        bool actionHappened = false;
        int indexColumnOfDatagrid = 0;
        int indexRowOfDatagrid = 0;

        bool clickOnDataGrid1 = false;
        bool clickOnDataGrid2 = false;
        bool clickOnDataGrid3 = false;
        bool clickOnDataGrid4 = false;
        bool clickOnDataGrid5 = false;
        bool clickOnCellDataGrid1 = false;
        bool clickOnCellDataGrid2 = false;
        bool clickOnCellDataGrid3 = false;
        bool clickOnCellDataGrid4 = false;
        bool clickOnCellDataGrid5 = false;

        public GUI_WORK_COMPANY()
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

        private void GUI_WORK_COMPANY_Load(object sender, EventArgs e)
        {
            setHeadsOfDataGridView();
            createColumnsinDataGridView5();
            sumTheCellsofAll();
        }

        private void setHeadsOfDataGridView()
        {
            buttonBackTotal.Enabled = false;
            buttonNextTotal.Enabled = false;
            dataGridView1.Columns.Clear();
            comboBox1.Text = threeLine;
            comboBox2.Text = threeLine;
            //
            string pathToReadData = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month;
            string[] storagePaths = Directory.GetFiles(pathToReadData);
            foreach (string path in storagePaths)
            {
                if (path.Contains("1-7"))
                {

                    string[] storageLines = File.ReadAllLines(path);
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
                                        dataGridView1.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                        ++line;
                                    }
                                    ++indexOfLine;
                                }

                            }
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView1.Columns.Add(storageLines[head], storageLines[head]);
                        }
                    }
                } else if (path.Contains("8-14"))
                {

                    string[] storageLines = File.ReadAllLines(path);
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
                                    dataGridView2.Rows.Add(indexOfLine.ToString());
                                    for (int column = 0; column < dataGridView2.Columns.Count; column++)
                                    {
                                        dataGridView2.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                        ++line;
                                    }
                                    ++indexOfLine;
                                }

                            }
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView2.Columns.Add(storageLines[head], storageLines[head]);
                        }
                    }
                } else if (path.Contains("15-21"))
                {

                    string[] storageLines = File.ReadAllLines(path);
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
                                    dataGridView3.Rows.Add(indexOfLine.ToString());
                                    for (int column = 0; column < dataGridView3.Columns.Count; column++)
                                    {
                                        dataGridView3.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                        ++line;
                                    }
                                    ++indexOfLine;
                                }

                            }
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView3.Columns.Add(storageLines[head], storageLines[head]);
                        }
                    }
                } else if (path.Contains("22-"))
                {
                    string[] storageLines = File.ReadAllLines(path);

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
                                    dataGridView4.Rows.Add(indexOfLine.ToString());
                                    for (int column = 0; column < dataGridView4.Columns.Count; column++)
                                    {
                                        dataGridView4.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                        ++line;
                                    }
                                    ++indexOfLine;
                                }

                            }
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView4.Columns.Add(storageLines[head], storageLines[head]);
                        }
                    }
                }
            }

            bool configurationExist = false;
            bool totalExist = false;
            foreach (string path in storagePaths)
            {
                if (path.Contains("SUMA-TOTALES"))
                {
                    string[] storageLines = File.ReadAllLines(path);
                    dataGridView5.EnableHeadersVisualStyles = false;
                    int index = 0;
                    for (int head = 0; head < storageLines.Length; head++)
                    {
                        if (storageLines[head] == tagEndHEad)
                        {
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView5.Columns.Add(storageLines[head], storageLines[head]);
                            dataGridView5.Columns[index].HeaderCell.Style.BackColor = SystemColors.ActiveCaption;
                            ++index;
                        }
                    }
                    totalExist = true;
                }
                else if (path.Contains("CONFIGURACIONES-CELDAS"))
                {
                    configurationExist = true;
                    DataGridView dataGridToStudy = new DataGridView();
                    string[] storageLines = File.ReadAllLines(path);
                    for (int line = 0; line < storageLines.Length; line++)
                    {
                        if (storageLines[line] == tagStartDataGrid1)
                        {
                            dataGridToStudy = dataGridView1;
                            ++line;
                            dataGridToStudy.Visible = Convert.ToBoolean(storageLines[line]);
                            ++line;
                            dataGridToStudy.Enabled = Convert.ToBoolean(storageLines[line]);
                        }
                        else if (storageLines[line] == tagStartDataGrid2)
                        {
                            dataGridToStudy = dataGridView2;
                            ++line;
                            dataGridToStudy.Visible = Convert.ToBoolean(storageLines[line]);
                            ++line;
                            dataGridToStudy.Enabled = Convert.ToBoolean(storageLines[line]);
                        }
                        else if (storageLines[line] == tagStartDataGrid3)
                        {
                            dataGridToStudy = dataGridView3;
                            ++line;
                            dataGridToStudy.Visible = Convert.ToBoolean(storageLines[line]);
                            ++line;
                            dataGridToStudy.Enabled = Convert.ToBoolean(storageLines[line]);
                        }
                        else if (storageLines[line] == tagStartDataGrid4)
                        {
                            dataGridToStudy = dataGridView4;
                            ++line;
                            dataGridToStudy.Visible = Convert.ToBoolean(storageLines[line]);
                            ++line;
                            dataGridToStudy.Enabled = Convert.ToBoolean(storageLines[line]);
                        }

                        dataGridToStudy.EnableHeadersVisualStyles = false;
                        foreach (DataGridViewColumn column in dataGridToStudy.Columns)
                        {
                            if (column.HeaderText == storageLines[line])
                            {
                                ++line;
                                column.Visible = Convert.ToBoolean(storageLines[line]);
                                ++line;
                                if (Convert.ToBoolean(storageLines[line]) == true)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightGray;
                                } else if (Convert.ToBoolean(storageLines[line]) == false)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightSalmon;
                                }
                                break;
                            }
                        }
                    }
                    clickOnCellDataGrid1 = true;
                    clickOnCellDataGrid2 = false;
                    clickOnCellDataGrid3 = false;
                    clickOnCellDataGrid4 = false;
                    setSaveDatagridOnChangesFirstTime();
                    clickOnCellDataGrid1 = false;
                    clickOnCellDataGrid2 = true;
                    clickOnCellDataGrid3 = false;
                    clickOnCellDataGrid4 = false;
                    setSaveDatagridOnChangesFirstTime();
                    clickOnCellDataGrid1 = false;
                    clickOnCellDataGrid2 = false;
                    clickOnCellDataGrid3 = true;
                    clickOnCellDataGrid4 = false;
                    setSaveDatagridOnChangesFirstTime();
                    clickOnCellDataGrid1 = false;
                    clickOnCellDataGrid2 = false;
                    clickOnCellDataGrid3 = false;
                    clickOnCellDataGrid4 = true;
                    setSaveDatagridOnChangesFirstTime();
                    clickOnCellDataGrid1 = false;
                    clickOnCellDataGrid2 = false;
                    clickOnCellDataGrid3 = false;
                    clickOnCellDataGrid4 = false;
                }
            }
            if (configurationExist == false)
            {
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView3.EnableHeadersVisualStyles = false;
                dataGridView4.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                clickOnCellDataGrid1 = true;
                clickOnCellDataGrid2 = false;
                clickOnCellDataGrid3 = false;
                clickOnCellDataGrid4 = false;
                setSaveDatagridOnChangesFirstTime();
                clickOnCellDataGrid1 = false;
                clickOnCellDataGrid2 = true;
                clickOnCellDataGrid3 = false;
                clickOnCellDataGrid4 = false;
                setSaveDatagridOnChangesFirstTime();
                clickOnCellDataGrid1 = false;
                clickOnCellDataGrid2 = false;
                clickOnCellDataGrid3 = true;
                clickOnCellDataGrid4 = false;
                setSaveDatagridOnChangesFirstTime();
                clickOnCellDataGrid1 = false;
                clickOnCellDataGrid2 = false;
                clickOnCellDataGrid3 = false;
                clickOnCellDataGrid4 = true;
                setSaveDatagridOnChangesFirstTime();
                clickOnCellDataGrid1 = false;
                clickOnCellDataGrid2 = false;
                clickOnCellDataGrid3 = false;
                clickOnCellDataGrid4 = false;
            }

            if (totalExist == false)
            {
                string pathTemplate = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + coreExtraConfiguration + "\\" + template;
                string[] storageTemplateFiles = Directory.GetFiles(pathTemplate);
                dataGridView5.EnableHeadersVisualStyles = false;
                int index = 0;
                foreach (string path in storageTemplateFiles)
                {
                    string[] storageLines = File.ReadAllLines(path);
                    foreach (string line in storageLines)
                    {
                        if (line == tagEndHEad)
                        {
                            break;
                        }
                        else if (line != tagStartHEad)
                        {
                            dataGridView5.Columns.Add(line, line);
                            dataGridView5.Columns[index].HeaderCell.Style.BackColor = SystemColors.ActiveCaption;
                            ++index;
                        }
                    }
                    break;
                }
            }
            //
            checkedListBox1.Items.Add("1-7", CheckState.Unchecked);
            checkedListBox1.Items.Add("8-14", CheckState.Unchecked);
            checkedListBox1.Items.Add("15-21", CheckState.Unchecked);
            checkedListBox1.Items.Add("22-30", CheckState.Unchecked);
            comboBox1.Items.Add("SEMANA 1");
            comboBox1.Items.Add("SEMANA 2");
            comboBox1.Items.Add("SEMANA 3");
            comboBox1.Items.Add("SEMANA 4");

            baseResizeDatasGridView();
        }

        private void baseResizeDatasGridView()
        {
            resizeDataGrid1();
            resizeDataGrid2();
            resizeDataGrid3();
            resizeDataGrid4();
        }


        int heigthLocation = 0;
        int maximunHeight = 292;
        private void resizeDataGrid1()
        {
            heigthLocation = 0;
            if (dataGridView1.Visible == true)
            {
                dataGridView1.Location = new Point(0, heigthLocation);
                dataGridView1.Width = tableLayoutPanel1.Width - 30;
                int sizeHeight = dataGridView1.ColumnHeadersHeight + 10;
                if (dataGridView1.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        sizeHeight += row.Height;
                    }
                    if (sizeHeight > maximunHeight)
                    {
                        dataGridView1.Height = maximunHeight;
                    } else
                    {
                        dataGridView1.Height = sizeHeight;
                    }
                }
                heigthLocation += dataGridView1.Height + 10;
            }
        }

        private void resizeDataGrid2()
        {
            if (dataGridView2.Visible == true)
            {
                dataGridView2.Location = new Point(0, heigthLocation);
                dataGridView2.Width = tableLayoutPanel1.Width - 30;
                int sizeHeight = dataGridView2.ColumnHeadersHeight + 10;
                if (dataGridView2.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        sizeHeight += row.Height;
                    }
                    if (sizeHeight > maximunHeight)
                    {
                        dataGridView2.Height = maximunHeight;
                    } else
                    {
                        dataGridView2.Height = sizeHeight;
                    }
                }
                heigthLocation += dataGridView2.Height + 10;
            }
        }

        private void resizeDataGrid3()
        {
            if (dataGridView3.Visible == true)
            {
                dataGridView3.Location = new Point(0, heigthLocation);
                dataGridView3.Width = tableLayoutPanel1.Width - 30;
                int sizeHeight = dataGridView3.ColumnHeadersHeight + 10;
                if (dataGridView3.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        sizeHeight += row.Height;
                    }
                    if (sizeHeight > maximunHeight)
                    {
                        dataGridView3.Height = maximunHeight;
                    } else
                    {
                        dataGridView3.Height = sizeHeight;
                    }
                }
                heigthLocation += dataGridView3.Height + 10;
            }
        }

        private void resizeDataGrid4()
        {
            if (dataGridView4.Visible == true)
            {
                dataGridView4.Location = new Point(0, heigthLocation);
                dataGridView4.Width = tableLayoutPanel1.Width - 30;
                int sizeHeight = dataGridView4.ColumnHeadersHeight + 10;
                if (dataGridView4.Rows.Count > 1)
                {
                    foreach (DataGridViewRow row in dataGridView4.Rows)
                    {
                        sizeHeight += row.Height;
                    }
                    if (sizeHeight > maximunHeight)
                    {
                        dataGridView4.Height = maximunHeight;
                    } else
                    {
                        dataGridView4.Height = sizeHeight;
                    }
                }
            }
        }

        private void sumTheCellsofAll()
        {
            List<DataGridView> listOFDataGridView = new List<DataGridView>();
            if (dataGridView1.Enabled == true)
            {
                listOFDataGridView.Add(dataGridView1);
            }
            if (dataGridView2.Enabled == true)
            {
                listOFDataGridView.Add(dataGridView2);
            }
            if (dataGridView3.Enabled == true)
            {
                listOFDataGridView.Add(dataGridView3);
            }
            if (dataGridView4.Enabled == true)
            {
                listOFDataGridView.Add(dataGridView4);
            }
            int indexAdd = 0;
            dataGridView5.Rows.Clear();
            generalDataAndAvoidData callToFindAvoidData = new generalDataAndAvoidData();
            generalMultiArrayMethods callToArrayMethod = new generalMultiArrayMethods();
            string pivote = "";
            bool onlyOnce = true;
            for (int dataGrid = 0; dataGrid < listOFDataGridView.Count; dataGrid++)
            {
                DataGridView dataGridStudy = listOFDataGridView[dataGrid];
                if (onlyOnce == true)
                {
                    for (int column = 0; column < dataGridStudy.Columns.Count; column++)
                    {
                        bool answer = callToFindAvoidData.pivoteColumns(dataGridStudy.Columns[column].HeaderText);
                        if (answer == true)
                        {
                            pivote = dataGridStudy.Columns[column].HeaderText;
                            break;
                        }
                    }
                    onlyOnce = false;
                }
                if (dataGridStudy.Rows.Count > dataGridView5.Rows.Count)
                {
                    for (int index = dataGridView5.Rows.Count; index < dataGridStudy.Rows.Count; index++)
                    {
                        dataGridView5.Rows.Add(indexAdd.ToString());
                        ++indexAdd;
                    }
                }
            }

            for (int dataGrid = 0; dataGrid < listOFDataGridView.Count; dataGrid++)
            {
                DataGridView dataGridStudy = listOFDataGridView[dataGrid];
                for (int rows = 0; rows < dataGridStudy.Rows.Count - 1; rows++)
                {
                    for (int column = 0; column < dataGridStudy.Columns.Count; column++)
                    {
                        if (dataGridStudy.Rows[rows].Cells[column].Value == null)
                        {
                            dataGridView5.Rows[rows].Cells[column].Value = dataGridStudy.Rows[rows].Cells[column].Value = " ";
                        }
                        else
                        {
                            dataGridView5.Rows[rows].Cells[column].Value = dataGridStudy.Rows[rows].Cells[column].Value.ToString();
                        }
                    }
                }
                if (listOFDataGridView.Count >= 1)
                {
                    for (int dataGridPhase2 = 1; dataGridPhase2 < listOFDataGridView.Count; dataGridPhase2++)
                    {
                        DataGridView dataGridStudyPhase2 = listOFDataGridView[dataGridPhase2];
                        for (int column = 0; column < dataGridStudyPhase2.Columns.Count; column++)
                        {
                            if (dataGridStudyPhase2.Columns[column].HeaderText == pivote)
                            {
                                for (int rowsPhase2 = 0; rowsPhase2 < dataGridStudy.Rows.Count - 1; rowsPhase2++)
                                {
                                    bool found = callToArrayMethod.findInRowsDataGridView(dataGridView5, pivote, dataGridStudyPhase2.Rows[rowsPhase2].Cells[column].Value.ToString());
                                    if (found == false)
                                    {
                                        for (int columnPhase2 = 0; columnPhase2 < dataGridStudyPhase2.Columns.Count; columnPhase2++)
                                        {
                                            dataGridView5.Rows[rowsPhase2].Cells[columnPhase2].Value = dataGridStudyPhase2.Rows[rowsPhase2].Cells[columnPhase2].Value.ToString();
                                        }
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    //break;
                }
            }

            for (int column = 0; column < dataGridView5.Columns.Count; column++)
            {
                bool answer = callToFindAvoidData.avoidColumns(dataGridView5.Columns[column].HeaderText);
                if (answer == false)
                {
                    for (int rows = 0; rows < dataGridView5.Rows.Count - 1; rows++)
                    {
                        dataGridView5.Rows[rows].Cells[column].Value = " ";
                    }
                }
            }

            for (int column = 0; column < dataGridView5.Columns.Count; column++)
            {
                if (dataGridView5.Columns[column].HeaderText == pivote)
                {
                    for (int rows = 0; rows < dataGridView5.Rows.Count - 1; rows++)
                    {
                        List<DataGridViewRow> lisfOfRows = new List<DataGridViewRow>();
                        if (dataGridView5.Rows[rows].Cells[column].Value != null)
                        {
                            lisfOfRows = callToArrayMethod.getLisfOfRowsWithPivote(listOFDataGridView, dataGridView5.Rows[rows].Cells[column].Value.ToString());
                            string[] storageData = callToArrayMethod.getSumOfLisfRows(lisfOfRows);
                            for (int replace = 0; replace < storageData.Length; replace++)
                            {
                                dataGridView5.Rows[rows].Cells[replace].Value = storageData[replace];
                            }
                        }
                    }
                    break;
                }
            }

            //appliying formulas
            string pathOfFormulas = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + "CORE-FORMULAS.txt";
            if (File.Exists(pathOfFormulas))
            {
                string[] storageFormulas = File.ReadAllLines(pathOfFormulas);
                List<string> resultOfBodyFormula = new List<string>();
                List<string> copyResultOfBodyFormula = new List<string>();
                List<string> bodyOfFormula = new List<string>();
                List<string> copyBodyOfFormula = new List<string>();
                foreach (string formula in storageFormulas)
                {
                    if (formula != tagStartFormula && formula != tagEndFormula)
                    {
                        string[] splitFormula = formula.Split('=');
                        resultOfBodyFormula.Add(splitFormula[0]);
                        copyResultOfBodyFormula.Add(splitFormula[0]);
                        string replaceString = splitFormula[1];
                        replaceString = replaceString.Replace("+", "?+?");
                        replaceString = replaceString.Replace("-", "?-?");
                        replaceString = replaceString.Replace("/", "?/?");
                        replaceString = replaceString.Replace("*", "?*?");
                        bodyOfFormula.Add(replaceString);
                        copyBodyOfFormula.Add(replaceString);
                    }
                }
                for (int formulaPhase1 = 0; formulaPhase1 < bodyOfFormula.Count; formulaPhase1++)
                {
                    calculateSystem callToCalculate = new calculateSystem();
                    for (int row = 0; row < dataGridView5.Rows.Count - 1; row++)
                    {
                        string[] splitFormulaPhase2 = bodyOfFormula[formulaPhase1].Split('?');
                        for (int column = 0; column < dataGridView5.Columns.Count; column++)
                        {
                            bool answer = callToFindAvoidData.avoidColumns(dataGridView5.Columns[column].HeaderText);
                            if (answer == false)
                            {
                                for (int formulaPhase2 = 0; formulaPhase2 < splitFormulaPhase2.Length; formulaPhase2++)
                                {
                                    if (dataGridView5.Columns[column].HeaderText == splitFormulaPhase2[formulaPhase2])
                                    {
                                        if (dataGridView5.Rows[row].Cells[column].Value == null || dataGridView5.Rows[row].Cells[column].Value.ToString() == "" || dataGridView5.Rows[row].Cells[column].Value.ToString() == " ")
                                        {
                                            splitFormulaPhase2[formulaPhase2] = "0";
                                        }
                                        else
                                        {
                                            splitFormulaPhase2[formulaPhase2] = dataGridView5.Rows[row].Cells[column].Value.ToString();
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        string numberAnswer = callToCalculate.recieveArray(splitFormulaPhase2);
                        //decimal transform = Convert.ToDecimal(numberAnswer);
                        //string numberAnswer1 = string.Format("{0:0,0.00}", transform);
                        for (int column = 0; column < dataGridView5.Columns.Count; column++)
                        {
                            if (dataGridView1.Columns[column].HeaderText == resultOfBodyFormula[formulaPhase1])
                            {
                                if (dataGridView1.Columns[column].HeaderText.Contains("TOT") && !dataGridView1.Columns[column].HeaderText.Contains("TOTAL"))
                                {
                                    dataGridView5.Rows[row].Cells[column].Value = numberAnswer.ToString();
                                }
                                else if (dataGridView1.Columns[column].HeaderText == "SALARIO NETO")
                                {
                                    dataGridView5.Rows[row].Cells[column].Value = numberAnswer;//Math.Round(Convert.ToDouble(numberAnswer)).ToString();
                                }
                                else
                                {
                                    dataGridView5.Rows[row].Cells[column].Value = numberAnswer;
                                }
                                break;
                            }
                        }
                    }
                }

                for (int column = 0; column < dataGridView5.Columns.Count; column++)
                {
                    bool answer = callToFindAvoidData.avoidColumns(dataGridView5.Columns[column].HeaderText);
                    if (answer == false)
                    {
                        double sum = 0;
                        for (int row = 0; row < dataGridView5.Rows.Count - 1; row++)
                        {
                            if (dataGridView5.Rows[row].Cells[column].Value.ToString().Contains("-"))
                            {
                                sum -= Convert.ToDouble(dataGridView5.Rows[row].Cells[column].Value);
                            }
                            else if (dataGridView5.Rows[row].Cells[column].Value == null || dataGridView5.Rows[row].Cells[column].Value.ToString() == "" || dataGridView5.Rows[row].Cells[column].Value.ToString() == " ")
                            {
                                sum += 0;
                            }
                            else
                            {
                                sum += Convert.ToDouble(dataGridView5.Rows[row].Cells[column].Value);
                            }
                        }
                        //sum = Math.Round(sum, 0, MidpointRounding.AwayFromZero);
                        //sum = Math.Round(sum);
                        string numberAnswer1 = string.Format("{0:0,0.00}", sum);
                        dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[column].Value = numberAnswer1;
                    }
                    else
                    {
                        dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[column].Value = "FALSE";
                    }
                }
                dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[0].Value = "TOTAL";
                for (int column = 0; column < dataGridView5.Columns.Count; column++)
                {
                    dataGridView5.Rows[dataGridView5.Rows.Count - 1].Cells[column].Style.BackColor = Color.LightGray;
                }
            }

        }
        private void createColumnsinDataGridView5()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                bool found = false;
                foreach (DataGridViewColumn compare in dataGridView5.Columns)
                {
                    if (compare.HeaderText == column.HeaderText)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    dataGridView5.Columns.Add(column.HeaderText, column.HeaderText);
                }
            }

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                bool found = false;
                foreach (DataGridViewColumn compare in dataGridView5.Columns)
                {
                    if (compare.HeaderText == column.HeaderText)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    dataGridView5.Columns.Add(column.HeaderText, column.HeaderText);
                }
            }

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                bool found = false;
                foreach (DataGridViewColumn compare in dataGridView5.Columns)
                {
                    if (compare.HeaderText == column.HeaderText)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    dataGridView5.Columns.Add(column.HeaderText, column.HeaderText);
                }
            }

            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                bool found = false;
                foreach (DataGridViewColumn compare in dataGridView5.Columns)
                {
                    if (compare.HeaderText == column.HeaderText)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    dataGridView5.Columns.Add(column.HeaderText, column.HeaderText);
                }
            }
        }

        private void buttonIntroduceData_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
            bool allowEnterData = true;
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                //dataGridviewToWhite();
                if (dataToChargeData.Rows.Count == 1)
                {
                    DialogResult answer = MessageBox.Show("¿DESEA AÑADIR UNA COLUMNA PARA INTRODUCIR DATOS?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                    switch (answer)
                    {
                        case DialogResult.Yes:
                            setSaveDatagridOnChanges();
                            int index = dataToChargeData.Rows.Count - 1;
                            dataToChargeData.Rows.Add(index.ToString());
                            for (int colum = 1; colum < dataToChargeData.Columns.Count; colum++)
                            {
                                string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + dataToChargeData.Columns[colum].HeaderText + " \n-S/F PARA SALIR:");
                                data = data.ToUpper();
                                if (data == "S/F")
                                {
                                    setSaveDatagridOnChanges();
                                    break;
                                }
                                else
                                {
                                    dataToChargeData.Rows[index].Cells[colum].Value = data;
                                }
                            }
                            actionHappened = true;
                            baseResizeDatasGridView();
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {

                    DialogResult answer = MessageBox.Show("¿DESEA INTRODUCIR EN LA CELDA QUE ELIGIO?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                    switch (answer)
                    {
                        case DialogResult.Yes:
                            setSaveDatagridOnChanges();
                            bool outFromHere = false;
                            for (int row = indexRowOfDatagrid; row < dataToChargeData.Rows.Count - 1; row++)
                            {
                                for (int colum = indexColumnOfDatagrid; colum < dataToChargeData.Columns.Count; colum++)
                                {
                                    string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + dataToChargeData.Columns[colum].HeaderText + " \n-S/F PARA SALIR DE LA FILA \n-S/T PARA SALIR TOTALMENTE:");
                                    data = data.ToUpper();
                                    if (data == "S/F")
                                    {
                                        break;
                                    } else if (data == "S/T")
                                    {
                                        outFromHere = true;
                                        break;
                                    }
                                    else
                                    {
                                        dataToChargeData.Rows[row].Cells[colum].Value = data;
                                    }
                                }
                                if (outFromHere == true)
                                {
                                    setSaveDatagridOnChanges();
                                    break;
                                }
                            }
                            actionHappened = true;
                            break;
                        case DialogResult.No:
                            answer = MessageBox.Show("¿DESEA IR A LA ULTIMA CELDA EN BLANCO QUE ENCUENTRE?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                            switch (answer)
                            {
                                case DialogResult.Yes:
                                    outFromHere = false;
                                    setSaveDatagridOnChanges();
                                    for (int row = dataToChargeData.Rows.Count - 2; row > 0; row--)
                                    {
                                        for (int colum = dataToChargeData.Columns.Count - 1; colum > 0; colum--)
                                        {
                                            if (dataToChargeData.Rows[row].Cells[colum].Value == null || dataToChargeData.Rows[row].Cells[colum].Value.ToString() == "" || dataToChargeData.Rows[row].Cells[colum].Value.ToString() == " ")
                                            {
                                                for (int columPhase2 = colum; columPhase2 < dataToChargeData.Columns.Count; columPhase2++)
                                                {
                                                    if (dataToChargeData.Rows[row].Cells[columPhase2].Value == null || dataToChargeData.Rows[row].Cells[columPhase2].Value.ToString() == " " || dataToChargeData.Rows[row].Cells[columPhase2].Value.ToString() == "")
                                                    {
                                                        string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + dataToChargeData.Columns[columPhase2].HeaderText + " \n-S/F PARA SALIR DE LA FILA \n-S/T PARA SALIR TOTALMENTE:");
                                                        data = data.ToUpper();
                                                        if (data == "S/F")
                                                        {
                                                            break;
                                                        }
                                                        else if (data == "S/T")
                                                        {
                                                            outFromHere = true;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            dataToChargeData.Rows[row].Cells[columPhase2].Value = data;
                                                        }
                                                    }
                                                }
                                                outFromHere = true;
                                                break;
                                            }
                                            if (outFromHere == true)
                                            {
                                                setSaveDatagridOnChanges();
                                                break;
                                            }
                                        }
                                        if (outFromHere == true)
                                        {
                                            break;
                                        }
                                    }
                                    actionHappened = true;
                                    break;
                                case DialogResult.No:
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            dataToChargeData = decideDataGridViewWithData5(dataToChargeData);
            bool allowEnterData = true;
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                if (clickOnDataGrid1 == true || clickOnDataGrid2 == true || clickOnDataGrid3 == true || clickOnDataGrid4 == true || clickOnDataGrid5 == true)
                {
                    string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA: -S/T ABORTAR");
                    data = data.ToUpper();
                    if (data != "S/T")
                    {
                        dataToChargeData.Columns.Add(data, data);
                    }
                    setSaveDatagridOnChanges();
                }
                else if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                {
                    string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA: -S/T ABORTAR");
                    data = data.ToUpper();
                    if (data != "S/T")
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach (DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                            {
                                listSalmon.Add(column.HeaderText);
                            }
                        }
                        generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                        string[,] arrayAnswer = calltoMethods.addColum(dataToChargeData, data, indexColumnOfDatagrid, 1);
                        int rows = arrayAnswer.GetLength(0);
                        int columns = arrayAnswer.GetLength(1);
                        dataToChargeData.Columns.Clear();
                        for (int column = 0; column < columns; column++)
                        {
                            dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                        }

                        for (int row = 0; row < rows - 1; row++)
                        {
                            dataToChargeData.Rows.Add(row.ToString());
                        }
                        int indexData = 0;
                        for (int row = 1; row < rows; row++)
                        {
                            for (int column = 0; column < columns; column++)
                            {
                                dataToChargeData.Rows[indexData].Cells[column].Value = arrayAnswer[row, column];
                            }
                            ++indexData;
                        }
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                        paintColum(dataToChargeData, indexColumnOfDatagrid);
                        baseResizeDatasGridView();
                        actionHappened = true;
                    }
                    setSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("SELECCIONA PRIMERO ALGUNA CELDA ANTES DE AÑADIR");
                }
            }
        }

        private void buttonAddArrow_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
            bool allowEnterData = true;
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                
                if (clickOnDataGrid1 == true || clickOnDataGrid2 == true || clickOnDataGrid3 == true || clickOnDataGrid4 == true || clickOnDataGrid5 == true)
                {
                    int beforeAdd = dataToChargeData.Rows.Count;
                    dataToChargeData.Rows.Add(dataToChargeData.Rows.Count.ToString());
                    for (int column = 1; column < dataToChargeData.Columns.Count; column++)
                    {
                        dataToChargeData.Rows[beforeAdd].Cells[column].Value = " ";
                    }
                    baseResizeDatasGridView();
                    setSaveDatagridOnChanges();
                }
                else if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                {
                    int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                    int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                    List<string> listSalmon = new List<string>();
                    foreach (DataGridViewColumn column in dataToChargeData.Columns)
                    {
                        if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                        {
                            listSalmon.Add(column.HeaderText);
                        }
                    }
                    generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                    string[,] arrayAnswer = calltoMethods.addRow(dataToChargeData, indexRowOfDatagrid);
                    
                    int rows = arrayAnswer.GetLength(0) - 1;
                    int columns = arrayAnswer.GetLength(1);
                    dataToChargeData.Columns.Clear();

                    for (int column = 0; column < columns; column++)
                    {
                        bool found = false;
                        foreach (string compare in listSalmon)
                        {
                            if (compare == arrayAnswer[0, column])
                            {
                                found = true;
                                break;
                            }
                        }
                        dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                        if (found == true)
                        {
                            dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightSalmon;
                        }
                        else if (found == false)
                        {
                            dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                        }
                    }

                    for (int row = 0; row < rows; row++)
                    {
                        dataToChargeData.Rows.Add(row.ToString());
                    }
                    int indexData = 1;
                    for (int row = 0; row < rows; row++)
                    {
                        for (int column = 0; column < columns; column++)
                        {
                            dataToChargeData.Rows[row].Cells[column].Value = arrayAnswer[indexData, column];
                        }
                        ++indexData;
                    }
                    for (int row = 0; row < rows; row++)
                    {
                        dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                    }
                    dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                    dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                    paintRow(dataToChargeData, indexRowOfDatagrid);
                    ++indexRowOfDatagrid;
                    baseResizeDatasGridView();
                    setSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("SELECCIONA ALGO ANTES DE AÑADIR FILA");
                }
                actionHappened = true;
            }
        }


        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            if (indexColumnOfDatagrid > 1)
            {
                DataGridView dataToChargeData = new DataGridView();
                bool allowEnterData = true;
                dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
                if (dataToChargeData.Visible == false)
                {
                    MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                    allowEnterData = false;
                }
                else if (dataToChargeData.Enabled == false)
                {
                    MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                    allowEnterData = false;
                }

                if (allowEnterData == true)
                {
                    if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach (DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                            {
                                listSalmon.Add(column.HeaderText);
                            }
                        }
                        generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                        string[,] arrayAnswer = calltoMethods.MoveBackColum(dataToChargeData, indexColumnOfDatagrid);
                        int rows = arrayAnswer.GetLength(0) - 1;
                        int columns = arrayAnswer.GetLength(1);
                        dataToChargeData.Columns.Clear();

                        for (int column = 0; column < columns; column++)
                        {
                            bool found = false;
                            foreach (string compare in listSalmon)
                            {
                                if (compare == arrayAnswer[0, column])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                            if (found == true)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightSalmon;
                            }
                            else if (found == false)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                            }
                        }
                        for (int row = 0; row < rows - 1; row++)
                        {
                            dataToChargeData.Rows.Add(row.ToString());
                        }
                        int indexData = 0;
                        for (int row = 1; row < rows; row++)
                        {
                            for (int column = 0; column < columns; column++)
                            {
                                dataToChargeData.Rows[indexData].Cells[column].Value = arrayAnswer[row, column];
                            }
                            ++indexData;
                        }
                        --indexColumnOfDatagrid;
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                        paintColum(dataToChargeData, indexColumnOfDatagrid);
                        actionHappened = true;
                    }
                    else
                    {
                        MessageBox.Show("IMPOSIBLE MOVER, SELECCIONA ALGO PRIMERO");
                    }
                }
                else
                {
                    MessageBox.Show("IMPOSIBLE MOVER, ESTAS AL INICIO");
                }
            }
        }

        private void buttonMoveNextColumn_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            bool allowEnterData = true;
            dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                if (indexColumnOfDatagrid < dataToChargeData.Columns.Count - 1)
                {
                    if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach (DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                            {
                                listSalmon.Add(column.HeaderText);
                            }
                        }
                        generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                        string[,] arrayAnswer = calltoMethods.MoveNextColum(dataToChargeData, indexColumnOfDatagrid);
                        int rows = arrayAnswer.GetLength(0) - 1;
                        int columns = arrayAnswer.GetLength(1);
                        dataToChargeData.Columns.Clear();

                        for (int column = 0; column < columns; column++)
                        {
                            bool found = false;
                            foreach (string compare in listSalmon)
                            {
                                if (compare == arrayAnswer[0, column])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                            if (found == true)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightSalmon;
                            }
                            else if (found == false)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                            }
                        }
                        for (int row = 0; row < rows - 1; row++)
                        {
                            dataToChargeData.Rows.Add(row.ToString());
                        }
                        int indexData = 0;
                        for (int row = 1; row < rows; row++)
                        {
                            for (int column = 0; column < columns; column++)
                            {
                                dataToChargeData.Rows[indexData].Cells[column].Value = arrayAnswer[row, column];
                            }
                            ++indexData;
                        }
                        ++indexColumnOfDatagrid;
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                        paintColum(dataToChargeData, indexColumnOfDatagrid);
                        actionHappened = true;
                    } else
                    {
                        MessageBox.Show("IMPOSIBLE MOVER, SELECCIONA ALGO PRIMERO");
                    }
                }
                else
                {
                    MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
                }
            }

        }

        private void buttonMoveUpArrow_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            bool allowEnterData = true;
            dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                if (indexRowOfDatagrid > 0)
                {
                    if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach (DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                            {
                                listSalmon.Add(column.HeaderText);
                            }
                        }
                        generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                        string[,] arrayAnswer = calltoMethods.MoveUpRow(dataToChargeData, indexRowOfDatagrid);
                        int rows = arrayAnswer.GetLength(0) - 1;
                        int columns = arrayAnswer.GetLength(1);
                        dataToChargeData.Columns.Clear();

                        for (int column = 0; column < columns; column++)
                        {
                            bool found = false;
                            foreach (string compare in listSalmon)
                            {
                                if (compare == arrayAnswer[0, column])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                            if (found == true)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightSalmon;
                            }
                            else if (found == false)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                            }
                        }
                        for (int row = 0; row < rows - 1; row++)
                        {
                            dataToChargeData.Rows.Add(row.ToString());
                        }
                        int indexData = 0;
                        for (int row = 1; row < rows; row++)
                        {
                            for (int column = 0; column < columns; column++)
                            {
                                dataToChargeData.Rows[indexData].Cells[column].Value = arrayAnswer[row, column];
                            }
                            ++indexData;
                        }
                        for (int row = 0; row < dataToChargeData.Rows.Count - 1; row++)
                        {
                            dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                        }
                        --indexRowOfDatagrid;
                        paintRow(dataToChargeData, indexRowOfDatagrid);
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                        actionHappened = true;
                    }
                    else
                    {
                        MessageBox.Show("IMPOSIBLE MOVER, NO HAS SELECCIONADO NADA");
                    }
                }
                else
                {
                    MessageBox.Show("IMPOSIBLE MOVER, ESTAS AL INICIO");
                }
            }
        }

        private void buttonMoveDownArrow_Click(object sender, EventArgs e)
        {

            DataGridView dataToChargeData = new DataGridView();
            bool allowEnterData = true;
            dataToChargeData = decideDataGridViewWithOutData5(dataToChargeData);
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }
            // 
            if (allowEnterData == true)
            {
                if (indexRowOfDatagrid < dataToChargeData.Rows.Count - 2)
                {

                    if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach (DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                            {
                                listSalmon.Add(column.HeaderText);
                            }
                        }
                        generalMultiArrayMethods calltoMethods = new generalMultiArrayMethods();
                        string[,] arrayAnswer = calltoMethods.MoveDownRow(dataToChargeData, indexRowOfDatagrid);
                        int rows = arrayAnswer.GetLength(0) - 1;
                        int columns = arrayAnswer.GetLength(1);
                        dataToChargeData.Columns.Clear();

                        for (int column = 0; column < columns; column++)
                        {
                            bool found = false;
                            foreach (string compare in listSalmon)
                            {
                                if (compare == arrayAnswer[0, column])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            dataToChargeData.Columns.Add(arrayAnswer[0, column], arrayAnswer[0, column]);
                            if (found == true)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightSalmon;
                            }
                            else if (found == false)
                            {
                                dataToChargeData.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                            }
                        }
                        for (int row = 0; row < rows - 1; row++)
                        {
                            dataToChargeData.Rows.Add(row.ToString());
                        }

                        int indexData = 0;
                        for (int row = 1; row < rows; row++)
                        {
                            for (int column = 0; column < columns; column++)
                            {
                                dataToChargeData.Rows[indexData].Cells[column].Value = arrayAnswer[row, column];
                            }
                            ++indexData;
                        }
                        for (int row = 0; row < dataToChargeData.Rows.Count - 1; row++)
                        {
                            dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                        }
                        ++indexRowOfDatagrid;
                        paintRow(dataToChargeData, indexRowOfDatagrid);
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                        actionHappened = true;
                    }
                    else
                    {
                        MessageBox.Show("IMPOSIBLE MOVER, SELECCIONA ALGO PRIMERO");
                    }
                }
                else
                {
                    MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
                }
            }

        }

        private void buttonUpdateTemplate_Click(object sender, EventArgs e)
        {
            methodToSave("ALERT");
        }

        private void methodToSave(string message)
        {
            string pathOfFiles = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month;
            string[] storageFiles = Directory.GetFiles(pathOfFiles);
            List<string> names = new List<string>();
            foreach (string path in storageFiles)
            {
                string changeString = path;
                changeString = changeString.Replace(pathOfFiles, "");
                changeString = changeString.Replace(".txt", "");
                changeString = changeString.Replace("\\", "");
                names.Add(changeString);
            }
            foreach (string path in storageFiles)
            {
                if (File.Exists(path) && !path.Contains("\\CORE-FORMULAS.txt") && !path.Contains("\\CORE-FORMULAS-SITS.txt"))
                {
                    File.Delete(path);
                }
            }
            generalMethodToWriteInFiles callToWriteInFiles = new generalMethodToWriteInFiles();
            foreach (string name in names)
            {
                if (name == "1-7")
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + name + ".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row = 0; row < dataGridView1.Rows.Count - 1; row++)
                    {
                        sumString += tagStartLine + "?";
                        for (int column = 0; column < dataGridView1.Columns.Count; column++)
                        {
                            if (dataGridView1.Rows[row].Cells[column].Value == null)
                            {
                                sumString += " " + "?";
                            }
                            else
                            {
                                sumString += dataGridView1.Rows[row].Cells[column].Value + "?";
                            }

                        }
                        sumString += tagEndLine + "?";
                    }
                    sumString = sumString.TrimEnd('?');
                    callToWriteInFiles.writeInFiles(pathToWrite, sumString);
                }
                else if (name == "8-14")
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + name + ".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row = 0; row < dataGridView2.Rows.Count - 1; row++)
                    {
                        sumString += tagStartLine + "?";
                        for (int column = 0; column < dataGridView2.Columns.Count; column++)
                        {
                            if (dataGridView2.Rows[row].Cells[column].Value == null)
                            {
                                sumString += " " + "?";
                            }
                            else
                            {
                                sumString += dataGridView2.Rows[row].Cells[column].Value + "?";
                            }
                        }
                        sumString += tagEndLine + "?";
                    }
                    sumString = sumString.TrimEnd('?');
                    callToWriteInFiles.writeInFiles(pathToWrite, sumString);
                }
                else if (name == "15-21")
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + name + ".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView3.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row = 0; row < dataGridView3.Rows.Count - 1; row++)
                    {
                        sumString += tagStartLine + "?";
                        for (int column = 0; column < dataGridView3.Columns.Count; column++)
                        {
                            if (dataGridView3.Rows[row].Cells[column].Value == null)
                            {
                                sumString += " " + "?";
                            }
                            else
                            {
                                sumString += dataGridView3.Rows[row].Cells[column].Value + "?";
                            }
                        }
                        sumString += tagEndLine + "?";
                    }
                    sumString = sumString.TrimEnd('?');
                    callToWriteInFiles.writeInFiles(pathToWrite, sumString);
                }
                else if (name.Contains("22"))
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + name + ".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView4.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row = 0; row < dataGridView4.Rows.Count - 1; row++)
                    {
                        sumString += tagStartLine + "?";
                        for (int column = 0; column < dataGridView4.Columns.Count; column++)
                        {
                            if (dataGridView4.Rows[row].Cells[column].Value == null)
                            {
                                sumString += " " + "?";
                            }
                            else
                            {
                                sumString += dataGridView4.Rows[row].Cells[column].Value + "?";
                            }
                        }
                        sumString += tagEndLine + "?";
                    }
                    sumString = sumString.TrimEnd('?');
                    callToWriteInFiles.writeInFiles(pathToWrite, sumString);
                }
            }

            string namePhase2 = "SUMA-TOTALES";
            if (namePhase2 == "SUMA-TOTALES")
            {
                string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + namePhase2 + ".txt";
                string sumString = "";
                sumString += tagStartHEad + "?";
                foreach (DataGridViewColumn column in dataGridView5.Columns)
                {
                    sumString += column.HeaderText + "?";
                }
                sumString += tagEndHEad + "?";
                sumString += tagStartLine + "?";
                for (int row = 0; row < dataGridView5.Rows.Count; row++)
                {
                    if (dataGridView5.Rows[row].Cells[0].Value.ToString() == "TOTAL")
                    {
                        for (int column = 0; column < dataGridView5.Columns.Count; column++)
                        {
                            if (dataGridView5.Rows[row].Cells[column].Value == null)
                            {
                                sumString += " " + "?";
                            }
                            else
                            {
                                sumString += dataGridView5.Rows[row].Cells[column].Value + "?";
                            }
                        }
                        break;
                    }
                }
                sumString += tagEndLine + "?";
                sumString = sumString.TrimEnd('?');
                callToWriteInFiles.writeInFiles(pathToWrite, sumString);
            }
            namePhase2 = "CONFIGURACIONES-CELDAS";
            if (namePhase2 == "CONFIGURACIONES-CELDAS")
            {
                string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + namePhase2 + ".txt";
                string sumString = "";
                //
                sumString += tagStartDataGrid1 + "?";
                sumString += dataGridView1.Visible.ToString() + "?";
                sumString += dataGridView1.Enabled.ToString() + "?";
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString() + "?";
                    if (column.HeaderCell.Style.BackColor == Color.LightGray)
                    {
                        sumString += "True" + "?";
                    }
                    else if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                    {
                        sumString += "False" + "?";
                    }
                }
                sumString += tagEndDataGrid1 + "?";
                //
                sumString += tagStartDataGrid2 + "?";
                sumString += dataGridView2.Visible.ToString() + "?";
                sumString += dataGridView2.Enabled.ToString() + "?";
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString() + "?";
                    if (column.HeaderCell.Style.BackColor == Color.LightGray)
                    {
                        sumString += "True" + "?";
                    }
                    else if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                    {
                        sumString += "False" + "?";
                    }
                }
                sumString += tagEndDataGrid2 + "?";
                //
                sumString += tagStartDataGrid3 + "?";
                sumString += dataGridView3.Visible.ToString() + "?";
                sumString += dataGridView3.Enabled.ToString() + "?";
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString() + "?";
                    if (column.HeaderCell.Style.BackColor == Color.LightGray)
                    {
                        sumString += "True" + "?";
                    }
                    else if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                    {
                        sumString += "False" + "?";
                    }
                }
                sumString += tagEndDataGrid3 + "?";
                //
                sumString += tagStartDataGrid4 + "?";
                sumString += dataGridView4.Visible.ToString() + "?";
                sumString += dataGridView4.Enabled.ToString() + "?";
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString() + "?";
                    if (column.HeaderCell.Style.BackColor == Color.LightGray)
                    {
                        sumString += "True" + "?";
                    }
                    else if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                    {
                        sumString += "False" + "?";
                    }
                }
                sumString += tagEndDataGrid4 + "?";
                //
                sumString = sumString.TrimEnd('?');
                callToWriteInFiles.writeInFiles(pathToWrite, sumString);
            }
            if (message == "ALERT")
            {
                MessageBox.Show("ACTUALIZADO EXITOSAMENTE");
            }
            actionHappened = false;
        }

        private void buttonEraseColumn_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            dataToChargeData = decideDataGridViewWithData5(dataToChargeData);
            bool allowEnterData = true;
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                {
                    dataGridviewToWhite(dataToChargeData);
                    dataToChargeData.Columns.RemoveAt(indexColumnOfDatagrid);
                    paintColum(dataToChargeData, indexColumnOfDatagrid);
                    actionHappened = true;
                    setSaveDatagridOnChanges();
                } else
                {
                    MessageBox.Show("SELECCIONA  PRIMERO ALGUNA CELDA ANTES DE ELIMINAR");
                }
            }
        }

        private void buttonEraseArrow_Click(object sender, EventArgs e)
        {
            DataGridView dataToChargeData = new DataGridView();
            dataToChargeData = decideDataGridViewWithData5(dataToChargeData);
            bool allowEnterData = true;
            if (dataToChargeData.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
                allowEnterData = false;
            }
            else if (dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                {
                    dataGridviewToWhite(dataToChargeData);
                    dataToChargeData.Rows.RemoveAt(indexRowOfDatagrid);
                    for (int row = 0; row < dataToChargeData.Rows.Count - 1; row++)
                    {
                        dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                    }
                    actionHappened = true;
                    paintRow(dataToChargeData, indexRowOfDatagrid);
                    setSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("SELECCIONA PRIMERO ALGUNA CELDA ANTES DE ELIMINAR");
                }
            }
        }

        private void buttonGenerateSits_Click(object sender, EventArgs e)
        {
            List<string> listOfHeads = new List<string>();
            foreach (DataGridViewColumn column in dataGridView5.Columns)
            {
                listOfHeads.Add(column.HeaderText);
            }
            GUI_SELECCIONAR_ASIENTOS callingCreateFormula = new GUI_SELECCIONAR_ASIENTOS();
            callingCreateFormula.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callingCreateFormula.lisfOFHeads(listOfHeads);
            callingCreateFormula.PathToCompany(company, deparment, month);
            callingCreateFormula.menuGlobalOrLocal("LOCAL");
            callingCreateFormula.ShowDialog();
        }

        private void buttonGenerateFormula_Click(object sender, EventArgs e)
        {
            List<string> listOfHeads = new List<string>();
            foreach (DataGridViewColumn column in dataGridView5.Columns)
            {
                listOfHeads.Add(column.HeaderText);
            }
            GUI_CREATE_FORMULA callingCreateFormula = new GUI_CREATE_FORMULA();
            callingCreateFormula.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callingCreateFormula.lisftOfHeads(listOfHeads);
            callingCreateFormula.PathToCompany(company, deparment, month);
            callingCreateFormula.menuGlobalOrLocal("LOCAL");
            callingCreateFormula.ShowDialog();
        }

        private void buttonImportDataColumn_Click(object sender, EventArgs e)
        {
            GUI_ELEGIR_GENERAR_TOTALES callToSelecDepartmens = new GUI_ELEGIR_GENERAR_TOTALES();
            callToSelecDepartmens.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callToSelecDepartmens.PathToCompany(company);
            callToSelecDepartmens.ordeOrSitOrImport("IMPORT-EXPORT");
            callToSelecDepartmens.ShowDialog();
            List<string> listDepartments = callToSelecDepartmens.getListOfDepartments();
            callToSelecDepartmens.Close();
            if (listDepartments != null && listDepartments.Count > 0)
            {
                List<string> changeList = new List<string>();
                string replaceString = "";
                foreach (string path in listDepartments)
                {
                    if (path.Contains("SEMANA 1"))
                    {
                        replaceString = path.Replace("SEMANA 1", "1-7");
                        changeList.Add(replaceString);
                    }
                    else if (path.Contains("SEMANA 2"))
                    {
                        replaceString = path.Replace("SEMANA 2", "8-14");
                        changeList.Add(replaceString);
                    }
                    else if (path.Contains("SEMANA 3"))
                    {
                        replaceString = path.Replace("SEMANA 3", "15-21");
                        changeList.Add(replaceString);
                    }
                    else if (path.Contains("SEMANA 4"))
                    {
                        replaceString = path.Replace("SEMANA 4", "22-");
                        changeList.Add(replaceString);
                    }
                }
                listDepartments = changeList;
                //List<string> listFiles = new List<string>();
                string companyPhase2 = CorePathOfFolderCompaniesSistemaPlanillas + company;
                string[] storageDept = Directory.GetDirectories(companyPhase2);
                string finalPath = "";
                foreach (string dept in storageDept)
                {
                    //MessageBox.Show(dept);
                    string[] storageMonth = Directory.GetDirectories(dept);
                    foreach (string month in storageMonth)
                    {
                        string[] storageFiles = Directory.GetFiles(month);
                        foreach (string file in storageFiles)
                        {
                            foreach (string compare in listDepartments)
                            {
                                if (file.Contains(compare))
                                {
                                    finalPath = file;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (File.Exists(finalPath))
                {
                    string replaceColumns = "-REEMPLAZAR COLUMNAS-";
                    string newColumns = "-AÑADIR COLUMNAS-";
                    string startColumns = "-NUEVAS COLUMNAS-";

                    string replaceRows = "-REEMPLAZAR FILAS-";
                    string newRows = "-AÑADIR FILAS-";
                    string startRows = "-NUEVAS FILAS-";

                    GUI_IMPORT_DATA_AND_COLUMNS callToImport = new GUI_IMPORT_DATA_AND_COLUMNS();
                    callToImport.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
                    callToImport.pathToChargeCompany(finalPath);
                    callToImport.ShowDialog();
                    List<string[]> listOfColumns = callToImport.getListColumns();
                    List<string[]> listOfRows = callToImport.getListRows();
                    string orderColumns = callToImport.getOrderColumns();
                    string orderRows = callToImport.getOrderRows();
                    string orderTable = callToImport.getTable();
                    DataGridView dataToStudy = new DataGridView();
                    if (orderTable == "TABLA 1")
                    {
                        clickOnCellDataGrid1 = true;
                        clickOnCellDataGrid2 = false;
                        clickOnCellDataGrid3 = false;
                        clickOnCellDataGrid4 = false;
                        //
                        dataGridView1.Visible = true;
                        dataGridView1.Enabled = true;
                        dataToStudy = dataGridView1;
                    } else if (orderTable == "TABLA 2")
                    {
                        clickOnCellDataGrid1 = false;
                        clickOnCellDataGrid2 = true;
                        clickOnCellDataGrid3 = false;
                        clickOnCellDataGrid4 = false;
                        //
                        dataGridView2.Visible = true;
                        dataGridView2.Enabled = true;
                        dataToStudy = dataGridView2;
                    }
                    else if (orderTable == "TABLA 3")
                    {
                        clickOnCellDataGrid1 = false;
                        clickOnCellDataGrid2 = false;
                        clickOnCellDataGrid3 = true;
                        clickOnCellDataGrid4 = false;
                        //
                        dataGridView3.Visible = true;
                        dataGridView3.Enabled = true;
                        dataToStudy = dataGridView3;
                    }
                    else if (orderTable == "TABLA 4")
                    {
                        clickOnCellDataGrid1 = false;
                        clickOnCellDataGrid2 = false;
                        clickOnCellDataGrid3 = false;
                        clickOnCellDataGrid4 = true;
                        //
                        dataGridView4.Visible = true;
                        dataGridView4.Enabled = true;
                        dataToStudy = dataGridView4;
                    }

                    if (orderColumns == threeLine)
                    {

                    } else if (orderColumns == replaceColumns)
                    {
                        for (int dataGrid = 0; dataGrid < listOfColumns.Count; dataGrid++)
                        {
                            string[] columnToStudy = listOfColumns[dataGrid];
                            if (dataToStudy.Rows.Count < columnToStudy.Length)
                            {
                                for (int create = dataToStudy.Rows.Count; create < columnToStudy.Length - 1; create++)
                                {
                                    dataToStudy.Rows.Add(create.ToString());
                                }
                            }
                        }

                        for (int dataGrid = 0; dataGrid < listOfColumns.Count; dataGrid++)
                        {
                            string[] columnToStudy = listOfColumns[dataGrid];
                            for (int column = 0; column < dataToStudy.Columns.Count; column++)
                            {
                                if (dataToStudy.Columns[column].HeaderText == columnToStudy[0])
                                {
                                    int index = 1;
                                    for (int row = 0; row < dataToStudy.Rows.Count - 1; row++)
                                    {
                                        dataToStudy.Rows[row].Cells[column].Value = columnToStudy[index];
                                        ++index;
                                    }
                                    break;
                                }
                            }
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("REEMPLAZO COLUMNAS EXITOSA");
                    } else if (orderColumns == startColumns)
                    {
                        dataToStudy.Columns.Clear();
                        dataToStudy.EnableHeadersVisualStyles = false;
                        for (int column = 0; column < listOfColumns.Count; column++)
                        {
                            string[] columnToStudy = listOfColumns[column];
                            dataToStudy.Columns.Add(columnToStudy[0], columnToStudy[0]);
                            dataToStudy.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                        }

                        for (int dataGrid = 0; dataGrid < listOfColumns.Count; dataGrid++)
                        {
                            string[] columnToStudy = listOfColumns[dataGrid];
                            if (dataToStudy.Rows.Count - 1 < columnToStudy.Length - 1)
                            {
                                for (int create = 0; create < columnToStudy.Length - 1; create++)
                                {
                                    dataToStudy.Rows.Add(create.ToString());
                                }
                            }
                        }

                        for (int column = 0; column < dataToStudy.Columns.Count; column++)
                        {
                            string[] columnToStudy = listOfColumns[column];
                            int index = 1;
                            for (int row = 0; row < columnToStudy.Length - 1; row++)
                            {
                                dataToStudy.Rows[row].Cells[column].Value = columnToStudy[index];
                                ++index;
                            }
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("IMPORTACION COLUMNAS EXITOSA");
                    }
                    else if (orderColumns == newColumns)
                    {
                        dataToStudy.EnableHeadersVisualStyles = false;
                        for (int column = 0; column < listOfColumns.Count; column++)
                        {
                            string[] columnToStudy = listOfColumns[column];
                            dataToStudy.Columns.Add(columnToStudy[0], columnToStudy[0]);
                            dataToStudy.Columns[column].HeaderCell.Style.BackColor = Color.LightGray;
                        }

                        for (int column = 0; column < listOfColumns.Count; column++)
                        {
                            string[] columnToStudy = listOfColumns[column];
                            if (dataToStudy.Rows.Count - 1 < columnToStudy.Length - 1)
                            {
                                for (int create = dataToStudy.Rows.Count - 1; create < columnToStudy.Length - 1; create++)
                                {
                                    dataToStudy.Rows.Add(create.ToString());
                                }
                            }
                        }

                        int indexPhase1 = 0;
                        int start = dataToStudy.Columns.Count - listOfColumns.Count;
                        for (int column = start; column < dataToStudy.Columns.Count; column++)
                        {
                            string[] columnToStudy = listOfColumns[indexPhase1];
                            int indexPhase2 = 1;
                            for (int row = 0; row < dataToStudy.Rows.Count - 1; row++)
                            {
                                dataToStudy.Rows[row].Cells[column].Value = columnToStudy[indexPhase2];
                                ++indexPhase2;
                            }
                            ++indexPhase1;
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("IMPORTACION COLUMNAS EXITOSA");
                    }

                    if (orderRows == threeLine)
                    {

                    }
                    else if (orderRows == replaceRows)
                    {
                        for (int dataGrid = 0; dataGrid < listOfRows.Count; dataGrid++)
                        {
                            string[] rowToStudy = listOfRows[dataGrid];

                            if (dataToStudy.Columns.Count - 1 < rowToStudy.Length - 1)
                            {
                                for (int create = dataToStudy.Columns.Count - 1; create < rowToStudy.Length - 1; create++)
                                {
                                    dataToStudy.Columns.Add(create.ToString(), create.ToString());
                                }
                            }

                            for (int row = 0; row < dataToStudy.Rows.Count - 1; row++)
                            {
                                if (dataToStudy.Rows[row].Cells[0].Value.ToString() == rowToStudy[0])
                                {
                                    for (int colum = 1; colum < rowToStudy.Length; colum++)
                                    {
                                        dataToStudy.Rows[row].Cells[colum].Value = rowToStudy[colum];
                                    }
                                    break;
                                }
                            }
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("IMPORTACION FILAS EXITOSA");
                    }
                    else if (orderRows == startRows)
                    {
                        dataToStudy.Rows.Clear();
                        dataToStudy.EnableHeadersVisualStyles = false;
                        for (int row = 0; row < listOfRows.Count; row++)
                        {
                            dataToStudy.Rows.Add(row.ToString());
                        }

                        for (int dataGrid = 0; dataGrid < listOfColumns.Count; dataGrid++)
                        {
                            string[] columnToStudy = listOfColumns[dataGrid];
                            if (dataToStudy.Columns.Count < columnToStudy.Length - 1)
                            {
                                for (int column = 0; column < columnToStudy.Length; column++)
                                {
                                    dataToStudy.Columns.Add(column.ToString(), column.ToString());
                                }
                            }
                        }
                        int indexPhase1 = 0;
                        for (int row = 0; row < dataToStudy.Rows.Count - 1; row++)
                        {
                            string[] columnToStudy = listOfRows[indexPhase1];
                            for (int column = 1; column < columnToStudy.Length; column++)
                            {
                                dataToStudy.Rows[row].Cells[column].Value = columnToStudy[column];
                            }
                            ++indexPhase1;
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("IMPORTACION FILAS EXITOSA");
                    }
                    else if (orderRows == newRows)
                    {
                        for (int create = 0; create < listOfRows.Count; create++)
                        {
                            dataToStudy.Rows.Add(create.ToString(), create.ToString());
                        }

                        for (int dataGrid = 0; dataGrid < listOfRows.Count; dataGrid++)
                        {
                            string[] rowToStudy = listOfRows[dataGrid];
                            if (dataToStudy.Columns.Count - 1 < rowToStudy.Length - 1)
                            {
                                for (int create = dataToStudy.Columns.Count - 1; create < rowToStudy.Length - 1; create++)
                                {
                                    dataToStudy.Columns.Add(create.ToString(), create.ToString());
                                }
                            }
                        }
                        int start = dataToStudy.Rows.Count - listOfRows.Count - 1;
                        int dataGridIndex = 0;
                        for (int row = start; row < dataToStudy.Rows.Count - 1; row++)
                        {
                            string[] rowToStudy = listOfRows[dataGridIndex];
                            for (int column = 1; column < rowToStudy.Length; column++)
                            {
                                dataToStudy.Rows[row].Cells[column].Value = rowToStudy[column];
                            }
                            ++dataGridIndex;
                        }
                        for (int row = start; row < dataToStudy.Rows.Count - 1; row++)
                        {
                            dataToStudy.Rows[row].Cells[0].Value = row.ToString();
                        }
                        setSaveDatagridOnChanges();
                        MessageBox.Show("IMPORTACION FILAS EXITOSA");
                    }
                    baseResizeDatasGridView();
                    actionHappened = true;
                }
            }

        }

        List<string[,]> listDataGriView1OnTime = new List<string[,]>();
        List<string[,]> listDataGriView2OnTime = new List<string[,]>();
        List<string[,]> listDataGriView3OnTime = new List<string[,]>();
        List<string[,]> listDataGriView4OnTime = new List<string[,]>();
        int indexDataGriView1OnTime = 0;
        int indexDataGriView2OnTime = 0;
        int indexDataGriView3OnTime = 0;
        int indexDataGriView4OnTime = 0;

        private void setSaveDatagridOnChangesFirstTime()
        {
            generalMultiArrayMethods callToGetArray = new generalMultiArrayMethods();
            if (clickOnCellDataGrid1 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView1OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView1));
            }
            else if (clickOnCellDataGrid2 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView2OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView2));
            }
            else if (clickOnCellDataGrid3 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView3OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView3));
            }
            else if (clickOnCellDataGrid4 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView4OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView4));
            }
        }
        private void setSaveDatagridOnChanges()
        {
            generalMultiArrayMethods callToGetArray = new generalMultiArrayMethods();
            if (clickOnCellDataGrid1==true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView1OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView1));
                ++indexDataGriView1OnTime;
            }
            else if(clickOnCellDataGrid2==true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView2OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView2));
                ++indexDataGriView2OnTime;
            }
            else if (clickOnCellDataGrid3 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView3OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView3));
                ++indexDataGriView3OnTime;
            }
            else if (clickOnCellDataGrid4 == true)
            {
                buttonBackTotal.Enabled = true;
                buttonNextTotal.Enabled = true;
                listDataGriView4OnTime.Add(callToGetArray.fillAndGetdataInDataGrid(dataGridView4));
                ++indexDataGriView4OnTime;
            }
        }

        private void getSaveDatagridOnChanges()
        {
            if (clickOnCellDataGrid1 == true)
            {
                string [,]daToStudy = listDataGriView1OnTime[indexDataGriView1OnTime];
                chargeBackAndNextData(daToStudy, dataGridView1);
                baseResizeDatasGridView();
            }
            else if (clickOnCellDataGrid2 == true)
            {
                string[,] daToStudy = listDataGriView2OnTime[indexDataGriView2OnTime];
                chargeBackAndNextData(daToStudy, dataGridView2);
                baseResizeDatasGridView();
            }
            else if (clickOnCellDataGrid3 == true)
            {
                string[,] daToStudy = listDataGriView3OnTime[indexDataGriView3OnTime];
                chargeBackAndNextData(daToStudy, dataGridView3);
                baseResizeDatasGridView();
            }
            else if (clickOnCellDataGrid4 == true && indexDataGriView4OnTime < listDataGriView4OnTime.Count)
            {
                string[,] daToStudy = listDataGriView4OnTime[indexDataGriView4OnTime];
                chargeBackAndNextData(daToStudy, dataGridView4);
                baseResizeDatasGridView();
            }
        }

        private void chargeBackAndNextData(string [,] daToStudy, DataGridView daToGoal)
        {
            daToGoal.Columns.Clear();
            for (int add = 0; add < daToStudy.GetLength(1); add++)
            {
                if (daToStudy[0, add].Contains("SALMON?"))
                {
                    string changeString = daToStudy[0, add].Replace("SALMON?", "");
                    daToGoal.Columns.Add(changeString, changeString);
                    daToGoal.Columns[add].HeaderText = changeString;
                    daToGoal.Columns[add].HeaderCell.Style.BackColor = Color.LightSalmon;
                }
                else if (daToStudy[0, add].Contains("GRAY?"))
                {
                    string changeString = daToStudy[0, add].Replace("GRAY?", "");
                    daToGoal.Columns.Add(changeString, changeString);
                    daToGoal.Columns[add].HeaderText = changeString;
                    daToGoal.Columns[add].HeaderCell.Style.BackColor = Color.LightGray;
                }
            }
            for (int add = 0; add < daToStudy.GetLength(0) - 1; add++)
            {
                daToGoal.Rows.Add(add.ToString());
            }

            int index = 0;
            for (int row = 1; row < daToStudy.GetLength(0); row++)
            {
                for (int column = 1; column < daToStudy.GetLength(1); column++)
                {
                    daToGoal.Rows[index].Cells[column].Value = daToStudy[row, column];
                }
                ++index;
            }
        }
        private void buttonBackTotal_Click_1(object sender, EventArgs e)
        {
            if (clickOnCellDataGrid1 == true)
            {
                if (indexDataGriView1OnTime >0)
                {
                    --indexDataGriView1OnTime;
                    getSaveDatagridOnChanges();
                    actionHappened = true;
                }
                else
                {
                    MessageBox.Show("INICIO");
                }
            }
            else if (clickOnCellDataGrid2 == true)
            {
                if (indexDataGriView2OnTime > 0)
                {
                    --indexDataGriView2OnTime;
                    actionHappened = true;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("INICIO");
                }
            }
            else if (clickOnCellDataGrid3 == true)
            {
                if (indexDataGriView3OnTime > 0)
                {
                    --indexDataGriView3OnTime;
                    actionHappened = true;
                    getSaveDatagridOnChanges();
                }else
                {
                    MessageBox.Show("INICIO");
                }
            }
            else if (clickOnCellDataGrid4 == true)
            {
                if (indexDataGriView4OnTime > 0)
                {
                    --indexDataGriView4OnTime;
                    actionHappened = true;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("INICIO");
                }
            }
            
        }

        private void buttonNextTotal_Click(object sender, EventArgs e)
        {
            if (clickOnCellDataGrid1 == true)
            {
                if (indexDataGriView1OnTime < listDataGriView1OnTime.Count-1)
                {
                    actionHappened = true;
                    ++indexDataGriView1OnTime;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("FIN");
                }
            }
            else if (clickOnCellDataGrid2 == true)
            {
                if (indexDataGriView2OnTime < listDataGriView2OnTime.Count-1)
                {
                    actionHappened = true;
                    ++indexDataGriView2OnTime;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("FIN");
                }
            }
            else if (clickOnCellDataGrid3 == true)
            {
                if (indexDataGriView3OnTime < listDataGriView3OnTime.Count-1)
                {
                    actionHappened = true;
                    ++indexDataGriView3OnTime;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("FIN");
                }
            }
            else if (clickOnCellDataGrid4 == true)
            {
                if (indexDataGriView4OnTime < listDataGriView4OnTime.Count-1)
                {
                    actionHappened = true;
                    ++indexDataGriView4OnTime;
                    getSaveDatagridOnChanges();
                }
                else
                {
                    MessageBox.Show("FIN");
                }
            }
        }

        private void buttonRecalculate_Click(object sender, EventArgs e)
        {
            sumTheCellsofAll();
            actionHappened = true;
        }
        
        private void GUI_WORK_COMPANY_Resize(object sender, EventArgs e)
        {
            baseResizeDatasGridView();
        }

        string orderDatagrid = "";
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            checkedListBox2.Items.Clear();
            foreach (Object item in checkedListBox1.CheckedItems)
            {
                int index = checkedListBox1.Items.IndexOf(item);
                bool answer = checkedListBox1.GetItemChecked(index);
                if (answer == true)
                {
                    DataGridView DataToStudy = new DataGridView();
                    string week = checkedListBox1.Items[index].ToString();
                    if (week.Contains("1-7"))
                    {
                        DataToStudy = dataGridView1;
                    } else if (week.Contains("8-14"))
                    {
                        DataToStudy = dataGridView2;
                    }
                    else if (week.Contains("15-21"))
                    {
                        DataToStudy = dataGridView3;
                    }
                    else if (week.Contains("22"))
                    {
                        DataToStudy = dataGridView4;
                    }
                    bool visible = DataToStudy.Visible;
                    bool calculate = DataToStudy.Enabled;
                    checkedListBox2.Items.Add("VISIBLE", visible);
                    checkedListBox2.Items.Add("CALCULAR", calculate);
                    orderDatagrid = "bigFrame";
                    break;
                }
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < checkedListBox1.Items.Count; index++)
            {
                checkedListBox1.SetItemChecked(index, false);
            }
            comboBox2.Items.Clear();
            checkedListBox2.Items.Clear();
            comboBox2.Items.Add("--ELEGIR VISIBLES--");
            comboBox2.Items.Add("--TODOS VISIBLES--");
            comboBox2.Items.Add("--TODOS INVISIBLES--");
            comboBox2.Items.Add("--ELEGIR CALCULAR--");
            comboBox2.Items.Add("--TODOS CALCULAR--");
            comboBox2.Items.Add("--TODOS NOCALCULAR--");
        }

        //reandonly=true NO CALCULAR
        //reandonly=false CALCULAR
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            checkedListBox2.Items.Clear();
            DataGridView DataToStudy = new DataGridView();
            if (comboBox1.Text == "SEMANA 1")
            {
                DataToStudy = dataGridView1;
            }
            else if (comboBox1.Text == "SEMANA 2")
            {
                DataToStudy = dataGridView2;
            }
            else if (comboBox1.Text == "SEMANA 3")
            {
                DataToStudy = dataGridView3;
            }
            else if (comboBox1.Text == "SEMANA 4")
            {
                DataToStudy = dataGridView4;
            }

            if (comboBox2.Text == "--TODOS VISIBLES--")
            {
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    column.Visible = true;
                }
                checkedListBox2.Items.Add("TAREA COMPLETA", CheckState.Checked);
                orderDatagrid = "TODOS";
            }
            else if (comboBox2.Text == "--TODOS INVISIBLES--")
            {
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    column.Visible = false;
                }
                checkedListBox2.Items.Add("TAREA COMPLETA", CheckState.Checked);
                orderDatagrid = "TODOS";
            }
            else if (comboBox2.Text == "--TODOS CALCULAR--")
            {
                DataToStudy.Enabled = true;
                DataToStudy.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                checkedListBox2.Items.Add("TAREA COMPLETA", CheckState.Checked);
                DataToStudy.Enabled = true;
                orderDatagrid = "TODOS";
            }
            else if (comboBox2.Text == "--TODOS NOCALCULAR--")
            {
                DataToStudy.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightSalmon;
                }
                checkedListBox2.Items.Add("TAREA COMPLETA", CheckState.Checked);
                DataToStudy.Enabled = false;
                orderDatagrid = "TODOS";
            }
            else if (comboBox2.Text == "--ELEGIR VISIBLES--")
            {
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    if (column.Visible == false)
                    {
                        checkedListBox2.Items.Add(column.HeaderText, CheckState.Unchecked);
                    }
                    else if (column.Visible == true)
                    {
                        checkedListBox2.Items.Add(column.HeaderText, CheckState.Checked);
                    }
                }
            }
            else if (comboBox2.Text == "--ELEGIR CALCULAR--")
            {
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    if (column.HeaderCell.Style.BackColor == Color.LightSalmon)
                    {
                        checkedListBox2.Items.Add(column.HeaderText, CheckState.Unchecked);
                    }
                    else if (column.HeaderCell.Style.BackColor == Color.LightGray)
                    {
                        checkedListBox2.Items.Add(column.HeaderText, CheckState.Checked);
                    }
                }
            }
        }

        private void checkedListBox2_MouseUp(object sender, MouseEventArgs e)
        {
            if (orderDatagrid == "bigFrame")
            {
                DataGridView DataToStudy = new DataGridView();
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    int index = checkedListBox1.Items.IndexOf(item);
                    bool answer = checkedListBox1.GetItemChecked(index);
                    if (answer == true)
                    {
                        string week = checkedListBox1.Items[index].ToString();
                        if (week.Contains("1-7"))
                        {
                            DataToStudy = dataGridView1;
                        }
                        else if (week.Contains("8-14"))
                        {
                            DataToStudy = dataGridView2;
                        }
                        else if (week.Contains("15-21"))
                        {
                            DataToStudy = dataGridView3;
                        }
                        else if (week.Contains("22"))
                        {
                            DataToStudy = dataGridView4;
                        }
                        break;
                    }
                }
                foreach (Object item in checkedListBox2.Items)
                {
                    int index = checkedListBox2.Items.IndexOf(item);
                    bool answer = checkedListBox2.GetItemChecked(index);
                    if (answer == true)
                    {
                        if (item.ToString() == "VISIBLE")
                        {
                            DataToStudy.Visible = true;
                        }
                        if (item.ToString() == "CALCULAR")
                        {
                            DataToStudy.Enabled = true;
                            DataToStudy.EnableHeadersVisualStyles = false;
                            foreach (DataGridViewColumn colum in DataToStudy.Columns)
                            {
                                colum.HeaderCell.Style.BackColor = Color.LightGray;
                            }
                            DataToStudy.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                        }
                        //break;
                    } else
                    {
                        if (item.ToString() == "VISIBLE")
                        {
                            DataToStudy.Visible = false;
                        }

                        if (item.ToString() == "CALCULAR")
                        {
                            DataToStudy.EnableHeadersVisualStyles = false;
                            foreach (DataGridViewColumn colum in DataToStudy.Columns)
                            {
                                colum.HeaderCell.Style.BackColor = Color.LightSalmon;
                            }
                            DataToStudy.Enabled = false;
                            DataToStudy.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
                checkedListBox2.Items.Clear();
                for (int index = 0; index < checkedListBox1.Items.Count; index++)
                {
                    checkedListBox1.SetItemChecked(index, false);
                }
                checkedListBox1.Text = threeLine;
                baseResizeDatasGridView();
            } else if (orderDatagrid == "TODOS")
            {
                //checkedListBox2.Items.Clear();
                comboBox1.Text = threeLine;
                comboBox2.Text = threeLine;
            }
            else
            {
                DataGridView DataToStudy = new DataGridView();
                if (comboBox1.Text == "SEMANA 1")
                {
                    DataToStudy = dataGridView1;
                }
                else if (comboBox1.Text == "SEMANA 2")
                {
                    DataToStudy = dataGridView2;
                }
                else if (comboBox1.Text == "SEMANA 3")
                {
                    DataToStudy = dataGridView3;
                }
                else if (comboBox1.Text == "SEMANA 4")
                {
                    DataToStudy = dataGridView4;
                }

                if (comboBox2.Text == "--ELEGIR VISIBLES--")
                {
                    foreach (DataGridViewColumn column in DataToStudy.Columns)
                    {
                        foreach (Object item in checkedListBox2.Items)
                        {
                            if (item.ToString() == column.HeaderText)
                            {
                                int index = checkedListBox2.Items.IndexOf(item);
                                bool answer = checkedListBox2.GetItemChecked(index);
                                column.Visible = answer;
                                break;
                            }
                        }
                    }
                }
                else if (comboBox2.Text == "--ELEGIR CALCULAR--")
                {
                    foreach (DataGridViewColumn column in DataToStudy.Columns)
                    {
                        DataToStudy.EnableHeadersVisualStyles = false;
                        foreach (Object item in checkedListBox2.Items)
                        {
                            if (item.ToString() == column.HeaderText)
                            {
                                int index = checkedListBox2.Items.IndexOf(item);
                                bool answer = checkedListBox2.GetItemChecked(index);
                                if (answer == false)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightSalmon;
                                }
                                else if (answer == true)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightGray;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            orderDatagrid = "";
            actionHappened = true;
        }

        public void PathToCompany(string companyReceive, string deptReceive, string monthReceive, string pathReceive)
        {
            company = companyReceive;
            deparment = deptReceive;
            month = monthReceive;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            if(actionHappened == true)
            {
                DialogResult answer = MessageBox.Show("¿HAY CAMBIOS NO GUARDADOS, DESEA GUARDARLOS?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                switch (answer)
                {
                    case DialogResult.Yes:
                        methodToSave("!ALERT");
                    break;
                    case DialogResult.No:
                    break;
                }
            }
            this.Close();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            clickOnDataGrid1 = true;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;
        }

        private void dataGridView2_Click_1(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = true;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;
        }

        private void dataGridView3_Click_1(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = true;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;
        }

        private void dataGridView4_Click_1(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = true;
            clickOnDataGrid5 = false;
        }

        private void dataGridView5_Click_1(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnCellDataGrid1 = true;
            clickOnCellDataGrid2 = false;
            clickOnCellDataGrid3 = false;
            clickOnCellDataGrid4 = false;
            clickOnCellDataGrid5 = false;
            try
            {
                indexColumnOfDatagrid = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { //MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); 
            }
            try
            {
                indexRowOfDatagrid = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { //MessageBox.Show("FILA NO SE HA SELECCIONANDO "); 
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnCellDataGrid1 = false;
            clickOnCellDataGrid2 = true;
            clickOnCellDataGrid3 = false;
            clickOnCellDataGrid4 = false;
            clickOnCellDataGrid5 = false;
            try
            {
                indexColumnOfDatagrid = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { //MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); 
            }
            try
            {
                indexRowOfDatagrid = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { //MessageBox.Show("FILA NO SE HA SELECCIONANDO "); 
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnCellDataGrid1 = false;
            clickOnCellDataGrid2 = false;
            clickOnCellDataGrid3 = true;
            clickOnCellDataGrid4 = false;
            clickOnCellDataGrid5 = false;
            try
            {
                indexColumnOfDatagrid = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { //MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); 
            }
            try
            {
                indexRowOfDatagrid = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { //MessageBox.Show("FILA NO SE HA SELECCIONANDO "); 
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnCellDataGrid1 = false;
            clickOnCellDataGrid2 = false;
            clickOnCellDataGrid3 = false;
            clickOnCellDataGrid4 = true;
            clickOnCellDataGrid5 = false;
            try
            {
                indexColumnOfDatagrid = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { 
                //MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); 
            }
            try
            {
                indexRowOfDatagrid = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { //MessageBox.Show("FILA NO SE HA SELECCIONANDO "); 
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickOnCellDataGrid1 = false;
            clickOnCellDataGrid2 = false;
            clickOnCellDataGrid3 = false;
            clickOnCellDataGrid4 = false;
            clickOnCellDataGrid5 = true;
            try
            {
                indexColumnOfDatagrid = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
            }
            catch (Exception)
            { //MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); 
            }
            try
            {
                indexRowOfDatagrid = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { //MessageBox.Show("FILA NO SE HA SELECCIONANDO "); 
            }
        }

        private void paintColum(DataGridView dataToChange, int flag)
        {
            for(int row=0; row<dataToChange.Rows.Count; row++)
            {
                dataToChange.Rows[row].Cells[flag].Style.BackColor = Color.LightGreen;
            }
        }

        private void paintRow(DataGridView dataToChange, int flag)
        {
            for (int column = 0; column < dataToChange.Columns.Count; column++)
            {
                dataToChange.Rows[flag].Cells[column].Style.BackColor = Color.LightGreen;
            }
        }

        private DataGridView decideDataGridViewWithData5(DataGridView dataToChargeData)
        {
            if (clickOnDataGrid1 == true && dataGridView1.Visible == true && dataGridView1.Enabled == true)
            {
                dataToChargeData = dataGridView1;
            }
            else if (clickOnDataGrid1 == true && dataGridView1.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid1 == true && dataGridView1.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Visible == true && dataGridView2.Enabled == true)
            {
                dataToChargeData = dataGridView2;
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Visible == true && dataGridView3.Enabled == true)
            {
                dataToChargeData = dataGridView3;
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Visible == true && dataGridView4.Enabled == true)
            {
                dataToChargeData = dataGridView4;
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid5 == true)
            {
                dataToChargeData = dataGridView5;
            }
            return dataToChargeData;
        }
        private DataGridView decideDataGridViewWithOutData5(DataGridView dataToChargeData)
        {
            if (clickOnDataGrid1 == true && dataGridView1.Visible == true && dataGridView1.Enabled == true)
            {
                dataToChargeData = dataGridView1;
            }
            else if (clickOnDataGrid1 == true && dataGridView1.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid1 == true && dataGridView1.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Visible == true && dataGridView2.Enabled == true)
            {
                dataToChargeData = dataGridView2;
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid2 == true && dataGridView2.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Visible == true && dataGridView3.Enabled == true)
            {
                dataToChargeData = dataGridView3;
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid3 == true && dataGridView3.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Visible == true && dataGridView4.Enabled == true)
            {
                dataToChargeData = dataGridView4;
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Visible == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO ES VISIBLE, HAZLA VISIBLE");
            }
            else if (clickOnDataGrid4 == true && dataGridView4.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
            }

            return dataToChargeData;
        }

        private void dataGridviewToWhite(DataGridView dataToChargeData)
        {

            for (int row = 0; row < dataToChargeData.Rows.Count - 1; row++)
            {
                for (int column = 0; column < dataToChargeData.Columns.Count; column++)
                {
                    dataToChargeData.Rows[row].Cells[column].Style.BackColor = Color.White;
                }
            }
        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tableLayoutPanel1.RowStyles[0] = new RowStyle(SizeType.Percent, 50);
                tableLayoutPanel1.RowStyles[1] = new RowStyle(SizeType.Percent, 50);
            }
            if (e.Button == MouseButtons.Right)
            {
                tableLayoutPanel1.RowStyles[0] = new RowStyle(SizeType.Percent, 86);
                tableLayoutPanel1.RowStyles[1] = new RowStyle(SizeType.Percent, 13);
            }
            baseResizeDatasGridView();
        }

    }
}
