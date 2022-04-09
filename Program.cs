using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie_3_klasy
{

    class Program
    {
        static List<Akademik> akademiki = new List<Akademik>();
        static void Start()
        {
            Console.WriteLine("Witaj w bazie danych Akademków!");
            while (1 == 1)
            {
                Interfejs();
            }
        }
        static void Interfejs()
        {
            Console.WriteLine("Stwórz nowy akademik-->\"1\"");
            Console.WriteLine("Wybierz akademik-->\"2\"");
            Console.WriteLine("zamknij program-->\"koniec\"");
            MenuInterfejsu();
        }
        static Akademik WybórAkademika()
        {
            if(akademiki.Count == 0)
            {
                Console.WriteLine("Brak dostępnych akademików");
                zatwierdz();
                Interfejs();
            }
            for (int i = 0; i < akademiki.Count; i++)
            {
                Console.WriteLine(akademiki[i].NazwaAkademika + " " + akademiki[i].wlasciciel.Imie+" "+akademiki[i].wlasciciel.Nazwisko +"-->" + (i + 1));
            }
            string wybórUzytkownika = Console.ReadLine();
            Akademik akademikUzytkownika = new Akademik();
            for (int i = 0; i < akademiki.Count; i++)
            {
                if(Convert.ToInt32(wybórUzytkownika) == i + 1)
                {
                    akademikUzytkownika = akademiki[i];
                }
            }
            return akademikUzytkownika;
        }
        static void MenuInterfejsu()
        {
            string wybórUżytkownika = Console.ReadLine();
            switch (wybórUżytkownika)
            {
                case "1":
                    Console.WriteLine("podaj nazwę akademika: ");
                    TworzenieAkademika();

                    break;
                case "2":
                    Akademik akademikUzytkownika = WybórAkademika();
                    OpcjeAkademika(akademikUzytkownika);
                    break;
                case "koniec":
                    koniec();
                    break;
                default:
                    Console.WriteLine("Nieznana opcja " + wybórUżytkownika + ", spróbuj jeszcze raz");
                    MenuInterfejsu();
                    break;
                
            }
            Interfejs();
        }
        static void TworzenieAkademika()
        {
            string nazwaAkademika = Console.ReadLine();
            akademiki.Add(new Akademik()
            {
                NazwaAkademika = nazwaAkademika
            });
            Akademik aktualnyaakdemik = akademiki.Last<Akademik>();
            aktualnyaakdemik.wlasciciel = new Człowiek();
            Console.WriteLine("Podaj imię właściciela: ");
            string imie = Console.ReadLine();
            aktualnyaakdemik.wlasciciel.Imie = imie;
            Console.WriteLine("Podaj Nawisko własciciela: ");
            string nazwisko = Console.ReadLine();
            aktualnyaakdemik.wlasciciel.Nazwisko = nazwisko;
        }
        static void OpcjeAkademika(Akademik akademikUzytkownika)
        {
            Console.WriteLine("Dodaj mieszkańca-->\"1\"");
            Console.WriteLine("Dodaj pracownika-->\"2\"");
            Console.WriteLine("Usuń mieszkańca-->\"3\"");
            Console.WriteLine("Usuń pracownika-->\"4\"");
            Console.WriteLine("Wyświetl dane wszystkich mieszkańców-->\"5\"");
            Console.WriteLine("Wyświetl dane wszystkich pracowników-->\"6\"");
            Console.WriteLine("Wyświetl numery pesel mieszkańców pokoi-->\"7\"");
            Console.WriteLine("wyświetl liczbę dostępnych miejsc-->\"8\"");
            Console.WriteLine("wyświetl liczbę dsotępnych stanowisk-->\"9\"");
            Console.WriteLine("Wróć-->\"10\"");
            DziałaniaOpcjiAkademika(akademikUzytkownika);
        }
        static void DodajMieszkańca(Akademik akademikuzytkownika)
        {
            List<string> parametrydane = new List<string>();
            string[] dane =
            {
                "Imię",
                "Nazwisko",
                "Nr Indeksu",
                "Nazwa uczelni",
                "Nr pokoju",
                "Nr pesel"
            };
            for(int i = 0; i<6; i++)
            {
                Console.WriteLine(dane[i]);
                parametrydane.Add(Console.ReadLine());
            }
            akademikuzytkownika.WprowadźDoAkademika(parametrydane[0], parametrydane[1], parametrydane[2], parametrydane[3], parametrydane[4], parametrydane[5]);           
        }
        static void DodajPracownika(Akademik akademikuzytkownika)
        {
            List<string> parametrydane = new List<string>();
            string[] dane =
            {
                "Imię",
                "Nazwisko",
                "Stanowisko",
                "Nr pesel"
            };
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(dane[i]);
                parametrydane.Add(Console.ReadLine());
            }
            akademikuzytkownika.ZatrudnijDoAkademika(parametrydane[0], parametrydane[1], parametrydane[2], parametrydane[3]);
        }
        static void UsuńMieszkańca(Akademik akademikuzytkownika)
        {
            Console.WriteLine("podaja pesel:");
            akademikuzytkownika.WyprowadźZAkademika(Console.ReadLine());
        }
        static void UsuńPracownika(Akademik akademikuzytkownika)
        {
            Console.WriteLine("podaja pesel:");
            akademikuzytkownika.ZwolnijZAkademika(Console.ReadLine());
        }
        static void DziałaniaOpcjiAkademika(Akademik akademikUzytkownika)
        {
            string wybóruzytkownika = Console.ReadLine();
            switch (wybóruzytkownika)
            {
                case "1":
                    DodajMieszkańca(akademikUzytkownika);
                    break;
                case "2":
                    DodajPracownika(akademikUzytkownika);
                    break;
                case "3":
                    UsuńMieszkańca(akademikUzytkownika);
                    break;
                case "4":
                    UsuńPracownika(akademikUzytkownika);
                    break;
                case "5":
                    akademikUzytkownika.WyświetlMieszkańców();
                    break;
                case "6":
                    akademikUzytkownika.WyświetlPracowników();
                    break;
                case "7":
                    akademikUzytkownika.WyświetlLIstęPokoi();
                    break;
                case "8":
                    akademikUzytkownika.WyświetlLiczbęDostępnychmiejsc();
                    break;
                case "9":
                    akademikUzytkownika.WuświetlLiczbęDostępnychStanowisk();
                    break;
                case "10":
                    Interfejs();
                    break;
                default:
                    Console.WriteLine("Nieznana opcja " + wybóruzytkownika + ", spróbuj jeszcze raz");
                    DziałaniaOpcjiAkademika(akademikUzytkownika);
                    break;
            }
            zatwierdz();
            OpcjeAkademika(akademikUzytkownika);
        }
        static void zatwierdz()
        {
            Console.ReadKey();
        }
        static void koniec()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        static void Main(string[] args)
        {
            Start();
        }
    }
}
