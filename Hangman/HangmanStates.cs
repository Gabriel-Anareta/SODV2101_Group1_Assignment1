using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public static class HangmanStates
    {
        public static string GetState(int counter)
        {
            string baseState =
                "------------ \n" +
                "|          | \n" +
                "|            \n" +
                "|            \n" +
                "|            \n" +
                "|            \n" +
                "|            \n" +
                "|_";

            char[] baseStateArr = baseState.ToCharArray();

            if (counter > 0)
                baseStateArr[39] = 'O';
            if (counter > 1)
                baseStateArr[53] = '|';
            if (counter > 2)
                baseStateArr[52] = '/';
            if (counter > 3)
                baseStateArr[54] = '\\';
            if (counter > 4)
                baseStateArr[67] = '|';
            if (counter > 5)
                baseStateArr[80] = '/';
            if (counter > 6)
                baseStateArr[82] = '\\';

            return new string(baseStateArr);
        }
    }
}
