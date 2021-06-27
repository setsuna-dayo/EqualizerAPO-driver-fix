# EqualizerAPO-driver-fix

大概是这样：

有一天我卸掉了Win10 21H1系统自带的Realtek音频驱动，装了EqualizerAPO来获得声音调节

出现了问题：数秒内无音频活动时音频驱动挂起，每次恢复活动时会造成一声音量巨大的短暂脉冲，不堪其扰

解决方案：开机自启一个程序后台为音频驱动保活ww

于是就有了这个随手写的小东西

在这里下载：https://github.com/setsuna-dayo/EqualizerAPO-driver-fix/releases/download/v1.0/EqualizerAPO-driver-fix.exe
