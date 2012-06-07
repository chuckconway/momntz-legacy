﻿using System;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using Momntz.Data.Commands.Queue;
using Momntz.Infrastructure;
using Momntz.Worker.Core.Implementations.Media;
using StructureMap;


namespace Momntz.UI.Core.RouteHandler
{
    public class UploadHttpHandler : IHttpHandler
    {
        private readonly ICommandProcessor _commandProcessor;
        readonly string[] _images = new[] { "jpg", "jpeg", "png", "gif", "tiff" };
        readonly string[] _documents = new[] { "pdf", "doc", "docx", "txt" };
        readonly string[] _videos = new[] { "avi", "mp4" };

        public UploadHttpHandler()
        {
            _commandProcessor = ObjectFactory.GetInstance<ICommandProcessor>();
        }

        private MediaType GetMediaType(string extension)
        {
            MediaType mediaType = MediaType.Unsupported;

            var types = new[]
                            {
                                new{Types = _images, MediaType= MediaType.Image},
                                new {Types = _documents, MediaType = MediaType.Document},
                                new {Types = _videos, MediaType = MediaType.Video}
                            };
            
            extension = extension.TrimStart('.');

            foreach (var type in types.Where(type => type.Types.Any(s=> string.Equals(s, extension, StringComparison.InvariantCulture))))
            {
                mediaType = type.MediaType;
            }

            return mediaType;
        }

        public void ProcessRequest(HttpContext context)
        {
            //IStorage storage = new AzureStorage();
            //storage.AddFile("img", file.FileName, file.ContentType, file.InputStream);

            //Image formats
            //jpg, jpeg, png, gif, tiff

            //Documents Formats
            //PDF, doc, docx, text
            var file = context.Request.Files["filedata"];

            var bytes = GetBytes(file);
            var extension = Path.GetExtension(file.FileName);
            var mediaType = GetMediaType(extension);

            Guid id = Guid.NewGuid();
            CreateMediaCommand command = new CreateMediaCommand(id, file.FileName, extension, file.ContentLength, string.Empty, file.ContentType, mediaType.ToString(), bytes);
            _commandProcessor.Process(command);

            string message = GetMediaMessage(id, mediaType);
            CreateQueueCommand queue = new CreateQueueCommand("Momntz.Worker.Core.Implementations.Media.MediaMessage", message);
            _commandProcessor.Process(queue);
            
            context.Response.Write("1");
        }

        private string GetMediaMessage(Guid id, MediaType mediaType)
        {
            MediaMessage mediaMessage = new MediaMessage {Id = id, MediaType = mediaType};
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(mediaMessage);
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