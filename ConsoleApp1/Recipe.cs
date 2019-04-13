using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public class Recipe
	{
		[LoadColumn(0)]
		public float bigbag_filling_duration;
		[LoadColumn(1)]
		public float bigbag_weight;
		[LoadColumn(2)]
		public float efficiency;
		[LoadColumn(3)]
		public float sifter_speed_nominal_pct;
		[LoadColumn(4)]
		public float steam_preasure;
		[LoadColumn(5)]
		public float dd_speed;
		[LoadColumn(6)]
		public float temp_out;
		[LoadColumn(7)]
		public float water_pct;
		[LoadColumn(8)]
		public float water_correction;
		[LoadColumn(9)]
		public float steam_pressure_at_the_inlet_of_regulation_unit;
		[LoadColumn(10)]
		public float product_temperature_at_the_outlet_of_JetCooker;
		[LoadColumn(11)]
		public float setpoint_of_steam_pressure_at_the_DD_inlet;
		[LoadColumn(12)]
		public float condensate_temperature_at_DD_outlet;
		[LoadColumn(13)]
		public float product_temperature_at_the_inlet;
		[LoadColumn(14)]
		public float setpoint_of_product_temperature;
		[LoadColumn(15)]
		public float product_at_the_outlet_of_JetCooker;
		[LoadColumn(16)]
		public float steam_pressure_at_the_inlet_of_JetCooker;
		[LoadColumn(17)]
		public float steam_pressure_at_the_outlet_of_regulation_unit;
		[LoadColumn(18)]
		public float product_temperature_at_the_outlet_of_product;
		[LoadColumn(19)]
		public float steam_pressure_at_DD_inlet;
		[LoadColumn(20)]
		public float fat_pct;
		[LoadColumn(21)]
		public float particles_grp1;
		[LoadColumn(22)]
		public float particles_grp2;
		[LoadColumn(23)]
		public float particles_grp3;
		[LoadColumn(24)]
		public float moisture_in;
		[LoadColumn(25)]
		public float usage_pct;
        [LoadColumn(26)]
        public float bulk_density;
    }

	public class OutputPrediction
	{
		[ColumnName("BulkDensity")]
		public float bulk_density;

		//[ColumnName("Moisture")]
		//public float moisture;
	}
}
