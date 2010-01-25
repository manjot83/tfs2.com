using System.Web.Mvc;
using TFS.Models;

namespace TFS.Web.Mvc {
    public class TransactionalController : Controller {
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
