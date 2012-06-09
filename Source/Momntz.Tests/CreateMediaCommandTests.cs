using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Hypersonic.Session;
using Momntz.Data.CommandHandlers.Queue;
using Momntz.Data.Commands.Queue;
using Momntz.Infrastructure;
using Momntz.Model.Configuration;
using NUnit.Framework;

namespace Momntz.Tests
{
    [TestFixture]
    public class CreateMediaCommandTests
    {
        [Test]   
        public void CreateMedia_InsertNewMedia_IsCorrectlyInsertedIntoTheQueueDatabase()
        {
            Guid id = Guid.NewGuid();
            CreateMediaCommand command = new CreateMediaCommand(
                id, 
                Path.GetRandomFileName(),
                "jpg",
                12342134,
                Path.GetRandomFileName(),
                "image/jpg",
                "Image",
                new byte[123421]
                );

            CreateMediaCommandHandler handler = new CreateMediaCommandHandler(SessionFactory.SqlServer(), new Settings(new MomntzConfiguration(SessionFactory.SqlServer())));
            handler.Execute(command);
        }
    }
}
