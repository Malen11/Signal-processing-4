using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal_processing_4
{
    public static class Utils
    {
        /// <summary>
        /// Нормализует массив значений
        /// </summary>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static double[] Normalisation(double[] data, double start, double end)
        {
            double min = data.Min();
            double max = data.Max();

            double k = (end - start) / (max - min);

            return data.Select(x => start + (x - min) * k).ToArray();
        }

        /// <summary>
        /// Преобразовать изображение в диапазоне [0; 255] к диапазону [0; 1]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[] Image8BitToDouble(double[] data)
        {
            if(data.Min() < 0 && data.Max() > 255)
            {
                data = Normalisation(data, 0, 255);
            }

            return data.Select(x=> x/255.0).ToArray();
        }

        /// <summary>
        /// Преобразовать изображение в диапазоне [0; 1] к диапазону [0; 255]
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[] ImageDoubleTo8Bit(double[] data)
        {
            if (data.Min() < 0 && data.Max() > 1)
            {
                data = Normalisation(data, 0, 1);
            }

            return data.Select(x => x * 255.0).ToArray();
        }

        /// <summary>
        /// Транспонирует матрицу (представленную одномерным массивом)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static double[] TransposeMatrix(double[] data, int rows, int cols)
        {
            int length = data.Length;
            double[] result = new double[length];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j * rows + i] = data[i * cols + j];
                }
            }

            return result;
        }

        /// <summary>
        /// Возвращает подматрицу матрицы
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <param name="rowStart"></param>
        /// <param name="rowEnd"></param>
        /// <param name="colStart"></param>
        /// <param name="colEnd"></param>
        /// <returns></returns>
        public static double[] GetSubMatrix(double[] data, int rows, int cols, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowEnd > rows || rowStart < 0 || colEnd > cols || colStart < 0 || rowEnd < rowStart || colEnd < colStart)
            {
                throw new ArgumentException("Wrong input values");
            }

            int RowsN = rowEnd - rowStart;
            int colsN = colEnd - colStart;

            double[] result = new double[RowsN * colsN];

            //верх-лево
            for (int i = rowStart; i < rowEnd; i++)
            {
                for (int j = colStart; j < colEnd; j++)
                {
                    result[i * colsN + j] = data[i * cols + j];
                }
            }

            return result;
        }

        /// <summary>
        /// Вставляет матрицу
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static double[] InsertSubMatrix(double[] baseData, int rowsBase, int colsBase, double[] insertData, int rowsInsert, int colsInsert, int rowPos, int colPos)
        {
            if (rowsInsert > rowsBase || colsInsert > colsBase)
            {
                throw new ArgumentException("Wrong input values");
            }

            double[] result = new double[baseData.Length];
            baseData.CopyTo(result, 0);
            
            for (int i = rowPos; i < rowsInsert + rowPos; i++)
            {
                for (int j = colPos; j < colsInsert + colPos; j++)
                {
                    baseData[i * colsBase + j] = insertData[i * colsInsert + j];
                }
            }

            return baseData;
        }
    }
}
