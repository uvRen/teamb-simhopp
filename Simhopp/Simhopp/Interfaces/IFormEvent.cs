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
        bool Closing { get; set; }

        void Show();
        DialogResult ShowDialog();
        void CompleteDive();
        void UpdateLeaderboard();
        void PrintEventStatus();
        void PopulateScoreInput(Score score, int judgeIndex, int diverIndex, int roundIndex);
        void LogToServer(string message);
        void RedrawContestInfo(bool highlightDivePanel = false);
        void ToggleControls(bool enable, bool hideControls = false);
        void SetClientLogin();
        void AssignJudgeAsClient(int judgeIndex);
        void Hide();
        void CloseInvoke();
    }
}
