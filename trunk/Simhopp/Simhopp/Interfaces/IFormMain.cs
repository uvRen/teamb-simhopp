using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simhopp
{
    public interface IFormMain
    {
        ListView ListViewEvent { get;}
        ListView ListViewResult { get; }
        Dictionary<ListViewItem, bool> SearchItemSource { get; set; }
        void Hide();
        void Show();
    }
}
