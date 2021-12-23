using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphLogic
{
    public static class UnionFind
    {
        public static Set Find(Set treeNode)
        {
            if (treeNode.Parent == treeNode)
                return treeNode;
            return Find(treeNode.Parent);
        }

        public static void Union(Set firstNode, Set secNode)
        {
            firstNode = Find(firstNode);
            secNode = Find(secNode);
            if (firstNode == secNode) return;

            if (firstNode.Rang < secNode.Rang) firstNode.Parent = secNode;
            else if (firstNode.Rang == secNode.Rang)
            {
                firstNode.Parent = secNode;
                secNode.Rang += 1;
            }
            else
            {
                //firstNode.Rang > secNode.Rang
                secNode.Parent = firstNode;
            }
        }

        public static void MakeSet(Set treeNode)
        {
            treeNode.Parent = treeNode;
        }
    }
}
