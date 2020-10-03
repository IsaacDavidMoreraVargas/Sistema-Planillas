namespace Sistema_Planillas_Contabilidad
{
    partial class GUI_VISTA_ASIENTOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_VISTA_ASIENTOS));
            this.label1 = new System.Windows.Forms.Label();
            this.labelWeek = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEBET = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREDIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(2, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLANILLA SEMANAL OPERARIOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.UseCompatibleTextRendering = true;
            // 
            // labelWeek
            // 
            this.labelWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWeek.BackColor = System.Drawing.Color.Transparent;
            this.labelWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelWeek.Location = new System.Drawing.Point(2, 127);
            this.labelWeek.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWeek.Name = "labelWeek";
            this.labelWeek.Size = new System.Drawing.Size(475, 42);
            this.labelWeek.TabIndex = 1;
            this.labelWeek.Text = "PLANILLA SEMANAL DEL AL";
            this.labelWeek.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelWeek.UseCompatibleTextRendering = true;
            // 
            // labelCompany
            // 
            this.labelCompany.BackColor = System.Drawing.Color.Transparent;
            this.labelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelCompany.Location = new System.Drawing.Point(2, 0);
            this.labelCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(448, 17);
            this.labelCompany.TabIndex = 2;
            this.labelCompany.Text = "EMPRESA";
            this.labelCompany.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelCompany.UseCompatibleTextRendering = true;
            // 
            // labelID
            // 
            this.labelID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelID.BackColor = System.Drawing.Color.Transparent;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.labelID.Location = new System.Drawing.Point(2, 32);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(475, 20);
            this.labelID.TabIndex = 3;
            this.labelID.Text = "CEDULA JURIDICA";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelID.UseCompatibleTextRendering = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODE,
            this.DESCRIPTION,
            this.DEBET,
            this.CREDIT});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.Location = new System.Drawing.Point(2, 202);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(475, 358);
            this.dataGridView1.TabIndex = 4;
            // 
            // CODE
            // 
            this.CODE.HeaderText = "CODIGO";
            this.CODE.MinimumWidth = 6;
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            this.CODE.Width = 74;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.HeaderText = "DESCRIPCION";
            this.DESCRIPTION.MinimumWidth = 6;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.ReadOnly = true;
            this.DESCRIPTION.Width = 105;
            // 
            // DEBET
            // 
            this.DEBET.HeaderText = "DEBITO";
            this.DEBET.MinimumWidth = 6;
            this.DEBET.Name = "DEBET";
            this.DEBET.ReadOnly = true;
            this.DEBET.Width = 72;
            // 
            // CREDIT
            // 
            this.CREDIT.HeaderText = "CREDITO";
            this.CREDIT.MinimumWidth = 6;
            this.CREDIT.Name = "CREDIT";
            this.CREDIT.ReadOnly = true;
            this.CREDIT.Width = 80;
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCloseProgram.Location = new System.Drawing.Point(2, 564);
            this.buttonCloseProgram.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(71, 25);
            this.buttonCloseProgram.TabIndex = 5;
            this.buttonCloseProgram.Text = "SALIR";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelCompany, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCloseProgram, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelWeek, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 362F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 592);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // GUI_VISTA_ASIENTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(495, 606);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GUI_VISTA_ASIENTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA MOSTRAR ASIENTOS";
            this.Load += new System.EventHandler(this.GUI_VISTA_ASIENTOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelWeek;
        private System.Windows.Forms.Label labelCompany;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEBET;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREDIT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}