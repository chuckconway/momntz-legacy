//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Momntz.Model;

//namespace Momntz.UI.Core.RouteConstraints
//{
//    public class UserRouteCache
//    {
//        private static readonly object _lock = new object();

//        private readonly IUserRepository _userRepository;
//        private readonly ICacheProvider _cacheProvider;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="UserRouteConstraint"/> class.
//        /// </summary>
//        /// <param name="userRepository">The user repository.</param>
//        /// <param name="cacheProvider">The cache provider.</param>
//        public UserRouteCache(IUserRepository userRepository, ICacheProvider cacheProvider)
//        {
//            _userRepository = userRepository;
//            _cacheProvider = cacheProvider;
//        }

//        /// <summary>
//        /// Selects all.
//        /// </summary>
//        /// <returns></returns>
//        public IList<User> SelectAll()
//        {
//            const string key = "SelectAll";
//            IList<User> users = _cacheProvider.Retrieve(key) as IList<User>;

//            if (users == null)
//            {
//                lock (_lock)
//                {
//                    if (users == null)
//                    {
//                        users = _userRepository.RetrieveAll();
//                        _cacheProvider.Add(key, users, new TimeSpan(0, 0, 5));
//                    }
//                }

//            }


//            return users;
//        }

//    }
//}