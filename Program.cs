using System;
using System.Collections.Generic;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listContas = new List<Conta>();
    static void Main(string[] args)
    {
      try
      {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
          switch (opcaoUsuario)
          {
            case "1":
              ListarContas();
              break;
            case "2":
              InserirConta();
              break;
            case "3":
              Transferir();
              break;
            case "4":
              Sacar();
              break;
            case "5":
              Depositar();
              break;
            case "C":
              Console.Clear();
              break;

            default:
              throw new ArgumentOutOfRangeException();
          }
          opcaoUsuario = ObterOpcaoUsuario();
        }

        Console.WriteLine("Obrigado por utilizar nossos serviços.");
        Console.ReadLine();
      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void InserirConta()
    {
      try
      {
        Console.WriteLine("Inserir nova conta");

        Console.Write("Digite 1 para conta Física ou 2 para Jurídica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o Nome do Cliente: ");
        string entradaNome = Console.ReadLine();

        Console.Write("Digite o saldo inicial: ");
        double entradaSaldo = double.Parse(Console.ReadLine());

        Console.Write("Digite o crédito: ");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
        saldo: entradaSaldo,
        credito: entradaCredito,
        nome: entradaNome);

        listContas.Add(novaConta);
      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void ListarContas()
    {
      try
      {
        Console.WriteLine("Listar contas");

        if (listContas.Count == 0)
        {
          Console.WriteLine("Nenhuma conta cadastrada.");
          Console.WriteLine("Pressione qualquer tecla para continuar.");
          Console.ReadKey();
          return;
        }

        for (int i = 0; i < listContas.Count; i++)
        {
          Conta conta = listContas[i];
          Console.Write("#{0} - ", i);
          Console.WriteLine(conta);
        }
      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void Sacar()
    {
      try
      {
        if (listContas.Count == 0)
        {
          Console.WriteLine("Nenhuma conta cadastrada.");
          Console.WriteLine("Pressione qualquer tecla para continuar.");
          Console.ReadKey();
          return;
        }

        Console.WriteLine("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser sacado: ");
        double valorSaque = double.Parse(Console.ReadLine());

        listContas[indiceConta].Sacar(valorSaque);
      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void Depositar()
    {
      try
      {
        if (listContas.Count == 0)
        {
          Console.WriteLine("Nenhuma conta cadastrada.");
          Console.WriteLine("Pressione qualquer tecla para continuar.");
          Console.ReadKey();
          return;
        }

        Console.Write("Digite o número da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor do Deposito: ");
        double valorDeposito = double.Parse(Console.ReadLine());

        listContas[indiceConta].Depositar(valorDeposito);
      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }

    private static void Transferir()
    {
      try
      {
        if (listContas.Count == 0)
        {
          Console.WriteLine("Nenhuma conta cadastrada.");
          Console.WriteLine("Pressione qualquer tecla para continuar.");
          Console.ReadKey();
          return;
        }

        Console.Write("Digite o número da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.Write("Digite o número da conta de destino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser transferido: ");
        double valorTransferencia = double.Parse(Console.ReadLine());
        Console.WriteLine();

        listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

      }
      catch (ArgumentOutOfRangeException erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Argumento fora do range de exceção.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
      catch (Exception erro)
      {
        Console.WriteLine();
        Console.WriteLine("===============ERRO==================");
        Console.WriteLine(" Tipo do erro: {0}", erro.GetType());
        Console.WriteLine(" Dado informado não aceito.");
        Console.WriteLine("=====================================");
        Console.ReadKey();
      }
    }


    private static string ObterOpcaoUsuario()
    {

      Console.WriteLine();
      Console.WriteLine("DIO Bank a seu dispor!!!");
      Console.WriteLine();
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar contas");
      Console.WriteLine("2- Inserir nova conta");
      Console.WriteLine("3- Transferir");
      Console.WriteLine("4- Sacar");
      Console.WriteLine("5- Depositar");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();


      string opcaoUsuario = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return opcaoUsuario;
    }
  }
}
