using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sistema_Planillas_Contabilidad
{
    public partial class GUI_ELEGIR__TRABAJAR_EMPRESA : Sistema_Planillas_Contabilidad.MACHOTE_GENERAL_MENUS
    {
        string companyOntime = "";
        string deparmentOntime = "";
        string monthOnTime = "";
        string weekOntime = "";
        string fileOnTime = "";
        bool boleanCompany = false;
        bool boleanDeparment = false;
        bool boleanMonth = false;
        bool boleanWeek = false;
        bool boleanFile = false;
        string FinalPath = "";
        string avoid = "configuration";
        string avoid2 = "Sits";
        string avoid3 = "exclusiveData";
        public GUI_ELEGIR__TRABAJAR_EMPRESA()
        {
            InitializeComponent();
        }

        private void GUI_ELEGIR__TRABAJAR_EMPRESA_Load(object sender, EventArgs e)
        {
            chargeData();
        }
        private void chargeData()
        {
            buttonQuickView.Visible = false;
            buttonStart.Visible = false;
            FinalPath = Directory.GetCurrentDirectory();
            FinalPath = FinalPath.Replace("\\bin\\Debug", "\\Companies");
            listViewCompany.View = View.Details;
            listViewCompany.Columns[0].Width = listViewCompany.Width;
            listViewCompany.Columns[0].Text = "EMPRESAS";
            listViewDeparment.View = View.Details;
            listViewDeparment.Columns[0].Width = listViewDeparment.Width;
            listViewDeparment.Columns[0].Text = "DEPARTAMENTOS";
            listViewMonth.View = View.Details;
            listViewMonth.Columns[0].Width = listViewMonth.Width;
            listViewMonth.Columns[0].Text = "MESES";
            listViewWeek.View = View.Details;
            listViewWeek.Columns[0].Width = listViewWeek.Width;
            listViewWeek.Columns[0].Text = "SEMANAS";
            try
            {
                string[] empresas = Directory.GetDirectories(FinalPath);
                foreach (string empresa in empresas)
                {
                    if (empresa == avoid || empresa.Contains(avoid2) || empresa == avoid3)
                    {

                    }
                    else
                    {
                        string addCompany = empresa;
                        addCompany = addCompany.Replace(FinalPath, "");
                        addCompany = addCompany.Replace("\\", "");
                        addCompany = addCompany.Replace("_", " ");
                        listViewCompany.Items.Add(addCompany);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("NO EXISTEN EMPRESAS");
            }
        }

        int IndexViewCompany = 0;
        private void listViewCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            companyOntime = "";
            deparmentOntime = "";
            monthOnTime = "";
            weekOntime = "";
            fileOnTime = "";
            listViewDeparment.Items.Clear();
            listViewMonth.Items.Clear();
            listViewWeek.Items.Clear();
            listViewMonth.Visible = false;
            listViewDeparment.Visible = false;
            listViewWeek.Visible = false;

            if (listViewCompany.FocusedItem == null)
            {
                return;
            }else
            {
                IndexViewCompany = listViewCompany.FocusedItem.Index;

                if (listViewCompany.Items[IndexViewCompany].Text == "" || listViewCompany.Items[IndexViewCompany].Text.Contains("EMPRESAS"))
                {
                    MessageBox.Show("SELECCIONA UNA COMPAÑIA VALIDA");
                }
                else
                {
                    boleanCompany = true;
                    listViewDeparment.Visible = true;
                    string company = listViewCompany.Items[IndexViewCompany].Text;
                    company = company.Replace(" ", "_");
                    companyOntime = company;
                    //MessageBox.Show(companyOntime);
                    string Charge= FinalPath + "\\" + company;
                    string[] departments = Directory.GetDirectories(Charge);
                    foreach (string deparment in departments)
                    {
                        string addDepartment = deparment;
                        addDepartment = addDepartment.Replace(Charge, "");
                        addDepartment = addDepartment.Replace("\\", "");
                        addDepartment = addDepartment.Replace("_", " ");
                        if (addDepartment == avoid || addDepartment.Contains( avoid2) || addDepartment == avoid3)
                        {

                        }
                        else
                        {
                            listViewDeparment.Items.Add(addDepartment);
                        }
                    }
                }
            }

        }

        int IndexViewDeparment = 0;
        private void listViewDeparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewMonth.Items.Clear();
            listViewWeek.Items.Clear();
            listViewWeek.Visible = false;
            if (listViewDeparment.FocusedItem == null)
            {
                return;
            }
            else
            {
                IndexViewDeparment= listViewDeparment.FocusedItem.Index;

                if (listViewDeparment.Items[IndexViewDeparment].Text == "" || listViewDeparment.Items[IndexViewDeparment].Text.Contains("DEPARTAMENTOS"))
                {
                    MessageBox.Show("SELECCIONA UN DEPARTAMENTO VALIDO");
                }
                else
                {
                    boleanDeparment = true;
                    listViewMonth.Visible = true;
                    string department = listViewDeparment.Items[IndexViewDeparment].Text;
                    department = department.Replace(" ", "_");
                    deparmentOntime = department;
                    string Charge= FinalPath + "\\" + companyOntime + "\\" + department;
                    string[] months = Directory.GetDirectories(Charge);
                    foreach (string month in months)
                    {
                        string addMonth = month;
                        addMonth = addMonth.Replace(Charge, "");
                        addMonth = addMonth.Replace("\\", "");
                        addMonth = addMonth.Replace("_", " ");
                        listViewMonth.Items.Add(addMonth);
                    }

                }
            }
        }

        int IndexViewMont = 0;
        private void listViewMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewWeek.Items.Clear();
            if (listViewMonth.FocusedItem == null)
            {
                return;
            }
            else
            {
                IndexViewMont = listViewMonth.FocusedItem.Index;

                if (listViewMonth.Items[IndexViewMont].Text == "" || listViewMonth.Items[IndexViewMont].Text.Contains("MESES"))
                {
                    MessageBox.Show("SELECCIONA UN MES VALIDO");
                }
                else
                {
                    boleanMonth = true;
                    listViewWeek.Visible = true;
                    string month = listViewMonth.Items[IndexViewMont].Text;
                    month = month.Replace(" ", "_");
                    monthOnTime = month;
                    string Charge= FinalPath + "\\" + companyOntime + "\\" + deparmentOntime + "\\" + month;
                    string[] weeks = Directory.GetDirectories(Charge);
                    foreach (string week in weeks)
                    {
                        string addWeek = week;
                        addWeek = addWeek.Replace(Charge, "");
                        addWeek = addWeek.Replace("\\", "");
                        addWeek = addWeek.Replace("_", " ");
                        listViewWeek.Items.Add(addWeek);
                    }

                }
            }
        }

        int IndexViewWeek = 0;
        private void listViewWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewWeek.FocusedItem == null)
            {
                return;
            }
            else
            {
                IndexViewWeek = listViewWeek.FocusedItem.Index;

                if (listViewWeek.Items[IndexViewWeek].Text == "" || listViewWeek.Items[IndexViewWeek].Text.Contains("SEMANAS"))
                {
                    MessageBox.Show("SELECCIONA UNA SEMANA VALIDA");
                }
                else
                {           
                    boleanWeek = true;
                    string week = listViewWeek.Items[IndexViewWeek].Text;
                    week = week.Replace(" ", "_");
                    weekOntime = week;
                    string Charge= FinalPath + "\\" + companyOntime + "\\" + deparmentOntime + "\\" + monthOnTime + "\\" + week;
                    string[] files = Directory.GetFiles(Charge);
                    foreach (string file in files)
                    {
                        boleanFile = true;
                        string momentaneum = file.Replace(Charge, "");
                        momentaneum = momentaneum.Replace("\\", "");
                        fileOnTime = momentaneum;
                    }

                }
            }
            buttonQuickView.Visible = true;
            buttonStart.Visible = true;
        }

        

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (listViewCompany.Visible == true && listViewDeparment.Visible == true && listViewMonth.Visible == true && listViewWeek.Visible == true)
            {
                string sendPath = FinalPath + "\\" + companyOntime + "\\" + deparmentOntime + "\\" + monthOnTime + "\\" + weekOntime + "\\" + fileOnTime;
                boleanCompany = false;
                boleanDeparment = false;
                boleanMonth = false;
                boleanWeek = false;
                boleanFile = false;
                GUI_WORK_COMPANY callingQuickView = new GUI_WORK_COMPANY();
                callingQuickView.PathToSave(companyOntime,deparmentOntime, monthOnTime, weekOntime, fileOnTime,sendPath);
                callingQuickView.ShowDialog();
            }
            else 
            {
                buttonQuickView.Visible = false;
                buttonStart.Visible = false;
                string MessageFalse = "NO HA SELECCIONADO TODOS LOS DATOS NECESARIOS\nFALTA:";
                if (boleanCompany == false) 
                {
                    MessageFalse += "\n-NOMBRE COMPAÑIA";
                    boleanCompany = false;
                }
                if (boleanDeparment == false)
                {
                    MessageFalse += "\n-DEPARTAMENTO";
                    boleanDeparment = false;
                }
                if (boleanMonth == false)
                {
                    MessageFalse += "\n-MES";
                    boleanMonth = false;
                }
                if (boleanWeek == false)
                {
                    MessageFalse += "\n-SEMANA";
                    boleanWeek = false;
                }
                if (boleanFile == false)
                {
                    MessageFalse += "\n-ARCHIVO INEXISTENTE";
                    boleanFile = false;
                }
                MessageBox.Show(MessageFalse);
            }
            
        }

        private void buttonReturnProgram_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_MENU_INICIO callingPrincipalMenu = new GUI_MENU_INICIO();
            callingPrincipalMenu.ShowDialog();
            this.Close();
        }

        private void buttonQuickView_Click(object sender, EventArgs e)
        {
            string sendPath = FinalPath + "\\" + companyOntime + "\\" + deparmentOntime + "\\" + monthOnTime + "\\" + weekOntime + "\\" + fileOnTime;
            GUI_VISTA_RAPIDA callingQuickView = new GUI_VISTA_RAPIDA();
            callingQuickView.PathToSave(sendPath);
            callingQuickView.ShowDialog();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGenerateTotal_Click(object sender, EventArgs e)
        {
            if (boleanCompany == false)
            {
                MessageBox.Show("NO POSIBLE, SELECCIONA UNA EMPRESA");
            }
            else
            {
                GUI_ELEGIR_GENERAR_TOTALES CallGenerateTotals = new GUI_ELEGIR_GENERAR_TOTALES();
                string typeTotal = "Totals";
                CallGenerateTotals.receivedWork(typeTotal);
                CallGenerateTotals.PathToSave(companyOntime, deparmentOntime, monthOnTime, weekOntime, fileOnTime);
                CallGenerateTotals.ShowDialog();
            }
        }

        private void buttonGenerateSits_Click(object sender, EventArgs e)
        {
            if (boleanCompany == false)
            {
                MessageBox.Show("NO POSIBLE, SELECCIONA UNA EMPRESA");
            }
            else
            {
                //GUI_SELECCIONAR_ASIENTOS CallGenerateSits = new GUI_SELECCIONAR_ASIENTOS();
                GUI_ELEGIR_GENERAR_TOTALES CallGenerateSits = new GUI_ELEGIR_GENERAR_TOTALES();
                string typeSits = "Sits";
                CallGenerateSits.receivedWork(typeSits);
                CallGenerateSits.PathToSave(companyOntime, deparmentOntime, monthOnTime, weekOntime, fileOnTime);
                CallGenerateSits.ShowDialog();
            }
        }
    }
}
