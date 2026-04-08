namespace Detective
{
    partial class DetectiveApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Люди");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Дела");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Версии");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Мотивы");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("Следственные действия");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("Локации");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("Встречи");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("Улики");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("Цепочки улик");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectiveApp));
            this.splitContainerDetective = new System.Windows.Forms.SplitContainer();
            this.treeViewdetective = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelBottomDetective = new System.Windows.Forms.Panel();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.pictureBoxDetective = new System.Windows.Forms.PictureBox();
            this.btnLoadJSON = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.dataGridViewDetective = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetective)).BeginInit();
            this.splitContainerDetective.Panel1.SuspendLayout();
            this.splitContainerDetective.Panel2.SuspendLayout();
            this.splitContainerDetective.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottomDetective.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetective)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerDetective
            // 
            this.splitContainerDetective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetective.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDetective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerDetective.Name = "splitContainerDetective";
            // 
            // splitContainerDetective.Panel1
            // 
            this.splitContainerDetective.Panel1.Controls.Add(this.treeViewdetective);
            // 
            // splitContainerDetective.Panel2
            // 
            this.splitContainerDetective.Panel2.Controls.Add(this.panelRight);
            this.splitContainerDetective.Size = new System.Drawing.Size(1476, 1033);
            this.splitContainerDetective.SplitterDistance = 372;
            this.splitContainerDetective.SplitterWidth = 6;
            this.splitContainerDetective.TabIndex = 0;
            // 
            // treeViewdetective
            // 
            this.treeViewdetective.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.treeViewdetective.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewdetective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewdetective.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewdetective.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.treeViewdetective.FullRowSelect = true;
            this.treeViewdetective.HideSelection = false;
            this.treeViewdetective.HotTracking = true;
            this.treeViewdetective.Indent = 20;
            this.treeViewdetective.ItemHeight = 45;
            this.treeViewdetective.Location = new System.Drawing.Point(0, 0);
            this.treeViewdetective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewdetective.Name = "treeViewdetective";
            treeNode37.Name = "Persons";
            treeNode37.Text = "Люди";
            treeNode38.Name = "Cases";
            treeNode38.Text = "Дела";
            treeNode39.Name = "Hypotheses";
            treeNode39.Text = "Версии";
            treeNode40.Name = "Motives";
            treeNode40.Text = "Мотивы";
            treeNode41.Name = "InvestigativeActions";
            treeNode41.Text = "Следственные действия";
            treeNode42.Name = "LocationTimes";
            treeNode42.Text = "Локации";
            treeNode43.Name = "Meetings";
            treeNode43.Text = "Встречи";
            treeNode44.Name = "Evidences";
            treeNode44.Text = "Улики";
            treeNode45.Name = "Clues";
            treeNode45.Text = "Цепочки улик";
            this.treeViewdetective.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode37,
            treeNode38,
            treeNode39,
            treeNode40,
            treeNode41,
            treeNode42,
            treeNode43,
            treeNode44,
            treeNode45});
            this.treeViewdetective.Size = new System.Drawing.Size(372, 1033);
            this.treeViewdetective.TabIndex = 0;
            this.treeViewdetective.TabStop = false;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelBottomDetective);
            this.panelRight.Controls.Add(this.dataGridViewDetective);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(1098, 1033);
            this.panelRight.TabIndex = 0;
            // 
            // panelBottomDetective
            // 
            this.panelBottomDetective.Controls.Add(this.btnShowDetails);
            this.panelBottomDetective.Controls.Add(this.pictureBoxDetective);
            this.panelBottomDetective.Controls.Add(this.btnLoadJSON);
            this.panelBottomDetective.Controls.Add(this.btnLoadXML);
            this.panelBottomDetective.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomDetective.Location = new System.Drawing.Point(0, 763);
            this.panelBottomDetective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBottomDetective.Name = "panelBottomDetective";
            this.panelBottomDetective.Size = new System.Drawing.Size(1098, 270);
            this.panelBottomDetective.TabIndex = 1;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowDetails.ForeColor = System.Drawing.Color.White;
            this.btnShowDetails.Location = new System.Drawing.Point(477, 27);
            this.btnShowDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(238, 102);
            this.btnShowDetails.TabIndex = 2;
            this.btnShowDetails.Text = "Показать детали";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // pictureBoxDetective
            // 
            this.pictureBoxDetective.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDetective.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDetective.Image")));
            this.pictureBoxDetective.InitialImage = null;
            this.pictureBoxDetective.Location = new System.Drawing.Point(762, 0);
            this.pictureBoxDetective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBoxDetective.Name = "pictureBoxDetective";
            this.pictureBoxDetective.Size = new System.Drawing.Size(336, 265);
            this.pictureBoxDetective.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDetective.TabIndex = 3;
            this.pictureBoxDetective.TabStop = false;
            // 
            // btnLoadJSON
            // 
            this.btnLoadJSON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadJSON.BackColor = System.Drawing.Color.Thistle;
            this.btnLoadJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadJSON.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadJSON.ForeColor = System.Drawing.Color.White;
            this.btnLoadJSON.Location = new System.Drawing.Point(243, 27);
            this.btnLoadJSON.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadJSON.Name = "btnLoadJSON";
            this.btnLoadJSON.Size = new System.Drawing.Size(226, 102);
            this.btnLoadJSON.TabIndex = 1;
            this.btnLoadJSON.Text = "Загрузить JSON";
            this.btnLoadJSON.UseVisualStyleBackColor = false;
            this.btnLoadJSON.Click += new System.EventHandler(this.btnLoadJSON_Click);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadXML.BackColor = System.Drawing.Color.BurlyWood;
            this.btnLoadXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadXML.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadXML.ForeColor = System.Drawing.Color.White;
            this.btnLoadXML.Location = new System.Drawing.Point(15, 27);
            this.btnLoadXML.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(220, 102);
            this.btnLoadXML.TabIndex = 0;
            this.btnLoadXML.Text = "Загрузить XML";
            this.btnLoadXML.UseVisualStyleBackColor = false;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // dataGridViewDetective
            // 
            this.dataGridViewDetective.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.dataGridViewDetective.AllowUserToAddRows = false;
            this.dataGridViewDetective.AllowUserToDeleteRows = false;
            this.dataGridViewDetective.AllowUserToResizeRows = false;
            this.dataGridViewDetective.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetective.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDetective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewDetective.MultiSelect = false;
            this.dataGridViewDetective.Name = "dataGridViewDetective";
            this.dataGridViewDetective.ReadOnly = true;
            this.dataGridViewDetective.RowHeadersVisible = false;
            this.dataGridViewDetective.RowHeadersWidth = 51;
            this.dataGridViewDetective.RowTemplate.Height = 24;
            this.dataGridViewDetective.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetective.Size = new System.Drawing.Size(1098, 1033);
            this.dataGridViewDetective.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // DetectiveApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 1033);
            this.Controls.Add(this.splitContainerDetective);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DetectiveApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Детективное агентство";
            this.splitContainerDetective.Panel1.ResumeLayout(false);
            this.splitContainerDetective.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDetective)).EndInit();
            this.splitContainerDetective.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelBottomDetective.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDetective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetective)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerDetective;
        private System.Windows.Forms.TreeView treeViewdetective;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dataGridViewDetective;
        private System.Windows.Forms.Panel panelBottomDetective;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnLoadJSON;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.PictureBox pictureBoxDetective;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

