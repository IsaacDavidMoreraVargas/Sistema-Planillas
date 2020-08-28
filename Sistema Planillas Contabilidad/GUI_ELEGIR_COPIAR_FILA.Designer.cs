namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_ELEGIR_COPIAR_FILA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxWeek = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxData = new System.Windows.Forms.ComboBox();
            this.comboBoxReplace = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonQuickView = new System.Windows.Forms.Button();
            this.buttonImportData = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.10614F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.89386F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 338F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDepartment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxMonth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxWeek, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxData, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxReplace, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonQuickView, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonImportData, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.16279F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.83721F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 292);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEPARTAMENTO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(143, 21);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(209, 24);
            this.comboBoxDepartment.TabIndex = 1;
            this.comboBoxDepartment.Text = "-----";
            this.comboBoxDepartment.SelectedValueChanged += new System.EventHandler(this.LoadDepartment);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "MES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(143, 85);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(202, 24);
            this.comboBoxMonth.TabIndex = 3;
            this.comboBoxMonth.Text = "-----";
            this.comboBoxMonth.SelectedValueChanged += new System.EventHandler(this.LoadMonth);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 51);
            this.label3.TabIndex = 4;
            this.label3.Text = "SEMANA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxWeek
            // 
            this.comboBoxWeek.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxWeek.FormattingEnabled = true;
            this.comboBoxWeek.Location = new System.Drawing.Point(143, 148);
            this.comboBoxWeek.Name = "comboBoxWeek";
            this.comboBoxWeek.Size = new System.Drawing.Size(202, 24);
            this.comboBoxWeek.TabIndex = 5;
            this.comboBoxWeek.Text = "-----";
            this.comboBoxWeek.SelectedValueChanged += new System.EventHandler(this.LoadWeek);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 51);
            this.label4.TabIndex = 6;
            this.label4.Text = "DATO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxData
            // 
            this.comboBoxData.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxData.FormattingEnabled = true;
            this.comboBoxData.Location = new System.Drawing.Point(143, 209);
            this.comboBoxData.Name = "comboBoxData";
            this.comboBoxData.Size = new System.Drawing.Size(202, 24);
            this.comboBoxData.TabIndex = 7;
            this.comboBoxData.Text = "-----";
            this.comboBoxData.SelectedValueChanged += new System.EventHandler(this.LoadData);
            // 
            // comboBoxReplace
            // 
            this.comboBoxReplace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxReplace.FormattingEnabled = true;
            this.comboBoxReplace.Location = new System.Drawing.Point(440, 21);
            this.comboBoxReplace.Name = "comboBoxReplace";
            this.comboBoxReplace.Size = new System.Drawing.Size(202, 24);
            this.comboBoxReplace.TabIndex = 9;
            this.comboBoxReplace.Text = "-----";
            this.comboBoxReplace.SelectedValueChanged += new System.EventHandler(this.LoadReplace);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(361, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 51);
            this.label5.TabIndex = 8;
            this.label5.Text = "A";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonQuickView
            // 
            this.buttonQuickView.Location = new System.Drawing.Point(440, 69);
            this.buttonQuickView.Name = "buttonQuickView";
            this.buttonQuickView.Size = new System.Drawing.Size(140, 57);
            this.buttonQuickView.TabIndex = 10;
            this.buttonQuickView.Text = "VISTA RAPIDA";
            this.buttonQuickView.UseVisualStyleBackColor = true;
            this.buttonQuickView.Click += new System.EventHandler(this.buttonQuickView_Click);
            // 
            // buttonImportData
            // 
            this.buttonImportData.Location = new System.Drawing.Point(440, 132);
            this.buttonImportData.Name = "buttonImportData";
            this.buttonImportData.Size = new System.Drawing.Size(140, 56);
            this.buttonImportData.TabIndex = 11;
            this.buttonImportData.Text = "INICIAR IMPORTACION";
            this.buttonImportData.UseVisualStyleBackColor = true;
            this.buttonImportData.Click += new System.EventHandler(this.buttonImportData_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(440, 194);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(140, 54);
            this.buttonCloseProgram.TabIndex = 12;
            this.buttonCloseProgram.Text = "CERRAR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // GUI_ELEGIR_COPIAR_FILA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 316);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI_ELEGIR_COPIAR_FILA";
            this.Text = "SISTEMA IMPORTAR DATOS FILAS";
            this.Load += new System.EventHandler(this.GUI_ELEGIR_COPIAR_FILA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxData;
        private System.Windows.Forms.ComboBox comboBoxReplace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonQuickView;
        private System.Windows.Forms.Button buttonImportData;
        private System.Windows.Forms.Button buttonCloseProgram;
    }
}