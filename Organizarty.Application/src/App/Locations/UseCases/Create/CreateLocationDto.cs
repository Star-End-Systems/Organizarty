using Organizarty.Application.App.Locations.Entities;

namespace Organizarty.Application.App.Locations.UseCases;

public record CreateLocationDto(string name, string description, double areaSize, decimal rentPerDay, string cep, string category, string address, string cords, List<string> images)
{
    public Location ToModel
      => new Location
      {
          Name = name,
          Description = description,
          AreaSize = areaSize,
          RentPerDay = rentPerDay,
          CEP = cep,
          Address = address,
          Category = category,
          Cords = cords,
          Images = images
      };
}
