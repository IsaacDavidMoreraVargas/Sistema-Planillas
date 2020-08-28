namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_EDITAR_PLANTILLA
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
            this.buttonUpdateTemplate = new System.Windows.Forms.Button();
            this.buttonReturnScreen = new System.Windows.Forms.Button();
            this.buttonMoveBackColum = new System.Windows.Forms.Button();
            this.buttonAddColumn = new System.Windows.Forms.Button();
            this.buttonEraseColumn = new System.Windows.Forms.Button();
            this.buttonMoveNextColumn = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.7095F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.2905F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.Controls.Add(this.buttonUpdateTemplate, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonReturnScreen, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveBackColum, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddColumn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonEraseColumn, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveNextColumn, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 11, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 675);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1175, 71);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonUpdateTemplate
            // 
            this.buttonUpdateTemplate.Location = new System.Drawing.Point(597, 3);
            this.buttonUpdateTemplate.Name = "buttonUpdateTemplate";
            this.buttonUpdateTemplate.Size = new System.Drawing.Size(160, 65);
            this.buttonUpdateTemplate.TabIndex = 5;
            this.buttonUpdateTemplate.Text = "Actualizar Plantilla";
            this.buttonUpdateTemplate.UseVisualStyleBackColor = true;
            this.buttonUpdateTemplate.Click += new System.EventHandler(this.buttonUpdateTemplate_Click);
            // 
            // buttonReturnScreen
            // 
            this.buttonReturnScreen.Location = new System.Drawing.Point(790, 3);
            this.buttonReturnScreen.Name = "buttonReturnScreen";
            this.buttonReturnScreen.Size = new System.Drawing.Size(160, 65);
            this.buttonReturnScreen.TabIndex = 4;
            this.buttonReturnScreen.Text = "Regresar";
            this.buttonReturnScreen.UseVisualStyleBackColor = true;
            this.buttonReturnScreen.Click += new System.EventHandler(this.buttonReturnScreen_Click);
            // 
            // buttonMoveBackColum
            // 
            this.buttonMoveBackColum.Location = new System.Drawing.Point(178, 3);
            this.buttonMoveBackColum.Name = "buttonMoveBackColum";
            this.buttonMoveBackColum.Size = new System.Drawing.Size(83, 65);
            this.buttonMoveBackColum.TabIndex = 1;
            this.buttonMoveBackColum.Text = "<< Mover";
            this.buttonMoveBackColum.UseVisualStyleBackColor = true;
            this.buttonMoveBackColum.Click += new System.EventHandler(this.buttonMoveBackColum_Click);
            // 
            // buttonAddColumn
            // 
            this.buttonAddColumn.Location = new System.Drawing.Point(3, 3);
            this.buttonAddColumn.Name = "buttonAddColumn";
            this.buttonAddColumn.Size = new System.Drawing.Size(147, 65);
            this.buttonAddColumn.TabIndex = 0;
            this.buttonAddColumn.Text = "Agregar Columna";
            this.buttonAddColumn.UseVisualStyleBackColor = true;
            this.buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // buttonEraseColumn
            // 
            this.buttonEraseColumn.Location = new System.Drawing.Point(401, 3);
            this.buttonEraseColumn.Name = "buttonEraseColumn";
            this.buttonEraseColumn.Size = new System.Drawing.Size(161, 65);
            this.buttonEraseColumn.TabIndex = 3;
            this.buttonEraseColumn.Text = "Eliminar Columna";
            this.buttonEraseColumn.UseVisualStyleBackColor = true;
            this.buttonEraseColumn.Click += new System.EventHandler(this.buttonEraseColumn_Click);
            // 
            // buttonMoveNextColumn
            // 
            this.buttonMoveNextColumn.Location = new System.Drawing.Point(288, 3);
            this.buttonMoveNextColumn.Name = "buttonMoveNextColumn";
            this.buttonMoveNextColumn.Size = new System.Drawing.Size(83, 65);
            this.buttonMoveNextColumn.TabIndex = 2;
            this.buttonMoveNextColumn.Text = "Mover >>";
            this.buttonMoveNextColumn.UseVisualStyleBackColor = true;
            this.buttonMoveNextColumn.Click += new System.EventHandler(this.buttonMoveNextColumn_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(976, 3);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(160, 65);
            this.buttonCloseProgram.TabIndex = 6;
            this.buttonCloseProgram.Text = "Salir";
            this.buttonCloseProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1166, 657);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellClickEvent);
            // 
            // GUI_EDITAR_PLANTILLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1190, 749);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI_EDITAR_PLANTILLA";
            this.Text = "SISTEMA EDITAR PLANTILLA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GUI_EDITAR_PLANTILLA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonUpdateTemplate;
        private System.Windows.Forms.Button buttonReturnScreen;
        private System.Windows.Forms.Button buttonMoveBackColum;
        private System.Windows.Forms.Button buttonAddColumn;
        private System.Windows.Forms.Button buttonEraseColumn;
        private System.Windows.Forms.Button buttonMoveNextColumn;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
