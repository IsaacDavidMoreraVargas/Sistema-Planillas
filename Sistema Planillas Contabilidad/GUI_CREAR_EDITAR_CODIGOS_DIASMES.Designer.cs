namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_CREAR_EDITAR_CODIGOS_DIASMES
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
            this.buttonAddColumn = new System.Windows.Forms.Button();
            this.buttonEraseColumn = new System.Windows.Forms.Button();
            this.buttonMoveBackColum = new System.Windows.Forms.Button();
            this.buttonMoveNextColumn = new System.Windows.Forms.Button();
            this.buttonUpdateTemplate = new System.Windows.Forms.Button();
            this.buttonReturnScreen = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SPACE1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SPACE2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableLayoutPanel1.Controls.Add(this.buttonAddColumn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonEraseColumn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveBackColum, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveNextColumn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonUpdateTemplate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonReturnScreen, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 419);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 115);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Location = new System.Drawing.Point(2, 2);
            this.buttonAddColumn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(110, 53);
            this.buttonAddColumn.TabIndex = 0;
            this.buttonAddColumn.Text = "Agregar Columna";
            this.buttonAddColumn.UseVisualStyleBackColor = true;
            this.buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // buttonEraseColumn
            // 
            this.buttonEraseColumn.Location = new System.Drawing.Point(2, 59);
            this.buttonEraseColumn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEraseColumn.Name = "buttonEraseColumn";
            this.buttonEraseColumn.Size = new System.Drawing.Size(110, 53);
            this.buttonEraseColumn.TabIndex = 3;
            this.buttonEraseColumn.Text = "Eliminar Columna";
            this.buttonEraseColumn.UseVisualStyleBackColor = true;
            this.buttonEraseColumn.Click += new System.EventHandler(this.buttonEraseColumn_Click);
            // 
            // buttonMoveBackColum
            // 
            this.buttonMoveBackColum.Location = new System.Drawing.Point(117, 2);
            this.buttonMoveBackColum.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoveBackColum.Name = "buttonMoveBackColum";
            this.buttonMoveBackColum.Size = new System.Drawing.Size(62, 53);
            this.buttonMoveBackColum.TabIndex = 1;
            this.buttonMoveBackColum.Text = "^ Mover";
            this.buttonMoveBackColum.UseVisualStyleBackColor = true;
            this.buttonMoveBackColum.Click += new System.EventHandler(this.buttonMoveBackColum_Click);
            // 
            // buttonMoveNextColumn
            // 
            this.buttonMoveNextColumn.Location = new System.Drawing.Point(117, 59);
            this.buttonMoveNextColumn.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMoveNextColumn.Name = "buttonMoveNextColumn";
            this.buttonMoveNextColumn.Size = new System.Drawing.Size(62, 53);
            this.buttonMoveNextColumn.TabIndex = 2;
            this.buttonMoveNextColumn.Text = " v Mover";
            this.buttonMoveNextColumn.UseVisualStyleBackColor = true;
            this.buttonMoveNextColumn.Click += new System.EventHandler(this.buttonMoveNextColumn_Click);
            // 
            // buttonUpdateTemplate
            // 
            this.buttonUpdateTemplate.Location = new System.Drawing.Point(186, 2);
            this.buttonUpdateTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateTemplate.Name = "buttonUpdateTemplate";
            this.buttonUpdateTemplate.Size = new System.Drawing.Size(120, 53);
            this.buttonUpdateTemplate.TabIndex = 5;
            this.buttonUpdateTemplate.Text = "Guardar Plantilla";
            this.buttonUpdateTemplate.UseVisualStyleBackColor = true;
            this.buttonUpdateTemplate.Click += new System.EventHandler(this.buttonUpdateTemplate_Click);
            // 
            // buttonReturnScreen
            // 
            this.buttonReturnScreen.Location = new System.Drawing.Point(186, 59);
            this.buttonReturnScreen.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturnScreen.Name = "buttonReturnScreen";
            this.buttonReturnScreen.Size = new System.Drawing.Size(120, 53);
            this.buttonReturnScreen.TabIndex = 4;
            this.buttonReturnScreen.Text = "Regresar";
            this.buttonReturnScreen.UseVisualStyleBackColor = true;
            this.buttonReturnScreen.Click += new System.EventHandler(this.buttonReturnScreen_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SPACE1,
            this.SPACE2});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 7);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(311, 365);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(2, 378);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 34);
            this.textBox1.TabIndex = 5;
            // 
            // GUI_CREAR_EDITAR_CODIGOS_DIASMES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 533);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI_CREAR_EDITAR_CODIGOS_DIASMES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU EDITAR CODIGOS O DIAS MES";
            this.Load += new System.EventHandler(this.GUI_CREAR_EDITAR_CODIGOS_DIASMES_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddColumn;
        private System.Windows.Forms.Button buttonEraseColumn;
        private System.Windows.Forms.Button buttonMoveBackColum;
        private System.Windows.Forms.Button buttonMoveNextColumn;
        private System.Windows.Forms.Button buttonUpdateTemplate;
        private System.Windows.Forms.Button buttonReturnScreen;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader SPACE1;
        private System.Windows.Forms.ColumnHeader SPACE2;
        private System.Windows.Forms.TextBox textBox1;
    }
}