using System;
using System.Linq;
using System.Net;

namespace Capital_Cities
{
    static class WikiParser
    {
        public static string FindCaptial(string stateName)
        {
            string Captial = string.Empty;
            stateName = FormatRequest(stateName);
            string rawPage = GetPage(stateName);
            if (!ValidateResponse(rawPage, stateName))
                return "requested state not found";
            Captial = ParsePage(rawPage, stateName);
            return Captial;
        }

        private static bool ValidateResponse(string response, string stateName)
        {
            if (response == "Error") return false;
            if (!response.Contains(stateName)) return false;
            return true;
        }

        private static string GetPage(string stateName)
        {
            try
            {
                WebClient client = new WebClient();
                return client.DownloadString("https://en.wikipedia.org/w/api.php?action=query&prop=revisions&format=json&rvprop=content&rvcontentformat=text%2Fx-wiki&titles=List_of_capitals_in_the_United_States");
            }
            catch
            {
                return "Error";
            }
        }

        private static string ParsePage(string rawPageText, string stateName)
        {
            string capitalCity = IsolateCapital(rawPageText, stateName);
            return capitalCity;
        }

        private static string IsolateCapital(string rawText, string stateName)
        {
            try
            {
                string split0 = String.Empty;
                if (rawText.Split(new string[] {"[[" + stateName + "]]"}, StringSplitOptions.None).Count() >= 2)
                    split0 = rawText.Split(new string[] {"[[" + stateName + "]]"}, StringSplitOptions.None)[1];
                else
                    split0 = rawText.Split(new string[] {"|" + stateName + "]]"}, StringSplitOptions.None)[1];
                string split1 = split0.Split(new string[] {"[["}, StringSplitOptions.None)[1];
                string Capital = split1.Split(new string[] {","}, StringSplitOptions.None).First();
                if (Capital.Contains("]]"))
                {
                    Capital = Capital.Split(new string[] {"]]"}, StringSplitOptions.None).First();
                }
            return Capital;
            }
            catch (Exception)
            {
                
                throw;
            }       
        }

        private static string FormatRequest(string rawRequest)
        {
            string formattedrequest = CapitalizeWords(rawRequest);
            return formattedrequest;
        }

        private static string CapitalizeWords(string rawRequest)
        {
            string formattedWords = string.Empty;
            string[] words = rawRequest.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (string word in words)
            {
                string captializedWord = CapitalizeFirstLetter(word);
                if (word != words.First())
                    formattedWords = formattedWords + " " + captializedWord;
                else
                    formattedWords = captializedWord;
            }
            return formattedWords;
        }

        private static string CapitalizeFirstLetter(string rawString)
        {
            char[] tempCharArray = rawString.ToCharArray();
            tempCharArray[0] = char.ToUpper(tempCharArray[0]);
            return new string(tempCharArray);
        }
    }
}
