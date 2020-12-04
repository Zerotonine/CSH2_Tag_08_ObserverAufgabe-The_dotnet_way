using System;
using System.Collections.Generic;
using System.Text;

namespace CSH2_Tag_08_ObserverAufgabe_The_dotnet_way
{
    class Katze : IObserver<Standort>
    {
        Dictionary<IObservable<Standort>, IDisposable> unsubscribers;
        string name;

        public Katze(string name)
        {
            this.name = name;
            unsubscribers = new Dictionary<IObservable<Standort>, IDisposable>();
        }

        public virtual void Subscribe(IObservable<Standort> provider)
        {
            if(!unsubscribers.ContainsKey(provider))
                unsubscribers.Add(provider, provider.Subscribe(this));
        }

        public virtual void Unsubscribe(IObservable<Standort> provider)
        {
            if (unsubscribers.ContainsKey(provider))
            {
                unsubscribers[provider].Dispose();
                unsubscribers.Remove(provider);
            }
        }
       
        public void OnCompleted()
        {
            //implementieren wir nicht
        }

        public void OnError(Exception error)
        {
            //implementieren wir nicht
        }

        public void OnNext(Standort value)
        {
            Console.WriteLine($"Katze {name}:\tFalle in Raum {value.Raum} wurde ausgelöst!");
        }
    }
}
