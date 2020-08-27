namespace WorkoutLoggerUI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.openFolderDays = new System.Windows.Forms.OpenFileDialog();
            this.openFolderTemplates = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDaysFolder = new System.Windows.Forms.Button();
            this.textBoxDaysLoc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonTemplateFolder = new System.Windows.Forms.Button();
            this.textBoxTemplatesLoc = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioXML = new System.Windows.Forms.RadioButton();
            this.radioJson = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioImperial = new System.Windows.Forms.RadioButton();
            this.radioMetric = new System.Windows.Forms.RadioButton();
            this.buttonExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFolderDays
            // 
            this.openFolderDays.CheckFileExists = false;
            this.openFolderDays.FileName = "Select Folder";
            this.openFolderDays.ValidateNames = false;
            // 
            // openFolderTemplates
            // 
            this.openFolderTemplates.CheckFileExists = false;
            this.openFolderTemplates.FileName = "Select Folder";
            this.openFolderTemplates.ValidateNames = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDaysFolder);
            this.groupBox1.Controls.Add(this.textBoxDaysLoc);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Days Folder Save To...";
            // 
            // buttonDaysFolder
            // 
            this.buttonDaysFolder.Location = new System.Drawing.Point(204, 27);
            this.buttonDaysFolder.Name = "buttonDaysFolder";
            this.buttonDaysFolder.Size = new System.Drawing.Size(52, 29);
            this.buttonDaysFolder.TabIndex = 5;
            this.buttonDaysFolder.Text = "...";
            this.buttonDaysFolder.UseVisualStyleBackColor = true;
            this.buttonDaysFolder.Click += new System.EventHandler(this.buttonDaysFolder_Click);
            // 
            // textBoxDaysLoc
            // 
            this.textBoxDaysLoc.Location = new System.Drawing.Point(6, 28);
            this.textBoxDaysLoc.Name = "textBoxDaysLoc";
            this.textBoxDaysLoc.ReadOnly = true;
            this.textBoxDaysLoc.Size = new System.Drawing.Size(192, 29);
            this.textBoxDaysLoc.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonTemplateFolder);
            this.groupBox2.Controls.Add(this.textBoxTemplatesLoc);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Template Folder Save To...";
            // 
            // buttonTemplateFolder
            // 
            this.buttonTemplateFolder.Location = new System.Drawing.Point(204, 27);
            this.buttonTemplateFolder.Name = "buttonTemplateFolder";
            this.buttonTemplateFolder.Size = new System.Drawing.Size(52, 29);
            this.buttonTemplateFolder.TabIndex = 6;
            this.buttonTemplateFolder.Text = "...";
            this.buttonTemplateFolder.UseVisualStyleBackColor = true;
            this.buttonTemplateFolder.Click += new System.EventHandler(this.buttonTemplateFolder_Click);
            // 
            // textBoxTemplatesLoc
            // 
            this.textBoxTemplatesLoc.Location = new System.Drawing.Point(6, 28);
            this.textBoxTemplatesLoc.Name = "textBoxTemplatesLoc";
            this.textBoxTemplatesLoc.ReadOnly = true;
            this.textBoxTemplatesLoc.Size = new System.Drawing.Size(192, 29);
            this.textBoxTemplatesLoc.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioXML);
            this.groupBox3.Controls.Add(this.radioJson);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(130, 92);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Files As...";
            // 
            // radioXML
            // 
            this.radioXML.AutoSize = true;
            this.radioXML.Location = new System.Drawing.Point(6, 59);
            this.radioXML.Name = "radioXML";
            this.radioXML.Size = new System.Drawing.Size(59, 25);
            this.radioXML.TabIndex = 1;
            this.radioXML.Text = "XML";
            this.radioXML.UseVisualStyleBackColor = true;
            this.radioXML.CheckedChanged += new System.EventHandler(this.radioXML_CheckedChanged);
            // 
            // radioJson
            // 
            this.radioJson.AutoSize = true;
            this.radioJson.Checked = true;
            this.radioJson.Location = new System.Drawing.Point(6, 28);
            this.radioJson.Name = "radioJson";
            this.radioJson.Size = new System.Drawing.Size(67, 25);
            this.radioJson.TabIndex = 0;
            this.radioJson.TabStop = true;
            this.radioJson.Text = "JSON";
            this.radioJson.UseVisualStyleBackColor = true;
            this.radioJson.CheckedChanged += new System.EventHandler(this.radioJson_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioImperial);
            this.groupBox4.Controls.Add(this.radioMetric);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(148, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(130, 92);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Weight Unit";
            // 
            // radioImperial
            // 
            this.radioImperial.AutoSize = true;
            this.radioImperial.Location = new System.Drawing.Point(6, 59);
            this.radioImperial.Name = "radioImperial";
            this.radioImperial.Size = new System.Drawing.Size(85, 25);
            this.radioImperial.TabIndex = 5;
            this.radioImperial.Text = "Imperial";
            this.radioImperial.UseVisualStyleBackColor = true;
            this.radioImperial.CheckedChanged += new System.EventHandler(this.radioImperial_CheckedChanged);
            // 
            // radioMetric
            // 
            this.radioMetric.AutoSize = true;
            this.radioMetric.Checked = true;
            this.radioMetric.Location = new System.Drawing.Point(6, 28);
            this.radioMetric.Name = "radioMetric";
            this.radioMetric.Size = new System.Drawing.Size(72, 25);
            this.radioMetric.TabIndex = 5;
            this.radioMetric.TabStop = true;
            this.radioMetric.Text = "Metric";
            this.radioMetric.UseVisualStyleBackColor = true;
            this.radioMetric.CheckedChanged += new System.EventHandler(this.radioMetric_CheckedChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(104, 252);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(86, 40);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 304);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFolderDays;
        private System.Windows.Forms.OpenFileDialog openFolderTemplates;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDaysFolder;
        private System.Windows.Forms.TextBox textBoxDaysLoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonTemplateFolder;
        private System.Windows.Forms.TextBox textBoxTemplatesLoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioXML;
        private System.Windows.Forms.RadioButton radioJson;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioImperial;
        private System.Windows.Forms.RadioButton radioMetric;
        private System.Windows.Forms.Button buttonExit;
    }
}