using System;
using System.Collections;
using System.Collections.Generic;

namespace Restaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitllet5 = 5;
            int bitllet10 = 10;
            int bitllet20 = 20;
            int bitllet50 = 50;
            int bitllet100 = 100;
            int bitllet200 = 200;
            int bitllet500 = 500;

            int preuMenjar = 0;

            string[] carta = { "Macarrons", "Pizza", "Estofat", "Llenties" };
            int[] preus = { 10, 15, 20, 5 };

            Dictionary<string, int> cartaD =
                new Dictionary<string, int>();

            for (int i = 0; i < carta.Length; i++)
            {
                cartaD.Add(carta[i], preus[i]);
            }
           // MostrarCarta(cartaD);
            Console.WriteLine("Que vols menjar?");

            bool demanat = false;
            ArrayList plats = new ArrayList();

            while (!demanat)
            {
                Console.WriteLine("Introdueix un plat:");
                try
                {
                    string platString = Console.ReadLine();
                    bool notrobat = true;
                    for (int i = 0; i < carta.Length; i++)
                    {
                        if (platString == carta[i])
                        {
                            notrobat = false;
                        }
                    }
                    if (notrobat)
                    {
                        throw new System.NullReferenceException("Plat no existeix");
                    }
                    plats.Add(Console.ReadLine());
                }
                catch (System.NullReferenceException ex)
                {
                    Console.WriteLine(ex);
                }

                try
                {
                    Console.WriteLine("Vols demanar algun plat mes? (1: Si / 2: No)");
                    int contestació = Convert.ToInt32(Console.ReadLine());
                    if (contestació == 2)
                    {
                        demanat = true;
                    }
                    else if (contestació == 1)
                    {
                        demanat = false;
                    }
                    else
                    {
                        throw new System.InvalidProgramException("Opció invalida");
                    }
                }
                catch (System.InvalidProgramException ex)
                {
                    Console.WriteLine(ex);
                }
                
            }
            preuMenjar = ComprobarInformacioIPreu(carta, preus, plats);
            if (preuMenjar == 0)
            {
                Console.WriteLine("Cap plat introduit existeix");
            }
            else
            {
                Console.WriteLine("El preu total es de {0} euros", preuMenjar);
            }




        }
        static void MostrarCarta(Dictionary<string,int> cartaD)
        {
            Console.WriteLine("Carta:");
            foreach (var menjar in cartaD)
            {
                Console.WriteLine("{0] - {1} euros", menjar.Key, menjar.Value);
            }
        }
        static int ComprobarInformacioIPreu (string[] carta,int[] preus, ArrayList plats)
        {
            int preuTotal = 0;
            foreach (string plat in plats)
            {
                bool trobat = false;
                for (int i = 0; i < carta.Length; i++)
                {
                    if (carta[i].Equals(plat))
                    {
                        trobat = true;
                        preuTotal += preus[i];
                    }
                }
                if (trobat == false)
                {
                    Console.WriteLine("{0} demanat no existeix", plat);
                }
            }
            return preuTotal;
        }
    }
}
