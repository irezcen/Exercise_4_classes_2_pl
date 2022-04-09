using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Zadanie_3_klasy
{
    class Akademik
    {
        private int maksLiczbaMiejsc = 300;
        private int maksLiczbaStanowisk = 20;
        private int liczbaZajętychMiejsc = 0;
        private int liczbaZajętychStanowisk = 0;
        private List<Pracownicy> listaPracowników = new List<Pracownicy>();
        private List<Mieszkaniec> listaMieszkancow = new List<Mieszkaniec>();
        private Dictionary<string, Mieszkaniec> listaPokoi = new Dictionary<string, Mieszkaniec>();
        public Człowiek wlasciciel
        {
            get;
            set;
        }
        public int LiczbaZajętychStanowisk
        {
            get
            {
                return liczbaZajętychStanowisk;
            }
        }
        public int LiczbaZajętychMiejsc
        {
            get
            {
                return liczbaZajętychMiejsc;
            }
        }
        public string NazwaAkademika
        {
            get;
            set;
        }
        public void ZatrudnijDoAkademika(string imie, string nazwisko, string stanowisko, string pesel)
        {
            if(maksLiczbaStanowisk == liczbaZajętychStanowisk)
            {
                Console.WriteLine("Brak wolnych stanowisk");
            }
            else
            {
                liczbaZajętychStanowisk++;
                Pracownicy pracownik = new Pracownicy()
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Stanowisko = stanowisko,
                    Pesel = pesel
                };
                listaPracowników.Add(pracownik);
            }
        }
        public void ZwolnijZAkademika(string pesel)
        {
            liczbaZajętychStanowisk--;
            for(int i = 0; i<listaPracowników.Count; i++)
            {
                if(listaPracowników[i].Pesel == pesel)
                {
                    listaPracowników.RemoveAt(i);
                }
            }
        }
        public void WyświetlPracowników()
        {
            if(listaPracowników.Count == 0)
            {
                Console.WriteLine("W tym akademiku nikt nie pracuje");
            }
            for(int i = 0; i<listaPracowników.Count; i++)
            {
                Console.WriteLine(listaPracowników[i].Imie + " " + listaPracowników[i].Nazwisko + " " + 
                    listaPracowników[i].Stanowisko + " " + listaPracowników[i].Pesel);
            }
        }
        public void WprowadźDoAkademika(string imie, string nazwisko, string index, string uczelnia, string pokój, string pesel)
        {
            if(maksLiczbaMiejsc == liczbaZajętychMiejsc)
            {
                Console.WriteLine("brak wolnych miejsc");
            }
            else
            {
                liczbaZajętychMiejsc++;
                Mieszkaniec mieszkaniec = new Mieszkaniec()
                {
                    Imie = imie,
                    Nazwisko = nazwisko,
                    Index = index,
                    Uczelnia = uczelnia,
                    Pokój = pokój,
                    Pesel = pesel
                };
                listaMieszkancow.Add(mieszkaniec);
                if(listaPokoi.Count == 0)
                {
                    listaPokoi.Add(pokój, mieszkaniec);
                }
                else
                {
                    foreach (KeyValuePair<string, Mieszkaniec> kvp in listaPokoi)
                    {
                        if (kvp.Key == pokój)
                        {
                            Console.WriteLine("W tym pokoju jest już inny mieszkaniec");
                            break;
                        }
                        else
                        {
                            listaPokoi.Add(pokój, mieszkaniec);
                        }
                    }
                }               
            }
        }
        public void WyprowadźZAkademika(string pesel)
        {
            liczbaZajętychMiejsc--;
            for(int i = 0; i< listaMieszkancow.Count; i++)
            {
                if(listaMieszkancow[i].Pesel == pesel)
                {
                    listaMieszkancow.RemoveAt(i);
                }
            }
            foreach(KeyValuePair<string, Mieszkaniec> kvp in listaPokoi)
            {
                if(kvp.Value.Pesel == pesel)
                {
                    listaPokoi.Remove(kvp.Key);
                }
            }
        }
        public void WyświetlMieszkańców()
        {
            if(listaMieszkancow.Count == 0)
            {
                Console.WriteLine("W tym akademiku nikt nie mieszka");
            }
            for (int i = 0; i < listaMieszkancow.Count; i++)
            {
                Console.WriteLine(listaMieszkancow[i].Imie + " " + listaMieszkancow[i].Nazwisko + " " +
                    listaMieszkancow[i].Index + " " + listaMieszkancow[i].Uczelnia+" "+listaMieszkancow[i].Pokój+" "+listaMieszkancow[i].Pesel);
            }
        }
        public void WyświetlLIstęPokoi()
        {
            foreach(KeyValuePair<string, Mieszkaniec> kvp in listaPokoi)
            {
                Console.WriteLine(kvp.Key+" "+kvp.Value.Pesel.ToString());
            }
        }
        public void WyświetlLiczbęDostępnychmiejsc()
        {
            Console.WriteLine(ObliczLiczbęWolnychMiejsc());
        }
        public void WuświetlLiczbęDostępnychStanowisk()
        {
            Console.WriteLine(ObliczLiczbęWolnychStanowisk());
        }
        private int ObliczLiczbęWolnychMiejsc()
        {
            return (maksLiczbaMiejsc - liczbaZajętychMiejsc);
        }
        private int ObliczLiczbęWolnychStanowisk()
        {
            return (maksLiczbaStanowisk - liczbaZajętychStanowisk);
        }

    }
}
