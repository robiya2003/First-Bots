using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using System;
namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            TELEGRAMBOTCLASS tELEGRAMBOTCLASS = new TELEGRAMBOTCLASS();
            try
            {
                await tELEGRAMBOTCLASS.EssentialFunction();
            }
            catch (Exception ex)
            {
                throw new Exception("");
            }



        }
    }
}
