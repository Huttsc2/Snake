namespace SnakeApp
{
    public class Food
    {
        private List<Point> SuitableCells { get; set; }
        private FreeCellsSearcher Searcher { get; set; }
        private Point NewFood { get; set; }

        public Food(FreeCellsSearcher searcher)
        {
            Searcher = searcher;
            SetNewFood();
        }

        public void SetNewFood()
        {
            SuitableCells = new List<Point>(Searcher.GetFreeCells());
            NewFood = SuitableCells[new Random().Next(SuitableCells.Count-1)];
        }

        public Point GetNewFood()
        {
            return NewFood;
        }
    }
}
