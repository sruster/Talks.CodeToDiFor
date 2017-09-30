﻿using System;
using System.Collections.Generic;
using System.Linq;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp.Lib
{
	public class CostCalculator: ICostCalculator
	{
		readonly IList<IBasePriceRule> _basePriceRules;
		readonly IList<IExtendedPriceRule> _extendedPriceRules;
		readonly ILogger _logger;


		public CostCalculator(IList<IBasePriceRule> basePriceRules, IList<IExtendedPriceRule> extendedPriceRules, ILogger logger)
		{
			_basePriceRules = basePriceRules;
			_extendedPriceRules = extendedPriceRules;
			_logger = logger;

			logger.Info($"Rules Loaded: Base Price Rules ({_basePriceRules.Count() }) Extended Price Rules ({_extendedPriceRules.Count() }) --");
		}

		public int CalculatePrice(string message)
		{
			var msg = new MessageForProcessing()
			{
				Text = message,
				CurrentPrice = 0,
				Weight = CalculateWeight(message)
			};

			// Base Price
			foreach (var costRule in _basePriceRules)
			{
				if (costRule.AppliesTo(msg))
				{
					System.Console.WriteLine($"Applying Rule: {costRule.RuleName}");
					msg.CurrentPrice = costRule.Apply(msg);
				}
			}

			// Extended Prices
			foreach (var ExtRule in _extendedPriceRules)
			{
				if (ExtRule.AppliesTo(msg))
				{
					System.Console.WriteLine($"Applying Rule: {ExtRule.RuleName}");
					msg.CurrentPrice = ExtRule.Apply(msg);
				}
			}

			return msg.CurrentPrice;
		}

		// Not in Interface - but still unit testable for this implementation
		public int CalculateWeight(string message)
		{
			return message.Length;
		}
	}
}
