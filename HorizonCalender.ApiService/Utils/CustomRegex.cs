using System.Text.RegularExpressions;

namespace HorizonCalender.ApiService.Utils;

public partial class CustomRegex
{
    public const string FullNameRegexPattern = @"^[\p{L}]+([ '-\.][\p{L}]+)*$";
    public const string FullNameRegexErrorMessage = "Please specify a full name.";

    [GeneratedRegex(FullNameRegexPattern)]
    public static partial Regex FullNameRegex();
}