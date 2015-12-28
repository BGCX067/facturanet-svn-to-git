namespace Facturanet.WinformsClient.Controls
{
    partial class AccountTreeListItemEditor
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.edName = new System.Windows.Forms.TextBox();
            this.edActive = new System.Windows.Forms.CheckBox();
            this.laId = new System.Windows.Forms.Label();
            this.edCode = new System.Windows.Forms.TextBox();
            this.edDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // edName
            // 
            this.edName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true));
            this.edName.Location = new System.Drawing.Point(6, 19);
            this.edName.Name = "edName";
            this.edName.Size = new System.Drawing.Size(100, 20);
            this.edName.TabIndex = 0;
            // 
            // edActive
            // 
            this.edActive.AutoSize = true;
            this.edActive.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "Active", true));
            this.edActive.Location = new System.Drawing.Point(112, 3);
            this.edActive.Name = "edActive";
            this.edActive.Size = new System.Drawing.Size(54, 17);
            this.edActive.TabIndex = 1;
            this.edActive.Text = "Active";
            this.edActive.UseVisualStyleBackColor = true;
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Id", true));
            this.laId.Location = new System.Drawing.Point(3, 3);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(24, 13);
            this.laId.TabIndex = 2;
            this.laId.Text = "laId";
            // 
            // edCode
            // 
            this.edCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Code", true));
            this.edCode.Location = new System.Drawing.Point(6, 45);
            this.edCode.Name = "edCode";
            this.edCode.Size = new System.Drawing.Size(100, 20);
            this.edCode.TabIndex = 3;
            // 
            // edDescription
            // 
            this.edDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Description", true));
            this.edDescription.Location = new System.Drawing.Point(112, 45);
            this.edDescription.Name = "edDescription";
            this.edDescription.Size = new System.Drawing.Size(100, 20);
            this.edDescription.TabIndex = 4;
            // 
            // AccountTreeListItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edDescription);
            this.Controls.Add(this.edCode);
            this.Controls.Add(this.laId);
            this.Controls.Add(this.edActive);
            this.Controls.Add(this.edName);
            this.Name = "AccountTreeListItemEditor";
            this.Size = new System.Drawing.Size(225, 80);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edName;
        private System.Windows.Forms.CheckBox edActive;
        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.TextBox edCode;
        private System.Windows.Forms.TextBox edDescription;

    }
}
