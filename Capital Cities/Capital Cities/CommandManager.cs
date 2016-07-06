using System;
using System.Collections.Generic;

namespace Capital_Cities
{
    static class CommandManager
    {
        private static bool _exitRequested = false;
        private static readonly List<string> States = new List<string>();

        public static void Start()
        {
            States.Clear();
            PopulateStates();
            while (!_exitRequested)
            {
                ProcessRequests();
            }
        }

        private static void ProcessRequests()
        {
            string request = Console.ReadLine();
            ParseRequest(request);
        }

        private static void ParseRequest(string rawRequest)
        {
            string request = rawRequest.ToLower();
            switch (request)
            {
                case "help":
                    Help();
                    break;
                case "find":
                    FindCapital();
                    break;
                case "test":
                    Test();
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Command not recognized. type help for list of commands");
                    break;
            }
        }

        private static void Help()
        {
            Console.WriteLine("-------Available Commands-------");
            Console.WriteLine("find - used to find the capital city of a state.");
            Console.WriteLine("exit - used to close this application.");
            Console.WriteLine("test - used to test compatability with all 50 states.");
        }

        private static void FindCapital()
        {
            Console.WriteLine("input State Name");
            string request = Console.ReadLine();
            Console.WriteLine(WikiParser.FindCaptial(request));
        }

        private static void Test()
        {
            foreach (string state in States)
            {
                Console.WriteLine("testing: " + state);
                Console.WriteLine(WikiParser.FindCaptial(state));
                Console.WriteLine("---------------------------");
            }
            Console.WriteLine("Test Complete");
        }

        private static void Exit()
        {
            _exitRequested = true;
        }

        private static void PopulateStates()
        {
            string[] states = new[] {"alabama", "alaska", "arizona", "arkansas", "california", "colorado", "connecticut", "delaware",
                                          "florida", "georgia", "hawaii", "idaho", "illinois", "indiana", "iowa", "kansas", "kentucky",
                                          "louisiana", "maine", "maryland", "massachusetts", "michigan", "minnesota", "mississippi", "missouri",
                                          "montana", "nebraska", "nevada", "new hampshire", "new jersey", "new mexico", "new york", "north carolina",
                                          "north dakota", "ohio", "oklahoma", "oregon", "pennsylvania", "rhode island", "south carolina",
                                          "south dakota", "tennessee", "texas", "utah", "vermont", "virginia", "washington", "west virginia", "wisconsin", "wyoming"};

            foreach (string state in states)
            {
                States.Add(state);
            }
        }
    }
}
