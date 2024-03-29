﻿using Big2.Models;

namespace Big2.Strategies.CardCompare
{
    public abstract class CompareStrategy
    {

        public abstract int Compare(IEnumerable<Card> topPlayCards, IEnumerable<Card> playCards);
    }
}