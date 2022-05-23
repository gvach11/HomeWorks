using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_11
{
    public abstract class Furniture
    {
        public abstract string style { get; set; }
        public abstract void ShowStyle();
    }

    public class Chair : Furniture
    {
        public override string style { get; set; }

        public override void ShowStyle()
        {
            Console.WriteLine($"Returned {style} Chair");
        }
    }

    public class Sofa : Furniture
    {
        public override string style { get; set; }

        public override void ShowStyle()
        {
            Console.WriteLine($"Returned {style} Sofa");
        }
    }

    public class Table : Furniture
    {
        public override string style { get; set; }

        public override void ShowStyle()
        {
            Console.WriteLine($"Returned {style} Table");
        }
    }

    public abstract class FurnitureFactory
    {
        public abstract Furniture CreateChair();
        public abstract Furniture CreateTable();
        public abstract Furniture CreateSofa();
    }

    public class ArtDecoFactory : FurnitureFactory
    {
        public override Furniture CreateChair()
        {
            Chair chair = new Chair();
            chair.style = "Art Deco";
            return chair;
        }

        public override Furniture CreateSofa()
        {
            Sofa sofa = new Sofa();
            sofa.style = "Art Deco";
            return sofa;
        }

        public override Furniture CreateTable()
        {
            Table table = new Table();
            table.style = "Art Deco";
            return table;
        }
    }

    public class VictorianFactory : FurnitureFactory
    {
        public override Furniture CreateChair()
        {
            Chair chair = new Chair();
            chair.style = "Victorian";
            return chair;
        }

        public override Furniture CreateSofa()
        {
            Sofa sofa = new Sofa();
            sofa.style = "Victorian";
            return sofa;
        }

        public override Furniture CreateTable()
        {
            Table table = new Table();
            table.style = "Victorian";
            return table;
        }
    }

    public class ModernFactory : FurnitureFactory
    {
        public override Furniture CreateChair()
        {
            Chair chair = new Chair();
            chair.style = "Modern";
            return chair;
        }

        public override Furniture CreateSofa()
        {
            Sofa sofa = new Sofa();
            sofa.style = "Modern";
            return sofa;
        }

        public override Furniture CreateTable()
        {
            Table table = new Table();
            table.style = "Modern";
            return table;
        }
    }







}