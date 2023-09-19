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
        // Метод для определения высоты узла
        private int Height(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        // Метод для вычисления баланс-фактора для узла
        private int BalanceFactor(Node node)
        {
            if (node == null)
                return 0;

            return Height(node.Left) - Height(node.Right);
        }

        // Метод для балансировки дерева
        public void Balance()
        {
            Root = BalanceRec(Root);
        }

        private Node BalanceRec(Node root)
        {
            if (root == null)
                return null;

            // Вычисляем баланс-фактор для текущего узла
            int balanceFactor = BalanceFactor(root);

            // Если баланс-фактор > 1, дерево несбалансировано влево
            if (balanceFactor > 1)
            {
                // Определяем, какой вращение применить (LL или LR)
                if (BalanceFactor(root.Left) >= 0)
                {
                    // LL - левое вращение
                    return RightRotate(root);
                }
                else
                {
                    // LR - левое затем правое вращение
                    root.Left = LeftRotate(root.Left);
                    return RightRotate(root);
                }
            }
            // Если баланс-фактор < -1, дерево несбалансировано вправо
            else if (balanceFactor < -1)
            {
                // Определяем, какой вращение применить (RR или RL)
                if (BalanceFactor(root.Right) <= 0)
                {
                    // RR - правое вращение
                    return LeftRotate(root);
                }
                else
                {
                    // RL - правое затем левое вращение
                    root.Right = RightRotate(root.Right);
                    return LeftRotate(root);
                }
            }

            // Если баланс-фактор в допустимом диапазоне, рекурсивно балансируем поддеревья
            root.Left = BalanceRec(root.Left);
            root.Right = BalanceRec(root.Right);

            return root;
        }

        // Левое вращение
        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            return y;
        }

        // Правое вращение
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
    }
}
