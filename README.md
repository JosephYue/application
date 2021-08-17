# 介绍
    1、平时常用的方法，进行了总结及拓展。
    2、会根据自己的所学开源一些有趣的小玩意。
    3、看懂需要一定的.NetCore基础
    4、后期可能会衍生出一套框架
    5、希望能对大家有用，多多提意见
# 基础类库——Application.Extension.Infrastructure

#### Quartz定时

注意： **Quartz定时任务只能在程序入口处被发现，你写到非入口程序的代码无法被找到** 。

在Startup:ConfigureServices中注入服务：services.AddQuartz();

新建一个定时任务的类，之后继承JobBase，打上定时任务独有的Attribute。如下：


```
//"0 0/1 * * * ? "  corn表达式
//nameof(xxx)  定时任务名
//Group 定时任务分组名
[Job(nameof(xxx), "Group", "0 0/1 * * * ? ")]
[DisallowConcurrentExecution]
public class XXX : JobBase
{
    public XXX(IServiceScopeFactory serviceScopeFactory):Base(serviceScopeFactory)
    {
                        
    }

    public Task Processing()
    {
        //在此写执行代码
        var service=GetService<serviceType>();//获取服务用这种方式获取，依赖注入Dbcontext是scope类型会出现问题
    }
}
```

#### FluentValidation模型验证

在Startup:ConfigureServices中注入服务：


```
services.AddMvc(setup =>{setup.Filters.Add(typeof(ValidatorFilter));};//添加异常过滤
Validator.Register();//注册模型验证
```

使用：

```
///YYY你要验证的类名称
public class XXX: AbstractValidator<YYY>
{
    public XXX()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("姓名不能为空");
    }
}
```

#### 领域事件Event

在Startup:ConfigureServices中注入服务：


```
DomainEvent.Register();//注册领域事件
```

使用：

1、声明一个领域事件：

```
///因为我只声明了单个参数的领域事件，所以多参数请用元组传递，具体传递方式我也会在下面演示
public class XXX
{
    /// <summary>
    /// 声明事件方法
    /// </summary>
    public static event DomainEventHandler<(string,int,object)> ActionXXX;

    /// <summary>
    /// 触发事件方法
    /// </summary>
    public static void TriggerXXX(string param1,int param2,object param3)
    {
        ActionXXX?.Invoke((param1,param2,param3));
    }
}
```

2、注册两个事件接收：

```
///演示了两个事件的监听
public class ClassXXX
{
    [DomainEvent]
    public void EventXXX()
    {
        XXX.ActionXXX+=((string param1,int param2,object param3) param)=>
        {
            Console.WriteLine($"已触发事件 EventXXX");
            Console.WriteLine($"param1为： {param.param1}，param2为：{param.param2}，param3为：{JsonConvert.SerializeObject(param.param3)}");
        }
    }
    
    [DomainEvent]
    public void EventYYY()
    {
        XXX.ActionXXX+=(param)=>
        {
            var(param1,param2,param3)=param;
            Console.WriteLine($"已触发事件 EventYYY");
            Console.WriteLine($"param1为： {param1}，param2为：{param2}，param3为：{JsonConvert.SerializeObject(param3)}");
        }
    }
}
```

3、触发事件：

```
///测试触发事件
[HttpGet]
public void Get()
{
    XXX.TriggerXXX("str参数",1024,new
    {
        Name="小明",
        Age=16,
        Sex="女"
    });
}
```

#### HttpClient简单封装

在Startup:ConfigureServices中注入服务：


```
services.AddHttpClient<Client>();
```

使用：

```
public class XXXController : Controller
{
    private readonly Client _client;
                    
    public XXXController(Client client)
    {
    _client = client;
    }
    
    [HttpGet]
    public async Task<string> XXXAction()
    {
        var result=await _client.GetString("https://www.baidu.com");
        return result;
    }
}
```

# 消息插件——Application.ChannelMessage.Extension

介绍：一个看了CAP源码从而有些骚想法的中间件，根据channel实现了单体项目内的消息收发

#### 注册服务

在Startup:ConfigureServices中注入服务：

```
services.AddChannelMessage(option =>
{
    option.ConnectionString = "localhost";//数据库链接
    option.TableNamePrefix="message";//表名前缀，可选
    option.FailedRetryCount=50,//失败重试次数
    option.FailedRetryInterval=60,//失败消息轮询延迟时间
    option.SucceedMessageExpiredAfter=24*3600//成功消息删除时间
}); 
```

#### 发送消息


```
public class XXXController:Controller
{
    private readonly IChannelPublisher _channelPublisher;
                        
    public XXXController(IChannelPublisher channelPublisher)
    {
        _channelPublisher = channelPublisher;
    }
                        
    [HttpGet]
    public void XXXAction()
    {
        _channelPublisher.Write("xxxMessageName",new XXXClass
        {
            Name="小红",
            Age=18,
            Sex="男"
        })
    }
}
```

#### 订阅消息


```
public class XXXController:Controller
{
    ///注意XXXAction需保持在xxxMessageName消息 内名称唯一
    [ChannelSubscriber("xxxMessageName", "XXXAction")]
    public void XXXAction(XXXClass param)
    {
        Console.WriteLine("已接收消息:{nameof(XXXAction)}");
    }
                    
    [ChannelSubscriber("xxxMessageName", "YYYAction")]
    public void YYYAction(XXXClass param)
    {
        Console.WriteLine("已接收消息:{nameof(YYYAction)}");
    }
}
```

