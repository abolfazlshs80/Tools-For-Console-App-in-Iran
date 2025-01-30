using System.Text;

namespace IranianApp.KhoshgelonasionLibrary.Service
{
    public class DynamicTable
    {
        private List<string> headers;
        private List<List<string>> rows;

        public DynamicTable(List<string> headers)
        {
            this.headers = headers;
            this.rows = new List<List<string>>();
        }

        // اضافه کردن یک ردیف جدید
        public void AddRow(List<string> row)
        {
            if (row.Count != headers.Count)
                throw new ArgumentException("تعداد مقادیر در ردیف باید برابر با تعداد ستون‌ها باشد.");

            rows.Add(row);
        }

        // تبدیل جدول به رشته و نمایش آن
        public string GetFormattedTable()
        {
            if (headers == null || headers.Count == 0 || rows == null)
                return "خطا: داده‌ای برای نمایش در جدول وجود ندارد.";

            int columnCount = headers.Count;

            // محاسبه عرض هر ستون
            int[] columnWidths = headers.Select(h => h.Length).ToArray();
            foreach (var row in rows)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    if (i < row.Count)
                        columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                }
            }

            // تابع کمکی برای ایجاد خطوط جداکننده
            string CreateSeparator() =>
                "+" + string.Join("+", columnWidths.Select(w => new string('-', w + 2))) + "+";

            StringBuilder table = new StringBuilder();
            table.AppendLine(CreateSeparator());

            // اضافه کردن هدر
            table.AppendLine("| " + string.Join(" | ", headers.Select((h, i) => h.PadRight(columnWidths[i]))) + " |");
            table.AppendLine(CreateSeparator());

            // اضافه کردن ردیف‌ها
            foreach (var row in rows)
            {
                table.AppendLine("| " + string.Join(" | ", row.Select((cell, i) => cell.PadRight(columnWidths[i]))) + " |");
            }

            table.AppendLine(CreateSeparator());
            return table.ToString();
        }
    }
    public class MessageFormatter
        {
            public enum MessageType { Info, Warning, Error }

            public string FormatPlainText(string message, MessageType type)
            {
                return $"[{type}] {message}";
            }

            public string FormatJson(string message, MessageType type)
            {
                var obj = new { Type = type.ToString(), Message = message, Timestamp = DateTime.Now };
                return System.Text.Json.JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            }

            public string FormatXml(string message, MessageType type)
            {
                var xml = new System.Xml.Linq.XElement("Log",
                    new System.Xml.Linq.XElement("Type", type.ToString()),
                    new System.Xml.Linq.XElement("Message", message),
                    new System.Xml.Linq.XElement("Timestamp", DateTime.Now));
                return xml.ToString();
            }

            public string FormatTable(List<string> headers, List<List<string>> rows)
            {
                if (headers == null || headers.Count == 0 || rows == null || rows.Count == 0)
                    return "خطا: داده‌ای برای نمایش در جدول وجود ندارد.";

                int columnCount = headers.Count;

                // محاسبه عرض هر ستون
                int[] columnWidths = headers.Select(h => h.Length).ToArray();
                foreach (var row in rows)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (i < row.Count)
                            columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                    }
                }

                // تابع کمکی برای ایجاد خطوط جداکننده
                string CreateSeparator() =>
                    "+" + string.Join("+", columnWidths.Select(w => new string('-', w + 2))) + "+";

                StringBuilder table = new StringBuilder();
                table.AppendLine(CreateSeparator());

                // اضافه کردن هدر
                table.AppendLine("| " + string.Join(" | ", headers.Select((h, i) => h.PadRight(columnWidths[i]))) + " |");
                table.AppendLine(CreateSeparator());

                // اضافه کردن ردیف‌ها
                foreach (var row in rows)
                {
                    table.AppendLine("| " + string.Join(" | ", row.Select((cell, i) => cell.PadRight(columnWidths[i]))) + " |");
                }

                table.AppendLine(CreateSeparator());
                return table.ToString();
            }
        }
    

}