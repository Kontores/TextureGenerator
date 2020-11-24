using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TXGen2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var weights = new int[2048 * 2048];
            //var rand = new Random();
            //for(var i = 0; i < weights.Length; i++)
            //{
            //    weights[i] = rand.Next(-14, 16);
            //}

            //var gen = new Generator() { Weights = weights };
            //var sourceMap = new Bitmap(@"D:\work\source.bmp");
            //var largeMap = gen.EnlargeMap(sourceMap);
            //largeMap.Save(@"D:\work\source_2.bmp");
            //var largeMapX2 = gen.EnlargeMap(largeMap);
            //largeMapX2.Save(@"D:\work\source_3.bmp");
            //var largeMapX3 = gen.EnlargeMap(largeMapX2);
            //largeMapX3.Save(@"D:\work\source_4.bmp");

            var gen = new Generator();
            var map = gen.DrawNoiseMap();
            map.Save(@"\Work\noisemap.bmp");
        }
    }

    public class Generator
    {
        public int[] Weights { get; set; }
        public Bitmap EnlargeMap(Bitmap sourceMap)
        {
            var largeMap = new Bitmap(sourceMap.Width * 2, sourceMap.Height * 2);
            var scale = largeMap.Width / sourceMap.Width;

            for(var x = 0; x < largeMap.Width; x++)
            {
                for (var y = 0; y < largeMap.Height; y++)
                {
                    if (y > 0 && y < largeMap.Height - 1 && x < largeMap.Width - 1 && Weights[x * y] > -5)
                    {
                        var yBias = Weights[x * y] > 0 ? 1 : -1;
                        largeMap.SetPixel(x, y, DisperseColor(sourceMap.GetPixel((x + 1) / scale, (y + yBias) / scale), Weights[x * y]));
                        continue;
                    }
                    largeMap.SetPixel(x, y, DisperseColor(sourceMap.GetPixel(x / scale, y / scale), Weights[x * y]));
                }
            }

            return largeMap;
        }

        public Color DisperseColor(Color sourceColor, int weight)
        {
            var r = sourceColor.R + weight;
            var g = sourceColor.G + weight;
            var b = sourceColor.B + weight;

            r = r < 0 ? 0 : r > 255 ? 255 : r;
            g = g < 0 ? 0 : g > 255 ? 255 : g;
            b = b < 0 ? 0 : b > 255 ? 255 : b;

            return b > g && b > r ? sourceColor : Color.FromArgb(r, g, b);
        }

        public Bitmap DrawNoiseMap()
        {
            var noiseMap = new Bitmap(1024, 1024);
            var rand = new Random();

            for (int x = 0; x < noiseMap.Width; x++)
            {
                for (int y = 0; y < noiseMap.Height; y++)
                {
                    var saturation = rand.Next(0, 256);
                    if(rand.Next(0, 4) == 1)
                        noiseMap.SetPixel(x, y, Color.FromArgb(saturation, saturation, saturation));
                }
            }

            for (int x = 1; x < noiseMap.Width - 1; x+=1)
            {
                for (int y = 1; y < noiseMap.Height - 1; y+=1)
                {
                   for(int xBias = -1; xBias < 2; xBias++)
                    {
                        for(int yBias = -1; yBias < 2; yBias++)
                        {
                            if (xBias == 0 && yBias == 0)
                                continue;
                            noiseMap.SetPixel(x + xBias, y + yBias, Color.FromArgb
                                (
                                    ((noiseMap.GetPixel(x, y).R + noiseMap.GetPixel(x + xBias, y + yBias).R) / 2),
                                    ((noiseMap.GetPixel(x, y).G + noiseMap.GetPixel(x + xBias, y + yBias).G) / 2),
                                    ((noiseMap.GetPixel(x, y).B + noiseMap.GetPixel(x + xBias, y + yBias).B) / 2)
                                ));
                        }
                    }
                }
            }

            return noiseMap;
        }

        private int Contrast(int color)
        {
            var output = 2 * (float)(128 - color) / (float)(color - 128);
            Console.WriteLine(output);

            if (output < 0)
                return 0;
            if (output > 255)
                return 255;

            return (int)output;
        }

      
    }
}
