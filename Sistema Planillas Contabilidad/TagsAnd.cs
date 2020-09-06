using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    class TagsAnd
    {
        private string tagStartHead = "";
        private string tagEndHead = "";
        private string tagStartLine = "";
        private string tagEndLine = "";

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
    }
}
