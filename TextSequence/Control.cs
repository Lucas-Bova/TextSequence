using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TextSequence
{
    class Control
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public string Path { get; set; }
        public int Floor { get; set; }
        public int Ceiling { get; set; }
        public int Limit { get; set; }
        public Control(string[] args)
        {
            Limit = 100;
            ProcessArgs(args);
            ParameterCheck();
        }
        private void ProcessArgs(string[] args)
        {
            if (!File.Exists(args[0]))
            {
                Logger.Error($"{args[0]} is not a valid file path");
                throw new Exception("Invalid argument");
            }
            Path = args[0];
            var floor = 0;
            if (!int.TryParse(args[1], out floor))
            {
                Logger.Error($"{args[1]} is not a valid integer");
                throw new Exception("Invalid argument");
            }
            Floor = floor;
            var ceiling = 0;
            if (!int.TryParse(args[2], out ceiling))
            {
                Logger.Error($"{args[2]} is not a valid integer");
                throw new Exception("Invalid argument");
            }
            Ceiling = ceiling;
            if (args.Length > 3)
            {
                var limit = 0;
                if (!int.TryParse(args[3], out limit))
                {
                    Logger.Error($"{args[3]} is not a valid integer");
                    throw new Exception("Invalid argument");
                }
                Limit = limit;
            }
        }

        private void ParameterCheck()
        {
            var rangeMessage = " is outside of the expected range of 0-100";
            if (Floor < 0 || Floor > 100)
            {
                Logger.Info(Floor + rangeMessage);
                throw new Exception("Invalid argument");
            }
            if (Ceiling < 0 || Ceiling > 100)
            {
                Logger.Info(Ceiling + rangeMessage);
                throw new Exception("Invalid argument");
            }
            if (Limit < 0 || Limit > 1000)
            {
                Logger.Error(Limit + rangeMessage);
                throw new Exception("Invalid argument");
            }
            if (Floor > Ceiling)
            {
                Logger.Error("Floor cannot be greater than Ceiling");
                throw new Exception("Invalid argument");
            }
        }
    }
}
