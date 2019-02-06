using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CalculatorCallbackService : ICalculatorCallbackService
    {
        private MainWindowViewModel MainViewModel;

        public CalculatorCallbackService(MainWindowViewModel MainViewModel)
        {
            this.MainViewModel = MainViewModel;
        }

        public Task EchoResult(string Msg)
        {
            MainViewModel.LogStr += $"{Msg}\n";
            return Task.CompletedTask;
        }
    }
}
