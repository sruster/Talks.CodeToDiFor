﻿using System;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib.v2Features
{
	public class BetterEncryptor: IEncryptHelper
	{

		readonly IAppLogger _logger;
		public BetterEncryptor(IAppLogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public string Decrypt(string message)
		{

			_logger.Debug($"BetterEncryptor - Decrypting Message: {message} : ");
			return Reverse(message);
		}

		public string Encrypt(string message)
		{
			_logger.Debug($"BetterEncryptor - Encrypting Message: {message} : ");
			return Reverse(message);
		}

		private string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
