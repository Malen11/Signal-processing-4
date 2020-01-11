using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_processing_4
{
    public class HaarWavelets
    {
        public static double[] DirectConversionMatrix(double[] dataMatrix, int rows, int cols, int itterations)
        {
            double[] haarData, transposeData, reorderData = null, result = null, tempDataPart, tempDataFull;
            int rowsPart, colsPart;

            rowsPart = rows;
            colsPart = cols;
            tempDataFull = new double[rows * cols];
            tempDataPart = dataMatrix;

            for(int i = 0; i < itterations; i++)
            {
                //считаем вейвлеты по строкам, потом по столбцам
                haarData = DirectConversion(tempDataPart);
                transposeData = Utils.TransposeMatrix(haarData, rowsPart, colsPart);
                haarData = DirectConversion(transposeData);
                result = Utils.TransposeMatrix(haarData, rowsPart, colsPart);

                //переупорядочиваем значения
                reorderData = ReorderMatrix(result, rowsPart, colsPart);

                tempDataFull = Utils.InsertSubMatrix(tempDataFull, rows, cols, reorderData, rowsPart, colsPart, 0, 0);
                
                rowsPart /= 2;
                colsPart /= 2;
                tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);
            }

            return Utils.InsertSubMatrix(tempDataFull, rows, cols, reorderData, 0, 0, rowsPart, colsPart);
        }

        public static double[] ReverseConversionMatrix(double[] dataMatrix, int rows, int cols, int itterations)
        {
            double[] haarData, transposeData, tempDataPart, tempDataFull;
            int rowsPart = rows, colsPart = cols;

            for (int i = 0; i < itterations - 1; i++)
            {
                rowsPart /= 2;
                colsPart /= 2;
            }

            tempDataFull = new double[rows * cols];
            dataMatrix.CopyTo(tempDataFull, 0);
            //tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);

            for (int i = 0; i < itterations; i++)
            {
                tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);
                tempDataPart = ReorderMatrixReverse(tempDataPart, rowsPart, colsPart);

                transposeData = Utils.TransposeMatrix(tempDataPart, rowsPart, colsPart);
                haarData = ReverseConversion(transposeData);
                transposeData = Utils.TransposeMatrix(haarData, rowsPart, colsPart);
                haarData = ReverseConversion(transposeData);

                tempDataFull = Utils.InsertSubMatrix(tempDataFull, rows, cols, haarData, rowsPart, colsPart, 0, 0);
                rowsPart *= 2;
                colsPart *= 2;

                //Bitmap bitmapNorm = ShowImageForm.ArrayToBitmapNormalized(tempDataFull, rows, cols);
                //var formHaar = new ShowImageForm(bitmapNorm, "Haar restored " + (itterations - i).ToString());
                //formHaar.Show();
            }

            return tempDataFull;
        }

        public static double[] DirectConversionSignal(double[] data, int itterations)
        {
            double[] haarData, reorderData = null;

            int length = data.Length;

            double[] tempDataPart = new double[length];
            double[] tempDataFull = new double[length];
            data.CopyTo(tempDataPart, 0);
            data.CopyTo(tempDataFull, 0);


            for (int i = 0; i < itterations; i++)
            {
                //считаем вейвлеты по строкам
                haarData = DirectConversion(tempDataPart);

                //переупорядочиваем значения
                reorderData = ReorderArray(haarData);
                Array.Copy(reorderData, tempDataFull, reorderData.Length);
                length /= 2;
                tempDataPart = new double[length];
                Array.Copy(tempDataFull, tempDataPart, length);
            }

            return tempDataFull;
        }

        public static double[] ReverseConversionSignal(double[] data, int itterations)
        {
            double[] haarData, reorderData = null;

            int length = (int)(data.Length / Math.Pow(2, itterations - 1));

            double[] tempDataPart = new double[length];
            double[] tempDataFull = new double[data.Length];
            data.CopyTo(tempDataFull, 0);

            Array.Copy(tempDataFull, tempDataPart, length);

            for (int i = 0; i < itterations; i++)
            {
                //переупорядочиваем значения
                reorderData = ReorderArrayReverse(tempDataPart);

                //считаем вейвлеты по строкам
                haarData = ReverseConversion(reorderData);
                
                Array.Copy(haarData, tempDataFull, reorderData.Length);
                length *= 2;
                if(i < itterations - 1)
                {
                    tempDataPart = new double[length];
                    Array.Copy(tempDataFull, tempDataPart, length);
                }
            }

            return tempDataFull;
        }

        public static double[] DirectConversionMatrixDobeshi(double[] dataMatrix, int rows, int cols, int itterations)
        {
            double[] haarData, transposeData, reorderData = null, result = null, tempDataPart, tempDataFull;
            int rowsPart, colsPart;

            rowsPart = rows;
            colsPart = cols;
            tempDataFull = new double[rows * cols];
            tempDataPart = dataMatrix;

            for (int i = 0; i < itterations; i++)
            {
                //считаем вейвлеты по строкам, потом по столбцам
                haarData = DirectConversionDobeshi(tempDataPart);
                transposeData = Utils.TransposeMatrix(haarData, rowsPart, colsPart);
                haarData = DirectConversionDobeshi(transposeData);
                result = Utils.TransposeMatrix(haarData, rowsPart, colsPart);

                //переупорядочиваем значения
                reorderData = ReorderMatrix(result, rowsPart, colsPart);

                tempDataFull = Utils.InsertSubMatrix(tempDataFull, rows, cols, reorderData, rowsPart, colsPart, 0, 0);

                rowsPart /= 2;
                colsPart /= 2;
                tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);
            }

            return Utils.InsertSubMatrix(tempDataFull, rows, cols, reorderData, 0, 0, rowsPart, colsPart);
        }

        public static double[] ReverseConversionMatrixDobeshi(double[] dataMatrix, int rows, int cols, int itterations)
        {
            double[] haarData, transposeData, tempDataPart, tempDataFull;
            int rowsPart = rows, colsPart = cols;

            for (int i = 0; i < itterations - 1; i++)
            {
                rowsPart /= 2;
                colsPart /= 2;
            }

            tempDataFull = new double[rows * cols];
            dataMatrix.CopyTo(tempDataFull, 0);
            //tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);

            for (int i = 0; i < itterations; i++)
            {
                tempDataPart = Utils.GetSubMatrix(tempDataFull, rows, cols, 0, rowsPart, 0, colsPart);
                tempDataPart = ReorderMatrixReverse(tempDataPart, rowsPart, colsPart);

                transposeData = Utils.TransposeMatrix(tempDataPart, rowsPart, colsPart);
                haarData = ReverseConversionDobeshi(transposeData);
                transposeData = Utils.TransposeMatrix(haarData, rowsPart, colsPart);
                haarData = ReverseConversionDobeshi(transposeData);

                tempDataFull = Utils.InsertSubMatrix(tempDataFull, rows, cols, haarData, rowsPart, colsPart, 0, 0);
                rowsPart *= 2;
                colsPart *= 2;

                //Bitmap bitmapNorm = ShowImageForm.ArrayToBitmapNormalized(tempDataFull, rows, cols);
                //var formHaar = new ShowImageForm(bitmapNorm, "Haar restored " + (itterations - i).ToString());
                //formHaar.Show();
            }

            return tempDataFull;
        }

        public static double[] DirectConversion(double[] data)
        {
            double[] result = new double[data.Length];
            double coef = 1.0 / Math.Sqrt(2.0);

            double[] CL = { coef, coef };
            double[] CH = { coef, -coef };

            double SL, SH;
            for (int k = 0; k < data.Length; k += 2)
            {
                SL = 0;
                SH = 0;
                for (int i = 0; i < CL.Length; i++)
                {
                    SL = SL + data[k + i] * CL[i];
                    SH = SH + data[k + i] * CH[i];
                }

                result[k] = SL;
                result[k + 1] = SH;
            }

            return result;
        }

        public static double[] DirectConversionDobeshi (double[] data)
        {
            double[] result = new double[data.Length];
            double c0 = (1 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c1 = (3 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c2 = (3 - Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c3 = (1 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));

            double[] CL = { c0, c1, c2, c3 };
            double[] CH = { c3, -c2, c1, -c0 };

            double SL, SH;
            for (int k = 0; k < data.Length; k += 2)
            {
                SL = 0;
                SH = 0;
                for (int i = 0; i < CL.Length; i++)
                {
                    SL = SL + data[(k + i) % data.Length] * CL[i];
                    SH = SH + data[(k + i) % data.Length] * CH[i];
                }

                result[k] = SL;
                result[k + 1] = SH;
            }

            return result;
        }

        public static double[] ReverseConversion(double[] data)
        {
            double[] result = new double[data.Length];
            double coef = 1.0 / Math.Sqrt(2.0);

            double[] CL = { coef, coef };
            double[] CH = { coef, -coef };

            double SL, SH;
            for (int k = 0; k < data.Length; k += 2)
            {
                SL = 0;
                SH = 0;
                for (int i = 0; i < CL.Length; i++)
                {
                    SL = SL + data[k + i] * CL[i];
                    SH = SH + data[k + i] * CH[i];
                }

                result[k] = SL;
                result[k + 1] = SH;
            }

            return result;
        }

        public static double[] ReverseConversionDobeshi(double[] data)
        {
            double[] result = new double[data.Length];
            double c0 = (1 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c1 = (3 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c2 = (3 - Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                c3 = (1 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));

            double[] CL = { c2, c1, c0, c3 };
            double[] CH = { c3, -c0, c1, -c2 };

            double SL, SH;
            for (int k = 0; k < data.Length; k += 2)
            {
                SL = 0;
                SH = 0;
                for (int i = 0; i < CL.Length; i++)
                {
                    SL = SL + data[(data.Length + k + i - 2) % data.Length] * CL[i];
                    SH = SH + data[(data.Length + k + i - 2) % data.Length] * CH[i];
                }

                result[k] = SL;
                result[k + 1] = SH;
            }

            return result;
        }

        public static double[] ReorderArray(double[] data)
        {
            double[] result = new double[data.Length];

            for (int i = 0; i < data.Length / 2; i++)
            {
                result[i] = data[2 * i];
            }

            for (int i = 0; i < data.Length / 2; i++)
            {
                result[data.Length / 2 + i] = data[2 * i + 1];
            }

            return result;
        }

        public static double[] ReorderArrayReverse(double[] data)
        {
            double[] result = new double[data.Length];

            for (int i = 0; i < data.Length / 2; i++)
            {
                result[2 * i] = data[i];
            }

            for (int i = 0; i < data.Length / 2; i++)
            {
                result[2 * i + 1] = data[data.Length / 2 + i];
            }

            return result;
        }

        /// <summary>
        /// Переставляем значения
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static double[] ReorderMatrix(double[] data, int rows, int cols)
        {
            double[] result = new double[data.Length];

            //верх-лево
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[i * cols + j] = data[2 * i * cols + 2 * j];
                }
            }

            //верх-право
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[i * cols + cols / 2 + j] = data[2 * i * cols + (2 * j + 1)];
                }
            }

            //низ-лево
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[(i + rows / 2) * cols + j] = data[(2 * i + 1) * cols + 2 * j];
                }
            }

            //верх-право
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[(i + rows / 2) * cols + cols / 2 + j] = data[(2 * i + 1) * cols + (2 * j + 1)];
                }
            }

            return result;
        }

        /// <summary>
        /// Переставляем значения
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static double[] ReorderMatrixReverse(double[] data, int rows, int cols)
        {
            double[] result = new double[data.Length];

            //верх-лево
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[2 * i * cols + 2 * j] = data[i * cols + j];
                }
            }

            //верх-право
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[2 * i * cols + (2 * j + 1)] = data[i * cols + cols / 2 + j];
                }
            }

            //низ-лево
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[(2 * i + 1) * cols + 2 * j] = data[(i + rows / 2) * cols + j];
                }
            }

            //верх-право
            for (int i = 0; i < rows / 2; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    result[(2 * i + 1) * cols + (2 * j + 1)] = data[(i + rows / 2) * cols + cols / 2 + j];
                }
            }

            return result;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static double[] Filter(double[] baseData, double threshold)
        {
            int length = baseData.Length;
            double[] result = new double[baseData.Length];

            for (int i = 0; i < length; i++)
            {
                if (Math.Abs(baseData[i]) > threshold)
                {
                    result[i] = baseData[i];
                }
            }

            return result;
        }
    }
}
