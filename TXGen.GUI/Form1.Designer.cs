namespace TXGen.GUI
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGen = new System.Windows.Forms.Button();
            this.buttonIncrease = new System.Windows.Forms.Button();
            this.buttonDecrease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(269, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1024, 1024);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(28, 33);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(115, 34);
            this.buttonGen.TabIndex = 1;
            this.buttonGen.Text = "Generate";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // buttonIncrease
            // 
            this.buttonIncrease.Location = new System.Drawing.Point(28, 87);
            this.buttonIncrease.Name = "buttonIncrease";
            this.buttonIncrease.Size = new System.Drawing.Size(48, 34);
            this.buttonIncrease.TabIndex = 2;
            this.buttonIncrease.Text = "+";
            this.buttonIncrease.UseVisualStyleBackColor = true;
            this.buttonIncrease.Click += new System.EventHandler(this.buttonIncrease_Click);
            // 
            // buttonDecrease
            // 
            this.buttonDecrease.Location = new System.Drawing.Point(95, 87);
            this.buttonDecrease.Name = "buttonDecrease";
            this.buttonDecrease.Size = new System.Drawing.Size(48, 34);
            this.buttonDecrease.TabIndex = 3;
            this.buttonDecrease.Text = "-";
            this.buttonDecrease.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 1047);
            this.Controls.Add(this.buttonDecrease);
            this.Controls.Add(this.buttonIncrease);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button buttonGen;
        public System.Windows.Forms.Button buttonIncrease;
        public System.Windows.Forms.Button buttonDecrease;
    }
}

