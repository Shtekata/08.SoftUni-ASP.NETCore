namespace AspNetCoreTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.settingsRepository = settingsRepository;
            this.userRepository = userRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }

        public async Task DeleteUser(string userId)
        {
            var user = this.userRepository.All()
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            user.IsDeleted = true;
            user.UserName = null;
            await this.userRepository.SaveChangesAsync();
        }
    }
}
