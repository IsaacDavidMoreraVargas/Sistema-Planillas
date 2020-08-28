using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_MENU_INICIO : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {
        public GUI_MENU_INICIO()
        {
            InitializeComponent();
        }

        private void GUI_MENU_INICIO_Load(object sender, EventArgs e)
        {
            createFolderStar();
        }

        private void createFolderStar()
        {
            string[] generalList = { "Companies", "configuration"};
            string[] foldersList = { "AvoidData", "DaysOfMoths", "Formulas", "Sits", "Templates"};
            string pathActual = Directory.GetCurrentDirectory();
            pathActual = pathActual.Replace("\\bin\\Debug", "");
            string generalPathOnTime = "";
            for (int item = 0; item < generalList.Length; item++)
            {
                if (item == 0)
                {
                    string general = pathActual + "\\" + generalList[item];
                    if (!Directory.Exists(general))
                    {
                        Directory.CreateDirectory(general);
                    }
                }
                else
                {
                    generalPathOnTime = pathActual + "\\" + generalList[item];
                    if (!Directory.Exists(generalPathOnTime))
                    {
                        Directory.CreateDirectory(generalPathOnTime);
                    }
                }
            }
            for (int item = 0; item < foldersList.Length; item++)
            {
                string general = generalPathOnTime + "\\" + foldersList[item];
                if (!Directory.Exists(general))
                {
                    Directory.CreateDirectory(general);
                }
            }
        }

        private void buttonCreateCompanySystem_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditTemplate_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_EDITAR_PLANTILLA callGuiEdit = new GUI_MENU_EDITAR_PLANTILLA();
            callGuiEdit.ShowDialog();
            this.Close();
        }
        private void buttonWorkWithCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_ELEGIR__TRABAJAR_EMPRESA callingWorkCompany = new GUI_ELEGIR__TRABAJAR_EMPRESA();
            callingWorkCompany.ShowDialog();
            this.Close();
        }

        private void buttonDuplicateCopyEliminateCompany_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY callGuiDuplicateCopyEliminate = new GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY();
            callGuiDuplicateCopyEliminate.ShowDialog();
            this.Close();
        }
    }
}
