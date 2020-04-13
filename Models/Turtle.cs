using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Turtle
    {
        public Turtle(int row, int colum, char direction)
        {
            Row = row;
            Colum = colum;
            Direction = direction;
        }
        public char Direction { get; set; }
        public int Row { get; set; }
        public  int Colum { get; set; }
    }
}
