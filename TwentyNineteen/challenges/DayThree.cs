using System;
using System.Collections.Generic;

namespace TwentyNineteen
{
    public class DayThree
    {
        public List<int[]> getWalkedPath(string[] PathInstructions, int pathNumber)
        {
            List<int[]> path = new List<int[]>();
            int currentLocationX = 0;
            int currentLocationY = 0;

            for (int i = 0; i < PathInstructions.Length; i++)
            {
                char direction = PathInstructions[i][0];
                int amountOfSteps = int.Parse(PathInstructions[i].Substring(1));

                for (int s = 0; s < amountOfSteps; s++)
                {
                    switch (direction)
                    {
                        case 'R':
                            currentLocationX += 1;
                            break;
                        case 'U':
                            currentLocationY += 1;
                            break;
                        case 'L':
                            currentLocationX -= 1;
                            break;
                        case 'D':
                            currentLocationY -= 1;
                            break;
                    }

                    path.Add(new[] {currentLocationX, currentLocationY});
                }
            }

            return path;
        }

        public List<int[]> checkForOverlaps(List<int[]> pathOne, List<int[]> pathTwo)
        {
            List<int[]> overlaps = new List<int[]>();
            for (int i = 0; i < pathOne.Count; i++)
            {
                Console.WriteLine(i + " / " + pathOne.Count);
                for (int j = 0; j < pathTwo.Count; j++)
                {
                    if (pathOne[i][0] == pathTwo[j][0] && pathTwo[j][1] == pathOne[i][1])
                    {
                        overlaps.Add(new[] {pathOne[i][0], pathOne[i][1]});
                    }
                }
            }

            return overlaps;
        }

        public int GetClossedOverlap(List<int[]> overlapps)
        {
            int closestDistance = int.MaxValue;
            for (int i = 0; i < overlapps.Count; i++)
            {
                int distance = Math.Abs(overlapps[i][0]) + Math.Abs(overlapps[i][1]);
                if (distance < closestDistance) closestDistance = distance;
            }

            return closestDistance;
        }

        public string[] createArray(String pathArray)
        {
            return pathArray.Split(',');
        }

        public void PrintArray(List<int[]> array)
        {
            foreach (var item in array)
            {
                Console.Write($"X{item[0]} Y{item[1]}, ");
            }
        }
    }
}