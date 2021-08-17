using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Application.Extension.Infrastructure.Common
{
    public sealed class ExcelCommon
    {
        #region 下载Excel到本地目录

        /// <summary>
        /// 下载Excel到本地目录
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息（内容类型默认：string）</param>
        /// <param name="localPath">指定的本地路径，没有则默认为程序集的根目录</param>
        /// <returns></returns>
        public static string DownloadToLocal<T>(List<T> excelData, List<string> headers, string localPath = "") where T : class, new()
        {
            string fileName = $@"\excel_{ Guid.NewGuid().ToString().Replace("-", "") }.xlsx";

            if (string.IsNullOrWhiteSpace(localPath))
            {
                string sWebRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "DownloadExcel", Utils.GetDateTime().ToString("yyyyMMdd"));

                if (!Directory.Exists(sWebRootFolder))
                {
                    Directory.CreateDirectory(sWebRootFolder);
                }

                localPath = sWebRootFolder;
            }

            FileInfo file = new FileInfo(localPath + fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            excelData.ToDataTable(table, false);

            MiniExcel.SaveAs(localPath + fileName, table);

            return localPath + fileName;
        }

        /// <summary>
        /// 下载Excel到本地目录
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息，需要指定对应的内容类型。例：typeof(string)</param>
        /// <param name="localPath">指定的本地路径，没有则默认为程序集的根目录</param>
        /// <returns></returns>
        public static string DownloadToLocal<T>(List<T> excelData, Dictionary<string, Type> headers, string localPath = "") where T : class, new()
        {
            string fileName = $@"\excel_{ Guid.NewGuid().ToString().Replace("-", "") }.xlsx";

            if (string.IsNullOrWhiteSpace(localPath))
            {
                string sWebRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "DownloadExcel", Utils.GetDateTime().ToString("yyyyMMdd"));

                if (!Directory.Exists(sWebRootFolder))
                {
                    Directory.CreateDirectory(sWebRootFolder);
                }

                localPath = sWebRootFolder;
            }

            FileInfo file = new FileInfo(localPath + fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header.Key, header.Value);
            }

            excelData.ToDataTable(table, false);

            MiniExcel.SaveAs(localPath + fileName, table);

            return localPath + fileName;
        }

        /// <summary>
        /// 下载Excel到本地目录
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头（内容类型默认：string），第二个为当前sheet展示的内容）</param>
        /// <param name="localPath">指定的本地路径，没有则默认为程序集的根目录</param>
        /// <returns></returns>
        public static string DownloadToLocal<T>(Dictionary<string, (List<string>, List<T>)> sheetDatas, string localPath = "") where T : class, new()
        {
            string fileName = $@"\excel_{ Guid.NewGuid().ToString().Replace("-", "") }.xlsx";

            if (string.IsNullOrWhiteSpace(localPath))
            {
                string sWebRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "DownloadExcel", Utils.GetDateTime().ToString("yyyyMMdd"));

                if (!Directory.Exists(sWebRootFolder))
                {
                    Directory.CreateDirectory(sWebRootFolder);
                }

                localPath = sWebRootFolder;
            }

            FileInfo file = new FileInfo(localPath + fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable()
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header);
                }

                excelData.ToDataTable(table, false);

                sheets.Tables.Add(table);
            }

            MiniExcel.SaveAs(localPath + fileName, sheets);

            return localPath + fileName;
        }

        /// <summary>
        /// 下载Excel到本地目录
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头，需要指定对应的内容类型 例：typeof(string)。第二个为当前sheet展示的内容）</param>
        /// <param name="localPath">指定的本地路径，没有则默认为程序集的根目录</param>
        /// <returns></returns>
        public static string DownloadToLocal<T>(Dictionary<string, (Dictionary<string, Type>, List<T>)> sheetDatas, string localPath = "") where T : class, new()
        {
            string fileName = $@"\excel_{ Guid.NewGuid().ToString().Replace("-", "") }.xlsx";

            if (string.IsNullOrWhiteSpace(localPath))
            {
                string sWebRootFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory ?? string.Empty, "DownloadExcel", Utils.GetDateTime().ToString("yyyyMMdd"));

                if (!Directory.Exists(sWebRootFolder))
                {
                    Directory.CreateDirectory(sWebRootFolder);
                }

                localPath = sWebRootFolder;
            }

            FileInfo file = new FileInfo(localPath + fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable()
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header.Key, header.Value);
                }

                excelData.ToDataTable(table, false);

                sheets.Tables.Add(table);
            }

            MiniExcel.SaveAs(localPath + fileName, sheets);

            return localPath + fileName;
        }

        #endregion

        #region 创建Excel的Stream信息

        /// <summary>
        /// 创建Excel的Stream信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息（内容类型默认：string）</param>
        /// <returns></returns>
        public static Stream CreateToStream<T>(List<T> excelData, List<string> headers) where T : class, new()
        {
            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            excelData.ToDataTable(table, false);

            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(table);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        /// <summary>
        /// 创建Excel的Stream信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息，需要指定对应的内容类型。例：typeof(string)</param>
        /// <returns></returns>
        public static Stream CreateToStream<T>(List<T> excelData, Dictionary<string, Type> headers) where T : class, new()
        {
            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header.Key, header.Value);
            }

            excelData.ToDataTable(table, false);

            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(table);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        /// <summary>
        /// 创建Excel的Stream信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头（内容类型默认：string），第二个为当前sheet展示的内容）</param>
        /// <returns></returns>
        public static Stream CreateToStream<T>(Dictionary<string, (List<string>, List<T>)> sheetDatas) where T : class, new()
        {
            var memoryStream = new MemoryStream();

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header);
                }

                excelData.ToDataTable(table, false);
                sheets.Tables.Add(table);
            }

            memoryStream.SaveAs(sheets);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        /// <summary>
        /// 创建Excel的Stream信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头，需要指定对应的内容类型 例：typeof(string)。第二个为当前sheet展示的内容）</param>
        /// <returns></returns>
        public static Stream CreateToStream<T>(Dictionary<string, (Dictionary<string, Type>, List<T>)> sheetDatas) where T : class, new()
        {
            var memoryStream = new MemoryStream();

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header.Key, header.Value);
                }

                excelData.ToDataTable(table, false);
                sheets.Tables.Add(table);
            }

            memoryStream.SaveAs(sheets);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        #endregion

        #region 创建Excel的Bytes信息

        /// <summary>
        /// 创建Excel的Bytes信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息（内容类型默认：string）</param>
        /// <returns></returns>
        public static byte[] CreateToBytes<T>(List<T> excelData, List<string> headers) where T : class, new()
        {
            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            excelData.ToDataTable(table, false);

            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(table);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream.GetBuffer();
        }

        /// <summary>
        /// 创建Excel的Bytes信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="excelData">excel信息</param>
        /// <param name="headers">excel的头部信息，需要指定对应的内容类型。例：typeof(string)</param>
        /// <returns></returns>
        public static byte[] CreateToBytes<T>(List<T> excelData, Dictionary<string, Type> headers) where T : class, new()
        {
            var table = new DataTable();

            foreach (var header in headers)
            {
                table.Columns.Add(header.Key, header.Value);
            }

            excelData.ToDataTable(table, false);

            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(table);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream.GetBuffer();
        }

        /// <summary>
        /// 创建Excel的Bytes信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头（内容类型默认：string），第二个为当前sheet展示的内容）</param>
        /// <returns></returns>
        public static byte[] CreateToBytes<T>(Dictionary<string, (List<string>, List<T>)> sheetDatas) where T : class, new()
        {
            var memoryStream = new MemoryStream();

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header);
                }

                excelData.ToDataTable(table, false);
                sheets.Tables.Add(table);
            }

            memoryStream.SaveAs(sheets);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream.GetBuffer();
        }

        /// <summary>
        /// 创建Excel的Bytes信息
        /// </summary>
        /// <typeparam name="T">泛型实体</typeparam>
        /// <param name="sheetDatas">工作表名称（字典key为sheet的名称，字典value为元组，元组的第一个字段为当前sheet内容的表头，需要指定对应的内容类型 例：typeof(string)。第二个为当前sheet展示的内容）</param>
        /// <returns></returns>
        public static byte[] CreateToBytes<T>(Dictionary<string, (Dictionary<string, Type>, List<T>)> sheetDatas) where T : class, new()
        {
            var memoryStream = new MemoryStream();

            var sheets = new DataSet();

            foreach (var data in sheetDatas)
            {
                var table = new DataTable
                {
                    TableName = data.Key
                };

                var (headers, excelData) = data.Value;

                foreach (var header in headers)
                {
                    table.Columns.Add(header.Key, header.Value);
                }

                excelData.ToDataTable(table, false);
                sheets.Tables.Add(table);
            }

            memoryStream.SaveAs(sheets);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream.GetBuffer();
        }

        #endregion
    }
}
