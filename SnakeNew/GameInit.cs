﻿using System.Xml.Linq;

namespace SnakeApp
{
    public class GameInit
    {
        private bool IsEaten { get; set; }
        private string? Key { get; set; }
        private int GameSpeed { get; set; }
        private bool IsAlive { get; set; }
        private Area Area { get; set; }
        private Snake Snake { get; set; }
        private Food Food { get; set; }
        private Drawing Drawing { get; set; }

        public GameInit(Snake snake, Food food, Drawing drawing, Area area, int speed)
        {
            Snake = snake;
            Food = food;
            Drawing = drawing;
            GameSpeed = speed;
            IsEaten = false;
            Key = null;
            IsAlive = true;
            Area = area;
        }

        public void Start()
        {
            while (IsAlive)
            {
                UpdateCoordinates();
                CheckHeadTouchWall();
                CheckHeadTouchBody();
                if (!IsAlive) break;
                CheckFoodIsEaten();
                SetNewFood();
                Drawing.Draw();
                Thread.Sleep(GameSpeed);
            }
        }

        private void UpdateCoordinates()
        {
            Snake.UpdateSnakeCoordinates(Key);
        }

        private void CheckHeadTouchWall()
        {
            if (Snake.GetSnakeHeadCoordinates().GetX() == -1 
                || Snake.GetSnakeHeadCoordinates().GetY() == 0
                || Snake.GetSnakeHeadCoordinates().GetX() == Area.GetWidth() 
                || Snake.GetSnakeHeadCoordinates().GetY() == Area.GetHeight() - 1)
            {
                IsAlive = false;
            }
        }

        private void CheckHeadTouchBody()
        {
            if (Snake.GetSnakeBodyCoordinates().Any
                (s => s.GetX() == Snake.GetSnakeHeadCoordinates().GetX() 
                && s.GetY() == Snake.GetSnakeHeadCoordinates().GetY()))
            {
                IsAlive = false;
            }
        }

        private void CheckFoodIsEaten()
        {
            if (Snake.GetSnakeHeadCoordinates().GetX() == Food.GetNewFood().GetX() 
                && Snake.GetSnakeHeadCoordinates().GetY() == Food.GetNewFood().GetY())
            {
                Snake.GrowSnake();
                IsEaten = true;
            }
        }

        private void SetNewFood()
        {
            if (IsEaten)
            {
                Food.SetNewFood();
                IsEaten = false;
            }
        }
    }
}
