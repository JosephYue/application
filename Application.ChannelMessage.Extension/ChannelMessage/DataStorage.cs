using Application.ChannelMessage.Extension.ChannelMessage.Config;
using Application.ChannelMessage.Extension.ChannelMessage.Enum.Status;
using Application.ChannelMessage.Extension.ChannelMessage.ValueModel;
using Application.ChannelMessage.Extension.Config;
using MySqlConnector;
using System.Collections.Generic;

namespace Application.ChannelMessage.Extension.ChannelMessage
{
    internal class DataStorage : MySqlConnectionConfig
    {
        #region 修改发布信息状态

        /// <summary>
        /// 修改发布信息状态
        /// </summary>
        /// <param name="id">消息di</param>
        /// <param name="state">消息状态</param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public void ChangePublishState(string id, MessageStatusEnum state, string msg = "")
        {
            var sql = $"UPDATE `{PublishTableName}` SET `StatusName`=@StatusName,`ExecuteMessage`=@ExecuteMessage WHERE `Id`=@Id";

            object[] sqlParams =
            {
                new MySqlParameter("@Id", id),
                new MySqlParameter("@ExecuteMessage", msg),
                 new MySqlParameter("@StatusName",state.ToString("G")),
            };

            Execute(sql, sqlParams);
        }

        #endregion

        #region 修改接收信息状态

        /// <summary>
        /// 修改接收信息状态
        /// </summary>
        /// <param name="id">消息id</param>
        /// <param name="state">消息状态</param>
        /// <param name="retries"></param>
        /// <param name="msg">错误信息</param>
        /// <returns></returns>
        public void ChangeReceiveState(string id, MessageStatusEnum state, int retries = 50, string msg = "")
        {
            var sql = $"UPDATE `{ReceiveTableName}` SET `StatusName`=@StatusName,`ExecuteMessage`=@ExecuteMessage,`Retries`=@Retries WHERE `Id`=@Id";

            object[] sqlParams =
            {
                new MySqlParameter("@Id", id),
                new MySqlParameter("@ExecuteMessage", msg),
                new MySqlParameter("@StatusName",state.ToString("G")),
                new MySqlParameter("@Retries", retries),
            };

            Execute(sql, sqlParams);
        }

        #endregion

        #region 删除发布信息状态

        /// <summary>
        /// 删除发布信息状态
        /// </summary>
        /// <returns></returns>
        public void DelPublishExpireMessage()
        {
            //DELETE FROM 表名 WHERE 过滤条件

            var sql = $"DELETE FROM `{PublishTableName}` WHERE  `ExpiresTime` < '{Utils.GetDateTime()}' AND StatusName='Succeeded'";

            Execute(sql);
        }

        #endregion

        #region 删除过期的接收消息

        /// <summary>
        /// 删除过期的接收消息
        /// </summary>
        /// <returns></returns>
        public void DelReceiveExpireMessage()
        {
            var sql = $"DELETE FROM `{ReceiveTableName}` WHERE  `ExpiresTime` < '{Utils.GetDateTime()}' AND StatusName='Succeeded'";

            Execute(sql);
        }

        #endregion

        #region 添加发布信息

        /// <summary>
        /// 添加发布信息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public void InsertPublishMessage(PublishMessageValueModel message)
        {
            var sql = $"INSERT INTO `{PublishTableName}`(`Id`,`SubscriberName`,`Content`,`ExecuteMessage`,`Retries`,`CreateTime`,`ExpiresTime`,`StatusName`)" + $" VALUES(@Id,@SubscriberName,@Content,@ExecuteMessage,0,@CreateTime,@ExpiresTime,@StatusName);";

            object[] sqlParams =
            {
                new MySqlParameter("@Id", message.Id),
                new MySqlParameter("@SubscriberName", message.SubscriberName),
                new MySqlParameter("@Content", message.Content),
                new MySqlParameter("@ExecuteMessage", message.ExecuteMessage),
                //new MySqlParameter("@Retries", 0),
                new MySqlParameter("@CreateTime", Utils.GetDateTime()),
                new MySqlParameter("@ExpiresTime", Utils.GetDateTime().AddSeconds(ChannelMessageConfig.ChannelMessageOption.SucceedMessageExpiredAfter)),
                new MySqlParameter("@StatusName",message.Status.ToString("G")),
            };

            Execute(sql, sqlParams);
        }

        #endregion

        #region 添加接收信息

