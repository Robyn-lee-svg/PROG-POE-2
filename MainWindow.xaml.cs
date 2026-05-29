using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Media;
using System.Windows;

namespace CybersecurityBot
{
    public partial class MainWindow : Window
    {
        Random random = new Random();
        String userName = "User";
        String lastTopic = "";
        private String rememberTopic = "";
        private String[] phishingTips =
        {
            "Be cautious of  emails, especially those asking for personal information.\n"+
            "Don't click on suspicious links or download attachments from unknown sources.\n"+
            "Always verify the sender before opening or responding to an email.\n"+
            "Block any suspious email or messages."\n"
        };
        public MainWindow()
        {
            InitializeComponent();
            PlayGreeting();

            BotReply("Hello! I'm your Cybersecurity Awarness Bot BOBO Dogg.");
            BotReply("You may ask me about passwords, phishing, scams, or computer privacy.");
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            String input = UserInput.Text.ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                BotReply("Please enter a message.");
                return;
            }
            ChatDisplay.Text += "\nYou:" + UserInput.Text;

            if (input.Contains("password"))
            {
                lastTopic = "Password";
                BotReply("Please remember to use strong passswords that include a mix of  letters,numbers, and special characters.");

            }
            else if (input.Contains("phishing") ||  input.Contains("scam"))
            {
                lastTopic = "phishing";
                BotReply(phishingTips[random.Next(phishingTips.Length)]);

            }   
            else if (input.Contains("privacy"))
            {
                lastTopic = "privacy";
                BotReply("Always be cautious about the information you share online.\n" +
                    "Always review the pivacy settings on your social media accounts.\n" +
                    "Be extra cautious about the apps you download and the permissions they request.\n");
            }
            else if (input.Contains("scam"))
            {
                lastTopic = "scam";
                BotReply("Scammers often use urgent language to pressure you into making quick decisions.\n"+
                    "Be skeptical of unsolicited offers or requests for personal information or money.\n"+
                    "Alwaya verify the legitimacy of a company or individuals before interacting with them.\n");

            }
            else if (input.Contains("safe browsing"))
            {
                lastTopic = "Safe Browsing";
                BotReply("Make sure that you are using a secure and up-to-date web browser.\n"+
                    "Be cautious when clicking on links, especially from unknown sources.\n"+
                    "Always look for padlock icon in the address bar to sensure that the website is secure (HTTPS).\n");
            }
            else if (input.Contains("another tip"))
            {
                BotReply(phishingTips[random.Next(phishingTips.Length)]);
            }
            else
            {
                BotReply("Please specify which topic you would like anothor tip on. You can ask about 'passwords', 'phishing', 'scamming', or 'privacy'.");
            }
        }
        private void ProcessInput(string input)
        {
            try
            {
                string userInput = input.ToLower().Trim();
                if (userInput == "exit" || userInput == "quite" || userInput == "Goodbye")
                {
                    BotReply("Goodbye! Stay safe online!");
                    Application.Current.Shutdown();
                    return;
                }
                if (userInput.Contains("Hello") || userInput.Contains("Hi") || userInput.Contains("Hey"))
                {
                    BotReply($"Hello there {userName}! How can I assist you with cybersecurity today?");
                    return;
                }
                if (userInput.Contains("purpose") || userInput.Contains("what can you do?"))
                {
                    BotReply("I'm here to provide you with tips and information about cybersecurity");
                    return;
                }
                if (userInput.Contains("worried") || userInput.Contains("Scared") || userInput.Contains("Angrey"))
                {
                    BotReply("I'm sorry to hear that you are feeling this way." +
                        "Remember being informed about cybersecurity can help you feel more confident and secure online.");
                    return;
                }
                if (userInput.Contains("intrested in"))
                {
                    string[] parts = userInput.Split(new string[] { "intrested in" }, StringSplitOptions.None);
                    if (parts.Length > 1)
                    {
                        rememberTopic = parts[1].Trim();
                        BotReply($"Perfect! I will remember that you are intrested in {rememberTopic}.");
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(rememberTopic) && userInput.Contains("reccomend"))
                {
                    BotReply("$ Seeing as you are intrested in {rememberTopic}, I would recommend looking into online courses or books on that topic.");
                    return;
                }
            }
            catch (Exception  ex)
            {
                BotReply(ex.Message);
            }   } 


            
            

             
        private void BotReply(string message)
        {
            ChatDisplay.Text += "\nBOBO DOGG: " + message;
        }










     
    private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Load();
            }
            catch
            {
                MessageBox.Show("Greeting audio file not found.");
            }

        }


    }   }    
        

        































    
   












