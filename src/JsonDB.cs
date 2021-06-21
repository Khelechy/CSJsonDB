using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Reflection;
using CSJsonDB.helpers;

namespace CSJsonDB
{
    public static class JsonDB
    {
        public static string jsonFile;
		public static string jsonLocation;
		private static JObject _dbObject;

		public static JObject Load(string filePathLoaded)
		{
			if (!File.Exists(filePathLoaded))
				throw new Exception("File does not exist, please check file or file path");
			try
			{
				jsonFile = File.ReadAllText(filePathLoaded);
				jsonLocation = filePathLoaded;
				return _dbObject = JObject.Parse(jsonFile);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
		}

		public static object Select(this object data, string table = "")
		{

			if (data != null)
			{
				try
				{
					var parsedData = JObject.Parse(data.ToString());
					var result = string.IsNullOrEmpty(table) ? (object)parsedData : (object)parsedData[table];
					return result;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}
		}

		public static List<dynamic> Where(this object data, string key = "", dynamic value = null)
		{
			if (data != null)
			{
				var dataArray = data.ToDataList();
				var newDataArray = new List<dynamic>();
				foreach (var singleData in dataArray.Where(x => x[key] as dynamic == value))
				{
					newDataArray.Add(singleData);
				}
				return newDataArray;
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}

		}

		public static void Add(this object data, string table, object newData)
		{
			if (data != null)
			{
				try
				{
					var parsedData = JObject.Parse(data.ToString());
					var result = string.IsNullOrEmpty(table) ? (object)parsedData : (object)parsedData[table];
					var dataArray = result.ToDataList();
					dataArray.Add(JObject.Parse(JsonConvert.SerializeObject(newData, Formatting.Indented)));
					parsedData[table] = dataArray;
					string newJsonResult = parsedData.ToString();
					File.WriteAllText(jsonLocation, newJsonResult);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}
		}

		public static void Delete(this object data, string table, string key, dynamic value)
		{
			if (data != null)
			{
				try
				{
					var parsedData = JObject.Parse(data.ToString());
					var result = (object)parsedData[table];
					var dataArray = result.ToDataList();
					var itemToBeDeleted = dataArray.FirstOrDefault(x => x[key] as dynamic == value);
					if (itemToBeDeleted == null)
						throw new Exception("There are no objects with key: " + key + " , Please check key again");
					dataArray.Remove(itemToBeDeleted);
					parsedData[table] = dataArray;
					string newJsonResult = parsedData.ToString();
					File.WriteAllText(jsonLocation, newJsonResult);
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}
		}

		public static object Update(this object data, string table, string key, dynamic value, object newData)
		{
			if (data != null)
			{
				try
				{
					var parsedData = JObject.Parse(data.ToString());
					var result = (object)parsedData[table];
					var dataArray = result.ToDataList();
					var x = dataArray.FirstOrDefault(x => x[key] as dynamic == value);
					if (x == null)
						throw new Exception("There are no objects with key: " + key + " , Please check key again");
					foreach (PropertyInfo prop in newData.GetType().GetProperties())
					{
						var valueObject = prop.GetValue(newData, null);
						x[prop.Name] = JToken.FromObject(valueObject);
					}
					parsedData[table] = dataArray;
					string newJsonResult = parsedData.ToString();
					File.WriteAllText(jsonLocation, newJsonResult);
					return x;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message.ToString());
				}
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}
		}

		public static string ToJsonString(this object data)
		{
			if(data != null)
			{
				return JsonConvert.SerializeObject(data);
			}
			else
			{
				throw new Exception("The preloaded data is null");
			}
		}
    }
}
