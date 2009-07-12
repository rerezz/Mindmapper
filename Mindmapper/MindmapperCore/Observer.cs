using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindmapperCore
{
    /// <summary>
    /// Abstract observer class
    /// </summary>
    public abstract class Observer
    {
        public abstract void Update();
    }
}
