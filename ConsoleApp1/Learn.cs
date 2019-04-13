
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
		//static readonly string _testDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "DataForTest.csv");
		static readonly string _testDataPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "DataForEval.csv");
		static readonly string _modelPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Data", "Model1.zip");

		public static void InitiateLearn()
		{
			Console.WriteLine("===== Rozpoczęto uczenie się =====");

			MLContext mlContext = new MLContext(seed: 0);
			var model = Train(mlContext, _trainDataPath);

			//Evaluate(mlContext,model);
			TestSinglePrediction(mlContext);

			Console.WriteLine("===== Zakończono uczenie się =====");
			Console.ReadLine();
		}


		public static ITransformer Train(MLContext mlContext, string dataPath)
		{

			IDataView dataView = mlContext.Data.LoadFromTextFile<Recipe>(dataPath, hasHeader: false, separatorChar: ';');
			var pipeline = mlContext.Transforms
							//		public float efficiency, moisture, bulk_density;
							.CopyColumns(outputColumnName: "Label", inputColumnName: "efficiency")
						   .Append(mlContext.Transforms.Concatenate("Features", "bigbag_filling_duration", "bigbag_weight", "sifter_speed_nominal_pct", "steam_preasure", "dd_speed", "temp_out", "water_pct", "water_correction", "steam_pressure_at_the_inlet_of_regulation_unit", "product_temperature_at_the_outlet_of_JetCooker", "setpoint_of_steam_pressure_at_the_DD_inlet", "condensate_temperature_at_DD_outlet", "product_temperature_at_the_inlet", "setpoint_of_product_temperature", "product_at_the_outlet_of_JetCooker", "steam_pressure_at_the_inlet_of_JetCooker", "steam_pressure_at_the_outlet_of_regulation_unit", "product_temperature_at_the_outlet_of_product", "steam_pressure_at_DD_inlet", "fat_pct", "particles_grp1", "particles_grp2", "particles_grp3", "moisture_in", "usage_pct"))
						   .Append(mlContext.Regression.Trainers.FastTree());

			var model = pipeline.Fit(dataView);

			SaveModelAsFile(mlContext, model);
			return model;
		}

		private static void SaveModelAsFile(MLContext mlContext, ITransformer model)
		{
			using(var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
				mlContext.Model.Save(model, fileStream);

			Console.WriteLine("The model is saved to {0}", _modelPath);
		}

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<Recipe>(_trainDataPath, hasHeader: false, separatorChar: ';');
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
			Console.WriteLine($"*       R2 Score:      {metrics.RSquared:0.##}");
			Console.WriteLine($"*       RMS loss:      {metrics.Rms:#.##}");
		}

		private static void TestSinglePrediction(MLContext mlContext)
		{
			ITransformer loadedModel;
			using(var stream = new FileStream(_modelPath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				loadedModel = mlContext.Model.Load(stream);
			}

			var predictionFunction = loadedModel.CreatePredictionEngine<Recipe, OutputPrediction>(mlContext);

			var dataSample = new Recipe()
			{
				bigbag_filling_duration = 0,
				bigbag_weight = 0,
				sifter_speed_nominal_pct = 0,
				steam_preasure = 0,
				dd_speed = 0,
				temp_out = 0,
				water_pct = 0.66f,
				water_correction = -20,
				steam_pressure_at_the_inlet_of_regulation_unit = 0,
				product_temperature_at_the_outlet_of_JetCooker = 0,
				setpoint_of_steam_pressure_at_the_DD_inlet = 0,
				condensate_temperature_at_DD_outlet = 0,
				product_temperature_at_the_inlet = 0,
				setpoint_of_product_temperature = 0,
				product_at_the_outlet_of_JetCooker = 0,
				steam_pressure_at_the_inlet_of_JetCooker = 0,
				steam_pressure_at_the_outlet_of_regulation_unit = 0,
				product_temperature_at_the_outlet_of_product = 0,
				steam_pressure_at_DD_inlet = 0,

				fat_pct = 0,
				particles_grp1 = 0.591f,
				particles_grp2 = 0.409f,
				particles_grp3 = 0,
				moisture_in = 12.4f,
				usage_pct = 0.119f,

				efficiency = 0,		//	100
				moisture = 0,		//	4,81
				bulk_density = 0	//	250
			};

			var prediction = predictionFunction.Predict(dataSample);

			Console.WriteLine($"**********************************************************************");
			Console.WriteLine($"Predicted : {prediction.Score:0.####}");
			Console.WriteLine($"**********************************************************************");


		}

	}
}
