using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_3_klasy
{
    class Człowiek
    {
        private string imie;
        private string nazwisko;
        public string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }
        public string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                nazwisko = value;
            }
        }
        public string Pesel
        {
            get;
            set;
        }
    }
}
