namespace TreeTask;

internal class Program
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new();

        tree.Add(8);
        tree.Add(3);
        tree.Add(1);
        tree.Add(10);
        tree.Add(14);
        tree.Add(6);
        tree.Add(7);
        tree.Add(13);
        tree.Add(4);
        tree.Add(5);
        tree.Add(9);

        tree.Remove(3);

        Console.WriteLine("Breadth first traversal:");
        tree.TraverseBreadthFirst(Console.WriteLine);

        Console.WriteLine();

        Console.WriteLine("Depth first traversal recursive:");
        tree.TraverseDepthFirstRecursive(Console.WriteLine);

        Console.WriteLine();

        Console.WriteLine("Depth first traversal:");
        tree.TraverseDepthFirst(Console.WriteLine);

        Console.WriteLine();

        Console.WriteLine(tree);
        Console.WriteLine($"Count = {tree.Count}");
    }
}
