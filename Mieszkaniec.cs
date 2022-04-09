using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie_3_klasy
{
    class Mieszkaniec : Człowiek
    {
        private string index;
        private string uczelnia;
        private string pokój;
        public string Pokój
        {
            get
            {
                return pokój;
            }
            set
            {
                pokój = value;
            }
        }
        public string Uczelnia
        {
            get
            {
                return uczelnia;
            }
            set
            {
                uczelnia = value;
            }
        }
        public string Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

    }
}
