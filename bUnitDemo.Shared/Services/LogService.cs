using bUnitDemo.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bUnitDemo.Shared.Services
{
    public class LogService : ILogService
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}