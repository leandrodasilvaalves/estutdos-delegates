using System;

namespace Leandro.Estudos.Delegates
{
  public class Pessoa
  {
    public Pessoa(string nome, int idade)
    {
      Nome = nome;
      Idade = idade;
    }

    public string Nome { get; private set; }
    public int Idade { get; private set; }

    public string ToString(Func<Pessoa, string> funcaoDelegate)
    {
      return funcaoDelegate(this);
    }
  }
}
