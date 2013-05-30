namespace Momntz.Messaging
{
    public interface ISaga<in T>  where T :class , new() 
    {
        /// <summary>
        /// Processes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Consume(T message);
    }
}
