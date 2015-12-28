using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Facturanet.WinformsClient.Util
{
    public static class TreeNodeExtensions
    {
        public static IEnumerable<TreeNode> GetAncestors(this TreeNode node)
        {
            var parent = node.Parent;
            if (parent != null)
            {
                yield return parent;
                foreach (var ancestor in parent.GetAncestors())
                    yield return ancestor;
            }
        }

        public static bool IsAncestorOf(this TreeNode node, TreeNode descendant)
        {
            foreach (var ancestor in descendant.GetAncestors())
                if (ancestor == node)
                    return true;
            return false;
        }

        public static bool IsDescendantOf(this TreeNode descendant, TreeNode node)
        {
            return node.IsAncestorOf(descendant);
        }


        /*
         * tiene algun error
        public static IEnumerable<TreeNode> Backtracking(this TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;
                foreach (TreeNode subnode in nodes.Backtracking())
                    yield return subnode;
            }
        }
         * */
    }
}
