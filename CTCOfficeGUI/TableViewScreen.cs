using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using Train;

namespace CTCOfficeGUI
{
    public partial class TableViewScreen : Form, ITrainSystemWatcher
    {
        public TableViewScreen()
        {
            InitializeComponent();
            m_ctcController.Subscribe(this);
        }

        public void UpdateDisplay(List<TrackBlock> blocks, List<ITrain> trains)
        {

        }

        List<TrackBlock> m_blockList;
        List<ITrain> m_trainList;
        CTCController m_ctcController = CTCController.GetCTCController();
    }
}
