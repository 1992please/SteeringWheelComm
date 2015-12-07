namespace Terminal2
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
            this.components = new System.ComponentModel.Container();
            this.joyTimer = new System.Windows.Forms.Timer(this.components);
            this.output = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // joyTimer
            // 
            this.joyTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(57, 72);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(145, 87);
            this.output.TabIndex = 0;
            this.output.Text = "button1";
            this.output.UseVisualStyleBackColor = true;
            this.output.Click += new System.EventHandler(this.output_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer joyTimer;
        private System.Windows.Forms.Button output;


    }
}

