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

        [TestCase(49, 50)]
        [TestCase(50, 50)]
        [TestCase(51, 51)]
        public void AgedBrieDoesNotIncreaseInQualityAboveFifty(int quality, int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    Quality = quality,
                    SellIn = 5
                }
            };

            Program.UpdateQuality(items);

            var item = items.First();
            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(11, 21)]
        [TestCase(10, 22)]
        [TestCase(9, 22)]
        [TestCase(6, 22)]
        [TestCase(5, 23)]
        [TestCase(4, 23)]
        public void BackstagePassQualityIncreaseWhenSellInDateApproaches(int sellIn, int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = sellIn
                }
            };

            Program.UpdateQuality(items);

            var item = items.First();
            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }


        [TestCase(1, 23)]  // TODO: Change 23 to >0 somehow
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        public void BackstagePassQualityDropsToZeroAfterSellInDate(int sellIn, int expectedQuality)
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    Quality = 20,
                    SellIn = sellIn
                }
            };

            Program.UpdateQuality(items);

            var item = items.First();
            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }
    }
}