using System;
using System.Collections.Generic;
using System.Text;



/**
 *  Motivation of using the Proxy pattern
 *  Here we create a wrapper in order to use Percentages , addition and multiplication
 */

namespace DotNetDesignPatternDemos.Structural.Proxy.ValueProxy
{

    // Percentage class with logic 
    public struct Percentage
    {
        public bool Equals(Percentage other)
        {
            return value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        private readonly float value;

        public Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a.value + b.value);
        }

        public override string ToString()
        {
            return $"{value * 100}%";
        }
    }



    // Extensions functions 
    public static class PercentageExtensions
    {
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }


    // Demo
    class ValueProxy
    {
        static void Main1(string[] args)
        {
            Console.WriteLine(
                10f * 5.Percent()
            );

            Console.WriteLine(
                2.Percent() + 3.Percent() // 5%
            );
        }
    }
}
