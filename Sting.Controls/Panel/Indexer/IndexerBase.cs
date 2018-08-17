using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sting.Controls.Panel.Indexer
{
    /// <summary>
    /// パネル内のコントロールの順序を算出する機能の基底ラスです。
    /// </summary>
    public abstract class IndexerBase
    {
        /// <summary>
        /// パネル内のコントロールの順序を決定します。
        /// </summary>
        /// <param name="visibleHosts">既に表示中のコントロール(表示順)</param>
        /// <param name="hosts">全ホスト</param>
        /// <param name="controls">全コントロール</param>
        public abstract void Present(IList<VirtualElementHost> visibleHosts, ICollection<VirtualElementHost> hosts, IEnumerable<ContentBase> controls);
    }
}
