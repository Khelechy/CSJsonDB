using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJsonDB.helpers
{
	public static class ExtensionMethods
	{
		public static JArray toDataList(this object data)
		{
			if (data != null)
			{
				try
				{
					var token = JToken.Parse(data.ToString());
					if (token is JArray)
					{

						JArray dataArray = (JArray)data;
						return dataArray;
					}
					else
					{
						throw new Exception("The preloaded data is not a Json Array");
					}
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

	}
}
