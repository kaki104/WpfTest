using System;
using System.Windows;
using System.Windows.Threading;

namespace CoreWpfMemory
{
    /// <summary>
    /// Interaction logic for ClockWindow.xaml
    /// </summary>
    public partial class ClockWindow : Window
    {
        private readonly DispatcherTimer timer;

        public ClockWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };

            timer.Start();
            timer.Tick += UpdateTime;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            timerText.Content = DateTime.Now.ToLongTimeString();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            //Uncommnet below lines to stop memory leak
            timer.Tick -= UpdateTime;
            timer.Stop();
        }
    }
}
