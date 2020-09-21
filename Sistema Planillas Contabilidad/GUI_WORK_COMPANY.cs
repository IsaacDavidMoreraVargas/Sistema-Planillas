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
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        //string[] avoidData = { "INDEX", "CEDULA", "NOMBRE", "APELLIDO", "ORD DIU", "EXT DIU", "ORD NOC", "EXT NOC", "PRE HOR", "TOT ORD", "TOT EXT", "TOTAL SALAR" };
        string[] avoidData;
        //string path = "";
        string company = "";
        string deparment = "";
        string month = "";
        //string week = "";
        //string file = "";
        int rowNumber = 0;
        int indexColumnOfDatagrid = 0;
        int indexRowOfDatagrid = 0;

        //string separator1 = "-----------";
        string separator2 = "+++++++++++";

        bool clickOnDataGrid1 = false;
        bool clickOnCellDataGrid1 = false;
        bool clickOnDataGrid2 = false;
        bool clickOnCellDataGrid2 = false;
        bool clickOnDataGrid3 = false;
        bool clickOnCellDataGrid3 = false;
        bool clickOnDataGrid4 = false;
        bool clickOnCellDataGrid4 = false;
        bool clickOnDataGrid5 = false;
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
        //generalMethods callToGeneralMethods = new generalMethods();

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
            createColumnsListView();
            sumTheCellsofAll();
            //startChargeData();
            //calculateFormula();
        }

        private void setHeadsOfDataGridView()
        {
            buttonBackTotal.Enabled = false;
            buttonNextTotal.Enabled = false;
            dataGridView1.Columns.Clear();
            /*
            //
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            dataGridView3.Enabled = false;
            dataGridView4.Enabled = false;
            //
            dataGridView1.Visible= false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            //
            */
            comboBox1.Text = threeLine;
            comboBox2.Text = threeLine;
            //
            string pathToReadData = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month;
            string[] storagePaths = Directory.GetFiles(pathToReadData);
            foreach (string path in storagePaths)
            {
                if (path.Contains("1-7"))
                {
                    //dataGridView1.Enabled=true;
                    //dataGridView1.Visible = true;

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
                    //dataGridView2.Enabled = true;
                    //dataGridView2.Visible = true;

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
                    //dataGridView3.Enabled = true;
                    //dataGridView3.Visible = true;

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
                    //dataGridView4.Enabled = true;
                    //dataGridView4.Visible = true;

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
                                    dataGridView5.Rows.Add(indexOfLine.ToString());
                                    for (int column = 0; column < dataGridView5.Columns.Count; column++)
                                    {
                                        dataGridView5.Rows[indexOfLine].Cells[column].Value = storageLines[line];
                                        ++line;
                                    }
                                }

                            }
                            break;
                        }
                        else if (storageLines[head] != tagStartHEad)
                        {
                            dataGridView5.Columns.Add(storageLines[head], storageLines[head]);
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
            }

            if (totalExist == false)
            {
                string pathTemplate = SpecificPathOfFolderConfigurationTemplates;
                string[] storageTemplateFiles = Directory.GetFiles(pathTemplate);
                {
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
                            }
                        }
                    }
                }
            }

            /*
            if (dataGridView1.Visible==true)
            {
                checkedListBox1.Items.Add("1-7", CheckState.Unchecked);
                comboBox1.Items.Add("SEMANA 1");
            }
            if (dataGridView2.Visible == true)
            {
                checkedListBox1.Items.Add("8-14", CheckState.Unchecked);
                comboBox1.Items.Add("SEMANA 2");
            }
            if (dataGridView3.Visible == true)
            {
                checkedListBox1.Items.Add("15-21", CheckState.Unchecked);
                comboBox1.Items.Add("SEMANA 3");
            }
            if (dataGridView4.Visible == true)
            {
                checkedListBox1.Items.Add("22-30", CheckState.Unchecked);
                comboBox1.Items.Add("SEMANA 4");
            }
            */
            checkedListBox1.Items.Add("1-7", CheckState.Unchecked);
            checkedListBox1.Items.Add("8-14", CheckState.Unchecked);
            checkedListBox1.Items.Add("15-21", CheckState.Unchecked);
            checkedListBox1.Items.Add("22-30", CheckState.Unchecked);
            comboBox1.Items.Add("SEMANA 1");
            comboBox1.Items.Add("SEMANA 2");
            comboBox1.Items.Add("SEMANA 3");
            comboBox1.Items.Add("SEMANA 4");

            baseResizeDatasGridViewPhase1();
        }

        private void baseResizeDatasGridViewPhase1()
        {
            resizeDataGrid1();
            resizeDataGrid2();
            resizeDataGrid3();
            resizeDataGrid4();
            //methodToHideUnhideDataGridView();
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
                int sizeHeight = dataGridView1.ColumnHeadersHeight;
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
                int sizeHeight = dataGridView2.ColumnHeadersHeight;
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
                int sizeHeight = dataGridView3.ColumnHeadersHeight;
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
                int sizeHeight = dataGridView4.ColumnHeadersHeight;
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
            generalDataAndAvoidData callToAvoid = new generalDataAndAvoidData();
            for (int dataGrid = 0; dataGrid < listOFDataGridView.Count; dataGrid++)
            {
                DataGridView dataGridStudy = listOFDataGridView[dataGrid];
                for (int column = 0; column < dataGridStudy.Columns.Count; column++)
                {
                    double sum = 0;
                    bool falseMenssaje = false;
                    bool answer = callToAvoid.avoidColumns(dataGridStudy.Columns[column].HeaderText);
                    if (answer == true)
                    {
                        falseMenssaje = true;
                    }
                    else
                    {
                        if (dataGridStudy.Columns[column].HeaderCell.Style.BackColor == Color.LightCoral)
                        {
                            sum += 0;
                        }
                        else if (dataGridStudy.Columns[column].HeaderCell.Style.BackColor == Color.LightGray)
                        {
                            for (int row = 0; row < dataGridStudy.Rows.Count; row++)
                            {
                                if (dataGridStudy.Rows[row].Cells[column].Value == null || dataGridStudy.Rows[row].Cells[column].Value.ToString() == " " || dataGridStudy.Rows[row].Cells[column].Value.ToString() == "")
                                {
                                    sum += 0;
                                }
                                else
                                {
                                    try
                                    {
                                        sum += Convert.ToDouble(dataGridStudy.Rows[row].Cells[column].Value.ToString());
                                    }
                                    catch (Exception) { falseMenssaje = true; }
                                }
                            }
                        }
                        if (listOFDataGridView.Count >= 1)
                        {
                            for (int dataGridPhase2 = 1; dataGridPhase2 < listOFDataGridView.Count; dataGridPhase2++)
                            {
                                DataGridView dataGridStudyPhase2 = listOFDataGridView[dataGridPhase2];
                                for (int columnPhase2 = 0; columnPhase2 < dataGridStudyPhase2.Columns.Count; columnPhase2++)
                                {
                                    if (dataGridStudyPhase2.Columns[columnPhase2].HeaderCell.Style.BackColor == Color.LightCoral)
                                    {
                                        sum += 0;
                                    }
                                    else if (dataGridStudyPhase2.Columns[columnPhase2].HeaderCell.Style.BackColor == Color.LightGray)
                                    {
                                        if (dataGridStudyPhase2.Columns[columnPhase2].HeaderText == dataGridStudy.Columns[column].HeaderText)
                                        {
                                            for (int rowPhase2 = 0; rowPhase2 < dataGridStudyPhase2.Rows.Count; rowPhase2++)
                                            {
                                                if (dataGridStudyPhase2.Rows[rowPhase2].Cells[columnPhase2].Value == null || dataGridStudyPhase2.Rows[rowPhase2].Cells[columnPhase2].Value.ToString() == " " || dataGridStudyPhase2.Rows[rowPhase2].Cells[columnPhase2].Value.ToString() == "")
                                                {
                                                    sum += 0;
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        sum += Convert.ToDouble(dataGridStudyPhase2.Rows[rowPhase2].Cells[columnPhase2].Value.ToString());
                                                    }
                                                    catch (Exception) { falseMenssaje = true; }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    for (int columnPhase3 = 0; columnPhase3 < dataGridView5.Columns.Count; columnPhase3++)
                    {
                        if (dataGridView5.Columns[columnPhase3].HeaderText == dataGridStudy.Columns[column].HeaderText)
                        {
                            if (falseMenssaje == true)
                            {
                                dataGridView5.Rows[0].Cells[columnPhase3].Value = "FALSE";
                            }
                            else
                            {
                                dataGridView5.Rows[0].Cells[columnPhase3].Value = sum.ToString();
                            }
                            break;
                        }
                    }
                }
                break;
            }
        }

        

        
        private void createColumnsListView()
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
                            int index = dataToChargeData.Rows.Count - 1;
                            dataToChargeData.Rows.Add(index.ToString());
                            for (int colum = 1; colum < dataToChargeData.Columns.Count; colum++)
                            {
                                string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + dataToChargeData.Columns[colum].HeaderText + " \n-S/F PARA SALIR:");
                                data = data.ToUpper();
                                if (data == "S/F")
                                {
                                    break;
                                }
                                else
                                {
                                    dataToChargeData.Rows[index].Cells[colum].Value = data;
                                }
                            }
                            baseResizeDatasGridViewPhase1();
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
                                    break;
                                }
                            }
                            break;
                        case DialogResult.No:
                            answer = MessageBox.Show("¿DESEA IR A LA ULTIMA CELDA EN BLANCO QUE ENCUENTRE?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                            switch (answer)
                            {
                                case DialogResult.Yes:
                                    outFromHere = false;
                                    for (int row = dataToChargeData.Rows.Count-2; row > 0; row--)
                                    {
                                        for (int colum = dataToChargeData.Columns.Count-1; colum > 0; colum--)
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
                                                break;
                                            }
                                        }
                                        if (outFromHere == true)
                                        {
                                            break;
                                        }
                                    }

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
            else if ( dataToChargeData.Enabled == false)
            {
                MessageBox.Show("NO PUEDES INTRODUCIR DATOS PORQUE LA TABLA NO PERMITE CALCULOS, HAZLA CALCULAR");
                allowEnterData = false;
            }

            if (allowEnterData == true)
            {
                string data = Microsoft.VisualBasic.Interaction.InputBox("DAME EL NOMBRE DE LA COLUMNA:");
                data = data.ToUpper();
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
                    baseResizeDatasGridViewPhase1();
                }
                else
                {
                    dataToChargeData.Columns.Add(data, data);
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
                    baseResizeDatasGridViewPhase1();
                }
                else
                {
                    dataToChargeData.Rows.Add(dataToChargeData.Rows.Count.ToString());
                }

                
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
                    }
                }
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ESTAS AL INICIO");
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
            if (indexColumnOfDatagrid < dataToChargeData.Columns.Count-1)
            {
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
                    }
                }
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
            }
        }

        private void buttonMoveUpArrow_Click(object sender, EventArgs e)
        {
            if (indexRowOfDatagrid > 0)
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
                        for (int row = 0; row < dataToChargeData.Rows.Count-1; row++)
                        {
                            dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                        }
                        --indexRowOfDatagrid;
                        paintRow(dataToChargeData, indexRowOfDatagrid);
                        dataToChargeData.FirstDisplayedScrollingRowIndex = scrollPositionV;
                        dataToChargeData.FirstDisplayedScrollingColumnIndex = scrollPositionH;
                    }
                }
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ESTAS AL INICIO");
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

            if (indexRowOfDatagrid < dataToChargeData.Rows.Count-2)
            {
                if (allowEnterData == true)
                {
                    if (clickOnCellDataGrid1 == true || clickOnCellDataGrid2 == true || clickOnCellDataGrid3 == true || clickOnCellDataGrid4 == true || clickOnCellDataGrid5 == true)
                    {
                        int scrollPositionV = dataToChargeData.FirstDisplayedScrollingRowIndex;
                        int scrollPositionH = dataToChargeData.FirstDisplayedScrollingColumnIndex;
                        List<string> listSalmon = new List<string>();
                        foreach(DataGridViewColumn column in dataToChargeData.Columns)
                        {
                            if(column.HeaderCell.Style.BackColor==Color.LightSalmon)
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
                            foreach(string compare in listSalmon)
                            {
                                if(compare== arrayAnswer[0, column])
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
                            else if(found == false)
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
                    }
                }
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
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
                if (File.Exists(path))
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
                for (int row = 0; row < dataGridView5.Rows.Count; row++)
                {
                    sumString += tagStartLine + "?";
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
                    sumString += tagEndLine + "?";
                }
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
                dataGridviewToWhite(dataToChargeData);
                dataToChargeData.Columns.RemoveAt(indexColumnOfDatagrid);
                paintColum(dataToChargeData, indexColumnOfDatagrid);
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
                dataGridviewToWhite(dataToChargeData);
                dataToChargeData.Rows.RemoveAt(indexRowOfDatagrid);
                for(int row=0; row<dataToChargeData.Rows.Count-1; row++)
                {
                    dataToChargeData.Rows[row].Cells[0].Value = row.ToString();
                }
                paintRow(dataToChargeData, indexRowOfDatagrid);
            }
        }

        private void buttonCalculateTotals_Click(object sender, EventArgs e)
        {
            /*
            using (GUI_ELEGIR_GENERAR_TOTALES form2 = new GUI_ELEGIR_GENERAR_TOTALES())
            {
                int maximunRowsS = dataGridView1.RowCount;
                //++maximunRowsS;
                int maximunColumsS = dataGridView1.ColumnCount;
                string[,] storageDataArray = new string[maximunColumsS,maximunRowsS];
                for (int rows = 0; rows < maximunRowsS; rows++)
                {
                    if (rows == 0)
                    {
                        for (int columns = 0; columns < maximunColumsS; columns++)
                        {
                            storageDataArray[columns, rows] = dataGridView1.Columns[columns].HeaderText.ToString();
                        }
                        int keepIndex = 0;
                        ++keepIndex;
                        for (int columns = 0; columns < maximunColumsS; columns++)
                        {
                            storageDataArray[columns, keepIndex] = dataGridView1.Rows[rows].Cells[columns].Value.ToString();
                        }
                    }
                    else
                    {
                        int keepIndex = rows;
                        ++keepIndex;
                        if (keepIndex >= maximunRowsS)
                        {

                        }
                        else
                        {
                            for (int columns = 0; columns < maximunColumsS; columns++)
                            {
                                if (dataGridView1.Rows[rows].Cells[columns].Value == null)
                                {
                                    storageDataArray[columns, rows] = " ";
                                }
                                else
                                {
                                    storageDataArray[columns, keepIndex] = dataGridView1.Rows[rows].Cells[columns].Value.ToString();
                                }

                            }
                        }
                    }
                }
                string actual = Directory.GetCurrentDirectory();
                actual = actual.Replace("\\bin\\Debug", "\\Companies");
                company = company.Replace(" ","_");
                string actualPath = actual + "\\" + company + "\\configuration\\totales.txt";
                if (File.Exists(actualPath))
                {
                    List<string> listSendData1 = new List<string>();
                    int maximunColums = dataGridView1.Columns.Count;
                    for (int colum = 1; colum < maximunColums; colum++)
                    {
                        listSendData1.Add(dataGridView1.Columns[colum].HeaderText.ToString());
                    }
                    string[] storageData = File.ReadAllLines(actualPath);
                    List<string> listSendData2 = new List<string>();
                    for (int data = 0; data < storageData.Length; data++)
                    {
                        listSendData2.Add(storageData[data]);
                    }
                    form2.PathToSave(company, deparment,month,week, file);
                    form2.recevivedArray(storageDataArray);
                    form2.receiveListYes(listSendData1, listSendData2,true);
                    if (form2.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        File.Delete(actualPath);
                        List<string> listSave = form2.listR;
                        FileStream fs = new FileStream(actualPath, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        foreach (string line in listSave)
                        {
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }
                }
                else 
                {
                    //MessageBox.Show("2");
                    int maximunColums = dataGridView1.Columns.Count;
                    List<string> listSendData = new List<string>();
                    for (int colum = 1; colum < maximunColums; colum++)
                    {
                        listSendData.Add(dataGridView1.Columns[colum].HeaderText.ToString());
                    }
                    form2.PathToSave(company, deparment, month, week, file);
                    form2.recevivedArray(storageDataArray);
                    form2.receiveListNot(listSendData,false);
                    if (form2.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<string>  listSave = form2.listR;
                        FileStream fs = new FileStream(actualPath, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);
                        foreach (string line in listSave)
                        {
                            writer.WriteLine(line);
                        }
                        writer.Close();
                    }
                }

            }
            */
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


        public void PathToCompany(string companyReceive, string deptReceive, string monthReceive, string pathReceive)
        {
            company = companyReceive;
            deparment = deptReceive;
            month = monthReceive;
        }

        public void recieveListColumn(List<string> listReceived, string head)
        {
            List<string> listReceive = new List<string>();
            listReceive = listReceived;
            string headReceived = head;
            int maximunColums = dataGridView1.Columns.Count;
            int indexFound = 0;

            bool found = false;
            for (int addCol = 0; addCol < maximunColums; addCol++)
            {
                string find = dataGridView1.Columns[addCol].HeaderText;
                //string find = evaluate.ToString();
                if (find == headReceived)
                {
                    indexFound = addCol;
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                ++maximunColums;
                dataGridView1.Columns.Add(alphabet[maximunColums], alphabet[maximunColums]);
                int indexAdd = 0;
                int minimunRows = dataGridView1.Rows.Count;
                --minimunRows;
                int maximunRows = listReceive.Count;
                ++maximunRows;
                if (minimunRows < maximunRows)
                {
                    for (int addRow = minimunRows; addRow < maximunRows; addRow++)
                    {
                        dataGridView1.Rows.Add(addRow.ToString());
                    }
                }

                maximunRows = dataGridView1.Rows.Count;
                --maximunRows;
                int cells = dataGridView1.Columns.Count;
                for (int rows = 1; rows < maximunRows; rows++)
                {
                    for (int cell = 1; cell < cells; cell++)
                    {
                        if (dataGridView1.Rows[rows].Cells[cell].Value == null)
                        {
                            dataGridView1.Rows[rows].Cells[cell].Value = " ";
                        }
                    }
                }

                int pointAdd = cells;
                --pointAdd;
                ++cells;//raisign the amount of cells to coinciding with the colum number
                for (int rows = 1; rows < maximunRows; rows++)
                {
                    for (int cell = 1; cell < cells; cell++)
                    {
                        if (cell == maximunColums)
                        {
                            dataGridView1.Rows[0].Cells[pointAdd].Value = headReceived;
                            dataGridView1.Rows[rows].Cells[pointAdd].Value = listReceive[indexAdd];
                            ++indexAdd;
                            break;
                        }

                    }

                }
            }
            else
            {
                int minimunRows = dataGridView1.Rows.Count;
                int maximunRows = listReceive.Count;
                if (minimunRows < maximunRows)
                {
                    for (int addRow = minimunRows; addRow < maximunRows; addRow++)
                    {
                        dataGridView1.Rows.Add(addRow.ToString());
                    }
                }

                int cells = dataGridView1.Columns.Count;
                maximunRows = dataGridView1.Rows.Count;
                --maximunRows;
                for (int rows = 0; rows < maximunRows; rows++)
                {
                    for (int cell = 1; cell < cells; cell++)
                    {
                        if (dataGridView1.Rows[rows].Cells[cell].Value == null)
                        {
                            dataGridView1.Rows[rows].Cells[cell].Value = " ";
                        }
                    }
                }
                int indexAdd = 0;
                for (int rows = 0; rows < maximunRows; rows++)
                {
                    for (int cell = 1; cell < cells; cell++)
                    {
                        if (cell == indexFound)
                        {
                            dataGridView1.Rows[rows].Cells[cell].Value = listReceive[indexAdd];
                            ++indexAdd;
                            break;
                        }

                    }

                }
            }

        }

        public void recieveListRow(List<string> listReceived, string head)
        {
            List<string> listReceive = new List<string>();
            listReceive = listReceived;
            int maximunColums = dataGridView1.Columns.Count;
            int maximuRows = dataGridView1.Rows.Count;

            if (head == "NUEVA FILA")
            {
                --maximunColums;
                dataGridView1.Rows.Add(maximuRows.ToString());
                int sizeList = listReceive.Count;
                if (sizeList > maximunColums)
                {
                    for (int addCol = maximunColums; addCol < sizeList; addCol++)
                    {
                        dataGridView1.Columns.Add(alphabet[addCol], alphabet[addCol]);
                    }
                }
                int headIndex = dataGridView1.Rows.Count;
                --headIndex;
                --headIndex;
                int index = 0;
                maximunColums = dataGridView1.Columns.Count;
                for (int rows = 0; rows < maximuRows; rows++)
                {
                    if (rows == headIndex)
                    {
                        for (int cell = 1; cell < sizeList; cell++)
                        {
                            dataGridView1.Rows[rows].Cells[cell].Value = listReceive[index];
                            ++index;
                        }
                        int start = listReceive.Count;
                        ++start;
                        for (int cell = start; cell < maximunColums; cell++)
                        {
                            dataGridView1.Rows[rows].Cells[cell].Value = " ";
                        }
                        break;
                    }
                }
                MessageBox.Show("IMPORTADO EXITOSAMENTE");
            }
            else
            {
                int sizeList = listReceive.Count;
                if (sizeList > maximunColums)
                {
                    --maximunColums;
                    for (int addCol = maximunColums; addCol < sizeList; addCol++)
                    {
                        dataGridView1.Columns.Add(alphabet[addCol], alphabet[addCol]);
                    }
                }

                int indexFound = Int32.Parse(head);
                //--indexFound;
                --maximuRows;
                int maximunCells = dataGridView1.Columns.Count;
                int index = 0;
                for (int row = 0; row < maximuRows; row++)
                {
                    if (indexFound == row)
                    {
                        for (int cells = 1; cells < listReceive.Count; cells++)
                        {
                            dataGridView1.Rows[row].Cells[cells].Value = listReceive[index];
                            ++index;
                        }
                        int start = listReceive.Count;
                        ++start;
                        for (int cells = start; cells < maximunCells; cells++)
                        {
                            dataGridView1.Rows[row].Cells[cells].Value = " ";
                        }
                        break;
                    }
                }
                MessageBox.Show("IMPORTADO EXITOSAMENTE");
            }
        }

        private void buttonReturnScreen_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //GUI_ELEGIR__TRABAJAR_EMPRESA callingChooseWork = new GUI_ELEGIR__TRABAJAR_EMPRESA();
            //callingChooseWork.ShowDialog();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            //methodToSave("!ALERT");
            this.Close();
        }



        private void buttonImportDataColumn_Click(object sender, EventArgs e)
        {

            //setDataAndSend2();
            using (GUI_ELEGIR_COPIAR_COLUMNA form2 = new GUI_ELEGIR_COPIAR_COLUMNA())
            {
                //form2.PathToSave(path);
                string sendData = "";
                int maximunColum = dataGridView1.Columns.Count;
                for (int colum = 0; colum < maximunColum; colum++)
                {
                    sendData += dataGridView1.Columns[colum].HeaderText.ToString() + "\n";
                }
                form2.dataToSave(sendData);
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    List<string> listSave = form2.listR;
                    string hedSave = form2.Head;
                    recieveListColumn(listSave, hedSave);
                    setDataAndSend();
                }
            }


        }

        private void buttonImportDataArrow_Click(object sender, EventArgs e)
        {
            //setDataAndSend2();
            using (GUI_ELEGIR_COPIAR_FILA form2 = new GUI_ELEGIR_COPIAR_FILA())
            {
                //form2.PathToSave(path);
                string sendData = "";
                int maximunRow = dataGridView1.RowCount;
                --maximunRow;
                for (int row = 0; row < maximunRow; row++)
                {
                    sendData += dataGridView1.Rows[row].Cells[0].Value.ToString() + "\n";
                }
                form2.dataToSave(sendData);

                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    List<string> listSave = form2.listR;
                    string hedSave = form2.Head;
                    recieveListRow(listSave, hedSave);
                    setDataAndSend();
                }
            }
        }
        List<string[,]> saveDataGrinOnTime = new List<string[,]>();
        int indexSaveDataGrinOnTime = 0;

        private void buttonBackTotal_Click_1(object sender, EventArgs e)
        {
            if (indexSaveDataGrinOnTime <= 0)
            {
                MessageBox.Show("ES EL INICIO");
                indexSaveDataGrinOnTime = 0;
                buttonBackTotal.Enabled = false;
            }
            else
            {
                --indexSaveDataGrinOnTime;
                //--indexSaveDataGrinOnTime;
                getDataAndSend(indexSaveDataGrinOnTime);
                buttonNextTotal.Enabled = true;
            }
        }

        private void buttonNextTotal_Click(object sender, EventArgs e)
        {
            int end = saveDataGrinOnTime.Count;
            --end;
            if (indexSaveDataGrinOnTime >= end)
            {
                MessageBox.Show("ES EL FIN");
                indexSaveDataGrinOnTime = end;
                buttonNextTotal.Enabled = false;
            }
            else
            {
                buttonBackTotal.Enabled = true;
                ++indexSaveDataGrinOnTime;
                //++indexSaveDataGrinOnTime;
                getDataAndSend(indexSaveDataGrinOnTime);
            }
        }

        private void setDataAndSend()
        {
            buttonBackTotal.Enabled = true;
            buttonNextTotal.Enabled = true;
            //++indexSaveDataGrinOnTime;
            int maximunRows = dataGridView1.Rows.Count;
            int maximunColum = dataGridView1.Columns.Count;
            string[,] getData = new string[maximunRows, maximunColum];
            for (int rows = 0; rows < maximunRows; rows++)
            {
                if (rows == 0)
                {
                    for (int cell = 1; cell < maximunColum; cell++)
                    {
                        getData[rows, cell] = dataGridView1.Columns[cell].HeaderText.ToString();
                    }
                }
                else
                {
                    for (int cell = 1; cell < maximunColum; cell++)
                    {
                        if (dataGridView1.Rows[rows].Cells[cell].Value == null)
                        {
                            getData[rows, cell] = " ";
                        }
                        else
                        {
                            getData[rows, cell] = dataGridView1.Rows[rows].Cells[cell].Value.ToString();
                        }
                    }
                }

            }
            bool foundArray = false;

            foreach (string[,] item in saveDataGrinOnTime)
            {
                if (item == getData)
                {
                    foundArray = true;
                    break;
                }
            }

            if (foundArray == false)
            {
                ++indexSaveDataGrinOnTime;
                saveDataGrinOnTime.Add(getData);
            }

        }

        private void getDataAndSend(int indexSaveDataGrinOnTime)
        {
            string[,] getData = saveDataGrinOnTime[indexSaveDataGrinOnTime];
            int maximunListRows = getData.GetLength(0);
            int maximunListColums = getData.GetLength(1);
            int maximunActualRows = dataGridView1.Rows.Count;
            --maximunActualRows;
            int maximunActualColums = dataGridView1.Columns.Count;
            //--maximunActualColums;
            int indexAlphabet = 0;

            if (maximunActualColums > maximunListColums)
            {
                for (int colum = maximunListColums; colum < maximunActualColums; colum++)
                {
                    dataGridView1.Columns.RemoveAt(colum);
                }
            }
            else if (maximunActualColums < maximunListColums)
            {
                for (int colum = maximunActualColums; colum < maximunListColums; colum++)
                {
                    if (colum > alphabet.Length)
                    {
                        string addLetter = alphabet[indexAlphabet] + alphabet[indexAlphabet++];
                        dataGridView1.Columns.Add(addLetter, addLetter);
                    }
                    else
                    {
                        dataGridView1.Columns.Add(alphabet[colum], alphabet[colum]);
                    }

                }
            }

            --maximunListRows;
            if (maximunActualRows > maximunListRows)
            {
                for (int row = maximunListRows; row < maximunActualRows; row++)
                {
                    dataGridView1.Rows.RemoveAt(row);
                }
            }
            else if (maximunActualRows < maximunListRows)
            {
                for (int row = maximunActualRows; row < maximunListRows; row++)
                {
                    dataGridView1.Rows.Add(row.ToString());
                }
            }

            for (int rows = 0; rows < maximunListRows; rows++)
            {
                if (rows == 0)
                {
                    for (int cell = 1; cell < maximunListColums; cell++)
                    {
                        dataGridView1.Columns[cell].HeaderText = getData[rows, cell];
                    }
                }
                else
                {
                    for (int cell = 1; cell < maximunListColums; cell++)
                    {
                        dataGridView1.Rows[rows].Cells[cell].Value = getData[rows, cell];
                    }
                }
            }
        }

        private void buttonGenerateFormula_Click(object sender, EventArgs e)
        {
            //this.Hide();
            List<string> listOfHeads = new List<string>();
            foreach(DataGridViewColumn column in dataGridView5.Columns)
            {
                listOfHeads.Add(column.HeaderText);
            }
            GUI_CREATE_FORMULA callingCreateFormula = new GUI_CREATE_FORMULA();
            callingCreateFormula.MethodToReceivedAccesToObject(startThePaths, startTheTagsAndDefaults, startFoldersInsideCompany);
            callingCreateFormula.lisftOfHeads(listOfHeads);
            callingCreateFormula.PathToCompany(company, deparment, month);
            callingCreateFormula.menuGlobalOrLocal("LOCAL");
            callingCreateFormula.ShowDialog();
            //this.Show();
        }

        private void calculateFormula()
        {
            string actual = Directory.GetCurrentDirectory();
            actual = actual.Replace("\\bin\\Debug", "\\configuration");
            string actualPath = actual + "\\Formulas\\formula.txt";
            finalCalculate(actualPath);

            actual = Directory.GetCurrentDirectory();
            actual = actual.Replace("\\bin\\Debug", "\\Companies");
            actualPath = actual + "\\" + company + "\\configuration\\formula.txt";
            finalCalculate(actualPath);

        }

        private void finalCalculate(string actualPath)
        {
            if (File.Exists(actualPath))
            {
                string[] lines = File.ReadAllLines(actualPath);
                //int chance = 0;
                string target = "";
                for (int line = 0; line < lines.Length; line++)
                {
                    if (lines[line] == "=")
                    {
                        //++chance;
                        target = lines[--line];
                        ++line;
                        ++line;
                        int numberSpaces = 0;
                        for (int line2 = line; line2 < lines.Length; line2++)
                        {
                            if (lines[line2] == separator2)
                            {
                                break;
                            }
                            else
                            {
                                ++numberSpaces;
                            }
                        }
                        string[] storageRow = new string[numberSpaces];
                        int index = 0;
                        for (int line2 = line; line2 < lines.Length; line2++)
                        {
                            if (lines[line2] == separator2)
                            {
                                break;
                            }
                            else if (lines[line2] == " ")
                            {

                            }
                            else
                            {
                                storageRow[index] = lines[line2];
                                ++index;
                            }
                        }
                        string[] storageReplace = new string[storageRow.Length];
                        int maximunColumns = dataGridView1.Columns.Count;
                        int maximunRows = dataGridView1.Rows.Count;
                        --maximunRows;

                        for (int row = 0; row < maximunRows; row++)
                        {
                            storageRow.CopyTo(storageReplace, 0);
                            for (int storage = 0; storage < storageRow.Length; storage++)
                            {
                                for (int column = 0; column < maximunColumns; column++)
                                {
                                    if (dataGridView1.Columns[column].HeaderText == storageRow[storage])
                                    {
                                        if (dataGridView1.Rows[row].Cells[column].Value == null)
                                        {
                                            storageReplace[storage] = " ";
                                        }
                                        else
                                        {
                                            string change = dataGridView1.Rows[row].Cells[column].Value.ToString();
                                            if (change.Length > 3)
                                            {
                                                change = change.Replace(".", "");
                                            }
                                            if (change.Length <= 3)
                                            {
                                                change = change.Replace(".", ",");
                                            }
                                            storageReplace[storage] = change;
                                        }

                                    }
                                }
                            }
                            try
                            {
                                calculateSystem callingCalculate = new calculateSystem();
                                //decimal numberReceveived = callingCalculate.recieveArray(storageReplace);
                                //string change = numberReceveived.ToString();
                                string change = callingCalculate.recieveArray(storageReplace);
                                //string sendData = callingCalculate.convertAndFormatLong(change.ToString());
                                string sendData = change.ToString();
                                sendData = Regex.Replace(sendData, @"\p{C}+", string.Empty);
                                string returnsendData = callingCalculate.correctString(sendData);
                                if (returnsendData != "false")
                                {
                                    sendData = returnsendData;
                                }
                                for (int column = 0; column < maximunColumns; column++)
                                {
                                    if (dataGridView1.Columns[column].HeaderText == target)
                                    {
                                        string evaluate = "";
                                        if (dataGridView1.Rows[row].Cells[column].Value == null)
                                        {
                                            evaluate = " ";
                                        }
                                        else
                                        {
                                            evaluate = dataGridView1.Rows[row].Cells[column].Value.ToString();
                                        }

                                        evaluate = evaluate.Replace(" ", "");
                                        evaluate = evaluate.ToUpper();
                                        if (evaluate == "NO")
                                        {
                                            //DO NOTHING
                                        }
                                        {
                                            //REPLACE
                                            bool found = false;
                                            string nameHead = dataGridView1.Columns[column].HeaderText;
                                            string[] splitNameHead = nameHead.Split(' ');
                                            foreach (string item in splitNameHead)
                                            {
                                                if (item == "TOT")
                                                {
                                                    found = true;
                                                    break;
                                                }
                                            }
                                            if (found == true)
                                            {
                                                //sendData = callingCalculate.convertAndFormatSHORT(sendData);
                                            }
                                            else
                                            {
                                                sendData = callingCalculate.convertAndFormatLONG(sendData);
                                            }
                                            dataGridView1.Rows[row].Cells[column].Value = sendData;
                                            break;
                                        }

                                    }
                                }
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }
            }
        }

        private void buttonRecalculate_Click(object sender, EventArgs e)
        {
            sumTheCellsofAll();
            /*
            try
            {
                calculateFormula();
            } catch (Exception)
            {
                MessageBox.Show("SUCEDIO ALGUN PROBLEMA RECALCULANDO LAS FORMULAS");
            }
            */
        }

        private void CellRecalculateFinish(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int x = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
                int y = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
                string convert = "";
                if (dataGridView1.Rows[x].Cells[y].Value == null)
                {
                    convert = " ";
                } else
                {
                    convert = dataGridView1.Rows[x].Cells[y].Value.ToString();
                }
                if (convert.Contains("/") || convert.Contains("+") || convert.Contains("-") || convert.Contains("*"))
                {
                    string storage = "";
                    foreach (char item in convert)
                    {
                        if (item == '/' || item == '+' || item == '-' || item == '*')
                        {
                            storage += "\n" + item + "\n";
                        }
                        else
                        {
                            storage += item;
                        }
                    }
                    string[] storageData = storage.Split('\n');
                    calculateSystem callingCalculate = new calculateSystem();
                    //decimal numberReceveived = callingCalculate.recieveArray(storageData);
                    //string sendData = callingCalculate.convertAndFormat(numberReceveived.ToString());
                    //decimal numberReceveived = callingCalculate.recieveArray(storageData);
                    //string sendData = numberReceveived.ToString();
                    string sendData = callingCalculate.recieveArray(storageData);
                    dataGridView1.Rows[x].Cells[y].Value = sendData;
                }
            }
            catch (Exception)
            { }
        }

        private void GUI_WORK_COMPANY_Resize(object sender, EventArgs e)
        {
            baseResizeDatasGridViewPhase1();
        }

        string orderDatagrid = "";
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            checkedListBox2.Items.Clear();
            //methodToHideUnhideDataGridView();
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
                DataToStudy.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn column in DataToStudy.Columns)
                {
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                }
                checkedListBox2.Items.Add("TAREA COMPLETA", CheckState.Checked);
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
                            DataToStudy.EnableHeadersVisualStyles = false;
                            foreach (DataGridViewColumn colum in DataToStudy.Columns)
                            {
                                colum.HeaderCell.Style.BackColor = Color.LightGray;
                            }
                            DataToStudy.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                            DataToStudy.Enabled = true;
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
                baseResizeDatasGridViewPhase1();
            } else if (orderDatagrid == "TODOS")
            {
                checkedListBox2.Items.Clear();
                checkedListBox1.Text = threeLine;
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
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            clickOnDataGrid1 = true;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;
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
            { MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); }
            try
            {
                indexRowOfDatagrid = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { MessageBox.Show("FILA NO SE HA SELECCIONANDO "); }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = true;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;
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
            { MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); }
            try
            {
                indexRowOfDatagrid = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { MessageBox.Show("FILA NO SE HA SELECCIONANDO "); }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = true;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = false;

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
            { MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); }
            try
            {
                indexRowOfDatagrid = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { MessageBox.Show("FILA NO SE HA SELECCIONANDO "); }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = true;
            clickOnDataGrid5 = false;
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
            { MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); }
            try
            {
                indexRowOfDatagrid = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { MessageBox.Show("FILA NO SE HA SELECCIONANDO "); }
        }

        private void dataGridView5_Click(object sender, EventArgs e)
        {
            clickOnDataGrid1 = false;
            clickOnDataGrid2 = false;
            clickOnDataGrid3 = false;
            clickOnDataGrid4 = false;
            clickOnDataGrid5 = true;
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
            { MessageBox.Show("COLUMNA NO SE HA SELECCIONANDO "); }
            try
            {
                indexRowOfDatagrid = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
            }
            catch (Exception)
            { MessageBox.Show("FILA NO SE HA SELECCIONANDO "); }
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
    }
}
