using System;
using System.Collections.Generic;

namespace Cirno.Mvc.Discovery
{
    public interface IActionDiscovery
    {
        IEnumerable<ActionDescription> Discover();
    }
}