using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using ClassLibrary1;
using Grpc.Net.Client;

namespace WpfGrpcClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class TableItem
        {
            public string Column0 { get; set; }
            public string Column1 { get; set; }
            public string Column2 { get; set; }
        }

        public ObservableCollection<TableItem> TableData { get; set; }

        private GrpcChannel _grpcChannel;

        public MainWindow()
        {
            InitializeComponent();

            TableData = new ObservableCollection<TableItem>();

            TableData.Add(new TableItem { Column0 = "Jan", Column1 = "Kowalski", Column2 = "Katowice" });
            TableData.Add(new TableItem { Column0 = "Adam", Column1 = "Nowak", Column2 = "Warszawa" });
            TableData.Add(new TableItem { Column0 = "Ewa", Column1 = "Wiśniewska", Column2 = "Wrocław" });

            myDataGrid.ItemsSource = TableData;

            InitializeGrpcChannel();
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            CallGrpcGreeterAsync();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            CallGrpcTest();
        }

        private void InitializeGrpcChannel()
        {
            _grpcChannel = GrpcChannel.ForAddress("https://localhost:5001");
        }

        private async void CallGrpcGreeterAsync()
        {
            var client = new ClassLibrary1.Greeter.GreeterClient(_grpcChannel);
            var reply = await client.SayHelloAsync(
                new ClassLibrary1.HelloRequest { Name = textBox1.Text });
            textBox2.Text = reply.Message;
        }

        private async void CallGrpcTest()
        {
            var client = new ClassLibrary1.Test.TestClient(_grpcChannel);
            var reply = await client.IsInDBAsync(
                new ClassLibrary1.Request { FirstName = firstName.Text, LastName = secondName.Text, City = city.Text });
            exist.Text = reply.Exist == true ? "Exist" : "Not exist";
            message.Text = reply.Message;
        }
    }
}
