using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FindMyWiFiPassword
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 调用CMD并获取返回值
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string execCMD(string command)
        {
            System.Diagnostics.Process pro = new System.Diagnostics.Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.CreateNoWindow = true;
            //pro.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            pro.Start();
            pro.StandardInput.WriteLine(command);
            pro.StandardInput.WriteLine("exit");
            pro.StandardInput.AutoFlush = true;
            //获取cmd窗口的输出信息
            string output = pro.StandardOutput.ReadToEnd();
            pro.WaitForExit();//等待程序执行完退出进程
            pro.Close();
            return output;

        }

        private void button_ListExisting_Click(object sender, EventArgs e)
        {
            string originalText = execCMD("netsh wlan show profiles");
            if(originalText.Contains("用户配置文件") == true)
            {
                string[] sArray = Regex.Split(originalText.Substring(originalText.IndexOf("用户配置文件")), Environment.NewLine);
                if(sArray.Length >= 5)
                {
                    foreach(var i in sArray)
                    {
                        if(Regex.IsMatch(i, @"配置文件 : ."))
                            listView_ExistWiFi.Items.Add(i.Substring(i.IndexOf(": ")).Replace(@": ",string.Empty));
                    }
                    if (listView_ExistWiFi.Items.Count > 0)
                    {
                        button_ListPassword.Enabled = true;
                        MessageBox.Show("列出成功，请在左侧列表中选中要列出的WLAN后点击列出密码按钮", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("列出失败", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("列出失败，原因可能有:\n此设备未连接过任何WLAN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("列出失败，原因可能有:\n1.此设备未连接过任何WLAN\n2.软件没有权限调用CMD，请使用管理员权限运行\n3.账户权限不足，可能是公司或学校限制等","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_ListPassword_Click(object sender, EventArgs e)
        {
            if(listView_ExistWiFi.SelectedItems.Count == 1)
            {
                string originalText = execCMD(string.Format(@"netsh wlan show profiles name=""{0}"" key=clear",listView_ExistWiFi.SelectedItems[0].Text));
                if(originalText.Contains("关键内容") == true)
                {
                    string KeyText = originalText.Substring(originalText.IndexOf("关键内容"), originalText.IndexOf("费用设置") - originalText.IndexOf("关键内容"));
                    MessageBox.Show(KeyText.Substring(KeyText.IndexOf(@": ")).Replace(@": ", string.Empty), listView_ExistWiFi.SelectedItems[0].Text + "的密码是：", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("未获取到WLAN信息或密码，下方将输出CMD命令原文\n" + originalText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
