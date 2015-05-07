namespace ViewModel.Models
{
    public class Hello
    {
        public static string Greeting(string name)
        {
            var value = string.IsNullOrWhiteSpace(name) ? "Guest" : name;
            return string.Format("Hello {0}!", value.Trim());
        }
    }
}
