namespace Models
{
    public class Exit
    {
        public Exit(int row,int colum)
        {
            Colum = colum;
            Row = row;
        }
        public int  Row { get; set; }
        public int Colum { get; set; }
    }
}
