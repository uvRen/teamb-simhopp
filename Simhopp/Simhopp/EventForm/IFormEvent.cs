using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public interface IFormEvent
    {
        EventPresenter Presenter { get; set; }
        double CurrentDiveScore { get; set; }

        void CompleteDive();
        void UpdateLeaderboard();
    }
}
