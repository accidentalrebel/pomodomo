namespace ToDoList
{
    partial class ToDoForm
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
            this.tbx_taskEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx_taskEntry
            // 
            this.tbx_taskEntry.Location = new System.Drawing.Point(55, 84);
            this.tbx_taskEntry.Name = "tbx_taskEntry";
            this.tbx_taskEntry.Size = new System.Drawing.Size(184, 20);
            this.tbx_taskEntry.TabIndex = 0;
            this.tbx_taskEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_taskEntry_KeyPress);
            // 
            // ToDoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbx_taskEntry);
            this.Name = "ToDoForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_taskEntry;
    }
}

