using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using Train;

namespace CTCOfficeGUI
{
    /// <summary>
    /// Interface for GUI to update status
    /// </summary>
    public interface ITrainSystemWatcher
    {
        void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains);
    }
}
