using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Test {


    [Test]
    public void LapsPlus()
    {
        var raceMeniu = new RaceChooseMenu();
        var lapsexpected = 3;
        var laps = raceMeniu.LapPluss();
        Assert.That(laps, Is.EqualTo(lapsexpected));
    }
    [Test]
    public void LapsMinus()
    {
        var raceMeniu = new RaceChooseMenu();
        var lapsexpected = 1;
        var laps = raceMeniu.LapMinuss();
        Assert.That(laps, Is.EqualTo(lapsexpected));
    }
    [Test]
    public void OpponentsPlus()
    {
        var raceMeniu = new RaceChooseMenu();
        var opponentsExpected = 4;
        var opponents = raceMeniu.OpPluss();
        Assert.That(opponents, Is.EqualTo(opponentsExpected));
    }
    [Test]
    public void OpponentsMinus()
    {
        var raceMeniu = new RaceChooseMenu();
        var opponentsExpected = 2;
        var opponents = raceMeniu.OpMinuss();
        Assert.That(opponents, Is.EqualTo(opponentsExpected));
    }
    [Test]
    public void CarChoosePlus()
    {
        var raceMeniu = new RaceChooseMenu();
        var CarExpected = 2;
        var cars = raceMeniu.NextCarss();
        Assert.That(cars, Is.EqualTo(CarExpected));
    }
    [Test]
    public void CarChooseMinus()
    {
        var raceMeniu = new RaceChooseMenu();
        var CarExpected = 0;
        var cars = raceMeniu.PrevCarss();
        Assert.That(cars, Is.EqualTo(CarExpected));
    }
}
