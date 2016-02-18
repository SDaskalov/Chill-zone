namespace ChillZone.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using ChillZone.Common;
    using ChillZone.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
