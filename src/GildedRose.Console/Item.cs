using System;

namespace GildedRose.Console
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public Item()
        { }

        public Item(DateTime dateOfEvent)
        {
            SellIn = (dateOfEvent - DateTime.Now).Days;
        }
    }
}