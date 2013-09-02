using System.Collections.Generic;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Repositories.Momentos.Parameters;
using Momntz.Data.Schema;

namespace Momntz.Data.Repositories.Momentos
{
    public interface IMomentoRepository
    {
        /// <summary>
        ///     Updates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Update(UpdateMomentoParameters parameters);

        /// <summary>
        ///     Creates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        void Create(CreateMomentoParameters parameters);

        /// <summary>
        ///     Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>Momento.</returns>
        Momento GetById(int id);

        /// <summary>
        /// Gets the tile by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>Tile.</returns>
        Tile GetTileById(int id);

        /// <summary>
        ///     Infinites the scroll.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{Tile}.</returns>
        List<Tile> InfiniteScroll(UserInfiniteScrollInParameters args);

        /// <summary>
        ///     First40s the specified arguments.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{Tile}.</returns>
        List<Tile> First40(string username);

        /// <summary>
        /// Gets the people by momento unique identifier.
        /// </summary>
        /// <param name="momentoId">The momento unique identifier.</param>
        /// <returns>List{Person}.</returns>
        List<MomentoPerson> GetPeopleByMomentoId(int momentoId);
    }
}