using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLibrary
{
    public class BFSAlgorithm
    {
        Queue<Node> States = new Queue<Node>();

        public BFSAlgorithm(bool? [,] State, int PointX, int PointY)
        {
            Node Root = new Node(null);
            Root.PointX = PointX;
            Root.PointY = PointY;

            Root.State = State;

            States.Enqueue(Root);
        }

        public Stack<Directions> getSolution()
        {
            while (States.Count > 0)
            {
                Node CurrentNode = States.Dequeue();
                
                // Check Goal
                if(CurrentNode.IsGoal)
                {
                    Stack<Directions> Sol = new Stack<Directions>();

                    while (CurrentNode.Parent != null)
                    {
                        Sol.Push(CurrentNode.Direction);
                        CurrentNode = CurrentNode.Parent;
                    }

                    return Sol;
                }

                List<Node> Children = getAllChildren(CurrentNode);


                foreach (Node Child in Children)
                {
                    States.Enqueue(Child);
                }
            }
            
            return null;
        }

        private List<Node> getAllChildren(Node Current)
        {
            List<Node> Children = new List<Node>();

            int X = Current.PointX;
            int Y = Current.PointY;

            int Right = ++Y;
            --Y;
            int Left = --Y;
            ++Y;

            int Down = ++X;
            --X;
            int Up = --X;
            ++X;

            bool?[,] State = Current.State;

            if(Right < State.GetLength(1) && State[X, Right] != false)
            {
                bool?[,] S = CopyArr(State);

                Node Child = new Node(Current);

                if (S[X, Right] == null)
                {
                    S[X, Right] = false;
                    Child.State = State;
                }
                else
                    Child.IsGoal = true;

                Child.PointX = X;
                Child.PointY = Right;

                Child.Direction = Directions.Right;

                Children.Add(Child);
            }

            if (Left >= 0&& State[X, Left] != false)
            {
                bool?[,] S = CopyArr(State);

                Node Child = new Node(Current);

                if (S[X, Left] == null)
                {
                    S[X, Left] = false;
                    Child.State = State;
                }
                else
                    Child.IsGoal = true;

                Child.PointX = X;
                Child.PointY = Left;

                Child.Direction = Directions.Left;

                Children.Add(Child);
            }


            if (Down < State.GetLength(0) && State[Down, Y] != false)
            {
                bool?[,] S = CopyArr(State);

                Node Child = new Node(Current);

                if (S[Down, Y] == null)
                {
                    S[Down, Y] = false;
                    Child.State = State;
                }
                else
                    Child.IsGoal = true;

                Child.PointX = Down;
                Child.PointY = Y;

                Child.Direction = Directions.Down;

                Children.Add(Child);
            }

            if (Up >= 0 && State[Up, Y] != false)
            {
                bool?[,] S = CopyArr(State);

                Node Child = new Node(Current);

                if (S[Up, Y] == null)
                {
                    S[Up, Y] = false;
                    Child.State = State;
                }
                else
                    Child.IsGoal = true;

                Child.PointX = Up;
                Child.PointY = Y;

                Child.Direction = Directions.Up;

                Children.Add(Child);
            }

            return Children;
        }


        private bool?[,] CopyArr(bool?[,] Arr)
        {
            bool?[,] newArr = new bool?[Arr.GetLength(0), Arr.GetLength(1)];

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    newArr[i, j] = Arr[i, j];
                }
            }

            return newArr;
        }

    }
}
