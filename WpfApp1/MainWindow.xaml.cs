using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }

    public class MainWindowViewModel : BindableBase
    {
        private string logStr = string.Empty;

        public string EndpointUrl { get; set; }
        public string EchoText { get; set; }
        public string aStr { get; set; }
        public string bStr { get; set; }
        public string LogStr { get => logStr; set => SetProperty(ref logStr, value, nameof(LogStr)); }
        public ICalculatorService CalculatorService { get; set; }

        public AsyncDelegateCommand AddClick => new AsyncDelegateCommand(async () =>
        {
            var Result = await CalculatorService.Add(double.Parse(aStr), double.Parse(bStr));
            LogStr += $"{aStr} + {bStr} = {Result} \n";
        });

        public AsyncDelegateCommand ConnectClick => new AsyncDelegateCommand(() =>
        {
            LogStr += "Connecting to Service... \n";
            NetTcpBinding Binding = new NetTcpBinding();

            DuplexChannelFactory<ICalculatorService> Factory = new DuplexChannelFactory<ICalculatorService>(new InstanceContext(new CalculatorCallbackService(this)), Binding);
            Factory.Endpoint.EndpointBehaviors.Add(new MyEndpointBehavior());

            CalculatorService = Factory.CreateChannel(new EndpointAddress(EndpointUrl));
            LogStr += "Connected.\n";
        });

        public AsyncDelegateCommand HttpConnectClick => new AsyncDelegateCommand(() =>
        {
            LogStr += "Connecting to Service... \n";
            BasicHttpBinding Binding = new BasicHttpBinding();

            ChannelFactory<ICalculatorService> Factory = new ChannelFactory<ICalculatorService>(Binding);
            Factory.Endpoint.EndpointBehaviors.Add(new MyEndpointBehavior());

            CalculatorService = Factory.CreateChannel(new EndpointAddress(EndpointUrl));
            LogStr += "Connected.\n";
        });

        public AsyncDelegateCommand SendEchoClick => new AsyncDelegateCommand( async () =>
        {
            await CalculatorService.Echo(EchoText);
        });
    }
}
