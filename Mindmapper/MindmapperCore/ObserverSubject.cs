using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    public abstract class ObserverSubject
    {
        private List<Observer> m_Observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            m_Observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            m_Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in m_Observers)
            {
                o.Update();
            }
        }
    }
}
