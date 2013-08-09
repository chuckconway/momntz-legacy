using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Momntz.Data.CommandHandlers;
using Momntz.Data.Commands.Tags;
using Momntz.Data.ProjectionHandlers;
using Momntz.Data.ProjectionHandlers.Api;
using Momntz.Data.Projections.Api;
using Momntz.UI.Areas.Api.Models;
using Momntz.UI.Core.Controllers;

namespace Momntz.UI.Areas.Api.Controllers
{
    public class TagsController : BaseController
    {
        private readonly IProjectionHandler<NameAndUsername, List<NameSearchResult>> _getTagNames;
        private readonly ICommandHandler<DeleteTagCommand> _deleteTag;
        private readonly IProjectionHandler<int, IList<MomentoPerson>> _retreiveTagsByMomentoId;
        private readonly ICommandHandler<CreateTagCommand> _createTag;

        /// <summary>
        /// Initializes a new instance of the <see cref="TagsController"/> class.
        /// </summary>
        /// <param name="processor">The processor.</param>
        /// <param name="commandProcessor">The command processor.</param>
        /// <param name="getTagNames"></param>
        /// <param name="deleteTag"></param>
        /// <param name="retreiveTagsByMomentoId"></param>
        public TagsController(IProjectionHandler<NameAndUsername, List<NameSearchResult>> getTagNames,
                              ICommandHandler<DeleteTagCommand> deleteTag, 
                              IProjectionHandler<int, IList<MomentoPerson>> retreiveTagsByMomentoId,
            ICommandHandler<CreateTagCommand> createTag
                              )
        {
            _getTagNames = getTagNames;
            _deleteTag = deleteTag;
            _retreiveTagsByMomentoId = retreiveTagsByMomentoId;
            _createTag = createTag;
        }

        /// <summary>
        /// Deletes the specified momento id.
        /// </summary>
        /// <param name="momentoId">The momento id.</param>
        /// <param name="tagid">The tagid.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Delete(int momentoId, int tagid)
        {
            _deleteTag.Execute(new DeleteTagCommand(momentoId, tagid));
            return Json(new {result=true}, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Nameses the specified term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Names(string term)
        {
            var search = new NameAndUsername() { Name = term, Username = GetUsername() };
            var results = _getTagNames.Execute(search);

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Retrieves the specified momentoid.
        /// </summary>
        /// <param name="momentoid">The momentoid.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Retrieve(int momentoid)
        {
            var momentoTag = _retreiveTagsByMomentoId.Execute(momentoid);
            var ts = GetTags(momentoTag);

            var tags = new { Image = new[] { new { id = momentoid, Tags = ts } } };

            return Json(tags, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the tags.
        /// </summary>
        /// <param name="momentoTag">The momento tag.</param>
        /// <returns>List{System.Object}.</returns>
        private static List<object> GetTags(IEnumerable<MomentoPerson> momentoTag)
        {
            List<object> ts = momentoTag.Select(o => new
                {
                    id = o.Id,
                    text = o.DisplayName,
                    left = o.XAxis,
                    width = o.Width,
                    height = o.Height,
                    top = o.YAxis,
                    url = "/" + o.Username,
                    isDeleteEnable = true
                }).Cast<object>().ToList();

            return ts;
        }

        /// <summary>
        /// Adds the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Add(NewTag tag)
        {
            string username = GetUsername();
            var tags = InternalAddTag(tag, username);

            return Json(new
            {
                result = true,
                tag = tags.Single()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Internals the add tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="username">The username.</param>
        /// <returns>IEnumerable{System.Object}.</returns>
        public IEnumerable<object> InternalAddTag(NewTag tag, string username)
        {
            _createTag.Execute(new CreateTagCommand(tag.Name, tag.Left, tag.Top, tag.Width, tag.Height, username, tag.MomentoId));

          var momentoTags = _retreiveTagsByMomentoId.Execute(tag.MomentoId);
            MomentoPerson t = momentoTags.SingleOrDefault(m => m.MomentoId == tag.MomentoId && m.DisplayName == tag.Name);

            var tags = GetTags(new List<MomentoPerson> {t});
            return tags;
        }
    }
}
