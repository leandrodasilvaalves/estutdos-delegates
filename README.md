# Delegates

## Objetivos
Este repositório tem como objetivo consolidar o estudos realizados sobre delegates.

## O que é Delegate?

De acordo com a documentação da [Microsoft](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/), é um tipo que representa referências a métodos com uma lista de parêmetros e tipo de retorno específicos.

A grosso modo, funciona como declarar uma variável, porém estará apontando para um método.
O delegate também é uma excelente forma de garantir o princípio do `aberto/fechado` do `SOLID`. Pois ao passá-lo como parametro de um método ou até mesmo definindo o comportamento de um delegate a partir de um client, posso mudar o comportamento de sua classe proprietária sem alterar o seu código.

Para mais detalhes veja o exemplo **LogError** na classe **SimpleDelegates**.
