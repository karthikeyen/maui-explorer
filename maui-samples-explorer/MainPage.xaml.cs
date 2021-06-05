using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace maui_samples_explorer
{
    public partial class MainPage : ContentPage, IPage
    {
        public MainPage()
        {
            InitializeComponent();

            GetBatteryState();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
        }

        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            this.GetBatteryState();
        }

        private void GetBatteryState()
        {
            this.BatteryLevel.Text = "";

            var state = Battery.State;
            var source = Battery.PowerSource;

            if (state != BatteryState.Discharging)
            {
                this.BatteryLevel.Text = $"{state} via {source.ToString()}";
            }

            labelPrecentage.Text = (Battery.ChargeLevel * 100).ToString();
        }
    }
}
