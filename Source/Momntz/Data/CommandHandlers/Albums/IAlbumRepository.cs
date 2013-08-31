using System.Collections.Generic;
using Momntz.Data.CommandHandlers.Albums.Parameters;
using Momntz.Data.Commands.Albums;
using Momntz.Data.Projections;
using Momntz.Data.Projections.Momentos;

namespace Momntz.Data.CommandHandlers.Albums
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// News the specified command.
        /// </summary>
        /// <param name="parameters">The command.</param>
        void New(NewAlbumParameters parameters);

        /// <summary>
        /// Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns>List{Tile}.</returns>
        List<Tile> GetMomentosById(int id, string username);

        /// <summary>
        /// Gets the next albums.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{Tile}.</returns>
        List<Tile> GetNextMomentos(AlbumTileScrollInParamters args);

        /// <summary>
        /// Gets the next albums.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{IGroupItem}.</returns>
        List<IGroupItem> GetNextAlbums(AutoScrollInParameters args);

        /// <summary>
        /// Gets the albums for user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{IGroupItem}.</returns>
        List<IGroupItem> GetAlbumsForUser(string username);

        /// <summary>
        /// Finds the name of the by.
        /// </summary>
        /// <param name="byName">Name of the by.</param>
        /// <returns>List{IGroupItem}.</returns>
        List<IGroupItem> FindNewlyAddedByName(FindAlbumByNameInParameters byName);
    }
}
