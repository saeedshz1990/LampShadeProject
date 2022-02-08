using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Application.Sms
{
    public interface ISmsService
    {
        void Send(string number, string message);
    }
}
