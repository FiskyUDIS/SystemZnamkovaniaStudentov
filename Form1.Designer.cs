namespace SystemZnamkovaniaStudentov
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewPriezviskoMeno = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriezvisko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewZnamky = new System.Windows.Forms.DataGridView();
            this.Column2ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2Priezvisko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2Meno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2Znamka = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2Priemer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPridajStudenta = new System.Windows.Forms.Button();
            this.buttonVymazStudenta = new System.Windows.Forms.Button();
            this.labelVyberSiPredmet = new System.Windows.Forms.Label();
            this.comboBoxSubjects = new System.Windows.Forms.ComboBox();
            this.textBoxPridajPredmet = new System.Windows.Forms.TextBox();
            this.labelPridajPredmet = new System.Windows.Forms.Label();
            this.buttonPridajPredmet = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pane_design1 = new System.Windows.Forms.Panel();
            this.buttonImport = new System.Windows.Forms.Button();
            this.panel_design2 = new System.Windows.Forms.Panel();
            this.labelVymazPredmet = new System.Windows.Forms.Label();
            this.buttonVymazPredmet = new System.Windows.Forms.Button();
            this.comboBoxVymazPredmet = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPredmet = new System.Windows.Forms.Label();
            this.openFileDialogSubor = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriezviskoMeno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZnamky)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pane_design1.SuspendLayout();
            this.panel_design2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPriezviskoMeno
            // 
            this.dataGridViewPriezviskoMeno.AllowUserToAddRows = false;
            this.dataGridViewPriezviskoMeno.AllowUserToDeleteRows = false;
            this.dataGridViewPriezviskoMeno.AllowUserToOrderColumns = true;
            this.dataGridViewPriezviskoMeno.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridViewPriezviskoMeno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPriezviskoMeno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPriezviskoMeno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnPriezvisko,
            this.ColumnMeno});
            this.dataGridViewPriezviskoMeno.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPriezviskoMeno.Location = new System.Drawing.Point(353, 0);
            this.dataGridViewPriezviskoMeno.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewPriezviskoMeno.Name = "dataGridViewPriezviskoMeno";
            this.dataGridViewPriezviskoMeno.RowHeadersWidth = 51;
            this.dataGridViewPriezviskoMeno.RowTemplate.Height = 24;
            this.dataGridViewPriezviskoMeno.Size = new System.Drawing.Size(424, 403);
            this.dataGridViewPriezviskoMeno.TabIndex = 2;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnPriezvisko
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.ColumnPriezvisko.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnPriezvisko.HeaderText = "Priezvisko";
            this.ColumnPriezvisko.MinimumWidth = 6;
            this.ColumnPriezvisko.Name = "ColumnPriezvisko";
            this.ColumnPriezvisko.Width = 125;
            // 
            // ColumnMeno
            // 
            this.ColumnMeno.HeaderText = "Meno";
            this.ColumnMeno.MinimumWidth = 6;
            this.ColumnMeno.Name = "ColumnMeno";
            this.ColumnMeno.Width = 125;
            // 
            // dataGridViewZnamky
            // 
            this.dataGridViewZnamky.AllowUserToAddRows = false;
            this.dataGridViewZnamky.AllowUserToDeleteRows = false;
            this.dataGridViewZnamky.AllowUserToOrderColumns = true;
            this.dataGridViewZnamky.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dataGridViewZnamky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewZnamky.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2ID,
            this.Column2Priezvisko,
            this.Column2Meno,
            this.Column2Znamka,
            this.Column2Priemer});
            this.dataGridViewZnamky.Location = new System.Drawing.Point(136, -1);
            this.dataGridViewZnamky.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewZnamky.Name = "dataGridViewZnamky";
            this.dataGridViewZnamky.RowHeadersWidth = 51;
            this.dataGridViewZnamky.RowTemplate.Height = 24;
            this.dataGridViewZnamky.Size = new System.Drawing.Size(637, 408);
            this.dataGridViewZnamky.TabIndex = 5;
            this.dataGridViewZnamky.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewZnamky_CellEndEdit);
            this.dataGridViewZnamky.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewZnamky_EditingControlShowing);
            this.dataGridViewZnamky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // Column2ID
            // 
            this.Column2ID.HeaderText = "ID";
            this.Column2ID.Name = "Column2ID";
            this.Column2ID.ReadOnly = true;
            // 
            // Column2Priezvisko
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.Column2Priezvisko.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2Priezvisko.HeaderText = "Priezvisko";
            this.Column2Priezvisko.MinimumWidth = 6;
            this.Column2Priezvisko.Name = "Column2Priezvisko";
            this.Column2Priezvisko.ReadOnly = true;
            this.Column2Priezvisko.Width = 125;
            // 
            // Column2Meno
            // 
            this.Column2Meno.HeaderText = "Meno";
            this.Column2Meno.MinimumWidth = 6;
            this.Column2Meno.Name = "Column2Meno";
            this.Column2Meno.ReadOnly = true;
            this.Column2Meno.Width = 125;
            // 
            // Column2Znamka
            // 
            this.Column2Znamka.HeaderText = "Známky";
            this.Column2Znamka.MinimumWidth = 6;
            this.Column2Znamka.Name = "Column2Znamka";
            this.Column2Znamka.Width = 125;
            // 
            // Column2Priemer
            // 
            this.Column2Priemer.HeaderText = "Priemer";
            this.Column2Priemer.Name = "Column2Priemer";
            this.Column2Priemer.ReadOnly = true;
            // 
            // buttonPridajStudenta
            // 
            this.buttonPridajStudenta.BackColor = System.Drawing.Color.Transparent;
            this.buttonPridajStudenta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPridajStudenta.Location = new System.Drawing.Point(8, 17);
            this.buttonPridajStudenta.Name = "buttonPridajStudenta";
            this.buttonPridajStudenta.Size = new System.Drawing.Size(96, 45);
            this.buttonPridajStudenta.TabIndex = 6;
            this.buttonPridajStudenta.Text = "Pridaj študenta";
            this.buttonPridajStudenta.UseVisualStyleBackColor = false;
            this.buttonPridajStudenta.Click += new System.EventHandler(this.buttonPridajStudenta_Click);
            // 
            // buttonVymazStudenta
            // 
            this.buttonVymazStudenta.Location = new System.Drawing.Point(7, 119);
            this.buttonVymazStudenta.Name = "buttonVymazStudenta";
            this.buttonVymazStudenta.Size = new System.Drawing.Size(96, 45);
            this.buttonVymazStudenta.TabIndex = 7;
            this.buttonVymazStudenta.Text = "Vymaž študenta";
            this.buttonVymazStudenta.UseVisualStyleBackColor = true;
            this.buttonVymazStudenta.Click += new System.EventHandler(this.buttonVymazStudenta_Click);
            // 
            // labelVyberSiPredmet
            // 
            this.labelVyberSiPredmet.AutoSize = true;
            this.labelVyberSiPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVyberSiPredmet.ForeColor = System.Drawing.SystemColors.Control;
            this.labelVyberSiPredmet.Location = new System.Drawing.Point(14, 48);
            this.labelVyberSiPredmet.Name = "labelVyberSiPredmet";
            this.labelVyberSiPredmet.Size = new System.Drawing.Size(110, 16);
            this.labelVyberSiPredmet.TabIndex = 8;
            this.labelVyberSiPredmet.Text = "Vyber si Predmet";
            // 
            // comboBoxSubjects
            // 
            this.comboBoxSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSubjects.FormattingEnabled = true;
            this.comboBoxSubjects.Location = new System.Drawing.Point(17, 73);
            this.comboBoxSubjects.Name = "comboBoxSubjects";
            this.comboBoxSubjects.Size = new System.Drawing.Size(108, 21);
            this.comboBoxSubjects.TabIndex = 10;
            this.comboBoxSubjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubjects_SelectedIndexChanged);
            // 
            // textBoxPridajPredmet
            // 
            this.textBoxPridajPredmet.Location = new System.Drawing.Point(102, 8);
            this.textBoxPridajPredmet.Name = "textBoxPridajPredmet";
            this.textBoxPridajPredmet.Size = new System.Drawing.Size(141, 20);
            this.textBoxPridajPredmet.TabIndex = 11;
            // 
            // labelPridajPredmet
            // 
            this.labelPridajPredmet.AutoSize = true;
            this.labelPridajPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPridajPredmet.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPridajPredmet.Location = new System.Drawing.Point(10, 11);
            this.labelPridajPredmet.Name = "labelPridajPredmet";
            this.labelPridajPredmet.Size = new System.Drawing.Size(88, 13);
            this.labelPridajPredmet.TabIndex = 12;
            this.labelPridajPredmet.Text = "Pridaj predmet";
            // 
            // buttonPridajPredmet
            // 
            this.buttonPridajPredmet.Location = new System.Drawing.Point(249, 6);
            this.buttonPridajPredmet.Name = "buttonPridajPredmet";
            this.buttonPridajPredmet.Size = new System.Drawing.Size(104, 23);
            this.buttonPridajPredmet.TabIndex = 13;
            this.buttonPridajPredmet.Text = "Pridaj";
            this.buttonPridajPredmet.UseVisualStyleBackColor = true;
            this.buttonPridajPredmet.Click += new System.EventHandler(this.buttonPridajPredmet_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Location = new System.Drawing.Point(12, 12);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(776, 429);
            this.tabControlMain.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.pane_design1);
            this.tabPage1.Controls.Add(this.panel_design2);
            this.tabPage1.Controls.Add(this.dataGridViewPriezviskoMeno);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(768, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hlavné okno";
            // 
            // pane_design1
            // 
            this.pane_design1.BackColor = System.Drawing.Color.Black;
            this.pane_design1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pane_design1.Controls.Add(this.buttonPridajStudenta);
            this.pane_design1.Controls.Add(this.buttonImport);
            this.pane_design1.Controls.Add(this.buttonVymazStudenta);
            this.pane_design1.Location = new System.Drawing.Point(245, 0);
            this.pane_design1.Name = "pane_design1";
            this.pane_design1.Size = new System.Drawing.Size(110, 186);
            this.pane_design1.TabIndex = 19;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(8, 68);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(96, 45);
            this.buttonImport.TabIndex = 17;
            this.buttonImport.Text = "Importuj študentov";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // panel_design2
            // 
            this.panel_design2.BackColor = System.Drawing.Color.Black;
            this.panel_design2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_design2.Controls.Add(this.labelPridajPredmet);
            this.panel_design2.Controls.Add(this.labelVymazPredmet);
            this.panel_design2.Controls.Add(this.buttonVymazPredmet);
            this.panel_design2.Controls.Add(this.textBoxPridajPredmet);
            this.panel_design2.Controls.Add(this.comboBoxVymazPredmet);
            this.panel_design2.Controls.Add(this.buttonPridajPredmet);
            this.panel_design2.Location = new System.Drawing.Point(-4, 192);
            this.panel_design2.Name = "panel_design2";
            this.panel_design2.Size = new System.Drawing.Size(359, 69);
            this.panel_design2.TabIndex = 18;
            // 
            // labelVymazPredmet
            // 
            this.labelVymazPredmet.AutoSize = true;
            this.labelVymazPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVymazPredmet.ForeColor = System.Drawing.SystemColors.Control;
            this.labelVymazPredmet.Location = new System.Drawing.Point(10, 37);
            this.labelVymazPredmet.Name = "labelVymazPredmet";
            this.labelVymazPredmet.Size = new System.Drawing.Size(92, 13);
            this.labelVymazPredmet.TabIndex = 14;
            this.labelVymazPredmet.Text = "Vymaž predmet";
            // 
            // buttonVymazPredmet
            // 
            this.buttonVymazPredmet.Location = new System.Drawing.Point(249, 35);
            this.buttonVymazPredmet.Name = "buttonVymazPredmet";
            this.buttonVymazPredmet.Size = new System.Drawing.Size(104, 23);
            this.buttonVymazPredmet.TabIndex = 16;
            this.buttonVymazPredmet.Text = "Vymaz";
            this.buttonVymazPredmet.UseVisualStyleBackColor = true;
            this.buttonVymazPredmet.Click += new System.EventHandler(this.buttonVymazPredmet_Click);
            // 
            // comboBoxVymazPredmet
            // 
            this.comboBoxVymazPredmet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVymazPredmet.FormattingEnabled = true;
            this.comboBoxVymazPredmet.Location = new System.Drawing.Point(102, 34);
            this.comboBoxVymazPredmet.Name = "comboBoxVymazPredmet";
            this.comboBoxVymazPredmet.Size = new System.Drawing.Size(141, 21);
            this.comboBoxVymazPredmet.TabIndex = 15;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.dataGridViewZnamky);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(768, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Výpočet priemeru";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.labelPredmet);
            this.panel3.Controls.Add(this.comboBoxSubjects);
            this.panel3.Controls.Add(this.labelVyberSiPredmet);
            this.panel3.Location = new System.Drawing.Point(0, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(138, 111);
            this.panel3.TabIndex = 12;
            // 
            // labelPredmet
            // 
            this.labelPredmet.AutoSize = true;
            this.labelPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPredmet.ForeColor = System.Drawing.SystemColors.Control;
            this.labelPredmet.Location = new System.Drawing.Point(14, 13);
            this.labelPredmet.Name = "labelPredmet";
            this.labelPredmet.Size = new System.Drawing.Size(71, 18);
            this.labelPredmet.TabIndex = 11;
            this.labelPredmet.Text = "Predmet";
            // 
            // openFileDialogSubor
            // 
            this.openFileDialogSubor.FileName = "openFileDialog1";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 431);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 10);
            this.panel2.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Znamkovanie studentov";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriezviskoMeno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewZnamky)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pane_design1.ResumeLayout(false);
            this.panel_design2.ResumeLayout(false);
            this.panel_design2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPriezviskoMeno;
        private System.Windows.Forms.DataGridView dataGridViewZnamky;
        private System.Windows.Forms.Button buttonPridajStudenta;
        private System.Windows.Forms.Button buttonVymazStudenta;
        private System.Windows.Forms.Label labelVyberSiPredmet;
        private System.Windows.Forms.ComboBox comboBoxSubjects;
        private System.Windows.Forms.TextBox textBoxPridajPredmet;
        private System.Windows.Forms.Label labelPridajPredmet;
        private System.Windows.Forms.Button buttonPridajPredmet;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelPredmet;
        private System.Windows.Forms.Label labelVymazPredmet;
        private System.Windows.Forms.ComboBox comboBoxVymazPredmet;
        private System.Windows.Forms.Button buttonVymazPredmet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriezvisko;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMeno;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.OpenFileDialog openFileDialogSubor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2Priezvisko;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2Meno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2Znamka;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2Priemer;
        private System.Windows.Forms.Panel pane_design1;
        private System.Windows.Forms.Panel panel_design2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}

