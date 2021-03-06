﻿namespace Dots
{
    /// <summary>
    ///     Holds all the constants and globally required values that are to be used in the game.
    /// </summary>
    public class GlobalConstants
    {
        /// <summary>
        ///     The number of colors
        /// </summary>
        public const int NumberOfColors = 5;

        /// <summary>
        ///     The maximum no of rows
        /// </summary>
        public const int MaxRows = 6;

        /// <summary>
        ///     The maximum no of items per row
        /// </summary>
        public const int MaxColumns = 6;

        /// <summary>
        ///     The dot to cell padding
        /// </summary>
        public const int DotToCellPadding = 20;

        /// <summary>
        ///     The scores for single dot destroyed
        /// </summary>
        public const int DotScores = 1;

        /// <summary>
        ///     The scores for square destroyed
        /// </summary>
        public const int SquareScores = 15;

        /// <summary>
        ///     The save game path
        /// </summary>
        public const string SavePath = Application.persistentDataPath + "/save.dobro";
    }

    /// <summary>
    ///     The type is used to define the type of dot.
    /// </summary>
    public enum DotTypes
    {
        None,
        Normal
    }
}
