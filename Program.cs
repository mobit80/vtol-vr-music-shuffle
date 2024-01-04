// See https://aka.ms/new-console-template for more information
using System;
using data;

namespace randomizer
{
   public class programStarter
    {
       public static void Main(string[] args)
        {
            FileModifier mod = new FileModifier();
            mod.randomizer();
        }
    }   
}