        /// <summary>
        /// 添加接收信息
        /// </summary>
        /// <param name="message">消息状态</param>
        /// <returns></returns>
        public void InsertReceiveMessage(ReceiveMessageValueModel message)
        {
            var sql = $"INSERT INTO `{ReceiveTableName}`(`Id`,`SubscriberName`,`Group`,`Content`,`ExecuteMessage`,`Retries`,`CreateTime`,`ExpiresTime`,`StatusName`)" + $" VALUES(@Id,@SubscriberName,@Group,@Content,@ExecuteMessage,0,@CreateTime,@ExpiresTime,@StatusName);";

            object[] sqlParams =
            {
                new MySqlParameter("@Id", message.Id),
                new MySqlParameter("@SubscriberName", message.SubscriberName),
                new MySqlParameter("@Group", message.Group),
                new MySqlParameter("@Content", message.Content),
                new MySqlParameter("@ExecuteMessage", message.ExecuteMessage),
                //new MySqlParameter("@Retries", 0),
                new MySqlParameter("@CreateTime", Utils.GetDateTime()),
                new MySqlParameter("@ExpiresTime", Utils.GetDateTime().AddSeconds(ChannelMessageConfig.ChannelMessageOption.SucceedMessageExpiredAfter)),
                new MySqlParameter("@StatusName",message.Status.ToString("G")),
            };

            Execute(sql, sqlParams);
        }

        #endregion

        #region 获取需要重试的接收消息

        /// <summary>
        /// 获取需要重试的接收消息
        /// </summary>
        /// <returns></returns>
        public List<RetryMessageValueModel> GetReceiveRetryMessages()
        {
            var fourMinAgo = Utils.GetDateTime().AddMinutes(-4).ToString("O");

            var sql = $"SELECT `Id`,`Content`,`Retries`,`SubscriberName`,`Group` FROM `{ReceiveTableName}` WHERE `Retries`<{ChannelMessageConfig.ChannelMessageOption.FailedRetryCount} " +
                $" AND `CreateTime`<'{fourMinAgo}' AND (`StatusName` = '{MessageStatusEnum.Failed}' OR `StatusName` = '{MessageStatusEnum.Scheduled}') LIMIT 200;";

            var result = Query(sql, (reader) =>
               {
                   var messages = new List<RetryMessageValueModel>();

                   while (reader.Read())
                   {
                       messages.Add(new RetryMessageValueModel
                       {
                           Id = reader.GetInt64(0).ToString(),
                           Content = reader.GetString(1),
                           Retries = reader.GetInt32(2),
                           SubscriberName = reader.GetString(3),
                           Group = reader.GetString(4),
                       });
                   }

                   return messages;
               });

            return result;
        }

        #endregion

        #region 获取需要重试的发送消息

        /// <summary>
        /// 获取需要重试的发送消息
        /// </summary>
        /// <returns></returns>
        public List<RetryMessageValueModel> GetPublishRetryMessages()
        {
            var fourMinAgo = Utils.GetDateTime().AddMinutes(-4).ToString("O");

            var sql = $"SELECT `Id`,`Content`,`Retries`,`SubscriberName` FROM `{PublishTableName}` WHERE `Retries`<{ChannelMessageConfig.ChannelMessageOption.FailedRetryCount} " +
                $" AND `CreateTime`<'{fourMinAgo}' AND (`StatusName` = '{MessageStatusEnum.Failed}' OR `StatusName` = '{MessageStatusEnum.Scheduled}') LIMIT 200;";

            var result = Query(sql, (reader) =>
            {
                var messages = new List<RetryMessageValueModel>();

                while (reader.Read())
                {
                    messages.Add(new RetryMessageValueModel
                    {
                        Id = reader.GetInt64(0).ToString(),
                        Content = reader.GetString(1),
                        Retries = reader.GetInt32(2),
                        SubscriberName = reader.GetString(3)
                    });
                }

                return messages;
            });

            return result;
        }

        #endregion

        #region 初始化数据库

        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void InitializationTable()
        {
            var batchSql =
               $@"
CREATE TABLE IF NOT EXISTS `{ReceiveTableName}` (
  `Id` bigint NOT NULL,
  `SubscriberName` varchar(400) DEFAULT NULL,
  `Group` varchar(400) NOT NULL,
  `Content` longtext,
  `ExecuteMessage` longtext,
  `Retries` int(11) DEFAULT 0,
  `CreateTime` datetime NOT NULL,
  `ExpiresTime` datetime DEFAULT NULL,
  `StatusName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_ExpiresAt`(`ExpiresTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS `{PublishTableName}` (
  `Id` bigint NOT NULL,
  `SubscriberName` varchar(400) DEFAULT NULL,
  `Content` longtext,
  `ExecuteMessage` longtext,
  `Retries` int(11) DEFAULT 0,
  `CreateTime` datetime NOT NULL,
  `ExpiresTime` datetime DEFAULT NULL,
  `StatusName` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IX_ExpiresAt`(`ExpiresTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
";

            Execute(batchSql);
        }

        #endregion

        #region Private

        /// <summary>
        /// 发送表 表名
        /// </summary>
        string PublishTableName
        {
            get
            {
                return ChannelMessageConfig.ChannelMessageOption.TableNamePrefix + ".published";
            }
        }

        /// <summary>
        /// 接收表 表名
        /// </summary>
        string ReceiveTableName
        {
            get
            {
                return ChannelMessageConfig.ChannelMessageOption.TableNamePrefix + ".received";
            }
        }

        #endregion
    }
}
