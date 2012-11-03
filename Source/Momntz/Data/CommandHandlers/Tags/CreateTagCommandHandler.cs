using System.Text.RegularExpressions;
using Hypersonic;
using Momntz.Data.Commands.Tags;

namespace Momntz.Data.CommandHandlers.Tags
{
    public class CreateTagCommandHandler : ICommandHandler<CreateTagCommand>
    {
        private readonly IDatabase _database;

        public CreateTagCommandHandler(IDatabase database)
        {
            _database = database;
        }

        public void Execute(CreateTagCommand command)
        {
            string newUsername = Regex.Replace(command.Name, @"\s", string.Empty).ToLower();
            string fullName = command.Name;

            //using (ISession session = _factory.OpenSession())
            //{
            //   var person = session.QueryOver<Person>()
            //        .Where(p => p.Name == fullName)
            //        .And(p => p.Username == command.Username)
            //        .And(p => p.Momento.Id == command.MomentoId)
            //        .SingleOrDefault();

            //    if(person != null)
            //    {
            //        person.Width = command.Width;
            //        person.Height = command.Height;
            //        person.XAxis = command.Left;
            //        person.YAxis = command.Top;

            //        session.Save(person);
            //    }
            //    else
            //    {
                    
            //    }
            //}

            _database.NonQuery("TagPerson_CreateTag", new
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
