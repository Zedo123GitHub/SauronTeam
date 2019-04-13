using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TestData
    {
        [LoadColumn(0)]
        public float test1;

        [LoadColumn(1)]
        public float test2;

        [LoadColumn(2)]
        public float test3;
    }

    class DataPrediction
    {
        [ColumnName("Label")]
        public float test3;
    }
}
