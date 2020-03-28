using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
    public interface IPositionsService
    {
        IEnumerable<SelectListItem> GetAll();
        //IEnumerable<string> GetAll();
    }
}
