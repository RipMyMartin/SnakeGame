using System;
using System.Collections.Generic;
namespace SnakeMaduussTARpv23.Models
{
    internal class Obstacle
    {
        List<Point> obstacleList;

        private int width;
        private int height;

        public Obstacle(int xStart, int yStart, int width, int height)
        {
            this.width = width;
            this.height = height;
            obstacleList = new List<Point>();

            GenerateObstacle(xStart, yStart,width, height);
        }
        public void GenerateObstacle(int xStart, int yStart, int width, int height)
        {
            obstacleList = new List<Point>();  // Change List<Figure> to List<Point>

            // Add horizontal and vertical edges of the obstacle.
            for (int x = xStart; x < xStart + width; x++)
            {
                obstacleList.Add(new Point(x, yStart, '─'));                    // Top border
                obstacleList.Add(new Point(x, yStart + height - 1, '─'));       // Bottom border
            }

            for (int y = yStart; y < yStart + height; y++)
            {
                obstacleList.Add(new Point(xStart, y, '│'));                    // Left border
                obstacleList.Add(new Point(xStart + width - 1, y, '│'));        // Right border
            }

            // Add corner points
            obstacleList.Add(new Point(xStart, yStart, '┌'));                    // Top-left corner
            obstacleList.Add(new Point(xStart + width - 1, yStart, '┐'));        // Top-right corner
            obstacleList.Add(new Point(xStart, yStart + height - 1, '└'));       // Bottom-left corner
            obstacleList.Add(new Point(xStart + width - 1, yStart + height - 1, '┘')); // Bottom-right corner
        }
            public void MoveObstacle(int maxWidth, int maxHeight, List<Point> snakePoints, Point foodPoint)
    {
        Random rand = new Random();
        int xStart, yStart;
        bool overlap;

        do
        {
            overlap = false;
            xStart = rand.Next(1, maxWidth - width - 1);
            yStart = rand.Next(1, maxHeight - height - 1);

            // Check if the new position overlaps with the snake or food
            foreach (var point in snakePoints)
            {
                if (point.IsHit(new Point(xStart, yStart, ' ')) || foodPoint.IsHit(new Point(xStart, yStart, ' ')))
                {
                    overlap = true;
                    break;
                }
            }
        }
        while (overlap);

        // Clear the old obstacle
        foreach (var obstacle in obstacleList)
        {
            obstacle.Clear();
        }

        // Create a new obstacle at the new position
        obstacleList.Clear();
        GenerateObstacle(xStart, yStart,width, height);

        // Draw the new obstacle
        Draw();
    }

        internal bool IsHit(Figure figure)
        {
            foreach (var obstacle in obstacleList)
            {
                if (figure.IsHit(obstacle))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var obstacle in obstacleList)
            {
                obstacle.Draw();
            }
        }
    }
}