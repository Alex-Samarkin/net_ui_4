using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ThemeManager
{
    public class ThemeColor
    {
        public Color Primary { get; set; }
        public Color Background { get; set; }
        public Color Accent1 { get; set; }
        public Color Accent2 { get; set; }
        public Color Accent3 { get; set; }
        public Color Accent4 { get; set; }
        public Color Accent5 { get; set; }
        public Font Font { get; set; }

        public ThemeColor()
        {
            // Default theme
            Primary = Color.FromArgb(33, 150, 243); // Blue
            Background = Color.FromArgb(245, 245, 245); // Light gray
            Accent1 = Color.FromArgb(244, 67, 54); // Red
            Accent2 = Color.FromArgb(76, 175, 80); // Green
            Accent3 = Color.FromArgb(255, 152, 0); // Orange
            Accent4 = Color.FromArgb(156, 39, 176); // Purple
            Accent5 = Color.FromArgb(0, 188, 212); // Cyan
            Font = new Font("Segoe UI", 9F);
        }
    }

    public class ThemeManager
    {
        private static ThemeManager _instance;
        private static readonly object _lock = new object();
        private ThemeColor _currentTheme;
        private readonly List<Control> _registeredControls = new List<Control>();

        public static ThemeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ThemeManager();
                    }
                }
                return _instance;
            }
        }

        public ThemeColor CurrentTheme
        {
            get => _currentTheme ??= new ThemeColor();
            set
            {
                _currentTheme = value;
                ApplyThemeToAllControls();
            }
        }

        public void RegisterControl(Control control)
        {
            if (!_registeredControls.Contains(control))
            {
                _registeredControls.Add(control);
                ApplyThemeToControl(control);
                
                // Subscribe to control events to handle dynamically added controls
                if (control is Form form)
                {
                    form.Load += (s, e) => ApplyThemeToControl(control);
                }
            }
        }

        public void ApplyThemeToControl(Control control)
        {
            if (control is Form form)
            {
                form.BackColor = CurrentTheme.Background;
                form.ForeColor = CurrentTheme.Primary;
                if (form.Font != CurrentTheme.Font)
                    form.Font = CurrentTheme.Font;
            }
            else
            {
                control.BackColor = GetBackgroundColor(control);
                control.ForeColor = GetForegroundColor(control);
                if (control.Font != CurrentTheme.Font)
                    control.Font = CurrentTheme.Font;
            }

            // Apply theme to child controls recursively
            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }

            // Special handling for specific control types
            switch (control)
            {
                case Button button:
                    ApplyButtonTheme(button);
                    break;
                case TextBox textBox:
                    ApplyTextBoxTheme(textBox);
                    break;
                case Label label:
                    ApplyLabelTheme(label);
                    break;
                case Panel panel:
                    ApplyPanelTheme(panel);
                    break;
                case ComboBox comboBox:
                    ApplyComboBoxTheme(comboBox);
                    break;
                case ListBox listBox:
                    ApplyListBoxTheme(listBox);
                    break;
                case DataGridView dataGridView:
                    ApplyDataGridViewTheme(dataGridView);
                    break;
            }
        }

        private void ApplyButtonTheme(Button button)
        {
            button.BackColor = CurrentTheme.Primary;
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderColor = CurrentTheme.Primary;
            button.FlatStyle = FlatStyle.Flat;
        }

        private void ApplyTextBoxTheme(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.Black;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void ApplyLabelTheme(Label label)
        {
            label.ForeColor = CurrentTheme.Primary;
        }

        private void ApplyPanelTheme(Panel panel)
        {
            panel.BackColor = CurrentTheme.Background;
        }

        private void ApplyComboBoxTheme(ComboBox comboBox)
        {
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.Black;
        }

        private void ApplyListBoxTheme(ListBox listBox)
        {
            listBox.BackColor = Color.White;
            listBox.ForeColor = Color.Black;
        }

        private void ApplyDataGridViewTheme(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.GridColor = CurrentTheme.Primary;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = CurrentTheme.Primary;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = CurrentTheme.Font;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = CurrentTheme.Background;
            dataGridView.RowHeadersDefaultCellStyle.ForeColor = CurrentTheme.Primary;
        }

        private Color GetBackgroundColor(Control control)
        {
            return control is Button ? CurrentTheme.Primary : CurrentTheme.Background;
        }

        private Color GetForegroundColor(Control control)
        {
            return control is Button ? Color.White : CurrentTheme.Primary;
        }

        private void ApplyThemeToAllControls()
        {
            foreach (var control in _registeredControls)
            {
                if (!control.IsDisposed)
                {
                    ApplyThemeToControl(control);
                }
            }
        }

        public void UnregisterControl(Control control)
        {
            _registeredControls.Remove(control);
        }
    }
}