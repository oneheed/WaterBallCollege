﻿using Big2.Models;

namespace Big2.Strategies.CardCompare
{
    public class WinOutrightCompareStrategy : CompareStrategy
    {
        public override int Compare(IEnumerable<Card> topPlayCards, IEnumerable<Card> playCards)
        {
            return 1;
        }
    }
}
