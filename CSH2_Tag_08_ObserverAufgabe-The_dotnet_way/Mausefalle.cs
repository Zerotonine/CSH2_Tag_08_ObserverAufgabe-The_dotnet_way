using System;
using System.Collections.Generic;
using System.Text;

namespace CSH2_Tag_08_ObserverAufgabe_The_dotnet_way
{
    public struct Standort
    {
        private string raum;
        public Standort(string raum)
        {
            this.raum = raum;
        }

        public string Raum { get => raum;}
    }
    class Mausefalle : IObservable<Standort>
    {
        List<IObserver<Standort>> observers;
        Standort raum;

        public Mausefalle(string standort)
        {
            observers = new List<IObserver<Standort>>();
            raum = new Standort(standort);
        }

        private class Unsubscriber : IDisposable
        {
            List<IObserver<Standort>> _observers;
            IObserver<Standort> _observer;

            public Unsubscriber(List<IObserver<Standort>> observers, IObserver<Standort> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }
            public void Dispose()
            {
                if (!(_observer == null)) _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<Standort> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }

        
        public void FalleZuschnappen()
        {
            foreach(IObserver<Standort> ob in observers)
            {
                ob.OnNext(raum);
            }
        }
    }
}
