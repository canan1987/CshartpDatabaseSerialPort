
namespace DatabaseApplication
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
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.btnClosePort = new System.Windows.Forms.Button();
            this.btnDispData = new System.Windows.Forms.Button();
            this.dgViewDispData = new System.Windows.Forms.DataGridView();
            this.btnWriteData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewDispData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Location = new System.Drawing.Point(32, 24);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPort.TabIndex = 0;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // btnClosePort
            // 
            this.btnClosePort.Location = new System.Drawing.Point(233, 23);
            this.btnClosePort.Name = "btnClosePort";
            this.btnClosePort.Size = new System.Drawing.Size(75, 23);
            this.btnClosePort.TabIndex = 1;
            this.btnClosePort.Text = "Close Port";
            this.btnClosePort.UseVisualStyleBackColor = true;
            // 
            // btnDispData
            // 
            this.btnDispData.Location = new System.Drawing.Point(384, 23);
            this.btnDispData.Name = "btnDispData";
            this.btnDispData.Size = new System.Drawing.Size(75, 23);
            this.btnDispData.TabIndex = 2;
            this.btnDispData.Text = "Display Data";
            this.btnDispData.UseVisualStyleBackColor = true;
            this.btnDispData.Click += new System.EventHandler(this.btnDispData_Click);
            // 
            // dgViewDispData
            // 
            this.dgViewDispData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewDispData.Location = new System.Drawing.Point(23, 117);
            this.dgViewDispData.Name = "dgViewDispData";
            this.dgViewDispData.Size = new System.Drawing.Size(750, 294);
            this.dgViewDispData.TabIndex = 3;
            // 
            // btnWriteData
            // 
            this.btnWriteData.Location = new System.Drawing.Point(516, 23);
            this.btnWriteData.Name = "btnWriteData";
            this.btnWriteData.Size = new System.Drawing.Size(75, 23);
            this.btnWriteData.TabIndex = 4;
            this.btnWriteData.Text = "Write Data";
            this.btnWriteData.UseVisualStyleBackColor = true;
            this.btnWriteData.Click += new System.EventHandler(this.btnWriteData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWriteData);
            this.Controls.Add(this.dgViewDispData);
            this.Controls.Add(this.btnDispData);
            this.Controls.Add(this.btnClosePort);
            this.Controls.Add(this.btnOpenPort);
            this.Name = "Form1";
            this.Text = "Main Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgViewDispData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.Button btnClosePort;
        private System.Windows.Forms.Button btnDispData;
        private System.Windows.Forms.DataGridView dgViewDispData;
        private System.Windows.Forms.Button btnWriteData;
    }
}

