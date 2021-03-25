using System;
using System.IO;
using System.Collections.Generic;

namespace _2LD
{
    class Program
    {
        static void Main(string[] args)
        {
            // pointeris į failą
            var reader = new StreamReader(@Environment.CurrentDirectory + "\\Book1.csv");
            // visas reiksmes saugome į sąrašą
            List<Projektai> projektai = new List<Projektai>();
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var split = line.Split(';');
                Projektai proj = new Projektai(split[0], split[1], int.Parse(split[2]), double.Parse(split[3]), int.Parse(split[4]));
                projektai.Add(proj);
            }
            // objektu masyvo atvaizdavimas ekrane
            foreach(var item in projektai) {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", item.getProjPavadinimas(), item.getVadPavarde(), item.getZmSk(),
                item.getBiudzetas(), item.getTrukme());
            }

            Console.WriteLine();
            Console.WriteLine("1 - vidutinės visų projektų biudžeto reikšmės skaičiavimas");
            Console.WriteLine("2 - filtruoti objektus pagal pavardę ir išsaugoti faile");
            Console.WriteLine("3 - filtruoti objektus pagal pavadinimą, biudžetą, trukmę ir išsaugoti faile");
            Console.WriteLine("0 - Exit");

            int pas;
            do {
                Console.Write("Jūsų pasirinkimas: ");
                pas = int.Parse(Console.ReadLine());
                switch(pas) {
                    case 0: {
                        break;
                    }
                    case 1: {
                        double vid = Projektai.VidProjBiudzetas(projektai);
                        Console.WriteLine("Vidutinė visų projektų biudžetų reikšmė: " + vid);
                        break;
                    }
                    case 2: {
                        Console.Write("Įveskite vadovo pavardę pagal kurią norėsite filtruoti duomenis: ");
                        String vadpav = Console.ReadLine();
                        List<Projektai> proj = Projektai.Filtravimas(projektai, vadpav);
                        // saugome į failą
                        Projektai.CsvSaugojimas(proj, "pirmas"); 
                        foreach(Projektai item in proj) {
                            Console.WriteLine(item.getBiudzetas());
                        }
                        break;
                    }
                    case 3: {
                        Console.Write("Įveskite projekto pavadinimą pagal kurį norėsite filtruoti duomenis: ");
                        string ProjPavadinimas = Console.ReadLine();
                        Console.Write("Įveskite biudžetą pagal kurį norėsite filtruoti duomenis: ");
                        double biudzetas = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Įveskite trukmę pagal kurią norėsite filtruoti duomenis: ");
                        int trukme = Convert.ToInt32(Console.ReadLine());
                        List<Projektai> proj = Projektai.Filtravimas(projektai, ProjPavadinimas, biudzetas, trukme);
                        // saugome į failą
                        Projektai.CsvSaugojimas(proj, "antras"); 
                        break;
                    }
                    default: {
                        Console.WriteLine("Blogas pasirinkimas");
                        break;
                    }
                }
            } while (pas != 0);
        }
    }
}
