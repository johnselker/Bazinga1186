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

	// ENUM: TrackSwitchState
	//--------------------------------------------------------------------------------------
	/// <summary>
	/// The state of a switch track block.
	/// </summary>
	//-------------------------------------------------------------------------------------- 
	public enum TrackSwitchState
	{
		Throwing,
		Closed
	}

    // ENUM: TrackAllowedDirection
    //--------------------------------------------------------------------------------------
    /// <summary>
    /// The allowed direction of travel on the track block
    /// </summary>
    /// 
    /// <remarks>
    /// "Left" is considered to the left of the y axis on the xy plane, or -y if track block
    /// is vertical
    /// </remarks>
    //-------------------------------------------------------------------------------------- 
    public enum TrackAllowedDirection
    {
        LeftToRight,
        RightToLeft,
        Both
    }
}
