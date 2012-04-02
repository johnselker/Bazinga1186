using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTCOfficeGUI
{
    /// <summary>
    /// Enums for track block commands
    /// </summary>
    public enum TrackBlockCommands
    {
        SuggestSpeedLimit,
        SuggestAuthority,
        CloseBlock,
        OpenBlock
    }

    /// <summary>
    /// Enums for train commands
    /// </summary>
    public enum TrainCommands
    {
        SuggestRoute,
        SetSchedule
    }
}
