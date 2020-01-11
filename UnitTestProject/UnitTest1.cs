using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Signal_processing_4;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void DirectConversionTestMethod1()
        {
            double coef = 1 / Math.Sqrt(2);
            double[] data = {16, 14, 12, 10, 8, 6, 4, 2 };
            double[] result = { 15, 1, 11, 1, 7, 1, 3, 1};
            
            var convertedData = HaarWavelets.DirectConversion(data);
            var convNormData = convertedData.Select(x => coef * x).ToArray();

            for(int i =0; i< result.Length; i++)
            {
                if (Math.Abs(result[i] - convNormData[i]) > 0.00001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ReverseConversionTestMethod1()
        {
            double coef = 1 / Math.Sqrt(2);
            double[] data = { 16, 14, 12, 10, 8, 6, 4, 2 };

            var convertedData = HaarWavelets.DirectConversion(data);
            var revConvData = HaarWavelets.ReverseConversion(convertedData);

            for (int i = 0; i < data.Length; i++)
            {
                if (Math.Abs(data[i] - revConvData[i]) > 0.00001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ReorderArrayTestMethod1()
        {
            double coef = 1 / Math.Sqrt(2);
            double[] data = { 16, 14, 12, 10, 8, 6, 4, 2 };
            double[] result = { 15, 11, 7, 3, 1, 1, 1, 1 };

            var convertedData = HaarWavelets.DirectConversion(data);
            var convNormData = convertedData.Select(x => coef * x).ToArray();
            var convNormReorderData = HaarWavelets.ReorderArray(convNormData);

            for (int i = 0; i < result.Length; i++)
            {
                if (Math.Abs(result[i] - convNormReorderData[i]) > 0.00001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ReorderMatrixTestMethod1()
        {
            double X = 0, x = 1, Y = 2, y = 3;
            double[] data = {
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, 4, 5, X, x,
                Y, y, Y, y, 6, 7, Y, y
            };

            double[] result = {
                X, X, X, X, x, x, x, x,
                X, X, X, X, x, x, x, x,
                X, X, X, X, x, x, x, x,
                X, X, 4, X, x, x, 5, x,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, 6, Y, y, y, 7, y
            };

            var reorderData = HaarWavelets.ReorderMatrix(data, (int)Math.Round(Math.Sqrt(data.Length)), (int)Math.Round(Math.Sqrt(data.Length)));

            for (int i = 0; i < result.Length; i++)
            {
                if (Math.Abs(result[i] - reorderData[i]) > 0.00001)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ReorderMatrixReverseTestMethod1()
        {
            double X = 0, x = 1, Y = 2, y = 3;
            double[] data ={
                X, X, X, X, x, x, x, x,
                X, X, X, X, x, x, x, x,
                X, X, X, X, x, x, x, x,
                X, X, 4, X, x, x, 5, x,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, Y, Y, y, y, y, y,
                Y, Y, 6, Y, y, y, 7, y
            };

            double[] result =  {
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, X, x, X, x,
                Y, y, Y, y, Y, y, Y, y,
                X, x, X, x, 4, 5, X, x,
                Y, y, Y, y, 6, 7, Y, y
            };
            

            var reorderData = HaarWavelets.ReorderMatrixReverse(data, (int)Math.Round(Math.Sqrt(data.Length)), (int)Math.Round(Math.Sqrt(data.Length)));

            for (int i = 0; i < result.Length; i++)
            {
                if (Math.Abs(result[i] - reorderData[i]) > 0.00001)
                {
                    Assert.Fail();
                }
            }
        }
    }
}
