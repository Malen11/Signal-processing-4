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
    public partial class TransformSignalForm : Form
    {
        double[] data;
        DataType dataType;

        public TransformSignalForm(double[] data, DataType dataType)
        {
            InitializeComponent();

            this.data = data;//Utils.Normalisation(data, 0, 1);
            this.dataType = dataType;

            numericUpDownItterations.Maximum = (decimal)Math.Sqrt(data.Length) / 4;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(dataType == DataType.Image)
                {
                    if (radioButtonDobeshi.Checked)
                    {
                        showImageDobeshi();
                    }
                    else
                    {
                        showImageHaar();
                    }
                }

                if(dataType == DataType.Spiro)
                {
                    if (radioButtonDobeshi.Checked)
                    {
                        //showSpiroDobeshi();
                        showSpiroHaar();
                    }
                    else
                    {
                        showSpiroHaar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showImageHaar()
        {
            int itterations = (int)numericUpDownItterations.Value;
            double threshold = (double)numericUpDownThreshold.Value;
            int dimLength = (int)Math.Sqrt(data.Length);

            double zeroPercent;

            Bitmap bitmap = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(data), dimLength, dimLength);
            zeroPercent = (double)data.Where(x => (int)(255 * x) == 0).ToArray().Length / data.Length;
            var form = new ShowImageForm(bitmap, "Base (Zero percent = " + zeroPercent + ")");
            form.Show();

            double[] directData = HaarWavelets.DirectConversionMatrix(data, dimLength, dimLength, itterations);

            double[] dataNorm = Utils.Normalisation(directData, 0, 1);
            Bitmap bitmapNorm = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(dataNorm), dimLength, dimLength);
            var formHaar = new ShowImageForm(bitmapNorm, "Haar");
            formHaar.Show();

            double[] filteredData = HaarWavelets.Filter(directData, threshold);
            zeroPercent = (double)filteredData.Where(x => (int)(255 * x) == 0).ToArray().Length / filteredData.Length;

            double[] restoredData = HaarWavelets.ReverseConversionMatrix(filteredData, dimLength, dimLength, itterations);
            Bitmap bitmapFiltered = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(restoredData), dimLength, dimLength);
            var formFiltered = new ShowImageForm(bitmapFiltered, "Restored(Zero percent = " + zeroPercent + ")");
            formFiltered.Show();
        }

        private void showImageDobeshi()
        {
            int itterations = (int)numericUpDownItterations.Value;
            double threshold = (double)numericUpDownThreshold.Value;
            int dimLength = (int)Math.Sqrt(data.Length);

            double zeroPercent;

            Bitmap bitmap = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(data), dimLength, dimLength);
            zeroPercent = (double)data.Where(x => (int)(255 * x) == 0).ToArray().Length / data.Length;
            var form = new ShowImageForm(bitmap, "Base (Zero percent = " + zeroPercent + ")");
            form.Show();

            double[] directData = HaarWavelets.DirectConversionMatrixDobeshi(data, dimLength, dimLength, itterations);

            double[] dataNorm = Utils.Normalisation(directData, 0, 1);
            Bitmap bitmapNorm = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(dataNorm), dimLength, dimLength);
            var formHaar = new ShowImageForm(bitmapNorm, "Haar");
            formHaar.Show();

            double[] filteredData = HaarWavelets.Filter(directData, threshold);
            zeroPercent = (double)filteredData.Where(x => (int)(255 * x) == 0).ToArray().Length / filteredData.Length;

            double[] restoredData = HaarWavelets.ReverseConversionMatrixDobeshi(filteredData, dimLength, dimLength, itterations);
            Bitmap bitmapFiltered = ShowImageForm.ArrayToBitmap(Utils.ImageDoubleTo8Bit(restoredData), dimLength, dimLength);
            var formFiltered = new ShowImageForm(bitmapFiltered, "Restored(Zero percent = " + zeroPercent + ")");
            formFiltered.Show();
        }

        private void showSpiroHaar()
        {
            int itterations = (int)numericUpDownItterations.Value;
            double threshold = (double)numericUpDownThreshold.Value;

            double zeroPercent;
            double[] dataNormRest, dataNorm;
            double max = data.Max(), min = data.Min();

            dataNorm = Utils.Normalisation(data, 0, 1);
            zeroPercent = (double)dataNorm.Where(x => x == 0).ToArray().Length / data.Length;
            var form = new ShowChartForm(data, "Base (Zero percent = " + zeroPercent + ")", dataType);
            form.Show();
            
            double[] directData = HaarWavelets.DirectConversionSignal(dataNorm, itterations);
            dataNormRest = Utils.Normalisation(directData, min, max);
            var formHaar = new ShowChartForm(dataNormRest, "Haar", dataType);
            formHaar.Show();

            double[] filteredData = HaarWavelets.Filter(directData, threshold);

            zeroPercent = (double)filteredData.Where(x => (int)x == 0).ToArray().Length / filteredData.Length;
            double[] restoredData = HaarWavelets.ReverseConversionSignal(filteredData, itterations);
            dataNormRest = Utils.Normalisation(restoredData, min, max);
            var formFiltered = new ShowChartForm(dataNormRest, "Restored(Zero percent = " + zeroPercent + ")", dataType);
            formFiltered.Show();
        }
    }
}
