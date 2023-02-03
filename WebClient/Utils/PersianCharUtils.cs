namespace WebClient.Utils
{
    internal static class PersianCharUtils
    {
        internal static string ArToFaNumber(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return numbers;
            char[] find = { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };
            char[] replace = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            for (var i = 0; i < find.Length; i++)
            {
                numbers = numbers.Replace(find[i], replace[i]);
            }
            return numbers;
        }
        
        internal static string FaToEnNumber(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers)) return numbers;
            char[] find = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            char[] replace = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (var i = 0; i < find.Length; i++)
            {
                numbers = numbers.Replace(find[i], replace[i]);
            }
            return numbers;
        }
    }
}