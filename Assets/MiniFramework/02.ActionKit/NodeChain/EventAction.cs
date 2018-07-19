using System;

namespace MiniFramework
{
    public class EventAction:INode
    {
        public Action ExcuteEvent { get; set; }
        public EventAction() { }
    }
}
