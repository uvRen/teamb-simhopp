using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Simhopp
{
    public interface IJudgeClient
    {
        void CommitScore(int judgeIndex, Score score);
    }
}
