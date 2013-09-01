using Momntz.Data.CommandHandlers.Media.Parameters;

namespace Momntz.Data.CommandHandlers.Media
{
    public interface IMediaRepository
    {
        /// <summary>
        /// Saves the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Save(SaveMediaParameters parameters);
    }
}
