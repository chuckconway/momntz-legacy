using Momntz.Data.Repositories.Media.Parameters;

namespace Momntz.Data.Repositories.Media
{
    public interface IMediaRepository
    {
        /// <summary>
        ///     Saves the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Save(SaveMediaParameters parameters);
    }
}