using Abp.Application.Services;

namespace EasyLife.Application
{
    public interface IUploadService : IApplicationService
    {
        string UploadImg(UploadImg input);
    }
}
