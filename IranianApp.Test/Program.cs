// See https://aka.ms/new-console-template for more information

using IranianApp.KhoshgelonasionLibrary.Service;

Console.WriteLine("Hello, World!");

#region message formater


//MessageFormatter formatter = new MessageFormatter();

//// نمایش پیام‌های متنی
//Console.WriteLine(formatter.FormatPlainText("this is a message is info", MessageFormatter.MessageType.Info));

//// نمایش پیام در قالب JSON
//Console.WriteLine("\nJSON Format:\n" + formatter.FormatJson("this is a message is JSON  ", MessageFormatter.MessageType.Info));

//// نمایش پیام در قالب XML
//Console.WriteLine("\nXML Format:\n" + formatter.FormatXml("this is a message is XML", MessageFormatter.MessageType.Warning));

//// نمایش جدول پویا
//var headers = new List<string> { "type", "Message", "Time" };
//var tableData = new List<List<string>>
//{
//    new List<string> { "Error", "Error database", "12:30 PM" },
//    new List<string> { "Warning", "Error for storage", "12:31 PM" },
//    new List<string> { "Info", "Start App", "12:32 PM" }
//};

//Console.WriteLine("\nTable Format:");
//Console.WriteLine(formatter.FormatTable(headers, tableData));
#endregion

#region Dynamic Convertor

//// Define table headers
//var headers1 = new List<string> { "Level", "Message", "Time" };
//var table = new DynamicTable(headers1);

//// Add initial rows
//table.AddRow(new List<string> { "Error", "Database connection failed", "12:30 PM" });
//table.AddRow(new List<string> { "Warning", "High memory usage", "12:31 PM" });
//table.AddRow(new List<string> { "Info", "Application started", "12:32 PM" });

//// Display the initial table
//Console.WriteLine("\nInitial Table:");


//// Dynamically add a new row at runtime
//table.AddRow(new List<string> { "Debug", "System log check", "12:33 PM" });
//table.AddRow(new List<string> { "Debug", "System log check", "12:33 PM" });
//table.AddRow(new List<string> { "Debug", "System log check", "12:33 PM" });
//Console.WriteLine(table.GetFormattedTable());
//// Display the table after adding a new row
//Console.WriteLine("\nTable after adding a new row");

#endregion

#region UseTools
#endregion
void ListProducts()
{
    ConsoleDesign.ShowMessage("Displaying list of products...", ConsoleColor.Yellow);
}

  void ShowCart()
{
    ConsoleDesign.ShowMessage("Showing shopping cart...", ConsoleColor.Blue);
}

  void AddToCart()
{
    ConsoleDesign.ShowMessage("Adding product to cart...", ConsoleColor.Green);
}

  void Checkout()
{
    ConsoleDesign.ShowMessage("Processing checkout...", ConsoleColor.Magenta);
}

var shopMenu = new Dictionary<string, Action>
{
    { "List Of Products", ListProducts },
    { "Shopping Cart", ShowCart },
    { "Add Product To Cart", AddToCart },
    { "Buy Product", Checkout }
};

ConsoleDesign.ShowMenu("Shop Menu", shopMenu);


