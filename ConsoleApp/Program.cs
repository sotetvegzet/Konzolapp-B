using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<string> szoveg = new List<string>();

            StreamReader sr = new StreamReader("nyeremenyek.txt");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            List<Jatszma> jatszmak = new List<Jatszma>();
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();

            string[] lines = File.ReadAllLines("nyeremenyek.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Jatszma jatszma_object = new Jatszma(int.Parse(values[0]), values[1], int.Parse(values[2]), int.Parse(values[3]), (values[4]));
                jatszmak.Add(jatszma_object);
            }

            foreach (var item in jatszmak)
            {
                Console.WriteLine($"{item.sorszam} {item.felhasznalo}  {item.tet} {item.szorzo} {item.nyeVve} {item.nyeremeny}");
            }

            Console.WriteLine("Enter a number:");
            string numberinput = Console.ReadLine();
            int inputToNumber = Convert.ToInt32(numberinput);
            Console.WriteLine(inputToNumber);

            foreach (var item in jatszmak)

            {
                if (inputToNumber == item.sorszam)
                {
                    Console.WriteLine($"Feladat1: {item.sorszam} {item.felhasznalo}  {item.tet} {item.szorzo} {item.nyeVve} {item.nyeremeny}");
                }

            }
            List<string> felhasznalokstr = new List<string>();
            foreach (var item in jatszmak)
            {
                if (!felhasznalokstr.Contains(item.felhasznalo))
                {
                    felhasznalokstr.Add(item.felhasznalo);
                }

            }
            foreach (var item in felhasznalokstr)
            {
                Felhasznalo felhasznalo_object = new Felhasznalo(item, jatszmak);
                felhasznalok.Add(felhasznalo_object);
            }
            int maxtet = int.MinValue;
            Felhasznalo max_ertek_user = felhasznalok[0];
            foreach (var item in felhasznalok)
            {
                if (item.sumtet > maxtet)
                {
                    maxtet = item.sumtet;
                    max_ertek_user =item;
                }
            }
            Console.WriteLine($"Felhasználó: {max_ertek_user.nev}, Tétösszege:{maxtet}");
          

            int nyertes = 0;
            foreach (var item2 in jatszmak)
            {
                if (item2.nyeVve.StartsWith("nye"))
                {
                    nyertes++;
                }
            }
            Console.WriteLine($"nyertes: {nyertes}");
      
            int min_nyeremeyn = int.MaxValue;

            Jatszma min_ertek = jatszmak[0];

            foreach (var item in jatszmak)
            {
                if (min_nyeremeyn> item.nyeremeny)
                {
                    min_nyeremeyn =item.nyeremeny;
                    min_ertek = item;
                }
            }
            Console.WriteLine($"{min_ertek.sorszam} {min_ertek.felhasznalo} tet: {min_ertek.tet} szorzo: {min_ertek.szorzo} , nyerem:{min_ertek.nyeremeny}");

  

            string a_fel = "";
            int adb = 0;
            foreach (var item in felhasznalokstr)
            {
                if (item.StartsWith("a"))
                {
                    adb++;
                    if (adb < 6)
                    {
                        a_fel += item +" ;";
                    }
                }

            }
            Console.WriteLine($"A:db: {adb}, { a_fel}, ");
           
           
            foreach (var item2 in jatszmak)
            {
                if (item2.nyeVve.StartsWith("nye"))
                {
                    Console.WriteLine($"nyertes:{item2.sorszam} {item2.felhasznalo} {item2.nyeremeny}");
                }
            }
           
        }


    }
}
