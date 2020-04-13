using EscapeMines.App;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    public class MoveShould
    {
        Setup sup = new Setup();
        [Test]
        public void CorrectMovementsN()
        {
            Turtle supTurtle = new Turtle(1, 2, 'N');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10,10,supTurtle,supBombs,supExit );
            Map supMoved = sup.Move(supMap);
            Assert.AreEqual(supMoved.Turtle.Colum, 1);
           
        }
        [Test]
        public void CorrectMovementsS()
        {
            Turtle supTurtle = new Turtle(1, 2, 'S');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supMoved = sup.Move(supMap);
            Assert.AreEqual(supMoved.Turtle.Colum, 3);

        }
        [Test]
        public void CorrectMovementsE()
        {
            Turtle supTurtle = new Turtle(1, 2, 'E');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supMoved = sup.Move(supMap);
            Assert.AreEqual(supMoved.Turtle.Row, 2);

        }
        [Test]
        public void CorrectMovementsW()
        {
            Turtle supTurtle = new Turtle(1, 2, 'W');
            Exit supExit = new Exit(1, 3);
            List<Bomb> supBombs = new List<Bomb>();
            supBombs.AddRange(new List<Bomb>{  new Bomb(1, 5, 1)
                                               , new Bomb(2, 3, 2) }); ;
            Map supMap = new Map(10, 10, supTurtle, supBombs, supExit);
            Map supMoved = sup.Move(supMap);
            Assert.AreEqual(supMoved.Turtle.Row, 0);

        }
    }
}
