using System.Collections.Generic;
using Momntz.Data.Projections.Momentos;
using Momntz.Data.Projections.Users;
using Momntz.Infrastructure.Processors;
using Momntz.UI.Areas.Users.Models;
using Momntz.UI.Core;

namespace Momntz.UI.Areas.Users.Handlers.Index
{
    public class GetMomentosUserPageHandler : HandlerBase, IQueryHandler<GetUserMomentsInParameters, UserView>
    {
        private readonly IProjectionProcessor _processor;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMomentosUserPageHandler" /> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        public GetMomentosUserPageHandler(IProjectionProcessor processor)
        {
            _processor = processor;
        }

        /// <summary>
        /// Handles the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>UserView.</returns>
        public UserView Handle(GetUserMomentsInParameters args)
        {
            var view = new UserView
                {
                    Username = args.Username,
                    DisplayName = _processor.Process<string, DisplayName>(args.Username).Fullname,
                    IsAuthenticatedUser = args.IsAuthenticatedUser,
                    Momentos = _processor.Process<string, List<MomentoWithMedia>>(args.Username)
                };

            return view;
        }
    }

    public class GetUserMomentsInParameters
    {
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is authenticated user.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated user; otherwise, <c>false</c>.</value>
        public bool IsAuthenticatedUser { get; set; }
    }
}