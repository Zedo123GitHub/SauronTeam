using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Recipe
    {
        [LoadColumn(0)]
        public string Test1;

        [LoadColumn(1)]
        public string Test2;

        [LoadColumn(2)]
        public float Test3;

        [LoadColumn(3)]
        public float Test4;

        [LoadColumn(4)]
        public float Test5;

        [LoadColumn(5)]
        public string BulkDensity;

        [LoadColumn(6)]
        public float Moisture;
    }

    class OutputPrediction
    {
        [ColumnName("BulkDensity")]
        public string BulkDensity;

        [ColumnName("Moisture")]
        public float Moisture;
    }
}
