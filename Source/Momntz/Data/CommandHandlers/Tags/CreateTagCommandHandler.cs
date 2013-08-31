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

        public void Execute(CreateTagCommand parameters)
        {
            string newUsername = Regex.Replace(parameters.Name, @"\s", string.Empty).ToLower();
            string fullName = parameters.Name;

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
                                                                      parameters.Height,
                                                                      parameters.Width,
                                                                      CreatedBy = parameters.Username,
                                                                      parameters.Username,
                                                                      parameters.InternalId,
                                                                      XAxis = parameters.Left,
                                                                      YAxis = parameters.Top,
                                                                      parameters.MomentoId

                                                                  });
        }
    }
}
