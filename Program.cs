using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Schumacher
{
    internal class Program
    {
        static List<Verseny> versenyek = new List<Verseny>();

        static void Main(string[] args)
        {
            string[] readSchumacher = File.ReadAllLines("schumacher.csv");

            // A ciklus indexe 1-ről indul, hogy kihagyja a fejléc sort
            for (int i = 1; i < readSchumacher.Length; i++)
            {
                string[] tagok = readSchumacher[i].Split(';');
                Verseny eredmeny = new Verseny(
                    Convert.ToDateTime(tagok[0]),
                    tagok[1],
                    Convert.ToInt32(tagok[2]),
                    Convert.ToInt32(tagok[3]),
                    Convert.ToInt32(tagok[4]),
                    tagok[5],
                    tagok[6]
                );
                versenyek.Add(eredmeny);
            }

            //  összes verseny adatai:
            /*    foreach (Verseny verseny in versenyek)
                {
                    Console.WriteLine($"Dátum: {verseny.Date}, " +
                        $"Verseny: {verseny.Grandprix}," +
                        $" Helyezés: {verseny.Position}," +
                        $" Körök: {verseny.Laps}," +
                        $" Pontszám: {verseny.Points}, " +
                        $"Csapat: {verseny.Team}," +
                        $" Státusz: {verseny.Status}");  
                }*/

            Console.WriteLine($"3. feladat: {versenyek.Count}");
            /* 4. feladat: Michyael Schumachernek hány sikeres célbaérése volt a Magyar Nagydíjon(Hungarian Grand Pris)!
            *              Az elért helyezésen kívül írja ki a nagydíj dátumát is!   */

            Console.WriteLine("4. feladat: Magyar Nagydíj helyezései");

            var magyarNagydijEredmenyek = from verseny in versenyek
                                          where verseny.Grandprix == "Hungarian Grand Prix"
                                          select new { Datum = verseny.Date, Helyezes = verseny.Position };

            // Eredmények kiírása
            foreach (var eredmeny in magyarNagydijEredmenyek)
            {

                if(eredmeny.Helyezes >0)

                Console.WriteLine($"\t{eredmeny.Datum}: {eredmeny.Helyezes}. hely: ");
            }

            /*  // Michyael Schumacher sikeres célbaéréseinek száma a Magyar Nagydíjon

               int sikeresCélbaEresek = magyarNagydijEredmenyek.Count(eredmeny => eredmeny.Helyezes > 0);

               Console.WriteLine($"Michyael Schumachernek {sikeresCélbaEresek} sikeres célbaérése volt a Magyar Nagydíjon.");  */

            /*  5. feladat:  Készítsen statisztikát a minta szerint a sikertelen célbaérések hibáinak okáról!
                             A hibák közül csak azokat jelenítse meg a képernyőn, amelyek több mint 2x fordultak elő.
                             A hibák okain kívül jelenítse meg a hibák előfordulásainak számát is.  */

            Console.WriteLine("5. feladat: Hibastatisztika");

            var hibakStatisztika = from verseny in versenyek
                                   where verseny.Position == 0
                                   group verseny by verseny.Status into hibaCsoport
                                   where hibaCsoport.Count() > 2
                                   select new { Hiba = hibaCsoport.Key, Előfordulások = hibaCsoport.Count() };

            // Statisztika kiírása
            foreach (var hibaStat in hibakStatisztika)
            {
                Console.WriteLine($" \t {hibaStat.Hiba}: {hibaStat.Előfordulások}");
            }
        } 
    }
}


/*               3. feladat: 308
                 4. feladat: Magyar Nagydíj helyezései
                        1994. 08. 14. 0:00:00: 1. hely:
                        1995. 08. 13. 0:00:00: 11. hely:
                        1996. 08. 11. 0:00:00: 9. hely:
                        1997. 08. 10. 0:00:00: 4. hely:
                        1998. 08. 16. 0:00:00: 1. hely:
                        2000. 08. 13. 0:00:00: 2. hely:
                        2001. 08. 19. 0:00:00: 1. hely:
                        2002. 08. 18. 0:00:00: 2. hely:
                        2003. 08. 24. 0:00:00: 8. hely:
                        2004. 08. 15. 0:00:00: 1. hely:
                        2005. 07. 31. 0:00:00: 2. hely:
                        2006. 08. 06. 0:00:00: 8. hely:
                        2010. 08. 01. 0:00:00: 11. hely:
                5. feladat: Hibastatisztika
                        Engine: 9
                        Spun off: 8
                        Accident: 6
                        Gearbox: 3
                        Hydraulics: 3
                        Collision: 16
                        Suspension: 3
                 Press any key to continue . . .  */

