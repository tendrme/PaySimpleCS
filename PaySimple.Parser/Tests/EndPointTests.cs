using System;
using System.Linq;

using NUnit.Framework;

namespace PaySimple.Parser.Tests
{
    [TestFixture]
    public class EndPointTests
    {
        [Test]
        public void General()
        {
            EndPointReader.Current.Read();
        }

        [Test]
        public void Check_parameters()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Uri = "/v4/customer/{customerId}/{accountId}"
            });
            Assert.AreEqual(ep.Parameters.Count(), 2);
            Assert.AreEqual(ep.Parameters.ElementAt(0).Name, "customerId");
            Assert.AreEqual(ep.Parameters.ElementAt(1).Name, "accountId");
        }

        [Test]
        public void Check_object_type_name()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Method = "GET",
                Uri = "/v4/customer/{customerId}/{accountId}"
            });
            var type = default(string);
            Assert.DoesNotThrow(() => type = ep.TypeName);
            Assert.AreEqual(type, "Customer");
        }

        [Test]
        public void Check_all_return_types()
        {
            var endpoints = EndPointReader
                .Current
                .Items
                .Values
                .SelectMany(x => x)
                .Select(x => new EndPoint(x));
            string returnType;
            Assert.DoesNotThrow(() =>
            {
                foreach (var ep in endpoints)
                    returnType = ep.ReturnTypeName;
            });
        }

        [Test]
        public void Complex_return_type_parsing()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Method = "GET",
                Uri = "/v4/invoice/{invoiceId}/invoicelineitems"
            });
            var foo = ep.ReturnTypeName;
        }

        [Test]
        public void Uri_with_query_string()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Method = "GET",
                Uri = "/v4/recurringpayment/{scheduleId}/pause?endDate={iso8601 Date}"
            });
            Assert.AreEqual("Pause", ep.FriendlyName);
        }

        [Test]
        public void Customer_return_type()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Method = "PUT",
                Uri = "/v4/customer"
            });
            Assert.AreNotEqual(ep.ReturnTypeName, "v4");
        }

        [Test]
        public void Get_all_items()
        {
            var ep = new EndPoint(new EndPointDesc
            {
                Method = "GET",
                Uri = "/v4/customer"
            });
            Assert.AreEqual(ep.FriendlyName, "GetAllCustomers");
        }
    }
}
