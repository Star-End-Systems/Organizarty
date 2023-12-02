namespace Organizarty.Adapters;

public interface IImageUpload
{
  Task<string> UploadImage(string bucket, string folder, byte[] fileBytes);
}
