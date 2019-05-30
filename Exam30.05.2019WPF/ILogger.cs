using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam30._05._2019WPF
{
    public interface ILogger
    {
        void LoginError(Exception exception);
        void LoginMessage(string text);
    }
}
