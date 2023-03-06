using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrangeHRM
{
    internal static class DemoHelper

      
    {
        public static void Pause(int miliSecondsToPause = 3000)
        {
            Thread.Sleep(miliSecondsToPause);
        }
    }
}
