using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Bomb
    {
        public Bomb(int row, int colum,int id)
        {
            Row = row;
            Colum = colum;
            Id = id;
        }
        public int Id { get; set; }
        public int  Row { get; set; }
        public int Colum { get; set; }
    }
}
