using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife.Application
{
    public interface IUploadService
    {
        string UploadImg(UploadImg input);
    }
}
