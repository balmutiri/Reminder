using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Volo.Abp.AspNetCore.Mvc;

namespace Reminder.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
    [HttpGet]
    [Route("api/header")]
    [AllowAnonymous]
    public IResult GetHeader()
    {
        var filePath = Path.Combine("images", "rmimage.png");
        return Results.File(filePath, "image/png");
    }
}
