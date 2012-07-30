namespace Momntz.Data.Commands.Tags
{
    public class DeleteTagCommand : ICommand
    {
        public int Momentoid { get; set; }
        public int TagPersonId { get; set; }
        public string Username { get; set; }

        public DeleteTagCommand(int momentoid, int tagPersonId, string username)
        {
            Momentoid = momentoid;
            TagPersonId = tagPersonId;
            Username = username;
        }
    }
}
