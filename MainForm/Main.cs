namespace MainForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(string username)
        {
            InitializeComponent();
            labelWelcome.Text = "Welcome, " + username;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtIntroduce.PlaceholderText = "Giới thiệu...";
        }
    }
}
