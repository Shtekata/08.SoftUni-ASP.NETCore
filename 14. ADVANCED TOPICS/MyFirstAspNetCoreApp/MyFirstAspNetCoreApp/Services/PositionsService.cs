using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
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

            //return new List<(string Value, string Text)>()
            //{
            //    ("Value=1", "Text=Junior Dev"),
            //    ("Value=2", "Text=Regular Dev"),
            //    ("Value=3", "Text=Junior QA"),
            //};

            //return new List<string>()
            //{
            //    "1",
            //    "2",
            //    "3",
            //};
        }
    }
}
