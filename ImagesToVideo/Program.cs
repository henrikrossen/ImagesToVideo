using System;

namespace ImagesToVideo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new CommandOptions();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // Consume CommandOptions instance properties
                Console.WriteLine(options.InputPath);
                Console.WriteLine(options.ImageWidth);
                Console.WriteLine(options.ImageHeight);
                Console.WriteLine(options.FileName);

                new ImageProcessor().CombineImagesToVideo(options.InputPath, options.ImageWidth, options.ImageHeight, options.FileName);
            }
        }
    }
}