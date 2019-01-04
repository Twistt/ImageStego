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
            this.button2 = new System.Windows.Forms.Button();
            this.btnOpenAudio = new System.Windows.Forms.Button();
            this.tbBinaryFile = new System.Windows.Forms.TextBox();
            this.btnEncodeAudio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecodeFile = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.pictureBox1.Size = new System.Drawing.Size(455, 413);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnValidated
            // 
            this.btnValidated.Location = new System.Drawing.Point(380, 416);
            this.btnValidated.Name = "btnValidated";
            this.btnValidated.Size = new System.Drawing.Size(75, 28);
            this.btnValidated.TabIndex = 4;
            this.btnValidated.Text = "Validate";
            this.btnValidated.UseVisualStyleBackColor = true;
            this.btnValidated.Click += new System.EventHandler(this.btnValidated_Click);
            // 
            // tbTextToEncode
            // 
            this.tbTextToEncode.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTextToEncode.Location = new System.Drawing.Point(3, 16);
            this.tbTextToEncode.Multiline = true;
            this.tbTextToEncode.Name = "tbTextToEncode";
            this.tbTextToEncode.Size = new System.Drawing.Size(281, 220);
            this.tbTextToEncode.TabIndex = 5;
            // 
            // btnEncodeText
            // 
            this.btnEncodeText.Location = new System.Drawing.Point(6, 274);
            this.btnEncodeText.Name = "btnEncodeText";
            this.btnEncodeText.Size = new System.Drawing.Size(132, 23);
            this.btnEncodeText.TabIndex = 6;
            this.btnEncodeText.Text = "Encode Text";
            this.btnEncodeText.UseVisualStyleBackColor = true;
            this.btnEncodeText.Click += new System.EventHandler(this.btnEncodeText_Click);
            // 
            // btnDecodeText
            // 
            this.btnDecodeText.Location = new System.Drawing.Point(144, 274);
            this.btnDecodeText.Name = "btnDecodeText";
            this.btnDecodeText.Size = new System.Drawing.Size(131, 23);
            this.btnDecodeText.TabIndex = 7;
            this.btnDecodeText.Text = "Decode Text";
            this.btnDecodeText.UseVisualStyleBackColor = true;
            this.btnDecodeText.Click += new System.EventHandler(this.btnDecodeText_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDecodeFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnEncodeAudio);
            this.groupBox1.Controls.Add(this.tbBinaryFile);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.btnOpenAudio);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.tbTextToEncode);
            this.groupBox1.Controls.Add(this.btnDecodeText);
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
            this.button1.Location = new System.Drawing.Point(0, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Open Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Create Signature";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOpenAudio
            // 
            this.btnOpenAudio.Location = new System.Drawing.Point(7, 340);
            this.btnOpenAudio.Name = "btnOpenAudio";
            this.btnOpenAudio.Size = new System.Drawing.Size(131, 23);
            this.btnOpenAudio.TabIndex = 9;
            this.btnOpenAudio.Text = "Open File";
            this.btnOpenAudio.UseVisualStyleBackColor = true;
            // 
            // tbBinaryFile
            // 
            this.tbBinaryFile.Location = new System.Drawing.Point(7, 314);
            this.tbBinaryFile.Name = "tbBinaryFile";
            this.tbBinaryFile.Size = new System.Drawing.Size(267, 20);
            this.tbBinaryFile.TabIndex = 10;
            this.tbBinaryFile.Text = "D:\\abraham.mp3";
            // 
            // btnEncodeAudio
            // 
            this.btnEncodeAudio.Location = new System.Drawing.Point(144, 340);
            this.btnEncodeAudio.Name = "btnEncodeAudio";
            this.btnEncodeAudio.Size = new System.Drawing.Size(131, 23);
            this.btnEncodeAudio.TabIndex = 11;
            this.btnEncodeAudio.Text = "Encode File";
            this.btnEncodeAudio.UseVisualStyleBackColor = true;
            this.btnEncodeAudio.Click += new System.EventHandler(this.btnEncodeAudio_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 58);
            this.label1.TabIndex = 12;
            this.label1.Text = "Notes: JPG will be converted to png because image compression. Use GIF or BMP or " +
    "PNG. If using alpha mode dont use BMP. Dont use really skinny images. For best r" +
    "esult use large squarish images.";
            // 
            // btnDecodeFile
            // 
            this.btnDecodeFile.Location = new System.Drawing.Point(143, 369);
            this.btnDecodeFile.Name = "btnDecodeFile";
            this.btnDecodeFile.Size = new System.Drawing.Size(131, 23);
            this.btnDecodeFile.TabIndex = 13;
            this.btnDecodeFile.Text = "Decode File";
            this.btnDecodeFile.UseVisualStyleBackColor = true;
            this.btnDecodeFile.Click += new System.EventHandler(this.btnDecodeFile_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 369);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Save Encoded Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnValidated);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnEncodeAudio;
        private System.Windows.Forms.TextBox tbBinaryFile;
        private System.Windows.Forms.Button btnOpenAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecodeFile;
        private System.Windows.Forms.Button button3;
    }
}

