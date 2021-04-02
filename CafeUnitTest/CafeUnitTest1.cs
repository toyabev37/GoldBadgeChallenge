using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeUnitTest
{
    [TestClass]
    public class CafeUnitTest1
    {
        //setup private fields
        private MenuRepository _mrepo;
        private MenuItem _item;

        //use test initialization attribute
        [TestInitialize]
        public void arrange()
        {
            _mrepo = new MenuRepository();
            _item = new MenuItem("chicken sandwich", "...", "...", 1.99     );
        }

        [TestMethod]
        public void AddToDatabaseAndReciveListOfItemsAndDelete()
        {
            //create a listTo hold _mrepo data
            _mrepo.AddMenuItemToDatabase(_item);
            List<MenuItem> menuItems = _mrepo.ReceiveListOfItems();
            foreach (var item in menuItems)
            {
                Console.WriteLine(item.MealName);
            }
            _mrepo.RemoveMenuItem(1);
            Console.WriteLine(menuItems.Count);
            Assert.IsTrue(menuItems.Count==0);
        }
    }
}
