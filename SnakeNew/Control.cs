namespace SnakeApp
{
    public class Control
    {
        public string CheckInput(string? lastInput)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                switch (keyInfo.KeyChar)
                {
                    case 'w':
                        return "w";
                    case 's':
                        return "s";
                    case 'a':
                        return "a";
                    case 'd':
                        return "d";
                }
            }
            return lastInput;
        }
    }
}
