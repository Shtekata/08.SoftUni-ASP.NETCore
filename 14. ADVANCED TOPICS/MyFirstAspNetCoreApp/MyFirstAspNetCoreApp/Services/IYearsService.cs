using System.Collections.Generic;

namespace MyFirstAspNetCoreApp.Services
{
    public interface IYearsService
    {
        IEnumerable<int> GetLastYears(int count);
    }
}
