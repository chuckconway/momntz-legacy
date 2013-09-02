using Momntz.Data.Projections.Momentos;
using Momntz.Data.Repositories.MomentoMedia.Parameters;

namespace Momntz.Data.Repositories.MomentoMedia
{
    public interface IMomentoMediaRepository
    {
        /// <summary>
        /// Finds the name of the momento by size and name.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <param name="filename">The filename.</param>
        /// <param name="username">The username.</param>
        /// <returns>Momento.</returns>
        Tile FindMomentoBySizeAndName(int size, string filename, string username);

        /// <summary>
        /// Finds the name of the momento from album by size and name.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Momento.</returns>
        Tile FindMomentoFromAlbumBySizeAndName(FindMomentoFromAlbumBySizeAndNameInParameters args);
    }
}
