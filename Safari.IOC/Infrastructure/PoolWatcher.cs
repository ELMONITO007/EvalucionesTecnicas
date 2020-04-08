using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safari.Infranstructure
{
    public class PoolWatcher
    {
        private INotificationAction _action;
        public PoolWatcher() { }
        public PoolWatcher(INotificationAction notificatioAction)

        {
            _action = notificatioAction;
        }
        public INotificationAction Action

        {
            get
            {
                return Action;
            }
            set
            {
                _action = value;
            }


           
        }

        public void Notify(String message)

        {
            if (_action==null)
            {
                _action = new EventLogWritter();

            }
        }


    }
}