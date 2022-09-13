using System;
using System.Threading;

namespace _20220913
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GC_Car();
            Indexer();
        }

        // 1번문제
        private static void GC_Car()
        {
            Program p = new Program();

            Console.WriteLine(DateTime.Now);

            p.Test();

            GC.Collect();

            Thread.Sleep(1000);
        }
        private void Test()
        {
            Car car = new Car(1, "Car");
        }
        
        // 2번문제
        private static void Indexer()
        {
            Abc abc = new Abc();
            for (int i = 0; i < 5; i++)
            {
                abc[i] = i;
            }
            foreach (int i in abc.a)
            {
                Console.WriteLine(i);
            }
        }
    }
    internal class Car
    {
        private int id;
        private string name;

        public Car(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        ~Car()
        {
            Console.WriteLine($"{DateTime.Now}시점에 소멸자 호출됨");
        }
    }

    internal class Abc
    {
        private int[] A;

        public Abc()
        {
            A = new int[5];
        }

        public int Length()
        {
            return A.Length;
        }

        public int this[int index]
        {
            get
            {
                return A[index];
            }
            set
            {
                if (index >= A.Length)
                {
                    Console.WriteLine("접근할 수 없는 인덱스 입니다");
                }

                A[index] = value;
            }
        }

        public int[] a
        {
            get { return A; }
            set { A = value; }
        }
    }
}
