using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class ExampleTests
    {
        private static void UpdateItem(Item item)
        {
            Program.UpdateQuality(new List<Item> {item});
        }

        [Test]
        public void AgedBrieIncreasesInQuality()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 10,
                SellIn = 5
            };

            UpdateItem(item);

            Assert.That(item.Name, Is.EqualTo("Aged Brie"));
            Assert.That(item.Quality, Is.EqualTo(11));
            Assert.That(item.SellIn, Is.EqualTo(4));
        }

        [TestCase(49, 50)]
        [TestCase(50, 50)]
        [TestCase(51, 51)]
        public void AgedBrieDoesNotIncreaseInQualityAboveFifty(int quality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = 5
            };

            UpdateItem(item);

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
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 20,
                SellIn = sellIn
            };

            UpdateItem(item);

            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }


        [TestCase(1, 23)]  // TODO: Change 23 to >0 somehow
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        public void BackstagePassQualityDropsToZeroAfterSellInDate(int sellIn, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 20,
                SellIn = sellIn
            };

            UpdateItem(item);

            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }

        [TestCase(10, 8)]
        [TestCase(9, 7)]
        [TestCase(1, 0)]
        public void ConjuredItemsDegradeAtDoubleSpeed(int quality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Conjured Mana Cake",
                Quality = quality,
                SellIn = 10
            };

            UpdateItem(item);

            Assert.That(item.Quality, Is.EqualTo(expectedQuality));
        }
    }
}