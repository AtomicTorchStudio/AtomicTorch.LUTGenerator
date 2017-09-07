namespace AtomicTorch.LUTGenerator
{
    #region

    using System;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    #endregion

    internal class Program
    {
        private static void DrawLayer(WriteableBitmap writeableBitmap, int size, int sliceIndex)
        {
            var sizeMinusOne = (double)(size - 1);
            var xOffset = sliceIndex * size;
            for (var y = 0; y < size; y++)
            for (var x = 0; x < size; x++)
            {
                var r = byte.MaxValue * (x / sizeMinusOne);
                var g = byte.MaxValue * (y / sizeMinusOne);
                var b = byte.MaxValue * (sliceIndex / sizeMinusOne);

                writeableBitmap.SetPixel(
                    x + xOffset,
                    y,
                    Color.FromRgb(
                        (byte)Math.Round(r, MidpointRounding.AwayFromZero),
                        (byte)Math.Round(g, MidpointRounding.AwayFromZero),
                        (byte)Math.Round(b, MidpointRounding.AwayFromZero)));
            }
        }

        private static void Main(string[] args)
        {
            int size = 0;
            try
            {
                size = int.Parse(args[0]);
            }
            catch
            {
            }

            if (size < 4
                || size > 128)
            {
                Console.WriteLine("Please provide the argument - size of the LUT texture - from 4 to 128.");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                return;
            }

            RenderAndSaveToFile(size);
        }

        private static void RenderAndSaveToFile(int size)
        {
            var widthStrip = size * size;

            var writeableBitmap = new WriteableBitmap(widthStrip, size, 96, 96, PixelFormats.Bgra32, null);
            writeableBitmap.Clear(Color.FromArgb(byte.MaxValue, 0, 0, 0));

            for (var sliceIndex = 0; sliceIndex < size; sliceIndex++)
            {
                DrawLayer(writeableBitmap, size, sliceIndex);
            }

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(
                BitmapFrame.Create(new FormatConvertedBitmap(writeableBitmap, PixelFormats.Bgr24, null, 0)));

            var resultPng = $"LUT{size}.png";
            using (var file = File.Open(resultPng, FileMode.Create))
            {
                encoder.Save(file);
                Console.WriteLine("File saved: " + resultPng);
            }
        }
    }
}