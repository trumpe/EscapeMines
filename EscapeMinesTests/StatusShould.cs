using EscapeMines.App;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    public class StatusShould
    {
        Setup sup = new Setup();
        [Test]
        public void StatusWin()
        {
            Turtle supTurtle = new Turtle(1, 1, 'N');
            Exit supExit = new Exit(1, 1);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supStatus = sup.Status(supMap);
            
            Assert.AreEqual(supStatus.Status, (Status)1);

        }
        [Test]
        public void StatusLose()
        {
            Turtle supTurtle = new Turtle(1, 1, 'N');
            Exit supExit = new Exit(1, 4);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 1, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supStatus = sup.Status(supMap);
            Assert.AreEqual(supStatus.Status, (Status)2);

        }
        [Test]
        public void StatusStillInDanger()
        {
            Turtle supTurtle = new Turtle(1, 1, 'N');
            Exit supExit = new Exit(0, 1);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supStatus = sup.Status(supMap);
            Assert.AreEqual(supStatus.Status, (Status)0);

        }
    }
}
