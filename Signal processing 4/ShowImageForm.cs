using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_processing_4
{
    public partial class ShowImageForm : Form
    {
        public ShowImageForm(Bitmap image, string windowsName = "ShowImageForm")
        {
            InitializeComponent();
            pictureBox.Image = image;
            this.Text = windowsName;
        }

        /// <summary>
        /// Преобразовать одномерный массив к Bitmap размерностью sqrt(L)*sqrt(L)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static Bitmap ArrayToBitmap(double[] data, int rows, int cols)
        {
            Bitmap bitmap = new Bitmap(rows, cols);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Color pixelColor = Color.FromArgb((int)data[y * cols + x], (int)data[y * cols + x], (int)data[y * cols + x]);
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }

            return bitmap;
        }

        /// <summary>
        /// Преобразовать одномерный массив к Bitmap размерностью sqrt(L)*sqrt(L)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static Bitmap ArrayToBitmapNormalized(double[] data, int rows, int cols)
        {
            double[] workingData = Utils.Normalisation(data, 0, 255);

            Bitmap bitmap = new Bitmap(rows, cols);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    Color pixelColor = Color.FromArgb((int)workingData[y * cols + x], (int)workingData[y * cols + x], (int)workingData[y * cols + x]);
                    bitmap.SetPixel(x, y, pixelColor);
                }
            }

            return bitmap;
        }
    }

}
