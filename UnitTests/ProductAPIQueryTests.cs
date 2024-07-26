using Microsoft.OData.Client;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class ProductAPIQueryTests
    {
        [Test]
        public void APIQueryShouldReturnResults()
        {
            var uri = new Uri("https://fakestoreapi.com/");
            var dsContext = new DataServiceContext(uri);
            dynamic productCollection = new DataServiceCollection<dynamic>(dsContext);
            dsContext.AddObject("Products", productCollection);

            IQueryable<dynamic> products = dsContext.CreateQuery<dynamic>("Products");

            Assert.That(products.Any(), Is.True);
        }
    }
}
