using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Infranstructure
{
  public  interface INotificationAction
    {
        void ActOnNotification(string message);
    }
}
