/*
   Title :
   主题：配置管理器
   功能：读取系统核心XML配置信息
*/
using System.Collections;
using System.Collections.Generic;
using System;

namespace Kernal
{
    public interface IConfigManager  {

        Dictionary<string, string> AppSetting { get; }

        int GetAppSettingMaxNumber();
    }
}


