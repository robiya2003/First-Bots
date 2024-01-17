using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.IO;
using Telegram.Bot.Requests;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp1.Xabarlar
{
    public class MessageClasss
    {
        
        public static async Task MessageAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message=update.Message;
            if (JsonDatabazaClasss.Checking(update.Message.Chat.Id) && update.Message.Type != MessageType.Contact)
            {
                ReplyKeyboardMarkup markup =
                    new ReplyKeyboardMarkup
                        (KeyboardButton.WithRequestContact("Contact yuborish"));
                markup.ResizeKeyboard = true;
                await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Contact",
                        replyMarkup: markup
                );
                return;
            }
            else
            {
                var handler = message.Type switch
                {
                    MessageType.Text => TextAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Photo => PhotoAsyncFunctionPost(botClient, update, cancellationToken),
                    MessageType.Video => VideoAsyncFunction(botClient, update, cancellationToken),
                    MessageType.VideoNote => VideoNoteAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Document => DopcumentAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Sticker => StikerAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Audio => AudioAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Voice => VoiceAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Animation => AnimationAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Poll => PollAsyncFunction(botClient, update, cancellationToken),
                    MessageType.Contact => ContactAsyncFunction(botClient, update, cancellationToken),
                    _ => OtherAsyncFunctiob()
                };
            }
        }
        static async Task TextAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
                var message = update.Message;
            #region GETME GET ALL
            if (message.Text == "/getme")
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: JsonDatabazaClasss.GetMe(message.Chat.Id),
                cancellationToken: cancellationToken);
            }
            else if (message.Text == "/getall")
            {
                string s;
                List<Userr> userrs =JsonDatabazaClasss.GetAll();
                foreach (Userr userr in userrs)
                {
                    s = "Chat Id" + userr.chatid + "\nName : " + userr.firstname + "\nPhone Number : " + userr.phonenumber;
                    Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    replyToMessageId: message.MessageId,
                    text: s,
                    cancellationToken: cancellationToken);
                }

            }
            #endregion
            else
            {
                Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                text: message.Text,
                replyMarkup:new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
            }
            
            
        }
        #region SEND ALL REPLY FUNCTIONS
        static async Task PhotoAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                photo:InputFile.FromUri("https://media.istockphoto.com/id/1299986427/photo/silhouette-of-asian-woman-standing-against-dark-corridor-in-a-park.jpg?s=612x612&w=0&k=20&c=QEAmWtDh8gK8b2hCy98GLQf2XR7vwImyNmPP2lszWRs="),
                cancellationToken: cancellationToken);
        }
        static async Task VideoAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await using Stream stream = System.IO.File.OpenRead(@"C:\Users\LENOVO\Desktop\fayllar\321548907_1068526601057408_6507867890495415380_n.mp4");
            var message = update.Message;
            Message sentMessage = await botClient.SendVideoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                //video: InputFile.FromUri("https://raw.githubusercontent.com/TelegramBots/book/master/src/docs/video-countdown.mp4"),
                video:InputFile.FromStream(stream),
                supportsStreaming:true,
                cancellationToken: cancellationToken);
        }
        static async Task VideoNoteAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendVideoNoteAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                videoNote: InputFile.FromFileId(message.VideoNote!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task DopcumentAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendDocumentAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                document: InputFile.FromFileId(message.Document!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task StikerAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
                   
            
            var message = update.Message;
            Message sentMessage = await botClient.SendStickerAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                sticker:InputFile.FromFileId(message.Sticker!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task AudioAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendAudioAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                audio:InputFile.FromFileId(message.Audio!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task VoiceAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendVoiceAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                voice:InputFile.FromFileId(message.Voice!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task AnimationAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendAnimationAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                animation:InputFile.FromFileId(message.Animation!.FileId),
                cancellationToken: cancellationToken);
        }
        static async Task PollAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            await botClient.SendPollAsync(
            chatId: update.Message.Chat.Id,
            question: "C# qiziqroqmi?",
            options: new[]
            {
                "Ha",
                "Yo'q"
            }
        );
        }
        static async Task ContactAsyncFunction(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message.Type == MessageType.Contact)
            {
                if (JsonDatabazaClasss.Checking(update.Message.Chat.Id))
                {
                    JsonDatabazaClasss.Apppend(update.Message.Chat.Id, update.Message.Contact.FirstName, update.Message.Contact.PhoneNumber);
                    var message = update.Message;
                    Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    replyToMessageId: message.MessageId,
                    text: "Hush kelibsiz : \n" + JsonDatabazaClasss.GetMe(message.Chat.Id),
                    replyMarkup: new ReplyKeyboardRemove(),
                    cancellationToken: cancellationToken);
                }

            }
        }
        #endregion
        static async Task PhotoAsyncFunctionPost(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            Message sentMessage = await botClient.SendPhotoAsync(
                chatId: message.Chat.Id,
                replyToMessageId: message.MessageId,
                photo: InputFile.FromUri("https://media.istockphoto.com/id/1299986427/photo/silhouette-of-asian-woman-standing-against-dark-corridor-in-a-park.jpg?s=612x612&w=0&k=20&c=QEAmWtDh8gK8b2hCy98GLQf2XR7vwImyNmPP2lszWRs="),
                cancellationToken: cancellationToken);
        }
        public static async Task OtherAsyncFunctiob()
        {
        }
    }
}
