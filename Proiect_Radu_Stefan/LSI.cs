using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Radu_Stefan
{
    public class Nod
    {
        public char info;
        public Nod leg;
        public Nod()
        {
            info = '0';
            leg = null;
        }
        public Nod(char x)
        {
            info = x;
            leg = null;
        }
    }

    public class LSI
    {
        public Nod head;
        public int n;


        ~LSI()
        {
            Clear();
        }


        public LSI()
        {
            head = null;
            n = 0;
        }

        public LSI(char x)
        {
            head = new Nod(x);
            n = 1;
        }


        public LSI(LSI A)
        {
            head = null;
            n = 0;
            for (Nod p = A.head; p != null; p = p.leg)
                AddEnd(p.info);
        }


        public void AddBegin(char x)
        {
            Nod p = new Nod(x);
            p.leg = head;
            head = p;
            n++;
        }


        public void Add(Nod p, char x)
        {
            Nod q = new Nod(x);
            q.leg = p.leg;
            p.leg = q;
            n++;
        }


        public void AddEnd(char x)
        {
            if (head == null)
            {
                AddBegin(x);
                return;
            }
            Nod p;
            for (p = head; p.leg != null; p = p.leg)
                ;
            Add(p, x);
        }


        public void EraseBegin()
        {
            if (head == null)
                return;
            Nod p = head;
            head = head.leg;
            p = null;
            n--;
        }


        public void Erase(Nod p)
        {
            Nod q = p.leg;
            p.leg = q.leg;
            q = null;
            n--;
        }


        public void Clear()
        {
            while (n > 0)
                EraseBegin();
        }


        public void Insert(int k, char x)
        {
            if (k <= 0)
            {
                AddBegin(x);
                return;
            }
            Nod p, q = head;
            for (p = head; k > 1 && p != null; p = p.leg)
            {
                q = p;
                k--;
            }
            Add(q, x);
        }

        public override string ToString()
        {
            string s = "";
            for (Nod p = head; p != null; p = p.leg)
                s += p.info + " ";
            return s;
        }

        public void AfisInvers(Nod p)
        {
            if (p != null)
            {
                AfisInvers(p.leg);
                Console.Write(p.info + " ");
            }
        }

        public int Count
        {
            get { return n; }
        }

        protected void Rezolva_e()
        {
            int ver = 0;
            LSI B = new LSI();
            int cl = n - 1;
            Nod p = head;
            string s = null;
            for (int i = 0; i < n; i++)
            {
                s += p.info;
                p = p.leg;
            }
            p = head;
            Console.Write(p.info + " ");
            B.AddEnd(p.info);
            for (int i = 1; i < n - 1; i++)
            {
                p = p.leg;
                B.AddEnd('_');
                Console.Write("_ ");
            }
            p = p.leg;
            B.AddEnd(p.info);
            char d = new char();
            int pen = 0;
            Console.Write(p.info);
            Console.WriteLine();
            char c = new char();
            while (cl > 1 && pen < 6)
            {
                Console.WriteLine("Crezi ca stii care este cuvantul?(d/n)");
                c = Convert.ToChar(Console.ReadLine());
                Nod q = head;
                Nod h = B.head;
                if (c == 'n')
                {
                    Console.WriteLine("Introduceti litera");
                    d = Convert.ToChar(Console.ReadLine());
                    Console.Write(q.info + " ");
                }
                int v = 0;
                switch (c)
                {
                    case 'n':
                        {
                            for (int i = 1; i < n; i++)
                            {
                                q = q.leg;
                                h = h.leg;
                                if (d == q.info)
                                {
                                    v = 1;
                                    cl--;
                                    h.info = q.info;
                                    Console.Write(h.info + " ");

                                }
                                else
                                    Console.Write(h.info + " ");
                            }
                            break;

                        }
                    case 'd':
                        {
                            Console.WriteLine("Introduceti cuvantul");
                            string o = null;
                            o = Convert.ToString(Console.ReadLine());
                            if (o.CompareTo(s) == 0)
                            {
                                ver = 1;
                                Console.WriteLine("Felictari, ati ghicit cuvantul!");
                                v++;
                                cl = 0;
                            }
                            else
                            {
                                pen++;
                                v++;
                                Console.WriteLine("Ghinion, n-ai ghicit, mai ai " + (6 - pen) + " incercari");
                            }
                            break;
                        }
                }


                Console.WriteLine();
                if (v == 0 && pen < 6 && (c == 'n' || c == 'd'))
                {
                    pen++;
                    Console.WriteLine("Litera nu exista in acest cuvant,mai aveti " + (6 - pen) + " incercari");
                }


                if (pen == 6 && (c == 'n' || c == 'd'))
                {
                    Console.WriteLine("Ati fost spanzurat(game over)");
                    Console.WriteLine("Cuvantul era : " + s);
                }
                if (c != 'n' && c != 'd')
                    Console.WriteLine("Optiunile sunt 'd' sau 'n' ");
            }
            if (pen < 6 && ver == 0)
                Console.WriteLine("Ati ghicit cuvantul");



        }
        protected void Rezolva_h()
        {
            int ver = 0;
            LSI B = new LSI();
            int cl = n - 1;
            Nod p = head;
            string s = null;
            for (int i = 0; i < n; i++)
            {
                s += p.info;
                p = p.leg;
            }
            p = head;
            Console.Write(p.info + " ");
            B.AddEnd(p.info);
            for (int i = 1; i < n - 1; i++)
            {
                p = p.leg;
                B.AddEnd('_');
                Console.Write("_ ");
            }
            p = p.leg;
            B.AddEnd('_');
            char d = new char();
            int pen = 0;
            Console.Write('_');
            Console.WriteLine();
            char c = new char();
            while (cl > 1 && pen < 6)
            {
                Console.WriteLine("Crezi ca stii care este cuvantul?(d/n)");
                c = Convert.ToChar(Console.ReadLine());
                Nod q = head;
                Nod h = B.head;
                if (c == 'n')
                {
                    Console.WriteLine("Introduceti litera");
                    d = Convert.ToChar(Console.ReadLine());
                    Console.Write(q.info + " ");
                }
                int v = 0;
                switch (c)
                {
                    case 'n':
                        {
                            for (int i = 1; i < n; i++)
                            {
                                q = q.leg;
                                h = h.leg;
                                if (d == q.info)
                                {
                                    v = 1;
                                    cl--;
                                    h.info = q.info;
                                    Console.Write(h.info + " ");

                                }
                                else
                                    Console.Write(h.info + " ");
                            }
                            break;

                        }
                    case 'd':
                        {
                            Console.WriteLine("Introduceti cuvantul");
                            string o = null;
                            o = Convert.ToString(Console.ReadLine());
                            if (o.CompareTo(s) == 0)
                            {
                                ver = 1;
                                Console.WriteLine("Felictari, ati ghicit cuvantul!");
                                v++;
                                cl = 0;
                            }
                            else
                            {
                                pen++;
                                v++;
                                Console.WriteLine("Ghinion,n-ai ghicit, mai ai " + (6 - pen) + " incercari");
                            }
                            break;
                        }
                }


                Console.WriteLine();
                if (v == 0 && pen < 6 && (c == 'n' || c == 'd'))
                {
                    pen++;
                    Console.WriteLine("Litera nu exista in acest cuvant, mai aveti " + (6 - pen) + " incercari");
                }


                if (pen == 6 && (c == 'n' || c == 'd'))
                {
                    Console.WriteLine("Ati fost spanzurat(game over)");
                    Console.WriteLine("Cuvantul era : " + s);
                }
                if (c != 'n' && c != 'd')
                    Console.WriteLine("Optiunile sunt 'd' sau 'n' ");
            }
            if (pen < 6 && ver == 0)
                Console.WriteLine("Ati ghicit cuvantul!");

        }

        public void Easy()
        {
            Random e = new Random();
            int x = e.Next(1, 6);
            switch (x)
            {
                case 1:
                    {
                        string s = "aptitudine";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.Write("Indiciu: contine mai putin de 5 vocale");
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;

                    }

                case 2:
                    {
                        string s = "pasare";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.Write("Indiciu: contine mai putin de  4 vocale");
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }
                case 3:
                    {
                        string s = "pasiune";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.Write("Indiciu: contine mai putin de  5 vocale");
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }
                case 4:
                    {
                        string s = "intelept";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.Write("Indiciu: contine mai putin de  3 vocale");
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }

                case 5:
                    {
                        string s = "captare";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.Write("Indiciu: contine mai putin de  3 vocale");
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();

                        break;
                    }



            }

        }
        public void Med()
        {
            Random e = new Random();
            int x = e.Next(1, 6);
            switch (x)
            {
                case 1:
                    {
                        string s = "dermatovenerologie";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();

                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;

                    }

                case 2:
                    {
                        string s = "incapabil";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }
                case 3:
                    {
                        string s = "Necooperant";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }
                case 4:
                    {
                        string s = "latifundiar";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();
                        break;
                    }

                case 5:
                    {
                        string s = "temperament";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_e();

                        break;
                    }



            }
        }

        public void Hard()
        {
            Random e = new Random();
            int x =e.Next(1, 7);
            switch (x)
            {
                case 1:
                    {
                        string s = "dermatovenerologie";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();

                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();
                        break;

                    }

                case 2:
                    {
                        string s = "incapabil";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();
                        break;
                    }
                case 3:
                    {
                        string s = "Necooperant";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();
                        break;
                    }
                case 4:
                    {
                        string s = "latifundiar";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();
                        break;
                    }

                case 5:
                    {
                        string s = "temperament";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();

                        break;
                    }
                case 6:
                    {
                        string s = "sternocleidomastoidian";
                        char[] c = new char[s.Length];
                        Nod p = new Nod();
                        p = head;
                        for (int i = 0; i < c.Length; i++)
                            c[i] = s[i];
                        Console.WriteLine();
                        for (int i = 0; i < c.Length; i++)
                        {
                            AddEnd(c[i]);
                        }
                        Rezolva_h();

                        break;
                    }


            }


        }
    }
}