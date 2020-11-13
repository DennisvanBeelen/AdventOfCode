using System;

namespace TwentyNineteen
{
    public class DayOneChallengeOne
    {
        public void CalculateFuelNeededSimple()
        {
            string[] masses = System.IO.File.ReadAllLines(
                "D:\\SoftwareEngineering\\Software Projects\\AdventOfCode\\TwentyNineteen\\assets\\spaceCraftMass.txt");
            int total = 0;

            foreach (var mass in masses)
            {
                total += GetFuelFromMass(Convert.ToInt32(mass));
            }

            Console.WriteLine(total);
        }

        public void CalculateFuelNeededWithItsOwnFuel()
        {
            string[] masses = System.IO.File.ReadAllLines(
                "D:\\SoftwareEngineering\\Software Projects\\AdventOfCode\\TwentyNineteen\\assets\\spaceCraftMass.txt");
            int total = 0;

            foreach (var mass in masses)
            {
                var subTotal = GetFuelFromMass(Convert.ToInt32(mass));
                var tempFuel = subTotal;
                bool moreFuelNeeded = true;

                while (moreFuelNeeded)
                {
                    tempFuel = GetFuelFromMass(tempFuel);
                    if (tempFuel <= 0) moreFuelNeeded = false;
                    else subTotal += tempFuel;
                }
                total += subTotal;
            }

            Console.WriteLine(total);
        }

        public int GetFuelFromMass(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}