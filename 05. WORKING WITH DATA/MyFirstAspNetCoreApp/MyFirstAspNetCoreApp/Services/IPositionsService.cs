using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
    public interface IPositionsService
    {
        IEnumerable<SelectListItem> GetAll();
    }

    public class PositionsService : IPositionsService
    {
        IEnumerable<SelectListItem> IPositionsService.GetAll()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value="1", Text="Junior Dev"},
                new SelectListItem {Value="2", Text="Regular Dev"},
                new SelectListItem {Value="3", Text="Junior QA"},
            };
        }
    }
}
