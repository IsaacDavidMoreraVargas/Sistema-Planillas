using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Planillas_Contabilidad
{
    public class SpecificAndCorePaths
    {
        //Core Folders
        private string pathOfFolderSistemaPlanillas;
        private string pathOfCompaniesFolderSistemaPlanillas;
        private string pathOfConfigurationFolderSistemaPlanillas;
        private string pathOfPicturesFolderSistemaPlanillas;
       
        public string CorePathOfFolderSistemaPlanillas
        {
            get 
            {
                return pathOfFolderSistemaPlanillas;
            }
            set 
            {
                pathOfFolderSistemaPlanillas = value;
            }
        }

        public string CorePathOfCompaniesFolderSistemaPlanillas
        {
            get
            {
                return pathOfCompaniesFolderSistemaPlanillas;
            }
            set
            {
                pathOfCompaniesFolderSistemaPlanillas = value;
            }
        }

        public string CorePathOfConfigurationFolderSistemaPlanillas
        {
            get
            {
                return pathOfConfigurationFolderSistemaPlanillas;
            }
            set
            {
                pathOfConfigurationFolderSistemaPlanillas = value;
            }
        }

        public string CorePathOfPicturesFolderSistemaPlanillas
        {
            get
            {
                return pathOfPicturesFolderSistemaPlanillas;
            }
            set
            {
                pathOfPicturesFolderSistemaPlanillas = value;
            }
        }

        //Specific Folders
        private string pathOfConfigurationFolderAvoidData;
        private string pathOfConfigurationFolderCodesSits;
        private string pathOfConfigurationFolderDaysOfMoths;
        private string pathOfConfigurationFolderFormulas;
        private string pathOfConfigurationFolderSits;
        private string pathOfConfigurationFolderTemplates;
        
        public string SpecificPathOfConfigurationFolderAvoidData
        {
            get
            {
                return pathOfConfigurationFolderAvoidData;
            }
            set
            {
                pathOfConfigurationFolderAvoidData = value;
            }
        }

        public string SpecificPathOfConfigurationFolderCodesSits
        {
            get
            {
                return pathOfConfigurationFolderCodesSits;
            }
            set
            {
                pathOfConfigurationFolderCodesSits = value;
            }
        }

        public string SpecificPathOfConfigurationFolderDaysOfMoths
        {
            get
            {
                return pathOfConfigurationFolderDaysOfMoths;
            }
            set
            {
                pathOfConfigurationFolderDaysOfMoths = value;
            }
        }

        public string SpecificPathOfConfigurationFolderFormulas
        {
            get
            {
                return pathOfConfigurationFolderFormulas;
            }
            set
            {
                pathOfConfigurationFolderFormulas = value;
            }
        }

        public string SpecificPathOfConfigurationFolderSits
        {
            get
            {
                return pathOfConfigurationFolderSits;
            }
            set
            {
                pathOfConfigurationFolderSits = value;
            }
        }


        public string SpecificPathOfConfigurationFolderTemplates
        {
            get
            {
                return pathOfConfigurationFolderTemplates;
            }
            set
            {
                pathOfConfigurationFolderTemplates = value;
            }
        }
    }
}
