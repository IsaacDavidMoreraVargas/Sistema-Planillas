using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    public class TagsAndDefaultValues
    {
        private string tagStartHead = "";
        private string tagEndHead = "";
        private string tagStartLine = "";
        private string tagEndLine = "";
        private string threeLine = "";
        private string deparment = "";

        public string isTagStartHead
        {
            get
            {
                return tagStartHead;
            }
            set
            {
                tagStartHead = value;
            }
        }

        public string isTagEndHead
        {
            get
            {
                return tagEndHead;
            }
            set
            {
                tagEndHead = value;
            }
        }

        public string isTagStartLine
        {
            get
            {
                return tagStartLine;
            }
            set
            {
                tagStartLine = value;
            }
        }

        public string isTagEndLine
        {
            get
            {
                return tagEndLine;
            }
            set
            {
                tagEndLine = value;
            }
        }

        public string tripleLine
        {
            get
            {
                return threeLine;
            }
            set
            {
                threeLine = value;
            }
        }

        public string isDeparment
        {
            get
            {
                return deparment;
            }
            set
            {
                deparment = value;
            }
        }

        private string tagStarGrid1 = "";
        private string tagEndGrid1 = "";
        private string tagStarGrid2 = "";
        private string tagEndGrid2 = "";
        private string tagStarGrid3 = "";
        private string tagEndGrid3 = "";
        private string tagStarGrid4 = "";
        private string tagEndGrid4 = "";
        //
        public string tagStartDataGrid1
        {
            get
            {
                return tagStarGrid1;
            }
            set
            {
                tagStarGrid1 = value;
            }
        }

        public string tagEndDataGrid1
        {
            get
            {
                return tagEndGrid1;
            }
            set
            {
                tagEndGrid1 = value;
            }
        }
        //
        public string tagStartDataGrid2
        {
            get
            {
                return tagStarGrid2;
            }
            set
            {
                tagStarGrid2 = value;
            }
        }

        public string tagEndDataGrid2
        {
            get
            {
                return tagEndGrid2;
            }
            set
            {
                tagEndGrid2 = value;
            }
        }
        //
        public string tagStartDataGrid3
        {
            get
            {
                return tagStarGrid3;
            }
            set
            {
                tagStarGrid3 = value;
            }
        }

        public string tagEndDataGrid3
        {
            get
            {
                return tagEndGrid3;
            }
            set
            {
                tagEndGrid3 = value;
            }
        }
        //
        public string tagStartDataGrid4
        {
            get
            {
                return tagStarGrid4;
            }
            set
            {
                tagStarGrid4 = value;
            }
        }

        public string tagEndDataGrid4
        {
            get
            {
                return tagEndGrid4;
            }
            set
            {
                tagEndGrid4 = value;
            }
        }
    }
}
