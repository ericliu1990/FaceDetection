namespace CameraCapture
{
    partial class FaceDetection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceDetection));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImageBoxRGB = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbDetectFaceFile = new System.Windows.Forms.CheckBox();
            this.cbDetectEyeFile = new System.Windows.Forms.CheckBox();
            this.LoadImage = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files (*.bmp;*.gif;*.exif;*.jpg;*.png;*.tiff)|*.bmp;*.gif;*.exif;*.jpg;*.jp" +
    "eg;*.png;*.tiff|All Files (*.*)|*.*";
            // 
            // webCameraImageBoxRGB
            // 
            this.ImageBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBoxRGB.Location = new System.Drawing.Point(37, 54);
            this.ImageBoxRGB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImageBoxRGB.Name = "webCameraImageBoxRGB";
            this.ImageBoxRGB.Size = new System.Drawing.Size(659, 569);
            this.ImageBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBoxRGB.TabIndex = 2;
            this.ImageBoxRGB.TabStop = false;
            this.ImageBoxRGB.OnZoomScaleChange += new System.EventHandler(this.DetectOrgansInFaceFromStaticImage);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(37, 20);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(164, 28);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Webcam";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbDetectFaceFile
            // 
            this.cbDetectFaceFile.AutoSize = true;
            this.cbDetectFaceFile.Location = new System.Drawing.Point(221, 22);
            this.cbDetectFaceFile.Margin = new System.Windows.Forms.Padding(4);
            this.cbDetectFaceFile.Name = "cbDetectFaceFile";
            this.cbDetectFaceFile.Size = new System.Drawing.Size(106, 21);
            this.cbDetectFaceFile.TabIndex = 7;
            this.cbDetectFaceFile.Text = "Detect Face";
            this.cbDetectFaceFile.UseVisualStyleBackColor = true;
            this.cbDetectFaceFile.CheckStateChanged += new System.EventHandler(this.DetectOrgansInFaceFromStaticImage);
            // 
            // cbDetectEyeFile
            // 
            this.cbDetectEyeFile.AutoSize = true;
            this.cbDetectEyeFile.Location = new System.Drawing.Point(343, 22);
            this.cbDetectEyeFile.Margin = new System.Windows.Forms.Padding(4);
            this.cbDetectEyeFile.Name = "cbDetectEyeFile";
            this.cbDetectEyeFile.Size = new System.Drawing.Size(99, 21);
            this.cbDetectEyeFile.TabIndex = 8;
            this.cbDetectEyeFile.Text = "Detect Eye";
            this.cbDetectEyeFile.UseVisualStyleBackColor = true;
            this.cbDetectEyeFile.CheckStateChanged += new System.EventHandler(this.DetectOrgansInFaceFromStaticImage);
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(475, 17);
            this.LoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(116, 28);
            this.LoadImage.TabIndex = 14;
            this.LoadImage.Text = "Load Image";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(702, 54);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(366, 360);
            this.pictureBox.TabIndex = 15;
            this.pictureBox.TabStop = false;
            // 
            // FaceDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 649);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.cbDetectEyeFile);
            this.Controls.Add(this.cbDetectFaceFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.ImageBoxRGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FaceDetection";
            this.Text = "Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CameraCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Emgu.CV.UI.ImageBox ImageBoxRGB;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbDetectFaceFile;
        private System.Windows.Forms.CheckBox cbDetectEyeFile;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

