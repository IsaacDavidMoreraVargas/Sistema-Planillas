namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_CREATE_FORMULA
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEraseFormula = new System.Windows.Forms.Button();
            this.buttonCharge = new System.Windows.Forms.Button();
            this.comboBoxCharge = new System.Windows.Forms.ComboBox();
            this.comboBoxSave = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonKey2 = new System.Windows.Forms.Button();
            this.buttonKey1 = new System.Windows.Forms.Button();
            this.buttonKey7 = new System.Windows.Forms.Button();
            this.buttonKey3 = new System.Windows.Forms.Button();
            this.buttonKey5 = new System.Windows.Forms.Button();
            this.buttonKey6 = new System.Windows.Forms.Button();
            this.buttonKey4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 274);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(315, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.combox1Add);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.Controls.Add(this.buttonNew, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEraseFormula, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCharge, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCharge, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSave, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEdit, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 304);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 84);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(2, 29);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(68, 49);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "NUEVA FORMULA";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click_1);
            // 
            // buttonEraseFormula
            // 
            this.buttonEraseFormula.Location = new System.Drawing.Point(456, 29);
            this.buttonEraseFormula.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEraseFormula.Name = "buttonEraseFormula";
            this.buttonEraseFormula.Size = new System.Drawing.Size(89, 49);
            this.buttonEraseFormula.TabIndex = 10;
            this.buttonEraseFormula.Text = "BORRAR FORMULA";
            this.buttonEraseFormula.UseVisualStyleBackColor = true;
            this.buttonEraseFormula.Click += new System.EventHandler(this.buttonEliminate_Click);
            // 
            // buttonCharge
            // 
            this.buttonCharge.Location = new System.Drawing.Point(362, 29);
            this.buttonCharge.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCharge.Name = "buttonCharge";
            this.buttonCharge.Size = new System.Drawing.Size(89, 49);
            this.buttonCharge.TabIndex = 2;
            this.buttonCharge.Text = "CARGAR FORMULAS";
            this.buttonCharge.UseVisualStyleBackColor = true;
            this.buttonCharge.Click += new System.EventHandler(this.buttonCharge_Click);
            // 
            // comboBoxCharge
            // 
            this.comboBoxCharge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxCharge.FormattingEnabled = true;
            this.comboBoxCharge.Location = new System.Drawing.Point(362, 3);
            this.comboBoxCharge.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCharge.Name = "comboBoxCharge";
            this.comboBoxCharge.Size = new System.Drawing.Size(89, 21);
            this.comboBoxCharge.TabIndex = 6;
            this.comboBoxCharge.Text = "----";
            // 
            // comboBoxSave
            // 
            this.comboBoxSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSave.FormattingEnabled = true;
            this.comboBoxSave.Location = new System.Drawing.Point(266, 3);
            this.comboBoxSave.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSave.Name = "comboBoxSave";
            this.comboBoxSave.Size = new System.Drawing.Size(89, 21);
            this.comboBoxSave.TabIndex = 8;
            this.comboBoxSave.Text = "----";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(266, 29);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(89, 49);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "GUARDAR";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(77, 30);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(89, 49);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "AÑADIR FORMULA";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(549, 29);
            this.buttonCloseProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(85, 49);
            this.buttonCloseProgram.TabIndex = 4;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.53764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.46236F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.Controls.Add(this.buttonKey2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey4, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(320, 271);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(289, 29);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // buttonKey2
            // 
            this.buttonKey2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey2.Location = new System.Drawing.Point(31, 3);
            this.buttonKey2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey2.Name = "buttonKey2";
            this.buttonKey2.Size = new System.Drawing.Size(24, 22);
            this.buttonKey2.TabIndex = 1;
            this.buttonKey2.Text = "=";
            this.buttonKey2.UseVisualStyleBackColor = true;
            this.buttonKey2.Click += new System.EventHandler(this.buttonKey2_Click);
            // 
            // buttonKey1
            // 
            this.buttonKey1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey1.Location = new System.Drawing.Point(2, 3);
            this.buttonKey1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey1.Name = "buttonKey1";
            this.buttonKey1.Size = new System.Drawing.Size(25, 22);
            this.buttonKey1.TabIndex = 0;
            this.buttonKey1.Text = "(";
            this.buttonKey1.UseVisualStyleBackColor = true;
            this.buttonKey1.Click += new System.EventHandler(this.buttonKey1_Click);
            // 
            // buttonKey7
            // 
            this.buttonKey7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey7.Location = new System.Drawing.Point(204, 3);
            this.buttonKey7.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey7.Name = "buttonKey7";
            this.buttonKey7.Size = new System.Drawing.Size(30, 22);
            this.buttonKey7.TabIndex = 5;
            this.buttonKey7.Text = ")";
            this.buttonKey7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey7.UseVisualStyleBackColor = true;
            this.buttonKey7.Click += new System.EventHandler(this.buttonKey6_Click);
            // 
            // buttonKey3
            // 
            this.buttonKey3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey3.Location = new System.Drawing.Point(59, 3);
            this.buttonKey3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey3.Name = "buttonKey3";
            this.buttonKey3.Size = new System.Drawing.Size(30, 22);
            this.buttonKey3.TabIndex = 2;
            this.buttonKey3.Text = "+";
            this.buttonKey3.UseVisualStyleBackColor = true;
            this.buttonKey3.Click += new System.EventHandler(this.buttonKey3_Click);
            // 
            // buttonKey5
            // 
            this.buttonKey5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey5.Location = new System.Drawing.Point(131, 3);
            this.buttonKey5.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey5.Name = "buttonKey5";
            this.buttonKey5.Size = new System.Drawing.Size(30, 22);
            this.buttonKey5.TabIndex = 4;
            this.buttonKey5.Text = "-";
            this.buttonKey5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey5.UseVisualStyleBackColor = true;
            this.buttonKey5.Click += new System.EventHandler(this.buttonKey5_Click);
            // 
            // buttonKey6
            // 
            this.buttonKey6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey6.Location = new System.Drawing.Point(168, 3);
            this.buttonKey6.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey6.Name = "buttonKey6";
            this.buttonKey6.Size = new System.Drawing.Size(30, 22);
            this.buttonKey6.TabIndex = 6;
            this.buttonKey6.Text = "/";
            this.buttonKey6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey6.UseVisualStyleBackColor = true;
            this.buttonKey6.Click += new System.EventHandler(this.buttonKey6_Click_1);
            // 
            // buttonKey4
            // 
            this.buttonKey4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey4.Location = new System.Drawing.Point(97, 3);
            this.buttonKey4.Margin = new System.Windows.Forms.Padding(2);
            this.buttonKey4.Name = "buttonKey4";
            this.buttonKey4.Size = new System.Drawing.Size(30, 22);
            this.buttonKey4.TabIndex = 3;
            this.buttonKey4.Text = "x";
            this.buttonKey4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey4.UseVisualStyleBackColor = true;
            this.buttonKey4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(3, 226);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(688, 44);
            this.textBox1.TabIndex = 5;
            this.textBox1.WordWrap = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(688, 219);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(172, 30);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(89, 49);
            this.buttonEdit.TabIndex = 12;
            this.buttonEdit.Text = "EDITAR FORMULA";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // GUI_CREATE_FORMULA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 390);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUI_CREATE_FORMULA";
            this.Text = "SISTEMA CREAR FORMULA";
            this.Load += new System.EventHandler(this.GUI_CREATE_FORMULA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCharge;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonKey7;
        private System.Windows.Forms.Button buttonKey5;
        private System.Windows.Forms.Button buttonKey4;
        private System.Windows.Forms.Button buttonKey3;
        private System.Windows.Forms.Button buttonKey2;
        private System.Windows.Forms.Button buttonKey1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonKey6;
        private System.Windows.Forms.ComboBox comboBoxCharge;
        private System.Windows.Forms.ComboBox comboBoxSave;
        private System.Windows.Forms.Button buttonEraseFormula;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
    }
}