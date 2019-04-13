using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Learn
    {
        /// <summary>
        /// Ścieżka do danych na których program będzie trenował.
        /// </summary>
        static readonly string _trainDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "data-train.csv");
        /// <summary>
        /// Ścieżka do danych na których program będzie testował czy dobrze się wyuczył.
        /// </summary>
        static readonly string _testDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "data-test.csv");
        /// <summary>
        /// Ścieżka w której znajduję się model.
        /// </summary>
        static readonly string _modelPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        public static void InitiateLearn()
        {
            Console.WriteLine("===== Rozpoczęto uczenie się =====");
            MLContext mlContext = new MLContext(seed: 0);
            // var model = Train(mlContext, _trainDataPath);

            //  Evaluate(mlContext, model);

            //  TestSinglePrediction(mlContext);
            Console.WriteLine("===== Zakończono uczenie się =====");
        }

        /*
        public static ITransformer Train(MLContext mlContext, string dataPath)
        {
          
           // var model = pipeline.Fit(dataView);
           // SaveModelAsFile(mlContext, model);
           // return model;
        }
        */
    }
}
