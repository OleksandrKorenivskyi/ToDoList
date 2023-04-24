using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class ConfigurationController : Controller
    {
        [HttpPost]
        public IActionResult SetDataStorageType(DataStorageType type)
        {
            Response.Cookies.Append(Constants.DataStorageCookieName, type.ToString());
            return Redirect("~/");
        }
    }
}
