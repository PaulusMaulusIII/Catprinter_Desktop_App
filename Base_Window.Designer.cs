namespace Catprinter
{
    partial class Base_Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonPrint = new Button();
            algorithmSelect = new ComboBox();
            buttonExit = new Button();
            picturePreview = new PictureBox();
            pictureBase = new PictureBox();
            buttonLoadImg = new Button();
            progressBar1 = new ProgressBar();
            terminalPanel = new RichTextBox();
            processButton = new Button();
            energyField = new TextBox();
            invertSelect = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picturePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBase).BeginInit();
            SuspendLayout();
            // 
            // buttonPrint
            // 
            buttonPrint.Location = new Point(995, 576);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(75, 23);
            buttonPrint.TabIndex = 1;
            buttonPrint.Text = "Print\r\n";
            buttonPrint.UseVisualStyleBackColor = true;
            buttonPrint.Click += ButtonPrint_Click;
            // 
            // algorithmSelect
            // 
            algorithmSelect.FormattingEnabled = true;
            algorithmSelect.Items.AddRange(new object[] { "Floyd-Steinberg", "Halftone", "Atkinson", "Mean-Threshold", "None" });
            algorithmSelect.Location = new Point(468, 575);
            algorithmSelect.Name = "algorithmSelect";
            algorithmSelect.Size = new Size(232, 23);
            algorithmSelect.TabIndex = 2;
            algorithmSelect.SelectedIndexChanged += AlgorithmSelect_SelectedIndexChanged;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(12, 576);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(75, 23);
            buttonExit.TabIndex = 3;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // picturePreview
            // 
            picturePreview.Location = new Point(706, 42);
            picturePreview.Name = "picturePreview";
            picturePreview.Size = new Size(364, 527);
            picturePreview.TabIndex = 5;
            picturePreview.TabStop = false;
            // 
            // pictureBase
            // 
            pictureBase.Location = new Point(336, 42);
            pictureBase.Name = "pictureBase";
            pictureBase.Size = new Size(364, 528);
            pictureBase.TabIndex = 6;
            pictureBase.TabStop = false;
            pictureBase.Click += PictureBase_Click;
            // 
            // buttonLoadImg
            // 
            buttonLoadImg.Location = new Point(336, 575);
            buttonLoadImg.Name = "buttonLoadImg";
            buttonLoadImg.Size = new Size(126, 23);
            buttonLoadImg.TabIndex = 7;
            buttonLoadImg.Text = "Load Image";
            buttonLoadImg.UseVisualStyleBackColor = true;
            buttonLoadImg.Click += ButtonLoadImg_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(336, 13);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(734, 23);
            progressBar1.TabIndex = 8;
            // 
            // terminalPanel
            // 
            terminalPanel.BackColor = SystemColors.Desktop;
            terminalPanel.Cursor = Cursors.No;
            terminalPanel.Font = new Font("Geist Mono Medium", 8.249999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            terminalPanel.ForeColor = SystemColors.HighlightText;
            terminalPanel.Location = new Point(12, 12);
            terminalPanel.Name = "terminalPanel";
            terminalPanel.ReadOnly = true;
            terminalPanel.ScrollBars = RichTextBoxScrollBars.None;
            terminalPanel.Size = new Size(318, 557);
            terminalPanel.TabIndex = 10;
            terminalPanel.Text = "";
            // 
            // processButton
            // 
            processButton.Location = new Point(706, 574);
            processButton.Name = "processButton";
            processButton.Size = new Size(75, 23);
            processButton.TabIndex = 11;
            processButton.Text = "Process";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += processButton_Click;
            // 
            // energyField
            // 
            energyField.Location = new Point(849, 574);
            energyField.Name = "energyField";
            energyField.Size = new Size(140, 23);
            energyField.TabIndex = 12;
            energyField.TextChanged += EnergyField_TextChanged;
            // 
            // invertSelect
            // 
            invertSelect.AutoSize = true;
            invertSelect.Location = new Point(787, 576);
            invertSelect.Name = "invertSelect";
            invertSelect.Size = new Size(56, 19);
            invertSelect.TabIndex = 13;
            invertSelect.Text = "Invert";
            invertSelect.UseVisualStyleBackColor = true;
            invertSelect.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Base_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 610);
            Controls.Add(invertSelect);
            Controls.Add(energyField);
            Controls.Add(processButton);
            Controls.Add(terminalPanel);
            Controls.Add(progressBar1);
            Controls.Add(buttonLoadImg);
            Controls.Add(pictureBase);
            Controls.Add(picturePreview);
            Controls.Add(buttonExit);
            Controls.Add(algorithmSelect);
            Controls.Add(buttonPrint);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Base_Window";
            Text = "Catprinter UI";
            Load += Base_Window_Load;
            ((System.ComponentModel.ISupportInitialize)picturePreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button buttonPrint;
        public ComboBox algorithmSelect;
        public Button buttonExit;
        public PictureBox picturePreview;
        public PictureBox pictureBase;
        public Button buttonLoadImg;
        public ProgressBar progressBar1;
        public RichTextBox terminalPanel;
        private Button processButton;
        private TextBox energyField;
        private CheckBox invertSelect;
    }
}
