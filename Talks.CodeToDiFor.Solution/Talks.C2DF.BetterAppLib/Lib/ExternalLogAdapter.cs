﻿using System;
using System.Linq;
using Talks.C2DF.Interfaces.ExternalLibrary;
using Inter = Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib
{
	public class ExternalLogAdapter: Inter.ILogger
	{
		readonly ILogger _logger;
		public ExternalLogAdapter(ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public void Debug(string Message)
		{
			_logger.Debug(Message);
		}

		public void Error(string Message)
		{
			_logger.Error(Message);
		}

		public void Info(string Message)
		{
			_logger.Info(Message);
		}

		public void Warn(string Message)
		{
			_logger.Warn(Message);
		}
	}
}
