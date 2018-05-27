using System;

namespace Cirno.Http
{
    [Serializable]
    public enum HttpMethod
    {
        Get = 0,

        Post = 1,

        Put = 2,

        Patch = 3,

        Delete = 4,

        Option = 5,

        Head = 6,
    }
}