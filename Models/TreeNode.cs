namespace RRStringConverter.Models;

internal class TreeNode<T>
{
    public T Value { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T value) 
    { 
        Value = value;
        Children = [];
    }

    public void AddChild(TreeNode<T> child)
    {
        child.Parent = this;
        Children.Add(child);
    }
}
