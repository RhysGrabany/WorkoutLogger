namespace WorkoutLoggerUI
{
    partial class LoadDayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadDayForm));
            this.listViewDays = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonLoadDay = new System.Windows.Forms.Button();
            this.buttonDeleteDay = new System.Windows.Forms.Button();
            this.buttonExitForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewDays
            // 
            this.listViewDays.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnDate});
            this.listViewDays.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewDays.FullRowSelect = true;
            this.listViewDays.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewDays.HideSelection = false;
            this.listViewDays.Location = new System.Drawing.Point(12, 12);
            this.listViewDays.MultiSelect = false;
            this.listViewDays.Name = "listViewDays";
            this.listViewDays.Size = new System.Drawing.Size(194, 500);
            this.listViewDays.TabIndex = 0;
            this.listViewDays.UseCompatibleStateImageBehavior = false;
            this.listViewDays.View = System.Windows.Forms.View.Details;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 100;
            // 
            // columnDate
            // 
            this.columnDate.Text = "Date";
            this.columnDate.Width = 90;
            // 
            // buttonLoadDay
            // 
            this.buttonLoadDay.Location = new System.Drawing.Point(212, 12);
            this.buttonLoadDay.Name = "buttonLoadDay";
            this.buttonLoadDay.Size = new System.Drawing.Size(92, 38);
            this.buttonLoadDay.TabIndex = 1;
            this.buttonLoadDay.Text = "Load";
            this.buttonLoadDay.UseVisualStyleBackColor = true;
            this.buttonLoadDay.Click += new System.EventHandler(this.buttonLoadDay_Click);
            // 
            // buttonDeleteDay
            // 
            this.buttonDeleteDay.Location = new System.Drawing.Point(212, 56);
            this.buttonDeleteDay.Name = "buttonDeleteDay";
            this.buttonDeleteDay.Size = new System.Drawing.Size(92, 38);
            this.buttonDeleteDay.TabIndex = 2;
            this.buttonDeleteDay.Text = "Delete";
            this.buttonDeleteDay.UseVisualStyleBackColor = true;
            this.buttonDeleteDay.Click += new System.EventHandler(this.buttonDeleteDay_Click);
            // 
            // buttonExitForm
            // 
            this.buttonExitForm.Location = new System.Drawing.Point(212, 474);
            this.buttonExitForm.Name = "buttonExitForm";
            this.buttonExitForm.Size = new System.Drawing.Size(92, 38);
            this.buttonExitForm.TabIndex = 3;
            this.buttonExitForm.Text = "Exit";
            this.buttonExitForm.UseVisualStyleBackColor = true;
            this.buttonExitForm.Click += new System.EventHandler(this.buttonExitForm_Click);
            // 
            // LoadDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(310, 524);
            this.Controls.Add(this.buttonExitForm);
            this.Controls.Add(this.buttonDeleteDay);
            this.Controls.Add(this.buttonLoadDay);
            this.Controls.Add(this.listViewDays);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "LoadDayForm";
            this.Text = "Load Day";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDays;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.Button buttonLoadDay;
        private System.Windows.Forms.Button buttonDeleteDay;
        private System.Windows.Forms.Button buttonExitForm;
    }
}