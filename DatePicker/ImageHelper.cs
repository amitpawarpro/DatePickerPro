using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace DatePickerPro
{
    public class ImageHelper
    {
        private static void Render(Graphics g, float w, float h, List<Holiday> holidays)
        {
            var border = 2;

            using (var brush = new SolidBrush(Color.Gray))
            {
                switch (holidays.Count)
                {
                    case 1:
                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w, h);
                        break;
                    case 2:

                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 2, h);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 2, 0, w, h);

                        break;
                    case 3:

                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 2, h / 2);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 2, 0, w, h / 2);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 2, w, h / 2);
                        break;
                    case 4:
                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 2, h / 2);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 2, 0, w, h / 2);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 2, w, h / 2);

                        brush.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(brush, w / 2, h / 2, w, h / 2);
                        break;
                    case 5:
                        // x x x
                        //  x x   
                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 3, h / 2);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 3, 0, w / 3, h / 2);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, 0, w / 3, h / 2);

                        brush.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 2, w / 2, h / 2);

                        brush.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(brush, w / 2, h / 2, w / 2, h / 2);
                        break;
                    case 6:
                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 3, h / 2);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 3, 0, w / 3, h / 2);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, 0, w / 3, h / 2);

                        brush.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 2, w / 3, h / 2);

                        brush.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(brush, w / 3, h / 2, w / 3 * 2, h / 2);

                        brush.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, h / 2, w, h / 2);
                        break;
                    case 7:
                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 3, h / 3);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 3, 0, w / 3, h / 3);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, 0, w / 3, h / 3);



                        brush.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 3, w / 2, h / 3 * 2);

                        brush.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(brush, w / 2, h / 3, w, h / 3 * 2);

                        brush.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 3 * 2, w / 2, h);

                        brush.Color = holidays[6].Calendar.Color;
                        g.FillRectangle(brush, w / 2, h / 3 * 2, w / 2, h);

                        break;
                    case 8:

                        brush.Color = holidays[0].Calendar.Color;
                        g.FillRectangle(brush, 0, 0, w / 3, h / 3);

                        brush.Color = holidays[1].Calendar.Color;
                        g.FillRectangle(brush, w / 3, 0, w / 3, h / 3);

                        brush.Color = holidays[2].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, 0, w / 3, h / 3);



                        brush.Color = holidays[3].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 3, w / 2, h / 3 * 2);

                        brush.Color = holidays[4].Calendar.Color;
                        g.FillRectangle(brush, w / 2, h / 3, w, h / 3 * 2);


                        brush.Color = holidays[5].Calendar.Color;
                        g.FillRectangle(brush, 0, h / 3 * 2, w / 3, h);

                        brush.Color = holidays[6].Calendar.Color;
                        g.FillRectangle(brush, w / 3, h / 3 * 2, w / 3 * 2, h);

                        brush.Color = holidays[7].Calendar.Color;
                        g.FillRectangle(brush, w / 3 * 2, h / 3 * 2, w, h);
                        break;
                    default:
                        break;
                }

                brush.Color = SystemColors.ButtonFace;
                g.FillRectangle(brush, border, border, w - 1 - border * 2, h - 1 - border * 2);
            }
        }
        public static Bitmap GenerateBitmap(int wt, int ht, List<Holiday> holidays)
        {
            Bitmap bmp = new Bitmap(wt, ht, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            Render(g, wt, ht, holidays);
            return bmp;
        }
    }
}
