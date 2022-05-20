﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_11
{
    public class TaskChooser
    {
        string input { get; set; }

        public static void Chooser(string input)
        {
            if (input == "1")
            {
                Console.WriteLine("Please select furniture style: [1] Art Deco, [2] Victorian, [3] Modern");
                var styleInput = Console.ReadLine();
                Console.WriteLine("Please select a piece of furniture: [1] Table, [2] Sofa, [3] Chair");
                var pieceInput = Console.ReadLine();
                if (styleInput == "1")
                {
                    var workingFactory = new ArtDecoFactory();

                    if (pieceInput == "1") 
                    { 
                        workingFactory.CreateTable().ShowStyle(); 
                    }
                    if (pieceInput == "2")
                    {
                        workingFactory.CreateSofa().ShowStyle();
                    }
                    if (pieceInput == "3")
                    {
                        workingFactory.CreateChair().ShowStyle();
                    }

                }
                else if (styleInput == "2")
                {
                    var workingFactory = new VictorianFactory();

                    if (pieceInput == "1")
                    {
                        workingFactory.CreateTable().ShowStyle();
                    }
                    if (pieceInput == "2")
                    {
                        workingFactory.CreateSofa().ShowStyle();
                    }
                    if (pieceInput == "3")
                    {
                        workingFactory.CreateChair().ShowStyle();
                    }
                }
                else if (styleInput == "3")
                {
                    var workingFactory = new ModernFactory();

                    if (pieceInput == "1")
                    {
                        workingFactory.CreateTable().ShowStyle();
                    }
                    if (pieceInput == "2")
                    {
                        workingFactory.CreateSofa().ShowStyle();
                    }
                    if (pieceInput == "3")
                    {
                        workingFactory.CreateChair().ShowStyle();
                    }
                }
            }

            if (input == "2")
            {

            }
        }
    }
}