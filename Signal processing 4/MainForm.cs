using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_processing_4
{
    public partial class MainForm : Form
    {
        private string dataFileName;
        private double[] data;
        private DataType dataType;
        private Bitmap image;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "Выбрать файл..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectImageFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataFileName = openFileDialog.FileName;

                    image = new Bitmap(dataFileName);
                    int x, y;

                    data = new double[image.Height * image.Width];
                    // Loop through the images pixels to reset color.
                    for (x = 0; x < image.Width; x++)
                    {
                        for (y = 0; y < image.Height; y++)
                        {
                            Color pixelColor = image.GetPixel(x, y);
                            //  0.3 · r + 0.59 · g + 0.11 · b
                            data[y * image.Width + x] = (pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                        }
                    }

                    data = Utils.Normalisation(data, 0, 1);

                    dataType = DataType.Image;

                    fileNameLabel.Text = dataFileName;

                    MessageBox.Show("Данные успешно загружены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dataFileName = null;
                    data = null;
                    image = null;
                    fileNameLabel.Text = "Файл не загружен";

                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        /// <summary>
        /// Обработчик кнопки "Выбрать файл..."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dataFileName = openFileDialog.FileName;
                    //writeFile();
                    double[] fileData = getDataFromFile(dataFileName).ToArray();
                    data = new double[fileData.Count()];

                    //coef = null;

                    var button = (Button)sender;

                    switch (button.Name)
                    {
                        case "selectTestFileButton":
                            //writeFile();
                            dataType = DataType.Test;
                            data = (double[])fileData.Clone();
                            break;

                        case "selectCardioFileButton":
                            dataType = DataType.Cardio;
                            data = ConvertData.ConvertToCardio(fileData);
                            break;

                        case "selectReoFileButton":
                            dataType = DataType.Reo;
                            data = ConvertData.ConvertToReo(fileData);
                            break;

                        case "selectVeloFileButton":
                            dataType = DataType.Velo;
                            data = ConvertData.ConvertToVelo(fileData);
                            break;

                        case "selectSpiroFileButton":
                            dataType = DataType.Spiro;
                            data = ConvertData.ConvertToSpiro(fileData);
                            break;

                        default:
                            throw new ArgumentException("Необрабатываемое нажатие клавиши");
                    }

                    //обрезаем до степени 2
                    int power = (int)Math.Log(data.Count(), 2.0);
                    data = resizeData(data, (int)Math.Pow(2, power));

                    fileNameLabel.Text = dataFileName;

                    MessageBox.Show("Данные успешно загружены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    dataFileName = null;
                    data = null;
                    dataType = DataType.NotSet;
                    fileNameLabel.Text = "Файл не загружен";

                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Получить данные из файла
        /// </summary>
        /// <returns></returns>
        private List<double> getDataFromFile(string fileName)
        {
            List<double> data = new List<double>();

            if (fileName == null)
            {
                throw new ArgumentNullException("Имя файла с данными не установлено!");
            }

            using (FileStream fs = File.Open(fileName, FileMode.Open))
            using (TextReader tr = new StreamReader(fs))
            {
                while (tr.Peek() != -1)
                {
                    string line = tr.ReadLine();
                    string[] strValues = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string strValue in strValues)
                    {
                        data.Add(Double.Parse(strValue));
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Построить по данным график и показать его
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showBaseSignalButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (data == null)
                {
                    throw new NullReferenceException("Данные не были загруженны!");
                }

                if (dataType == DataType.Image)
                {
                    int dimLength = (int)Math.Sqrt(data.Length);
                    double zeroPercent;

                    Bitmap bitmap = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(data), dimLength, dimLength);
                    zeroPercent = (double)data.Where(x=> (int)(255 * x) == 0).ToArray().Length / data.Length;
                    var form = new ShowImageForm(bitmap, "Base " + zeroPercent);
                    form.Show();
                }
                else
                {
                    var form = new ShowChartForm(data, dataFileName.Split('/').Last(), dataType);
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Преобразовать сигнал
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transformSignalButton_Click(object sender, EventArgs e)
        {
            var form = new TransformSignalForm(data, dataType);
            form.ShowDialog();
        }

        /// <summary>
        /// Изменить размер изображения
        /// </summary>
        /// <param name="data"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        private double[] resizeData(double[] data, int newSize)
        {
            int oldSize = data.Count();

            double[] resizedData = new double[newSize];

            for (int i = 0; i < newSize; i++)
            {
                if (i < oldSize)
                {
                    resizedData[i] = data[i];
                }
                else
                {
                    resizedData[i] = 0;
                }
            }

            return resizedData;
        }
    }
}
