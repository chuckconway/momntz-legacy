using System;
using System.Collections.Generic;
using System.Linq;
using Momntz.Core.Extensions;
using Momntz.Data.Projections.Api;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Repositories.Momentos.Parameters;
using Momntz.Data.Schema;
using Momntz.Infrastructure;
using Momntz.Infrastructure.Configuration;
using NHibernate;
using NHibernate.Criterion;
using Mapper = AutoMapper.Mapper;

namespace Momntz.Data.Repositories.Momentos
{
    public class MomentoRepository : IMomentoRepository
    {
        private readonly IMap _mapper;
        private readonly ISession _session;
        private readonly ISettings _settings;


        /// <summary>
        ///     Initializes a new instance of the <see cref="MomentoRepository" /> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="database">The database.</param>
        /// <param name="settings">The settings.</param>
        public MomentoRepository(ISession session, IMap mapper, ISettings settings)
        {
            _session = session;
            _mapper = mapper;
            _settings = settings;
        }

        /// <summary>
        ///     Creates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Create(CreateMomentoParameters parameters)
        {
            Momento single = SaveMomento(parameters);
            SaveMedia(parameters, single);
        }

        /// <summary>
        ///     Gets the by unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>Momento.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Momento GetById(int id)
        {
            Momento momento;

            using (ITransaction trans = _session.BeginTransaction())
            {
                momento = _session.Get<Momento>(id);
                trans.Commit();
            }

            return momento;
        }

        /// <summary>
        ///     Infinites the scroll.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>List{Tile}.</returns>
        public List<Tile> InfiniteScroll(UserInfiniteScrollInParameters args)
        {
            using (ITransaction trans = _session.BeginTransaction())
            {
                IList<object> items = _session.CreateQueryProcedure<object>("Momento_GetNext40Momentos", args)
                    .List<object>();

                object[] ids = items.Cast<IDictionary<string, string>>().Select(i => (object) i["MomentoId"]).ToArray();

                List<Tile> momentos = _session.QueryOver<Momento>()
                    .OrderBy(n => n.CreateDate).Desc
                    .Where(Restrictions.In("Id", ids))
                    .List()
                    .ToList()
                    .ConvertToTiles(_settings);

                trans.Commit();
                return momentos;
            }
        }

        /// <summary>
        ///     First40s the specified arguments.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List{Tile}.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public List<Tile> First40(string username)
        {
            using (ITransaction trans = _session.BeginTransaction())
            {
                IList<Momento> items = _session.QueryOver<Momento>()
                    .And(m => m.User.Username == username)
                    .OrderBy(m => m.CreateDate).Desc
                    .Take(40)
                    .List();

                trans.Commit();

                return items.ConvertToTiles(_settings);
            }
        }

        /// <summary>
        /// Gets the people by momento unique identifier.
        /// </summary>
        /// <param name="momentoId">The momento unique identifier.</param>
        /// <returns>List{Person}.</returns>
        public List<MomentoPerson> GetPeopleByMomentoId(int momentoId)
        {
            using (var trans = _session.BeginTransaction())
            {
                var items = _session.QueryOver<Person>()
                         .Where(p => p.Momento.Id == momentoId)
                         .List();


                trans.Commit();

                return items.Select(
                        i => new MomentoPerson()
                        {
                            MomentoId = i.Momento.Id,
                            Id = i.Id,
                            CreatedBy = i.CreatedBy,
                            DisplayName = i.Name,
                            Height = i.Height,
                            Username = i.Username,
                            Width = i.Width,
                            XAxis = i.XAxis,
                            YAxis = i.YAxis
                        }).ToList();
            }
        }

        /// <summary>
        ///     Updates the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public void Update(UpdateMomentoParameters parameters)
        {
            Func<string, int?> nullable =
                s => (string.IsNullOrEmpty(parameters.Day) ? null : (int?) Convert.ToInt32(parameters.Day));

            using (ITransaction trans = _session.BeginTransaction())
            {
                var momento = _session.Get<Momento>(parameters.Id);
                momento.Title = parameters.Title;
                momento.Story = parameters.Story;
                momento.Day = nullable(parameters.Day);
                momento.Month = nullable(parameters.Month);
                momento.Year = nullable(parameters.Year);

                _session.Save(momento);
                trans.Commit();
            }
        }

        /// <summary>
        ///     Saves the media.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="single">The single.</param>
        private void SaveMedia(CreateMomentoParameters command, Momento single)
        {
            command.Media.ForEach(m => m.MomentoId = single.Id);
            List<Schema.MomentoMedia> media =
                command.Media.ConvertAll(Mapper.DynamicMap<CreateMomentoMediaParameters, Schema.MomentoMedia>);

            using (ITransaction transaction = _session.BeginTransaction())
            {
                foreach (Schema.MomentoMedia momentoMedia in media)
                {
                    momentoMedia.Momento = single;
                    _session.Save(momentoMedia);
                }

                transaction.Commit();
            }
        }

        /// <summary>
        ///     Saves the momento.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Momento.</returns>
        private Momento SaveMomento(CreateMomentoParameters command)
        {
            Momento momento = _mapper.Map<CreateMomentoParameters, Momento>(command);

            momento.UploadedBy = command.Username;
            momento.InternalId = Guid.NewGuid();
            momento.Visibility = MomentoVisibility.Public;

            using (ITransaction trans = _session.BeginTransaction())
            {
                _session.Save(momento);
                _session.Save(new MomentoUser {Momento = momento, Username = command.Username});

                trans.Commit();
            }

            return momento;
        }
    }
}