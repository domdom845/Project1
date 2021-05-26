using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestProject1
{
    public class Tests
    {
        [TestMethod()]
        public void RemoveData()
        {

            Database data = new Database();

            bool removeResult = data.RemoveData(6);

            Assert.IsFalse(removeResult);

        }

        [TestMethod()]
        public void storeData()
        {
            Database data = new Database();

            bool removeResult = data.storeData(20, "cup", "food", "Low", DateTime.Now, "true");


            Assert.IsTrue(removeResult);

        }

    }
}