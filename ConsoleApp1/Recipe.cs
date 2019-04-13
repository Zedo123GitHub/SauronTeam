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
		[LoadColumn(xxx)]
		public string line_dd;
		[LoadColumn(xxx)]
		public string production_order;
		[LoadColumn(xxx)]
		public string process_order_sap;
		[LoadColumn(xxx)]
		public string material_code;
		[LoadColumn(xxx)]
		public string recipe;
		[LoadColumn(xxx)]
		public string activation_date;
		[LoadColumn(xxx)]
		public string closing_date;
		[LoadColumn(xxx)]
		public string bigbag_number;
		[LoadColumn(xxx)]
		public string bigbag_filling_time_end;
		[LoadColumn(xxx)]
		public string bigbag_filling_duration;
		[LoadColumn(xxx)]
		public string bigbag_weight;
		[LoadColumn(xxx)]
		public string efficiency;
		[LoadColumn(xxx)]
		public string bbigbag_filling_time_end;
		[LoadColumn(xxx)]
		public string sifter_speed_nominal_pct;
		[LoadColumn(xxx)]
		public string slurry_process_order;
		[LoadColumn(xxx)]
		public string slurry_line;
		[LoadColumn(xxx)]
		public string slurry_start_time;
		[LoadColumn(xxx)]
		public string water_pct;
		[LoadColumn(xxx)]
		public string water_correction;
		[LoadColumn(xxx)]
		public string testing_time;
		[LoadColumn(xxx)]
		public string steam_preasure;
		[LoadColumn(xxx)]
		public string dd_speed;
		[LoadColumn(xxx)]
		public string temp_out;
		[LoadColumn(xxx)]
		public string fat_pct;
		[LoadColumn(xxx)]
		public string particles_grp1;
		[LoadColumn(xxx)]
		public string particles_grp2;
		[LoadColumn(xxx)]
		public string particles_grp3;
		[LoadColumn(xxx)]
		public string moisture_in;
		[LoadColumn(xxx)]
		public string material_code_2;
		[LoadColumn(xxx)]
		public string process_order_sap3;
		[LoadColumn(xxx)]
		public string usage_pct;
		[LoadColumn(xxx)]
		public string vendor_batch;
		[LoadColumn(xxx)]
		public string moisture;
		[LoadColumn(xxx)]
		public string bulk_density;
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
