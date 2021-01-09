using System;
using System.Linq;

namespace Leandro.Estudos.Delegates
{
  class Program
  {
    static void Main(string[] args)
    {
      var simpleDelegates = new SimpleDelegates();
      simpleDelegates.Run();
      simpleDelegates.LogError = LogError;
      simpleDelegates.Run();

      // new MulticastDelegates().Run();
    }

    static void LogError(string erro)
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.Error.WriteLine(erro);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
