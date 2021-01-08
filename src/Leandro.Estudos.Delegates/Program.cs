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

      ///////Multicast Delegates
      Action<string> notificarPorSms = m => imprimirTexto($"notificado por sms: {m}");
      Action<string> notificarPorEmail = m => throw new Exception("Deu ruim");
      Action<string> notificarPorWhatsapp = m => imprimirTexto($"notificado por whatsapp: {m}");


      Action<string> notificarTudo =
        notificarPorSms
        + notificarPorEmail
        + notificarPorWhatsapp;

      //notificarTudo("Notificacao com Problema");

      //safe call
      Action<Delegate> safeCAllDelegate = handler =>
      {
        try{
            handler.DynamicInvoke("Hello safe Delegates");            
        }
        catch(Exception ex){
            imprimirTexto(ex.Message);
        }
      };

      notificarTudo
        .GetInvocationList()
        .ToList()
        .ForEach(safeCAllDelegate);
    }
  }
}
