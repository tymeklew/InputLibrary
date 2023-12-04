namespace Input;
public static class Get
{
   public static T Single<T>(string prompt)
   {
      do
      {
         Console.Write(prompt);
         string? input = string.Empty;
         input = Console.ReadLine();
         if (string.IsNullOrEmpty(input))
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Must enter value");
            Console.ResetColor();
            Console.ReadKey();
            continue;
         }
         try
         {
            return (T)Convert.ChangeType(input, typeof(T));
         }
         catch
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Input must be of type ({typeof(T).Name})");
            Console.ResetColor();
            Console.ReadKey();
         }
      } while (true);
   }
   public static T MultiSelect<T>(string prompt, T[] options) where T : IComparable
   {
      string multiString = string.Concat("", string.Join(',', options.Select(t => Convert.ToString(t))));
      do
      {
         Console.Write(prompt);
         T input = Single<T>("");
         if (options.Contains(input)) return input;
         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine($"Input must be one of : {multiString} ");
         Console.ResetColor();
         Console.ReadKey();
      } while (true);
   }
   public static bool Confirm(string prompt)
   {

      do
      {
         Console.Write(prompt);
         string? input = string.Empty;
         input = Console.ReadLine();

         if (string.IsNullOrEmpty(input))
         {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Must enter value");
            Console.ResetColor();
            Console.ReadKey();
         }
         switch (input)
         {

            case "Y":
            case "y":
               return true;
            case "N":
            case "n":
               return false;
            default:
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine("Invalid input");
               Console.ResetColor();
               Console.ReadKey();
               break;
         }

      } while (true);
   }
}
