namespace SnakeApp
{
    public class FreeCellsSearcher
    {
        private List<Point> AreaCells { get; set; }
        private List<Point> SnakeCoordinates { get; set; }
        private List<Point> FreeCells { get; set; }

        public FreeCellsSearcher(List<Point> areaCells, List<Point> snakeCoordinates)
        {
            AreaCells = areaCells;
            SnakeCoordinates = snakeCoordinates;
        }

        private void SetFreeCells()
        {
            FreeCells = AreaCells;
            FreeCells.RemoveAll((p => SnakeCoordinates
            .Any(partial => partial.GetX() == p.GetX() && partial.GetY() == p.GetY())));
        }

        public List<Point> GetFreeCells()
        {
            SetFreeCells();
            return FreeCells;
        }
    }
}
