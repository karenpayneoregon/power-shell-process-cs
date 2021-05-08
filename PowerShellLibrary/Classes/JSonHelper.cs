using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using PowerShellLibrary.Converters;

namespace PowerShellLibrary.Classes
{
    /// <summary>
	/// When viewing in GitHub formatting of this file is way off
	/// </summary>
	public class JSonHelper
	{
		/// <summary>
		/// Deserialize from Json string to TModel
		/// </summary>
		/// <typeparam name="TModel">Type to deserialize Json to</typeparam>
		/// <param name="json">Valid json for deserialize TModel too.</param>
		/// <returns>single instance of TModel</returns>
		public static TModel DeserializeObject<TModel>(string json) => JsonSerializer.Deserialize<TModel>(json);
		/// <summary>
		/// Deserialize from Json string to TModel using <see cref="UnixEpochLocalDateTimeConverter"/>
		/// </summary>
        /// <typeparam name="TModel">Type to deserialize Json to</typeparam>
        /// <param name="json">Valid json for deserialize TModel too.</param>
        /// <returns>single instance of TModel</returns>
		public static TModel DeserializeObjectUnixEpochDateTime<TModel>(string json)
        {

            JsonSerializerOptions options = new();
            options.Converters.Add(new UnixEpochLocalDateTimeConverter());
			
            return JsonSerializer.Deserialize<TModel>(json, options);

        }
        
		/// <summary>
		/// Deserialize from Json string to List(Of TModel)
		/// </summary>
		/// <typeparam name="TModel">Type to deserialize Json to</typeparam>
		/// <param name="json">Valid json for deserialize TModel too</param>
		/// <returns>List(Of TModel)</returns>
		public static List<TModel> JSonToList<TModel>(string json)
		{

			JsonSerializerOptions options = new();
			options.Converters.Add(new UnixEpochLocalDateTimeConverter());

			return JsonSerializer.Deserialize<List<TModel>>(json);

		}

		/// <summary>
		/// Write T to json file
		/// </summary>
		/// <typeparam name="TModel">Type</typeparam>
		/// <param name="sender">Type</param>
		/// <param name="fileName">File name with optional path</param>
		/// <returns></returns>
		public static bool ObjectToJsonFormatted<TModel>(TModel sender, string fileName)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Serialize a list to a file
		/// </summary>
		/// <typeparam name="TModel"></typeparam>
		/// <param name="sender">Type to serialize</param>
		/// <param name="fileName">File json to this file</param>
		/// <param name="format">true to format json, otherwise no formatting</param>
		/// <returns>Value Tuple, on success return true/null, otherwise false and the exception thrown</returns>
		public static (bool result, Exception exception) JsonToListFormatted<TModel>(List<TModel> sender, string fileName, bool format = true)
		{

			try
			{

				var options = new JsonSerializerOptions { WriteIndented = true };
				File.WriteAllText(fileName, JsonSerializer.Serialize(sender, (format ? options : null)));

				return (true, null);

			}
			catch (Exception e)
			{
				return (false, e);
			}

		}
	}

}
