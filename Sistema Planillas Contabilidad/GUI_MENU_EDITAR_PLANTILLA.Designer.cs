namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_MENU_EDITAR_PLANTILLA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_MENU_EDITAR_PLANTILLA));
            this.buttonGoEditTemplate = new System.Windows.Forms.Button();
            this.buttonReturnProgram = new System.Windows.Forms.Button();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.LISTEMPLATE = new System.Windows.Forms.ListView();
            this.PLANTILLAS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDuplicate = new System.Windows.Forms.Button();
            this.buttonEliminateFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGoEditTemplate
            // 
            this.buttonGoEditTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGoEditTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGoEditTemplate.Location = new System.Drawing.Point(2, 54);
            this.buttonGoEditTemplate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonGoEditTemplate.Name = "buttonGoEditTemplate";
            this.buttonGoEditTemplate.Size = new System.Drawing.Size(186, 48);
            this.buttonGoEditTemplate.TabIndex = 1;
            this.buttonGoEditTemplate.Text = "EDITAR";
            this.buttonGoEditTemplate.UseVisualStyleBackColor = true;
            this.buttonGoEditTemplate.Click += new System.EventHandler(this.buttonGoEditTemplate_Click);
            // 
            // buttonReturnProgram
            // 
            this.buttonReturnProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReturnProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReturnProgram.Location = new System.Drawing.Point(2, 211);
            this.buttonReturnProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReturnProgram.Name = "buttonReturnProgram";
            this.buttonReturnProgram.Size = new System.Drawing.Size(186, 49);
            this.buttonReturnProgram.TabIndex = 2;
            this.buttonReturnProgram.Text = "REGRESAR";
            this.buttonReturnProgram.UseVisualStyleBackColor = true;
            this.buttonReturnProgram.Click += new System.EventHandler(this.buttonReturnProgram_Click);
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCloseProgram.Location = new System.Drawing.Point(2, 264);
            this.buttonCloseProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(186, 53);
            this.buttonCloseProgram.TabIndex = 3;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // LISTEMPLATE
            // 
            this.LISTEMPLATE.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LISTEMPLATE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PLANTILLAS});
            this.LISTEMPLATE.GridLines = true;
            this.LISTEMPLATE.HideSelection = false;
            this.LISTEMPLATE.Location = new System.Drawing.Point(10, 5);
            this.LISTEMPLATE.Margin = new System.Windows.Forms.Padding(2);
            this.LISTEMPLATE.Name = "LISTEMPLATE";
            this.LISTEMPLATE.Size = new System.Drawing.Size(253, 319);
            this.LISTEMPLATE.TabIndex = 4;
            this.LISTEMPLATE.UseCompatibleStateImageBehavior = false;
            this.LISTEMPLATE.SelectedIndexChanged += new System.EventHandler(this.LISTAPLANTILLAS_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.buttonGoEditTemplate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonNew, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDuplicate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonReturnProgram, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonEliminateFile, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(267, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 319);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNew.Location = new System.Drawing.Point(2, 2);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(186, 48);
            this.buttonNew.TabIndex = 4;
            this.buttonNew.Text = "NUEVO";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDuplicate
            // 
            this.buttonDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDuplicate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDuplicate.Location = new System.Drawing.Point(2, 106);
            this.buttonDuplicate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDuplicate.Name = "buttonDuplicate";
            this.buttonDuplicate.Size = new System.Drawing.Size(186, 48);
            this.buttonDuplicate.TabIndex = 5;
            this.buttonDuplicate.Text = "DUPLICAR";
            this.buttonDuplicate.UseVisualStyleBackColor = true;
            this.buttonDuplicate.Click += new System.EventHandler(this.buttonDuplicate_Click);
            // 
            // buttonEliminateFile
            // 
            this.buttonEliminateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEliminateFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEliminateFile.Location = new System.Drawing.Point(2, 158);
            this.buttonEliminateFile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEliminateFile.Name = "buttonEliminateFile";
            this.buttonEliminateFile.Size = new System.Drawing.Size(186, 49);
            this.buttonEliminateFile.TabIndex = 6;
            this.buttonEliminateFile.Text = "ELIMINAR";
            this.buttonEliminateFile.UseVisualStyleBackColor = true;
            this.buttonEliminateFile.Click += new System.EventHandler(this.buttonEliminateFile_Click);
            // 
            // GUI_MENU_EDITAR_PLANTILLA
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(468, 326);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.LISTEMPLATE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_MENU_EDITAR_PLANTILLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU SELECCION EDITAR PLANTILLA";
            this.Load += new System.EventHandler(this.GUI_MENU_EDITAR_PLANTILLA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonGoEditTemplate;
        private System.Windows.Forms.Button buttonReturnProgram;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.ListView LISTEMPLATE;
        private System.Windows.Forms.ColumnHeader PLANTILLAS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDuplicate;
        private System.Windows.Forms.Button buttonEliminateFile;
    }
}
