using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using com.gexin.rp.sdk.dto;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.payload;
using System.Net;

namespace GPush
{
    public class push_message
    {
        public static string PushMessageToSingle( string ALIAS, string title, string text, string transmission_content,int role_id)
        {
            String APPID="";
            String APPKEY="";
            String MASTERSECRET="";
            if (role_id == 2)
            {
                APPID = "CuAQ3h9MP39OHtOx8bdzu3";
                APPKEY = "3TitJm47Og9xT7JeQYfj11";
                MASTERSECRET = "FzCOYUbsaN9dulGHd1my75"; 
            }
            else if (role_id == 3)
            {
                APPID = "770lAMYDP86TVg1RQMQwA4";
                APPKEY = "hDME2xorANAF0miHddCkU3";
                MASTERSECRET = "PXrTN6Nrb66Sq5IrrZRud3";  
            }
            String pushResult = "";
            String HOST = "http://sdk.open.api.igexin.com/apiex.htm";
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);

            //消息模版：TransmissionTemplate:透传模板

            NotificationTemplate template = NotificationTemplateDemo(APPID,APPKEY,title,text,transmission_content);


            // 单推消息模型
            SingleMessage message = new SingleMessage();
            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;            // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //判断是否客户端是否wifi环境下推送，2为4G/3G/2G，1为在WIFI环境下，0为不限制环境
            //message.PushNetWorkType = 1;  

            com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
            target.appId = APPID;
            target.alias = ALIAS;
           
            try
            {
                pushResult = push.pushMessageToSingle(message, target);

            }
            catch (RequestException e)
            {
                String requestId = e.RequestId;
                //发送失败后的重发
                pushResult = push.pushMessageToSingle(message, target, requestId);
               
            }
            return pushResult;
        }
        public static string PushMessageToList(string alias_list_str, string title, string text, string transmission_content, int role_id)
        {
            String APPID = "";
            String APPKEY = "";
            String MASTERSECRET = "";
            if (role_id == 2)
            {
                APPID = "CuAQ3h9MP39OHtOx8bdzu3";
                APPKEY = "3TitJm47Og9xT7JeQYfj11";
                MASTERSECRET = "FzCOYUbsaN9dulGHd1my75";
            }
            else if (role_id == 3)
            {
                APPID = "770lAMYDP86TVg1RQMQwA4";
                APPKEY = "hDME2xorANAF0miHddCkU3";
                MASTERSECRET = "PXrTN6Nrb66Sq5IrrZRud3";
            }
            String HOST = "http://sdk.open.api.igexin.com/apiex.htm";
            String pushResult = "";

            
            // 推送主类（方式1，不可与方式2共存）
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            // 推送主类（方式2，不可与方式1共存）此方式可通过获取服务端地址列表判断最快域名后进行消息推送，每10分钟检查一次最快域名
            //IGtPush push = new IGtPush("",APPKEY,MASTERSECRET);
            ListMessage message = new ListMessage();

            NotificationTemplate template = NotificationTemplateDemo(APPID, APPKEY, title, text, transmission_content);
            // 用户当前不在线时，是否离线存储,可选
            message.IsOffline = true;
            // 离线有效时间，单位为毫秒，可选
            message.OfflineExpireTime = 1000 * 3600 * 12;
            message.Data = template;
            //message.PushNetWorkType = 0;        //判断是否客户端是否wifi环境下推送，1为在WIFI环境下，0为不限制网络环境。
            //设置接收者
            List<com.igetui.api.openservice.igetui.Target> targetList = new List<com.igetui.api.openservice.igetui.Target>();

            string[] alias_list = alias_list_str.Split(new char[1] { ',' });
            foreach (string alias in alias_list)
            {
                com.igetui.api.openservice.igetui.Target target = new com.igetui.api.openservice.igetui.Target();
                target.appId = APPID;
                target.alias = alias;
                targetList.Add(target);
            }

            

            String contentId = push.getContentId(message);
            pushResult = push.pushMessageToList(contentId, targetList);
            return pushResult;
        }




