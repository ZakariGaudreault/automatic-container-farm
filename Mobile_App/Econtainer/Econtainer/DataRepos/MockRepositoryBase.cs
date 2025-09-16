using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.DataRepos
{
    public abstract class MockRepositoryBase
    {
        protected void NotifyDataChanged() => DataChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler DataChanged;
    }

}
