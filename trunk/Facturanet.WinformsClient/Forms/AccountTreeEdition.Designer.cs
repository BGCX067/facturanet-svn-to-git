namespace Facturanet.WinformsClient.Forms
{
    partial class AccountTreeEdition
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.accountTreeListItemEditor1 = new Facturanet.WinformsClient.Controls.AccountTreeListItemEditor();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNewBrother = new System.Windows.Forms.Button();
            this.btnNewChild = new System.Windows.Forms.Button();
            this.btnBeginEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnEndEdit = new System.Windows.Forms.Button();
            this.contableAccountEditor1 = new Facturanet.WinformsClient.Controls.ContableAccountEditor();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.accountTreesTreeView1 = new Facturanet.WinformsClient.Controls.AccountTreesTreeView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(42, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "showInactiveItems";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.accountTreeListItemEditor1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.contableAccountEditor1);
            this.panel1.Location = new System.Drawing.Point(12, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 115);
            this.panel1.TabIndex = 4;
            // 
            // accountTreeListItemEditor1
            // 
            this.accountTreeListItemEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accountTreeListItemEditor1.EditableObject = null;
            this.accountTreeListItemEditor1.Location = new System.Drawing.Point(0, 0);
            this.accountTreeListItemEditor1.Name = "accountTreeListItemEditor1";
            this.accountTreeListItemEditor1.Size = new System.Drawing.Size(491, 115);
            this.accountTreeListItemEditor1.TabIndex = 0;
            this.accountTreeListItemEditor1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNewBrother);
            this.panel2.Controls.Add(this.btnNewChild);
            this.panel2.Controls.Add(this.btnBeginEdit);
            this.panel2.Controls.Add(this.btnCancelEdit);
            this.panel2.Controls.Add(this.btnEndEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(491, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 115);
            this.panel2.TabIndex = 5;
            // 
            // btnNewBrother
            // 
            this.btnNewBrother.Location = new System.Drawing.Point(37, 0);
            this.btnNewBrother.Name = "btnNewBrother";
            this.btnNewBrother.Size = new System.Drawing.Size(37, 23);
            this.btnNewBrother.TabIndex = 6;
            this.btnNewBrother.Text = "Bro";
            this.btnNewBrother.UseVisualStyleBackColor = true;
            this.btnNewBrother.Click += new System.EventHandler(this.btnNewBrother_Click);
            // 
            // btnNewChild
            // 
            this.btnNewChild.Location = new System.Drawing.Point(0, 0);
            this.btnNewChild.Name = "btnNewChild";
            this.btnNewChild.Size = new System.Drawing.Size(38, 23);
            this.btnNewChild.TabIndex = 5;
            this.btnNewChild.Text = "Child";
            this.btnNewChild.UseVisualStyleBackColor = true;
            this.btnNewChild.Click += new System.EventHandler(this.btnNewChild_Click);
            // 
            // btnBeginEdit
            // 
            this.btnBeginEdit.Location = new System.Drawing.Point(0, 29);
            this.btnBeginEdit.Name = "btnBeginEdit";
            this.btnBeginEdit.Size = new System.Drawing.Size(75, 23);
            this.btnBeginEdit.TabIndex = 1;
            this.btnBeginEdit.Text = "Edit";
            this.btnBeginEdit.UseVisualStyleBackColor = true;
            this.btnBeginEdit.Click += new System.EventHandler(this.btnBeginEdit_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.Location = new System.Drawing.Point(0, 87);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEdit.TabIndex = 3;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.UseVisualStyleBackColor = true;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // btnEndEdit
            // 
            this.btnEndEdit.Location = new System.Drawing.Point(0, 58);
            this.btnEndEdit.Name = "btnEndEdit";
            this.btnEndEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEndEdit.TabIndex = 2;
            this.btnEndEdit.Text = "Accept";
            this.btnEndEdit.UseVisualStyleBackColor = true;
            this.btnEndEdit.Click += new System.EventHandler(this.btnEndEdit_Click);
            // 
            // contableAccountEditor1
            // 
            this.contableAccountEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contableAccountEditor1.EditableObject = null;
            this.contableAccountEditor1.Location = new System.Drawing.Point(0, 0);
            this.contableAccountEditor1.Name = "contableAccountEditor1";
            this.contableAccountEditor1.Size = new System.Drawing.Size(566, 115);
            this.contableAccountEditor1.TabIndex = 4;
            this.contableAccountEditor1.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(222, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(315, 354);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // accountTreesTreeView1
            // 
            this.accountTreesTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.accountTreesTreeView1.Location = new System.Drawing.Point(12, 33);
            this.accountTreesTreeView1.Name = "accountTreesTreeView1";
            this.accountTreesTreeView1.Size = new System.Drawing.Size(567, 185);
            this.accountTreesTreeView1.TabIndex = 7;
            this.accountTreesTreeView1.CurrentChanged += new System.EventHandler(this.accountTreesTreeView1_CurrentChanged);
            // 
            // AccountTreeEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 379);
            this.Controls.Add(this.accountTreesTreeView1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Name = "AccountTreeEdition";
            this.Text = "AccountTreeEdition";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private Facturanet.WinformsClient.Controls.AccountTreeListItemEditor accountTreeListItemEditor1;
        private System.Windows.Forms.Button btnBeginEdit;
        private System.Windows.Forms.Button btnEndEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private Facturanet.WinformsClient.Controls.ContableAccountEditor contableAccountEditor1;
        private System.Windows.Forms.Button btnNewChild;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewBrother;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private Facturanet.WinformsClient.Controls.AccountTreesTreeView accountTreesTreeView1;
    }
}