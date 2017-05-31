namespace Fractal.Forms
{
    partial class Form_Julia_Config
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
            this.txt_real = new System.Windows.Forms.TextBox();
            this.txt_imaginery = new System.Windows.Forms.TextBox();
            this.lbl_real = new System.Windows.Forms.Label();
            this.lbl_imaginery = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hsc_real = new System.Windows.Forms.HScrollBar();
            this.hsc_imaginery = new System.Windows.Forms.HScrollBar();
            this.lbl_width = new System.Windows.Forms.Label();
            this.lbl_height = new System.Windows.Forms.Label();
            this.txt_width = new System.Windows.Forms.TextBox();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.lbl_zoom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_real
            // 
            this.txt_real.Location = new System.Drawing.Point(100, 12);
            this.txt_real.Name = "txt_real";
            this.txt_real.Size = new System.Drawing.Size(100, 20);
            this.txt_real.TabIndex = 0;
            // 
            // txt_imaginery
            // 
            this.txt_imaginery.Location = new System.Drawing.Point(100, 38);
            this.txt_imaginery.Name = "txt_imaginery";
            this.txt_imaginery.Size = new System.Drawing.Size(100, 20);
            this.txt_imaginery.TabIndex = 1;
            // 
            // lbl_real
            // 
            this.lbl_real.AutoSize = true;
            this.lbl_real.Location = new System.Drawing.Point(61, 15);
            this.lbl_real.Name = "lbl_real";
            this.lbl_real.Size = new System.Drawing.Size(29, 13);
            this.lbl_real.TabIndex = 2;
            this.lbl_real.Text = "Real";
            // 
            // lbl_imaginery
            // 
            this.lbl_imaginery.AutoSize = true;
            this.lbl_imaginery.Location = new System.Drawing.Point(38, 41);
            this.lbl_imaginery.Name = "lbl_imaginery";
            this.lbl_imaginery.Size = new System.Drawing.Size(52, 13);
            this.lbl_imaginery.TabIndex = 3;
            this.lbl_imaginery.Text = "Imaginery";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hsc_real
            // 
            this.hsc_real.Location = new System.Drawing.Point(203, 15);
            this.hsc_real.Maximum = 1000;
            this.hsc_real.Name = "hsc_real";
            this.hsc_real.Size = new System.Drawing.Size(175, 17);
            this.hsc_real.TabIndex = 5;
            this.hsc_real.Value = 500;
            this.hsc_real.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsc_real_Scroll);
            // 
            // hsc_imaginery
            // 
            this.hsc_imaginery.Location = new System.Drawing.Point(203, 41);
            this.hsc_imaginery.Maximum = 1000;
            this.hsc_imaginery.Name = "hsc_imaginery";
            this.hsc_imaginery.Size = new System.Drawing.Size(175, 17);
            this.hsc_imaginery.TabIndex = 6;
            this.hsc_imaginery.Value = 500;
            this.hsc_imaginery.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsc_imaginery_Scroll);
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Location = new System.Drawing.Point(55, 67);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(35, 13);
            this.lbl_width.TabIndex = 7;
            this.lbl_width.Text = "Width";
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(55, 93);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(38, 13);
            this.lbl_height.TabIndex = 8;
            this.lbl_height.Text = "Height";
            // 
            // txt_width
            // 
            this.txt_width.Location = new System.Drawing.Point(100, 64);
            this.txt_width.Name = "txt_width";
            this.txt_width.Size = new System.Drawing.Size(100, 20);
            this.txt_width.TabIndex = 9;
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(100, 90);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(100, 20);
            this.txt_height.TabIndex = 10;
            // 
            // lbl_zoom
            // 
            this.lbl_zoom.AutoSize = true;
            this.lbl_zoom.Location = new System.Drawing.Point(206, 67);
            this.lbl_zoom.MaximumSize = new System.Drawing.Size(220, 0);
            this.lbl_zoom.Name = "lbl_zoom";
            this.lbl_zoom.Size = new System.Drawing.Size(218, 26);
            this.lbl_zoom.TabIndex = 11;
            this.lbl_zoom.Text = "Move mouse over picture and scroll wheel to zoom in and out. Arrow keys move frac" +
    "tal.";
            // 
            // Form_Julia_Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 163);
            this.Controls.Add(this.lbl_zoom);
            this.Controls.Add(this.txt_height);
            this.Controls.Add(this.txt_width);
            this.Controls.Add(this.lbl_height);
            this.Controls.Add(this.lbl_width);
            this.Controls.Add(this.hsc_imaginery);
            this.Controls.Add(this.hsc_real);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_imaginery);
            this.Controls.Add(this.lbl_real);
            this.Controls.Add(this.txt_imaginery);
            this.Controls.Add(this.txt_real);
            this.MaximizeBox = false;
            this.Name = "Form_Julia_Config";
            this.Text = "Julia Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_real;
        private System.Windows.Forms.TextBox txt_imaginery;
        private System.Windows.Forms.Label lbl_real;
        private System.Windows.Forms.Label lbl_imaginery;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.HScrollBar hsc_real;
        private System.Windows.Forms.HScrollBar hsc_imaginery;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.TextBox txt_width;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label lbl_zoom;
    }
}