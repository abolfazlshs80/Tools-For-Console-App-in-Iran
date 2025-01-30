using System.Text;

    public class RandomString
    {

      public  static string  GenerateRandomString(int length)
        {
            // تعریف کاراکترهایی که در رشته تصادفی می‌خواهیم استفاده کنیم
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // استفاده از Random برای تولید عدد تصادفی
            Random random = new Random();

            // استفاده از StringBuilder برای ساخت رشته
            StringBuilder result = new StringBuilder(length);

            // تولید رشته تصادفی
            for (int i = 0; i < length; i++)
            {
                // انتخاب تصادفی یک کاراکتر از رشته chars
                result.Append(chars[random.Next(chars.Length)]);
            }

            // تبدیل StringBuilder به رشته
            return result.ToString();
        }
    }

