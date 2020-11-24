using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TXGen.Service
{
    public class Generator
    {
        public static Vector[,] Vectors { get; set; }
        public static Bitmap CreateRandomMap(int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            var rand = new Random();
            for(var y = 0; y < height; y++)
            {
                for(var x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
                }
            }
            return bitmap;
        }

        public static Bitmap CreateNoiseMap(int width, int height, Color colorOne, Color colorTwo, int iterations = 1, double colorOneProbability = 0.5)
        {
            var noiseMap = new Bitmap(width, height);
            var rand = new Random();
            Vectors = new Vector[width, height];


            for(var x = 0; x < width; x++)
            {
                for(var y = 0; y < height; y++)
                {
                    var color = rand.NextDouble() <= colorOneProbability ? colorOne : colorTwo;
                    noiseMap.SetPixel(x, y, color);
                    var randXVector = rand.Next(-1, 2);
                    var randYVector = rand.Next(-1, 2);
                    Vectors[x, y] = new Vector { X = randXVector, Y = randYVector };
                }
            }

            for(var i = 0; i < iterations; i++)
            {
                for (var x = 0; x < width; x++)
                {
                    for (var y = 0; y < height; y++)
                    {
                        var vectorX = x + Vectors[x, y].X;
                        var vectorY = y + Vectors[x, y].Y;

                        if (vectorX < 0 || vectorX >= width || vectorY < 0 || vectorY >= height)
                            continue;

                        var newRed = (noiseMap.GetPixel(x, y).R + noiseMap.GetPixel(vectorX, vectorY).R) / 2;
                        var newGreen = (noiseMap.GetPixel(x, y).G + noiseMap.GetPixel(vectorX, vectorY).G) / 2;
                        var newBlue = (noiseMap.GetPixel(x, y).B + noiseMap.GetPixel(vectorX, vectorY).B) / 2;

                        noiseMap.SetPixel(vectorX, vectorY, Color.FromArgb(newRed, newGreen, newBlue));
                    }
                }
            }
            
            return noiseMap;
        }

        public static Bitmap IncreaseMap(Bitmap originalMap)
        {            
            var increasedMap = new Bitmap(originalMap.Width, originalMap.Height);
            var xStart = originalMap.Width / 4 - 1;
            var yStart = originalMap.Height / 4 - 1;
            for(var x = 0; x < originalMap.Width; x++)
            {
                for(var y = 0; y < originalMap.Height; y++)
                {
                    var originalPixel = originalMap.GetPixel(xStart + x / 2, yStart + y / 2);
                    increasedMap.SetPixel(x, y, originalPixel);
                }
            }

            var random = new Random();

            for (var x = 1; x < increasedMap.Width - 1; x++)
            {
                for (var y = 1; y < increasedMap.Height - 1; y++)
                {
                    increasedMap.SetPixel(x, y, GetBlendNearColor(increasedMap, x, y, random));
                }
            }

            return increasedMap;
        }


        public static Color GetBlendNearColor(Bitmap bitmap, int x, int y, Random rand)
        {       
            // taking random pixel from nearest

            var xShift = rand.Next(-1, 2);
            var yShift = rand.Next(-1, 2);

            var colorOne = bitmap.GetPixel(x, y);
            var colorTwo = bitmap.GetPixel(x + xShift, y + yShift);

            if (colorOne.Equals(colorTwo))
                return colorOne;

            // blending color (blending water with water & ground with ground only)

            var red = default(int);
            var green = default(int);
            var blue = default(int);

            if (IsBlendable(colorOne, colorTwo))
            {
                var blendingCoef = 0.5;//rand.NextDouble();

                red = (int)(colorOne.R * blendingCoef + colorTwo.R * (1 - blendingCoef));
                green = (int)(colorOne.G * blendingCoef + colorTwo.G * (1 - blendingCoef));
                blue = (int)(colorOne.B * blendingCoef + colorTwo.B * (1 - blendingCoef));
            }
            else
            {
                var selectColor = rand.Next(0, 2);

                red = selectColor == 1 ? colorOne.R : colorTwo.R;
                green = selectColor == 1 ? colorOne.G : colorTwo.G;
                blue = selectColor == 1 ? colorOne.B : colorTwo.B;
            }


            // randomising color
            var randomShift = rand.Next(-5, 6);
            red = ColorInRange(red + randomShift);
            green = ColorInRange(green + randomShift);
            blue = ColorInRange(blue + randomShift);

            return Color.FromArgb(red, green, blue);
        }

        public static int ColorInRange(int color)
        {
            return color < 0 ? 0 : color > 255 ? 255 : color;
        }

        public static bool IsBlendable(Color colorOne, Color colorTwo)
        {
            if (colorOne.B > colorOne.G && colorTwo.B > colorTwo.G) return true;

            if (colorOne.G > colorOne.B && colorTwo.G > colorTwo.B) return true;

            if (colorOne.R > colorOne.B && colorTwo.R > colorTwo.B) return true;

            return false;
        }
    }   

    public class Vector
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
