using Econtainer.Models;

namespace Econtainer.DataRepos
{
    public class SecurityRepository : MockRepositoryBase
    {
        private List<SecurityModel> securities = new List<SecurityModel>
        {
            new SecurityModel { ContainerId = 1, IsDoorLocked = true, HasMotionDetected = false },
            new SecurityModel { ContainerId = 2, IsDoorLocked = false, HasMotionDetected = true }
        };

        public IEnumerable<SecurityModel> GetAllSecurities() => securities;

        public SecurityModel GetSecurityByContainerId(int containerId) => securities.FirstOrDefault(s => s.ContainerId == containerId);
    }

}
