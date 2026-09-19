public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of my day?",
        "What did I learn today?",
        "What made me happy today?",
        "What was something difficult today?",
        "What is something I want to improve tomorrow?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}