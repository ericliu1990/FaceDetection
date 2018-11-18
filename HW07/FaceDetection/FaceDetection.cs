using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Globalization;



namespace CameraCapture
{
    public partial class FaceDetection : Form
    {   //Global Variables
        private Capture capturedCaptureFromWebcam;     //a capture from the webcam   
        private bool isCaptureInProgress; // if capture is in being captured?
        private HaarCascade faceHaar; // the data for the face features
        private HaarCascade eyeHaar;// the data for the eyes features
        private HaarCascade mouthHaar;// the data for the mouth features
        private bool cbFace; 
        private Bitmap originalImageFromPics; // the original image loaded bu user
        private Bitmap temporaryImageCopiedFromOriginal; // an image for temporary usages
        private Bitmap finalImage;// the image for showing after some detection
        private bool imageFit = false;
        // global fonts
        MCvFont faceFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 1.0, 1.0); // fonts for the dispaly
        MCvFont eyeFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 1.0, 1.0);// fonts for display
        MCvFont mouthFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_SIMPLEX, 2.0, 2.0);// fonts for display
        

        public FaceDetection()
        {
            InitializeComponent(); // this method initialize the form components
            //cbFace = cbDetectFaceFile.Checked.ToString();
        }

        
        private void DetectOrgansInFace(object sender, EventArgs arg)
        {
            #region
            /*
             * This function capture frams from the webcam and detects organs in it
             * the organs that is being detected are: Face, Eye, And mouth 
             * 
             */
            Image<Bgr, Byte> imageFrameCapturedFromCamera = capturedCaptureFromWebcam.QueryFrame(); // an image will be captured from the camera and will be processed
            if (imageFrameCapturedFromCamera != null)
            {
                Image<Gray, byte> grayOfImageFrameCapturedFromCamera = imageFrameCapturedFromCamera.Convert<Gray, byte>();
                // the processing will be done on the GRAY SCALE of the captured images bit the display is yet RGB

                if (cbDetectFaceFile.Checked) // checkBox to check if the user wants to detect the Face.
                {
                    var faces // an array that holds the faceS detected in the gray scal image
                        = grayOfImageFrameCapturedFromCamera.DetectHaarCascade(faceHaar, //the geometrical features of the face stored in XML format used for detection
                        1.1, // a good coeffient to detect the face
                        5, //a good coeffient to detect the face
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(25, 25))[0];
                    foreach (var face in faces)
                    {
                        imageFrameCapturedFromCamera.Draw(face.rect, new Bgr(Color.Blue), 10); // draw a rectangle on the detected faces
                        int faceLableX = face.rect.X; // finding X left-top corner of the face for labeling
                        int faceLableY = face.rect.Y; // finding Y left-top corner of the face for labeling
                        Point p = new Point(faceLableX, faceLableY); // create a point to attach a lable "FACE" to the point
                        String s = "Face";// just a place holder for the "Face" that are goiong to be placed on the top-left corner of the face
                        imageFrameCapturedFromCamera.Draw(s, ref faceFont, p, new Bgr(Color.Blue)); // Add "Face" lable to the detected face

                    }
                }

                if (cbDetectEyeFile.Checked)// checkBox to check if the user wants to detect the EYEs.
                {
                    var eyes // an araay that holds the detcted eyes and later on we will loop over them 
                        = grayOfImageFrameCapturedFromCamera.DetectHaarCascade(eyeHaar, // the geometrical features of the EYE are stored in the format of XML
                        4,// after trial and error this coeeffient is ok
                        3, // after trial and error this coefficient is ok
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(1, 1))[0];
                    foreach (var eye in eyes) // more than one eye may be detected so for each eye there will be a rectangle
                    {
                        imageFrameCapturedFromCamera.Draw(eye.rect, new Bgr(Color.Red), 3);
                        // for each detecte eye in the image a rectangle will be drawn on the image
                        int eyeLableX = eye.rect.X; // find the X top-left corner of the eye for labeling
                        int eyeLableY = eye.rect.Y; // find the Y top-left corneer of the eye for lableing 
                        Point p = new Point(eyeLableX, eyeLableY); // create a point p to attach the lable "EYE" to it
                        String e = "Eye"; // just a place holder for the string "EYE" 
                        imageFrameCapturedFromCamera.Draw(e, ref eyeFont, p, new Bgr(Color.Red)); // add a string "EYE" to the image captured from webcam just to be distingushable
                    }
                
                }
                // display the image with the detected Face, Eye, Mouth based on user selection
                ImageBoxRGB.Image = imageFrameCapturedFromCamera; // processed image will be displayed
            }
            #endregion
        }

        private void DetectOrgansInFaceFromStaticImage(object sender, EventArgs arg)
        {
            #region
            /*
             * This function capture frams from the webcam and detects organs in it
             * the organs that is being detected are: Face, Eye, And mouth 
             * 
             */

            if (pictureBox.Image != null)
            {
                var StaticImage = new Image<Bgr, Byte>(new Bitmap(pictureBox.Image));
                var gray = StaticImage.Convert<Gray, Byte>();
                bool eyesdetected = false;
                // the processing will be done on the GRAY SCALE of the captured images bit the display is yet RGB

                if (cbDetectFaceFile.Checked) // checkBox to check if the user wants to detect the Face.
                {
                    var faces // an array that holds the faceS detected in the gray scal image
                        = gray.DetectHaarCascade(faceHaar, //the geometrical features of the face stored in XML format used for detection
                        1.1, // a good coeffient to detect the face
                       5, //a good coeffient to detect the face
                        HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        new Size(20, 20))[0];
                    foreach (var face in faces)
                    {
                        StaticImage.Draw(face.rect, new Bgr(Color.Blue), 5); // draw a rectangle on the detected faces
                        gray.ROI = face.rect;
                        if (cbDetectEyeFile.Checked)// checkBox to check if the user wants to detect the EYEs.
                        {
                            var eyes // an araay that holds the detcted eyes and later on we will loop over them 
                                = gray.DetectHaarCascade(
                                eyeHaar, // the geometrical features of the EYE are stored in the format of XML
                                1.1,// after trial and error this coeeffient is ok
                                3, // after trial and error this coefficient is ok
                                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                new Size(5, 5))[0];
                            
                            foreach (var eye in eyes) // more than one eye may be detected so for each eye there will be a rectangle
                            {
                                Rectangle eyeRect = eye.rect;
                                eyeRect.Offset(face.rect.X, face.rect.Y);
                                StaticImage.Draw(eyeRect, new Bgr(Color.LimeGreen), 3);
                            }
                            gray.ROI = Rectangle.Empty;
                            

                            eyesdetected = true;
                        }
                       
                    }
                }


                //if (!eyesdetected)
                //{
                //    if (cbDetectEyeFile.Checked)// checkBox to check if the user wants to detect the EYEs.
                //    {
                //        var eyes // an araay that holds the detcted eyes and later on we will loop over them 
                //            = gray.DetectHaarCascade(
                //            eyeHaar, // the geometrical features of the EYE are stored in the format of XML
                //            1.1,// after trial and error this coeeffient is ok
                //            10, // after trial and error this coefficient is ok
                //            HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                //            new Size(20, 20))[0];
                //        foreach (var eye in eyes) // more than one eye may be detected so for each eye there will be a rectangle
                //        {
                //            StaticImage.Draw(eye.rect, new Bgr(Color.LimeGreen), 2);
                //        }
                //    }
                //}

                // display the image with the detected Face, Eye, Mouth based on user selection
                ImageBoxRGB.Image = StaticImage; // processed image will be displayed
            }

            #endregion
        }


        private void btnStart_Click(object sender, EventArgs e)
        {            
            //cbFace = cbDetectFaceFile.Checked;
            if (capturedCaptureFromWebcam == null)
            {
                try
                {//try to capture new captures by invocking the new Capture() method
                    capturedCaptureFromWebcam = new Capture();
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message); 
                    // if the web cam is not ready so it transfered the error msg to the 
                    // display for the user. 
                    // to do list for myself: i should add another camera to
                    // capture the EAR form left and right. 
                }
            }           

            if (capturedCaptureFromWebcam != null)
            {
                if (isCaptureInProgress)
                {   // start capturing if the camera is not being used by any other application 
                    // and change the btnTxt to Start so user can start webcam
                    btnStart.Text = "Start Webcam"; //
                    Application.Idle -= DetectOrgansInFace;
                }
                else
                {
                    // capturing, so by press one more time it will pause/stop so
                    btnStart.Text = "Stop Webcam";
                    Application.Idle += DetectOrgansInFace;
                }

                isCaptureInProgress = !isCaptureInProgress;
            }
        }

        private void disposeDataFromTheMemory()
        {
            if (capturedCaptureFromWebcam != null)
                capturedCaptureFromWebcam.Dispose();
        }

        private void CameraCapture_Load(object sender, EventArgs e)
        {   // the XML files are loaded so no need for selection at this point
            // these are the files that storing the featurs for the 
            // i put them @C:\Dropbox\Dara\CLASS\CS740\HW\HW07\FaceDetection\bin\Debug
            // but it can be loaed wthile runing the code
            try
            {
                faceHaar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");
                eyeHaar = new HaarCascade("haarcascade_eye.xml");
                mouthHaar = new HaarCascade("haarcascade_Mouth.xml");
            }
            catch(Exception ex)
            {

            }

        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    
                    originalImageFromPics = new Bitmap(openFileDialog.FileName);

                    // Convert pixel format
                    originalImageFromPics = originalImageFromPics.Clone(
                        new Rectangle(0, 0, originalImageFromPics.Width, originalImageFromPics.Height), PixelFormat.Format32bppArgb);

                    pictureBox.Image = originalImageFromPics;
                    pictureBox.Size = originalImageFromPics.Size;
                    //ImageBoxRGB = new Image<Bgr, Byte>(new Bitmap(originalImageFromPics));

                    DetectOrgansInFaceFromStaticImage(sender, e);

                }
                catch
                {
                    MessageBox.Show("Cannot open the file.");
                }

            }
        }

    }
}
