using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniFramework
{
    public class DelayAction : INode
    {
        public float DelayTime { get; set; }
        public DelayAction() { }
    }
}
