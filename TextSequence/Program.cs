using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextSequence
{
    class Program
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        static int Main(string[] args)
        {
            //args: path floor ceiling limit

            //want to detect all sequences of a certain length or length range in a set of chars and then report those sequences
            //parms = 
            //floor: int value of the sequence length floor to look for - default of 0
            //ceiling: int value of the sequence length cieling to look for - default of set length
            //might need a limit to the number of returned values

            if (args[0] == "-h" || args[0] == "-help")
            {
                Logger.Info("Command should be in the form: TextSequence.exe [Path] [Floor] [Ceiling] [*Limit] *optional \n EX: TextSequence.exe C:/mydoc.doc 5 6 10");
                return 1;
            }
            else
            {
                try
                {
                    Logger.Info("Starting operation.");
                    var control = new Control(args);
                    Logger.Info("All arguments processed.");
                    Logger.Info("Starting search.");
                    var jsonResult = GetStream(control.Path).FindSequences(control.Floor, control.Ceiling, control.Limit);
                    Console.WriteLine(jsonResult);
                    Logger.Info("Operation complete");
                    return 0;
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                    return -1;
                }
            }
        }

        private static string GetStream(string filePath)
        {
            using (var stream = new StreamReader(filePath))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
