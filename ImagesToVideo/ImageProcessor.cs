using AForge.Video.FFMPEG;
using System.Drawing;
using System.IO;

namespace ImagesToVideo
{
    public class ImageProcessor
    {
        /// <summary>
        /// Combines PNG files to AVI video.
        /// </summary>
        /// <param name="inputPath"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="fileName"></param>
        public void CombineImagesToVideo(string inputPath, int width, int height, string fileName)
        {
            var imagePaths = Directory.GetFiles(inputPath, "*.png");

            using (var videoWriter = new VideoFileWriter())
            {
                var output = Path.Combine(inputPath, fileName);
                videoWriter.Open(output, width, height, 1, VideoCodec.MPEG4);

                foreach (var imagePath in imagePaths)
                {
                    using (var image = Image.FromFile(imagePath) as Bitmap)
                    {
                        var resizedImage = ResizeImage(image, new Size(width, height));
                        videoWriter.WriteVideoFrame(resizedImage);
                    }
                }
            }
        }

        public static Bitmap ResizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
    }
}