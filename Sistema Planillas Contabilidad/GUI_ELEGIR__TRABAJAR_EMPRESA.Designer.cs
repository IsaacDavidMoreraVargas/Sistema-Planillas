﻿namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_ELEGIR__TRABAJAR_EMPRESA
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewCompany = new System.Windows.Forms.ListView();
            this.EMPRESAS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMonth = new System.Windows.Forms.ListView();
            this.MESES = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDeparment = new System.Windows.Forms.ListView();
            this.DEPARTAMENTOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReturnProgram = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGenerateSits = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.listViewCompany, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewMonth, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listViewDeparment, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(508, 454);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listViewCompany
            // 
            this.listViewCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EMPRESAS});
            this.listViewCompany.GridLines = true;
            this.listViewCompany.HideSelection = false;
            this.listViewCompany.Location = new System.Drawing.Point(2, 2);
            this.listViewCompany.Margin = new System.Windows.Forms.Padding(2);
            this.listViewCompany.Name = "listViewCompany";
            this.listViewCompany.Size = new System.Drawing.Size(163, 450);
            this.listViewCompany.TabIndex = 0;
            this.listViewCompany.UseCompatibleStateImageBehavior = false;
            this.listViewCompany.SelectedIndexChanged += new System.EventHandler(this.listViewCompany_SelectedIndexChanged);
            // 
            // listViewMonth
            // 
            this.listViewMonth.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MESES});
            this.listViewMonth.GridLines = true;
            this.listViewMonth.HideSelection = false;
            this.listViewMonth.Location = new System.Drawing.Point(335, 2);
            this.listViewMonth.Margin = new System.Windows.Forms.Padding(2);
            this.listViewMonth.Name = "listViewMonth";
            this.listViewMonth.Size = new System.Drawing.Size(162, 450);
            this.listViewMonth.TabIndex = 3;
            this.listViewMonth.UseCompatibleStateImageBehavior = false;
            this.listViewMonth.Visible = false;
            this.listViewMonth.SelectedIndexChanged += new System.EventHandler(this.listViewMonth_SelectedIndexChanged);
            // 
            // listViewDeparment
            // 
            this.listViewDeparment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DEPARTAMENTOS});
            this.listViewDeparment.GridLines = true;
            this.listViewDeparment.HideSelection = false;
            this.listViewDeparment.Location = new System.Drawing.Point(169, 2);
            this.listViewDeparment.Margin = new System.Windows.Forms.Padding(2);
            this.listViewDeparment.Name = "listViewDeparment";
            this.listViewDeparment.Size = new System.Drawing.Size(162, 450);
            this.listViewDeparment.TabIndex = 1;
            this.listViewDeparment.UseCompatibleStateImageBehavior = false;
            this.listViewDeparment.Visible = false;
            this.listViewDeparment.SelectedIndexChanged += new System.EventHandler(this.listViewDeparment_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(2, 225);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(81, 70);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "INICIAR";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonReturnProgram
            // 
            this.buttonReturnProgram.Location = new System.Drawing.Point(2, 301);
            this.buttonReturnProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturnProgram.Name = "buttonReturnProgram";
            this.buttonReturnProgram.Size = new System.Drawing.Size(81, 70);
            this.buttonReturnProgram.TabIndex = 2;
            this.buttonReturnProgram.Text = "REGRESAR";
            this.buttonReturnProgram.UseVisualStyleBackColor = true;
            this.buttonReturnProgram.Click += new System.EventHandler(this.buttonReturnProgram_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(2, 376);
            this.buttonCloseProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(81, 70);
            this.buttonCloseProgram.TabIndex = 4;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCloseProgram, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.buttonReturnProgram, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonGenerateSits, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(522, 11);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.73822F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.26178F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(87, 454);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // buttonGenerateSits
            // 
            this.buttonGenerateSits.Location = new System.Drawing.Point(2, 149);
            this.buttonGenerateSits.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGenerateSits.Name = "buttonGenerateSits";
            this.buttonGenerateSits.Size = new System.Drawing.Size(81, 69);
            this.buttonGenerateSits.TabIndex = 5;
            this.buttonGenerateSits.Text = "GENERAR ASIENTOS";
            this.buttonGenerateSits.UseVisualStyleBackColor = true;
            this.buttonGenerateSits.Click += new System.EventHandler(this.buttonGenerateSits_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(81, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // GUI_ELEGIR__TRABAJAR_EMPRESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(615, 479);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_ELEGIR__TRABAJAR_EMPRESA";
            this.Text = "SISTEMA ELEGIR EMPRESA";
            this.Load += new System.EventHandler(this.GUI_ELEGIR__TRABAJAR_EMPRESA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewCompany;
        private System.Windows.Forms.ListView listViewDeparment;
        private System.Windows.Forms.ColumnHeader EMPRESAS;
        private System.Windows.Forms.ColumnHeader DEPARTAMENTOS;
        private System.Windows.Forms.ListView listViewMonth;
        private System.Windows.Forms.ColumnHeader MESES;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonReturnProgram;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonGenerateSits;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
