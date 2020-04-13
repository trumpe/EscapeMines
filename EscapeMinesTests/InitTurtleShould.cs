using EscapeMines.App;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{

    public class InitTurtleShould
    {
        Setup sut = new Setup();

        [Test]
        public void TurtleNullSetting()
        {
            Assert.That(() => sut.InitTurtle("")
                                                   , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "noNullPath"));
        }
        [Test]
        public void TurtleNotCorrectSetting()
        {


            Assert.That(() => sut.InitTurtle("asdasd")
                                                    , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "noNullPath"));

        }
        [Test]
        public void TurtleInvalidSettingsWithThreeItems()
        {

            Assert.That(() => sut.InitTurtle("K 2 N"), Throws.TypeOf<FormatException>());

            Assert.That(() => sut.InitTurtle("2 das W"), Throws.TypeOf<FormatException>());

            Assert.That(() => sut.InitTurtle("1 3 adfgP"), Throws.TypeOf<FormatException>());


            Assert.That(() => sut.InitTurtle("-1 das W")
                                                   , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                   .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            Assert.That(() => sut.InitTurtle("1 -3 W")
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

        }
        [Test]
        public void TurtleInvalidSettingsWithTwoItems()
        {



            Assert.That(() => sut.InitTurtle("1 asdP"), Throws.TypeOf<FormatException>());



            Assert.That(() => sut.InitTurtle("-3 W")
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

        }

        [Test]
        public void TurtleDirectionDoesNotExist()
        {


            Assert.That(() => sut.InitTurtle("1 4 p")
                                                    , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "direction"));

        }

    }
}
