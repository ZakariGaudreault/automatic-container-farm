using Econtainer.Models;

namespace Econtainer.DataRepos
{
    public class TrackingRepository : MockRepositoryBase
    {
        private List<TrackingModel> trackings = new List<TrackingModel>
        {
            new TrackingModel { ContainerId = "1", Latitude = 34.0522, Longitude = -118.2437 },
            new TrackingModel { ContainerId = "2", Latitude = 40.7128, Longitude = -74.0060 }
        };

        public IEnumerable<TrackingModel> GetAllTrackings() => trackings;

        public TrackingModel GetTrackingByContainerId(string containerId) => trackings.FirstOrDefault(t => t.ContainerId == containerId);
    }

}
