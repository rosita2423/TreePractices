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
        public Nullable <int>[] transverseList = new Nullable <int>[10];
    }
    
    internal class Node
    {
        public Nullable <int> data = null;
        public Node elementLeft = null;
        public Node elementRight = null;
        
        private int save;

        //Constructor
        public Node(int nodeData)
        {
            data = nodeData;
        }
        xd listOfNodes = new xd();

        public void Insert(Node newNode) { 
        if (elementLeft == null)
                {
                    elementLeft = newNode;
                }
        }
        public void Insert(Node newNode, string direction)
            {
            if(direction == "left")
            {
                if (elementLeft == null)
                {
                    elementLeft = newNode;
                }
                
            }
            else if(direction == "right")
            {
                if(elementRight == null)
                {
                    elementRight = newNode;
                }
                
            }
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
        public void Search(int nodeNumber)
        {
            if (1 == Search(this, nodeNumber))
            {
                Console.WriteLine("Search result: Yes, there is the node number " + nodeNumber + ".");
            }
            else 
            {
                Console.WriteLine("Search result: Jajajaja there isn't the node number " + nodeNumber + ".");
            }
            
        }
        public Nullable <int> Search(Node node, int nodeNumber)
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
                        if(1 == Search(node.elementLeft, nodeNumber))
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
                        if(1 == Search(node.elementRight, nodeNumber))
                        {
                            return 1;
                        }
                    }

                }
            }
            return null;
        }
        public void Transverse(string type)
        {
            //Transverse nodes and saving them on an array
            Transverse(this, type);

            //Print trasnversed tree
            Console.Write("Transversed tree: (");
            for(int i=0;i < listOfNodes.transverseList.Length;i++)
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
        public void Transverse(Node node,string type)
        {
            if (node.data == null)
            {
                return;
            }
            //Inorder
            if (type == "inorder")
            {
                for (int i = 1; i < 4; i++)
                {
                    if (i == 1)
                    {
                        if (node.elementLeft != null)
                        {
                            Transverse(node.elementLeft, "inorder");
                        }

                    }
                    else if (i == 2)
                    {
                        for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                        {
                            if (listOfNodes.transverseList[k] == null)
                            {
                                listOfNodes.transverseList[k] = node.data;
                                break;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        if (node.elementRight != null)
                        {
                            Transverse(node.elementRight,"inorder");
                        }

                    }

                }
            }
            //preorder
            else if(type == "preorder")
            {
                for (int i = 1; i < 4;i++)
                {
                    if (i==1)
                    {
                        for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                        {
                            if (listOfNodes.transverseList[k] == null)
                            {
                                listOfNodes.transverseList[k] = node.data;
                                break;
                            }
                        }
                    } 
                    else if (i == 2)
                    {
                        if (node.elementLeft != null)
                        {
                            Transverse(node.elementLeft, "preorder");
                        }
                        
                    }
                    else if(i == 3)
                    {
                        if(node.elementRight != null)
                        {
                            Transverse(node.elementRight, "preorder");
                        }
                    }
                }
            } 
            //postorder
            else if(type == "postorder")
            {
                for (int i = 1; i < 4;i++)
                {
                    if (i == 1)
                    {
                        if (node.elementLeft != null)
                        {
                            Transverse(node.elementLeft, "postorder");
                        }
                    }
                    else if(i == 2)
                    {
                        if (node.elementRight != null)
                        {
                            Transverse(node.elementRight, "postorder");
                        }
                    }
                    else if (i == 3)
                    {
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
            }
        }

        public void Height(Node node)
        {
            for (int i = 1; i < 4; i++)
            {
                if (i == 1)
                {
                    for (int k = 0; k < listOfNodes.transverseList.Length; k++)
                    {
                        if (listOfNodes.transverseList[k] == null)
                        {
                            listOfNodes.transverseList[k] = node.data;
                            break;
                        }
                    }
                }
                else if (i == 2)
                {
                    if (node.elementLeft != null)
                    {
                        Transverse(node.elementLeft, "preorder");
                    }

                }
                else if (i == 3)
                {
                    if (node.elementRight != null)
                    {
                        Transverse(node.elementRight, "preorder");
                    }
                }
            }
        }
        public void printTree()
        {
            Console.WriteLine("      "+this.data+"       ");
            Console.Write("     ");
            if (this.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (this.elementRight.data != null)
            {
                Console.Write("\\");
            }


            Console.WriteLine("");
            Console.Write("    ");
            if (elementLeft.data != null)
            {
                Console.Write(elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if (elementRight.data != null)
            {
                Console.Write(elementRight.data);
            }

            Console.WriteLine("");
            Console.Write("   ");
            if(elementLeft.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if(this.elementLeft.elementRight.data != null)
            {
                Console.Write("\\");
            }
            Console.Write(" ");
            if (elementRight.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (elementRight.elementRight.data != null)
            {
                Console.Write("\\");
            }

            Console.WriteLine();
            Console.Write("  ");
            if(elementLeft.elementLeft.data != null)
            {
                Console.Write(elementLeft.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("  ");
            if(elementLeft.elementRight.data != null)
            {
                Console.Write(elementLeft.elementRight.data);
            }
            if(elementRight.elementLeft.data != null)
            {
                Console.Write(elementRight.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if(elementRight.elementRight.data != null)
            {
                Console.Write(elementRight.elementRight.data);
            }

            Console.WriteLine();
            Console.Write(" ");
            if(elementLeft.elementLeft.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if(elementLeft.elementLeft.elementRight.data != null)
            {
                Console.Write("\\");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("     ");
            if (elementRight.elementRight.elementLeft.data != null)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write(" ");
            if (elementRight.elementRight.elementRight.data != null)
            {
                Console.Write("\\");
            }

            Console.WriteLine("");
            if(elementLeft.elementLeft.elementLeft.data != null)
            {
                Console.Write(elementLeft.elementLeft.elementLeft.data);
            }
            else
            {
                Console.Write(" ");
            }
            Console.Write("   ");
            if (elementLeft.elementLeft.elementRight.data != null)
            {
                Console.Write(elementLeft.elementLeft.elementRight.data);
            }
            Console.Write("   ");
            if(elementRight.elementRight.elementLeft.data != null)
            {
                Console.Write(elementRight.elementRight.elementLeft.data);
            }
            //Console.WriteLine("     / \\      ");
            //Console.WriteLine("    2   3");
            //Console.WriteLine("   / \\ / \\");
            //Console.WriteLine("  4");
            //Console.WriteLine(" /");
            //Console.WriteLine("6");
        }
    }
}
