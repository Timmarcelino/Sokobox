using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOCO_BAN
{
    class Funcoes
    {
        public int Altura = 60;
        public int Largura = 80;
        public string sCompBemVindo = "!     ";
        public int Linhas;
        public bool CancelarCampo = true;

        /* Tipos de dados digitados */
        public enum TipoDados
        {
            Texto = 0,
            Inteiro = 1,
            InteiroPositivo = 2,
            Real = 3,
            RealPositivo = 4,
            Data = 5,
            Hora = 6,
            DataHora = 7
        }

        public string Duplicar(string S, int Tamanho)
        {
            string nS = S;
            while (S.Length < Tamanho) S = S + nS;
            return S;
        }

        public void Escrever(string pLinha)
        {
            Console.CursorLeft = 0;
            Console.CursorVisible = false;
            if (pLinha.Length > Largura - 3) pLinha = pLinha.Substring(0, Largura - 3);
            pLinha = "  " + pLinha;
            Console.WriteLine(pLinha);
            Linhas++;
        }

        public string AlinharEsquerda(string S, int Tamanho)
        {
            while (S.Length < Tamanho) S = S + " ";
            return S;
        }

        public void CabecalhoTela()
        {
            Linhas = 0;
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 1;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(Duplicar(" ", 78));
            Console.ResetColor();
            Linhas++;
            Console.CursorTop++;
            Console.CursorLeft = 1;
            Console.BackgroundColor = ConsoleColor.Blue;

            string Space = null;
            for (int i = 0; i < ((78 / 2) - 10); i++)
            {
                Space = Space + " ";
            }
            Console.Write(AlinharEsquerda(Space + " SOKO BAN /  SOKO BOX ", 78));
            Console.ResetColor();
            Linhas++;
            Console.CursorTop++;
            Console.CursorLeft = 1;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(Duplicar(" ", 78));
            Console.ResetColor();
            Linhas++;
            Console.CursorTop++;
            // Escrever("");
            Console.Write("\n");
        }
        /* Cor do fundo para botão */
        public void CorBotao()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /* Cor do fundo para titulo */
        public void CorTitulo()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /* Cor do fundo para header de grid */
        public void CorHeaderGrid()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /* Cor do campo */
        public void CorCampo()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /* Desenhar botão */
        public void DesenharMenu(int Coluna, string Rotulo, string Descricao, bool IsPrimeiro)
        {
            if (!IsPrimeiro)
            {
                Console.CursorTop++;
                Console.CursorTop++;
            }
            Console.CursorLeft = Coluna;
            CorBotao();
            Console.Write(" <" + Rotulo + "> ");
            Console.ResetColor();
            Console.Write(" " + Descricao);
        }

        /* Recebe um valor digitado com um tamanho máximo indicado */
        public string ReceberCampo(int Linha, int ColunaInicio, int Tamanho, TipoDados TipoDado)
        {
            string S = "";
            int I = 0;
            bool TeclaNaoPermitida = false;
            Console.CursorTop = Linha;
            Console.CursorLeft = ColunaInicio;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Duplicar(" ", Tamanho));
            Console.CursorLeft = ColunaInicio;
            CancelarCampo = true;
            //I = ValorPadrao.Length;
            //if (I > 0)
            //{
            //    Console.Write(ValorPadrao);
            //    S = ValorPadrao;
            //    if (I == Tamanho) Console.CursorLeft--;
            //}
            Console.CursorVisible = true;
            ConsoleKeyInfo K = new ConsoleKeyInfo();
            while (I < Tamanho + 1)
            {
                CancelarCampo = false;
                TeclaNaoPermitida = false;
                K = Console.ReadKey(true);
                //Confirmação do que foi digitado 
                if ((K.Key == ConsoleKey.Enter) || (K.Key == ConsoleKey.Escape))
                {
                    I = Tamanho + 1;
                    //Cancelar com ESC  
                    if (K.Key == ConsoleKey.Escape)
                        CancelarCampo = true;
                    else
                    {
                        //Verifica tipo de dados 
                        try
                        {
                            switch (TipoDado)
                            {
                                //Números positivos 
                                case TipoDados.Inteiro:
                                case TipoDados.InteiroPositivo: S = String.Format("{0:" + Duplicar("0", Tamanho) + "}", Convert.ToInt64(S)); break;
                            }
                        }
                        catch
                        {
                            S = "";
                        }
                    }
                }
                else
                {
                    //Apagar digitação 
                    if ((K.Key == ConsoleKey.Backspace) || (K.Key == ConsoleKey.UpArrow) || (K.Key == ConsoleKey.LeftArrow))
                    {
                        if (S.Length > 0)
                        {
                            S = S.Substring(0, S.Length - 1);
                            if (S.Length < Tamanho - 1)
                            {
                                Console.CursorLeft--;
                                Console.Write(" ");
                                Console.CursorLeft--;
                            }
                            else
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    else
                    {
                        //Verifica tipos de dados 
                        switch (TipoDado)
                        {
                            case TipoDados.InteiroPositivo:
                                TeclaNaoPermitida = (((K.Key < ConsoleKey.NumPad0) || (K.Key > ConsoleKey.NumPad9)) && ((K.Key < ConsoleKey.D0) || (K.Key > ConsoleKey.D9)));
                                break;
                            default:
                                TeclaNaoPermitida = (((K.Key < ConsoleKey.NumPad0) || (K.Key > ConsoleKey.NumPad9)) && ((K.Key < ConsoleKey.D0) || (K.Key > ConsoleKey.D9)) && ((K.Key < ConsoleKey.A) || (K.Key > ConsoleKey.Z)) && (K.Key != ConsoleKey.Spacebar));
                                break;
                        }
                        if (!((S.Length == Tamanho) || TeclaNaoPermitida))
                        {
                            S = S + K.KeyChar.ToString();
                        }
                    }
                    I = S.Length;
                    Console.CursorLeft = ColunaInicio;
                    Console.Write(S);
                    if (S.Length == Tamanho) Console.CursorLeft--;
                }
            }
            Console.ResetColor();
            return S.Trim();
        }

        /* Janela com título */
        public void JanelaTitulo(string Titulo)
        {
            CabecalhoTela();
            //Titulo da janela 
            Console.CursorLeft = 2;
            CorTitulo();
            Console.Write("= " + Titulo.ToUpper().Trim() + " " + Duplicar("=", 73 - Titulo.Trim().Length));
            Console.ResetColor();
            //Dá espaço 
            Console.CursorTop++;
            Escrever("");
            Console.CursorLeft = 0;
        }

        /* Desenhar campo */
        public void DesenharCampo(string Nome, int Linha, int ColunaLabel, int ColunaCampo, int Tamanho)
        {
            Console.CursorTop = Linha;
            Console.CursorLeft = ColunaLabel;
            if (Nome.Length > 0) Console.Write(Nome + ":");
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorLeft = ColunaCampo;
            Console.Write(Duplicar(" ", Tamanho));
            Console.ResetColor();
        }

        /* Desenhar botão */
        public void DesenharBotao(string Rotulo, int Linha, int Coluna)
        {
            CorBotao();
            Console.CursorTop = Linha;
            Console.CursorLeft = Coluna;
            Console.Write(" " + Rotulo + " ");
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        /* Verifica se o campo foi digitado */
        public bool Recebeu()
        {
            bool Retorno = !CancelarCampo;
            CancelarCampo = true;
            return Retorno;
        }

        /* Função de confirmação */
        public bool Confirmar(string Pergunta, int Linha, int Coluna)
        {
            Console.CursorTop = Linha;
            Console.CursorLeft = Coluna;
            Console.WriteLine(Pergunta + "?");
            int LinhaBotao = Console.CursorTop + 1;
            DesenharBotao("<S> = Sim", LinhaBotao, Coluna);
            DesenharBotao("<N> = Nao", LinhaBotao, Coluna + 13);
            //Ler teclas 
            ConsoleKeyInfo K = Console.ReadKey(true);
            while ((K.Key != ConsoleKey.N) && (K.Key != ConsoleKey.S)) K = Console.ReadKey(true);
            if (K.Key == ConsoleKey.N)
            {
                //Apagar mensagem 
                Console.CursorTop = Linha;
                Console.CursorLeft = Coluna;
                Console.WriteLine(Duplicar(" ", Pergunta.Length + 1));
                Escrever("");
                Console.CursorLeft = Coluna;
                Console.WriteLine(Duplicar(" ", 25));
                return false;
            }
            else
                return true;
        }

        /* Escrever mensagem */
        public void EscreverMensagem(string Mensagem, int Linha, int Coluna)
        {
            Console.CursorTop = Linha;
            Console.CursorLeft = Coluna;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" " + Mensagem);
            Console.ResetColor();
        }

        /* Funcao para apagar células */
        public void Apagar(int Linha, int Coluna, int Tamanho)
        {
            Console.CursorTop = Linha;
            Console.CursorLeft = Coluna;
            Console.ResetColor();
            Console.Write(Duplicar(" ", Tamanho));
        }
    }
}

