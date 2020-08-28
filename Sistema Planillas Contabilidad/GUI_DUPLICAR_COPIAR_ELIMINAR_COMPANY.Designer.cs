namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.EMPRESAS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttonChargeSafeCopy = new System.Windows.Forms.Button();
            this.buttonSafeCopyCompany = new System.Windows.Forms.Button();
            this.buttoneEliminateCompany = new System.Windows.Forms.Button();
            this.buttonDuplicateCompany = new System.Windows.Forms.Button();
            this.buttonCreateCompanySystem = new System.Windows.Forms.Button();
            this.buttonEditCompany = new System.Windows.Forms.Button();
            this.buttonReturnProgram = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EMPRESAS});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 13);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(466, 564);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonChargeSafeCopy, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSafeCopyCompany, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttoneEliminateCompany, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDuplicateCompany, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCreateCompanySystem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonEditCompany, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonReturnProgram, 0, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(485, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 565);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(3, 492);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(238, 63);
            this.buttonCloseProgram.TabIndex = 4;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // buttonChargeSafeCopy
            // 
            this.buttonChargeSafeCopy.Location = new System.Drawing.Point(3, 353);
            this.buttonChargeSafeCopy.Name = "buttonChargeSafeCopy";
            this.buttonChargeSafeCopy.Size = new System.Drawing.Size(238, 63);
            this.buttonChargeSafeCopy.TabIndex = 6;
            this.buttonChargeSafeCopy.Text = "CARGAR COPIA SEGURIDAD";
            this.buttonChargeSafeCopy.UseVisualStyleBackColor = true;
            this.buttonChargeSafeCopy.Click += new System.EventHandler(this.buttonChargeSafeCopy_Click);
            // 
            // buttonSafeCopyCompany
            // 
            this.buttonSafeCopyCompany.Location = new System.Drawing.Point(3, 282);
            this.buttonSafeCopyCompany.Name = "buttonSafeCopyCompany";
            this.buttonSafeCopyCompany.Size = new System.Drawing.Size(238, 63);
            this.buttonSafeCopyCompany.TabIndex = 5;
            this.buttonSafeCopyCompany.Text = "CREAR COPIA SEGURIDAD";
            this.buttonSafeCopyCompany.UseVisualStyleBackColor = true;
            this.buttonSafeCopyCompany.Click += new System.EventHandler(this.buttonSafeCopyCompany_Click);
            // 
            // buttoneEliminateCompany
            // 
            this.buttoneEliminateCompany.Location = new System.Drawing.Point(3, 212);
            this.buttoneEliminateCompany.Name = "buttoneEliminateCompany";
            this.buttoneEliminateCompany.Size = new System.Drawing.Size(238, 63);
            this.buttoneEliminateCompany.TabIndex = 2;
            this.buttoneEliminateCompany.Text = "ELIMINAR ";
            this.buttoneEliminateCompany.UseVisualStyleBackColor = true;
            this.buttoneEliminateCompany.Click += new System.EventHandler(this.buttoneEliminateCompany_Click);
            // 
            // buttonDuplicateCompany
            // 
            this.buttonDuplicateCompany.Location = new System.Drawing.Point(3, 143);
            this.buttonDuplicateCompany.Name = "buttonDuplicateCompany";
            this.buttonDuplicateCompany.Size = new System.Drawing.Size(238, 63);
            this.buttonDuplicateCompany.TabIndex = 3;
            this.buttonDuplicateCompany.Text = "DUPLICAR";
            this.buttonDuplicateCompany.UseVisualStyleBackColor = true;
            this.buttonDuplicateCompany.Click += new System.EventHandler(this.buttonDuplicateCompany_Click);
            // 
            // buttonCreateCompanySystem
            // 
            this.buttonCreateCompanySystem.Location = new System.Drawing.Point(3, 3);
            this.buttonCreateCompanySystem.Name = "buttonCreateCompanySystem";
            this.buttonCreateCompanySystem.Size = new System.Drawing.Size(238, 63);
            this.buttonCreateCompanySystem.TabIndex = 7;
            this.buttonCreateCompanySystem.Text = "GENERAR NUEVA EMPRESA";
            this.buttonCreateCompanySystem.UseVisualStyleBackColor = true;
            this.buttonCreateCompanySystem.Click += new System.EventHandler(this.buttonCreateCompanySystem_Click);
            // 
            // buttonEditCompany
            // 
            this.buttonEditCompany.Location = new System.Drawing.Point(3, 73);
            this.buttonEditCompany.Name = "buttonEditCompany";
            this.buttonEditCompany.Size = new System.Drawing.Size(238, 63);
            this.buttonEditCompany.TabIndex = 8;
            this.buttonEditCompany.Text = "EDITAR EMPRESA";
            this.buttonEditCompany.UseVisualStyleBackColor = true;
            this.buttonEditCompany.Click += new System.EventHandler(this.buttonEditCompany_Click);
            // 
            // buttonReturnProgram
            // 
            this.buttonReturnProgram.Location = new System.Drawing.Point(3, 423);
            this.buttonReturnProgram.Name = "buttonReturnProgram";
            this.buttonReturnProgram.Size = new System.Drawing.Size(238, 63);
            this.buttonReturnProgram.TabIndex = 1;
            this.buttonReturnProgram.Text = "REGRESAR";
            this.buttonReturnProgram.UseVisualStyleBackColor = true;
            this.buttonReturnProgram.Click += new System.EventHandler(this.buttonReturnProgram_Click);
            // 
            // GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 596);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA MULTIPLES OPCIONES COMPAÑIA";
            this.Load += new System.EventHandler(this.GUI_DUPLICAR_COPIAR_ELIMINAR_COMPANY_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonDuplicateCompany;
        private System.Windows.Forms.Button buttoneEliminateCompany;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.Button buttonReturnProgram;
        private System.Windows.Forms.Button buttonSafeCopyCompany;
        private System.Windows.Forms.ColumnHeader EMPRESAS;
        private System.Windows.Forms.Button buttonChargeSafeCopy;
        private System.Windows.Forms.Button buttonCreateCompanySystem;
        private System.Windows.Forms.Button buttonEditCompany;
    }
}