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
        string tagEndHEad = "";
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
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
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
            //startChargeData();
            //calculateFormula();
        }

        private void setHeadsOfDataGridView()
        {
            string pathOfAvoidData = SpecificPathOfFolderConfigurationAvoidData;
            string []storageAvoidDataFiles = Directory.GetFiles(pathOfAvoidData);
            generalMethods generalMethods = new generalMethods();
            foreach (string path in storageAvoidDataFiles)
            {
                string[] storageAvoidData = File.ReadAllLines(path);
                foreach(DataGridViewColumn colum in dataGridView1.Columns)
                {
                    bool answer = generalMethods.findDataInArray(storageAvoidData, colum.HeaderText);
                    if(answer==false)
                    {
                        dataGridView1.Columns.Add(colum.HeaderText, colum.HeaderText);
                    }
                }
            }
        }

        private void startChargeData()
        {
            buttonBackTotal.Enabled= false;
            buttonNextTotal.Enabled = false;
            string[] lines = File.ReadAllLines(path);
            int columnNumber = 0;
            int rowNumber = 0;
            int numberHeads = 0;
            
            for (int line = 0; line < lines.Length; line++)
            {
                if (lines[line] == separator1)
                {
                    numberHeads = columnNumber;
                }
                else if (lines[line] == separator2)
                {
                    ++rowNumber;
                }
                ++columnNumber;
            }
            
            bool found = false;
            for (int line = 0; line < numberHeads; line++)
            {
                if (lines[line] == separator1)
                {
                    break;
                }
                else 
                {
                    try
                    {
                        string tryFind = dataGridView1.Columns[line].HeaderText.ToString();
                        for (int data = 0; data < avoidData.Length; data++)
                        {
                            string compare = avoidData[data];
                            if (tryFind.Contains(compare))
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found == false)
                        {
                            dataGridView1.Columns.Add(lines[line].ToString(), lines[line].ToString());
                        }
                        else
                        {
                            found = false;
                        }
                    }
                    catch (Exception)
                    {
                        dataGridView1.Columns.Add(lines[line].ToString(), lines[line].ToString());
                    }
                }
            }

            for (int line = 0; line < rowNumber; line++)
            {
                dataGridView1.Rows.Add(line.ToString());
            }
            
            int jumpRow = 0;
            int row = 1;
            ++numberHeads;
            for (int line = numberHeads; line < lines.Length; line++)
            {
                if (lines[line] == separator2)
                {
                    ++jumpRow;
                    ++line;
                    row = 1;
                }
                try
                {
                    dataGridView1.Rows[jumpRow].Cells[row].Value = lines[line];
                }
                catch (Exception)
                {
                    dataGridView1.Rows[jumpRow].Cells[row].Value = " ";
                }
                ++row;
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
            if (AllowedUpdateAction == true)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(fs);

                        int maximunRows = dataGridView1.Rows.Count;
                        --maximunRows;
                        int maximunCells = dataGridView1.Columns.Count;
                        int end = dataGridView1.Columns.Count;
                        for (int col = 0; col < end; col++)
                        {
                            writer.WriteLine(dataGridView1.Columns[col].HeaderText.ToString());
                        }
                        writer.WriteLine(separator1);
                        for (int row = 0; row < maximunRows; row++)
                        {
                            for (int cell = 1; cell < maximunCells; cell++)
                            {
                                if (dataGridView1.Rows[row].Cells[cell].Value == null || dataGridView1.Rows[row].Cells[cell].Value.ToString() == "" || dataGridView1.Rows[row].Cells[cell].Value.ToString() == " ")
                                {
                                    dataGridView1.Rows[row].Cells[cell].Value = " ";
                                    writer.WriteLine(" ");
                                    //dataGridView1.Rows[row].Cells[cell].Value=" ";
                                }
                                else
                                {
                                    object data = dataGridView1.Rows[row].Cells[cell].Value;
                                    writer.WriteLine(data.ToString());
                                }
                            }
                            writer.WriteLine(separator2);
                        }
                        writer.Close();
                        MessageBox.Show("ACTUALIZADO EXITOSAMENTE");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("HUBO UN PROBLEMA ACTUALIZANDO LA PLANTILLA");
                }

                AllowedUpdateAction = false;
            }
            else
            {
                MessageBox.Show("CAMBIE PRIMERO ALGO ANTES DE ACTUALIZARLO");
            }
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
    }
}
