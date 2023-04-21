using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace лр1.Models
{
    //нужен класс для сохранения картинок
    public class ImageInfo
    {
        //собственно, сама картинка
        public Bitmap bitmap { get; set; }
        //какое наложение
        public string overlay { get; set; }
        //и прозрачность через число (на него просто умножается)
        public int transparency { get; set; }

        //конструкторы
        public ImageInfo()
        {
            this.bitmap = null;
            this.overlay = "Нет";
            this.transparency = 255;
        }
        public ImageInfo(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            this.overlay = "Нет";
            this.transparency = 255;
        }


        //группа функций изменение эффектов слоя
        //да, так делать неправильно
        #region
        static Color Sum(int x, int y, Bitmap img1, Bitmap img2)
        {
            byte red = (byte)(img1.GetPixel(x, y).R + img2.GetPixel(x, y).R);
            byte green = (byte)(img1.GetPixel(x, y).G + img2.GetPixel(x, y).G);
            byte blue = (byte)(img1.GetPixel(x, y).B + img2.GetPixel(x, y).B);
            return Color.FromArgb(red, green, blue);
        }
        static Color AverageSum(int x, int y, Bitmap img1, Bitmap img2)
        {
            byte red = (byte)((img1.GetPixel(x, y).R + img2.GetPixel(x, y).R) / 2);
            byte green = (byte)((img1.GetPixel(x, y).G + img2.GetPixel(x, y).G) / 2);
            byte blue = (byte)((img1.GetPixel(x, y).B + img2.GetPixel(x, y).B) / 2);
            return Color.FromArgb(red, green, blue);
        }
        static Color MaxPix(int x, int y, Bitmap img1, Bitmap img2)
        {
            byte red = Math.Max(img1.GetPixel(x, y).R, img2.GetPixel(x, y).R);
            byte green = Math.Max(img1.GetPixel(x, y).G, img2.GetPixel(x, y).G);
            byte blue = Math.Max(img1.GetPixel(x, y).B, img2.GetPixel(x, y).B);
            return Color.FromArgb(red, green, blue);
        }
        static Color MinPix(int x, int y, Bitmap img1, Bitmap img2)
        {
            byte red = Math.Min(img1.GetPixel(x, y).R, img2.GetPixel(x, y).R);
            byte green = Math.Min(img1.GetPixel(x, y).G, img2.GetPixel(x, y).G);
            byte blue = Math.Min(img1.GetPixel(x, y).B, img2.GetPixel(x, y).B);
            return Color.FromArgb(red, green, blue);
        }
        static Color Transparentcy(int x, int y, Bitmap img1, Bitmap img2, int trn)
        {
            float transp = (float)trn / 255;
            byte red = (byte)(img1.GetPixel(x, y).R* transp + img2.GetPixel(x, y).R*(1-transp));
            byte green = (byte)(img1.GetPixel(x, y).G* transp + img2.GetPixel(x, y).G * (1 - transp));
            byte blue = (byte)(img1.GetPixel(x, y).B * transp + img2.GetPixel(x, y).B * (1 - transp));
            return Color.FromArgb(red, green, blue);
        }
        static Color MultiPix(int x, int y, Bitmap img1, Bitmap img2)
        {
            byte red = (byte)((img1.GetPixel(x, y).R * img2.GetPixel(x, y).R) /255);
            byte green = (byte)((img1.GetPixel(x, y).G * img2.GetPixel(x, y).G) / 255);
            byte blue = (byte)((img1.GetPixel(x, y).B * img2.GetPixel(x, y).B) / 255);
            return Color.FromArgb(red, green, blue);
        }
        #endregion
        //добавление маски

        internal Bitmap EffectAdder(ImageInfo addBitmap)
        {
            //для итоговой картинки/вывода
            Bitmap addToImage = this.bitmap;
            //для промежуточного расчета слоя
            Bitmap image = (Bitmap)addBitmap.bitmap.Clone();

            //расчет высоты и ширины, на которые нужно поместить (чтобы поместить его на центр)
            int height = (addToImage.Height - image.Height) / 2;
            int width = (addToImage.Width - image.Width) / 2;

            for (var x = 0; x < image.Width; x++)
                for (var y = 0; y < image.Height; y++)
                {
                    //добавление эффекта на промежуточный слой
                    switch (addBitmap.overlay)
                    {
                        case "Сумма":
                            image.SetPixel(x, y, Sum(x, y, image, addToImage));
                            break;
                        case "Умножение":
                            image.SetPixel(x, y, MultiPix(x, y, image, addToImage));
                            break;
                        case "Макс":
                            image.SetPixel(x, y, MaxPix(x, y, image, addToImage));
                            break;
                        case "Мин":
                            image.SetPixel(x, y, MinPix(x, y, image, addToImage));
                            break;
                        case "Среднее":
                            image.SetPixel(x, y, AverageSum(x, y, image, addToImage));
                            break;
                    }
                    //добавление прозрачности
                    image.SetPixel(x, y, Transparentcy(x, y, image, addToImage, addBitmap.transparency));
                    //добавление на готовый слой
                    addToImage.SetPixel(x, y, Color.FromArgb(image.GetPixel(x, y).R, image.GetPixel(x, y).G, image.GetPixel(x, y).B));

                }                        
            //возвращение измененной картинки
            return addToImage;
        }
    }
}
