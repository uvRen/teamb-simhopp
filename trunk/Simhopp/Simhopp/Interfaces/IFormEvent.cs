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

        void Show();
        void CompleteDive();
        void UpdateLeaderboard();
        void PrintEventStatus();
        void PopulateScoreInput(Score score, int judgeIndex);
        void LogToServer(string message);
        void RedrawContestInfo();
        void EnableControls(bool enable);
    }
}
