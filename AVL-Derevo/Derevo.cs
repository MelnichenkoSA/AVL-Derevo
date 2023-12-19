namespace AVL_Derevo
{
    internal class Derevo
    {
        public Node Root { get; set; }

        public Derevo()
        {
            Root = null;
        }

        public void Insert(int data)
        {
            Root = InsertRec(Root, data);
        }

        private Node InsertRec(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = InsertRec(root.Right, data);
            }
            root.Height = 1 + Math.Max(Height(root.Left), Height(root.Right));
            return root;
        }
        public void Delete(int data)
        {
            Root = DeleteRec(Root, data);
        }

        private Node DeleteRec(Node root, int data)
        {
            if (root == null)
            {
                return root; 
            }

            if (data < root.Data)
            {
                root.Left = DeleteRec(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = DeleteRec(root.Right, data);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.Data = MinValue(root.Right);
                root.Right = DeleteRec(root.Right, root.Data);
            }
            root.Height = 1 + Math.Max(Height(root.Left), Height(root.Right));
            return root;
        }

        private int MinValue(Node root)
        {
            int minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Left.Data;
                root = root.Left;
            }
            return minValue;
        }

        public bool Find(int data)
        {
            return FindRec(Root, data) != null;
        }

        private Node FindRec(Node root, int data)
        {
            if (root == null || root.Data == data)
            {
                return root;
            }

            if (data < root.Data)
            {
                return FindRec(root.Left, data);
            }

            return FindRec(root.Right, data);
        }

        private int Height(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }
        private int BalanceFactor(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }


        public void Balance()
        {
            Root = BalanceRec(Root);
        }

        private Node BalanceRec(Node root)
        {
            if (root == null)
                return null;

            int balanceFactor = BalanceFactor(root);

            if (balanceFactor > 1)
            {
                if (BalanceFactor(root.Left) >= 0)
                {
                    return RightRotate(root);
                }
                else
                {
                    root.Left = LeftRotate(root.Left);
                    return RightRotate(root);
                }
            }
            else if (balanceFactor < -1)
            {
                if (BalanceFactor(root.Right) <= 0)
                {
                    return LeftRotate(root);
                }
                else
                {
                    root.Right = RightRotate(root.Right);
                    return LeftRotate(root);
                }
            }

            root.Left = BalanceRec(root.Left);
            root.Right = BalanceRec(root.Right);
            root.Height = 1 + Math.Max(Height(root.Left), Height(root.Right));
            return root;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            return y;
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            return x;
        }


        public void InorderTraversal()
        {
            InorderTraversal(Root);
        }

        private void InorderTraversal(Node root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InorderTraversal(root.Right);
            }
        }
        public void PreorderTraversal()
        {
            PreorderTraversal(Root);
        }

        private void PreorderTraversal(Node root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreorderTraversal(root.Left);
                PreorderTraversal(root.Right);
            }
        }
        public void PostorderTraversal()
        {
            PostorderTraversal(Root);
        }

        private void PostorderTraversal(Node root)
        {
            if (root != null)
            {
                PostorderTraversal(root.Left);
                PostorderTraversal(root.Right);
                Console.Write(root.Data + " ");
            }
        }

        //Операторы
        public void PlusTraversal(Node root, Derevo tree2, int b)
        {
            if (root != null)
            {
                PlusTraversal(root.Left, tree2, b);
                PlusTraversal(root.Right, tree2, b);
                tree2.Insert( root.Data + b);
            }
        }

        public void PulusTraversal(Node root1, Node root2, Derevo tree3)
        {
            Console.WriteLine("*");
            if ((root1 != null) && (root2 != null))
            {
                PulusTraversal(root1.Left, root2.Left, tree3);
                PulusTraversal(root1.Right, root2.Right, tree3);
                tree3.Insert(root1.Data);
                tree3.Insert(root2.Data);
            }

            else if ((root1 != null) && (root2 == null))
            {

                PulusTraversal(root1.Left, root1.Left, tree3);
                PulusTraversal(root1.Right, root1.Right, tree3);
                tree3.Insert(root1.Data);
            }

            else if ((root1 == null) && (root2 != null))
            {

                PulusTraversal(root2.Left, root2.Left, tree3);
                PulusTraversal(root2.Right, root2.Right, tree3);
                tree3.Insert(root2.Data);
            }

        }

        public static Derevo operator +(Derevo a, int b)
        {
            Derevo tree2 = new Derevo();
            a.PlusTraversal(a.Root, tree2, b);
            return tree2;
        }
        public static Derevo operator +(Derevo tree1, Derevo tree2)
        {
            if (tree1.MinValue(tree1.Root) >= tree2.MaxValue(tree2.Root))
            {
                Derevo tree3 = new Derevo();
                tree3.Insert(0);
                tree3.Root.Left = tree2.Root;
                tree3.Root.Right = tree1.Root;
                tree3.Delete(0);
                return tree3;
            }
            else if (tree2.MinValue(tree2.Root) >= tree1.MaxValue(tree1.Root))
            {
                Derevo tree3 = new Derevo();
                tree3.Insert(0);
                tree3.Root.Left = tree1.Root;
                tree3.Root.Right = tree2.Root;
                tree3.Delete(0);
                return tree3;   
            }

            else
            {
                Derevo tree3 = new Derevo();

                tree3.PulusTraversal(tree1.Root, tree2.Root, tree3);
                return tree3;
            }

        }
        /*public static Derevo operator +(Derevo tree1, Derevo tree2)
        {
            Derevo tree3 = new Derevo();

            tree3.PulusTraversal(tree1.Root, tree2.Root, tree3);
            return tree3;
        }*/

        private int MaxValue(Node root)
        {
            int minValue = root.Data;
            while (root.Right != null)
            {
                minValue = root.Right.Data;
                root = root.Right;
            }
            return minValue;
        }

    }
}
