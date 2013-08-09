using System;
using System.IO;
using System.Web;
using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Queue;
using Momntz.Messaging.Models;
using Momntz.UI.Core.Controllers;
using StructureMap;


namespace Momntz.UI.Core.RouteHandler
{
    public class UploadHttpHandler : IHttpHandler
    {
        private readonly ICommandHandler<CreateMediaCommand> _commandHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="UploadHttpHandler" /> class.
        /// </summary>
        public UploadHttpHandler()
        {
            _commandHandler = ObjectFactory.GetInstance<ICommandHandler<CreateMediaCommand>>();
        }

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
            var file = context.Request.Files["filedata"];

            var bytes = GetBytes(file);
            var username = BaseController.AuthenticatedUsername();

            var extension = Path.GetExtension(file.FileName).Replace(".", string.Empty);

            var id = Guid.NewGuid();
            var media = new MediaMessage
            {
                Extension = extension,
                Filename = file.FileName,
                Id = id,
                Size = bytes.Length,
                Username = username
            };

            //Save the media to storage
            var command = new CreateMediaCommand(id, bytes, media);
            _commandHandler.Execute(command);
           
            context.Response.Write("1");
        }

        private static byte[] GetBytes(HttpPostedFile file)
        {
            var memoryStream = new MemoryStream();
            file.InputStream.CopyTo(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            return bytes;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}