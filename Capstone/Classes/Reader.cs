﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Reader
    {
        public Dictionary<string, List<Item>> ReadInventoryFile()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            List<string> fullText = new List<string>();
            Dictionary<string, List<Item>> startingItemList = new Dictionary<string, List<Item>>();

            string[] temp = new string[1];

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        fullText.Add(sr.ReadLine());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < fullText.Count(); i++)
            {
                temp = fullText[i].Split('|');
                int startingInventoryCount = 5;
                List<Item> fiveSameItems = new List<Item>();

                if (temp[0].Substring(0, 1) == "A")
                {
                    for (int j = 0; j < startingInventoryCount; j++)
                    {
                        fiveSameItems.Add(new Chip(temp[1], temp[2]));
                    }
                }
                else if (temp[0].Substring(0, 1) == "B")
                {
                    for (int j = 0; j < startingInventoryCount; j++)
                    {
                        fiveSameItems.Add(new Candy(temp[1], temp[2]));
                    }
                }
                else if (temp[0].Substring(0, 1) == "C")
                {
                    for (int j = 0; j < startingInventoryCount; j++)
                    {
                        fiveSameItems.Add(new Beverage(temp[1], temp[2]));
                    }
                }
                else if (temp[0].Substring(0, 1) == "D")
                {
                    for (int j = 0; j < startingInventoryCount; j++)
                    {
                        fiveSameItems.Add(new Gum(temp[1], temp[2]));
                    }
                }
                
                startingItemList.Add(temp[0], fiveSameItems);
            }

            return startingItemList;
        }
    }
}
