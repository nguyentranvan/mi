using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MI.Helpers.Lib
{
    public class StringHelper
    {
        public static string ConvertStringToVNDash(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput)) return string.Empty;
            stringInput = stringInput.ToLower();
            var extension = Path.GetExtension(stringInput).ToLower();
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(stringInput);
            fileNameWithoutExt = fileNameWithoutExt.Replace(" ", "-").Replace("/", "-").Replace("\\", "-").Replace(",", "").Replace("[", "").Replace("]", "");
            fileNameWithoutExt = utf8ConvertPro(fileNameWithoutExt);
            return Regex.Replace(fileNameWithoutExt, @"[`!&\/\\#+()$~%@:*?<>{ }|,.'=]", "") + extension;
        }
        public static string utf8ConvertPro(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, string.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
