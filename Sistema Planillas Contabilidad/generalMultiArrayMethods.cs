using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    class generalMultiArrayMethods
    {
        TagsAndDefaultValues startTheTagsAndDefaults;
        string tagStartHead = "";
        string tagEndHEad = "";
        string tagStartLine = "";
        string tagEndLine = "";
        public void MethodToReceivedAccesToObject(TagsAndDefaultValues startTheTagsAndDefaultsReceived)
        {
            //receiving object reference
            startTheTagsAndDefaults = startTheTagsAndDefaultsReceived;
            //default values
            tagStartHead = startTheTagsAndDefaults.isTagStartHead;
            tagEndHEad = startTheTagsAndDefaults.isTagEndHead;
            tagStartLine = startTheTagsAndDefaults.isTagStartLine;
            tagEndLine = startTheTagsAndDefaults.isTagEndLine;
        }

        private string[,] calculateSizeAndFillArray(DataGridView receivedDataGridView)
        {
            int numberOfRows = receivedDataGridView.Rows.Count;
            ++numberOfRows;
            int numberOfColumns = receivedDataGridView.Columns.Count;
            string[,] multiArrayReceived = new string[numberOfRows, numberOfColumns];
            int indexRow = 0;
            for (int column = 0; column < numberOfColumns; column++)
            {
                multiArrayReceived[indexRow, column] = receivedDataGridView.Columns[column].HeaderText;
            }
            ++indexRow;
            int indexRowDataGridView = 0;
            foreach (DataGridViewRow row in receivedDataGridView.Rows)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    if (receivedDataGridView.Rows[indexRowDataGridView].Cells[column].Value == null)
                    {
                        multiArrayReceived[indexRow, column] = " ";
                    }
                    else
                    {
                        multiArrayReceived[indexRow, column] = receivedDataGridView.Rows[indexRowDataGridView].Cells[column].Value.ToString();
                    }
                }
                ++indexRow;
                ++indexRowDataGridView;
            }
            return multiArrayReceived;
        }

        private string[,] resizeArrayColumnsErase(string[,] receivedArray, int stopFlag)
        {
            int numberOfRows = receivedArray.GetLength(0);
            int numberOfColumns = receivedArray.GetLength(1);
            numberOfColumns -= stopFlag;
            string[,] replaceArray = new string[numberOfRows, numberOfColumns];
            for (int column = 0; column < numberOfColumns; column++)
            {
                for (int row = 0; row < numberOfRows; row++)
                {
                    replaceArray[row, column] = receivedArray[row, column];
                }
            }
            return replaceArray;
        }

        public List<string [,]> methodToGetListOfArray(List<string> paths)
        {
            List<string[,]> listOfArrays = new List<string[,]>();
            foreach (string path in paths)
            {
                string[] storageData = File.ReadAllLines(path);
                int counterHeads = 0;
                int counterRows = 0;
                for (int line = 0; line < storageData.Length; line++)
                {
                    if (storageData[line] == tagEndHEad)
                    {
                        ++counterRows;
                        break;
                    }
                    else if (storageData[line] != tagStartHead)
                    {
                        ++counterHeads;
                    }
                }
                for (int line = 0; line < storageData.Length; line++)
                {
                    if(storageData[line] == tagStartLine)
                    {
                        ++counterRows;
                    }
                }
                string[,] data = new string[counterRows, counterHeads];
                int index = 0;
                for (int rows = 0; rows < counterRows; rows++)
                {
                    if (storageData[index] == tagStartHead || storageData[index] == tagEndHEad || storageData[index] == tagEndLine || storageData[index] == tagStartLine)
                    {
                        ++index;
                    }
                    for (int column = 0; column < counterHeads; column++)
                    {
                        if(storageData[index]==tagStartHead || storageData[index] ==tagEndHEad || storageData[index] == tagEndLine|| storageData[index] == tagStartLine)
                        {
                            ++index;
                        }
                        data[rows, column] = storageData[index];
                        ++index;
                    }
                    ++index;
                }
                listOfArrays.Add(data);
            }
            return listOfArrays;
        }

        public int[] countColumnsAndRows(string[] receivedArray, int flag)
        {
            int rowCounter = 0;
            int columnCounter = 0;
            for (int linePhase1 = 0; linePhase1 < receivedArray.Length; linePhase1++)
            {
                if (receivedArray[linePhase1] == tagEndHEad)
                {
                    ++linePhase1;
                    for (int linePhase2 = linePhase1; linePhase2 < receivedArray.Length; linePhase2++)
                    {
                        if (receivedArray[linePhase2] == tagStartLine)
                        {
                            ++rowCounter;
                        }
                    }
                    break;
                }
                else if (receivedArray[linePhase1] != tagStartHead)
                {
                    ++columnCounter;
                }
            }
            int[] returnArray = new int[1];
            returnArray[0] = rowCounter;
            returnArray[1] = columnCounter;
            return returnArray;
        }

        public bool findInRowsDataGridView(DataGridView receivedDataGridView,string flag, string find)
        {
            bool found=false;
            for (int column=0; column<receivedDataGridView.Columns.Count; column++)
            {
                if(receivedDataGridView.Columns[column].HeaderText==flag)
                {
                    for(int row=0; row<receivedDataGridView.Rows.Count-1; row++)
                    {
                        if(receivedDataGridView.Rows[row].Cells[flag].Value==null)
                        { 
                        }else if(receivedDataGridView.Rows[row].Cells[flag].Value.ToString()==find)
                        {
                            found = true;
                            break;
                        }
                    }
                    break;
                }
            }
            return found;
        }

        public List<DataGridViewRow> getLisfOfRowsWithPivote(List<DataGridView> receivedListDataGridView, string flag)
        {
            List<DataGridViewRow> listReturnRows = new List<DataGridViewRow>();
            for(int dataGridView=0; dataGridView<receivedListDataGridView.Count; dataGridView++)
            {
                DataGridView dataGridToStudy = receivedListDataGridView[dataGridView];
                for(int row=0; row<dataGridToStudy.Rows.Count-1; row++)
                {
                    for (int column = 0; column < dataGridToStudy.Columns.Count; column++)
                    {
                        if(dataGridToStudy.Rows[row].Cells[column].Value.ToString()==flag)
                        {
                            listReturnRows.Add(dataGridToStudy.Rows[row]);
                            break;
                        }
                    }
                }
            }
            return listReturnRows;
        }

        public string[] getSumOfLisfRows(List<DataGridViewRow> receivedListDataGridViewRows)
        {
            generalDataAndAvoidData callToHeads = new generalDataAndAvoidData();
            string sumAll = "";
            List<string> returnList = new List<string>(); 
            for (int row=0; row<receivedListDataGridViewRows.Count; row++)
            {
                for (int cell = 0; cell < receivedListDataGridViewRows[row].Cells.Count; cell++)
                {
                    bool answer = callToHeads.avoidColumns(receivedListDataGridViewRows[row].Cells[cell].Value.ToString());
                    if(answer==false)
                    {
                        sumAll+=receivedListDataGridViewRows[row].Cells[cell].Value.ToString()+"?";
                    }else
                    {
                        double sum = 0;
                        if(receivedListDataGridViewRows[row].Cells[cell].Value==null || receivedListDataGridViewRows[row].Cells[cell].Value.ToString()== " " || receivedListDataGridViewRows[row].Cells[cell].Value.ToString() == "")
                        {
                            sum += 0;
                        }else
                        {
                            sum += Convert.ToDouble(receivedListDataGridViewRows[row].Cells[cell].Value);
                        }
                        if (receivedListDataGridViewRows.Count >= 1)
                        {
                            for (int rowPhase2 = 1; rowPhase2 < receivedListDataGridViewRows.Count; rowPhase2++)
                            {
                                if(receivedListDataGridViewRows[rowPhase2].Cells[cell].Value==null || receivedListDataGridViewRows[rowPhase2].Cells[cell].Value.ToString()==" "|| receivedListDataGridViewRows[rowPhase2].Cells[cell].Value.ToString() == "")
                                {
                                    sum += 0;
                                }else
                                {
                                    sum += Convert.ToDouble(receivedListDataGridViewRows[rowPhase2].Cells[cell].Value);
                                }
                            }
                        }
                        if (sum == 0)
                        {
                            sumAll += " " + "?";
                        }
                        else
                        {
                            sumAll += sum.ToString() + "?";
                        }
                    }
                }
                break;
            }
            sumAll = sumAll.TrimEnd('?');
            string []storageData = sumAll.Split('?');
            return storageData;
        }

        public string[,] MoveNextColum(DataGridView receivedDataGridView, int flag)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int afterFlag = flag + 1;
            int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int column = 0; column < numberOfColumns; column++)
            {
                if (column == flag)
                {
                    for (int row = 0; row < numberOfRows; row++)
                    {
                        string actual = multiArrayReceived[row, flag];
                        string after = multiArrayReceived[row, afterFlag];
                        multiArrayReceived[row, flag] = after;
                        multiArrayReceived[row, afterFlag] = actual;

                    }
                    break;
                }
            }
            return multiArrayReceived;
        }

        public string[,] MoveBackColum(DataGridView receivedDataGridView, int flag)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int beforeFlag = flag - 1;
            int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int column = 0; column < numberOfColumns; column++)
            {
                if (column == flag)
                {
                    for (int row = 0; row < numberOfRows; row++)
                    {
                        string actual = multiArrayReceived[row, flag];
                        string before = multiArrayReceived[row, beforeFlag];
                        multiArrayReceived[row, beforeFlag] = actual;
                        multiArrayReceived[row, flag] = before;
                    }
                    break;
                }
            }
            return multiArrayReceived;
        }

        public string[,] MoveUpRow(DataGridView receivedDataGridView, int flag)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int afterFlag = flag + 1;
            ///int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int column = 0; column < numberOfColumns; column++)
            {
                string actual = multiArrayReceived[flag, column];
                string after = multiArrayReceived[afterFlag, column];
                multiArrayReceived[flag, column] = after;
                multiArrayReceived[afterFlag, column] = actual;
            }
            return multiArrayReceived;
        }

        public string[,] MoveDownRow(DataGridView receivedDataGridView, int flag)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int beforeFlag = flag+3;
            --beforeFlag;
            int next=flag+1;
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int column = 0; column < numberOfColumns; column++)
            {
                string actual = multiArrayReceived[beforeFlag, column];
                string before = multiArrayReceived[next, column];
                multiArrayReceived[beforeFlag, column] = before;
                multiArrayReceived[next, column] = actual;
            }
            return multiArrayReceived;
        }

        

        public string[,] eraseColum(DataGridView receivedDataGridView, int flag, int amountSpacesErase)
        {
            int beforeFlag = flag + 1;
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            for (int columnPhase1 = 0; columnPhase1 < numberOfColumns; columnPhase1++)
            {
                if (columnPhase1 == flag)
                {
                    for (int columnPhase2 = columnPhase1; columnPhase2 < numberOfColumns; columnPhase2++)
                    {
                        for (int row = 0; row < numberOfRows; row++)
                        {
                            string actual = multiArrayReceived[row, flag];
                            if (beforeFlag < numberOfColumns)
                            {
                                string before = multiArrayReceived[row, beforeFlag];
                                multiArrayReceived[row, beforeFlag] = actual;
                                multiArrayReceived[row, flag] = before;
                            }
                        }
                        ++flag;
                        ++beforeFlag;
                    }
                    multiArrayReceived = resizeArrayColumnsErase(multiArrayReceived, amountSpacesErase);
                    break;
                }
            }
            return multiArrayReceived;
        }

        public string[,] addColum(DataGridView receivedDataGridView, string nameHead, int flag, int amountSpacesAdd)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int numberOfRows = multiArrayReceived.GetLength(0) - 1;
            int numberOfColumns = multiArrayReceived.GetLength(1);
            //new array
            int addNumberOfColumns = numberOfColumns + amountSpacesAdd;
            string[,] replaceArray = new string[numberOfRows, addNumberOfColumns];

            for (int columnPhase1 = 0; columnPhase1 < numberOfColumns; columnPhase1++)
            {
                if (columnPhase1 == flag)
                {
                    int indexToMove = flag + 1;
                    for (int columnPhase2 = columnPhase1; columnPhase2 < numberOfColumns; columnPhase2++)
                    {
                        for (int row = 0; row < numberOfRows; row++)
                        {
                            replaceArray[row, indexToMove] = multiArrayReceived[row, columnPhase2];
                        }
                        ++indexToMove;
                    }

                    for (int row = 0; row < numberOfRows; row++)
                    {
                        if (row == 0)
                        {
                            replaceArray[row, flag] = nameHead;
                        }
                        else
                        {
                            replaceArray[row, flag] = " ";
                        }
                    }
                    break;
                }
                else
                {
                    for (int row = 0; row < numberOfRows; row++)
                    {
                        replaceArray[row, columnPhase1] = multiArrayReceived[row, columnPhase1];
                    }
                }
            }
            return replaceArray;
        }

        public string[,] addRow(DataGridView receivedDataGridView, int flag)
        {
            string[,] multiArrayReceived = calculateSizeAndFillArray(receivedDataGridView);
            int numberOfRows = multiArrayReceived.GetLength(0);
            int numberOfColumns = multiArrayReceived.GetLength(1);
            int flagStop = flag + 1;
            //new array
            string[,] replaceArray = new string[numberOfRows, numberOfColumns];
            for (int rowPhase1 = 0; rowPhase1 < numberOfRows; rowPhase1++)
            {
                if(rowPhase1 == flagStop)
                {
                    int indexToMove = flag + 1;
                    for (int rowPhase2 = flag; rowPhase2 < receivedDataGridView.Rows.Count; rowPhase2++)
                    {
                        for (int column = 0; column < numberOfColumns; column++)
                        {
                            replaceArray[indexToMove, column] = multiArrayReceived[rowPhase2, column];
                        }
                        ++indexToMove;
                    }
                    for (int column = 0; column < numberOfColumns; column++)
                    {
                        replaceArray[rowPhase1, column] = " ";
                    }
                    
                    break;
                }
                else
                {
                    for (int column = 0; column < numberOfColumns; column++)
                    {
                        replaceArray[rowPhase1, column] = multiArrayReceived[rowPhase1, column];
                    }
                }
            }
            return replaceArray;
        }
    }
}
