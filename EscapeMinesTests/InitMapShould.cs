using EscapeMines.App;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Tests
{
    public class InitMapShould
    {
        Setup sut = new Setup();
        List<string> sutList = new List<string>();

        [Test]
        public void MapNullSetting()
        {
            sutList.Clear();
            sutList.AddRange(
                new List<string>{
                "",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                   , Throws.TypeOf<ArgumentNullException>()
                                                     .With.Matches<ArgumentNullException>(ex => ex.ParamName == "path"));
        }
        [Test]
        public void MapNotCorrectSetting()
        {
            sutList.Clear();
            sutList.AddRange(
                new List<string>{
                "asd asd asd asd ",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});

            Assert.That(() => sut.InitMap(sutList)
                                                    , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "path"));

        }


        [Test]
        public void MapSettingsWithTwoItems()
        {
            sutList.Clear();
            sutList.AddRange(
                new List<string>{
                "n 1",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});
            Assert.That(() => sut.InitMap(sutList), Throws.TypeOf<FormatException>());

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "1 n",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});
            Assert.That(() => sut.InitMap(sutList), Throws.TypeOf<FormatException>());
            sutList.Clear();

            sutList.AddRange(
               new List<string>{
                "-1 1",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                    , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                    .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));
            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "1 -1",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});

            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

        }
        [Test]
        public void MapSettingsWithOneItems()
        {

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "asdasd",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});

            Assert.That(() => sut.InitMap(sutList), Throws.TypeOf<FormatException>());


            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "-4",
                "1,1 3,3 1,4 4",
                "4 3",
                "0 0 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

        }
        [Test]
        public void MapSettingsTurtleOutOfMap()
        {

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "8 8",
                "1,1 3,3 1,4 4",
                "2 3",
                "9 1 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "8 8",
                "1,1 3,3 1,4 4",
                "4 3",
                "1 9 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));
        }
        [Test]
        public void MapSettingsExitOutOfMap()
        {

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "4 4",
                "1,1 3,3 1,4 4",
                "8 9",
                "1 1 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "5 5",
                "1,1 3,3 1,4 4",
                "2 9",
                "1 2 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

        }
        [Test]
        public void MapSettingsBombOutOfMap()
        {

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "9 9",
                "15,1 3,3 1,4 4",
                "0 0",
                "1 1 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "row"));

            sutList.Clear();
            sutList.AddRange(
               new List<string>{
                "9 9",
                "1,1 15,3 1,4 4",
                "2 10",
                "1 2 n"});
            Assert.That(() => sut.InitMap(sutList)
                                                     , Throws.TypeOf<ArgumentOutOfRangeException>()
                                                     .With.Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "colum"));

        }

    }
}
