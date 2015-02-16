using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    interface IFormEvent
    {
        EventPresenter Presenter { get; set; }
        public int CurrentDiverIndex { get; set; }
        public int CurrentRoundIndex { get; set; }
        public int CurrentJudgeIndex { get; set; }
        public double CurrentDiveScore { get; set; }
        public List<Diver> divers { get; set; }

        public void CompleteDive();
        public void UpdateLeaderboard();
    }
}
