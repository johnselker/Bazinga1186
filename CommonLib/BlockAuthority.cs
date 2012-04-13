using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
	public class BlockAuthority
	{
		public int SpeedLimitKPH;
		public int Authority;

        public BlockAuthority(int speedLimit, int authority)
        {
            SpeedLimitKPH = speedLimit;
            Authority = authority;
        }
	}
}
