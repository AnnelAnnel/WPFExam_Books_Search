using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Design;
using Microsoft.Win32;

namespace SoulMelody.Usermenu
{
    /// <summary>
    /// Interaction logic for EmoSearchUC.xaml
    /// </summary>
    public partial class EmoSearchUC : UserControl
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("86ed05317afc43d2a74e0c29613b64c1", "https://myfacemelodyapp.cognitiveservices.azure.com/face/v1.0");
               
        private static Face[] found;
        private string filePath;

        UserMenu um;
        int userId;
        string emotion;
        public EmoSearchUC(UserMenu um, int userId)
        {
            InitializeComponent();
            this.um = um;
            this.userId = userId;
            BtnProcess.IsEnabled = false;
            ShowBooks.IsEnabled = false;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFrame = new OpenFileDialog { Filter = "JPEG Image(*.jpg)|*.jpg" };
            var result = openFrame.ShowDialog(um);
            if (!(bool)result)
                return;
            filePath = openFrame.FileName;
            var fileUri = new Uri(filePath);
            BitmapImage bitMapSource = new BitmapImage();
            bitMapSource.BeginInit();
            bitMapSource.CacheOption = BitmapCacheOption.None;
            bitMapSource.UriSource = fileUri;
            bitMapSource.EndInit();
            faceImage.Source = bitMapSource;
            BtnProcess.IsEnabled = true;
        }

        private async Task<Face[]> UploadAndDetectFaces(string imageFilePath)
        {
            try
            {
                using (Stream imageFileStream = File.OpenRead(imageFilePath))
                {
                    var faces = await faceServiceClient.DetectAsync(imageFileStream,
                        true,
                        true,
                        new FaceAttributeType[] {
                    FaceAttributeType.Gender,
                    FaceAttributeType.Age,
                    FaceAttributeType.Emotion
                        });
                    return faces.ToArray();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Face[0];
            }


        }

        private async void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                found = await UploadAndDetectFaces(filePath);



                um.Title = "Just a second...or two";
                if (found.Length != 0)
                    ShowBooks.IsEnabled = true;
                else
                    MessageBox.Show("No detected faces");

                MainEmotion.Content = "Gender: " + found[0].FaceAttributes.Gender.ToString();

                MainEmotion1.Content ="Age: " + found[0].FaceAttributes.Age.ToString();
                StringBuilder sb = new StringBuilder();
                var emotionScores = found[0].FaceAttributes.Emotion;
                if (emotionScores.Anger >= 0.6f) sb.Append(
                    String.Format("anger {0:F1}%, ", emotionScores.Anger * 100));
                if (emotionScores.Contempt >= 0.6f) sb.Append(
                    String.Format("contempt {0:F1}%, ", emotionScores.Contempt * 100));
                if (emotionScores.Disgust >= 0.6f) sb.Append(
                    String.Format("disgust {0:F1}%, ", emotionScores.Disgust * 100));
                if (emotionScores.Fear >= 0.6f) sb.Append(
                    String.Format("fear {0:F1}%, ", emotionScores.Fear * 100));
                if (emotionScores.Happiness >= 0.6f) sb.Append(
                    String.Format("happiness {0:F1}%, ", emotionScores.Happiness * 100));
                if (emotionScores.Neutral >= 0.6f) sb.Append(
                    String.Format("neutral {0:F1}%, ", emotionScores.Neutral * 100));
                if (emotionScores.Sadness >= 0.6f) sb.Append(
                    String.Format("sadness {0:F1}%, ", emotionScores.Sadness * 100));
                if (emotionScores.Surprise >= 0.6f) sb.Append(
                    String.Format("surprise {0:F1}%, ", emotionScores.Surprise * 100));

                MainEmotion2.Content = "Emotion: " + sb;
                emotion = sb.ToString();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private string FaceDescription(Face face)
        {
            StringBuilder sb = new StringBuilder();


            // Add the gender, age, and smile.
            sb.Append(face.FaceAttributes.Gender);
            sb.Append(", ");
            sb.Append(face.FaceAttributes.Age);
            sb.Append(", ");
            

            // Add the emotions. Display all emotions over 10%.
            sb.Append("Emotion: ");

            var emotionScores = face.FaceAttributes.Emotion;
            if (emotionScores.Anger >= 0.1f) sb.Append(
                String.Format("anger {0:F1}%, ", emotionScores.Anger * 100));
            if (emotionScores.Contempt >= 0.1f) sb.Append(
                String.Format("contempt {0:F1}%, ", emotionScores.Contempt * 100));
            if (emotionScores.Disgust >= 0.1f) sb.Append(
                String.Format("disgust {0:F1}%, ", emotionScores.Disgust * 100));
            if (emotionScores.Fear >= 0.1f) sb.Append(
                String.Format("fear {0:F1}%, ", emotionScores.Fear * 100));
            if (emotionScores.Happiness >= 0.1f) sb.Append(
                String.Format("happiness {0:F1}%, ", emotionScores.Happiness * 100));
            if (emotionScores.Neutral >= 0.1f) sb.Append(
                String.Format("neutral {0:F1}%, ", emotionScores.Neutral * 100));
            if (emotionScores.Sadness >= 0.1f) sb.Append(
                String.Format("sadness {0:F1}%, ", emotionScores.Sadness * 100));
            if (emotionScores.Surprise >= 0.1f) sb.Append(
                String.Format("surprise {0:F1}%, ", emotionScores.Surprise * 100));



            // Return the built string.
            return sb.ToString();
        }

        private void FaceImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (found == null)
                return;

            // Find the mouse position relative to the image.
            System.Windows.Point mouseXY = e.GetPosition(faceImage);

            ImageSource imageSource = faceImage.Source;
            BitmapSource bitmapSource = (BitmapSource)imageSource;


            // Check if this mouse position is over a face rectangle.
            //bool mouseOverFace = false;

            List<Face> faceList = found.ToList();

            var scale = faceImage.ActualWidth / (bitmapSource.PixelWidth);

            for (int i = 0; i < faceList.Count; ++i)
            {
                FaceRectangle fr = faceList[i].FaceRectangle;
                double left = fr.Left * scale;
                double top = fr.Top * scale;
                double width = fr.Width * scale;
                double height = fr.Height * scale;

                // Display the face description if the mouse is over this face rectangle.
                if (mouseXY.X >= left && mouseXY.X <= left + width &&
                    mouseXY.Y >= top && mouseXY.Y <= top + height)
                {
                    StatusBarText.Text = FaceDescription(faceList[i]);
                    //mouseOverFace = true;
                    break;
                }
                else
                {
                    StatusBarText.Text = "No faces hovered";
                }
            }


        }


        private void ShowBooks_Click(object sender, RoutedEventArgs e)
        {
            int emotionId = 0;
            if (emotion.Contains("anger"))
                emotionId = 1;
            if (emotion.Contains("contempt"))
                emotionId = 2;
            if (emotion.Contains("disgust"))
                emotionId = 3;
            if (emotion.Contains("fear"))
                emotionId = 4;
            if (emotion.Contains("neutral"))
                emotionId = 5;
            if (emotion.Contains("happiness"))
                emotionId = 6;
            if (emotion.Contains("sadness"))
                emotionId = 7;
            if (emotion.Contains("surprise"))
                emotionId = 8;

            
            //MessageBox.Show(emotion+" "+ emotionId.ToString());

            EmoBooksUC emoBooks = new EmoBooksUC(um, userId, emotionId);

            um.UCgrid.Children.Clear();
            um.UCgrid.Children.Add(emoBooks);
        }
    }
}
