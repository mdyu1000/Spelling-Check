using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1
{
    class AboutUs : Form
    {
        //設定form
        public void SetAboutForm()
        {
            _about.ClientSize = new System.Drawing.Size(Constant.THREE_HUNDRED, Constant.TWO_HUNDRED);
            _about.Text = Constant.TEXT_1;
            _about.ControlBox = false;
        }

        //設定GroupBox
        public void SetGroupBox()
        {
            _groupBox.Location = new System.Drawing.Point(Constant.TEN, Constant.TEN);
            _groupBox.Size = new System.Drawing.Size(Constant.TWO_EIGHTY, Constant.ONE_EIGHTY);
        }

        //設定Label
        public void SetLabel()
        {
            _introduceLabel.Text = Constant.TEXT_1;
            _introduceLabel.Size = new System.Drawing.Size(Constant.ONE_FIFTY, Constant.FIFTEEN);
            _introduceLabel.Location = new System.Drawing.Point(Constant.SIXTY, Constant.TWENTY_FIVE);
            _copyrightLabel.Text = Constant.TEXT_3;
            _copyrightLabel.Size = new System.Drawing.Size(Constant.ONE_FIFTY, Constant.FIFTEEN);
            _copyrightLabel.Location = new System.Drawing.Point(Constant.SIXTY, Constant.SIXTY_FIVE);
            _authorLabel.Text = Constant.MY_NAME;
            _authorLabel.Size = new System.Drawing.Size(Constant.ONE_FIFTY, Constant.FIFTEEN);
            _authorLabel.Location = new System.Drawing.Point(Constant.SIXTY_FIVE, Constant.EIGHTY_FIVE);
        }

        //設定LinkLabel
        public void SetLinkLabel()
        {
            _departmentLinkLabel.Text = Constant.DEPARTMENT;
            _departmentLinkLabel.Size = new System.Drawing.Size(Constant.FOUR_ZERO, Constant.FIFTEEN);
            _departmentLinkLabel.Location = new System.Drawing.Point(Constant.EIGHTY_FIVE, Constant.FOUR_FIVE);
            _departmentLinkLabel.Click += new System.EventHandler(this.ClickDepartmentLinkLabel);
            _schoolLinkLabelLinkLabel.Text = Constant.SCHOOL;
            _schoolLinkLabelLinkLabel.Size = new System.Drawing.Size(Constant.FOUR_ZERO, Constant.FIFTEEN);
            _schoolLinkLabelLinkLabel.Location = new System.Drawing.Point(Constant.ONE_FOUR_FIVE, Constant.FOUR_FIVE);
            _schoolLinkLabelLinkLabel.Click += new System.EventHandler(this.ClickSchoolLinkLabel);
        }

        // LinkLabel的超連結 往CSIE
        private void ClickDepartmentLinkLabel(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constant.DEPARTMENT_WEB);
        }

        // LinkLabel的超連結 往NTUT
        private void ClickSchoolLinkLabel(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Constant.SCHOOL_WEB);
        }

        //設定按鈕"OK"
        public void SetButton()
        {
            _completeButton.Text = Constant.TEXT_4;
            _completeButton.Size = new System.Drawing.Size(Constant.ONE_HUNDRED, Constant.TWENTY);
            _completeButton.Location = new System.Drawing.Point(Constant.ONE_SEVENTY, Constant.ONE_FIFTY);
            _completeButton.Click += (_, args) =>
            {
                _about.Close();
            };
        }

        //設定picture box
        public void SetPictureBox()
        {
            _picture.Size = new System.Drawing.Size(Constant.FIFTY, Constant.FIFTY);
            _picture.Location = new System.Drawing.Point(Constant.TWENTY, Constant.ONE_TWENTY);
            _picture.Image = new Bitmap(Constant.FILE_EYE);
            _picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        }

        //加入
        public void SetAdd()
        {
            _about.Controls.Add(_groupBox);
            _groupBox.Controls.Add(_introduceLabel);
            _groupBox.Controls.Add(_departmentLinkLabel);
            _groupBox.Controls.Add(_schoolLinkLabelLinkLabel);
            _groupBox.Controls.Add(_copyrightLabel);
            _groupBox.Controls.Add(_authorLabel);
            _groupBox.Controls.Add(_completeButton);
            _groupBox.Controls.Add(_picture);
            _about.ShowDialog();
        }

        //打包好About us 回傳
        public void Complete()
        {
            SetAboutForm();
            SetGroupBox();
            SetLabel();
            SetLinkLabel();
            SetButton();
            SetPictureBox();
            SetAdd();
        }

        Form _about = new Form();
        GroupBox _groupBox = new GroupBox();
        Label _introduceLabel = new Label();
        Label _copyrightLabel = new Label();
        Label _authorLabel = new Label();
        LinkLabel _departmentLinkLabel = new LinkLabel();
        LinkLabel _schoolLinkLabelLinkLabel = new LinkLabel();
        Button _completeButton = new Button();
        PictureBox _picture = new PictureBox();
    }
}
