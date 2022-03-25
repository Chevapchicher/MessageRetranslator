using System;
using MessengerRetranslator.Interfaces;
using MessengerRetranslator.VK;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using VkApi;

namespace MessengerRetranslator
{
    class Program
    {
       
        static async Task Main(string[] args)
        {
            Manager manager = new();

            while (true)
            {
                Console.Read();
            }
        }
    }
}
