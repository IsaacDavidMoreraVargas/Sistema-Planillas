namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_MENU_INICIO
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
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttonWorkWithCompany = new System.Windows.Forms.Button();
            this.buttonDuplicateCopyEliminateCompany = new System.Windows.Forms.Button();
            this.buttonEditTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonWorkWithCompany, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonEditTemplate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDuplicateCopyEliminateCompany, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.4717F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.5283F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 528);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(248, 416);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(239, 98);
            this.buttonCloseProgram.TabIndex = 4;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // buttonWorkWithCompany
            // 
            this.buttonWorkWithCompany.Location = new System.Drawing.Point(248, 108);
            this.buttonWorkWithCompany.Name = "buttonWorkWithCompany";
            this.buttonWorkWithCompany.Size = new System.Drawing.Size(238, 98);
            this.buttonWorkWithCompany.TabIndex = 1;
            this.buttonWorkWithCompany.Text = "TRABAJAR CON EMPRESA EXISTENTE";
            this.buttonWorkWithCompany.UseVisualStyleBackColor = true;
            this.buttonWorkWithCompany.Click += new System.EventHandler(this.buttonWorkWithCompany_Click);
            // 
            // buttonDuplicateCopyEliminateCompany
            // 
            this.buttonDuplicateCopyEliminateCompany.Location = new System.Drawing.Point(248, 3);
            this.buttonDuplicateCopyEliminateCompany.Name = "buttonDuplicateCopyEliminateCompany";
            this.buttonDuplicateCopyEliminateCompany.Size = new System.Drawing.Size(238, 96);
            this.buttonDuplicateCopyEliminateCompany.TabIndex = 5;
            this.buttonDuplicateCopyEliminateCompany.Text = "MULTIPLES OPCIONES EMPRESA EXISTENTE";
            this.buttonDuplicateCopyEliminateCompany.UseVisualStyleBackColor = true;
            this.buttonDuplicateCopyEliminateCompany.Click += new System.EventHandler(this.buttonDuplicateCopyEliminateCompany_Click);
            // 
            // buttonEditTemplate
            // 
            this.buttonEditTemplate.Location = new System.Drawing.Point(3, 3);
            this.buttonEditTemplate.Name = "buttonEditTemplate";
            this.buttonEditTemplate.Size = new System.Drawing.Size(238, 96);
            this.buttonEditTemplate.TabIndex = 3;
            this.buttonEditTemplate.Text = "MULTIPLES OPCIONES PLANTILLAS";
            this.buttonEditTemplate.UseVisualStyleBackColor = true;
            this.buttonEditTemplate.Click += new System.EventHandler(this.buttonEditTemplate_Click);
            // 
            // GUI_MENU_INICIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(766, 590);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI_MENU_INICIO";
            this.Text = "MENU GENERAL";
            this.Load += new System.EventHandler(this.GUI_MENU_INICIO_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.Button buttonWorkWithCompany;
        private System.Windows.Forms.Button buttonEditTemplate;
        private System.Windows.Forms.Button buttonDuplicateCopyEliminateCompany;
    }
}
