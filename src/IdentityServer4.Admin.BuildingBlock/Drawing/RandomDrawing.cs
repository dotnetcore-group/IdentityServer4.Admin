using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IdentityServer4.Admin.BuildingBlock.Drawing
{
    public class RandomDrawing
    {
        private readonly Rgba32[] Colors = new[] { Rgba32.CadetBlue };
        public Stream Generate(int width, int height)
        {
            var color = RandomDrawColor();
            var stream = new MemoryStream();
            using (var image = new Image<Rgba32>(width, height))
            {

                var aW = (int)Math.Round(width / 5d);
                var aH = (int)Math.Round(height / 5d);

                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        using (var block = RandomBlock(aW, aH, color))
                        {
                            image.Mutate(x => x.DrawImage(block, new Point(i * aW, j * aH), 1));
                        }
                    }
                }
                image.Save(stream, new JpegEncoder());
                return stream;
            }
        }

        private Rgba32 RandomDrawColor()
        {
            var length = Colors.Length;
            var r = new Random();

            var index = r.Next(0, length);
            return Colors[index];
        }

        private bool IsWhite()
        {
            var r = new Random();
            var value = r.Next(0, 5);
            return value % 2 == 0;
        }

        private Image<Rgba32> RandomBlock(int width, int height, Rgba32 color)
        {
            var image = new Image<Rgba32>(width, height);
            var isWhite = IsWhite();
            if (isWhite)
            {
                image.Mutate(x => x.Fill(Rgba32.White)
                    .DrawLines(new Pen<Rgba32>(color, .2f), new PointF(0, 0), new PointF(width, 0), new PointF(width, height), new PointF(0, height), new PointF(0, 0)));
            }
            else
            {
                image.Mutate(x => x.Fill(color));
            }

            return image;
        }
    }
}