        //通知透传模板动作内容
        public static NotificationTemplate NotificationTemplateDemo(String APPID,String APPKEY,string title,string text, string transmission_content)
        {
            NotificationTemplate template = new NotificationTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            //通知栏标题
            template.Title = title;
            //通知栏内容     
            template.Text = text;
            //通知栏显示本地图片
            template.Logo = "";
            //通知栏显示网络图标
            template.LogoURL = "";
            //应用启动类型，1：强制应用启动  2：等待应用启动
            template.TransmissionType = "2";
            //透传内容  
            template.TransmissionContent = transmission_content;
            //接收到消息是否响铃，true：响铃 false：不响铃   
            template.IsRing = true;
            //接收到消息是否震动，true：震动 false：不震动   
            template.IsVibrate = true;
            //接收到消息是否可清除，true：可清除 false：不可清除    
            template.IsClearable = true;
            //设置通知定时展示时间，结束时间与开始时间相差需大于6分钟，消息推送后，客户端将在指定时间差内展示消息（误差6分钟）
            String begin = "2017-07-15 12:46:00";
            String end = "2117-07-15 12:56:20";
            template.setDuration(begin, end);

            return template;
        }

        //透传模板动作内容
        public static TransmissionTemplate TransmissionTemplateDemo()
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = "5n4ySmpwGy8E7vqVNVbVd3";
            template.AppKey = "FnfWbe2vbF9Mpj9ZtwJ3NA";
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = "1";
            //透传内容  
            template.TransmissionContent = "透传内容";
            //设置通知定时展示时间，结束时间与开始时间相差需大于6分钟，消息推送后，客户端将在指定时间差内展示消息（误差6分钟）
            String begin = "2015-03-06 14:36:10";
            String end = "2015-03-06 14:46:20";
            template.setDuration(begin, end);

            return template;
        }

        //网页模板内容
        public static LinkTemplate LinkTemplateDemo()
        {
            LinkTemplate template = new LinkTemplate();
            template.AppId = "5n4ySmpwGy8E7vqVNVbVd3";
            template.AppKey = "FnfWbe2vbF9Mpj9ZtwJ3NA";
            //通知栏标题
            template.Title = "请填写通知标题";
            //通知栏内容 
            template.Text = "请填写通知内容";
            //通知栏显示本地图片 
            template.Logo = "";
            //通知栏显示网络图标，如无法读取，则显示本地默认图标，可为空
            template.LogoURL = "";
            //打开的链接地址    
            template.Url = "http://www.baidu.com";
            //接收到消息是否响铃，true：响铃 false：不响铃   
            template.IsRing = true;
            //接收到消息是否震动，true：震动 false：不震动   
            template.IsVibrate = true;
            //接收到消息是否可清除，true：可清除 false：不可清除
            template.IsClearable = true;
            return template;
        }

        //通知栏弹框下载模板
        public static NotyPopLoadTemplate NotyPopLoadTemplateDemo()
        {
            NotyPopLoadTemplate template = new NotyPopLoadTemplate();
            template.AppId = "5n4ySmpwGy8E7vqVNVbVd3";
            template.AppKey = "FnfWbe2vbF9Mpj9ZtwJ3NA";
            //通知栏标题
            template.NotyTitle = "请填写通知标题";
            //通知栏内容
            template.NotyContent = "请填写通知内容";
            //通知栏显示本地图片
            template.NotyIcon = "icon.png";
            //通知栏显示网络图标
            template.LogoURL = "http://www-igexin.qiniudn.com/wp-content/uploads/2013/08/logo_getui1.png";
            //弹框显示标题
            template.PopTitle = "弹框标题";
            //弹框显示内容    
            template.PopContent = "弹框内容";
            //弹框显示图片    
            template.PopImage = "";
            //弹框左边按钮显示文本    
            template.PopButton1 = "下载";
            //弹框右边按钮显示文本    
            template.PopButton2 = "取消";
            //通知栏显示下载标题
            template.LoadTitle = "下载标题";
            //通知栏显示下载图标,可为空 
            template.LoadIcon = "file://push.png";
            //下载地址，不可为空
            template.LoadUrl = "http://www.appchina.com/market/d/425201/cop.baidu_0/com.gexin.im.apk ";
            //应用安装完成后，是否自动启动
            template.IsActived = true;
            //下载应用完成后，是否弹出安装界面，true：弹出安装界面，false：手动点击弹出安装界面 
            template.IsAutoInstall = true;
            //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsBelled = true;
            //接收到消息是否震动，true：震动 false：不震动   
            template.IsVibrationed = true;
            //接收到消息是否可清除，true：可清除 false：不可清除    
            template.IsCleared = true;
            return template;
        }

    }
}
