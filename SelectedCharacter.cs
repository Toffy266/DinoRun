using System;
using System.Windows.Forms;

namespace Gameproject
{
    public partial class SelectedCharacter : Form
    {
        public SelectedCharacter()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public bool isSelected = false;
        public String character = "";
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            isSelected = true;
            character = "Dino_Green.png";
            Close();
        }

        private void buttonRed_Click(object sender, EventArgs e)
        {
            isSelected = true;
            character = "Dino_Red.png";
            Close();
        }

        private void buttonYellow_Click(object sender, EventArgs e)
        {
            isSelected = true;
            character = "Dino_Yellow.png";
            Close();
        }

        private void buttonBlue_Click(object sender, EventArgs e)
        {
            isSelected = true;
            character = "Dino_Green.png";
            Close();
        }
    }
}
