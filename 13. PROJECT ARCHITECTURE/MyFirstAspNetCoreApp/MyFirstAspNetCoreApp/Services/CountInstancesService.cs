namespace MyFirstAspNetCoreApp.Services
{
    public class CountInstancesService : ICountInstancesService
    {
        private static int count;
        public CountInstancesService()
        {
            count++;
        }
        public int Instaces => count;
    }
}
