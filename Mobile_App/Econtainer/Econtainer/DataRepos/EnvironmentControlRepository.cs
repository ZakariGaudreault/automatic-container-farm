using Econtainer.Models;

namespace Econtainer.DataRepos
{
    public class EnvironmentControlRepository : MockRepositoryBase
    {
        private List<EnvironmentControlModel> environmentControls = new List<EnvironmentControlModel>
        {
            new EnvironmentControlModel {ContainerId = 1, LightIntensity = 70, IsFanOn = true, TemperatureSetPoint = 22.0, HumiditySetPoint = 50 },
            new EnvironmentControlModel {ContainerId = 2, LightIntensity = 65, IsFanOn = false, TemperatureSetPoint = 24.0, HumiditySetPoint = 55 }
        };

        public IEnumerable<EnvironmentControlModel> GetAllControls() => environmentControls;

        public void UpdateEnvironmentControl(EnvironmentControlModel control)
        {
            var existingControl = environmentControls.FirstOrDefault(ec => ec == control);
            if (existingControl != null)
            {
                existingControl.LightIntensity = control.LightIntensity;
                existingControl.IsFanOn = control.IsFanOn;
                existingControl.TemperatureSetPoint = control.TemperatureSetPoint;
                existingControl.HumiditySetPoint = control.HumiditySetPoint;
                NotifyDataChanged();
            }
        }
    }

}
