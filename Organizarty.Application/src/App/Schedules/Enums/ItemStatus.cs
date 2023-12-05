namespace Organizarty.Application.App.Schedules.Enum;

public enum ItemStatus
{
    PENDING = 0,
    ACCEPT,
    REFUSED,
    WAITING,
}

public static class ItemStatusExtension{
    public static string GetName(this ItemStatus status){
        switch (status)
        {
            case(ItemStatus.ACCEPT):
                return "Aceito";
            
            case(ItemStatus.REFUSED):
                return "Recusado";

            case(ItemStatus.PENDING):
                return "Pendente";
            
            case(ItemStatus.WAITING):
                return "Esperando";
        }

        return "";
    }
}