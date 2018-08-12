using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sting.Controls.Panel.Indexer

{
    public abstract class IndexerBase
    {
        public abstract void Present(IList<VirtualElementHost> visibleHosts, ICollection<VirtualElementHost> hosts, IEnumerable<ContentBase> controls);
    }
}
