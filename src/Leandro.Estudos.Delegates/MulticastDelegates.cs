using System;
using System.Linq;

namespace Leandro.Estudos.Delegates
{
  public class MulticastDelegates
  {
    Action<string> notificar = Console.WriteLine;
    Action<string> notificarPorSms;
    Action<string> notificarPorEmail;
    Action<string> notificarPorWhatsapp;

    public MulticastDelegates()
    {

      notificarPorSms = m => notificar($"notificado por sms: {m}");
      notificarPorEmail = m => throw new Exception("Deu ruim");
      notificarPorWhatsapp = m => notificar($"notificado por whatsapp: {m}");
    }
    public void Run()
    {

      Action<string> notificarTudo =
      notificarPorSms
      + notificarPorEmail
      + notificarPorWhatsapp;

      //notificar com seguranca  
      notificarTudo
        .GetInvocationList()
        .ToList()
        .ForEach(SafeCallDelegate);

      //notificar sem seguranca
      notificarTudo("Notificacao com Problema");
    }

    public void SafeCallDelegate(Delegate handler)
    {
      try
      {
        handler.DynamicInvoke("Hello safe Delegates");
      }
      catch (Exception ex)
      {
        notificar(ex.Message);
      }
    }
  }
}