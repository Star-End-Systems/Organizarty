using Organizarty.Application.App.Decorations.Entities;
namespace Organizarty.UI.Extensions;

public static class DecorationCategoryMethods
{
    public static string GetName(this DecorationCategory Category)
    {
      switch (Category)
      {
        case(DecorationCategory.Balao):
          return "Balão";
        case(DecorationCategory.Mesa):
          return "Mesa";
        case(DecorationCategory.Descartaveis):
          return "Descartáveis";
        case(DecorationCategory.Enfeites):
          return "Enfeites";
        case(DecorationCategory.Loucas):
          return "Louças";
      }

      return "";
    }

    public static string GetTitle(this DecorationCategory Category)
    {
      switch (Category)
      {
        case(DecorationCategory.Balao):
          return "Escolha o Balão";
        case(DecorationCategory.Mesa):
          return "Escolha a Mesa";
        case(DecorationCategory.Descartaveis):
          return "Escolha os Descatáveis";
        case(DecorationCategory.Enfeites):
          return "Escolha os Enfeites";
        case(DecorationCategory.Loucas):
          return "Escolha as Louças";
      }

      return "";
    }

    public static string GetSubTitle(this DecorationCategory Category)
    {
      switch (Category)
      {
        case(DecorationCategory.Balao):
          return "Aqui você escolhe o formato desejado do arranjo de seus balões";
        case(DecorationCategory.Mesa):
          return "Aqui você escolhe o formato desejado de suas mesas";
        case(DecorationCategory.Descartaveis):
          return "Aqui você escolhe o tipo desejado de descatáveis";
        case(DecorationCategory.Enfeites):
          return "Aqui você escolhe o estilo desejado do arranjo dos enfeites";
        case(DecorationCategory.Loucas):
          return "Aqui você escolhe o estilo desejado das louças";
      }

      return "";
    }
}
