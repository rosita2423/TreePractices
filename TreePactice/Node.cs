using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TreePactice
{
    public class xd
    {
        public Nullable <int>[] transverseList = new Nullable <int>[15];
        public int save = 1;
        public int saveTotal = 0;
        public String [] levels = new String [10];
        public String[] diagonals = new String[10];
        public int treeConstant = 0;
        public bool left;
        public bool right;

        //Constructor
        public int[] nodesSaved = new int [1];
        public bool uniqueValue = false;

        //new
        public Nullable<int>[] intList = new Nullable<int>[16];
        public List<Nullable<int>[]> intListTotal = new List<Nullable<int>[]>();
        public int depness = 0;
        public bool x = false;
        public int diagonalLineSpaces = 0;
        public int arrayPosition = 0;
    }

    internal class Node
    {
        public Nullable<int> data = null;
        public Node elementLeft = null;
        public Node elementRight = null;
        int depnessX;
        private int save;

        //Constructor
        public Node(int nodeData)
        {
            listOfNodes.uniqueValue = true;
            for (int i = 0; i < listOfNodes.nodesSaved.Length; i++)
            {
                if (nodeData == listOfNodes.nodesSaved[i])
                {
                    listOfNodes.uniqueValue = false;
                    break;
                }
            }
            if (listOfNodes.uniqueValue == true)
            {
                data = nodeData;
            }
            else
            {
                Console.WriteLine("You cannot add a non-unique value");
            }
            
        }
        xd listOfNodes = new xd();

        //Insert a new node into the tree
        public void Insert(Node newNode) { 
            if (newNode != null)
            {
                if (elementLeft == null)
                {
                    elementLeft = newNode;
                }
            }
        
        }
        public void Insert(Node newNode, string direction)
        {
            if (newNode.data != null)
            {
                if (direction == "left")
                {
                    if (elementLeft == null)
                    {
                        elementLeft = newNode;
                    }

                }
                else if (direction == "right")
                {
                    if (elementRight == null)
                    {
                        elementRight = newNode;
                    }

                }
            }
            else
            {
                Console.WriteLine("You cannot add an invalid node.");            }
        }
        public void Remove()
        {

            if (elementLeft != null)
            {
                elementLeft.Remove();
                elementLeft = null;
            }
            if (elementRight != null)
            {
                elementRight.Remove();
                elementRight = null;
            }
            data = null;

        }

        //Remove a node
        public void RemoveDefinitive(Node node)
        {
            RemoveDefinitive2(node);
            if (node == this.elementLeft)
            {
                elementLeft = null;
            }
            else if (node == this.elementRight)
            {
                elementRight = null;
            }
        }
        public void RemoveDefinitive2(Node node)
        {
            if (node.elementLeft != null)
            {
                node.elementLeft.RemoveDefinitive2(node.elementLeft);
                node.elementLeft = null;
            }
            if (node.elementRight != null)
            {
                node.elementRight.RemoveDefinitive2(node.elementRight);
                node.elementRight = null;
            }

            node.data = null;
        }
        
        public void Search(int nodeNumber)
        {
            Console.WriteLine();
            if (1 == Search(this, nodeNumber))
            {
                Console.WriteLine("Search result: Yes, there is the node number " + nodeNumber + ".");
            }
            else
            {
                Console.WriteLine("Search result: Jajajaja there isn't the node number " + nodeNumber + ".");
            }

        }
        public Nullable<int> Search(Node node, int nodeNumber)
        {
            if (node.data == null)
            {
                return null;
            }
            for (int i = 1; i < 4; i++)
            {
                if (i == 1)
                {
                    if (node.elementLeft != null)
                    {
                        if (1 == Search(node.elementLeft, nodeNumber))
                        {
                            return 1;
                        }
                    }

                }
                else if (i == 2)
                {
                    if (nodeNumber == node.data)
                    {
                        return 1;
                    }
                }
                else if (i == 3)
                {
                    if (node.elementRight != null)
                    {
                        if (1 == Search(node.elementRight, nodeNumber))
                        {
                            return 1;
                        }
                    }

                }
            }
            return null;
        }
        public Node SearchWithReturn(int nodeNumber)
        {
            Node node = SearchWithReturn(this, nodeNumber);
            
            return node;
        }
        public Node SearchWithReturn(Node node, int nodeNumber)
        {
            if (node.data == null)
            {
                return null;
            }
            if (node.data == nodeNumber)
            {
                Node find = node;
                return find;
            }

            if (node.elementLeft != null)
            {
                if (null != SearchWithReturn(node.elementLeft, nodeNumber))
                {
                    Node find = SearchWithReturn(node.elementLeft, nodeNumber);
                    return find;
                }
            }

            if (node.elementRight != null)
            {
                if (null != SearchWithReturn(node.elementRight, nodeNumber))
                {
                    Node find = SearchWithReturn(node.elementRight, nodeNumber);
                    return find;
                }
            }
 
            return null;
        }
        public void Transverse(string type)
        {
            //Transverse nodes and saving them on an array
            Transverse(this, type);

            //Print trasnversed tree
            Console.WriteLine();
            Console.Write("Transversed tree: (");
            for (int i = 0; i < listOfNodes.transverseList.Length; i++)
            {
                if (listOfNodes.transverseList[i] != null)
                {
                    if (i == 0)
                    {
                        Console.Write(listOfNodes.transverseList[i]);
                    }
                    else
                    {
                        Console.Write(", " + listOfNodes.transverseList[i]);
                    }
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
        public void Transverse(Node node, string type)
        {
            if (node.data == null)
            {
                return;
            }
            //Inorder
            if (type == "inorder")
            {
                if (node.elementLeft != null)
                {
                    Transverse(node.elementLeft, "inorder");
                }
                for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                {
                    if (listOfNodes.transverseList[k] == null)
                    {
                        listOfNodes.transverseList[k] = node.data;
                        break;
                    }
                }
                if (node.elementRight != null)
                {
                    Transverse(node.elementRight, "inorder");
                }
            }
            //preorder
            else if (type == "preorder")
            {
                for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                {
                    if (listOfNodes.transverseList[k] == null)
                    {
                        listOfNodes.transverseList[k] = node.data;
                        break;
                    }
                }
                if (node.elementLeft != null)
                {
                    Transverse(node.elementLeft, "preorder");
                }
                if (node.elementRight != null)
                {
                    Transverse(node.elementRight, "preorder");
                }
            }
            //postorder
            else if (type == "postorder")
            {
                if (node.elementLeft != null)
                {
                    Transverse(node.elementLeft, "postorder");
                }
                if (node.elementRight != null)
                {
                    Transverse(node.elementRight, "postorder");
                }
                for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                {
                    if (listOfNodes.transverseList[k] == null)
                    {
                        listOfNodes.transverseList[k] = node.data;
                        break;
                    }
                }
            }
        }
        public void Height()
        {
            Height(this);
            Console.WriteLine();
            Console.WriteLine("Your tree have " + listOfNodes.saveTotal + " levels.");
        }
        public int HeightWithReturn()
        {
            Height(this);
            return listOfNodes.saveTotal;
        }
        public void Height(Node node)
        {
            for (int i = 2; i < 4; i++)
            {
                if (i == 2)
                {
                    if (node.elementLeft != null)
                    {
                        listOfNodes.save = listOfNodes.save + 1;
                        if (listOfNodes.save > listOfNodes.saveTotal)
                        {
                            listOfNodes.saveTotal = listOfNodes.save;
                        }
                        Height(node.elementLeft);
                        listOfNodes.save = listOfNodes.save - 1;
                    }

                }
                else if (i == 3)
                {
                    if (node.elementRight != null)
                    {
                        listOfNodes.save = listOfNodes.save + 1;
                        if (listOfNodes.save > listOfNodes.saveTotal)
                        {
                            listOfNodes.saveTotal = listOfNodes.save;
                        }
                        Height(node.elementRight);
                        listOfNodes.save = listOfNodes.save - 1;
                    }
                }
            }
        }

        public void printTreeDefinitive()
        {
            for (int i = 0; i < HeightWithReturn()+1;i++)
            {
                Nullable<int>[] intList2 = new Nullable<int>[15];
                listOfNodes.intListTotal.Add(intList2);

            }

            printTreeDefinitive(this);

            bool exchange = true;
            for (int level = 0; level < HeightWithReturn(); level++)
            {
                //Print the first spaces
                for (int k = 0; k < HeightWithReturn() - listOfNodes.diagonalLineSpaces + 1; k++)
                {
                    Console.Write("  ");
                }
                while (listOfNodes.intListTotal[level][listOfNodes.arrayPosition] != null)
                {
                    if (exchange == false)
                    {
                        Console.Write("(");
                        Console.Write(listOfNodes.intListTotal[level][listOfNodes.arrayPosition] + ", ");
                        exchange = true;
                    }
                    else
                    {
                        Console.Write(listOfNodes.intListTotal[level][listOfNodes.arrayPosition]+") ");
                        exchange = false;
                    }
                    
                    listOfNodes.arrayPosition++;
                }
                Console.WriteLine();
                Console.WriteLine();
                listOfNodes.arrayPosition = 0;
                listOfNodes.diagonalLineSpaces = listOfNodes.diagonalLineSpaces + 1;
            }
        }

        public bool returning(Node node, string side)
        {
            if (side == "right")
            {
                if (node.elementRight != null)
                {
                    return true;
                }
            }
            if (side == "left")
            {
                if (node.elementLeft != null)
                {
                    return true;
                }
            }
            return false;
        }
        public void printTreeDefinitive(Node node)
        {
            if (node.elementLeft != null)
            {
                listOfNodes.depness = listOfNodes.depness + 1;
                printTreeDefinitive(node.elementLeft);
                listOfNodes.depness = listOfNodes.depness - 1;
            }
            else
            {
                listOfNodes.depness = listOfNodes.depness + 1;

                int h = 0;
                while (listOfNodes.x == false)
                {
                    if (listOfNodes.intListTotal[listOfNodes.depness][h] == null)
                    {
                        listOfNodes.intListTotal[listOfNodes.depness][h] = 0;
                        listOfNodes.x = true;
                    }
                    h = h + 1;
                }
                listOfNodes.x = false;

                listOfNodes.depness = listOfNodes.depness - 1;
            }
            
            
            if (node.elementRight != null)
            {
                listOfNodes.depness = listOfNodes.depness + 1;
                printTreeDefinitive(node.elementRight);
                listOfNodes.depness = listOfNodes.depness - 1;
            }
            else
            {
                listOfNodes.depness = listOfNodes.depness + 1;

                int h = 0;
                while (listOfNodes.x == false)
                {
                    if (listOfNodes.intListTotal[listOfNodes.depness][h] == null)
                    {
                        listOfNodes.intListTotal[listOfNodes.depness][h] = 0;
                        listOfNodes.x = true;
                    }
                    h = h + 1;
                }
                listOfNodes.x = false;

                listOfNodes.depness = listOfNodes.depness - 1;
            }

            //Save depnesss
            int p = 0;
            while (listOfNodes.x == false)
            {
                if (listOfNodes.intListTotal[listOfNodes.depness][p] == null)
                {
                    listOfNodes.intListTotal[listOfNodes.depness][p] = node.data;
                    listOfNodes.x = true;
                }
                p = p + 1;

            }
            listOfNodes.x = false;
            
        }
    }
}
