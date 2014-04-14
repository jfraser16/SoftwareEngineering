using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GUIManager.GUIitem tItem = new GUIManager.GUIitem();
            tItem.content.text = "BLAH";

            GUIManager gm = new GUIManager();
            Rect tRect;
            tRect = gm.ScreenRect(1.7f, 1.8f, tItem);

            Assert.Equals(tRect.xMax, Screen.width);
            Assert.Equals(tRect.yMax, Screen.height);

            tRect = gm.ScreenRect(7.0f, 9.0f, tItem);

            Assert.Equals(tRect.xMax, Screen.width);
            Assert.Equals(tRect.yMax, Screen.height);

            tRect = gm.ScreenRect(100f, 100f, tItem);

            Assert.Equals(tRect.xMax, Screen.width);
            Assert.Equals(tRect.yMax, Screen.height);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Scoring.setScore("Mama", 0);
            Assert.Equals(Scoring.getScore("Mama"), 0);

            Scoring.setScore("Mama", 1);
            Assert.Equals(Scoring.getScore("Mama"), 1);
            
            Scoring.setScore("Mama", 2);
            Assert.Equals(Scoring.getScore("Mama"), 2);
        }
    }
}
