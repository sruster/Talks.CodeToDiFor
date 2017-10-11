﻿using System;
using System.Linq;

namespace Talks.C2DF.Interfaces
{
	public interface ICostCalculator
	{
		int CalculatePrice(string message);
	}
}
