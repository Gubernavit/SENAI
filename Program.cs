using System;
using System.ComponentModel.Design;

public class Jogador
{
    public string Escolha
    {
        get;
        set;
    }

    public virtual void FazerEscolha()
    {
        bool escolhendo = true;
        while (escolhendo)
        {
            Console.Write("Escolha Pedra(1), Papel(2) ou Tesoura(3): ");
            Escolha = Console.ReadLine().Trim().ToLower();

            if (Escolha == "1" || Escolha == "pedra")
            {
                Escolha = "pedra";
                escolhendo = false;
            }
            else if (Escolha == "2" || Escolha == "papel")
            {
                Escolha = "papel";
                escolhendo = false;
            }
            else if (Escolha == "3" || Escolha == "tesoura")
            {
                Escolha = "tesoura";
                escolhendo = false;
            }
            else
            {
                escolhendo = true;
            }
        }
    }
}

public class Computador : Jogador
{
    string[] Opcoes = { "pedra", "papel", "tesoura" };

    Random opcao = new Random();

    public override void FazerEscolha()
    {
        int Opcao = opcao.Next(0, 3);
        Escolha = Opcoes[Opcao];
        Console.WriteLine("Computador escolheu: " + Escolha);
    }
}

public class Jogo
{
    int PontosJogador = 0;
    int PontosComputador = 0;
    Jogador humano;
    Computador bot;

    public Jogo(Jogador j, Computador c)
    {
        humano = j;
        bot = c;
    }

    public void Vitoria()
    {
        Console.WriteLine("VOCE VENCEU esta rodada.");
        PontosJogador += 1;
    }

    public void Derrota()
    {
        Console.WriteLine("COMPUTADOR VENCEU esta rodada.");
        PontosComputador += 1;
    }

    public void Jogar()
    {
        bool JogarNovamente = true;
        int rodada = 1;
        string Opcao;
        bool escolhendo = true;

        while (JogarNovamente)
        {
            while (rodada <= 3)
            {
                Console.WriteLine("========================RODADA-" + rodada + "=========================");

                humano.FazerEscolha();
                bot.FazerEscolha();

                if (humano.Escolha == bot.Escolha)
                {
                    Console.WriteLine("Empate.");
                }
                else if (
                    (humano.Escolha == "pedra" && bot.Escolha == "tesoura") ||
                    (humano.Escolha == "papel" && bot.Escolha == "pedra") ||
                    (humano.Escolha == "tesoura" && bot.Escolha == "papel")
                )
                {
                    Vitoria();
                }
                else
                {
                    Derrota();
                }

                rodada++;

                Console.WriteLine("=========================================================");
            }

            if (PontosComputador > PontosJogador)
            {
                Console.WriteLine("Placar: C" + PontosComputador + " x J" + PontosJogador);
                Console.WriteLine("\nFim das 3 rodadas, COMPUTADOR GANHOU o jogo");
            }
            else if (PontosComputador < PontosJogador)
            {
                Console.WriteLine("Placar: J" + PontosJogador + " x C" + PontosComputador);
                Console.WriteLine("\nFim das 3 rodadas, VOCE GANHOU o Jogo");
            }
            else if (PontosComputador == PontosJogador)
            {
                Console.WriteLine("Placar: J" + PontosJogador + " x C" + PontosComputador);
                Console.WriteLine("\nFim das 3 rodadas, Houve um EMPATE");
            }

            Console.WriteLine("Jogar novamente? (s/n)");
            Opcao = Console.ReadLine().Trim().ToLower();

            if (Opcao == "s" || Opcao == "sim")
            {
                JogarNovamente = true;
                rodada = 1;
                escolhendo = false;
            }
            else
            {
                Menu Menu = new Menu();
                Menu.Mostrar();
            }
        }
    }
}

public class Regras
{
    public void Mostrar()
    {
        string Opcao;

        Console.WriteLine("=========================REGRAS==========================");
        Console.WriteLine("Esse é o Pedra Papel Tesoura, voce deve escolher entre:");
        Console.WriteLine("Pedra   (1)");
        Console.WriteLine("Papel   (2)");
        Console.WriteLine("Tesoura (3)");
        Console.WriteLine("");
        Console.WriteLine("Voce pode encolher digitando o nome de sua escolha ou o numero.");
        Console.WriteLine("");
        Console.WriteLine("LEMBRANDO:");
        Console.WriteLine("Pedra   (1) derrota Tesoura (3)");
        Console.WriteLine("Papel   (2) derrota Pedra   (1)");
        Console.WriteLine("Tesoura (3) derrota Papel   (2)");
        Console.WriteLine("");
        Console.WriteLine("BOM JOGO :D");
        Console.WriteLine("");
        Console.WriteLine("Sair (0)");
        Console.WriteLine("=========================================================");

        Opcao = Console.ReadLine().Trim().ToLower();

        if (Opcao == "sair" || Opcao == "0")
        {
            Menu Menu = new Menu();
            Menu.Mostrar();
        }
    }
}

public class Menu
{
    public void Mostrar()
    {
        Jogador humano = new Jogador();
        Computador bot = new Computador();
        Jogo jogo = new Jogo(humano, bot);
        Regras Regras = new Regras();

        bool escolhendo = true;
        string Opcao;

        while (escolhendo)
        {
            Console.WriteLine("==================PEDRA-PAPEL-TESOURA====================");
            Console.WriteLine("Jogar  (1)");
            Console.WriteLine("Regras (2)");
            Console.WriteLine("Sair   (0)");
            Console.WriteLine("=========================================================");

            Opcao = Console.ReadLine().Trim().ToLower();

            if (Opcao == "1" || Opcao == "jogar")
            {
                jogo.Jogar();
                escolhendo = false;
            }
            else if (Opcao == "2" || Opcao == "regras")
            {
                Regras.Mostrar();
                escolhendo = false;
            }
            else if (Opcao == "0" || Opcao == "sair")
            {
                Console.WriteLine("======================SAINDO...==========================");
                Environment.Exit(0);
            }
            else
            {
                escolhendo = true;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Menu Menu = new Menu();
        Menu.Mostrar();
    }
}