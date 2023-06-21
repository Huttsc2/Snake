﻿namespace SnakeApp
{
    public class MainClass
    {
        private static int SnakeHeadCoordinateX = 7;
        private static int SnakeHeadCoordinateY = 8;
        private static int StartingSnakeLenght = 10;
        private static int Width = 22; //only even numbers
        private static int Height = 11;
        private static int FoodX = 3; //only odd numbers
        private static int FoodY = 3;
        private static int GameSpeed = 100; //console update rate in milliseconds

        public static void Main(string[] args)
        {
            Snake snake = new Snake(SnakeHeadCoordinateX, SnakeHeadCoordinateY, StartingSnakeLenght);
            Area area = new Area(Width, Height);
            Food food = new Food(FoodX, FoodY, area, snake);
            Drawing drawing = new Drawing(area, snake, food);
            ConsoleInitialization console = new ConsoleInitialization(Width, Height);
            GameInitialization game = new GameInitialization(snake, food, drawing, GameSpeed);

            console.Initiate();
            game.Start();
        }
    }
}
