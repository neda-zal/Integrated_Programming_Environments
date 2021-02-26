using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

class Methods {

    public static void Method1() {
        double f = 1;
        Console.WriteLine("Įveskite teigiamą skaičių i: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i <= n; i++) {
            f *= i;
        }
        Console.WriteLine(n + "! = " + f);
    }
    
    public static void Method2() {
        Console.Write("Įveskite skaičių aibės ilgį: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] aibe = new int[n];
        for(int i = 0; i < n; i++) {
            Console.Write("Įveskite " + (i + 1) + " skaičių: ");
            aibe[i] = Convert.ToInt32(Console.ReadLine());
        }
        double vidurkis;
        double tmp = 0;
        for(int i = 0; i < aibe.Length; i++) {        
            tmp += aibe[i];
        }
        vidurkis = tmp / aibe.Length;
        Console.WriteLine("Skaičių aibes vidurkis: " + vidurkis);
    }
    
    public static void Method3() {
        int count = 0;
        for(int i = 0; ; i++) {
            if(count < 5) {
              if(i % 2 != 0) {
                Console.WriteLine(i + " skaičiaus kvadratas = " + (i * i));
              } else {
                continue;
              }   
            } else {
              break;
            }
            count++;
        }
    }

    public static void Method4() {
        double x, y, z, plotas;
        Console.WriteLine("Kokios figūros plotą norėsite apskaičiuoti?");
        Console.WriteLine("1 - Stačiakampio");
        Console.WriteLine("2 - Trikampio");
        Console.WriteLine("3 - Trapecijos");
        int input = Convert.ToInt32(Console.ReadLine());
        switch(input) {
            case 1: 
                Console.Write("Įveskite stačiakampio ilgį: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Įveskite stačiakampio plotį: ");
                y = Convert.ToDouble(Console.ReadLine());
                plotas = x * y;
                Console.WriteLine("Stačiakampio plotas: " + plotas);
                break;
            
            case 2: 
                Console.Write("Įveskite trikampio ilgį: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Įveskite trikampio aukštinę: ");
                y = Convert.ToDouble(Console.ReadLine());
                plotas = (x * y) / 2;
                Console.WriteLine("Trikampio plotas: " + plotas);
                break;

            case 3:
                Console.Write("Įveskite trapecijos viršutinį pagrindą: ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Įveskite trapecijos apatinį pagrindą: ");
                y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Įveskite trapecijos aukštinę: ");
                z = Convert.ToDouble(Console.ReadLine());
                plotas = ((x + y) / 2) * z;
                Console.WriteLine("Trapecijos plotas: " + plotas);
                break;

            default: 
                Console.WriteLine("Bloga įvestis");
                break;

        } 
    }

    public static void Method5() {
        Console.Write("Įveskite simbolį: ");
        char simb = Console.ReadKey().KeyChar;
        Console.WriteLine();
        if(Char.IsNumber(simb)) {
            Console.WriteLine("Jūsų įvestas simbolis yra skaičius");
        }
        else if(Char.IsLower(simb) && Char.IsLetter(simb)) {
            Console.WriteLine("Jūsų įvestas simbolis yra mažoji raidė");
        } 
        else if(Char.IsUpper(simb) && Char.IsLetter(simb)) {
            Console.WriteLine("Jūsų įvestas simbolis yra didžioji raidė");
        } else {
            Console.WriteLine("Jūsų įvestas simbolis yra ne raidė");
        }
    }

    public static void Method6() {
        int i = 1;
        while(i < 10) {
            int j = i * i - 1;
            int k = 2 * j - 1;
            Console.WriteLine("i = " + i + " j = " + j + " k = " + k);
            i++;
        }
    }

    public static void Method7() {
        double y;
        for(double x = -2; x < 2; x += 0.5) {
            y = -2.4 * x * x + 5 * x - 3;
            Console.WriteLine("Funkcijos reikšmė, kai x yra " + x + " lygi: " + y);
        }
    }

    public static void Method8() {
        for(int i = (int)'a'; i <= (int)'z'; i++) {
            Console.WriteLine("Simbolio '{0}' skaitmeninė reikšmė: {1}", (char)i, Convert.ToInt32(i));
        }
    }

    public static void Method9() {
        Console.Write("Įveskite sveikajį skaičių: ");
        int sk = Convert.ToInt32(Console.ReadLine());
        if(sk > 1 && sk <= 3) {
            Console.WriteLine("Jūsų įvestas skaičius yra pirminis");
            return;
        } 
        if(sk <= 1) {
            Console.WriteLine("Jūsų įvestas skaičius nėra pirminis");
            return;
        }
        if(sk % 2 == 0) {
            Console.WriteLine("Jūsų įvestas skaičius nėra pirminis");
            return;
        }
        var boundary = (int)Math.Floor(Math.Sqrt(sk));
          
        for (int i = 3; i <= boundary; i += 2) {
            if (sk % i == 0) {
                Console.WriteLine("Jūsų įvestas skaičius nėra pirminis");
            }  
        }
        
        Console.WriteLine("Jūsų įvestas skaičius yra pirminis");
    }

    public static void Method10() {
        Random rand = new Random();
        int counter = 0;
        int guess = 0;
        int num = rand.Next(1, 10);
        Console.WriteLine("Spėkite skaičių nuo 1 iki 10 ");

        while(guess != num && counter < 5) {
            try {
                guess = Convert.ToInt32(Console.ReadLine());
                if (guess != num) {
                    Console.WriteLine("Neteisingas spėjimas!");
                } else {
                    counter++;
                    Console.WriteLine("Atspėjote iš " + counter + " karto, skaičius buvo: " + num );
                } 
            }
            catch {
                Console.WriteLine("Spėjimas turi būti skaičius!");
            }
            counter++;
        }
        Console.WriteLine("Žaidimas baigtas!");
    }

    public static void Method11() {
        Console.Write("Įveskite pi skaičiaus apskaičiavimo tikslumą: ");
        int tiksl = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(GetPi(tiksl));
    }

    public static double GetPi(int tiksl)
    {
        long divisor = 1;
        for(int i = 0; i < 10; i++) {
            divisor *= 10;
        }
        return (double)(16 * ArcTan1OverX(5, 10).ElementAt(tiksl)
            - 4 * ArcTan1OverX(239, 10).ElementAt(tiksl)) / divisor; 
    }
    public static IEnumerable<BigInteger> ArcTan1OverX(int x, int digits)
    {
        var mag = BigInteger.Pow(10, digits);
        var sum = BigInteger.Zero;
        bool sign = true;
        for (int i = 1; true; i += 2)
        {
            var cur = mag / (BigInteger.Pow(x, i) * i);
            if (sign) {
                sum += cur;
            } else {
                sum -= cur;
            }
            yield return sum;
            sign = !sign;
        }
    }

    public static void Method12() {
        int x, y;
        Console.Write("Įveskite pirmą skaičių: ");
        x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Įveskite antrą skaičių: ");
        y = Convert.ToInt32(Console.ReadLine());

        int Remainder;
    
        while( y != 0 )
        {
            Remainder = x % y;
            x = y;
            y = Remainder;
        }
        Console.WriteLine("Didžiausias bendras daliklis: " + x);
    }

    public static void Method13() {
        Console.Write("Įveskite skaičių ir simbolių eilutę: ");
        string eil = Console.ReadLine();

        var freq = new Dictionary<char, int>();

        foreach(var c in eil) {
            if(freq.ContainsKey(c)) {
                freq[c]++;
            } else {
                freq[c] = 1;
            }
        }
        foreach(var c in freq) {
            Console.WriteLine("Simbolis " + c.Key + " pasikartoja " + c.Value + " kartus");
        }
    }

    public static void Method14() {
        int counter = 0;
        int guess = 0;

        Console.WriteLine("Spėkite Vilniaus įkūrimo metus: ");

        while(guess != 1323 && counter < 3) {
            try {
                guess = Convert.ToInt32(Console.ReadLine());
                if (guess != 1323) {
                    Console.WriteLine("Neteisingas spėjimas!");
                } else {
                    counter++;
                    Console.WriteLine("Atspėjote iš " + counter + " karto.");
                } 
            }
            catch {
                Console.WriteLine("Spėjimas turi būti skaičius!");
            }
            counter++;
            if(counter == 3) {
                 Console.WriteLine("Neatspėjote, 1323");   
            }
        }
        Console.WriteLine("Žaidimas baigtas!");
    }


}