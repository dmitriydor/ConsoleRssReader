using ConsoleRssReader.DataLayer;
using ConsoleRssReader.DataLayer.Types;
using Moq;
using NUnit.Framework;

namespace ConsoleRssReader.Tests
{
    [TestFixture]
    public class RssManagerTest
    {
        [Test]
        public void Add_RssManagerTest()
        {
            FakeConfigManager fakeConfigManager = new FakeConfigManager();
            RssManager manager = new RssManager(fakeConfigManager);
            manager.AddUrl("javaa.com");
            Assert.Contains("javaa.com",fakeConfigManager.Deserialization().UrlList);
        }

        [Test]
        public void ReadFromUrl_RssManagerTest()
        {
            FakeConfigManager fakeConfigManager = new FakeConfigManager();
            RssManager manager = new RssManager(fakeConfigManager);
            var list = manager.ReadFromUrl();
            Assert.AreEqual(fakeConfigManager.Deserialization().UrlList, list);
        }
        
    }
}