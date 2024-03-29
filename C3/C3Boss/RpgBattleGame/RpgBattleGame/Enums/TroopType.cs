﻿namespace RpgBattleGame.Enums
{
    [Flags]
    internal enum TroopType
    {
        /// <summary>
        /// 無
        /// </summary>
        None = 0,

        /// <summary>
        /// 全部
        /// </summary>
        ALL = Ally | Enemy,

        /// <summary>
        /// 友軍
        /// </summary>
        Ally = 1,

        /// <summary>
        /// 敵軍
        /// </summary>
        Enemy = 2,

        /// <summary>
        /// 自己
        /// </summary>
        Self = 4,
    }
}
