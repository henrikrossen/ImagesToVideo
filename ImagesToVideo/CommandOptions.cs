using CommandLine;
using CommandLine.Text;

namespace ImagesToVideo
{
    // Command example:
    //ImagesToVideo -i C:\Images\ -w 200 -h 400
    internal class CommandOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input path to read.")]
        public string InputPath { get; set; }

        [Option('w', "width", Required = true, HelpText = "Width of images.")]
        public int ImageWidth { get; set; }

        [Option('h', "height", Required = true, HelpText = "Height of images.")]
        public int ImageHeight { get; set; }

        [Option("filename", DefaultValue = "video.avi", HelpText = "The file name of the generated video file.")]
        public string FileName { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}