using System;

class Methods {

    public static void Method1 () {
        double f = 1;
        Console.WriteLine("Įveskite teigiamą skaičių i: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i <= n; i++) {
            f *= i;
        }
        Console.WriteLine(n + "! = " + f);
    }

    


}