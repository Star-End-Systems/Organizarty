using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Organizarty.Infra.Utils;

public class NanoidConverter : ValueConverter<string, string>
{
    public NanoidConverter()
        : base(v => IdGenerator.DefaultId(), v => v) { }
}
