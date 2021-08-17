using System;
using System.Text;

namespace Application.Extension.Infrastructure.Common
{
    public class StringCommon
    {
        #region 生成随机字符串

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        public static string GenerateString()
        {
            // 创建一个StringBuilder对象存储密码
            StringBuilder sb = new StringBuilder();
            //使用for循环把单个字符填充进StringBuilder对象里面变成14位密码字符串
            for (int i = 0; i < 40; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                //随机选择里面其中的一种字符生成
                switch (random.Next(3))
                {
                    case 0:
                        //调用生成生成随机数字的方法
                        sb.Append(CreateNum());
                        break;
                    case 1:
                        //调用生成生成随机小写字母的方法
                        sb.Append(CreateSmallAbc());
                        break;
                    case 2:
                        //调用生成生成随机大写字母的方法
                        sb.Append(CreateBigAbc());
                        break;
                }
            }
            return sb.ToString();
        }

        #region 生成单个小写随机字母

        /// <summary>
        /// 生成单个小写随机字母
        /// </summary>
        private static string CreateSmallAbc()
        {
            //a-z的 ASCII值为97-122
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int num = random.Next(97, 123);
            string abc = Convert.ToChar(num).ToString();
            return abc;
        }

        #endregion

        #region 生成单个大写随机字母

        /// <summary>
        /// 生成单个大写随机字母
        /// </summary>
        private static string CreateBigAbc()
        {
            //A-Z的 ASCII值为65-90
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int num = random.Next(65, 91);
            string abc = Convert.ToChar(num).ToString();
            return abc;
        }

        #endregion

        #region 生成单个随机数字

        /// <summary>
        /// 生成单个随机数字
        /// </summary>
        private static int CreateNum()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int num = random.Next(10);
            return num;
        }

        #endregion

        #endregion
    }
}
