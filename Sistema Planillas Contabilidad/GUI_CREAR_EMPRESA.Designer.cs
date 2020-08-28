namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_CREAR_EMPRESA
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameCompany = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxChargeTemplate = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxDepartment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddDeparment = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.DEPARTAMENTOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonGenerateCompany = new System.Windows.Forms.Button();
            this.buttonReturnProgram = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttoneEraseDepartment = new System.Windows.Forms.Button();
            this.textBoxLegalID = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOMBRE EMPRESA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxNameCompany
            // 
            this.textBoxNameCompany.Location = new System.Drawing.Point(97, 3);
            this.textBoxNameCompany.Multiline = true;
            this.textBoxNameCompany.Name = "textBoxNameCompany";
            this.textBoxNameCompany.Size = new System.Drawing.Size(563, 56);
            this.textBoxNameCompany.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.17798F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.82202F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxNameCompany, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(663, 62);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxFrom, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBoxTo, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLegalID, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 90);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(673, 62);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(276, 15);
            this.comboBoxTo.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(111, 24);
            this.comboBoxTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 56);
            this.label3.TabIndex = 2;
            this.label3.Text = "DE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(63, 15);
            this.comboBoxFrom.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(111, 24);
            this.comboBoxFrom.TabIndex = 4;
            this.comboBoxFrom.SelectedValueChanged += new System.EventHandler(this.ReloadDataComboX);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(186, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 56);
            this.label4.TabIndex = 3;
            this.label4.Text = "HASTA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBoxChargeTemplate, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 169);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(495, 62);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 56);
            this.label5.TabIndex = 2;
            this.label5.Text = "CARGAR PLANTILLA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxChargeTemplate
            // 
            this.comboBoxChargeTemplate.FormattingEnabled = true;
            this.comboBoxChargeTemplate.Location = new System.Drawing.Point(123, 15);
            this.comboBoxChargeTemplate.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.comboBoxChargeTemplate.Name = "comboBoxChargeTemplate";
            this.comboBoxChargeTemplate.Size = new System.Drawing.Size(368, 24);
            this.comboBoxChargeTemplate.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.09091F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.90909F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel4.Controls.Add(this.textBoxDepartment, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonAddDeparment, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(13, 248);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(540, 62);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // textBoxDepartment
            // 
            this.textBoxDepartment.Location = new System.Drawing.Point(171, 3);
            this.textBoxDepartment.Multiline = true;
            this.textBoxDepartment.Name = "textBoxDepartment";
            this.textBoxDepartment.Size = new System.Drawing.Size(257, 56);
            this.textBoxDepartment.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 62);
            this.label6.TabIndex = 0;
            this.label6.Text = "AÑADIR DEPARTAMENTO";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAddDeparment
            // 
            this.buttonAddDeparment.Location = new System.Drawing.Point(434, 3);
            this.buttonAddDeparment.Name = "buttonAddDeparment";
            this.buttonAddDeparment.Size = new System.Drawing.Size(94, 56);
            this.buttonAddDeparment.TabIndex = 2;
            this.buttonAddDeparment.Text = "Añadir";
            this.buttonAddDeparment.UseVisualStyleBackColor = true;
            this.buttonAddDeparment.Click += new System.EventHandler(this.buttonAddDeparment_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DEPARTAMENTOS});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.listView1.Location = new System.Drawing.Point(12, 327);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(541, 176);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.Visible = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.IndexChangeViewList);
            // 
            // buttonGenerateCompany
            // 
            this.buttonGenerateCompany.Location = new System.Drawing.Point(574, 293);
            this.buttonGenerateCompany.Name = "buttonGenerateCompany";
            this.buttonGenerateCompany.Size = new System.Drawing.Size(102, 66);
            this.buttonGenerateCompany.TabIndex = 7;
            this.buttonGenerateCompany.Text = "Generar";
            this.buttonGenerateCompany.UseVisualStyleBackColor = true;
            this.buttonGenerateCompany.Click += new System.EventHandler(this.buttonGenerateCompany_Click);
            // 
            // buttonReturnProgram
            // 
            this.buttonReturnProgram.Location = new System.Drawing.Point(574, 365);
            this.buttonReturnProgram.Name = "buttonReturnProgram";
            this.buttonReturnProgram.Size = new System.Drawing.Size(102, 66);
            this.buttonReturnProgram.TabIndex = 8;
            this.buttonReturnProgram.Text = "Regresar";
            this.buttonReturnProgram.UseVisualStyleBackColor = true;
            this.buttonReturnProgram.Click += new System.EventHandler(this.buttonReturnProgram_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(574, 437);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(102, 66);
            this.buttonCloseProgram.TabIndex = 9;
            this.buttonCloseProgram.Text = "Salir";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // buttoneEraseDepartment
            // 
            this.buttoneEraseDepartment.Location = new System.Drawing.Point(12, 510);
            this.buttoneEraseDepartment.Name = "buttoneEraseDepartment";
            this.buttoneEraseDepartment.Size = new System.Drawing.Size(152, 48);
            this.buttoneEraseDepartment.TabIndex = 10;
            this.buttoneEraseDepartment.Text = "Eliminar Departamento";
            this.buttoneEraseDepartment.UseVisualStyleBackColor = true;
            this.buttoneEraseDepartment.Visible = false;
            this.buttoneEraseDepartment.Click += new System.EventHandler(this.buttonEraseDepartment_Click);
            // 
            // textBoxLegalID
            // 
            this.textBoxLegalID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLegalID.Location = new System.Drawing.Point(542, 13);
            this.textBoxLegalID.Multiline = true;
            this.textBoxLegalID.Name = "textBoxLegalID";
            this.textBoxLegalID.Size = new System.Drawing.Size(128, 36);
            this.textBoxLegalID.TabIndex = 11;
            this.textBoxLegalID.WordWrap = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(394, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 62);
            this.label7.TabIndex = 13;
            this.label7.Text = "CEDULA JURIDICA";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GUI_CREAR_EMPRESA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(766, 590);
            this.Controls.Add(this.buttoneEraseDepartment);
            this.Controls.Add(this.buttonCloseProgram);
            this.Controls.Add(this.buttonReturnProgram);
            this.Controls.Add(this.buttonGenerateCompany);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI_CREAR_EMPRESA";
            this.Text = "SISTEMA MULTIPLES OPCIONES EMPRESA";
            this.Load += new System.EventHandler(this.GUI_CREAR_EMPRESA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNameCompany;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxChargeTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox textBoxDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddDeparment;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonGenerateCompany;
        private System.Windows.Forms.Button buttonReturnProgram;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.ColumnHeader DEPARTAMENTOS;
        private System.Windows.Forms.Button buttoneEraseDepartment;
        private System.Windows.Forms.TextBox textBoxLegalID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label7;
    }
}
