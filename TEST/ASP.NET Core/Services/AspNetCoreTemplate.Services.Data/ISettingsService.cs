namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task DeleteUser(string userId);
    }
}
