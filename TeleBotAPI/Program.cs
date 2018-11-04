using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeleBotAPI;
using TeleBotAPI.DB;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeleBotAPI
{
    class Program
    {
        public static String TOKEN = "670025645:AAFpfE3q0uNgzEdsTouji-RtBduvFgzej08";
        private static readonly TelegramBotClient Bot = new TelegramBotClient(TOKEN);
        static void Main(string[] args)
        {
            Bot.StartReceiving();
            Bot.OnMessage += Bot_OnMessage;
            Bot.OnMessageEdited += Bot_OnMessageEdited;
            Bot.OnCallbackQuery += Bot_OnCallbackQuery;
            Bot.OnInlineQuery += Bot_OnInlineQuery;
            Bot.OnInlineResultChosen += Bot_OnInlineResultChosen;
            Bot.OnReceiveError += Bot_OnReceiveError;
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void Bot_OnReceiveError(object sender, ReceiveErrorEventArgs e)
        {

            Console.WriteLine("Received error: {0} — {1}",
                e.ApiRequestException.ErrorCode,
                e.ApiRequestException.Message);
        }

        private static void Bot_OnInlineResultChosen(object sender, ChosenInlineResultEventArgs e)
        {
            Console.WriteLine($"Received inline result: {e.ChosenInlineResult.ResultId}");
        }

        private static async void Bot_OnInlineQuery(object sender, InlineQueryEventArgs e)
        {
            Console.WriteLine($"Received inline query from: {e.InlineQuery.From.Id}");

            InlineQueryResultBase[] results = {
                new InlineQueryResultLocation(
                    id: "1",
                    latitude: 40.7058316f,
                    longitude: -74.2581888f,
                    title: "New York")   // displayed result
                    {
                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 40.7058316f,
                            longitude: -74.2581888f)    // message if result is selected
                    },

                new InlineQueryResultLocation(
                    id: "2",
                    latitude: 13.1449577f,
                    longitude: 52.507629f,
                    title: "Berlin") // displayed result
                    {

                        InputMessageContent = new InputLocationMessageContent(
                            latitude: 13.1449577f,
                            longitude: 52.507629f)   // message if result is selected
                    }
            };
            await Bot.AnswerInlineQueryAsync(
                e.InlineQuery.Id,
                results,
                isPersonal: true,
                cacheTime: 0);
        }

        private static async void Bot_OnCallbackQuery(object sender, CallbackQueryEventArgs e)
        {
            var callbackQuery = e.CallbackQuery;

            await Bot.AnswerCallbackQueryAsync(
                callbackQuery.Id,
                $"Received {callbackQuery.Data}");

            await Bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Received {callbackQuery.Data}");
        }

        private static async void Bot_OnMessageEdited(object sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text.Split(' ').First())
            {
                // send inline keyboard
                case "/inline":
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(500); // simulate longer running task

                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new [] // first row
                        {
                            InlineKeyboardButton.WithCallbackData("1.1"),
                            InlineKeyboardButton.WithCallbackData("1.2"),
                        },
                        new [] // second row
                        {
                            InlineKeyboardButton.WithCallbackData("2.1"),
                            InlineKeyboardButton.WithCallbackData("2.2"),
                        }
                    });

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Choose",
                        replyMarkup: inlineKeyboard);
                    break;

                // send custom keyboard
                case "/keyboard":
                    ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "1.1", "1.2" },
                        new[] { "2.1", "2.2" },
                    };

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Choose",
                        replyMarkup: ReplyKeyboard);
                    break;

                // send a photo
                case "/photo":
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                    const string file = @"Files/tux.png";

                    var fileName = file.Split(Path.DirectorySeparatorChar).Last();

                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        await Bot.SendPhotoAsync(
                            message.Chat.Id,
                            fileStream,
                            "Nice Picture");
                    }
                    break;

                // request location or contact
                case "/request":
                    var RequestReplyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        KeyboardButton.WithRequestLocation("Location"),
                        KeyboardButton.WithRequestContact("Contact"),
                    });

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        "Who or Where are you?",
                        replyMarkup: RequestReplyKeyboard);
                    break;

                default:
                    const string usage = @"
Usage:
/inline   - send inline keyboard
/keyboard - send custom keyboard
/photo    - send a photo
/request  - request location or contact";

                    await Bot.SendTextMessageAsync(
                        message.Chat.Id,
                        usage,
                        replyMarkup: new ReplyKeyboardRemove());
                    break;
            }
        }
        public async static Task SendPhoto(string chatId, string filePath, string token)
        {
            var url = string.Format("https://api.telegram.org/bot{0}/sendPhoto", token);
            var fileName = filePath.Split('\\').Last();

            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId.ToString(), Encoding.UTF8), "chat_id");

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    form.Add(new StreamContent(fileStream), "photo", fileName);

                    using (var client = new HttpClient())
                    {
                        await client.PostAsync(url, form);
                    }
                }
            }
        }
        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                if (e.Message.Text.Equals("/hello"))
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hallo " + e.Message.From.FirstName +" nih tak ksh gambar");
                    
                    string path = Directory.GetCurrentDirectory() + "//akakom.png";
                    if (File.Exists(path))
                    {
                        SendPhoto(e.Message.Chat.Id.ToString(), path, TOKEN);
                    }
                }
                else if (e.Message.Text.Equals("/absen"))
                {
                    //ABSENSI_HRDBEntities db = new ABSENSI_HRDBEntities();
                    //List<tAbsenUser_mobile> user = db.tAbsenUser_mobile.ToList();
                    //List<String> Namas = new List<string>();
                    //if (user.Count > 0)
                    //{
                    //    foreach (tAbsenUser_mobile a in user)
                    //    {
                    //        Bot.SendTextMessageAsync(e.Message.Chat.Id, a.txtUserId);
                    //    }
                    //}else
                    //{
                    //    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Not Found");
                    //}

                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Not Found");
                }
                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello " + e.Message.From.FirstName);

                }

        }
    }
}
