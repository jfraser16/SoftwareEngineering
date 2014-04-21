using System;
using UnityEngine;
using System.Linq;
using System.Collections;
using NUnit.Framework;

public class CollegeQuestTesting
{
    GUIManager.GUIitem tItem = new GUIManager.GUIitem();
    GUIManager gm = new GUIManager();
    Rect tRect;

    [Test]
    public void TestGUIRect1()
    {
        tItem.content = new GUIContent();
        tItem.size = new Vector2(100, 100);
        tItem.content.text = "BLAH";

        tRect = gm.ScreenRect(1.7f, 1.8f, tItem);

        Assert.That(tRect.xMax == Screen.width, "xMax != " + Screen.width);
        Assert.That(tRect.yMax == Screen.height, "yMax != " + Screen.height);
    }

    [Test]
    public void TestGUIRect2()
    {
        tItem.content = new GUIContent();
        tItem.size = new Vector2(100, 100);
        tItem.content.text = "BLAH";

        tRect = gm.ScreenRect(7.0f, 9.0f, tItem);

        Assert.That(tRect.xMax == Screen.width, "xMax != " + Screen.width);
        Assert.That(tRect.yMax == Screen.height, "yMax != " + Screen.height);
    }

    [Test]
    public void TestGUIRect3()
    {
        tItem.content = new GUIContent();
        tItem.size = new Vector2(100, 100);
        tItem.content.text = "BLAH";

        tRect = gm.ScreenRect(100f, 100f, tItem);

        Assert.That(tRect.xMax == Screen.width, "xMax != " + Screen.width);
        Assert.That(tRect.yMax == Screen.height, "yMax != " + Screen.height);
    }

    [Test]
    public void TestScore1()
    {
        Scoring.setScore("Mama", 0);
        Assert.That(Scoring.getScore("Mama") == 0, "Score was not set correctly!");
    }

    [Test]
    public void TestScore2()
    {
        Scoring.setScore("Mama", 1);
        Assert.That(Scoring.getScore("Mama") == 1, "Score was not set correctly!");
    }

    [Test]
    public void TestScore3()
    {
        Scoring.setScore("Mama", 2);
        Assert.That(Scoring.getScore("Mama") == 2, "Score was not set correctly!");
    }

}
