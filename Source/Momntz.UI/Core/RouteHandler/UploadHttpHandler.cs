using System;
using System.IO;
using System.Web;
using Momntz.Core.Contants;
using Momntz.Data.Repositories.Media;
using Momntz.Data.Repositories.Media.Parameters;
using Momntz.Messaging.Models;
using Momntz.UI.Core.Controllers;
using StructureMap;


namespace Momntz.UI.Core.RouteHandler
{
    public class UploadHttpHandler : IHttpHandler
    {
        private readonly IMediaRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadHttpHandler" /> class.
        /// </summary>
        public UploadHttpHandler(IMediaRepository repository)
        {
            _repository = repository;
        }

        public UploadHttpHandler() : this(ObjectFactory.GetInstance<IMediaRepository>()) { }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            //Image formats
            //jpg, jpeg, png, gif, tiff

            //Documents Formats
            //PDF, doc, docx, text
            var file = context.Request.Files[FormConstants.UploadParameterName];
            var albumId = context.Request[FormConstants.AlbumIdParameterName];

            var bytes = GetBytes(file);
            var username = BaseController.AuthenticatedUsername();

            var extension = Path.GetExtension(file.FileName).Replace(".", string.Empty);

            var id = Guid.NewGuid();
            var media = new MediaMessage
            {
                AlbumId = (string.IsNullOrEmpty(albumId) ? null : (int?)Convert.ToInt32(albumId)),
                Extension = extension,
                Filename = file.FileName,
                Id = id,
                Size = bytes.Length,
                Username = username
            };

            _repository.Save(new SaveMediaParameters(id, bytes, media));
        }

        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>System.Byte[][].</returns>
        private static byte[] GetBytes(HttpPostedFile file)
        {
            var memoryStream = new MemoryStream();
            file.InputStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler" /> instance.
        /// </summary>
        /// <value><c>true</c> if this instance is reusable; otherwise, <c>false</c>.</value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler" /> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return true; }
        }
    }
}