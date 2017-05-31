using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
namespace BLL
{
    public class UploadFile
    {
        #region 字段

        private string _UploadInfo;
        private bool _UploadState;
        private string _FileType;
        private int _FileSize;
        private int _MaxFileSize;
        private string _NewFileName;

        #endregion




        public UploadFile()
        {
            _UploadInfo = "NONE";
            _UploadState = false;
            _FileType = "*";
            _MaxFileSize = 1024000;
            _NewFileName = "";
        }

        #region 属性

        public string UploadInfo
        {
            set { _UploadInfo = value; }
            get { return _UploadInfo; }
        }


        public bool UploadState
        {
            set { _UploadState = value; }
            get { return _UploadState; }
        }


        public string FileType
        {
            set { _FileType = value; }
            get { return _FileType; }
        }


        public int FileSize
        {
            get { return _FileSize / 1024; }
        }


        public int MaxFileSize
        {
            set { _MaxFileSize = value * 1024; }
            get { return _MaxFileSize / 1024; }
        }


        public string NewFileName
        {
            set { _NewFileName = value; }
            get { return _NewFileName; }
        }

        #endregion



        public void UploadFileGo(string strSaveDir, FileUpload FileUploadCtrlID)
        {
            int intFileExtPoint = FileUploadCtrlID.PostedFile.FileName.LastIndexOf(".");
            string strFileExtName = FileUploadCtrlID.PostedFile.FileName.Substring(intFileExtPoint + 1).ToLower();

            _FileSize = FileUploadCtrlID.PostedFile.ContentLength;

            if (_FileSize == 0)
            {
                _UploadInfo = "没有选择要上传的文件或所选文件大小为0字节";
                _UploadState = false;
                return;
            }

            if (_FileSize > _MaxFileSize)
            {
                _UploadInfo = "上传的文件超过限制大小(" + (_MaxFileSize / 1024).ToString() + "K)";
                _UploadState = false;
                return;
            }

            if (_FileType != "*")
            {
                if (_FileType.ToLower().IndexOf(strFileExtName.ToLower().Trim()) == -1)
                {
                    _UploadInfo = "不允许上传的文件类型";
                    _UploadState = false;
                    return;
                }
            }

            if (_NewFileName == "")
            {
                DateTime dteNow = DateTime.Now;
                _NewFileName = dteNow.Year.ToString() + dteNow.Month.ToString() + dteNow.Day.ToString() + GetRandomStr(8);
                _NewFileName = _NewFileName + "." + strFileExtName;
            }
            FileUploadCtrlID.PostedFile.SaveAs(this.GetSaveDirectory(strSaveDir) + _NewFileName);
            _UploadInfo = "已成功上传";
            _UploadState = true;

        }




        private string GetRandomStr(int RndNumCount)
        {
            string RandomStr;
            RandomStr = "";
            Random Rnd = new Random();
            for (int i = 1; i <= RndNumCount; i++)
            {
                RandomStr += Rnd.Next(0, 9).ToString();
            }
            return RandomStr;
        }





        public string GetSaveDirectory(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            return DirectoryPath;
        }

    }





}