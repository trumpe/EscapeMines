using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public  class Map
    {
        public Map(int colums,int rows,Turtle turtle,List<Bomb>bombs,Exit exit)
        {
            Colums = colums;
            Rows = rows;
            Turtle = turtle;
            Bombs = bombs;
            Exit = exit;
            Status = Status.InDanger;
        }
        public int Colums { get; set; }
        public int Rows { get; set; }
        public Turtle Turtle { get; set; }
        public List<Bomb> Bombs { get; set; }
        public Exit Exit { get; set; }
        public Status Status { get; set; }
    }
}
