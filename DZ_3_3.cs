using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_3_3
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class stack<T>
    {
        private Node<T> top;
        public int count;

        public stack()
        {
            top = null;
            count = 0;
        }

        public int Size()
        {
            return count;
        }

        public void Push(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = top;
            top = newNode;
            count++;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }
            Node<T> temp = top;
            top = top.Next;
            count--;
            return temp.Data;
        }
    }

    internal class DZ_3_3
    {
        public static bool Check(string stroka)  
        {
            stack<char> stack = new stack<char>();
            int CloseCkobki = 0;
            foreach (char value in stroka.ToCharArray())
            {
                if (value == '(')
                {
                    stack.Push(value);
                }
                else if (value == ')')
                {
                    CloseCkobki++;
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine("Лишняя {0} закрывающая скобка", CloseCkobki);
                        return false;
                    }
                }
            }
            if (stack.count != 0)
            {
                Console.WriteLine(" Количество лишних открывающих скобок : " + stack.Size());
                return false;
            }
            Console.WriteLine("Скобки расставлены верно");
            return true;
        }
        static void Main()
        {
            string stroka = Console.ReadLine();
            Check(stroka);
        }
    }
}
