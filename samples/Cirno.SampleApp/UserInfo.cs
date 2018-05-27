using System;

namespace Cirno.SampleApp
{
    [Serializable]
    public class UserInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}