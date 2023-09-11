using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using SOCO_BAN;

namespace Sokobox1._3
{



    public class Password
    {
        static public string Pass = null;
        #region Password

        public static void Password2()
        {

            Posicao Local = new Posicao();

            Principal.Tela.CabecalhoTela();
            Console.CursorTop = Console.WindowHeight / 2;
            Console.CursorLeft = Console.WindowWidth / 2 - 10;
            Console.Write(" Digite o Password: ");
            Pass = Console.ReadLine();
            ConsoleKeyInfo K = new ConsoleKeyInfo();

            do
            {



                //Pass = Console.ReadLine();

                switch (Pass)
                {
                    case "1C6F54E":                     // Password Mapa 2
                        Principal.Controle = 2;
                        Principal.Nivel_02(ref Local);
                        break;

                    case "75FC59":                      // Password Mapa 3
                        Principal.Controle = 3;
                        Principal.Nivel_03(ref Local);
                        break;

                    case "459F94FED":                   // Password Mapa 4
                        Principal.Controle = 4;
                        Principal.Nivel_04(ref Local);
                        break;

                    case "F1C5EF9C":                    // Password Mapa 5
                        Principal.Controle = 5;
                        Principal.Nivel_05(ref Local);
                        break;

                    case "79FF1EE9":                    // Password Mapa 6
                        Principal.Controle = 6;
                        Principal.Nivel_06(ref Local);
                        break;

                    case "FFBFF5F":                     // Password Mapa 7
                        Principal.Controle = 6;
                        Principal.Controle++;
                        Principal.Nivel_07(ref Local);
                        break;

                    default:
                        Console.WriteLine("Password Incorreto. Verifique as letras, elas devem ser MAIÚSCULAS");
                        //Thread.Sleep(4000);
                        K = Console.ReadKey();
                        Password2();
                        break;

                }// fim da switch
            } while (K.Key == ConsoleKey.Escape);// fim de while

            Principal.Avatar = Local;
        }

        #endregion
    }
}
