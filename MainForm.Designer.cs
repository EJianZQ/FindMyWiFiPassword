namespace FindMyWiFiPassword
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_ExistWiFi = new System.Windows.Forms.ListView();
            this.button_ListExisting = new System.Windows.Forms.Button();
            this.button_ListPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_ExistWiFi
            // 
            this.listView_ExistWiFi.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView_ExistWiFi.HideSelection = false;
            this.listView_ExistWiFi.Location = new System.Drawing.Point(26, 26);
            this.listView_ExistWiFi.Name = "listView_ExistWiFi";
            this.listView_ExistWiFi.Size = new System.Drawing.Size(296, 221);
            this.listView_ExistWiFi.TabIndex = 0;
            this.listView_ExistWiFi.UseCompatibleStateImageBehavior = false;
            this.listView_ExistWiFi.View = System.Windows.Forms.View.List;
            // 
            // button_ListExisting
            // 
            this.button_ListExisting.Location = new System.Drawing.Point(359, 26);
            this.button_ListExisting.Name = "button_ListExisting";
            this.button_ListExisting.Size = new System.Drawing.Size(177, 70);
            this.button_ListExisting.TabIndex = 1;
            this.button_ListExisting.Text = "列出已连接过的WLAN";
            this.button_ListExisting.UseVisualStyleBackColor = true;
            this.button_ListExisting.Click += new System.EventHandler(this.button_ListExisting_Click);
            // 
            // button_ListPassword
            // 
            this.button_ListPassword.Enabled = false;
            this.button_ListPassword.Location = new System.Drawing.Point(359, 177);
            this.button_ListPassword.Name = "button_ListPassword";
            this.button_ListPassword.Size = new System.Drawing.Size(177, 70);
            this.button_ListPassword.TabIndex = 2;
            this.button_ListPassword.Text = "列出选中WLAN的密码";
            this.button_ListPassword.UseVisualStyleBackColor = true;
            this.button_ListPassword.Click += new System.EventHandler(this.button_ListPassword_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 275);
            this.Controls.Add(this.button_ListPassword);
            this.Controls.Add(this.button_ListExisting);
            this.Controls.Add(this.listView_ExistWiFi);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找已连接过的WLAN密码";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_ExistWiFi;
        private System.Windows.Forms.Button button_ListExisting;
        private System.Windows.Forms.Button button_ListPassword;
    }
}

