using EscapeMines.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    public class InitExitShould
    {
        public class InitTurtleShould
        {
            Setup sut = new Setup();

            [Test]
            public void TurtleNullSetting()
            {
                Assert.That(() => sut.InitExit("")
                                                       , Throws.TypeOf<ArgumentNullException>()
                                                         .With.Matches<ArgumentNullException>(ex => ex.ParamName == "path"));
            }
            [Test]
            public void ExitNotCorrectSetting()
            {


                Assert.That(() => sut.InitExit("asd asd  asd asd asd asd")
                                                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "path"));

            }


            [Test]
            public void ExitSettingsWithTwoItems()
            {



                Assert.That(() => sut.InitExit("K 2"), Throws.TypeOf<FormatException>());

                Assert.That(() => sut.InitExit("2 das"), Throws.TypeOf<FormatException>());
                Assert.That(() => sut.InitExit("-3 1")
                                                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                        .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));


                Assert.That(() => sut.InitExit("0 -1")
                                                         , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

            }
            public void ExitSettingsWithOneItems()
            {



                Assert.That(() => sut.InitTurtle("asdasd"), Throws.TypeOf<FormatException>());



                Assert.That(() => sut.InitTurtle("-8")
                                                         , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            }
        }
    }
}
