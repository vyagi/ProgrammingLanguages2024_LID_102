using System.Net;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var handler = new HttpClientHandler();

            handler.ClientCertificateOptions = ClientCertificateOption.Manual;

            handler.ServerCertificateCustomValidationCallback =
                (_, _, _, _) => true;

            var httpClient = new HttpClient(handler);

            var cities = textBox3.Text.Split(',');

            textBox2.Clear();
            
            var tasks = new List<Task<string>>();
                        
            foreach (var city in cities)
            {
                var task = httpClient.GetStringAsync(textBox1.Text);
                tasks.Add(task);
            }

            var allTasks = Task.WhenAll(tasks);
            
            var timeoutTask = Task.Delay(2500);

            await Task.WhenAny(allTasks, timeoutTask);

            if (timeoutTask.IsCompleted)
            {
                textBox2.Text = "ERROR: Server timeout";
                return;
            }

            foreach (var task in tasks)
            {
                textBox2.Text += task.Result + "\r\n";
            }


            //var result = await httpClient.GetStringAsync(textBox1.Text);

            //textBox2.Text = result;


            //ServicePointManager
            //    .ServerCertificateValidationCallback +=
            //    (sender, cert, chain, sslPolicyErrors) => true;

            //var webClient = new WebClient();  //DON'T USE THIS CLASS. IT'S SHIT

            //var result = webClient.DownloadString(textBox1.Text);

            //textBox2.Text = result;
        }
    }
}