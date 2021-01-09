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
      ImprimirTexto imprimirTexto = Console.WriteLine;
      Action<string> imprimirTextoAction = Console.WriteLine;

      TransformarTexto inverter = texto => texto.Reverse().ToString();
      Func<string, string> inverterAction = texto => texto.Reverse().ToString();

      LogError = erro =>
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine(erro);
        Console.ForegroundColor = ConsoleColor.White;
      };
      LogError("Ocorreu um erro inesperado :(");

      ToUpperCase = texto => texto.ToUpper();
      ToUpperCase("Delegates é tooop!");

      Func<Pessoa, string> mostrarNomeIdade = p => $"Nome: {p.Nome} | Idade: { p.Idade}";
      Func<Pessoa, string> mostrarNome = p => $"Nome: {p.Nome}";

      var pessoa = new Pessoa("Leandro", 34);
      imprimirTextoAction(pessoa.ToString(mostrarNome));
      imprimirTexto(pessoa.ToString(mostrarNomeIdade));
    }
  }
}