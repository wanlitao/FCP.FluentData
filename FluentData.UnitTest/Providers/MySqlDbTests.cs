using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentData;

namespace FCP.FluentData.UnitTest
{
    [TestClass]
    public class MySqlDbTests
    {
        private IDbContext Context
        {
            get { return ContextHelper.getMySqlDbContext("MySqlConnection"); }
        }

        [TestMethod]
        public void SqlSelectTest()
        {
            var command = Context.Sql("select count(1) from ticket_info");

            var ticketCount = command.QuerySingle<int>();

            Assert.IsTrue(ticketCount >= 0);
        }

        [TestMethod]
        public void SqlSelectByInTest()
        {
            var ticketIds = new List<string> { "111", "222", "333" };

            var selectBuilder = Context.Select<int>("count(1)")
                .From("ticket_info")
                .Where("id in(@0)")
                .Parameters(ticketIds);

            var ticketCount = selectBuilder.QuerySingle();

            Assert.AreEqual(0, ticketCount);
        }
    }
}
