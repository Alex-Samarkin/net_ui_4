using System;
using System.Drawing;
using System.Windows.Forms;
using ThemeManager;

namespace ThemeManagerDemo
{
    public partial class SampleForm : Form
    {
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Panel panel1;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Button changeThemeButton;
        private Button resetThemeButton;

        public SampleForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            
            // Register this form with the theme manager
            ThemeManager.Instance.RegisterControl(this);
        }

        private void InitializeComponent()
        {
            this.Size = new Size(800, 600);
            this.Text = "Theme Manager Demo";
        }

        private void InitializeCustomComponents()
        {
            // Create and configure controls
            label1 = new Label
            {
                Text = "Theme Manager Demo",
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                Font = new Font("Segoe UI", 14F, FontStyle.Bold)
            };

            textBox1 = new TextBox
            {
                Location = new Point(20, 60),
                Size = new Size(200, 25),
                Text = "Sample Text Input"
            };

            button1 = new Button
            {
                Text = "Sample Button",
                Location = new Point(20, 100),
                Size = new Size(120, 30)
            };

            button2 = new Button
            {
                Text = "Another Button",
                Location = new Point(150, 100),
                Size = new Size(120, 30)
            };

            comboBox1 = new ComboBox
            {
                Location = new Point(20, 140),
                Size = new Size(200, 25)
            };
            comboBox1.Items.Add("Option 1");
            comboBox1.Items.Add("Option 2");
            comboBox1.Items.Add("Option 3");
            comboBox1.SelectedIndex = 0;

            listBox1 = new ListBox
            {
                Location = new Point(20, 180),
                Size = new Size(200, 100)
            };
            listBox1.Items.Add("List Item 1");
            listBox1.Items.Add("List Item 2");
            listBox1.Items.Add("List Item 3");

            panel1 = new Panel
            {
                Location = new Point(250, 60),
                Size = new Size(200, 150),
                BorderStyle = BorderStyle.FixedSingle
            };
            var panelLabel = new Label
            {
                Text = "Panel Content",
                Location = new Point(10, 10),
                Size = new Size(100, 20)
            };
            panel1.Controls.Add(panelLabel);

            dataGridView1 = new DataGridView
            {
                Location = new Point(20, 300),
                Size = new Size(500, 150)
            };
            dataGridView1.Columns.Add("Column1", "Name");
            dataGridView1.Columns.Add("Column2", "Value");
            dataGridView1.Rows.Add("Row 1", "Value 1");
            dataGridView1.Rows.Add("Row 2", "Value 2");

            changeThemeButton = new Button
            {
                Text = "Change Theme",
                Location = new Point(300, 20),
                Size = new Size(120, 30)
            };
            changeThemeButton.Click += ChangeThemeButton_Click;

            resetThemeButton = new Button
            {
                Text = "Reset Theme",
                Location = new Point(430, 20),
                Size = new Size(120, 30)
            };
            resetThemeButton.Click += ResetThemeButton_Click;

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                label1, textBox1, button1, button2, 
                comboBox1, listBox1, panel1, dataGridView1,
                changeThemeButton, resetThemeButton
            });
        }

        private void ChangeThemeButton_Click(object sender, EventArgs e)
        {
            // Create a new theme with dark colors
            var darkTheme = new ThemeColor
            {
                Primary = Color.FromArgb(100, 150, 255), // Light blue
                Background = Color.FromArgb(30, 30, 30), // Dark gray
                Accent1 = Color.FromArgb(255, 100, 100), // Light red
                Accent2 = Color.FromArgb(100, 255, 100), // Light green
                Accent3 = Color.FromArgb(255, 200, 100), // Light orange
                Accent4 = Color.FromArgb(200, 100, 255), // Light purple
                Accent5 = Color.FromArgb(100, 255, 255), // Light cyan
                Font = new Font("Arial", 10F)
            };

            ThemeManager.Instance.CurrentTheme = darkTheme;
        }

        private void ResetThemeButton_Click(object sender, EventArgs e)
        {
            // Reset to default theme
            ThemeManager.Instance.CurrentTheme = new ThemeColor();
        }
    }
}