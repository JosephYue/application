using Newtonsoft.Json;
using System;

namespace Application.Jingdong.Extension.JingDongAlliance.Param
{
    public class GoodsJingFenQueryParam : ValidateParam
    {
        /// <summary>
        /// 频道ID:
        /// 1-好券商品
        /// 2-精选卖场
        /// 10-9.9包邮
        /// 15-京东配送
        /// 22-实时热销榜
        /// 23-为你推荐
        /// 24-数码家电
        /// 25-超市
        /// 26-母婴玩具
        /// 27-家具日用
        /// 28-美妆穿搭
        /// 30-图书文具
        /// 31-今日必推
        /// 32-京东好物
        /// 33-京东秒杀
        /// 34-拼购商品
        /// 40-高收益榜
        /// 41-自营热卖榜
        /// 108-秒杀进行中
        /// 109-新品首发
        /// 110-自营
        /// 112-京东爆品
        /// 125-首购商品
        /// 129-高佣榜单
        /// 130-视频商品
        /// 153-历史最低价商品榜
        /// 210-极速版商品
        /// 238-新人价商品
        /// 247-京喜9.9
        /// 249-京喜秒杀
        /// 1000-招商团长
        /// 1001-选品库
        /// </summary>
        [JsonProperty("eliteId")]
        public int EliteId { get; set; }

        /// <summary>
        /// 页码，默认1
        /// </summary>
        [JsonProperty("pageIndex")]
        public int? PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页数量，默认20，上限50，建议20
        /// </summary>
        [JsonProperty("pageSize")]
        public int? PageSize { get; set; } = 20;

        /// <summary>
        /// 排序字段
        /// price：单价
        /// commissionShare：佣金比例
        /// commission：佣金
        /// inOrderCount30DaysSku：sku维度30天引单量
        /// comments：评论数
        /// goodComments：好评数
        /// </summary>
        [JsonProperty("sortName")]
        public string SortName { get; set; }

        /// <summary>
        /// asc,desc升降序,默认降序
        /// </summary>
        [JsonProperty("sort")]
        public string Sort { get; set; }

        /// <summary>
        /// 联盟id_应用id_推广位id，三段式
        /// </summary>
        [JsonProperty("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 支持出参数据筛选，逗号','分隔，目前可用：
        /// videoInfo(视频信息)
        /// hotWords(热词)
        /// similar(相似推荐商品)
        /// documentInfo(段子信息)
        /// skuLabelInfo（商品标签）
        /// promotionLabelInfo（商品促销标签）
        /// </summary>
        [JsonProperty("fields")]
        public string Fields { get; set; }

        /// <summary>
        /// 10微信京东购物小程序禁售
        /// 11微信京喜小程序禁售
        /// </summary>
        [JsonProperty("forbidTypes")]
        public string ForbidTypes { get; set; }

        /// <summary>
        /// 选品库id（仅对eliteId=10001有效，且必传）
        /// </summary>
        [JsonProperty("groupId")]
        public long? GroupId { get; set; }

        /// <summary>
        /// groupId创建者的UnionId
        /// </summary>
        [JsonProperty("ownerUnionId")]
        public long? OwnerUnionId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        internal override void Validate()
        {
            if (EliteId <= 0)
            {
                throw new ArgumentNullException(nameof(EliteId));
            }
        }
    }
}
