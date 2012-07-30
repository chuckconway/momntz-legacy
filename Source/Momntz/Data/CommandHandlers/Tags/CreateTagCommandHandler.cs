using System.Text.RegularExpressions;
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
            string newUsername = Regex.Replace(command.Name, @"\s", string.Empty).ToLower();
            string fullName = command.Name;
            _session.Session.Database.NonQuery("TagPerson_CreateTag", new
                                                                  {
                                                                      newUsername,
                                                                      fullName,
                                                                      command.Height, 
                                                                      command.Width,
                                                                      CreatedBy = command.Username, 
                                                                      command.Username, 
                                                                      command.InternalId, 
                                                                      XAxis = command.Left, 
                                                                      YAxis = command.Top,
                                                                      command.MomentoId

                                                                  });
        }
    }
}
