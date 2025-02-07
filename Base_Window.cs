using Catprinter.Utils;
using InTheHand.Net;
using InTheHand.Net.Sockets;

namespace Catprinter
{
    public partial class Base_Window : Form
    {
        Bitmap img = null;
        Bitmap processedImg = null;
        int energy = 0xffff;
        String dithering = "Floyd-Steinberg";

        public Base_Window()
        {
            InitializeComponent();
        }

        private void Base_Window_Load(object sender, EventArgs e)
        {
            pictureBase.SizeMode = PictureBoxSizeMode.CenterImage;
            picturePreview.SizeMode = PictureBoxSizeMode.CenterImage;
            energyField.Text = "0x" + energy.ToString("X4");
            algorithmSelect.Text = dithering;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Base_Window.ActiveForm.Close();
        }

        private void PictureBase_Click(object sender, EventArgs e)
        {
            Task.Run(() => ButtonLoadImg_Click(sender, e));
        }

        private void EnergyField_TextChanged(object sender, EventArgs e)
        {
            if (energyField.Text.Length == 6)
            {
                try
                {
                    energy = int.Parse(energyField.Text.Remove(0, 2), System.Globalization.NumberStyles.HexNumber);
                    terminalPanel.AppendText("\nSet Energy to " + energyField.Text);
                }
                catch (Exception exc)
                {
                    terminalPanel.AppendText("\nNot a valid value");
                    return;
                }
            }
        }

        private void AlgorithmSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            dithering = algorithmSelect.Text;
            terminalPanel.AppendText("\nSet Dithering to " + dithering);
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => Process());
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            Task.Run(() => Print());
        }

        private async void Process()
        {
            processedImg = img;
            progressBar1.Invoke((Action)(() => progressBar1.Value = 10));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nProcessing Image...")));
            try
            {
                processedImg = ImageProcessing.ReadImg("in.jpg", PrinterCommands.PRINT_WIDTH, dithering);
            }
            catch (InvalidOperationException exc)
            {
                terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\n" + exc.Message)));
                return;
            }
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nImage Processed!")));
            processedImg.Save("out.jpg");
            progressBar1.Invoke((Action)(() => progressBar1.Value = 90));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nSaved Processed Image as: " + Directory.GetCurrentDirectory() + "\\out.jpg")));
            SetPicture(picturePreview, processedImg);
            progressBar1.Invoke((Action)(() => progressBar1.Value = 0));
        }

        private async void Print()
        {
            progressBar1.Invoke((Action)(() => progressBar1.Value = 10));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nFinding Printer")));
            BluetoothClient client = new BluetoothClient();
            IReadOnlyCollection<BluetoothDeviceInfo> devices = client.DiscoverDevices();
            BluetoothDeviceInfo printer = null;
            foreach (BluetoothDeviceInfo device in devices)
            {
                if (device.DeviceName == "X5h-0000")
                {
                    printer = device;
                    break;
                }
            }
            if (printer == null)
            {
                terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nPrinter not found")));
                return;
            }
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nPrinter found")));
            BluetoothAddress address = printer.DeviceAddress;
            IReadOnlyCollection<Guid> services = printer.InstalledServices;
            Guid spp = new Guid();
            progressBar1.Invoke((Action)(() => progressBar1.Value = 20));

            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nName: " + printer.DeviceName)));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nAddress: " + address)));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nServices:")));
            foreach (Guid service in services)
            {
                terminalPanel.Invoke((Action)(() => terminalPanel.AppendText(" - " + service.ToString().ToUpper())));
                if (service.ToString().ToUpper().Equals("00001101-0000-1000-8000-00805F9B34FB"))
                {
                    spp = service;
                    terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\n    -> SPP service found")));
                    break;
                }
            }
            if (!spp.ToString().ToUpper().Equals("00001101-0000-1000-8000-00805F9B34FB"))
            {
                terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nSPP service not found")));
                return;
            }
            progressBar1.Invoke((Action)(() => progressBar1.Value = 30));

            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nConnecting to printer")));
            try
            {
                client.Connect(printer.DeviceAddress, spp);
            }
            catch (Exception err)
            {
                terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nFailed to connect")));
                return;
            }
            Stream stream = client.GetStream();
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nConnected to printer")));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nGenerating and sending commands")));
            stream.Write(PrinterCommands.GetImgPrintCmd(processedImg, energy));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nCommands sent")));
            progressBar1.Invoke((Action)(() => progressBar1.Value = 90));

            stream.Close();
            client.Close();

            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nConnection closed")));
            progressBar1.Invoke((Action)(() => progressBar1.Value = 0));
        }
        private async void ButtonLoadImg_Click(object sender, EventArgs e)
        {
            progressBar1.Invoke((Action)(() => progressBar1.Value = 0));
            progressBar1.Invoke((Action)(() => progressBar1.Value = 10));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nLoading Image...")));
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            progressBar1.Invoke((Action)(() => progressBar1.Value = 90));
            string selectedFileName = openFileDialog.FileName;
            img = new Bitmap(selectedFileName);
            progressBar1.Invoke((Action)(() => progressBar1.Value = 100));
            Thread.Sleep(500);
            img.Save("in.jpg");
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nImage Loaded!")));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nImage Path: " + selectedFileName)));
            terminalPanel.Invoke((Action)(() => terminalPanel.AppendText("\nSaved Image as: " + Directory.GetCurrentDirectory() + "\\in.jpg")));
            SetPicture(pictureBase, img);

            progressBar1.Invoke((Action)(() => progressBar1.Value = 0));
        }

        private void SetPicture(PictureBox pictureBox, Bitmap img)
        {
            int width = img.Width;
            int height = img.Height;
            double factor = 1;
            Bitmap resized = img;
            if (height > width && height > pictureBox.Height)
            {
                factor = (double)pictureBox.Height / height;
                resized = new Bitmap(img, new Size((int)(width * factor), (int)(height * factor)));
            }
            else if (width > height && width > pictureBox.Width)
            {
                factor = (double)pictureBox.Width / width;
                resized = new Bitmap(img, new Size((int)(width * factor), (int)(height * factor)));
            }
            pictureBox.Image = resized;
        }
    }
}
