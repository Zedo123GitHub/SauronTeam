﻿using Microsoft.Data.DataView;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
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
        static readonly string _trainDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "TestData.csv");
        /// <summary>
        /// Ścieżka do danych na których program będzie testował czy dobrze się wyuczył.
        /// </summary>
       // static readonly string _testDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "data-test.csv");
        /// <summary>
        /// Ścieżka w której znajduję się model.
        /// </summary>
        static readonly string _modelPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        public static void InitiateLearn()
        {
            Console.WriteLine("===== Rozpoczęto uczenie się =====");
            MLContext mlContext = new MLContext(seed: 0);
            var model = Train(mlContext, _trainDataPath);

            //Evaluate(mlContext, model);

            TestSinglePrediction(mlContext);
            Console.WriteLine("===== Zakończono uczenie się =====");
        }

        
        public static ITransformer Train(MLContext mlContext, string dataPath)
        {

            IDataView dataView = mlContext.Data.LoadFromTextFile<TestData>(dataPath, hasHeader: false, separatorChar: ';');
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "test3")
                           .Append(mlContext.Transforms.Concatenate("test1", "test2"))
                           .Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);
            SaveModelAsFile(mlContext, model);
            return model;
        }

        private static void SaveModelAsFile(MLContext mlContext, ITransformer model)
        {
            using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
                mlContext.Model.Save(model, fileStream);

            Console.WriteLine("The model is saved to {0}", _modelPath);
        }

        private static void TestSinglePrediction(MLContext mlContext)
        {

        }

    }
}
