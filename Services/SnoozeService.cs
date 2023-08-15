using CoreWebApplication1.Data;
using CoreWebApplication1.Models;
using CoreWebApplication1.Services.Strategy;
using System;
using System.Reflection;
using System.Runtime.Loader;

namespace CoreWebApplication1.Services
{
    public class SnoozeService
    {
        private readonly DataService dataService;
        private ICalcDateStrategy? calcDateStrategy;

        public SnoozeService()
        {
            dataService = new DataService();
        }
        public void HandleSnoozeRequest(string message, SnoozeOption option, DateTime dateTime)
        {
            try
            {
                SetCalcDateStrategy(option, dateTime);
                dataService.InsertSnoozeMassage(message, CalculateSnoozeDate());
            }
            catch (Exception)
            {
                throw;
            }
        }

        // using strategy design pattern + reflection for choose the CalcDateStrategy on run time
        private void SetCalcDateStrategy(SnoozeOption option, DateTime dateTime)
        {
            try
            {
                Type type;
                string strategyNamespace = $"CoreWebApplication1.Services.Strategy.{option}";
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetType(strategyNamespace) != null);

                if (assembly == null)
                {
                    throw new Exception("Could not find the strategy assembly associated with the selected option");
                }

                type = assembly.GetType(strategyNamespace);

                if (type == typeof(CustomDateTime)) // CustomDateTime is the only class with parametrs constructor
                {
                    calcDateStrategy = (ICalcDateStrategy)Activator.CreateInstance(type, dateTime);
                }
                else
                {
                    calcDateStrategy = (ICalcDateStrategy)Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {

                throw (new Exception("Fail to set the calcDateStrategy", ex));
            }
            
        }

        private DateTime CalculateSnoozeDate()
        {
            return calcDateStrategy.Calc();
        }
    }
}
