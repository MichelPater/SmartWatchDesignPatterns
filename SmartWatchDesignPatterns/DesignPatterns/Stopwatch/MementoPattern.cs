using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWatchDesignPatterns.DesignPatterns.Stopwatch
{
    class MementoPattern
    {

    }

    class Originator
    {
        private string _savedTime;

        public string savedTime
        {
            get { return _savedTime; }
            set { _savedTime = value; }
        }

        public Memento CreateMemento()
        {
            return (new Memento(_savedTime));
        }

        public void setMemento(Memento memento)
        {
            savedTime = memento.savedTime;
        }

    }

    class Memento
    {
        private string _savedTime;

        public Memento(string savedTime)
        {
            this._savedTime = savedTime;
        }

        public string savedTime
        {
            get { return _savedTime; }
        }
    }

    class CareTaker
    {
        private Memento _memento;

        public Memento Memento
        {
            get { return _memento; }
            set { _memento = value; }
        }
    }
}
