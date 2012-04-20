using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLib
{
    public class Constants
    {
        public const string TRAINYARD = "YARD";
        public const string REDYARD = "REDYARD";
        public const string GREENYARDIN = "GREENYARDIN";
        public const string GREENYARDOUT = "GREENYARDOUT";
        public const string SPAWNTRAIN = "Spawn Train";
        public Dictionary<string, Direction> STARTING_DIRECTIONS = new Dictionary<string, Direction>(){
            {REDYARD, Direction.North}, {GREENYARDIN, Direction.Southwest}, {GREENYARDOUT, Direction.South} }; 
    }
}
