using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy
{

    // Proxy for performance improvment

    class Creature
    {
        public byte Age;
        public int X, Y;
    }

    class Creatures
    {
        public readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            this.age = new byte[size];
            this.x = new int[size];
            this.y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures _creatures;
            private readonly int index;

            public CreatureProxy(Creatures creatures, int index)
            {
                _creatures = creatures;
                this.index = index;
            }

            public ref byte Age => ref _creatures.age[index];
            public ref int X => ref _creatures.x[index];
            public ref int Y => ref _creatures.y[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0; pos < size; ++pos)
            {
                yield return new CreatureProxy(this, pos);
            }
        }
    }

    class CompositeProxy
    {
        static void Main(string[] args)
        {
            var creatures = new Creatures(100);

            foreach (var c in creatures)
            {
                c.X++;
            }

            var creatures2 = new Creatures(100);
            foreach (Creatures.CreatureProxy c in creatures2)
            {
                c.X++;
            }
        }

    }
}
