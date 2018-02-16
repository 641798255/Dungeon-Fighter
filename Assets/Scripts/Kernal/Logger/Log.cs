/*
   Title :
   主题：日志调试系统
   功能：灵活调试系统代码
   实现原理：1：把自己在代码中定义的调试语句，写入本日志的缓存。
            2：当缓存中数量超过定义的最大写入文件数值，则把缓存内容调试语句一次性写入文本文件
*/
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Kernal
{
    public  static class Log  {
        //日志缓存数据
        private static List<string> _LisLogArray;
        //日志文件路径
        private static string _LogPath;
        //日志部署模式
        private static State _LogState;
        //日志最大容量
        private static int _LogMaxCapacity;
        //日志缓存最大容量
        private static int _LogBufferMaxNumber;

        static Log()
        {
            _LisLogArray = new List<string>();
            IConfigManager configMgr = new ConfigManager(KernalParameter.SystemConfiginfo_LogPath,KernalParameter.SystemConfiginfo_LogRootNodeName);
            //日志文件路径
            _LogPath = configMgr.AppSetting["LogPath"];
            if (string.IsNullOrEmpty(_LogPath))
            {
                _LogPath = UnityEngine.Application.persistentDataPath + "\\DungeonFighterLog.txt";
            }
            //日志部署模式
            string strLogState = configMgr.AppSetting["LogState"];
            if (!string.IsNullOrEmpty(strLogState))
            {
                switch (strLogState)
                {
                    case "Develop":
                        _LogState = State.Develop;
                        break;
                    case "Special":
                        _LogState = State.Special;
                        break;
                    case "Deploy":
                        _LogState = State.Deploy;
                        break;
                    case "Stop":
                        _LogState = State.Stop;
                        break;
                    default:
                        _LogState = State.Stop;
                        break;
                }
            }
            else
            {
                _LogState = State.Stop;
            }
            //日志最大容量
            string strLogMaxCapacity = configMgr.AppSetting["LogMaxCapacity"];
            if (!string.IsNullOrEmpty(strLogMaxCapacity))
            {
                _LogMaxCapacity = Convert.ToInt32(strLogMaxCapacity);
            }
            else
            {
                _LogMaxCapacity = 2000;
            }

            //日志缓存最大容量
            string strLogBufferMaxNumber = configMgr.AppSetting["LogBufferNumber"];
            if (!string.IsNullOrEmpty(strLogBufferMaxNumber))
            {
                _LogBufferMaxNumber = Convert.ToInt32(strLogBufferMaxNumber);
            }
            else
            {
                _LogBufferMaxNumber = 1;
            }


            //创建文件
            if (!File.Exists(_LogPath))
            {
                File.Create(_LogPath);
                Thread.CurrentThread.Abort();
            }
            //把日志文件中的数据同步到日志缓存中
            SyncFileDataToLogArray();
        }

        private static void SyncFileDataToLogArray()
        {
            if (!string.IsNullOrEmpty(_LogPath))
            {
                StreamReader sr = new StreamReader(_LogPath);
                while (sr.Peek()>=0)
                {
                    _LisLogArray.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        public static void Write(string writeFileData,Level level)
        {
            //参数检查
            if (_LogState==State.Stop)
            {
                return;
            }
            //如果日志缓存文件中的数量超过指定容量，则清空
            if (_LisLogArray.Count>=_LogMaxCapacity)
            {
                _LisLogArray.Clear();
            }

            if (!string.IsNullOrEmpty(writeFileData))
            {
                //增加日期和时间
                writeFileData = "Log State:"+_LogState.ToString()+"/"+DateTime.Now.ToString()+"/"+writeFileData;
                //对于不同的日志状态，分特定情形写入文件
                if (level==Level.High)
                {
                    writeFileData = "@@@ Error or Warnning or Important!!! @@@" + writeFileData;
                }
                switch (_LogState)
                {
                    case State.Develop:
                        //追加调试信息，写入文件
                        AppendDataToFile(writeFileData);
                        break;
                    case State.Special:
                        if (level==Level.High||level==Level.Special)
                        {
                            AppendDataToFile(writeFileData);
                        }
                        break;
                    case State.Deploy:
                        if (level == Level.High)
                        {
                            AppendDataToFile(writeFileData);
                        }
                        break;
                    case State.Stop:
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Write(string writeFileData)
        {
            Write(writeFileData,Level.Low);
        }

        private static void AppendDataToFile(string writeFileData)
        {
            if (!string.IsNullOrEmpty(writeFileData))
            {
                //调试信息数据追加到缓存集合中
                _LisLogArray.Add(writeFileData);
            }
            //缓存集合数量超过一定指定数量，则同步到尸体文件中
            if (_LisLogArray.Count%_LogBufferMaxNumber==0)
            {
                //同步缓存中的数据信息到实体文件中
                SyncLogArrayToFile();
            }
           
        }

        private static void SyncLogArrayToFile()
        {
            if (!string.IsNullOrEmpty(_LogPath))
            {
                StreamWriter sw = new StreamWriter(_LogPath);
                foreach (string item in _LisLogArray)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
        }

        #region 本类枚举类型
        /// <summary>
        /// 日志部署模式
        /// </summary>
        public enum State
        {
            Develop,
            Special,
            Deploy,
            Stop
        }

        /// <summary>
        /// 调试信息的等级（表示调试信息本身的重要程度）
        /// </summary>
        public enum Level
        {
            High,
            Special,
            Low
        }

        #endregion
    }
}


