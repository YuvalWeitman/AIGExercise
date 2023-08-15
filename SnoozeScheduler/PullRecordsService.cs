using CoreWebApplication1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnoozeScheduler
{
    public class PullRecordsService
    {
        private readonly DataService dataService;
        public PullRecordsService() 
        {
            dataService = new DataService("C:\\Users\\yuval\\source\\repos\\CoreWebApplication1\\snoozeService.db");
        }

        public void Execute()
        {
            dataService.GetMessagesToSend().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("press any key to update db with isSent=true");
            Console.ReadLine();

            dataService.UpdateMessages();
        }
    }
}
