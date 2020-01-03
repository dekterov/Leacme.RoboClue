// Copyright (c) 2017 Leacme (http://leac.me). View LICENSE.md for more information.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Humanizer;
using Humanizer.Bytes;
using NickStrupat;

namespace Leacme.Lib.RoboClue {

	public class Library {

		public Library() {

		}

		/// <summary>
		/// Retrieves the local machine information in a variable:value format.
		/// /// </summary>
		/// <param name="variable"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public List<(string variable, string value)> GetComputerInformation() {
			var ci = new ComputerInfo();
			var infoList = new List<(string variable, string value)>();

			infoList.Add((nameof(ci.OSFullName).Humanize(LetterCasing.Title), ci.OSFullName));
			infoList.Add((nameof(Environment.OSVersion).Humanize(LetterCasing.Title), Environment.OSVersion.ToString()));
			infoList.Add((nameof(Environment.ProcessorCount).Humanize(LetterCasing.Title), Environment.ProcessorCount.ToString()));
			infoList.Add((nameof(ci.TotalPhysicalMemory).Humanize(LetterCasing.Title), Math.Round(ByteSize.FromBytes(ci.TotalPhysicalMemory).Gigabytes, 2) + " GB"));
			infoList.Add((nameof(Environment.Is64BitOperatingSystem).Humanize(LetterCasing.Title), Environment.Is64BitOperatingSystem.ToString()));
			infoList.Add((nameof(Environment.MachineName).Humanize(LetterCasing.Title), Environment.MachineName));
			infoList.Add((nameof(Environment.Version).Humanize(LetterCasing.Title), Environment.Version.ToString()));
			infoList.Add((nameof(Environment.UserName).Humanize(LetterCasing.Title), Environment.UserName));
			infoList.Add((nameof(Environment.UserDomainName).Humanize(LetterCasing.Title), Environment.UserDomainName));
			infoList.Add((nameof(Environment.SystemPageSize).Humanize(LetterCasing.Title), Environment.SystemPageSize.ToString()));
			infoList.Add((nameof(Environment.TickCount).Humanize(LetterCasing.Title), Environment.TickCount.ToString()));

			Environment.GetCommandLineArgs().ForEach(z => infoList.Add(("Command Line Arg", z)));
			((System.Collections.Hashtable)Environment.GetEnvironmentVariables()).Cast<DictionaryEntry>().ForEach(z => infoList.Add(("Environment Variable", z.Key + "=" + z.Value)));
			Environment.GetLogicalDrives().ForEach(z => infoList.Add(("Logical Drive", z)));

			if (!string.IsNullOrWhiteSpace(Environment.SystemDirectory)) {
				infoList.Add((nameof(Environment.SystemDirectory).Humanize(LetterCasing.Title), Environment.SystemDirectory));
			}

			foreach (Environment.SpecialFolder sf in Enum.GetValues(typeof(Environment.SpecialFolder))) {
				if (!string.IsNullOrWhiteSpace(Environment.GetFolderPath(sf))) {
					infoList.Add((sf.Humanize(LetterCasing.Title), Environment.GetFolderPath(sf)));
				}
			}

			return infoList;
		}
	}
}