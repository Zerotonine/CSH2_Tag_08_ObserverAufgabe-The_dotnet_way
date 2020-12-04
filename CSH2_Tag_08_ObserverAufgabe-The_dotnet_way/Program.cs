using System;

namespace CSH2_Tag_08_ObserverAufgabe_The_dotnet_way
{
    class Program
    {
        static void Main(string[] args)
        {
            Mausefalle m1 = new Mausefalle("M1 - Wohnzimmer");
            Mausefalle m2 = new Mausefalle("M2 - Keller");
            Mausefalle m3 = new Mausefalle("M3 - Küche");

            Katze k1 = new Katze("K1 - Kenny");
            Katze k2 = new Katze("K2 - Rocky");

            k1.Subscribe(m1);
            k1.Subscribe(m2);
            k1.Subscribe(m3);
            k2.Subscribe(m1);
            k2.Subscribe(m2);
            k2.Subscribe(m3);

            Console.WriteLine("Alle haben alles abonniert!");
            Console.WriteLine("Alle Fallen");
            m1.FalleZuschnappen();
            m2.FalleZuschnappen();
            m3.FalleZuschnappen();

            Console.WriteLine("\nNur Falle 2 schnappt zu!");
            m2.FalleZuschnappen();
            Console.WriteLine("\nK1 - deabonniert Falle 2 & Falle 3!");
            k1.Unsubscribe(m2);
            k1.Unsubscribe(m3);

            Console.WriteLine("\nAlle Fallen Schnappen zu");
            m1.FalleZuschnappen();
            m2.FalleZuschnappen();
            m3.FalleZuschnappen();

            Console.WriteLine("\nK2 - Deabonniert Falle 1");
            k2.Unsubscribe(m1);

            Console.WriteLine("\nAlle Fallen Schnappen zu");
            m1.FalleZuschnappen();
            m2.FalleZuschnappen();
            m3.FalleZuschnappen();


            Console.ReadKey(true);
        }
    }
}
