using System;
using System.IO;
using System.Threading.Tasks;

namespace Cirno.Common
{
    public interface ILazyContent
    {
        void WriteTo(Stream stream);

        Task WriteToAsync(Stream stream);
    }
}