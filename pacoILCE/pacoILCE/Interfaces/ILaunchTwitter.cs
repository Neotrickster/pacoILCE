using System;
using System.Collections.Generic;
using System.Text;

namespace pacoILCE.Interfaces
{
    interface ILaunchTwitter
    {
        bool OpenUserName(string username);

        bool OpenStatus(string statusId);
    }
}
