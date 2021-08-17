using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
   public class GoodsCategoryQueryParam : ValidateParam
    {
        /// <summary>
        /// 父类目id(一级父类目为0)
        /// </summary>
        [JsonProperty("parentId")]
        public int ParentId { get; set; }

        /// <summary>
        /// 类目级别(类目级别 0，1，2 代表一、二、三级类目)
        /// </summary>
        [JsonProperty("grade")]
        public int Grade { get; set; }

        internal override void Validate()
        {
            if (ParentId <= 0)
            {
                throw new ArgumentNullException(nameof(ParentId));
            }
            if (Grade <= 0)
            {
                throw new ArgumentNullException(nameof(Grade));
            }
        }
    }
}
