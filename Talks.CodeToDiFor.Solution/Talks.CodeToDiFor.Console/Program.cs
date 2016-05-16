﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.PCL.SuperSpyLib;
using Talks.PCL.SuperSpyLib.Data;
using Talks.PCL.SuperSpyLib.Imp;

namespace Talks.CodeToDiFor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\t* * * Spy Message Sender * * *");
            Console.Write("\n\tMessage:");
            var input = Console.ReadLine();

            ISpyLogger logger = new SpyLogger();
            IMessageSender sender = new MessageSender(logger);
            sender.Send(input);


            Console.WriteLine("\tLogger Output:");
            var msgs = logger.GetMessages();
            foreach(var msg in msgs)
            {
                Console.WriteLine("\t\t - " + msg);
            }

            Console.Write("\n\tDone.");
            Console.ReadLine();

           // ConsoleWithDI();
        }

        static void ConsoleWithDI()
        {
            // DI //
            var container = getContainer();
            var senderDI = container.Get<IMessageSender>();
            var loggerDI = container.Get<ISpyLogger>();

            Console.WriteLine("\n\t* * * Spy Message Sender with DI * * *");
            Console.Write("\n\tDI Message:");
            var inputDI = Console.ReadLine();

            senderDI.Send(inputDI);

            Console.WriteLine("\tDI Logger Output:");
            var msgsDI = loggerDI.GetMessages();
            foreach (var msg in msgsDI)
            {
                Console.WriteLine("\t\t - " + msg);
            }

            Console.Write("\n\tDI Done.");
            Console.ReadLine();
        }

        static IKernel getContainer()
        {
            IKernel container = new StandardKernel();
            container.Bind<ISpyLogger>().To<SpyLogger>();
            container.Bind<IEncrypter>().To<Encrypter>();
            container.Bind<ISpyDataLayer>().To<SpyDataLayer>();
            container.Bind<IMessageSender>().To<MessageSender>();
            container.Bind<IShippingCalculator>().To<ShippingCalculator>();

            return container;
        }
    }
}
