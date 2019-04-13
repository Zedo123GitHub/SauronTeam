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
		public string line_dd;
		[LoadColumn(1)]
		public string production_order;
		[LoadColumn(2)]
		public string process_order_sap;
		[LoadColumn(3)]
		public string material_code;
		[LoadColumn(4)]
		public string recipe;
		[LoadColumn(5)]
		public string activation_date;
		[LoadColumn(6)]
		public string closing_date;
		[LoadColumn(7)]
		public string bigbag_number;
		[LoadColumn(8)]
		public string bigbag_filling_time_end;
		[LoadColumn(9)]
		public string bigbag_filling_duration;
		[LoadColumn(10)]
		public string bigbag_weight;
		[LoadColumn(11)]
		public string efficiency;
		[LoadColumn(12)]
		public string bbigbag_filling_time_end;
		[LoadColumn(13)]
		public string sifter_speed_nominal_pct;
		[LoadColumn(14)]
		public string slurry_process_order;
		[LoadColumn(15)]
		public string slurry_line;
		[LoadColumn(16)]
		public string slurry_start_time;
		[LoadColumn(17)]
		public string water_pct;
		[LoadColumn(18)]
		public string water_correction;
		[LoadColumn(19)]
		public string testing_time;
		[LoadColumn(20)]
		public string steam_preasure;
		[LoadColumn(21)]
		public string dd_speed;
		[LoadColumn(22)]
		public string temp_out;
		[LoadColumn(23)]
		public string fat_pct;
		[LoadColumn(24)]
		public string particles_grp1;
		[LoadColumn(25)]
		public string particles_grp2;
		[LoadColumn(26)]
		public string particles_grp3;
		[LoadColumn(27)]
		public string moisture_in;
		[LoadColumn(28)]
		public string material_code_2;
		[LoadColumn(29)]
		public string process_order_sap3;
		[LoadColumn(30)]
		public string usage_pct;
		[LoadColumn(31)]
		public string vendor_batch;
		[LoadColumn(32)]
		public string moisture;
		[LoadColumn(33)]
		public string bulk_density;
	}

	class OutputPrediction
	{
		[ColumnName("BulkDensity")]
		public string bulk_density;

		//[ColumnName("Moisture")]
		//public float moisture;
	}
}
