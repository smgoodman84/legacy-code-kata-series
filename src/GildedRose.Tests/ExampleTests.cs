using System;
using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ExampleTests
    {
        [Test]
        public void AgedBrieIncreasesInQuality()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = 10,
                    SellIn = 5
                }
            };

            Program.UpdateQuality(items);

            var item = items.First();
            Assert.That(item.Name, Is.EqualTo("Aged Brie"));
            Assert.That(item.Quality, Is.EqualTo(11));
            Assert.That(item.SellIn, Is.EqualTo(4));
        }
    }
}