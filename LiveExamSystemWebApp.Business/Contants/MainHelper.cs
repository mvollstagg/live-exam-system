
namespace LiveExamSystemWebApp.Business.Contants;

public class MainHelper
{
    public static string GenerateFirstLetterOfValue(string value)
    {
        string firstLetter = value.Trim()[0].ToString().ToLower();
        string defaultLetter = "a";

        switch (firstLetter)
        {
            case "ç":
                return "c";
            case "ə":
                return "e";
            case "ğ":
                return "g";
            case "ı":
                return "i";
            case "ö":
                return "o";
            case "ş":
                return "s";
            case "ü":
                return "u";
            case "0":
                return defaultLetter;
            case "1":
                return defaultLetter;
            case "2":
                return defaultLetter;
            case "3":
                return defaultLetter;
            case "4":
                return defaultLetter;
            case "5":
                return defaultLetter;
            case "6":
                return defaultLetter;
            case "7":
                return defaultLetter;
            case "8":
                return defaultLetter;
            case "9":
                return defaultLetter;
            default:
                return firstLetter;
        }
    }
    public static string GetMonthByDigit(string lang, int month)
    {
        if(lang.ToLower() == "az")
        {
            switch (month)
            {
                case 1:
                    return "yanvar";
                case 2:
                    return "fevral";
                case 3:
                    return "mart";
                case 4:
                    return "aprel";
                case 5:
                    return "may";
                case 6:
                    return "iyun";
                case 7:
                    return "iyul";
                case 8:
                    return "avqust";
                case 9:
                    return "sentyabr";
                case 10:
                    return "oktyabr";
                case 11:
                    return "noyabr";
                case 12:
                    return "dekabr";
                default:
                    return "yanvar";
            }
        }
        else if(lang.ToLower() == "ru")
        {
            switch (month)
            {
                case 1:
                    return "январь";
                case 2:
                    return "февраль";
                case 3:
                    return "март";
                case 4:
                    return "апрель";
                case 5:
                    return "май";
                case 6:
                    return "июнь";
                case 7:
                    return "июль";
                case 8:
                    return "август";
                case 9:
                    return "сентябрь";
                case 10:
                    return "октябрь";
                case 11:
                    return "ноябрь";
                case 12:
                    return "декабрь";
                default:
                    return "январь";
            }
        }
        else
        {
            switch (month)
            {
                case 1:
                    return "january";
                case 2:
                    return "february";
                case 3:
                    return "march";
                case 4:
                    return "april";
                case 5:
                    return "may";
                case 6:
                    return "june";
                case 7:
                    return "july";
                case 8:
                    return "august";
                case 9:
                    return "september";
                case 10:
                    return "october";
                case 11:
                    return "november";
                case 12:
                    return "december";
                default:
                    return "january";
            }
        }
    }
}