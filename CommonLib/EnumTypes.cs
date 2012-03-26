using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    // ENUM: Direction
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Direction of travel on a map
    /// </summary>
    //-------------------------------------------------------------------------------------- 
    public enum Direction
    {
        East,
        Northeast,
        North,
        Northwest,
        West,
        Southwest,
        South,
        Southeast
    }

    // ENUM: TrackOrientation
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Orientation of track blocks
    /// </summary>
    //-------------------------------------------------------------------------------------- 
    public enum TrackOrientation
    {
        NorthSouth,
        EastWest,
        SouthWestNorthEast,
        NorthWestSouthEast
    }

    // ENUM: TrackSignalState
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// Signal state of track blocks
    /// </summary>
    //-------------------------------------------------------------------------------------- 
    public enum TrackSignalState
    {
        Red,
        Yellow,
        Green,
        SuperGreen
    }
}
