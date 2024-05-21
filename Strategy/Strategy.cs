using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI.Strategy
{
    public interface IMovementStrategy
    {
        void Move();
    }

    public class WalkStrategy : IMovementStrategy
    {
        public void Move()
        {
            Console.WriteLine("Персонаж идет.");
        }
    }

    public class FlyStrategy : IMovementStrategy
    {
        public void Move()
        {
            Console.WriteLine("Персонаж летает.");
        }
    }

    public class WalkAndFlyStrategy : IMovementStrategy
    {
        public void Move()
        {
            Console.WriteLine("Персонаж и ходит, и летает.");
        }
    }

    public class MagicFlyStrategy : IMovementStrategy
    {
        public void Move()
        {
            Console.WriteLine("Персонаж летает с помощью магии.");
        }
    }

    public abstract class Character
    {
        protected IMovementStrategy _movementStrategy;

        public Character(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public void SetMovementStrategy(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public void Move()
        {
            _movementStrategy.Move();
        }

        public abstract void Display();
    }

    public class Orc : Character
    {
        public Orc(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я орк.");
        }
    }

    public class Troll : Character
    {
        public Troll(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я тролль.");
        }
    }

    public class Pegasus : Character
    {
        public Pegasus(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я пегас.");
        }
    }

    public class Elf : Character
    {
        public Elf(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я эльф.");
        }
    }

    public class Vampire : Character
    {
        public Vampire(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я вампир.");
        }
    }

    public class Harpy : Character
    {
        public Harpy(IMovementStrategy movementStrategy) : base(movementStrategy) { }

        public override void Display()
        {
            Console.WriteLine("Я гарпия.");
        }
    }

    public interface ISortStrategy
    {
        void Sort(int[] array);
    }

    public interface ISearchStrategy
    {
        int Find(int[] array);
    }

    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Отсортировано пузырьковой сортировкой.");
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("Отсортировано быстрой сортировкой.");
        }

        private void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);

                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            return i + 1;
        }
    }

    public class MaxValueStrategy : ISearchStrategy
    {
        public int Find(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }

    public class MinValueStrategy : ISearchStrategy
    {
        public int Find(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
    }

    public class ArrayContext
    {
        private ISortStrategy _sortStrategy;
        private ISearchStrategy _searchStrategy;

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void SetSearchStrategy(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }

        public void Sort(int[] array)
        {
            _sortStrategy.Sort(array);
        }

        public int Search(int[] array)
        {
            return _searchStrategy.Find(array);
        }
    }
}
