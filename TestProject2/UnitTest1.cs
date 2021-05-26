using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shopping_List_2;

namespace TestProject2
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void RemoveData()
        {

            Database data = new Database();

            bool removeResult = data.RemoveData(20);

            Assert.IsTrue(removeResult);

        }

        [TestMethod()]
        public void storeData()
        {
            Database data = new Database();

            bool removeResult = data.storeData(20, "cup", "food", "Low", "05/26/2021", "true");


            Assert.IsTrue(removeResult);

        }
    }
}
