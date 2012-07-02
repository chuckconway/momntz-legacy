using System.Collections.Generic;
using System.Data.Common;
using System.Text.RegularExpressions;
using Hypersonic;
using Momntz.Data.Commands.Tags;

namespace Momntz.Data.CommandHandlers.Tags
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand>
    {
        private readonly IMomntzSession _session;

        public CreateTagCommandHandler(IMomntzSession session)
        {
            _session = session;
        }

        public void Execute(CreateTagCommand command)
        {
            string name = Regex.Replace(command.Name, @"\s", string.Empty);
            string fullName = command.Name;
            _session.Session.Database.NonQuery("TagPerson_CreateTag", new
                                                                  {
                                                                      name,
                                                                      fullName,
                                                                      command.Height, 
                                                                      command.Width, 
                                                                      command.Username, 
                                                                      command.InternalId, 
                                                                      XAxis = command.Left, 
                                                                      YAxis = command.Top
                                                                  });
        }
    }
}
