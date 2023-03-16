using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors; 

namespace BaseComponent
{
    public partial class MessageEx : DevExpress.XtraEditors.XtraForm
    {
        public string MessageText;
        public string MessageCaption;
        public MessageBoxButtons MessageButton;
        public MessageBoxIcon MessageIcon;
        public MessageBoxDefaultButton DefaultButton;
        private List<SimpleButton> lstButtons = new List<DevExpress.XtraEditors.SimpleButton>();
        private Size startSize;

        //public msgBox()
        //{
        //    InitializeComponent();
        //}

        public MessageEx()
        {

            InitializeComponent();
            btnAbort.Visible = false;
            btnCancel.Visible = false;
            btnIgnore.Visible = false;
            btnNo.Visible = false;
            btnOK.Visible = false;
            btnRetry.Visible = false;
            btnYes.Visible = false;
            this.startSize = this.Size;
        }

        public MessageEx(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
            : this()
        {
            MessageText = text;
            MessageCaption = caption;
            MessageButton = buttons;
            MessageIcon = icon;
            DefaultButton = defaultbutton;


            //show MESSAGES
            lblMessage.Text = this.MessageText;
            this.Text = this.MessageCaption;
            groupControl1.Text = MessageCaption.ToUpper();

            //SHOW BUTTONS
            if (MessageButton == MessageBoxButtons.AbortRetryIgnore)
            {
                btnAbort.Visible = true;
                btnRetry.Visible = true;
                btnIgnore.Visible = true;
                lstButtons.AddRange(new SimpleButton[3] { btnAbort, btnRetry, btnIgnore });
            }
            else if (MessageButton == MessageBoxButtons.OK)
            {
                btnOK.Visible = true;
                lstButtons.AddRange(new SimpleButton[1] { btnOK });
            }
            else if (MessageButton == MessageBoxButtons.OKCancel)
            {
                btnOK.Visible = true;
                btnCancel.Visible = true;
                lstButtons.AddRange(new SimpleButton[2] { btnOK, btnCancel });
            }
            else if (MessageButton == MessageBoxButtons.RetryCancel)
            {
                btnRetry.Visible = true;
                btnCancel.Visible = true;
                lstButtons.AddRange(new SimpleButton[2] { btnRetry, btnCancel });
            }
            else if (MessageButton == MessageBoxButtons.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
                lstButtons.AddRange(new SimpleButton[2] { btnYes, btnNo });
            }
            else if (MessageButton == MessageBoxButtons.YesNoCancel)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
                btnCancel.Visible = true;
                lstButtons.AddRange(new SimpleButton[3] { btnYes, btnNo, btnCancel });
            }

            //Show images
            if (icon == MessageBoxIcon.Asterisk)
            {
                this.picMessage.Image = Properties.Resources.icon_infomation;
            }
            else if (icon == MessageBoxIcon.Error)
            {
                this.picMessage.Image = Properties.Resources.icon_error;
            }
            else if (icon == MessageBoxIcon.Exclamation)
            {
                this.picMessage.Image = BaseComponent.Properties.Resources.icon_warning;
            }
            else if (icon == MessageBoxIcon.Hand)
            {
                this.picMessage.Image = Properties.Resources.icon_error;
            }
            else if (icon == MessageBoxIcon.Information)
            {
                this.picMessage.Image =Properties.Resources.icon_infomation;
            }
            else if (icon == MessageBoxIcon.None)
            {
                this.picMessage.Image = Properties.Resources.icon_none;
            }
            else if (icon == MessageBoxIcon.Question)
            {
                this.picMessage.Image = Properties.Resources.icon_question;
            }
            else if (icon == MessageBoxIcon.Stop)
            {
                this.picMessage.Image = Properties.Resources.icon_error;
            }
            else if (icon == MessageBoxIcon.Warning)
            {
                this.picMessage.Image = Properties.Resources.icon_warning;
            }

            //Show DEFAULT BUTTONS
            if (this.DefaultButton == MessageBoxDefaultButton.Button1)
            {
                if (lstButtons.Count > 0)
                {
                    this.AcceptButton = lstButtons[0];
                }
            }
            else if (this.DefaultButton == MessageBoxDefaultButton.Button2)
            {
                if (lstButtons.Count > 1)
                {
                    this.AcceptButton = lstButtons[1];
                }
            }
            else if (this.DefaultButton == MessageBoxDefaultButton.Button3)
            {
                if (lstButtons.Count > 2)
                {
                    this.AcceptButton = lstButtons[2];
                }
            }

            int x = this.Location.X - (this.Size.Width - this.startSize.Width) / 2;
            int y = this.Location.Y - (this.Size.Height - this.startSize.Height) / 2;
            if (x > 0 && y > 0)
                this.Location = new Point(x, y);
        }
        /*************************************************/
        public static DialogResult Show(string text)
        {
            return Show(text, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2 ^ MessageBoxDefaultButton.Button3);
        }
        /*************************************************/
        public static DialogResult Show(string text, string caption)
        {
            return Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button2 ^ MessageBoxDefaultButton.Button3);
        }
        /*************************************************/
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(text, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button2 ^ MessageBoxDefaultButton.Button3);
        }
        /*************************************************/
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(text, caption, buttons, icon, MessageBoxDefaultButton.Button2 ^ MessageBoxDefaultButton.Button3);
        }
        /*************************************************/
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultbutton)
        {
            if (caption==null || caption == "")
                caption = Core.MessageContstants.TITLE;
            else if (caption == "err")
                caption = Core.MessageContstants.MSG_ERR;
            else
                caption = caption.Trim();
            MessageEx f = new MessageEx(text, caption, buttons, icon, defaultbutton);
            return f.ShowDialog();
        }
    }
}