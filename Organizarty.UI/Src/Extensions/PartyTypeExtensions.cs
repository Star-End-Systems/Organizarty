using Organizarty.Application.App.Party.Enums;

namespace Organizarty.UI.Extensions;

public static class PartyTypeMethods
{
    public static string GetName(this PartyType type)
    {
      switch (type)
      {
        case(PartyType.chadebebe):
          return "Chá de Bebê";
        case(PartyType.casamento):
          return "Casamento";
        case(PartyType.aniversario):
          return "Aniversário";
        case(PartyType.debutante):
          return "Debutante";
        case(PartyType.happyHour):
          return "Happy Hour";
      }

      return "";
    }

    public static string GetBackground(this PartyType type)
    {
      switch (type)
      {
        case(PartyType.chadebebe):
          return "#A912DD";
        case(PartyType.casamento):
          return "#928163";
        case(PartyType.aniversario):
          return "#DD0068";
        case(PartyType.debutante):
          return "#2A2D34";
        case(PartyType.happyHour):
          return "#00DD45";
      }

      return "#ff0000";
    }

    public static string GetImage(this PartyType type)
    {
      switch (type)
      {
        case(PartyType.chadebebe):
          return "/images/Clients/MyParties/Urso.png";
        case(PartyType.casamento):
          return "/images/Clients/MyParties/Casamento.png";
        case(PartyType.aniversario):
          return "/images/Clients/MyParties/Aniversario.png";
        case(PartyType.debutante):
          return "/images/Clients/MyParties/Debutante.png";
        case(PartyType.happyHour):
          return "/images/Clients/MyParties/HappyHour.png";
      }

      return "";
    }
}
