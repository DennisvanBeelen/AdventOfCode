﻿using System;
using System.Security.AccessControl;

namespace TwentyNineteen
{
    // 99 program finished, halt program.
    // 1 adds together the ints from the position of the next two ints. then overwrite the value at position 3.
    // 2 = same as 1 but multiplies instead of additions.
    // after completion step forwards 4 positions
    public class DayTwo
    {
        public int[] BaseOpCode =
        {
            1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 10, 19, 1, 9, 19, 23, 1, 13, 23, 27, 1, 5, 27, 31, 2,
            31, 6, 35, 1, 35, 5, 39, 1, 9, 39, 43, 1, 43, 5, 47, 1, 47, 5, 51, 2, 10, 51, 55, 1, 5, 55, 59, 1, 59, 5,
            63, 2, 63, 9, 67, 1, 67, 5, 71, 2, 9, 71, 75, 1, 75, 5, 79, 1, 10, 79, 83, 1, 83, 10, 87, 1, 10, 87, 91, 1,
            6, 91, 95, 2, 95, 6, 99, 2, 99, 9, 103, 1, 103, 6, 107, 1, 13, 107, 111, 1, 13, 111, 115, 2, 115, 9, 119, 1,
            119, 6, 123, 2, 9, 123, 127, 1, 127, 5, 131, 1, 131, 5, 135, 1, 135, 5, 139, 2, 10, 139, 143, 2, 143, 10,
            147, 1, 147, 5, 151, 1, 151, 2, 155, 1, 155, 13, 0, 99, 2, 14, 0, 0
        };

        public int[] OpCode;

        public int ExpectedAnswer = 19690720;
        
        public void BruteForceIntputFromAnwer(int expectedAnswer)
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    OpCode = new int[BaseOpCode.Length];
                    BaseOpCode.CopyTo(OpCode, 0);
                    OpCode[1] = i;
                    OpCode[2] = j;

                    ReadCode();
                    
                    if (OpCode[0] == expectedAnswer)
                    {
                        PrintOpCode();
                        return;
                    }
                }
            }
        }

        public void SimpleReadCode()
        {
            OpCode = BaseOpCode;
            ReadCode();
            PrintOpCode();
        }


        private void ReadCode()
        {
            var Location = 0;
            var NinetyNineNotFound = true;

            while (NinetyNineNotFound)
            {
                switch (OpCode[Location])
                {
                    case 1:
                        OpCodeOne(Location);
                        Location += 4;
                        break;
                    case 2:
                        OpCodeTwo(Location);
                        Location += 4;
                        break;
                    case 99:
                        NinetyNineNotFound = false;
                        break;
                    default:
                        Console.WriteLine($"No Opcode found ERROR! {Location} {OpCode[Location]}");
                        break;
                }
            }
        }

        private void OpCodeOne(int OpCodeLocation)
        {
            int FirstIntLocation = OpCode[OpCodeLocation + 1];
            int SecondIntLocation = OpCode[OpCodeLocation + 2];
            int ThirdIntLocation = OpCode[OpCodeLocation + 3];
            OpCode[ThirdIntLocation] = OpCode[FirstIntLocation] + OpCode[SecondIntLocation];
        }

        private void OpCodeTwo(int OpCodeLocation)
        {
            int FirstIntLocation = OpCode[OpCodeLocation + 1];
            int SecondIntLocation = OpCode[OpCodeLocation + 2];
            int ThirdIntLocation = OpCode[OpCodeLocation + 3];
            OpCode[ThirdIntLocation] = OpCode[FirstIntLocation] * OpCode[SecondIntLocation];
        }

        private void PrintOpCode()
        {
            foreach (var item in OpCode)
            {
                Console.Write(item + ", ");
            }
        }
    }
}