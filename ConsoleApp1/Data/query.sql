--select 
--osfp.bigbag_filling_duration,osfp.bigbag_weight,bb.sifter_speed_nominal_pct,dd.steam_preasure,dd.dd_speed,dd.temp_out,ss.water_pct,ss.water_correction,
--ww.steam_pressure_at_the_inlet_of_regulation_unit,ww.product_temperature_at_the_outlet_of_JetCooker,ww.setpoint_of_steam_pressure_at_the_DD_inlet,ww.condensate_temperature_at_DD_outlet,ww.product_temperature_at_the_inlet,
--ww.setpoint_of_product_temperature,ww.product_at_the_outlet_of_JetCooker,ww.steam_pressure_at_the_inlet_of_JetCooker,ww.steam_pressure_at_the_outlet_of_regulation_unit,ww.product_temperature_at_the_outlet_of_product,
--'' steam_pressure_at_DD_inlet,
--_in.fat_pct,_in.particles_grp1,_in.particles_grp2,_in.particles_grp3,_in.moisture moisture_in, _us.usage_pct
--,osfp.efficiency
--,dp.moisture
--,dp.bulk_density
--from recipe_0_orders_details od
--join recipe_0_out_semi_finished_production osfp on osfp.orders_details_id = od.id
--join recipe_0_processing_details_bigbag bb on bb.orders_details_id = od.id and left(convert(varchar,bb.bigbag_filling_time_end,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
--join recipe_0_processing_details_dd dd on dd.orders_details_id = od.id and left(convert(varchar,dd.testing_time,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
--join recipe_0_out_test_during_production dp on dp.orders_details_id = od.id and left(convert(varchar,dp.testing_time,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
--join ( select orders_details_id,avg(water_pct) water_pct,-1*avg(abs(water_correction)) water_correction from recipe_0_processing_details_slurry group by orders_details_id
--) ss on ss.orders_details_id = od.id
--join (
--	select left(convert(varchar,timestamp,20),13) time,
--	avg(steam_pressure_at_the_inlet_of_regulation_unit) steam_pressure_at_the_inlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_JetCooker) product_temperature_at_the_outlet_of_JetCooker,
--	avg(setpoint_of_steam_pressure_at_the_DD_inlet) setpoint_of_steam_pressure_at_the_DD_inlet,avg(condensate_temperature_at_DD_outlet) condensate_temperature_at_DD_outlet,
--	avg(product_temperature_at_the_inlet) product_temperature_at_the_inlet,avg(setpoint_of_product_temperature) setpoint_of_product_temperature,
--	avg(product_at_the_outlet_of_JetCooker) product_at_the_outlet_of_JetCooker,avg(steam_pressure_at_the_inlet_of_JetCooker) steam_pressure_at_the_inlet_of_JetCooker,
--	avg(steam_pressure_at_the_outlet_of_regulation_unit) steam_pressure_at_the_outlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_product) product_temperature_at_the_outlet_of_product 
--	from [Walec DD08] group by timestamp 
--) ww on ww.time = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
--join recipe_0_raw_material_in _in on _in.id = od.id
--join recipe_0_raw_material_used _us on _us.id = od.id and _us.process_order_sap3 = _in.process_order_sap3
----where od.data_split = 'test' and osfp.class != 'optimal'
--union
select 
osfp.bigbag_filling_duration,osfp.bigbag_weight,bb.sifter_speed_nominal_pct,dd.steam_preasure,dd.dd_speed,dd.temp_out,ss.water_pct,ss.water_correction,
ww.steam_pressure_at_the_inlet_of_regulation_unit,ww.product_temperature_at_the_outlet_of_JetCooker,ww.setpoint_of_steam_pressure_at_the_DD_inlet,ww.condensate_temperature_at_DD_outlet,ww.product_temperature_at_the_inlet,
ww.setpoint_of_product_temperature,ww.product_at_the_outlet_of_JetCooker,ww.steam_pressure_at_the_inlet_of_JetCooker,ww.steam_pressure_at_the_outlet_of_regulation_unit,ww.product_temperature_at_the_outlet_of_product,
ww.steam_pressure_at_DD_inlet,
'' fat_pct,_in.particles_grp1,_in.particles_grp2,_in.particles_grp3,_in.moisture moisture_in, _us.usage_pct
,osfp.efficiency
,dp.moisture
,dp.bulk_density
from recipe_1_orders_details od
left join recipe_1_out_semi_finished_production osfp on osfp.orders_details_id = od.id
left join recipe_1_processing_details_bigbag bb on bb.orders_details_id = od.id and left(convert(varchar,bb.bigbag_filling_time_end,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
left join recipe_1_processing_details_dd dd on dd.orders_details_id = od.id and left(convert(varchar,dd.testing_time,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
left join recipe_1_out_test_during_production dp on dp.orders_details_id = od.id and left(convert(varchar,dp.testing_time,20),13) = left(convert(varchar,osfp.bigbag_filling_time_end,20),13)
left join ( select orders_details_id,avg(water_pct) water_pct,-1*avg(abs(water_correction)) water_correction from recipe_1_processing_details_slurry group by orders_details_id
) ss on ss.orders_details_id = od.id
left join (
	select left(convert(varchar,timestamp,20),13) time,'DD02' walec,
	avg(steam_pressure_at_the_inlet_of_regulation_unit) steam_pressure_at_the_inlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_JetCooker) product_temperature_at_the_outlet_of_JetCooker,
	avg(setpoint_of_steam_pressure_at_the_DD_inlet) setpoint_of_steam_pressure_at_the_DD_inlet,avg(condensate_temperature_at_DD_outlet) condensate_temperature_at_DD_outlet,
	avg(product_temperature_at_the_inlet) product_temperature_at_the_inlet,avg(setpoint_of_product_temperature) setpoint_of_product_temperature,avg(steam_pressure_at_DD_inlet) steam_pressure_at_DD_inlet,
	'' product_at_the_outlet_of_JetCooker,'' steam_pressure_at_the_inlet_of_JetCooker,
	avg(steam_pressure_at_the_outlet_of_regulation_unit) steam_pressure_at_the_outlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_product) product_temperature_at_the_outlet_of_product 
	from [Walec DD02] group by timestamp 
	union
	select left(convert(varchar,timestamp,20),13) time,'DD05' walec,
	avg(steam_pressure_at_the_inlet_of_regulation_unit) steam_pressure_at_the_inlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_JetCooker) product_temperature_at_the_outlet_of_JetCooker,
	avg(setpoint_of_steam_pressure_at_the_DD_inlet) setpoint_of_steam_pressure_at_the_DD_inlet,avg(condensate_temperature_at_DD_outlet) condensate_temperature_at_DD_outlet,
	avg(product_temperature_at_the_inlet) product_temperature_at_the_inlet,avg(setpoint_of_product_temperature) setpoint_of_product_temperature,avg(steam_pressure_at_DD_inlet) steam_pressure_at_DD_inlet,
	'' product_at_the_outlet_of_JetCooker,'' steam_pressure_at_the_inlet_of_JetCooker,
	avg(steam_pressure_at_the_outlet_of_regulation_unit) steam_pressure_at_the_outlet_of_regulation_unit,avg(product_temperature_at_the_outlet_of_product) product_temperature_at_the_outlet_of_product 
	from [Walec DD05] group by timestamp 
) ww on ww.time = left(convert(varchar,osfp.bigbag_filling_time_end,20),13) and ww.walec = od.line_dd
join recipe_1_raw_material_in _in on _in.id = od.id
join recipe_1_raw_material_used _us on _us.id = od.id and _us.process_order_sap = _in.process_order_sap
where od.data_split = 'val' --and osfp.class != 'optimal';