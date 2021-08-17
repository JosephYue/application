using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    /// <summary>
    /// 京东注册用户判定业务参数
    /// </summary>
    public class UserRegisterValidateParam : ValidateParam
    {
        /// <summary>
        /// userIdType对应的用户设备ID，userIdType和userId需同时传入
        /// 示例1： userIdType设置为8时，此时userId需要设置为安卓移动设备Imei，如861794042953717 
        /// 示例2： userIdType设置为16时，此时userId需要设置为苹果移动设备Openudid，如f99dbd2ba8de45a65cd7f08b7737bc919d6c87f7 
        /// 示例3： userIdType设置为32时，此时userId需要设置为苹果移动设备idfa，如DCC77BDA-C2CA-4729-87D6-B7F65C8014D6 
        /// 示例4： userIdType设置为64时，此时userId需要设置为安卓移动设备imei的32位大写的MD5编码，如1097787632DB8876D325C356285648D0（原始imei：861794042953717） 
        /// 示例5： userIdType设置为128时，此时userId需要设置为苹果移动设备idfa的32位大写的MD5编码，如01D0C2D675F700BA3716C05F39BDA0EB（原始idfa：DCC77BDA-C2CA-4729-87D6-B7F65C8014D6） 
        /// 示例6： userIdType设置为32768时，此时userId需要设置为安卓移动设备oaid，如7dafe7ff-bffe-a28b-fdf5-7fefdf7f7e85
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// 用户ID类型，当前userIdType支持的枚举值包括：8、16、32、64、128、32768。
        /// userIdType和userId需同时传入，且一一对应。
        /// userIdType各枚举值对应的userId含义如下：
        /// 8(安卓移动设备Imei)
        /// 16(苹果移动设备Openudid)
        /// 32(苹果移动设备idfa)
        /// 64(安卓移动设备imei的md5编码，32位，大写，匹配率略低)
        /// 128(苹果移动设备idfa的md5编码，32位，大写，匹配率略低)
        /// 32768(安卓移动设备oaid)；131072(安卓移动设备oaid的md5编码，32位，大写)
        /// 1048576（苹果移动设备caid）
        /// </summary>
        [JsonProperty("userIdType")]
        public int UserIdType { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(UserId))
            {
                throw new ArgumentNullException(nameof(UserId));
            }
            if (UserIdType <= 0)
            {
                throw new ArgumentNullException(nameof(UserIdType));
            }
        }
    }
}
