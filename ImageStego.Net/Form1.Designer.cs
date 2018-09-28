namespace ImageStego.Net
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
            this.btnValidated = new System.Windows.Forms.Button();
            this.tbTextToEncode = new System.Windows.Forms.TextBox();
            this.btnEncodeText = new System.Windows.Forms.Button();
            this.btnDecodeText = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(504, 413);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnValidated
            // 
            this.btnValidated.Location = new System.Drawing.Point(6, 390);
            this.btnValidated.Name = "btnValidated";
            this.btnValidated.Size = new System.Drawing.Size(75, 58);
            this.btnValidated.TabIndex = 4;
            this.btnValidated.Text = "Validated";
            this.btnValidated.UseVisualStyleBackColor = true;
            // 
            // tbTextToEncode
            // 
            this.tbTextToEncode.Location = new System.Drawing.Point(6, 19);
            this.tbTextToEncode.Multiline = true;
            this.tbTextToEncode.Name = "tbTextToEncode";
            this.tbTextToEncode.Size = new System.Drawing.Size(269, 310);
            this.tbTextToEncode.TabIndex = 5;
            // 
            // btnEncodeText
            // 
            this.btnEncodeText.Location = new System.Drawing.Point(101, 390);
            this.btnEncodeText.Name = "btnEncodeText";
            this.btnEncodeText.Size = new System.Drawing.Size(174, 23);
            this.btnEncodeText.TabIndex = 6;
            this.btnEncodeText.Text = "Encode Text";
            this.btnEncodeText.UseVisualStyleBackColor = true;
            this.btnEncodeText.Click += new System.EventHandler(this.btnEncodeText_Click);
            // 
            // btnDecodeText
            // 
            this.btnDecodeText.Location = new System.Drawing.Point(101, 425);
            this.btnDecodeText.Name = "btnDecodeText";
            this.btnDecodeText.Size = new System.Drawing.Size(174, 23);
            this.btnDecodeText.TabIndex = 7;
            this.btnDecodeText.Text = "Decode Text";
            this.btnDecodeText.UseVisualStyleBackColor = true;
            this.btnDecodeText.Click += new System.EventHandler(this.btnDecodeText_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbTextToEncode);
            this.groupBox1.Controls.Add(this.btnDecodeText);
            this.groupBox1.Controls.Add(this.btnValidated);
            this.groupBox1.Controls.Add(this.btnEncodeText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(522, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 461);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encode/Decode Message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Open Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Twisted Steno";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnValidated;
        private System.Windows.Forms.TextBox tbTextToEncode;
        private System.Windows.Forms.Button btnEncodeText;
        private System.Windows.Forms.Button btnDecodeText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

