using NanoidDotNet;

namespace Organizarty.Infra.Utils;

public class IdGenerator
{
    public readonly static int ID_SIZE = 15;

    public static string DefaultId()
      => Nanoid.Generate(size: ID_SIZE);
}
