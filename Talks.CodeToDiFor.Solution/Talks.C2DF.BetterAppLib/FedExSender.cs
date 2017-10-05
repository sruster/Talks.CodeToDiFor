﻿using System;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib
{
	public class FedExSender: IMessageSender
	{
		IEncryptHelper _crypto;
		IAppLogger _logger;

		public FedExSender(IEncryptHelper crypto, IAppLogger logger)
		{
			_crypto = crypto;
			_logger = logger;
		}

		public void Send(string message)
		{
			var xMsg = _crypto.Encrypt(message);
			_logger.Info($"Message Sent via FedEx: {xMsg}");
		}
	}
}
