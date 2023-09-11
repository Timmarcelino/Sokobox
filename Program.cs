/*
 *   Trabalho Interdisciplinar -  Sokobox 
 * 
 *   Integrantes do grupo:
 *   
 *          - Alfredo Vinícius
 *          - Deividson Barbosa
 *          - Gerlei Gandra
 *          - Giovanni Rocha
 *          - Valentim Marcelino
 * 
 *    Fonte do Console:  - LucidaSams -  Tam - 28
 */

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
using System.Media;
using Sokobox1._3;

namespace SOCO_BAN
{
    public struct Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
    }

    class Principal
    {
        public static int Controle; // Variavel Global para controle
        public static int Contador;
        public static Posicao Avatar;
        public static Posicao[] Modifica;
        public static Posicao Alteracao;
        public static Posicao Tam_Matrix;
        public static Posicao[] Metas; // Guarda onde as metas estão em cada nivel
        public static Funcoes Tela = new Funcoes();

        public static ConsoleKeyInfo KEY_EXIT = new ConsoleKeyInfo();

        public static string jogador;

        // ---------------------------------------------------------------------
        //Exemplo de Layout

        // Níveis 
        #region ----------Níveis------------

        public static int[,] Nivel_01(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;
            Tam_Matrix.Linha = x; Tam_Matrix.Coluna = y;


            int[,] Nivel_01 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_01[l, c] = 0;

            x = x / 2; y = y / 2; //exatamente o centro;

            // avatar
            Nivel_01[x, y] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);            
            Avatar.Linha = x; Avatar.Coluna = y;

            // Caixas            

            Nivel_01[(x) - 1, (y)] = 2;
            Nivel_01[(x) + 1, (y)] = 2;
            Nivel_01[(x) + 1, (y) + 1] = 2;

            // Caminho disponivel
            Nivel_01[(x), (y) + 1] = 3; Nivel_01[(x) - 1, (y) + 1] = 3; Nivel_01[(x) + 1, (y) - 1] = 3; Nivel_01[(x) + 1, (y) + 2] = 3; Nivel_01[(x) + 2, (y) - 1] = 3; Nivel_01[(x) + 2, (y)] = 3; Nivel_01[(x) + 2, (y) + 1] = 3; Nivel_01[(x) + 3, (y) - 1] = 3; Nivel_01[(x) + 3, (y)] = 3;

            // Meta
            Metas = new Posicao[3]; // vetor que guarda as posições das metas            

            Nivel_01[(x) - 2, (y) - 1] = 4;
            Metas[0].Linha = Avatar.Linha - 2; Metas[0].Coluna = Avatar.Coluna - 1; //armazena a posição da Meta;

            Nivel_01[(x) - 2, (y)] = 4;
            Metas[1].Linha = Avatar.Linha - 2; Metas[1].Coluna = Avatar.Coluna; //armazena a posição da Meta;

            Nivel_01[(x) - 2, (y) + 1] = 4;
            Metas[2].Linha = Avatar.Linha - 2; Metas[2].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;


            return Nivel_01;
        }// ---------------------------------------------------------------------  

        public static int[,] Nivel_02(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_02 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_02[l, c] = 0;

            // avatar
            Nivel_02[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_02[Avatar.Linha, Avatar.Coluna + 2] = 2;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna + 2] = 2;
            // Caminho disponivel
            Nivel_02[Avatar.Linha, Avatar.Coluna - 1] = 3;
            Nivel_02[Avatar.Linha, Avatar.Coluna + 1] = 3;
            Nivel_02[Avatar.Linha + 1, Avatar.Coluna - 1] = 3;
            Nivel_02[Avatar.Linha + 2, Avatar.Coluna - 1] = 3;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna - 1] = 3;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna] = 3;
            Nivel_02[Avatar.Linha + 1, Avatar.Coluna + 1] = 3;
            Nivel_02[Avatar.Linha + 2, Avatar.Coluna + 1] = 3;
            Nivel_02[Avatar.Linha + 1, Avatar.Coluna + 3] = 3;
            Nivel_02[Avatar.Linha + 2, Avatar.Coluna + 3] = 3;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna + 3] = 3;
            Nivel_02[Avatar.Linha, Avatar.Coluna + 4] = 3;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna + 4] = 3;
            Nivel_02[Avatar.Linha, Avatar.Coluna + 5] = 3;
            Nivel_02[Avatar.Linha + 1, Avatar.Coluna + 5] = 3;
            Nivel_02[Avatar.Linha + 2, Avatar.Coluna + 5] = 3;
            Nivel_02[Avatar.Linha + 3, Avatar.Coluna + 5] = 3;
            // Meta

            Metas = new Posicao[2]; // vetor que guarda as posições das metas 

            Nivel_02[Avatar.Linha, Avatar.Coluna + 3] = 4;
            Metas[0].Linha = Avatar.Linha; Metas[0].Coluna = Avatar.Coluna + 3;//armazena a posição da Meta;

            Nivel_02[Avatar.Linha + 3, Avatar.Coluna + 1] = 4;
            Metas[1].Linha = Avatar.Linha + 3; Metas[1].Coluna = Avatar.Coluna + 1;//armazena a posição da Meta;


            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;

            return Nivel_02;

        }// --------------------------------------------------------------------

        public static int[,] Nivel_03(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_03 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_03[l, c] = 0;

            // avatar
            Nivel_03[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_03[Avatar.Linha - 1, Avatar.Coluna] = 2;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 2] = 2;
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna + 3] = 2;
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna + 4] = 2;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 5] = 2;
            // Caminho disponivel
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna + 3] = 3;
            Nivel_03[Avatar.Linha, Avatar.Coluna - 1] = 3;
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna - 1] = 3;
            Nivel_03[Avatar.Linha - 2, Avatar.Coluna] = 3;
            Nivel_03[Avatar.Linha - 2, Avatar.Coluna + 1] = 3;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 1] = 3;
            Nivel_03[Avatar.Linha - 2, Avatar.Coluna + 2] = 3;
            Nivel_03[Avatar.Linha - 2, Avatar.Coluna + 3] = 3;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 3] = 3;
            Nivel_03[Avatar.Linha + 2, Avatar.Coluna + 3] = 3;
            Nivel_03[Avatar.Linha - 2, Avatar.Coluna + 4] = 3;
            Nivel_03[Avatar.Linha - 1, Avatar.Coluna + 4] = 3;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 4] = 3;
            Nivel_03[Avatar.Linha + 2, Avatar.Coluna + 4] = 3;
            Nivel_03[Avatar.Linha - 1, Avatar.Coluna + 5] = 3;
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna + 5] = 3;
            Nivel_03[Avatar.Linha + 2, Avatar.Coluna + 5] = 3;
            Nivel_03[Avatar.Linha - 1, Avatar.Coluna + 6] = 3;
            Nivel_03[Avatar.Linha, Avatar.Coluna + 6] = 3;
            // Meta
            Metas = new Posicao[4];
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna] = 4;
            Metas[0].Linha = Avatar.Linha + 1; Metas[0].Coluna = Avatar.Coluna; //armazena a posição da Meta;
            Nivel_03[Avatar.Linha + 2, Avatar.Coluna] = 4;
            Metas[1].Linha = Avatar.Linha + 2; Metas[1].Coluna = Avatar.Coluna; //armazena a posição da Meta;
            Nivel_03[Avatar.Linha + 1, Avatar.Coluna + 1] = 4;
            Metas[2].Linha = Avatar.Linha + 1; Metas[2].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;
            Nivel_03[Avatar.Linha + 2, Avatar.Coluna + 1] = 4;
            Metas[3].Linha = Avatar.Linha + 2; Metas[3].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;

            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;
            return Nivel_03;

        }// --------------------------------------------------------------------

        public static int[,] Nivel_04(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_04 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_04[l, c] = 0;

            // avatar
            Nivel_04[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_04[Avatar.Linha, Avatar.Coluna + 2] = 2;
            Nivel_04[Avatar.Linha - 4, Avatar.Coluna + 1] = 2;
            Nivel_04[Avatar.Linha - 2, Avatar.Coluna + 1] = 2;
            // Caminho disponivel
            Nivel_04[Avatar.Linha - 4, Avatar.Coluna - 1] = 3;
            Nivel_04[Avatar.Linha - 3, Avatar.Coluna - 1] = 3;
            Nivel_04[Avatar.Linha - 2, Avatar.Coluna - 1] = 3;
            Nivel_04[Avatar.Linha - 1, Avatar.Coluna - 1] = 3;
            Nivel_04[Avatar.Linha, Avatar.Coluna - 1] = 3;
            Nivel_04[Avatar.Linha - 4, Avatar.Coluna] = 3;
            Nivel_04[Avatar.Linha - 2, Avatar.Coluna] = 3;
            Nivel_04[Avatar.Linha - 3, Avatar.Coluna + 1] = 3;
            Nivel_04[Avatar.Linha - 1, Avatar.Coluna + 1] = 3;
            Nivel_04[Avatar.Linha - 2, Avatar.Coluna + 2] = 3;
            Nivel_04[Avatar.Linha - 4, Avatar.Coluna + 3] = 3;
            Nivel_04[Avatar.Linha - 3, Avatar.Coluna + 3] = 3;
            Nivel_04[Avatar.Linha - 2, Avatar.Coluna + 3] = 3;
            Nivel_04[Avatar.Linha, Avatar.Coluna + 3] = 3;
            // Meta
            Metas = new Posicao[3];
            Nivel_04[Avatar.Linha, Avatar.Coluna + 1] = 4;
            Metas[0].Linha = Avatar.Linha; Metas[0].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;
            Nivel_04[Avatar.Linha - 4, Avatar.Coluna + 2] = 4;
            Metas[1].Linha = Avatar.Linha - 4; Metas[1].Coluna = Avatar.Coluna + 2; //armazena a posição da Meta;
            Nivel_04[Avatar.Linha - 1, Avatar.Coluna + 3] = 4;
            Metas[2].Linha = Avatar.Linha - 1; Metas[2].Coluna = Avatar.Coluna + 3; //armazena a posição da Meta;

            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;
            return Nivel_04;

        }// --------------------------------------------------------------------

        public static int[,] Nivel_05(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_05 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_05[l, c] = 0;

            // avatar
            Nivel_05[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_05[Avatar.Linha - 2, Avatar.Coluna] = 2;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna] = 2;
            Nivel_05[Avatar.Linha - 4, Avatar.Coluna] = 2;
            // Caminho disponivel
            Nivel_05[Avatar.Linha - 5, Avatar.Coluna - 4] = 3;
            Nivel_05[Avatar.Linha - 4, Avatar.Coluna - 4] = 3;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna - 4] = 3;
            Nivel_05[Avatar.Linha - 2, Avatar.Coluna - 4] = 3;
            Nivel_05[Avatar.Linha - 1, Avatar.Coluna - 4] = 3;
            Nivel_05[Avatar.Linha - 5, Avatar.Coluna - 3] = 3;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna - 3] = 3;
            Nivel_05[Avatar.Linha - 1, Avatar.Coluna - 3] = 3;
            Nivel_05[Avatar.Linha - 1, Avatar.Coluna - 2] = 3;
            Nivel_05[Avatar.Linha - 2, Avatar.Coluna - 2] = 3;
            Nivel_05[Avatar.Linha - 4, Avatar.Coluna - 2] = 3;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna - 2] = 3;
            Nivel_05[Avatar.Linha - 5, Avatar.Coluna - 2] = 3;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna - 1] = 3;
            Nivel_05[Avatar.Linha - 5, Avatar.Coluna] = 3;
            Nivel_05[Avatar.Linha - 1, Avatar.Coluna] = 3;
            Nivel_05[Avatar.Linha - 5, Avatar.Coluna + 1] = 3;
            Nivel_05[Avatar.Linha - 1, Avatar.Coluna + 1] = 3;
            Nivel_05[Avatar.Linha, Avatar.Coluna + 1] = 3;
            // Meta
            Metas = new Posicao[3];
            Nivel_05[Avatar.Linha - 2, Avatar.Coluna + 1] = 4;
            Metas[0].Linha = Avatar.Linha - 2; Metas[0].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;
            Nivel_05[Avatar.Linha - 3, Avatar.Coluna + 1] = 4;
            Metas[1].Linha = Avatar.Linha - 3; Metas[1].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;
            Nivel_05[Avatar.Linha - 4, Avatar.Coluna + 1] = 4;
            Metas[2].Linha = Avatar.Linha - 4; Metas[2].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;

            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;
            return Nivel_05;

        }// --------------------------------------------------------------------

        public static int[,] Nivel_06(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_06 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_06[l, c] = 0;

            // avatar
            Nivel_06[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna + 1] = 2;
            Nivel_06[Avatar.Linha - 1, Avatar.Coluna - 2] = 2;
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna - 3] = 2;
            // Caminho disponivel
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna - 4] = 3;
            Nivel_06[Avatar.Linha - 1, Avatar.Coluna - 4] = 3;
            Nivel_06[Avatar.Linha, Avatar.Coluna - 4] = 3;
            Nivel_06[Avatar.Linha - 3, Avatar.Coluna - 3] = 3;
            Nivel_06[Avatar.Linha - 3, Avatar.Coluna - 2] = 3;
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna - 2] = 3;
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna - 1] = 3;
            Nivel_06[Avatar.Linha + 1, Avatar.Coluna - 1] = 3;
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna] = 3;
            Nivel_06[Avatar.Linha - 1, Avatar.Coluna] = 3;
            Nivel_06[Avatar.Linha + 1, Avatar.Coluna] = 3;
            Nivel_06[Avatar.Linha, Avatar.Coluna + 1] = 3;
            Nivel_06[Avatar.Linha + 1, Avatar.Coluna + 1] = 3;
            Nivel_06[Avatar.Linha, Avatar.Coluna + 2] = 3;
            Nivel_06[Avatar.Linha - 1, Avatar.Coluna + 2] = 3;
            Nivel_06[Avatar.Linha - 2, Avatar.Coluna + 2] = 3;
            // Meta
            Metas = new Posicao[3];
            Nivel_06[Avatar.Linha, Avatar.Coluna - 3] = 4;
            Metas[0].Linha = Avatar.Linha; Metas[0].Coluna = Avatar.Coluna - 3; //armazena a posição da Meta;
            Nivel_06[Avatar.Linha, Avatar.Coluna - 2] = 4;
            Metas[1].Linha = Avatar.Linha; Metas[1].Coluna = Avatar.Coluna - 2; //armazena a posição da Meta;
            Nivel_06[Avatar.Linha, Avatar.Coluna - 1] = 4;
            Metas[2].Linha = Avatar.Linha; Metas[2].Coluna = Avatar.Coluna - 1; //armazena a posição da Meta;

            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;
            return Nivel_06;

        }// --------------------------------------------------------------------

        public static int[,] Nivel_07(ref Posicao Avatar)
        {
            int x, y;

            x = Convert.ToInt32(Console.BufferWidth / 3.5);
            y = x + 13;

            int[,] Nivel_07 = new int[x, y];
            for (int l = 0; l < x; l++) // zerar todas as posições (PAREDES)
                for (int c = 0; c < y; c++)
                    Nivel_07[l, c] = 0;

            // avatar
            Nivel_07[(x / 2), (y / 2)] = 1; // posicão inicial do avatar (tem que ser o centro da matriz);
            Avatar.Linha = (x / 2); Avatar.Coluna = (y / 2);
            // Caixas
            Nivel_07[Avatar.Linha - 1, Avatar.Coluna] = 2;
            Nivel_07[Avatar.Linha - 2, Avatar.Coluna] = 2;
            Nivel_07[Avatar.Linha - 1, Avatar.Coluna - 1] = 2;
            // Caminho disponivel
            Nivel_07[Avatar.Linha - 3, Avatar.Coluna - 3] = 3;
            Nivel_07[Avatar.Linha - 4, Avatar.Coluna - 2] = 3;
            Nivel_07[Avatar.Linha - 3, Avatar.Coluna - 2] = 3;
            Nivel_07[Avatar.Linha - 2, Avatar.Coluna - 2] = 3;
            Nivel_07[Avatar.Linha - 1, Avatar.Coluna - 2] = 3;
            Nivel_07[Avatar.Linha, Avatar.Coluna - 2] = 3;
            Nivel_07[Avatar.Linha - 2, Avatar.Coluna - 1] = 3;
            Nivel_07[Avatar.Linha - 3, Avatar.Coluna - 1] = 3;
            Nivel_07[Avatar.Linha, Avatar.Coluna - 1] = 3;
            Nivel_07[Avatar.Linha - 4, Avatar.Coluna] = 3;
            Nivel_07[Avatar.Linha - 2, Avatar.Coluna + 1] = 3;
            Nivel_07[Avatar.Linha - 3, Avatar.Coluna + 1] = 3;
            // Meta
            Metas = new Posicao[3];
            Nivel_07[Avatar.Linha - 4, Avatar.Coluna + 1] = 4;
            Metas[0].Linha = Avatar.Linha - 4; Metas[0].Coluna = Avatar.Coluna + 1; //armazena a posição da Meta;
            Nivel_07[Avatar.Linha - 4, Avatar.Coluna - 1] = 4;
            Metas[1].Linha = Avatar.Linha - 4; Metas[1].Coluna = Avatar.Coluna - 1; //armazena a posição da Meta;
            Nivel_07[Avatar.Linha - 4, Avatar.Coluna - 3] = 4;
            Metas[2].Linha = Avatar.Linha - 4; Metas[2].Coluna = Avatar.Coluna - 3; //armazena a posição da Meta;

            Tam_Matrix.Linha = x;
            Tam_Matrix.Coluna = y;
            return Nivel_07;

        }// --------------------------------------------------------------------

        #endregion

        // Movimentos do jogo

        // Move's

        #region Move's
        static int[,] Move(int[,] Game_Atual, ConsoleKeyInfo Play_atual)
        {
            SoundPlayer Move = new SoundPlayer(@"C:\\Program Files\\SokoboxTI\\Sound\MovimentoCaixa03.wav");
            Move.Play();

            ConsoleKeyInfo Mov = new ConsoleKeyInfo();
            Mov = Play_atual;

            //Contador = 0; // escolher outro local para o contador            

            if (Mov.Key == ConsoleKey.UpArrow)
            {
                Move_Up(Game_Atual, Avatar);
                Print_Matriz(Game_Atual);


            }
            else if (Mov.Key == ConsoleKey.DownArrow)
            {
                Move_Down(Game_Atual, Avatar);
                Print_Matriz(Game_Atual);

            }
            else if (Mov.Key == ConsoleKey.RightArrow)
            {
                Move_Right(Game_Atual, Avatar);
                Print_Matriz(Game_Atual);
                //       Mov = Console.ReadKey();
            }
            else if (Mov.Key == ConsoleKey.LeftArrow)
            {
                Move_Left(Game_Atual, Avatar);
                Print_Matriz(Game_Atual);
                //         Mov = Console.ReadKey();
            }

            Contador++;
            return Game_Atual;
        }

        //-------------------------------------------------------------------------------------------------------------
        // função do movimento para cima
        static void Move_Up(int[,] Game_Atual, Posicao avatar)
        {
            int Dv = -1; // UP (Direção vertical do movimento)
            int Dh = 0; // (Direção Horizontal do movimento)

            Avatar = avatar; // Atualiza o Avatar

            Modifica = new Posicao[4]; Alteracao = new Posicao();// reset na armazenagem
            int v = 0; // posição do vetor de armazenagem de alterações

            int x = Avatar.Linha; int y = Avatar.Coluna;// simplificando             

            int x1 = x + Dv; int y1 = y + Dh; // simplificando             
            int Next = Game_Atual[x1, y1]; // valor da proxima casa

            int x2 = x + (Dv * 2); int y2 = y + (Dh * 2);// simplicando
            int Next_Next = Game_Atual[x2, y2]; ; // valor da proxima casa depois da proxima casa

            int x3 = Avatar.Linha + ((Dv * 6) / 2); int x4 = Avatar.Coluna + ((Dh * 6) / 2);
            int Next_Next_Next = Game_Atual[Avatar.Linha + ((Dv * 6) / 2), Avatar.Coluna + ((Dh * 6) / 2)]; ; // valor da proxima casa depois da proxima casa depois da proxima casa

            switch (Next)
            {
                #region 0
                case 0: //(Parede)
                    // nda a fazer
                    break;
                #endregion

                #region 2
                case 2: //(Caixa)
                    switch (Next_Next)
                    {
                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)

                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5

                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;

                        #endregion
                    }
                    break;
                #endregion

                #region 3
                case 3://(Disponivel)                                                                          

                    Game_Atual[x1, y1] = 1; // proxima posição = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar

                    break;
                #endregion

                #region 4
                case 4://(Meta)

                    Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                    break;
                #endregion

                #region 5
                case 5://(Meta com Caixa)
                    switch (Next_Next)
                    {

                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)
                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5
                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;
                        #endregion
                    }
                    break;
                #endregion
            }
        }// fim da função UP

        //-------------------------------------------------------------------------------------------------------------
        // função do movimento para Baixo
        static void Move_Down(int[,] Game_Atual, Posicao avatar)
        {
            int Dv = +1; // DOWN (Direção vertical do movimento)
            int Dh = 0; // (Direção Horizontal do movimento)

            Avatar = avatar; // Atualiza o Avatar

            Modifica = new Posicao[4]; Alteracao = new Posicao();// reset na armazenagem
            int v = 0; // posição do vetor de armazenagem de alterações

            int x = Avatar.Linha; int y = Avatar.Coluna;// simplificando             

            int x1 = x + Dv; int y1 = y + Dh; // simplificando             
            int Next = Game_Atual[x1, y1]; // valor da proxima casa

            int x2 = x + (Dv * 2); int y2 = y + (Dh * 2);// simplicando
            int Next_Next = Game_Atual[x2, y2]; ; // valor da proxima casa depois da proxima casa

            int x3 = Avatar.Linha + ((Dv * 6) / 2); int x4 = Avatar.Coluna + ((Dh * 6) / 2);
            int Next_Next_Next = Game_Atual[Avatar.Linha + ((Dv * 6) / 2), Avatar.Coluna + ((Dh * 6) / 2)]; ; // valor da proxima casa depois da proxima casa depois da proxima casa

            switch (Next)
            {
                #region 0
                case 0: //(Parede)
                    // nda a fazer
                    break;
                #endregion

                #region 2
                case 2: //(Caixa)
                    switch (Next_Next)
                    {
                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)

                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5

                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;

                        #endregion
                    }
                    break;
                #endregion

                #region 3
                case 3://(Disponivel)                                                                          

                    Game_Atual[x1, y1] = 1; // proxima posição = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }

                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar

                    break;
                #endregion

                #region 4
                case 4://(Meta)

                    Game_Atual[x1, y1] = 1; // proxima posicao = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                    break;
                #endregion

                #region 5
                case 5://(Meta com Caixa)
                    switch (Next_Next)
                    {

                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)
                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5
                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;
                        #endregion
                    }
                    break;
                #endregion
            }
        }// fim da função DOWN

        //-------------------------------------------------------------------------------------------------------------
        // Função do movimento para direita - Right
        static void Move_Right(int[,] Game_Atual, Posicao avatar)
        {
            int Dv = 0; //(Direção vertical do movimento)
            int Dh = 1; // RIGHT(Direção Horizontal do movimento)

            Avatar = avatar; // Atualiza o Avatar

            Modifica = new Posicao[4]; Alteracao = new Posicao();// reset na armazenagem
            int v = 0; // posição do vetor de armazenagem de alterações

            int x = Avatar.Linha; int y = Avatar.Coluna;// simplificando             

            int x1 = x + Dv; int y1 = y + Dh; // simplificando             
            int Next = Game_Atual[x1, y1]; // valor da proxima casa

            int x2 = x + (Dv * 2); int y2 = y + (Dh * 2);// simplicando
            int Next_Next = Game_Atual[x2, y2]; ; // valor da proxima casa depois da proxima casa

            int x3 = Avatar.Linha + ((Dv * 6) / 2); int x4 = Avatar.Coluna + ((Dh * 6) / 2);
            int Next_Next_Next = Game_Atual[Avatar.Linha + ((Dv * 6) / 2), Avatar.Coluna + ((Dh * 6) / 2)]; ; // valor da proxima casa depois da proxima casa depois da proxima casa

            switch (Next)
            {
                #region 0
                case 0: //(Parede)
                    // nda a fazer
                    break;
                #endregion

                #region 2
                case 2: //(Caixa)
                    switch (Next_Next)
                    {
                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)
                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 


                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                {
                                    Game_Atual[x, y] = 3;
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                                }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5

                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;

                        #endregion
                    }
                    break;
                #endregion

                #region 3
                case 3://(Disponivel)                                                                          

                    Game_Atual[x1, y1] = 1; // proxima posição = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar

                    break;
                #endregion

                #region 4
                case 4://(Meta)

                    Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                    break;
                #endregion

                #region 5
                case 5://(Meta com Caixa)
                    switch (Next_Next)
                    {

                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)
                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5
                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;
                        #endregion
                    }
                    break;
                #endregion
            }
        } // fim da função Right

        //-------------------------------------------------------------------------------------------------------------
        // função do movimento para esquerda - Left
        static void Move_Left(int[,] Game_Atual, Posicao avatar)
        {
            int Dv = 0; // (Direção vertical do movimento)
            int Dh = -1; // LEFT (Direção Horizontal do movimento)

            Avatar = avatar; // Atualiza o Avatar

            Modifica = new Posicao[4]; Alteracao = new Posicao();// reset na armazenagem
            int v = 0; // posição do vetor de armazenagem de alterações

            int x = Avatar.Linha; int y = Avatar.Coluna;// simplificando             

            int x1 = x + Dv; int y1 = y + Dh; // simplificando             
            int Next = Game_Atual[x1, y1]; // valor da proxima casa

            int x2 = x + (Dv * 2); int y2 = y + (Dh * 2);// simplicando
            int Next_Next = Game_Atual[x2, y2]; ; // valor da proxima casa depois da proxima casa

            int x3 = Avatar.Linha + ((Dv * 6) / 2); int x4 = Avatar.Coluna + ((Dh * 6) / 2);
            int Next_Next_Next = Game_Atual[Avatar.Linha + ((Dv * 6) / 2), Avatar.Coluna + ((Dh * 6) / 2)]; ; // valor da proxima casa depois da proxima casa depois da proxima casa

            switch (Next)
            {
                #region 0
                case 0: //(Parede)
                    // nda a fazer
                    break;
                #endregion

                #region 2
                case 2: //(Caixa)
                    switch (Next_Next)
                    {
                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)

                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5

                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;

                        #endregion
                    }
                    break;
                #endregion

                #region 3
                case 3://(Disponivel)                                                                          

                    Game_Atual[x1, y1] = 1; // proxima posição = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar

                    break;
                #endregion

                #region 4
                case 4://(Meta)

                    Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                    Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                    Game_Atual[x, y] = 3;
                    for (int j = 0; j < Metas.Length; j++)
                        if (Metas[j].Linha == x)
                            if (Metas[j].Coluna == y)
                            {
                                Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                break;
                            }
                    Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                    Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                    break;
                #endregion

                #region 5
                case 5://(Meta com Caixa)
                    switch (Next_Next)
                    {

                        #region 0
                        case 0: //(Parede)
                            // nda a fazer
                            break;
                        #endregion

                        #region 2
                        case 2: //(Caixa)
                            //nda a fazer
                            break;
                        #endregion

                        #region 3
                        case 3://(Disponivel)

                            Game_Atual[x2, y2] = 2; // (setar caixa) proxima posicao da caixa = caixa                    
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;                                                       

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 4
                        case 4://(Meta)
                            Game_Atual[x2, y2] = 5; // (setar caixa) meta alcançada                   
                            Alteracao.Linha = x2; Alteracao.Coluna = y2; Modifica[v] = Alteracao;// armazena alterações;

                            Game_Atual[x1, y1] = 1; // posicao onde estava a caixa = avatar
                            Alteracao.Linha = x1; Alteracao.Coluna = y1; Modifica[v++] = Alteracao; // armazena alterações; 

                            Game_Atual[x, y] = 3;
                            for (int j = 0; j < Metas.Length; j++)
                                if (Metas[j].Linha == x)
                                    if (Metas[j].Coluna == y)
                                    {
                                        Game_Atual[x, y] = 4; // posicao onde o Avatar estava = Meta se ali fosse uma Meta
                                        break;
                                    }
                            Alteracao = Avatar; Modifica[v++] = Alteracao;// armazena alterações;

                            Avatar.Linha = x1; Avatar.Coluna = y1; // atualiza a posicao do avatar
                            break;
                        #endregion

                        #region 5
                        case 5://(Meta com Caixa)
                            // nda a fazer
                            break;
                        #endregion
                    }
                    break;
                #endregion
            }
        }// fim da função Left

        #endregion

        public static void Rankings()
        {
            Tela.CabecalhoTela();

            ConsoleKeyInfo Ver = new ConsoleKeyInfo();
            bool escolha = false;

            int centralizar = ((78 / 2) - 8);

            Tela.DesenharBotao(" <1>  Nível 1    ", 8, centralizar);
            Tela.DesenharBotao(" <2>  Nivel 2    ", 10, centralizar);
            Tela.DesenharBotao(" <3>  Nível 3    ", 12, centralizar);
            Tela.DesenharBotao(" <4>  Nível 4    ", 14, centralizar);
            Tela.DesenharBotao(" <5>  Nível 5    ", 16, centralizar);
            Tela.DesenharBotao(" <6>  Nível 6    ", 18, centralizar);
            Tela.DesenharBotao(" <7>  Nível 7    ", 20, centralizar);
            Tela.DesenharBotao("<ESC>  Voltar    ", 22, centralizar);

            do
            {
                Ver = Console.ReadKey();
                switch (Ver.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        escolha = true;
                        Rank_Page1();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        escolha = true;
                        Rank_Page2();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        escolha = true;
                        Rank_Page3();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        escolha = true;
                        Rank_Page4();
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        escolha = true;
                        Rank_Page5();
                        break;

                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        escolha = true;
                        Rank_Page6();
                        break;

                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        escolha = true;
                        Rank_Page7();
                        break;

                    case ConsoleKey.Escape:
                        Controle = 0;
                        KEY_EXIT = Ver;
                        escolha = true;
                        break;
                }
            } while (!escolha);

        }//fim de abertura.

        // Páginas de Rank 1 a 7
        #region Rank Page's

        public static void Rank_Page1()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_01.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_01.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();

            Console.ReadKey();

        }//fim de Rank Page 1

        public static void Rank_Page2()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_02.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_02.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();


            Console.ReadKey();

        }//fim de Rank Page 2

        public static void Rank_Page3()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_03.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_03.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();

            Console.ReadKey();

        }//fim de Rank Page 3

        public static void Rank_Page4()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_04.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_04.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();

            Console.ReadKey();

        }//fim de Rank Page 4

        public static void Rank_Page5()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_05.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_05.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();

            Console.ReadKey();
        }//fim de Rank Page 5

        public static void Rank_Page6()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_06.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_06.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();
            Console.ReadKey();

        }//fim de Rank Page 6

        public static void Rank_Page7()
        {
            string x = null;
            List<string> Pontuacao = new List<string>();
            StreamReader Ler = new StreamReader(@"C:\Program Files\SokoboxTI\Save\Nivel_07.txt");
            while ((x = Ler.ReadLine()) != null)
            {
                Pontuacao.Add(x);
            }
            Ler.Close();
            Pontuacao.Sort();
            StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_07.txt", false);
            Tela.CabecalhoTela();
            foreach (string a in Pontuacao)
            {
                Escrever.WriteLine(a);
                Console.WriteLine(a);
            }
            Escrever.Close();

            Console.ReadKey();
        }//fim de Rank Page 7

        #endregion

        // Abertura 

        public static void MENU()
        {

            Tela.CabecalhoTela();

            int centralizar = ((78 / 2) - 8);

            SoundPlayer Intro = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Intro.wav");
            Intro.Play();

            Tela.DesenharBotao(" <1> Iniciar Jogo ", 14, centralizar);
            Tela.DesenharBotao(" <2>  Passwords   ", 16, centralizar);
            Tela.DesenharBotao(" <3> Ver Rankings ", 18, centralizar);
            Tela.DesenharBotao("<ESC>   Sair      ", 20, centralizar);

        }

        public static void Cadastro()
        {
            Tela.CabecalhoTela();
            Tela.DesenharCampo("Digite seu Nome", Console.CursorTop = Console.WindowHeight / 2 - 3, 2, 20, 10);
            jogador = Tela.ReceberCampo(Console.CursorTop = Console.WindowHeight / 2 - 3, 20, 10, Funcoes.TipoDados.Texto);
        }

        public static void Abertura()
        {
            //int Opcao = 0;

            Tela.CabecalhoTela();
            ConsoleKeyInfo Ver = new ConsoleKeyInfo();
            bool escolha = false;
            Controle = 0;
            do
            {
                MENU();
                Ver = Console.ReadKey();
                switch (Ver.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Controle = 1;
                        escolha = true;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        //Controle = 2;
                        escolha = true;
                        Password.Password2();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        //Controle = 3;
                        escolha = true;
                        Rankings();
                        break;

                    case ConsoleKey.Escape:
                        Controle = 0;
                        KEY_EXIT = Ver;
                        escolha = true;
                        break;
                }
            } while (!escolha);

        }//fim de abertura.

        //Função configuradora de tela
        #region Config
        public static void Config()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            //Console.CursorSize = 28;
            //Console.BufferWidth = Console.LargestWindowWidth;
            Console.BufferWidth = 80;
            // Console.BufferHeight = Console.LargestWindowHeight;
            Console.BufferHeight = Console.BufferWidth * (4 / 3);
            // Console.SetWindowSize(Console.BufferWidth-1, Console.BufferHeight-1);
            return;
        }//fim de Config
        #endregion

        // ------------ Função Controladora ---------------

        private static void Ctrl_Jogabilidade(ConsoleKeyInfo K, int[,] Game, ref bool Reiniciar, ref bool Sair)
        {
            
            while (K.Key != ConsoleKey.Escape)
            {
                K = Console.ReadKey();
                Game = Move(Game, K);

                if (K.Key == ConsoleKey.F2)
                {
                    Contador = 0;
                    Reiniciar = true;
                    break;
                }
                else
                    Reiniciar = false;

                if (K.Key == ConsoleKey.Escape)
                {
                    Tela.CabecalhoTela();
                    Console.WriteLine("\t\n  Splash Screen  \n\n\n\n \t  Deseja continuar? <S/N> ");
                    K = Console.ReadKey();

                    if (K.Key == ConsoleKey.N)
                    {
                        Sair = true;
                        break;
                    }
                    else if (K.Key == ConsoleKey.S)
                    {
                        Tela.CabecalhoTela();
                        Print_Matriz(Game);
                    }
                }
                if (Nivel_Win(Game))
                {
                    break;
                }
            }
        }


        public static void Controladora()// Encaminha outras funções
        {


            Controle = 0;

            Config();
            Cadastro();
            if (jogador == "")
                jogador = "New Player";

            int[,] GAME;
            bool Nivel_win = false;
            bool Reiniciar = false;

            ConsoleKeyInfo Play;
            ConsoleKeyInfo Nivel = new ConsoleKeyInfo();

            //switch (Control)
            do
            {
                Play = new ConsoleKeyInfo();
                if (Nivel_win == false)
                    Abertura();
                Nivel_win = false;
                switch (Controle)
                {
                    case 1:
                        Contador = 0;
                        Reiniciar = false;
                        Nivel_win = false;
                        bool Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_01 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_01.wav");
                            Sound_Nivel_01.Play();
                            GAME = Nivel_01(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                Sound_Nivel_01.Stop();
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_01.txt",true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }

                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 2:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_02 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_02.wav");
                            Sound_Nivel_02.Play();
                            GAME = Nivel_02(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_02.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_02.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 3:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_03 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_03.wav");
                            Sound_Nivel_03.Play();
                            GAME = Nivel_03(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_03.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_03.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 4:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_04 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_04.wav");
                            Sound_Nivel_04.Play();
                            GAME = Nivel_04(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_04.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_04.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 5:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_05 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_05.wav");
                            Sound_Nivel_05.Play();
                            GAME = Nivel_05(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_05.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_05.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 6:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_06 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_06.wav");
                            Sound_Nivel_06.Play();
                            GAME = Nivel_06(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_06.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_06.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;
                    case 7:
                        Contador = 0;
                        Splash(Controle);
                        Reiniciar = false;
                        Nivel_win = false;
                        Sair = false;
                        do
                        {
                            SoundPlayer Sound_Nivel_07 = new SoundPlayer(@"C:\Program Files\SokoboxTI\Sound\Nivel_07.wav");
                            Sound_Nivel_07.Play();
                            GAME = Nivel_07(ref Avatar);
                            Tela.CabecalhoTela();

                            Print_Matriz(GAME);
                            Ctrl_Jogabilidade(Play, GAME, ref Reiniciar, ref Sair);

                            if (Nivel_Win(GAME))
                            {
                                Controle++;
                                Nivel_win = true;
                                StreamWriter Escrever = new StreamWriter(@"C:\Program Files\SokoboxTI\Save\Nivel_07.txt", true);
                                Escrever.WriteLine("Movimentos: " + Contador + "   " + "Nome: " + jogador);
                                Escrever.Close();
                                //  break;
                            }
                            Sound_Nivel_07.Stop();
                        } while ((Reiniciar == true || Nivel_win == false) && Sair == false);

                        break;



                    case 0:
                        //nada a ser feito (saindo da tela abertura)
                        Nivel = KEY_EXIT;
                        // Abertura();
                        break;
                }//fim de switch

                Tela.CabecalhoTela();

                // criar tela de splash (entre niveis) tipo parabens ou q pena vc foi maus (exibir passoword de cada nivel)
                // necessario apertar qualquer coisa para continuar ou esc para voltar ao menu;                
            } while (Nivel.Key != ConsoleKey.Escape);
            Abertura();

            return;
        }//fim de Controladora


        private static void Splash(int Fase)
        {
            Tela.CabecalhoTela();
            Console.CursorTop = (Console.WindowHeight / 2) - 2;

            string Senha2 = "1C6F54E";
            string Senha3 = "75FC59";
            string Senha4 = "459F94FED";
            string Senha5 = "F1C5EF9C";
            string Senha6 = "79FF1EE9";
            string Senha7 = "FFBFF5F";

            
            switch (Fase)
            {
                case 2:
                    Tela.EscreverMensagem(Senha2, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

                case 3:
                    Tela.EscreverMensagem(Senha3, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

                case 4:
                    Tela.EscreverMensagem(Senha4, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

                case 5:
                    Tela.EscreverMensagem(Senha5, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

                case 6:
                    Tela.EscreverMensagem(Senha6, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

                case 7:
                    Tela.EscreverMensagem(Senha7, Console.CursorTop, (Console.WindowWidth / 2 - 5));
                    break;

            }
            Console.CursorTop = Console.WindowHeight - 5;
            Console.CursorLeft = Console.WindowWidth - 33;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Digite <ENTER> para continuar");
            Console.ReadLine();
            Console.ResetColor();
        }


        private static bool Nivel_Win(int[,] GAME)
        {
            bool test = true;
            int i, j;
            for (i = 0; i < Tam_Matrix.Linha; i++)
            {
                for (j = 0; j < Tam_Matrix.Coluna; j++)
                {
                    if (GAME[i, j] == 2)
                    {
                        test = false;
                        break;
                    }
                }
            }
            return test;
        }

        static void Main(string[] args)
        {
            // função startScreen();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.CursorVisible = false;
            Controladora();

        }

        // -------------------------------------------------------------------------------
        // FUNÇÃO PARA IMPRIMIR A MATRIZ

        static public void Print_Matriz(int[,] M)
        {
            //Console.Clear();


            Console.CursorVisible = false;
            int L, C;

            int Altura = Tam_Matrix.Linha;
            int Largura = Tam_Matrix.Coluna;


            for (L = 0; L < Altura; L++)
            {
                for (C = 0; C < Largura; C++)
                {
                    if (C < Largura)
                        Console.CursorLeft = C + 15;

                    if (L < Altura)
                        Console.CursorTop = L + 4;

                    if (M[L, C] != 0)
                    {
                        if (M[L, C] == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            //Console.Write("{0}", M[L, C]);
                            Console.Write("{0}", (char)1);
                            Console.ResetColor();
                        }
                        else if (M[L, C] == 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else if (M[L, C] == 3)
                        {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else if (M[L, C] == 4)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            Console.ResetColor();
                        }
                        else if (M[L, C] == 5)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        Console.ResetColor();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write((char)127);
                        Console.ResetColor();
                    }

                }
                Console.WriteLine();
            }

            Print_Dados();

        }

        static public void Print_Dados()
        {
            Console.CursorTop = 4;
            Console.CursorLeft = Console.WindowWidth - 16;
            Console.Write(jogador);
            Console.CursorVisible = false;
            Console.CursorTop++;
            Console.CursorLeft = Console.WindowWidth - (16);
            Console.Write("Nivel : ");
            Console.Write(Controle);
            Console.CursorTop++;
            Console.CursorLeft = Console.WindowWidth - (16);
            Console.Write("Movimentos : ");
            Console.Write(Contador);

        }


        static public void Print(int[,] Game_Atual)
        {
            Posicao Alterada;
            // Console.CursorTop = 1; Console.CursorLeft = 1; // começa sempre no inicio

            uint cont = 0;
            for (int i = 0; i < Modifica.Length; i++)
                if (Modifica[i].Linha != 0 && Modifica[i].Coluna != 0)
                    cont++;


            int L, C;
            while (cont != 0)
            {
                Alterada = Modifica[cont];

                L = Alterada.Linha; C = Alterada.Coluna;

                if (L != 0 && C != 0)
                {
                    Console.CursorTop = L; Console.CursorLeft = C;

                    if (Game_Atual[L, C] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", Game_Atual[L, C]);
                    }
                    else if (Game_Atual[L, C] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", Game_Atual[L, C]);
                    }
                    else if (Game_Atual[L, C] == 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("{0}", Game_Atual[L, C]);
                    }
                    else if (Game_Atual[L, C] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0}", Game_Atual[L, C]);
                    }
                }

                cont--;
            }




        }
    }
}

