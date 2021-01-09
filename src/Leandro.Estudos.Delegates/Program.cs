using System;
using System.Linq;

namespace Leandro.Estudos.Delegates
{
  public delegate void ImprimirTexto(string texto);
  public delegate string TransformarTexto(string texto);

  class Program
  {
    public static Action<string> ImprimirTextoAction;
    public static Func<string, string> TransformarTextAction;

    static void Main(string[] args)
    {
      ImprimirTexto imprimirTexto = Console.WriteLine;
      Action<string> imprimirTextoAction = Console.WriteLine;

      TransformarTexto inverter = texto => texto.Reverse().ToString();
      Func<string, string> inverterAction = texto => texto.Reverse().ToString();

      Func<Pessoa, string> mostrarNomeIdade = p => $"Nome: {p.Nome} | Idade: { p.Idade}";
      Func<Pessoa, string> mostrarNome = p => $"Nome: {p.Nome}";

      var pessoa = new Pessoa("Leandro", 34);
      var pessoaString = pessoa.ToString(mostrarNomeIdade);
      Console.WriteLine(pessoaString);

     new MulticastDelegates().Run();
    }
  }
}
