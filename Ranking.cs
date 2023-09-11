using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace Sokobox1._3
{
    class Ranking
    {
        public static void Grava(string nome, int pontos)
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamWriter Escrever = new StreamWriter(@"C:\\Temp\\Pontuação_Nivei_01.txt", true);
            Escrever.WriteLine(nome + " " + pontos);
            Escrever.Close();
            StreamReader Ler = new StreamReader(@"C:\\Temp\\Pontuação_Nivei_01.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            Escrever = new StreamWriter(@"C:\\Temp\\Pontuação_Nivei_01.txt", true);
            foreach (string a in Pontuacao)
            {
                Console.WriteLine(a);
                Escrever.WriteLine(a);
            }
            Escrever.Close();

        }//fim de Grava 

        public static void Ler(string nome, int pontos)
        {
            string x = null;
            List<string> Lista = new List<string>();
            StreamWriter Escrever = new StreamWriter(@"C:\\Temp\\test.doc", true);

            while (x != "fim")
            {
                Console.Write("Digite Nomes: ");
                x = Console.ReadLine();
                if (x != "fim")
                {
                    Lista.Add(x);
                    Escrever.WriteLine(x);
                }

            }
            StreamReader Ler = new StreamReader(@"C:\\Temp\\test.TXT");
            Console.WriteLine("Nomes da ordem de escrita: \n");
            foreach (string i in Lista)
            {
                Console.WriteLine(i);
            }

            Lista.Sort();
            Console.WriteLine("Nomes da ordem alfabetica: \n");
            foreach (string i in Lista)
            {
                Console.WriteLine(i);
            }
            Escrever.Close();
            Console.ReadKey();
        }
    }
}