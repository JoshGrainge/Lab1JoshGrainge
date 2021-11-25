// https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio

using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

using Psim.Materials;
using System;

namespace Psim.IOManagers
{
	public static class InputManager
	{
        public static Model InitializeModel(string path)
		{
            JObject modelData = LoadJson(path);
			// This model can only handle 1 material
			Material material = GetMaterial(modelData["materials"][0]);
			Model model = GetModel(material, modelData["settings"]);
			AddSensors(model, modelData["sensors"]);
			AddCells(model, modelData["cells"]);
            return model;
		}
        private static JObject LoadJson(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JObject modelData = JObject.Parse(json);
                return modelData;
            }
        }

        private static void AddCells(Model m, JToken cellData)
		{
            int cellNum = cellData.Count();

            for (int i = 0; i < cellNum; i++)
            {
                var l = (double)cellData[i]["length"];
                var w = (double)cellData[i]["width"];
                var sensorId = (int)cellData[i]["sensorID"];

                Console.WriteLine($"Successfully added a {l} x {w} cell to the model. The cell is linked to sensor {sensorId}");
                m.AddCell(l, w, sensorId);
            }
		}

        private static void AddSensors(Model m, JToken sensorData)
		{
            int cellNum = sensorData.Count();

            for (int i = 0; i < cellNum; i++)
            {
                var id = (int)sensorData[i]["id"];
                var initTemp = (double)sensorData[i]["t_init"];

                Console.WriteLine($"Successfully added sensor {id} to the model. The sensor's initial temperature is {initTemp}");
                m.AddSensor(id, initTemp);
            }
        }

        private static Model GetModel(Material material, JToken settingsData)
		{
            var highTemp = (double)settingsData["high_temp"];
            var lowTemp = (double)settingsData["low_temp"];
            var simTime = (double)settingsData["sim_time"];

            Model m = new Model(material, highTemp, lowTemp, simTime);
            Console.WriteLine($"Successfully created a model {highTemp} {lowTemp} {simTime}");
            return m;
		}

        private static Material GetMaterial(JToken materialData)
		{
            var dData = GetDispersionData(materialData["d_data"]);
            var rData = GetRelaxationData(materialData["r_data"]);

            return new Material(dData, rData);
		}

        private static DispersionData GetDispersionData(JToken dData)
		{
            var laData = dData["la_data"].ToObject<double[]>();
            var taData = dData["ta_data"].ToObject<double[]>();

            var wMaxLa = (double)dData["max_freq_la"];
            var wMaxTa = (double)dData["max_freq_ta"];


            return new DispersionData(laData, wMaxLa, taData, wMaxTa);
		}

        private static RelaxationData GetRelaxationData(JToken rData)
		{
            var b_l = (double)rData["b_l"];
            var b_tn = (double)rData["b_tn"];
            var b_tu = (double)rData["b_tu"];
            var b_i = (double)rData["b_i"];
            var w = (double)rData["w"];

            return new RelaxationData(b_l, b_tn, b_tu, b_i, w);
		}
    }
}
