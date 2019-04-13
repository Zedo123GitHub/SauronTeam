
using Microsoft.Data.DataView;
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

        static readonly string _trainDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "DataForLearn.csv");
       // static readonly string _testDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "data-test.csv");
        static readonly string _modelPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        public static void InitiateLearn()
        {
            Console.WriteLine("===== Rozpoczęto uczenie się =====");

            MLContext mlContext = new MLContext(seed: 0);
            var model = Train(mlContext, _trainDataPath);

            TestSinglePrediction(mlContext);

            Console.WriteLine("===== Zakończono uczenie się =====");
            Console.ReadLine();
        }

        
        public static ITransformer Train(MLContext mlContext, string dataPath)
        {

            IDataView dataView = mlContext.Data.LoadFromTextFile<Recipe>(dataPath, hasHeader: false, separatorChar: ';');
            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "bulk_density")
                           .Append(mlContext.Transforms.Concatenate("Features", "bigbag_filling_duration", "bigbag_weight", "efficiency", "sifter_speed_nominal_pct", "steam_preasure", "dd_speed", "temp_out", "moisture", "water_pct", "water_correction", "steam_pressure_at_the_inlet_of_regulation_unit", "product_temperature_at_the_outlet_of_JetCooker", "setpoint_of_steam_pressure_at_the_DD_inlet", "condensate_temperature_at_DD_outlet", "product_temperature_at_the_inlet", "setpoint_of_product_temperature", "product_at_the_outlet_of_JetCooker", "steam_pressure_at_the_inlet_of_JetCooker", "steam_pressure_at_the_outlet_of_regulation_unit", "product_temperature_at_the_outlet_of_product", "steam_pressure_at_DD_inlet", "fat_pct", "particles_grp1", "particles_grp2", "particles_grp3", "moisture_in", "usage_pct"))
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

        /*
        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<TestData>(_trainDataPath, hasHeader: false, separatorChar: ';');
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
        }
        */

        private static void TestSinglePrediction(MLContext mlContext)
        {
            ITransformer loadedModel;
            using (var stream = new FileStream(_modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                loadedModel = mlContext.Model.Load(stream);
            }

            var predictionFunction = loadedModel.CreatePredictionEngine<Recipe, OutputPrediction>(mlContext);

            var dataSample = new Recipe()
            {
                bigbag_filling_duration = 25,
                bigbag_weight = 255,
                efficiency = 102,
                sifter_speed_nominal_pct = 1,
                steam_preasure = 6.6f,
                dd_speed = 10,
                temp_out = 121,
                moisture = 4.75f,
                bulk_density = 0,
                water_pct = 0.66f,
                water_correction = -40,
                steam_pressure_at_the_inlet_of_regulation_unit = 6.571f,
                product_temperature_at_the_outlet_of_JetCooker = 119.376f,
                setpoint_of_steam_pressure_at_the_DD_inlet = 6.599f,
                condensate_temperature_at_DD_outlet = 159.746f,
                product_temperature_at_the_inlet = 177.767f,
                setpoint_of_product_temperature = 128,
                product_at_the_outlet_of_JetCooker = 0,
                steam_pressure_at_the_inlet_of_JetCooker = 0,
                steam_pressure_at_the_outlet_of_regulation_unit = 90.224f,
                product_temperature_at_the_outlet_of_product = 100,
                steam_pressure_at_DD_inlet = 6.578f,
                fat_pct = 0,
                particles_grp1 = 0.85f,
                particles_grp2 = 0.15f,
                particles_grp3 = 0,
                moisture_in = 1.5f,
                usage_pct = 0.98f

            };

            var prediction = predictionFunction.Predict(dataSample);

            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Predicted : {prediction.bulk_density:0.####}");
            Console.WriteLine($"**********************************************************************");


        }

    }
}
