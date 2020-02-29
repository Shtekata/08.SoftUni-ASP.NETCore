using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public string MyMessage { get; set; }

        public int Year { get; set; }

        public IEnumerable<string> Names { get; set; }

        public string UpperMessage => MyMessage.ToUpper();
    }
}
