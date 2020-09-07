﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    public class FoldersInsideCompany
    {
        private string valueConfiguration = "";
        private string ValueExclusiveData = "";
        private string ValueSits = "";
        private string ValueTemplate = "";
        private string CoreValueExtraConfigurations = "";

        public string isCoreExtraConfigurations
        {
            get
            {
                return CoreValueExtraConfigurations;
            }
            set
            {
                CoreValueExtraConfigurations = value;
            }
        }

        public string isConfiguration
        {
            get
            {
                return valueConfiguration;
            }
            set
            {
                valueConfiguration = value;
            }
        }

        public string isExclusiveData
        {
            get
            {
                return ValueExclusiveData;
            }
            set
            {
                ValueExclusiveData = value;
            }
        }

        public string isSits
        {
            get
            {
                return ValueSits;
            }
            set
            {
                ValueSits = value;
            }
        }

        public string isTemplate
        {
            get
            {
                return ValueTemplate;
            }
            set
            {
                ValueTemplate = value;
            }
        }
    }
}
