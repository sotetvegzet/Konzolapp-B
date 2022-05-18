using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    internal class Jatszma
    {
        //az osztály változói
        public int sorszam;
        public string felhasznalo;
        public int tet;
        public int szorzo;
        public string nyeVve;
        public int nyeremeny;


        //construktor, ami paramétereket vár és ez alapján értéket az a változóknak
        public Jatszma(int sorszam, string felhasznalo, int tet, int szorzo, string nyeVve)
        {
            this.sorszam =  sorszam;
            this.felhasznalo = felhasznalo;
            this.tet = tet;
            this.szorzo = szorzo;
            this.nyeVve = nyeVve;
            this.nyeremeny = tet * szorzo;

        }
    }
}
