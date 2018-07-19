using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MiniFramework
{
    public class Sequence:INode
    {
        public MonoBehaviour Executer { get; set; }
        public List<Action> Nodes = new List<Action>();
        public Sequence()
        {

        }
    }
}
