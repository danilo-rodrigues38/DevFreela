namespace DevFreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStorageService
    {
        void UpLoadFile ( byte [ ] bytes, string filename );
    }
}
