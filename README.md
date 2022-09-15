# FindMyWiFiPassword

Winform编写的可列出已连接过的WLAN（Wi-Fi）并查看其密码

---

## 原理

调用CMD来执行 `netsh wlan show profiles`列出已连接过的WLAN列表

执行 `netsh wlan show profiles name="EJianZQ" key=clear`来查看指定名称的WLAN密码

---

## 适用范围

适用于WLAN连接的无线网，不支持拨号查看账号密码等情况
