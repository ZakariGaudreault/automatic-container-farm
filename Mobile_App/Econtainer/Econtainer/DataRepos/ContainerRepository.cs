using System;
using Econtainer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Econtainer.DataRepos
{
    public class ContainerRepository : MockRepositoryBase
    {
        private List<ContainerModel> containers = new List<ContainerModel>
        {
            new ContainerModel
            {
                Id = 1,
                Name = "Location A",
                Longitude = 204.13213,
                Latitude = -124.34245,
                Temperature = 22.5,
                Humidity = 50,
                WaterLevel = 75,
                TempHistory = new List<(DateTime Time, double Temperature)>
                {
                    (DateTime.Now.AddDays(-9), 22),
                    (DateTime.Now.AddDays(-8), 22),
                    (DateTime.Now.AddDays(-7), 22),
                    (DateTime.Now.AddDays(-6), 12),
                    (DateTime.Now.AddDays(-5), 12),
                    (DateTime.Now.AddDays(-4), 12),
                    (DateTime.Now.AddDays(-3), 12),
                    (DateTime.Now.AddDays(-2), 22),
                    (DateTime.Now.AddDays(-1), 22),
                    (DateTime.Now, 30)
                }
            },
            new ContainerModel
            {
                Id = 2,
                Name = "Location B",
                Longitude = 305.34245,
                Latitude = -124.34245,
                Temperature = 24.0,
                Humidity = 55,
                WaterLevel = 65,
                TempHistory = new List<(DateTime Time, double Temperature)>
                {
                    (DateTime.Now.AddDays(-9), 23),
                    (DateTime.Now.AddDays(-8), 24),
                    (DateTime.Now.AddDays(-7), 22),
                    (DateTime.Now.AddDays(-6), 19),
                    (DateTime.Now.AddDays(-5), 18),
                    (DateTime.Now.AddDays(-4), 15),
                    (DateTime.Now.AddDays(-3), 18),
                    (DateTime.Now.AddDays(-2), 24),
                    (DateTime.Now.AddDays(-1), 25),
                    (DateTime.Now, 30)
                }
            }
        };

        public IEnumerable<ContainerModel> GetAllContainers() => containers;

        public ContainerModel GetContainerById(int id) => containers.FirstOrDefault(c => c.Id == id);
    }
}
