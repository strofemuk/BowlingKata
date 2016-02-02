using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class FrameCollection : List<Frame>
    {
        public int Score()
        {
            int score = 0;

            for (int frame = 0; frame < this.Count; frame++)
            {
                if (!this[frame].IsBonus)
                {
                    if (this[frame].IsStrike)
                        score += CalculateStrikeScore(frame);
                    else if (this[frame].IsSpare)
                    {
                        score += CalculateSpareScore(frame);
                    }
                    else
                    {
                        score += this[frame].FrameSum;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("BONUS");
                }

            }

            return score;
        }

        private int CalculateStrikeScore(int startingIndex)
        {
            int strikeScore = 10;

            if (startingIndex + 1 < this.Count())
            {
                strikeScore += this[startingIndex + 1].FirstThrow;
                if (this[startingIndex + 1].IsStrike)
                {
                    if (startingIndex + 2 < this.Count())
                    {
                        strikeScore += this[startingIndex + 2].FirstThrow;
                    }
                }
            }
            return strikeScore;
        }

        private int CalculateSpareScore(int startingIndex)
        {
            int spareScore = 10;
            if (startingIndex != this.Count)
            {
                spareScore += this[startingIndex + 1].FirstThrow;
            }
            return spareScore;
        }
    }
}
