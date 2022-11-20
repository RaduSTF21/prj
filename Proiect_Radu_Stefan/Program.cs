using Proiect_Radu_Stefan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proiect_Radu_Stefan
{
    class Program
    {
        static void Main(string[] args)
        {
            LSI A = new LSI();
            Console.WriteLine("\tJocul Spanzuratoarea");
            Console.WriteLine("Va rog sa alegeti un nivel de dificultate (e/m/h)");
            char d = new char();
            d = Convert.ToChar(Console.ReadLine());
            switch (d)
            {
                case 'e':
                    {
                        char x = new char();
                        Console.WriteLine("Ati ales dificultatea 'easy' \n La acest nivel de dificultate primiti ca informatii suplimentare :\n-Indiciu \n-Ultima litera a cuvantului \n Doriti sa continuati?(d/n)");
                        x = Convert.ToChar(Console.ReadLine());
                        switch (x)
                        {
                            case 'd':
                                {
                                    A.Easy();
                                    break;
                                }

                            case 'n':
                                {
                                    Console.WriteLine("O zi buna in continuare");
                                    break;
                                }
                        }
                        break;

                    }
                case 'm':
                    {
                        char x = new char();
                        Console.WriteLine("Ati ales dificultatea 'medium' \n La acest nivel de dificultate primiti ca informatii suplimentare :\n-Ultima litera a cuvantului \n Doriti sa continuati?(d/n)");
                        x = Convert.ToChar(Console.ReadLine());
                        switch (x)
                        {
                            case 'd':
                                {
                                    A.Med();
                                    break;
                                }

                            case 'n':
                                {
                                    Console.WriteLine("O zi buna in continuare ");
                                    break;
                                }
                        }
                        break;

                    }
                case 'h':
                    {
                        char x = new char();
                        Console.WriteLine("Ati ales dificultatea 'hard' \n La acest nivel de dificultate nu primit informatii suplimentare\n Doriti sa continuati?(d/n)");
                        x = Convert.ToChar(Console.ReadLine());
                        switch (x)
                        {
                            case 'd':
                                {
                                    A.Hard();
                                    break;
                                }

                            case 'n':
                                {
                                    Console.WriteLine("O zi buna in continuare ");
                                    break;
                                }
                        }
                        break;
                    }
            }
            Console.ReadKey();

        }





    }
}