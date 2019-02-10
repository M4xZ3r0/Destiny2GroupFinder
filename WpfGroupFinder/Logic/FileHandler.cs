﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WpfGroupFinder.Models;

namespace WpfGroupFinder.Logic
{
	public class FileHandler : IFileHandler
	{
		private const string Filename = "groups";

		public IEnumerable<Group> LoadGroups(string languageShort)
		{
			var groups = new List<Group>();

			if (!File.Exists(GetLangaugeSpecificFilename(languageShort)))
			{
				return groups;
			}
			using (StreamReader file = File.OpenText(GetLangaugeSpecificFilename(languageShort)))
			{
				JsonSerializer serializer = new JsonSerializer();
				groups = (List<Group>)serializer.Deserialize(file, typeof(List<Group>));
			}

			return groups;
		}

		public async Task SaveGroups(IEnumerable<Group> groups, string languageShort)
		{
			await Task.Run(() =>
			{
				using (StreamWriter file = File.CreateText(GetLangaugeSpecificFilename(languageShort)))
				{
					JsonSerializer serializer = new JsonSerializer();
					serializer.Serialize(file, groups);
				}
			});
		}

		private string GetLangaugeSpecificFilename(string languageShort)
		{
			return Filename + "_" + languageShort + ".json";
		}
	}
}