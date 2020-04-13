using EscapeMines.App;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    
    public class RotateShould
    {
        Setup sup = new Setup();
        [Test]
        public void CorrectRotateR()
        {
            Turtle supTurtle = new Turtle(1, 2, 'N');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supRotated = sup.TurtleRitation(supMap,'R');
            Assert.AreEqual(supRotated.Turtle.Direction,'E');

        }
        [Test]
        public void CorrectRotateL()
        {
            Turtle supTurtle = new Turtle(1, 2, 'S');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supRotated = sup.TurtleRitation(supMap, 'L');
            Assert.AreEqual(supRotated.Turtle.Direction, 'E');

        }
    }
}
