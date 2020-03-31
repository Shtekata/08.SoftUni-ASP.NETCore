namespace MyFirstAspNetCoreApp.Services
{
    public class StringManipulation : IStringManipulation
    {
        public string MakeFirstLetterUpper(string input)
        {
            if(input == null)
            {
                return null;
            }

            if (input.Length == 1)
            {
                return input.ToUpper();
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }
}
