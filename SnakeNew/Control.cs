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
                        if (lastInput == "s")
                        {
                            break;
                        }
                        return "w";
                    case 's':
                        if (lastInput == "w")
                        {
                            break;
                        }
                        return "s";
                    case 'a':
                        if (lastInput == "d")
                        {
                            break;
                        }
                        return "a";
                    case 'd':
                        if (lastInput == "a")
                        {
                            break;
                        }
                        return "d";
                }
            }
            return lastInput;
        }
    }
}
