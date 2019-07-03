using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    class Fasada
    {
        public class Logowanie
        {
            public void PodajLogin()
            {
                Console.WriteLine("Podaj login ");
                Console.ReadLine();
                Console.WriteLine("Zalogowano");
            }
            public void PodajHobby()
            {
                Console.WriteLine("Podaj hobby ");
                Console.ReadLine();
                Console.WriteLine("Zaakceptowano");
            }
        }
        public class Czat
        {
            public void WyslijWiadomosc()
            {
                Console.WriteLine("Napisz wiadomosc ");
                Console.ReadLine();
                Console.WriteLine("Wyslano wiadomosc");
            }
        }
        public class Aplikacja
        {
            Logowanie a = new Logowanie();
            Czat b = new Czat();

            public void Start()
            {
                a.PodajLogin();
                a.PodajHobby();
                b.WyslijWiadomosc();
            }
        }
        static void main1()
        {
            Aplikacja app = new Aplikacja();
            app.Start();
        }
    }
    class Fabryka
    {
        public interface Posilek
        {
            String getName();
        }
        public class Sniadanie : Posilek
        {
            public String getName()
            {
                return "Sniadanie";
            }
        }
        public class Obiad : Posilek
        {
            public String getName()
            {
                return "Obiad";
            }
        }
        public class Kolacja : Posilek
        {
            public String getName()
            {
                return "Kolacja";
            }
        }
        public interface Creator
        {
            Posilek Create(String nazwa_posilku);
        }
        public class ConcreteCreator : Creator
        {
            public Posilek Create(String nazwa_posilku)
            {
                switch (nazwa_posilku)
                {
                    case "Sniadanie":
                        return new Sniadanie();
                        break;
                    case "Obiad":
                        return new Obiad();
                        break;
                    case "Kolacja":
                        return new Kolacja();
                        break;
                }
                return null;
            }
        }
        static void main2()
        {
            Creator creator = new ConcreteCreator();
            Posilek produkt = creator.Create("Sniadanie");
            Console.WriteLine(produkt.getName());
        }
    }
    public class Strategia
    {
        public interface CenaPosilku
        {
            int Check(String posilek);
        }
        public class Rano : CenaPosilku
        {
            int cena = 0;

            public int Check(String posilek)
            {
                if (posilek == "Sniadanie") cena = 20;
                if (posilek == "Obiad") cena = 30;
                if (posilek == "Kolacja") cena = 30;
                return cena;
            }
        }
        public class Poludnie : CenaPosilku
        {
            public int Check(String posilek)
            {
                int cena = 0;
                if (posilek == "Sniadanie") cena = 30;
                if (posilek == "Obiad") cena = 20;
                if (posilek == "Kolacja") cena = 30;
                return cena;
            }
        }
        public class Wieczor : CenaPosilku
        {
            public int Check(String posilek)
            {
                int cena = 0;
                if (posilek == "Sniadanie") cena = 30;
                if (posilek == "Obiad") cena = 30;
                if (posilek == "Kolacja") cena = 20;
                return cena;
            }
        }
        public class Context
        {
            private CenaPosilku cena_posilku;
            public CenaPosilku PobierzPosilek()
            {
                return cena_posilku;
            }
            public void UstalPosilek(CenaPosilku cena_posilku)
            {
                this.cena_posilku = cena_posilku;
            }
        }
        static void main4()
        {
            Context context = new Context();
            context.UstalPosilek(new Rano());

            Console.WriteLine(context.PobierzPosilek().Check("Sniadanie"));
        }
    }
    class Pełnomocnik
    {
        interface Subject
        {
            void SprawdzHaslo(String haslo);
        }
        public class RealSubject : Subject
        {
            public void SprawdzHaslo(String haslo)
            {
                Console.WriteLine("Otrzymano 5 nowych wiadomości");
            }
        }
        public class Proxy : Subject
        {
            private RealSubject realSubject;
            public void SprawdzHaslo(String haslo)
            {
                if (haslo == "qwerty")
                {
                    Console.WriteLine("Uzyskano dostęp");
                    realSubject = new RealSubject();
                    realSubject.SprawdzHaslo(haslo);
                }
                else Console.WriteLine("Brak dostępu");

            }
        }
        static void main5()
        {
            Proxy poczta = new Proxy();
            poczta.SprawdzHaslo("qwerty");
        }
    }
    class Adapter
    {
        interface OldVersion
        {
            void wypiszKod();
        }
        public class NewVersion
        {
            public void Kod()
            {
                Console.WriteLine("Kod nowej wersji programu");
            }
        }
        public class Program : OldVersion
        {
            public void wypiszKod()
            {
                new NewVersion().Kod();
            }
        }
        static void main3()
        {
            Program program = new Program();
            program.wypiszKod();
        }
    }
}