# EntityFrameworkCore——Application.EntityFrameworkCore.Extension

#### 开始使用

注入EFCore：

```
services.AddEntityFrameworkCore(option =>
{
    option.ConnectionConfig = new ConnectionConfig()
    {
        DbType = DbTypeEnum.MySql,
        ConnectionString = "数据库链接",
        MigrationsAssembly = "迁移文件需要生成在哪个程序集，需要指定程序集的名称，如：xxx.Api,不需要加dll"
    };
});
```

#### 创建实体

```
///活动实体 
///继承AggregateRoot主要是为了实现聚合的概念
///AggregateRoot 自带主键id
///仅做参考字段很少
///不考虑各种概念的可以什么都不用继承直接随意写就可以了
public class Activity: AggregateRoot<int>
{
    ///活动名称
    [MaxLength(100)]
    public string ActivityName { get; set; }
    
    ///创建时间
    public DateTime CreateTime { get; set; }=DateTime.Now;
    
    ///外键表 方便关系映射 也方便查询
    public virtual ActivityOther ActivityOther { get; set; }
}

///聚合下面的实体，实现以下一对一映射
///假如使用了 AggregateRoot 那么对用聚合下面的实体要用 Entity 这样才能实现聚合的含义
public class ActivityOther:Entity<int>
{
    ///创建时间
    public DateTime CreateTime { get; set; }=DateTime.Now;
    
    ///活动实体 用来做主外键映射
    public Activity Activity { get; set; }
}

```

#### Map映射


```
///具体的映射属性解释请百度
///只写一个Map，ActivityOther的Map举一反三
public class ActivityMap : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("activity");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.ActivityName ).HasComment("活动名称");
        builder.Property(t => t.CreateTime).HasComment("创建时间");
        ///仅介绍一对一，一对多举一反三
        builder.HasOne(t => t.ActivityOther).WithOne(t => t.Activity).HasForeignKey<ActivityOther>(t => t.Id).OnDelete(DeleteBehavior.Cascade);
    }
}

```


#### 仓储模式

```
///抽象
public interface IxxxRepository : IRepository<xxx(需要生成的表的实体), int(主键id类型)>
{
    
}

///具体
public interface IActivityRepository : IRepository<Activity, int>
{
    ///获取活动信息
    Activity Get(int id)；
}

```

#### 仓储实现


```
//抽象
public class xxxRepository : RepositoryBase<xxx, int>, IxxxRepository
{
    public xxxRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }

}

//具体
public class ActivityRepository : RepositoryBase<Activity, int>, IActivityRepository
{
    public ActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        
    }
    
    ///获取活动信息
    public Activity Get(int id)
    {
        return DbSet<Activity>().Where(x=>x.Id==id).FirstOrDefault();
    }
}

```

#### 工作单元IUnitOfWork及仓储的使用

```
public class ActivityController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IActivityRepository _activityRepository;
    
    public ActivityController(IUnitOfWork unitOfWork,
    IActivityRepository activityRepository)
    {
        _unitOfWork = unitOfWork;
        _activityRepository = activityRepository;
    }

    ///简单的添加修改
    [HttpPost]
    public ContentResult AddOrUpdate([FromBody] ActivityParam param)
    {
        var activity = _activityRepository.Get(param.Id);
        
        var isAdd=false;

        if(activity==null)
        {
            isAdd=true;
            activity = new Activity();
        }

        activity.ActivityName="测试修改";
        
        if(isAdd)
        {
            _activityRepository.Add(activity);
        }
        else
        {
            _activityRepository.Update(activity);
        }

        _unitOfWork.Commit();///提交代码
        return "success";
    }
}
```

#### 查询IQuery


```
public class ActivityController : Controller
{
    private readonly IQuery<Activity, int> _activityQuery;
   
    public ActivityController(IQuery<Activity, int> activityQuery)
    {
       _activityQuery = activityQuery;
    }

    ///简单的查询列表
    [HttpGet]
    public JsonResult Get()
    {
        var result= _activityLocationQuery.GetQueryable().Where(x=>x.CreateTime>=DateTime.Now).Select(x => new
        {
            activityName = x.ActivityName,
            createTime = x.CreateTime
        }).ToList()
        return base.Json(result);
    }
}
```

#### 迁移

1、选择程序包管理器控制台（ **记得一定要选择你在Startup里写的迁移文件需要生成在哪个程序集，选择对应的程序集** ）

![程序包管理器控制台](https://images.gitee.com/uploads/images/2021/0526/214031_ee99cf16_1734045.png "程序包管理器控制台")

2、执行命令Add-Migration 生成需要更新的迁移文件

![Add-Migration](https://images.gitee.com/uploads/images/2021/0526/214514_ce46623c_1734045.png "Add-Migration")

3、执行命令Update-Database开始迁移更新数据库

![Update-Database](https://images.gitee.com/uploads/images/2021/0526/214632_791a376b_1734045.png "Update-Database")





# 参与贡献

1.  Fork 本仓库
2.  新建 Application_xxx 分支
3.  提交代码
4.  新建 Pull Request


# 其他信息

1.  CSDN博客地址：https://blog.csdn.net/weixin_43837119/article/details/115641961

