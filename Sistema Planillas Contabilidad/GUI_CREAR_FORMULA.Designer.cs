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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonCharge = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.comboBoxUpdate = new System.Windows.Forms.ComboBox();
            this.comboBoxCharge = new System.Windows.Forms.ComboBox();
            this.comboBoxSave = new System.Windows.Forms.ComboBox();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttonRestar = new System.Windows.Forms.Button();
            this.buttonEliminate = new System.Windows.Forms.Button();
            this.comboBoxEliminate = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonKey2 = new System.Windows.Forms.Button();
            this.buttonKey1 = new System.Windows.Forms.Button();
            this.buttonKey7 = new System.Windows.Forms.Button();
            this.buttonKey3 = new System.Windows.Forms.Button();
            this.buttonKey5 = new System.Windows.Forms.Button();
            this.buttonKey6 = new System.Windows.Forms.Button();
            this.buttonKey4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(4, 172);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(384, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.combox1Add);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonNew, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonCharge, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonUpdate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxUpdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCharge, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRestar, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEliminate, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxEliminate, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 241);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 104);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(102, 37);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 60);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "GUARDAR";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(3, 37);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(91, 60);
            this.buttonNew.TabIndex = 3;
            this.buttonNew.Text = "NUEVA FORMULA";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click_1);
            // 
            // buttonCharge
            // 
            this.buttonCharge.Location = new System.Drawing.Point(228, 37);
            this.buttonCharge.Name = "buttonCharge";
            this.buttonCharge.Size = new System.Drawing.Size(107, 60);
            this.buttonCharge.TabIndex = 2;
            this.buttonCharge.Text = "CARGAR FORMULAS";
            this.buttonCharge.UseVisualStyleBackColor = true;
            this.buttonCharge.Click += new System.EventHandler(this.buttonCharge_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(354, 37);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(107, 60);
            this.buttonUpdate.TabIndex = 5;
            this.buttonUpdate.Text = "ELIMINA Y ACTUALIZA FORMULAS";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // comboBoxUpdate
            // 
            this.comboBoxUpdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxUpdate.FormattingEnabled = true;
            this.comboBoxUpdate.Location = new System.Drawing.Point(354, 4);
            this.comboBoxUpdate.Name = "comboBoxUpdate";
            this.comboBoxUpdate.Size = new System.Drawing.Size(117, 24);
            this.comboBoxUpdate.TabIndex = 7;
            this.comboBoxUpdate.Text = "----";
            this.comboBoxUpdate.SelectedValueChanged += new System.EventHandler(this.CellChangedUpdate);
            // 
            // comboBoxCharge
            // 
            this.comboBoxCharge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxCharge.FormattingEnabled = true;
            this.comboBoxCharge.Location = new System.Drawing.Point(228, 4);
            this.comboBoxCharge.Name = "comboBoxCharge";
            this.comboBoxCharge.Size = new System.Drawing.Size(117, 24);
            this.comboBoxCharge.TabIndex = 6;
            this.comboBoxCharge.Text = "----";
            this.comboBoxCharge.SelectedValueChanged += new System.EventHandler(this.CellChangedCharge);
            // 
            // comboBoxSave
            // 
            this.comboBoxSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSave.FormattingEnabled = true;
            this.comboBoxSave.Location = new System.Drawing.Point(102, 4);
            this.comboBoxSave.Name = "comboBoxSave";
            this.comboBoxSave.Size = new System.Drawing.Size(117, 24);
            this.comboBoxSave.TabIndex = 8;
            this.comboBoxSave.Text = "----";
            this.comboBoxSave.SelectedValueChanged += new System.EventHandler(this.CellChangedSave);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(703, 37);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(91, 60);
            this.buttonCloseProgram.TabIndex = 4;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click_1);
            // 
            // buttonRestar
            // 
            this.buttonRestar.Location = new System.Drawing.Point(605, 37);
            this.buttonRestar.Name = "buttonRestar";
            this.buttonRestar.Size = new System.Drawing.Size(91, 60);
            this.buttonRestar.TabIndex = 9;
            this.buttonRestar.Text = "REINICIAR";
            this.buttonRestar.UseVisualStyleBackColor = true;
            this.buttonRestar.Click += new System.EventHandler(this.buttonRestar_Click);
            // 
            // buttonEliminate
            // 
            this.buttonEliminate.Location = new System.Drawing.Point(479, 37);
            this.buttonEliminate.Name = "buttonEliminate";
            this.buttonEliminate.Size = new System.Drawing.Size(107, 60);
            this.buttonEliminate.TabIndex = 10;
            this.buttonEliminate.Text = "ELIMINAR ARCHIVO FORMULA";
            this.buttonEliminate.UseVisualStyleBackColor = true;
            this.buttonEliminate.Click += new System.EventHandler(this.buttonEliminate_Click);
            // 
            // comboBoxEliminate
            // 
            this.comboBoxEliminate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxEliminate.FormattingEnabled = true;
            this.comboBoxEliminate.Location = new System.Drawing.Point(479, 4);
            this.comboBoxEliminate.Name = "comboBoxEliminate";
            this.comboBoxEliminate.Size = new System.Drawing.Size(117, 24);
            this.comboBoxEliminate.TabIndex = 11;
            this.comboBoxEliminate.Text = "----";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.53764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.46236F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.Controls.Add(this.buttonKey2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonKey4, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 202);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(385, 36);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // buttonKey2
            // 
            this.buttonKey2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey2.Location = new System.Drawing.Point(45, 4);
            this.buttonKey2.Name = "buttonKey2";
            this.buttonKey2.Size = new System.Drawing.Size(35, 27);
            this.buttonKey2.TabIndex = 1;
            this.buttonKey2.Text = "=";
            this.buttonKey2.UseVisualStyleBackColor = true;
            this.buttonKey2.Click += new System.EventHandler(this.buttonKey2_Click);
            // 
            // buttonKey1
            // 
            this.buttonKey1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey1.Location = new System.Drawing.Point(3, 4);
            this.buttonKey1.Name = "buttonKey1";
            this.buttonKey1.Size = new System.Drawing.Size(36, 27);
            this.buttonKey1.TabIndex = 0;
            this.buttonKey1.Text = "(";
            this.buttonKey1.UseVisualStyleBackColor = true;
            this.buttonKey1.Click += new System.EventHandler(this.buttonKey1_Click);
            // 
            // buttonKey7
            // 
            this.buttonKey7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey7.Location = new System.Drawing.Point(279, 4);
            this.buttonKey7.Name = "buttonKey7";
            this.buttonKey7.Size = new System.Drawing.Size(40, 27);
            this.buttonKey7.TabIndex = 5;
            this.buttonKey7.Text = ")";
            this.buttonKey7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey7.UseVisualStyleBackColor = true;
            this.buttonKey7.Click += new System.EventHandler(this.buttonKey6_Click);
            // 
            // buttonKey3
            // 
            this.buttonKey3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey3.Location = new System.Drawing.Point(86, 4);
            this.buttonKey3.Name = "buttonKey3";
            this.buttonKey3.Size = new System.Drawing.Size(40, 27);
            this.buttonKey3.TabIndex = 2;
            this.buttonKey3.Text = "+";
            this.buttonKey3.UseVisualStyleBackColor = true;
            this.buttonKey3.Click += new System.EventHandler(this.buttonKey3_Click);
            // 
            // buttonKey5
            // 
            this.buttonKey5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey5.Location = new System.Drawing.Point(182, 4);
            this.buttonKey5.Name = "buttonKey5";
            this.buttonKey5.Size = new System.Drawing.Size(40, 27);
            this.buttonKey5.TabIndex = 4;
            this.buttonKey5.Text = "-";
            this.buttonKey5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey5.UseVisualStyleBackColor = true;
            this.buttonKey5.Click += new System.EventHandler(this.buttonKey5_Click);
            // 
            // buttonKey6
            // 
            this.buttonKey6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey6.Location = new System.Drawing.Point(231, 4);
            this.buttonKey6.Name = "buttonKey6";
            this.buttonKey6.Size = new System.Drawing.Size(40, 27);
            this.buttonKey6.TabIndex = 6;
            this.buttonKey6.Text = "/";
            this.buttonKey6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey6.UseVisualStyleBackColor = true;
            this.buttonKey6.Click += new System.EventHandler(this.buttonKey6_Click_1);
            // 
            // buttonKey4
            // 
            this.buttonKey4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonKey4.Location = new System.Drawing.Point(136, 4);
            this.buttonKey4.Name = "buttonKey4";
            this.buttonKey4.Size = new System.Drawing.Size(40, 27);
            this.buttonKey4.TabIndex = 3;
            this.buttonKey4.Text = "x";
            this.buttonKey4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonKey4.UseVisualStyleBackColor = true;
            this.buttonKey4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(807, 164);
            this.textBox1.TabIndex = 5;
            this.textBox1.WordWrap = false;
            // 
            // GUI_CREATE_FORMULA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 357);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox comboBoxCharge;
        private System.Windows.Forms.ComboBox comboBoxUpdate;
        private System.Windows.Forms.ComboBox comboBoxSave;
        private System.Windows.Forms.Button buttonRestar;
        private System.Windows.Forms.Button buttonEliminate;
        private System.Windows.Forms.ComboBox comboBoxEliminate;
    }
}