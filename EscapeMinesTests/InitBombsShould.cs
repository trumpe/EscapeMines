using EscapeMines.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    public class InitBombsShould
    {
        public class InitTurtleShould
        {
            Setup sut = new Setup();

            [Test]
            public void BombNullSetting()
            {
                Assert.That(() => sut.InitBombs("")
                                                       , Throws.TypeOf<ArgumentNullException>()
                                                         .With.Matches<ArgumentNullException>(ex => ex.ParamName == "path"));
            }
            [Test]
            public void BombNotCorrectSetting()
            {


                Assert.That(() => sut.InitBombs("as adasd asd asd dasd")
                                                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "path"));

            }


            [Test]
            public void BombSettingsWithTwoItems()
            {



                Assert.That(() => sut.InitBombs("K 2"), Throws.TypeOf<FormatException>());

                Assert.That(() => sut.InitBombs("2 das"), Throws.TypeOf<FormatException>());
                Assert.That(() => sut.InitBombs("-3 1")
                                                        , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                        .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));


                Assert.That(() => sut.InitBombs("0 -1")
                                                         , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

            }
            public void BombSettingsWithOneItems()
            {



                Assert.That(() => sut.InitBombs("asdasd"), Throws.TypeOf<FormatException>());



                Assert.That(() => sut.InitBombs("-8")
                                                         , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                         .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            }
        }
    }
}
