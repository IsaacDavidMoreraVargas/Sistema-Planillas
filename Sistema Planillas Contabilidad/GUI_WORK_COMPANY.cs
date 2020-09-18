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
        string path = "";
        string company = "";
        string deparment = "";
        string month = "";
        //string week = "";
        //string file = "";
        int rowNumber = 0;
        int locationCell = 0;
        int locationRow = 0;
        bool AllowedUpdateAction = false;
        string separator1 = "-----------";
        string separator2 = "+++++++++++";
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
        string configuration = "";
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
        generalMethods callToGeneralMethods = new generalMethods();

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
            configuration = startFoldersInsideCompany.isConfiguration;
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
            comboBox1.Text = threeLine;
            comboBox2.Text = threeLine;
            //
            string pathToReadData = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month;
            string[] storagePaths = Directory.GetFiles(pathToReadData);
            foreach (string path in storagePaths)
            {
                if (path.Contains("1-7"))
                {
                    dataGridView1.Enabled=true;
                    dataGridView1.Visible = true;
                   
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
                }else if (path.Contains("8-14"))
                {
                    dataGridView2.Enabled = true;
                    dataGridView2.Visible = true;
                   
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
                    dataGridView3.Enabled = true;
                    dataGridView3.Visible = true;
                    
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
                    dataGridView4.Enabled = true;
                    dataGridView4.Visible = true;
                    
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
                        }else if (storageLines[line] == tagStartDataGrid2)
                        {
                            dataGridToStudy = dataGridView2;
                        }else if (storageLines[line] == tagStartDataGrid3)
                        {
                            dataGridToStudy = dataGridView3;
                        }else if (storageLines[line] == tagStartDataGrid4)
                        {
                            dataGridToStudy = dataGridView4;
                        }

                        dataGridToStudy.EnableHeadersVisualStyles = false;
                        foreach (DataGridViewColumn column in dataGridToStudy.Columns)
                        {
                            if(column.HeaderText== storageLines[line])
                            {
                                ++line;
                                column.Visible = Convert.ToBoolean(storageLines[line]);
                                ++line;
                                if (Convert.ToBoolean(storageLines[line])==true)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightGray;
                                }else if (Convert.ToBoolean(storageLines[line]) == false)
                                {
                                    column.HeaderCell.Style.BackColor = Color.LightSalmon;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            if(configurationExist == false)
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

        private void baseResizeDatasGridViewPhase2()
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
                dataGridView1.Width = tableLayoutPanel1.Width;
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
                heigthLocation += dataGridView1.Height+10;
            }
        }

        private void resizeDataGrid2()
        {
            if (dataGridView2.Visible == true)
            {
                dataGridView2.Location = new Point(0, heigthLocation);
                dataGridView2.Width = tableLayoutPanel1.Width;
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
                heigthLocation += dataGridView2.Height+10;
            }
        }

        private void resizeDataGrid3()
        {
            if (dataGridView3.Visible == true)
            {
                dataGridView3.Location = new Point(0, heigthLocation);
                dataGridView3.Width = tableLayoutPanel1.Width;
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
                heigthLocation += dataGridView3.Height+10;
            }
        }

        private void resizeDataGrid4()
        {
            if (dataGridView4.Visible == true)
            {
                dataGridView4.Location = new Point(0, heigthLocation);
                dataGridView4.Width = tableLayoutPanel1.Width;
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

        private void methodToHideUnhideDataGridView()
        {
            for (int item = 0; item < checkedListBox1.Items.Count; item++)
            {
                if (checkedListBox1.GetItemChecked(item)==true)
                {
                    if (item == 0)
                    {
                        dataGridView1.Visible = true;
                        dataGridView1.Enabled = true;
                    }
                    else if (item == 1)
                    {
                        dataGridView2.Visible = true;
                        dataGridView2.Enabled = true;
                    }
                    else if (item == 2)
                    {
                        dataGridView3.Visible = true;
                        dataGridView3.Enabled = true;
                    }
                    else if (item == 3)
                    {
                        dataGridView4.Visible = true;
                        dataGridView4.Enabled = true;
                    }
                }else if (checkedListBox1.GetItemChecked(item) == false)
                {
                    
                    if (item == 0)
                    {
                        dataGridView1.Visible = false;
                        dataGridView1.Enabled = false;
                    }
                    else if (item == 1)
                    {
                        dataGridView2.Visible = false;
                        dataGridView2.Enabled = false;
                    }
                    else if (item == 2)
                    {
                        dataGridView3.Visible = false;
                        dataGridView3.Enabled = false;
                    }
                    else if (item == 3)
                    {
                        dataGridView4.Visible = false;
                        dataGridView4.Enabled = false;
                    }
                }
            }
            baseResizeDatasGridViewPhase2();
        }

        private void sumTheCellsofAll()
        {
            List<DataGridView> listOFDataGridView = new List<DataGridView>();
            if(dataGridView1.Enabled==true)
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
            for(int dataGrid=0; dataGrid<listOFDataGridView.Count; dataGrid++)
            {
                DataGridView dataGridStudy=listOFDataGridView[dataGrid];
                for (int column=0; column < dataGridStudy.Columns.Count; column++)
                {
                    double sum= 0;
                    bool falseMenssaje = false;
                    bool answer = callToAvoid.avoidColumns(dataGridStudy.Columns[column].HeaderText);
                    if (answer == true)
                    {
                        falseMenssaje = true;
                    }
                    else
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
                        if (listOFDataGridView.Count >= 1)
                        {
                            for (int dataGridPhase2 = 1; dataGridPhase2 < listOFDataGridView.Count; dataGridPhase2++)
                            {
                                DataGridView dataGridStudyPhase2 = listOFDataGridView[dataGridPhase2];
                                for (int columnPhase2 = 0; columnPhase2 < dataGridStudyPhase2.Columns.Count; columnPhase2++)
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

        private void dataGridviewToWhite()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int maximunCells = dataGridView1.Columns.Count;
                for (int cell = 0; cell < maximunCells; cell++)
                {
                    row.Cells[cell].Style.BackColor = Color.White;
                }
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
            dataGridviewToWhite();
            int maximunRows = dataGridView1.RowCount;
            int maximunRows2 = dataGridView1.RowCount;
            --maximunRows2;
            --maximunRows2;
            int maximunColums = dataGridView1.ColumnCount;
            int maximunColums2 = dataGridView1.ColumnCount;
            --maximunColums2;
            --maximunColums2;
            DialogResult answer = MessageBox.Show("¿IR AL FINAL?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
            switch (answer)
            {
                case DialogResult.Yes:
                    AllowedUpdateAction = true;
                    bool continueAdd = true;
                    for (int rows = 0; rows < maximunRows; rows++)
                    {
                        bool getOut = false;
                        if (rows == maximunRows2)
                        {
                            for (int cell = 1; cell < maximunColums; cell++)
                            {
                                if (cell == maximunColums2)
                                {
                                    DialogResult createRow = MessageBox.Show("¿CREAR NUEVA FILA?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                                    switch (createRow)
                                    {
                                        case DialogResult.Yes:
                                            int numberRow = dataGridView1.Rows.Count;
                                            --numberRow;
                                            --numberRow;
                                            while (continueAdd == true)
                                            {
                                                ++numberRow;
                                                dataGridView1.Rows.Add(numberRow.ToString());
                                                maximunColums2 = dataGridView1.ColumnCount;
                                                for (cell = 1; cell < maximunColums2; cell++)
                                                {
                                                    dataGridView1.Rows[numberRow].Cells[cell].Value = " ";
                                                }
                                                for (cell = 1; cell < maximunColums2; cell++)
                                                {
                                                    //string UpperHead = dataGridView1.Rows[0].Cells[cell].Value.ToString();
                                                    string UpperHead = dataGridView1.Columns[cell].HeaderText.ToString();
                                                    UpperHead = UpperHead.ToUpper();
                                                    dataGridviewToWhite();
                                                    dataGridView1.Rows[numberRow].Cells[cell].Style.BackColor = Color.LightGreen;
                                                    object cellToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + UpperHead + ":");
                                                    string upperData = cellToEnter.ToString();
                                                    upperData = upperData.ToUpper();
                                                    if (upperData.ToString() == "SALIR" || upperData.ToString() == "S")
                                                    {
                                                        continueAdd = false;
                                                        getOut = true;
                                                        break;
                                                    }
                                                    else if (upperData.ToString() == " ")
                                                    {
                                                        dataGridView1.Rows[numberRow].Cells[cell].Value = "0";
                                                    }
                                                    else if (upperData.ToString().Length == 0 || upperData.ToString() == "")
                                                    {
                                                        continueAdd = false;
                                                        getOut = true;
                                                        break;
                                                    }
                                                    else if (UpperHead == "CEDULA")
                                                    {
                                                        dataGridView1.Rows[numberRow].Cells[cell].Value = upperData;
                                                    }
                                                    else
                                                    {
                                                        calculateSystem callingConvert = new calculateSystem();
                                                        //string returnCellToEnter = callingConvert.convertAndFormat(cellToEnter.ToString());
                                                        //string returnCellToEnter = cellToEnter.ToString();
                                                        string returnCellToEnter =cellToEnter.ToString();
                                                        if (returnCellToEnter == "false")
                                                        {
                                                            dataGridView1.Rows[numberRow].Cells[cell].Value = upperData;

                                                        }
                                                        else
                                                        {
                                                            dataGridView1.Rows[numberRow].Cells[cell].Value = returnCellToEnter.ToString();
                                                        }
                                                    }
                                                }
                                                if (getOut == true)
                                                {
                                                    break;
                                                }
                                                else
                                                {
                                                    DialogResult KeepCreating = MessageBox.Show("¿CREAR NUEVA FILA?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                                                    switch (KeepCreating)
                                                    {
                                                        case DialogResult.Yes:
                                                            continueAdd = true;
                                                            break;
                                                        case DialogResult.No:
                                                            rows = maximunRows;
                                                            continueAdd = false;
                                                            break;
                                                        case DialogResult.Cancel:
                                                            rows = maximunRows;
                                                            continueAdd = false;
                                                            goto outLoop;
                                                    }
                                                }
                                            }
                                            break;
                                        case DialogResult.No:
                                            rows = maximunRows;
                                            goto outLoop;
                                            //break;
                                        case DialogResult.Cancel:
                                            rows = maximunRows;
                                            goto outLoop;
                                    }
                                    break;
                                }
                                //break;
                            }
                            break;
                        }

                    }
                    break;
                case DialogResult.No:
                    AllowedUpdateAction = true;
                    bool continueAdd2 = true;
                    --maximunRows;
                    for (int rows = 0; rows < maximunRows; rows++)
                    {
                        bool getOut = false;
                        for (int cell = 1; cell < maximunColums; cell++)
                        {
                            if (dataGridView1.Rows[rows].Cells[cell].Value.ToString() == "" || dataGridView1.Rows[rows].Cells[cell].Value.ToString() == " ")
                            {
                                string UpperHead = dataGridView1.Columns[cell].HeaderText.ToString();
                                UpperHead = UpperHead.ToUpper();
                                dataGridviewToWhite();
                                dataGridView1.Rows[rows].Cells[cell].Style.BackColor = Color.LightGreen;
                                object cellToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + UpperHead + ":");
                                string upperData = cellToEnter.ToString();
                                upperData = upperData.ToUpper();
                                if (upperData.ToString() == "SALIR" || upperData.ToString() == "S")
                                {
                                    continueAdd = false;
                                    getOut = true;
                                    break;
                                }
                                else if (upperData.ToString() == " ")
                                {
                                    dataGridView1.Rows[rows].Cells[cell].Value = "0";
                                }
                                else if (upperData.ToString().Length == 0 || upperData.ToString() == "")
                                {
                                    continueAdd = false;
                                    getOut = true;
                                    break;
                                }
                                else if (UpperHead == "CEDULA")
                                {
                                    dataGridView1.Rows[rows].Cells[cell].Value = upperData;
                                }
                                else
                                {
                                    calculateSystem callingConvert = new calculateSystem();
                                    //string returnCellToEnter = callingConvert.convertAndFormat(cellToEnter.ToString());
                                    string returnCellToEnter = cellToEnter.ToString();
                                    if (returnCellToEnter == "false")
                                    {
                                        dataGridView1.Rows[rows].Cells[cell].Value = upperData;
                                    }
                                    else
                                    {
                                        dataGridView1.Rows[rows].Cells[cell].Value = returnCellToEnter.ToString();
                                    }
                                }
                            }
                        }

                        if (getOut == true)
                        {
                            break;
                        }
                        else
                        {
                            if (rows == maximunRows2)
                            {
                                DialogResult createRow = MessageBox.Show("¿CREAR NUEVA FILA?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                                switch (createRow)
                                {
                                    case DialogResult.Yes:
                                        int numberRow = dataGridView1.Rows.Count;
                                        --numberRow;
                                        --numberRow;
                                        while (continueAdd2 == true)
                                        {
                                            ++numberRow;
                                            dataGridView1.Rows.Add(numberRow.ToString());
                                            maximunColums2 = dataGridView1.ColumnCount;
                                            for (int cell = 1; cell < maximunColums2; cell++)
                                            {
                                                dataGridView1.Rows[numberRow].Cells[cell].Value = " ";
                                            }
                                            for (int cell = 1; cell < maximunColums2; cell++)
                                            {
                                                
                                                string UpperHead = dataGridView1.Columns[cell].HeaderText.ToString();
                                                UpperHead = UpperHead.ToUpper();
                                                dataGridviewToWhite();
                                                dataGridView1.Rows[numberRow].Cells[cell].Style.BackColor = Color.LightGreen;
                                                object cellToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME EL VALOR " + UpperHead + ":");
                                                string upperData = cellToEnter.ToString();
                                                upperData = upperData.ToUpper();
                                                if (upperData.ToString() == "SALIR" || upperData.ToString() == "S")
                                                {
                                                    continueAdd2 = false;
                                                    break;
                                                }
                                                else if (upperData.ToString() == " ")
                                                {
                                                    dataGridView1.Rows[numberRow].Cells[cell].Value = "0";
                                                }
                                                else if (upperData.ToString().Length == 0 || upperData.ToString() == "")
                                                {
                                                    continueAdd2 = false;
                                                    getOut = true;
                                                    break;
                                                }
                                                else if (UpperHead == "CEDULA")
                                                {
                                                    dataGridView1.Rows[numberRow].Cells[cell].Value = upperData;
                                                }
                                                else
                                                {
                                                    calculateSystem callingConvert = new calculateSystem();
                                                    //string returnCellToEnter = callingConvert.convertAndFormat(cellToEnter.ToString());
                                                    string returnCellToEnter = cellToEnter.ToString();
                                                    if (returnCellToEnter == "false")
                                                    {
                                                        dataGridView1.Rows[numberRow].Cells[cell].Value = upperData;

                                                    }
                                                    else
                                                    {
                                                        dataGridView1.Rows[numberRow].Cells[cell].Value = returnCellToEnter.ToString();
                                                    }
                                                }

                                            }
                                            DialogResult KeepCreating = MessageBox.Show("¿CREAR NUEVA FILA?", "OPCIÓN RAPIDA", MessageBoxButtons.YesNo);
                                            switch (KeepCreating)
                                            {
                                                case DialogResult.Yes:
                                                    continueAdd2 = true;
                                                    break;
                                                case DialogResult.No:
                                                    rows = maximunRows;
                                                    continueAdd2 = false;
                                                    goto outLoop;
                                                    break;
                                                case DialogResult.Cancel:
                                                    rows = maximunRows;
                                                    continueAdd2 = false;
                                                    goto outLoop;
                                            }
                                        }
                                        break;
                                    case DialogResult.No:
                                        rows = maximunRows;
                                        continueAdd2 = false;
                                        goto outLoop;
                                    //break;
                                    case DialogResult.Cancel:
                                        rows = maximunRows;
                                        continueAdd2 = false;
                                        goto outLoop;
                                }
                                break;
                            }
                        }
                    }
                    break;
            }

            outLoop: ;
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            //setDataAndSend2();
            dataGridviewToWhite();
            AllowedUpdateAction = true;
            object cellToEnter = Microsoft.VisualBasic.Interaction.InputBox("DAME NOMBRE DE LA COLUMNA:");
            string introduce=cellToEnter.ToString();
            introduce = introduce.ToUpper();
            dataGridView1.Columns.Add(introduce, introduce);
            int rowNumberSave = dataGridView1.Rows.Count;
            --rowNumberSave;
            int colNumberSave = dataGridView1.Columns.Count;
            int end = dataGridView1.Columns.Count;
            --end;
            for (int rows = 0; rows < rowNumberSave; rows++)
            {
                for (int cell = 1; cell < colNumberSave; cell++)
                {
                    if (end == cell)
                    {
                        dataGridView1.Rows[rows].Cells[cell].Value=" ";
                    }
                }
            }
            setDataAndSend();
        }

        private void buttonAddArrow_Click(object sender, EventArgs e)
        {
            //setDataAndSend2();
            AllowedUpdateAction = true;
            dataGridviewToWhite();
            int arrows = dataGridView1.Rows.Count;
            int maximunCells = dataGridView1.Columns.Count;
            string[,] storage = new string[arrows, maximunCells];
            for (int columns = 0; columns < arrows; columns++)
            {
                for (int cell = 1; cell < maximunCells; cell++)
                {
                    if (dataGridView1.Rows[columns].Cells[cell].Value == null)
                    {
                        storage[columns, cell] = "";
                    }
                    else
                    {
                        storage[columns, cell] = dataGridView1.Rows[columns].Cells[cell].Value.ToString();
                    }
                }
            }
            int numberRow = locationRow;
            ++numberRow;
            dataGridView1.Rows.Add(numberRow.ToString());

            for (int arrow2 = 0; arrow2 < arrows; arrow2++)
            {
                if (arrow2 == locationRow)
                {
                    int end = arrow2;
                    int arrowBack = arrow2;
                    for (arrow2 = arrowBack; arrow2 < arrows; arrow2++)
                    {
                        for (int cell = 1; cell < maximunCells; cell++)
                        {
                            dataGridView1.Rows[arrow2].Cells[cell].Value = storage[arrowBack, cell];
                        }
                        arrowBack = arrow2;
                        dataGridView1.Rows[arrow2].Cells[0].Value = end;
                        ++end;
                    }

                    ++locationRow;
                }
            }
            dataGridviewToWhite();
            for (int arrow2 = 0; arrow2 < arrows; arrow2++)
            {
                if (arrow2 == locationRow)
                {
                    for (int cell = 1; cell < maximunCells; cell++)
                    {
                        dataGridView1.Rows[arrow2].Cells[cell].Value = " ";
                        dataGridView1.Rows[arrow2].Cells[cell].Style.BackColor = Color.LightGreen;
                    }
                    break;
                }
            }
            setDataAndSend();
        }

        private void buttonMoveUpArrow_Click(object sender, EventArgs e)
        {
            dataGridviewToWhite();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int maximunCells = row.Cells.Count;
                if (locationRow == row.Index)
                {
                    int indexActual = locationRow;
                    int indexToMove = locationRow;
                    --indexToMove;
                    try
                    {
                        for (int cell = 1; cell < maximunCells; cell++)
                        {

                            object dataActual = dataGridView1.Rows[indexActual].Cells[cell].Value;
                            object dataBefore = dataGridView1.Rows[indexToMove].Cells[cell].Value;
                            dataGridView1.Rows[indexActual].Cells[cell].Value = dataBefore;
                            dataGridView1.Rows[indexToMove].Cells[cell].Style.BackColor = Color.LightGreen;
                            dataGridView1.Rows[indexToMove].Cells[cell].Value = dataActual;
                            dataGridView1.Rows[indexActual].Cells[cell].Style.BackColor = Color.White;
                            AllowedUpdateAction = true;
                        }
                        --locationRow;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("IMPOSIBLE DE MOVER, ES EL INICIO");
                        break;
                    }

                    break;
                }
            }
        }

        private void buttonMoveBackColum_Click(object sender, EventArgs e)
        {
            dataGridviewToWhite();
            int last = locationCell;
            --last;
            if (last > 0)
            {
                //++locationCell;
                int rowNumberSave = 0;
                bool onlyOnce = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;

                    for (int cell = 1; cell < maximunCells; cell++)
                    {
                        if (locationCell == cell)
                        {
                            if (onlyOnce == true)
                            {
                                int indexHead = locationCell;
                                string headActual = dataGridView1.Columns[indexHead].HeaderText.ToString();
                                string headBefore = dataGridView1.Columns[--indexHead].HeaderText.ToString();
                                dataGridView1.Columns[indexHead].HeaderText = headActual;
                                dataGridView1.Columns[++indexHead].HeaderText = headBefore;
                                onlyOnce = false;
                            }
                            
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

                                break;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("SUCEDIO ALGUN PROBLEMA MOVIENDO LAS COLUMNAS");
                                break;
                            }
                            //break;
                        }
                    }
                    ++rowNumberSave;
                }
                --locationCell;
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL INICIO");
                //++locationCell;
            }
        }

        private void buttonMoveNextColumn_Click(object sender, EventArgs e)
        {
            dataGridviewToWhite();
            int last = dataGridView1.Columns.Count;
            --last;

            if (locationCell < last)
            {
                int rowNumberSave = 0;
                bool onlyOnce = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;

                    for (int cell = 1; cell < maximunCells; cell++)
                    {
                        if (locationCell == cell)
                        {
                            if (onlyOnce == true)
                            {
                                int indexHead = locationCell;
                                string headBefore = dataGridView1.Columns[indexHead].HeaderText.ToString();
                                string headAfter = dataGridView1.Columns[++indexHead].HeaderText.ToString();
                                dataGridView1.Columns[--indexHead].HeaderText = headAfter;
                                dataGridView1.Columns[++indexHead].HeaderText = headBefore;
                                onlyOnce = false;
                            }
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
                                break;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("");
                                break;
                            }
                            //break;
                        }

                    }

                    ++rowNumberSave;
                }
                ++locationCell;
            }
            else
            {
                MessageBox.Show("IMPOSIBLE MOVER, ES EL FIN");
            }
        }

        private void buttonMoveDownArrow_Click(object sender, EventArgs e)
        {
            dataGridviewToWhite();
            int last = dataGridView1.RowCount;
            --last;
            --last;
            if (locationRow < last)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int maximunCells = row.Cells.Count;
                    if (locationRow == row.Index)
                    {
                        int indexActual = locationRow;
                        int indexToMove = locationRow;
                        ++indexToMove;
                        try
                        {
                            for (int cell = 1; cell < maximunCells; cell++)
                            {

                                object dataActual = dataGridView1.Rows[indexActual].Cells[cell].Value;
                                object dataBefore = dataGridView1.Rows[indexToMove].Cells[cell].Value;
                                dataGridView1.Rows[indexActual].Cells[cell].Value = dataBefore;
                                dataGridView1.Rows[indexActual].Cells[cell].Style.BackColor = Color.White;
                                dataGridView1.Rows[indexToMove].Cells[cell].Value = dataActual;
                                dataGridView1.Rows[indexToMove].Cells[cell].Style.BackColor = Color.LightGreen;
                                AllowedUpdateAction = true;
                            }
                            ++locationRow;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("SUCEDIO UN PROBLEMA MOVIENDO LAS FILAS");
                            break;
                        }
                        break;

                    }
                }
            }
            else
            {
                MessageBox.Show("IMPOSIBLE DE MOVER, ES EL FIN");
            }
        }

        private void buttonUpdateTemplate_Click(object sender, EventArgs e)
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
                if(File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            generalMethodToWriteInFiles callToWriteInFiles = new generalMethodToWriteInFiles();
            foreach (string name in names)
            {
                if(name=="1-7")
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" +name+".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row=0; row<dataGridView1.Rows.Count-1;row++)
                    {
                        sumString += tagStartLine + "?";
                        for (int column = 0; column < dataGridView1.Columns.Count; column++)
                        {
                            if(dataGridView1.Rows[row].Cells[column].Value==null)
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
                    callToWriteInFiles.writeInFiles(pathToWrite,sumString);
                }
                else if(name == "8-14")
                {
                    string pathToWrite = CorePathOfFolderCompaniesSistemaPlanillas + company + "\\" + deparment + "\\" + month + "\\" + name + ".txt";
                    string sumString = "";
                    sumString += tagStartHEad + "?";
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        sumString += column.HeaderText + "?";
                    }
                    sumString += tagEndHEad + "?";
                    for (int row = 0; row < dataGridView2.Rows.Count-1; row++)
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
                    for (int row = 0; row < dataGridView3.Rows.Count-1; row++)
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
                    for (int row = 0; row < dataGridView4.Rows.Count-1; row++)
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
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString()+ "?";
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
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    sumString += column.HeaderText + "?";
                    sumString += column.Visible.ToString() + "?";
                    if(column.HeaderCell.Style.BackColor==Color.LightGray)
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
            MessageBox.Show("ACTUALIZADO EXITOSAMENTE"); 
        }

        private void buttonEraseColumn_Click(object sender, EventArgs e)
        {
            //setDataAndSend2();
            dataGridviewToWhite();
            int rowNumberSave = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int maximunCells = row.Cells.Count;

                for (int cell = 1; cell < maximunCells; cell++)
                {
                    if (locationCell == cell)
                    {
                        ++cell;
                        for (int cell2 = cell; cell2 < maximunCells; cell2++)
                        {
                            int indexToMove2 = cell2;
                            try
                            {

                                object dataActual = dataGridView1.Rows[rowNumberSave].Cells[cell2].Value;
                                dataGridView1.Rows[rowNumberSave].Cells[--indexToMove2].Value = dataActual;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("");
                            }
                        }
                        cell = maximunCells;
                    }

                }
                ++rowNumberSave;
            }
            --locationCell;
            AllowedUpdateAction = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int maximunCells = row.Cells.Count;
                for (int cell = 1; cell < maximunCells; cell++)
                {
                    if (locationCell == cell)
                    {
                        row.Cells[cell].Style.BackColor = Color.LightGreen;
                    }
                }
            }

            int eraseColum = dataGridView1.Columns.Count;
            --eraseColum;
            dataGridView1.Columns.RemoveAt(eraseColum);

            setDataAndSend();
        }

        private void buttonEraseArrow_Click(object sender, EventArgs e)
        {
            dataGridviewToWhite();
            int arrows = dataGridView1.Rows.Count;
            if (dataGridView1.Rows.Count > 0 && locationRow > 0)
            {
                //setDataAndSend2();
                int maximunCells = dataGridView1.Columns.Count;
                string[,] storage = new string[arrows, maximunCells];
                for (int columns = 0; columns < arrows; columns++)
                {
                    for (int cell = 1; cell < maximunCells; cell++)
                    {
                        if (dataGridView1.Rows[columns].Cells[cell].Value == null)
                        {
                            storage[columns, cell] = "";
                        }
                        else
                        {
                            storage[columns, cell] = dataGridView1.Rows[columns].Cells[cell].Value.ToString();
                        }

                    }
                }

                try
                {
                    for (int arrow2 = 0; arrow2 < arrows; arrow2++)
                    {
                        if (arrow2 == locationRow)
                        {
                            int arrowBack = locationRow;
                            ++arrowBack;
                            --arrows;
                            for (arrow2 = locationRow; arrow2 < arrows; arrow2++)
                            {
                                for (int cell = 1; cell < maximunCells; cell++)
                                {
                                    dataGridView1.Rows[arrowBack].Cells[cell].Value = storage[arrowBack, cell];
                                }
                                int head = arrow2;
                                --head;
                                dataGridView1.Rows[arrow2].Cells[0].Value = head.ToString();
                            }
                            break;
                        }
                        else
                        {
                            for (int cell = 1; cell < maximunCells; cell++)
                            {
                                dataGridView1.Rows[arrow2].Cells[cell].Value = storage[arrow2, cell];
                            }
                        }
                    }

                    dataGridView1.Rows.RemoveAt(locationRow);
                    --locationRow;
                    AllowedUpdateAction = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("IMPOSIBLE BORRAR");
                }

                for (int arrow2 = 0; arrow2 < arrows; arrow2++)
                {
                    if (arrow2 == locationRow)
                    {
                        for (int cell = 1; cell < maximunCells; cell++)
                        {
                            dataGridView1.Rows[arrow2].Cells[cell].Style.BackColor = Color.LightGreen;
                        }
                        break;
                    }
                }

                setDataAndSend();
            }
            else
            {
                MessageBox.Show("IMPOSIBLE BORRAR, ES EL LA PRIMER FILA");
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
            using (GUI_SELECCIONAR_ASIENTOS form2 = new GUI_SELECCIONAR_ASIENTOS())
            {
                /*
                
                
                if (form2.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                {
                    
                }
                */
            }
        }
        

        public void PathToSave(string companyReceive, string deptReceive, string monthReceive, string pathReceive)
        {
            path = pathReceive;
            company = companyReceive;
            deparment = deptReceive;
            month = monthReceive;
            /*
            week = weekReceive;
            file = fileReceive;
            */
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
                for (int rows=0; rows< maximunRows; rows++)
                {
                    for (int cell=1; cell< cells; cell++)
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
            this.Close();
        }

        private void CellClickEvent(object sender, DataGridViewCellEventArgs e)
        {
            dataGridviewToWhite();
            try
            {
                AllowedUpdateAction = true;
                locationCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
                locationRow = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
            }
            catch (Exception)
            { 
                MessageBox.Show("HUBO ALGUN PROBLEMA SELECCIONANDO LA COLUMNA"); 
            }
        }

        private void buttonImportDataColumn_Click(object sender, EventArgs e)
        {

            //setDataAndSend2();
            using (GUI_ELEGIR_COPIAR_COLUMNA form2 = new GUI_ELEGIR_COPIAR_COLUMNA())
            {
                form2.PathToSave(path);
                string sendData = "";
                int maximunColum = dataGridView1.Columns.Count;
                for (int colum= 0; colum<maximunColum; colum++)
                {
                    sendData += dataGridView1.Columns[colum].HeaderText.ToString()+ "\n";
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
                form2.PathToSave(path);
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
                indexSaveDataGrinOnTime=0;
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
                indexSaveDataGrinOnTime= end;
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
            List<string> savingHeads = new List<string>();
            int maximunColums = dataGridView1.Columns.Count;
            for (int colums = 5; colums < maximunColums; colums++)
            {
                savingHeads.Add(dataGridView1.Columns[colums].HeaderText);
            }
            GUI_CREATE_FORMULA callingCreateFormula = new GUI_CREATE_FORMULA();
            callingCreateFormula.receivedData(savingHeads);
            //callingCreateFormula.PathToSave(company, deparment, month, week, file, path);
            callingCreateFormula.ShowDialog();
        }

        private void calculateFormula()
        {
            string actual = Directory.GetCurrentDirectory();
            actual = actual.Replace("\\bin\\Debug", "\\configuration");
            string actualPath =actual +"\\Formulas\\formula.txt";
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
                                string returnsendData=callingCalculate.correctString(sendData);
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
            try
            {
                calculateFormula();
            } catch (Exception)
            {
                MessageBox.Show("SUCEDIO ALGUN PROBLEMA RECALCULANDO LAS FORMULAS");
            }
        }

        private void CellRecalculateFinish(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               int x = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].RowIndex;
               int y = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
               string convert ="";
               if(dataGridView1.Rows[x].Cells[y].Value==null)
               {
                 convert =" ";
               }else
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
                            storage +=item;
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
            catch(Exception)
            {  }
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
            foreach(Object item in checkedListBox1.CheckedItems)
            {
                int index = checkedListBox1.Items.IndexOf(item);
                bool answer = checkedListBox1.GetItemChecked(index);
                if (answer==true)
                {
                    DataGridView DataToStudy = new DataGridView();
                    string week = checkedListBox1.Items[index].ToString();
                    if(week.Contains("1-7"))
                    {
                        DataToStudy = dataGridView1;
                    }else if(week.Contains("8-14"))
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
                    bool visible= DataToStudy.Visible;
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
            comboBox2.Items.Clear();
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
                    if (column.HeaderCell.Style.BackColor==Color.LightSalmon)
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
                        if (item.ToString()=="VISIBLE")
                        {
                            DataToStudy.Visible = true;
                        }
                        if (item.ToString() == "CALCULAR")
                        {
                            DataToStudy.EnableHeadersVisualStyles = false;
                            foreach(DataGridViewColumn colum in DataToStudy.Columns)
                            {
                                colum.HeaderCell.Style.BackColor= Color.LightGray;
                            }
                            DataToStudy.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                        }
                        //break;
                    }else
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
                            DataToStudy.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }
                }
                checkedListBox2.Items.Clear();
                baseResizeDatasGridViewPhase1();
            }else if(orderDatagrid == "TODOS")
            {
                checkedListBox2.Items.Clear();
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
    }
}
