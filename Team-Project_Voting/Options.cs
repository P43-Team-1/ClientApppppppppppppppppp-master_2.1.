using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team_Project_Voting
{
    public partial class Options : UserControl
    {
        private readonly Color _defaultBackColor;
        private bool _isSelected;

        public Options()
        {
            InitializeComponent();
            _defaultBackColor = BackColor;
            MakeControlsClickable(this);
        }

        /// <summary>
        /// Raised when the user chooses this option.
        /// </summary>
        public event EventHandler? Selected;

        [Browsable(false)]
        public bool IsSelected => _isSelected;

        private void Options_Load(object sender, EventArgs e)
        {

        }
        private string _optionText = string.Empty;
        private Image? _optionImage;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Option")]
        public string optionText
        {
            get { return _optionText; }
            set { _optionText = value; lblOption.Text = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Option")]
        public Image? optionImage
        {
            get { return _optionImage; }
            set { _optionImage = value; PictureO.Image = value; }
        }

        /// <summary>
        /// Marks this option as selected and notifies its container.
        /// </summary>
        public void SelectOption()
        {
            if (_isSelected)
            {
                return;
            }

            SetSelected(true);
            Selected?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Updates the visual selection state. The parent form uses this to
        /// clear the previously selected option.
        /// </summary>
        public void SetSelected(bool selected)
        {
            _isSelected = selected;
            BackColor = selected ? Color.LightSteelBlue : _defaultBackColor;
        }

        private void MakeControlsClickable(Control control)
        {
            control.Cursor = Cursors.Hand;
            control.Click += Option_Click;
            control.ControlAdded += ChildControl_Added;

            foreach (Control child in control.Controls)
            {
                MakeControlsClickable(child);
            }
        }

        private void ChildControl_Added(object? sender, ControlEventArgs e)
        {
            if (e.Control is not null)
            {
                MakeControlsClickable(e.Control);
            }
        }

        private void Option_Click(object? sender, EventArgs e)
        {
            SelectOption();
        }
    }
}
