using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace mintstamper.Services;

public interface ICensorService
{
    string CensorText(string text, List<string> filterList);
    List<Stamp> HighlightFilteredWords(List<Stamp> stamps, List<string> filterList);
}

public class CensorService : ICensorService
{
    public string CensorText(string text, List<string> filterList)
    {
        foreach (var filteredWord in filterList)
        {
            string pattern = $@"\b{Regex.Escape(filteredWord)}\b";
            text = Regex.Replace(text, pattern, match => CensorWord(match.Value), RegexOptions.IgnoreCase);
        }

        return text;
    }

    private static string CensorWord(string word)
    {
        foreach (char c in word)
        {
            if ("aeiouAEIOU".Contains(c))
            {
                int censorIndex = word.IndexOf(c);
                return word.Remove(censorIndex, 1).Insert(censorIndex, "*");
            }
        }

        return word.Remove(0, 1).Insert(0, "*");
    }

    public List<Stamp> HighlightFilteredWords(List<Stamp> stamps, List<string> filterList)
    {
        foreach (var filteredWord in filterList)
        {
            foreach (Stamp stamp in stamps){
                if (stamp.Text.IndexOf(filteredWord, StringComparison.OrdinalIgnoreCase) != -1)
                {

                }
            }
        }
        return stamps;
    }
}
