using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Sistema_Planillas_Contabilidad
{
    class keepDataGridView
    {
        string [,] dataGridView;
        int indexDataGridView;
        public string[,] dataGrid
        {
            get
            {
                return dataGridView;
            }

            set
            {
                dataGridView = value;
            }
        }

        public int index
        {
            get
            {
                return indexDataGridView;
            }

            set
            {
                indexDataGridView = value;
            }
        }

        public keepDataGridView(int index, string [,] inData)
        {
            indexDataGridView = index;
            dataGridView = inData;
        }
    }
}
