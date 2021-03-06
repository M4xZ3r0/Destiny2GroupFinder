﻿using System.Collections.Generic;
using WpfGroupFinder.Models;

namespace WpfGroupFinder.Logic
{
	public interface IGroupParser
	{
		IEnumerable<Guardian> GetFireteam(string pageUrl);

		IEnumerable<Group> UpdateGroupList(IList<Group> currentGroups, string language);
	}
}