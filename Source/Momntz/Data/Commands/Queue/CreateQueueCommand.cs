namespace Momntz.Data.Commands.Queue
{
    public class CreateQueueCommand : ICommand
    {
        public CreateQueueCommand(string implementation, string payload)
        {
            Implementation = implementation;
            Payload = payload;
        }

        public string Implementation { get; set; }

        public string Payload { get; set; }
    }

}
