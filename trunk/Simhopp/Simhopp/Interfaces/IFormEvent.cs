using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Simhopp
{
    public interface IFormEvent
    {
        EventPresenter Presenter { get; set; }
        void SetIcon(Icon icon);
        double CurrentDiveScore { get; set; }

        void Show();
        DialogResult ShowDialog();
        void CompleteDive();
        void UpdateLeaderboard();
        void PrintEventStatus();
        void PopulateScoreInput(Score score, int judgeIndex);
        void LogToServer(string message);
        void RedrawContestInfo(bool highlightDivePanel = false);
        void EnableControls(bool enable, bool hideControls = false);
        void SetClientLogin();
    }
}
