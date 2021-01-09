using System;
using System.Linq;

namespace Leandro.Estudos.Delegates
{
  public delegate void ImprimirTexto(string texto);
  public delegate string TransformarTexto(string texto);
  public class SimpleDelegates
  {
    public Action<string> LogError;
    public Func<string, string> ToUpperCase;

    public void Run()
    {
      Exemplo1();
      Exemplo2();
      Exemplo3();
    }

    public void Exemplo1()
    {
      if (LogError == null)
        LogError = DefaultLogError;
      LogError("Ocorreu um erro inesperado :(");
    }

    public void Exemplo2()
    {
      TransformarTexto inverter = texto => texto.Reverse().ToString();
      Func<string, string> inverterAction = texto => texto.Reverse().ToString();
      ToUpperCase = texto => texto.ToUpper();
      ToUpperCase("Delegates é tooop!");
    }

    public void Exemplo3()
    {
      ImprimirTexto imprimirTexto = Console.WriteLine;
      Action<string> imprimirTextoAction = Console.WriteLine;
      Func<Pessoa, string> mostrarNomeIdade = p => $"Nome: {p.Nome} | Idade: { p.Idade}";
      Func<Pessoa, string> mostrarNome = p => $"Nome: {p.Nome}";

      var pessoa = new Pessoa("Leandro", 34);
      imprimirTextoAction(pessoa.ToString(mostrarNome));
      imprimirTexto(pessoa.ToString(mostrarNomeIdade));
    }

    private void DefaultLogError(string erro)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Error.WriteLine(erro);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}