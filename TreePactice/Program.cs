using TreePactice;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Node n1 = new Node(1);
        Node n2 = new Node(2);
        Node n3 = new Node(3);
        Node n4 = new Node(4);
        Node n5 = new Node(5);
        Node n6 = new Node(6);
        Node n7 = new Node(7);
        Node n8 = new Node(8);
        Node n9 = new Node(9);
        Node n10 = new Node(10);
        Node n11 = new Node(11);
        Node n12 = new Node(12);

        n1.Insert(n2);
        n1.Insert(n3,"right");

        n2.Insert(n4);
        n2.Insert(n5,"right");

        n3.Insert(n7);
        n3.Insert(n8,"right");

        n4.Insert(n6);
        n4.Insert(n9,"right");

        n7.Insert(n10,"right");

        n8.Insert(n12);
        n8.Insert(n11,"right");

        //n2.Remove();

        n1.Transverse("postorder");

        n1.Height();

        n1.Search(1);

        n1.printTree();

    }
}