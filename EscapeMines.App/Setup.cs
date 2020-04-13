using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EscapeMines.App
{
    public class Setup
    {
        #region Init
        public void Init()
        {
            string path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\DataAccess\Settings\Settings.txt"));
            Data data = new Data(path);

            List<string> fileLines = data.ReadData();

            string movementsString = "";

            char rotation;



            Map map = InitMap(fileLines);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Escape Mines\n");

            Console.ReadLine();


            Console.WriteLine($"You are playing on a map with <{map.Colums}> colums and <{map.Rows}> rows. \n" +
                    $"There are {map.Bombs.Count} Bombs on the map with positions :");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var bomb in map.Bombs)
            {
                Console.WriteLine($"Bomb <{bomb.Id}> is on <{bomb.Row}> row and <{bomb.Colum}> colum");
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Exit is on <{map.Exit.Colum}> colum <{map.Exit.Row}> row");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"Turtle position is <{map.Turtle.Row}> row and <{map.Turtle.Colum}>  colum" +
                $"colum facing <{map.Turtle.Direction}> direction. \n");

            Console.WriteLine(
               $"To rotate to the left press <R>, to rotate to the right press <L> and to move press <M>. \n" +
               $"If you are ready to start the game press enter...");

            var input = Console.ReadKey(true);
            while (input.Key != ConsoleKey.Enter) { input = Console.ReadKey(true); }
            
            while (map.Status == (Status)0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Map : <{map.Colums}> colums     <{map.Rows}> rows");
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"{map.Bombs.Count} Bombs :");
                foreach (var bomb in map.Bombs)
                {
                    Console.WriteLine($"Bomb <{bomb.Id}>    <{bomb.Row}> row    <{bomb.Colum}>     colum");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Exit: <{map.Exit.Colum}> colum   <{map.Exit.Row}> row");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Turtle: <{map.Turtle.Row}> row       <{map.Turtle.Colum}> colum     <{map.Turtle.Direction}> Direction");


                Console.WriteLine("Press your next move on the keyboard");
                

                bool validInput = false;
                while (validInput == false)
                {
                    input = Console.ReadKey(true);


                    if (input.Key == ConsoleKey.M)
                    {
                        map = Move(map);
                        map = Status(map);
                        movementsString += "M ";
                        validInput = true;

                    }
                    else if (input.Key == ConsoleKey.R)
                    {
                        rotation = 'R';
                        map = TurtleRitation(map, rotation);
                        movementsString += "R ";
                        validInput = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Direction changed to :{map.Turtle.Direction}");
                    }
                    else if (input.Key == ConsoleKey.L)
                    {
                        rotation = 'L';
                        map = TurtleRitation(map, rotation);
                        movementsString += "L ";
                        validInput = true;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Direction changed to :{map.Turtle.Direction}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorect input ");
                    }
                }

            }

            data.WriteData(movementsString);
            Console.WriteLine($"There were your movements: \n {movementsString} \n" +
                $" you can find them on the last line of the settings file ");
            Console.ReadLine();

        }
        #endregion
        #region Move
        public Map Move(Map map)
        {
            string messege = "You can't move there it's the end of the map";
            if (map.Turtle.Direction == 'N')
            {
                if (map.Turtle.Colum - 1 < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(messege);
                    return map;
                }

                map.Turtle.Colum = map.Turtle.Colum - 1;
                return map;
            }
            if (map.Turtle.Direction == 'W')
            {
                if (map.Turtle.Row - 1 < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(messege);
                    return map;
                }
                map.Turtle.Row = map.Turtle.Row - 1;
                return map;
            }
            if (map.Turtle.Direction == 'S')
            {
                if (map.Turtle.Colum + 1 > map.Colums)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(messege);
                    return map;
                }
                map.Turtle.Colum = map.Turtle.Colum + 1;
                return map;
            }

            if (map.Turtle.Row + 1 > map.Rows)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(messege);
                return map;
            }
            map.Turtle.Row = map.Turtle.Row + 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Turtle moved to:{map.Turtle.Row} row {map.Turtle.Colum} colum");
            return map;
        }
        #endregion
        #region Rotation
        public Map TurtleRitation(Map map, char direction)
        {
            if (direction == 'R')
            {
                if (map.Turtle.Direction == 'N')
                {
                    map.Turtle.Direction = 'E';
                    return map;
                }
                else if (map.Turtle.Direction == 'E')
                {
                    map.Turtle.Direction = 'S';
                    return map;
                }
                else if (map.Turtle.Direction == 'S')
                {
                    map.Turtle.Direction = 'W';
                    return map;
                }
                else
                {
                    map.Turtle.Direction = 'N';
                    return map;
                }

            }
            else if (direction == 'L')
            {
                if (map.Turtle.Direction == 'N')
                {
                    map.Turtle.Direction = 'W';
                    return map;
                }
                else if (map.Turtle.Direction == 'W')
                {
                    map.Turtle.Direction = 'S';
                    return map;
                }
                else if (map.Turtle.Direction == 'S')
                {
                    map.Turtle.Direction = 'E';
                    return map;
                }
                else
                {
                    map.Turtle.Direction = 'N';
                    return map;
                }
            }
            else
            {
                return map;
            }

        }
        #endregion
        #region Status
        public Map Status(Map map)
        {
            if (map.Turtle.Colum == map.Exit.Colum && map.Turtle.Row == map.Exit.Row)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Congratulations you won");
                map.Status = (Status)1;
                return map;

            }
            foreach (var bomb in map.Bombs)
            {
                if (map.Turtle.Colum == bomb.Colum && map.Turtle.Row == bomb.Row)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You went KABOOOM and you lost the game");
                    map.Status = (Status)2;
                    return map;
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Still in danger");
            
            return map;

        }
        #endregion
        #region Map
        public Map InitMap(List<string> path)
        {
            int row;
            int colum;

            Exit exit = InitExit(path[2]);
            List<Bomb> bombs = InitBombs(path[1]);
            Turtle turtle = InitTurtle(path[3]);
            if (path[0].Length== 0)
            {
                throw new ArgumentNullException(nameof(path), "Setting for the turtle is empty");
            }
             
            string[] boardSize = path[0].Split(' ');
            if (boardSize.Length == 2)
            {
                try
                {
                    row = int.Parse(boardSize[0]);
                   
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");
                    colum = int.Parse(boardSize[1]);
                    
                    if (colum < 0)
                        throw new ArgumentOutOfRangeException(nameof(colum),"Setting can't be a negative number");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
            else if (boardSize.Length == 1)
            {
                try
                {
                    row = int.Parse(boardSize[0]);
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row), "Setting can't be a negative number");
                    
                    colum = row;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            else
                throw new ArgumentOutOfRangeException(nameof(path),"Invalid setings for the map");

            if (turtle.Row > row)
            {
                throw new ArgumentOutOfRangeException(nameof(row),"Turtle is out of the map");
            }
            if ( turtle.Colum > colum)
            {
                throw new ArgumentOutOfRangeException(nameof(colum),"Turtle is out of the map");
            }
            if (exit.Row > row )
            {
                throw new ArgumentOutOfRangeException(nameof(row),"Exit is out of the map");
            }
            if ( exit.Colum > colum)
            {
                throw new ArgumentOutOfRangeException(nameof(colum), "Exit is out of the map");
            }
            foreach (var bomb in bombs)
            {
                if (bomb.Row > row )
                {
                    throw new ArgumentOutOfRangeException(nameof(row),$"bomb {bomb.Id} is out of the map");
                }
                if ( bomb.Colum > colum)
                {
                    throw new ArgumentOutOfRangeException(nameof(colum),$"bomb {bomb.Id} is out of the map");
                }
            }

            return new Map(colum, row, turtle, bombs, exit);
        }
        #endregion
        #region Bombs
        public List<Bomb> InitBombs(string path)
        {
            if (path.Length== 0) 
            {
                throw new ArgumentNullException(nameof(path), "Setting for the turtle is empty");
            }
               
            string[] listOfMinesStringArray = path.Split(',');
            int row;
            int colum;
            List<Bomb> bombs = new List<Bomb>();
            int id = 1;
            

            foreach (var item in listOfMinesStringArray)
            {
                string[] strinTemp = item.Split(" ");
                if (strinTemp.Length == 2)
                {
                    try
                    {
                        row = int.Parse(strinTemp[0]);
                        
                        if (row < 0)
                            throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");
                        colum = int.Parse(strinTemp[1]);
                       
                        if (colum < 0)
                            throw new ArgumentOutOfRangeException(nameof(colum),"Setting can't be a negative number");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }

                    bombs.Add(new Bomb(row, colum, id));
                    id++;
                }
                else if (strinTemp.Length == 1)
                {
                    try
                    {
                        row = int.Parse(strinTemp[0]);
                       
                        if (row < 0)
                            throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");
                        colum = row;

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                    bombs.Add(new Bomb(row, colum, id));
                    id++;

                }
                else
                    throw new ArgumentOutOfRangeException(nameof(path),"Invalid settings for the bombs");

            }
            return bombs;


        }
        #endregion
        #region Exit
        public Exit InitExit(string path)
        {
            if (path.Length==0)
            {
                throw new ArgumentNullException(nameof(path), "Setting for the turtle is empty");
            }
           
            string[] exitPointArray = path.Split(' ');
            int row;
            int colum;
            

            if (exitPointArray.Length == 2)
            {

                try
                {

                    row = int.Parse(exitPointArray[0]);                   
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");
                    colum = int.Parse(exitPointArray[1]);
                   
                    if (colum < 0)
                        throw new ArgumentOutOfRangeException(nameof(colum),"Setting can't be a negative number");

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
            else if (exitPointArray.Length == 1)
            {
                try
                {
                    row = int.Parse(exitPointArray[0]);
                   
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");

                    colum = row;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }


            }
            else
                throw new ArgumentOutOfRangeException(nameof(path),"Not correct setting for the Exit");

            return new Exit(row, colum);
        }
        #endregion
        #region Turtle
        public Turtle InitTurtle(string path)
        {
            
            var noNullPath = path ?? throw new ArgumentNullException(nameof(path),"Setting for the turtle is empty");
            string[] turtleStartingPoingString = noNullPath.Split(" ");
            int row;
            int colum;
            char direction;
            

            if (turtleStartingPoingString.Length == 3)
            {


                try
                {
                    row = int.Parse(turtleStartingPoingString[0]);                    
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row)
                                                              ,"Setting for turtle row can't be a negative number");


                    colum = int.Parse(turtleStartingPoingString[1]);
                    
                    if (colum < 0)
                        throw new ArgumentOutOfRangeException(nameof(colum)
                                                              ,"Setting for turtle colum can't be a negative number");


                    direction = Char.Parse(turtleStartingPoingString[2]);
                    

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                catch (ArgumentOutOfRangeException ex) 
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            else if (turtleStartingPoingString.Length == 2)
            {
                try
                {
                    row = int.Parse(turtleStartingPoingString[0]);
                   
                    if (row < 0)
                        throw new ArgumentOutOfRangeException(nameof(row),"Setting can't be a negative number");

                    colum = row;


                    direction = Char.Parse(turtleStartingPoingString[1]);
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                    throw new FormatException();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }

            else
                throw new ArgumentOutOfRangeException(nameof(noNullPath),"Not correct setting for the turtle");


            if (direction.Equals('n') || direction.Equals('N'))
            {
                direction = 'N';
            }
            else if (direction.Equals('w') || direction.Equals('W'))
            {
                direction = 'W';
            }
            else if (direction.Equals('s') || direction.Equals('S'))
            {
                direction = 'S';
            }
            else if (direction.Equals('e') || direction.Equals('E'))
            {
                direction = 'E';
            }
            else
            {

                throw new ArgumentOutOfRangeException(nameof(direction),$"Invalid Direction <{direction}> for the turtle");
            }
            return new Turtle(row, colum, direction);
        }
        #endregion
    }

}


