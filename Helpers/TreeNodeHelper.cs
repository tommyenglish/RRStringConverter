using RRStringConverter.Models;

namespace RRStringConverter.Helpers
{
    internal static class TreeNodeHelper
    {
        public static TreeNode<string> BuildTree(string input)
        {
            int openingParenIndex = input.IndexOf('(');
            bool suppressRoot = openingParenIndex == 0;
            string truncatedInput; // version with removed outer parentheses
            TreeNode<string> treeNode;

            if (suppressRoot)
            {
                treeNode = new TreeNode<string>("root");
                truncatedInput = input[1..^1];
            }
            else
            {
                string root = input[..openingParenIndex];
                treeNode = new TreeNode<string>(root);
                int startingIndex = root.Length + 1; // the root plus '('
                truncatedInput = input[startingIndex..^1];
            }

            // id, name, email, type(id, name, customFields(c1, c2, c3)), externalId
            var items = truncatedInput.Split(", ");
            // As we iterate, if the item has no parentheses, we'll add it as a child to the current node.
            // If it has a '(', we know we need to add a child node and traverse down to add more children.
            // If it has a ')', we'll traverse back up to the parent node.
            var currentNode = treeNode;
            foreach (var item in items)
            {
                if (item.Contains('('))
                {
                    // Add a child node for what comes before the '(' and then make that the current node
                    // and add a child to that node for what comes after the '('.
                    int index = item.IndexOf('(');
                    var childBeforeParenNode = new TreeNode<string>(item[..index]);
                    currentNode.AddChild(childBeforeParenNode);

                    currentNode = childBeforeParenNode;

                    var childAfterParenNode = new TreeNode<string>(item[(index + 1)..]);
                    currentNode.AddChild(childAfterParenNode);
                }
                else if (item.Contains(')'))
                {
                    // Add a child node for what comes before the ')' and then traverse back up
                    // however many ')' there are and set that as the current node.
                    int index = item.IndexOf(')');
                    var childNode = new TreeNode<string>(item[..index]);
                    currentNode.AddChild(childNode);
                    int levelsToGoUp = item.Count(c => c == ')');
                    for (int i = 0; i < levelsToGoUp; i++)
                    {
                        currentNode = currentNode.Parent!;
                    }
                }
                else
                {
                    // Just a regular ol' child to add.
                    currentNode.AddChild(new TreeNode<string>(item));
                }
            }

            return treeNode;
        }
    }
}
