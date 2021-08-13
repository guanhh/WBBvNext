# EditModule

>借助 `WTM` 框架的自动生成功能，自动生成 Model 的 CRUD 操作及交互 UI

### 创建 model

本样例模块演示的是创建一个反馈信息收集功能，所以创建以下对象，用来保持反馈信息

```csharp

[Table("Suggestions")]
public class Suggestion : BasePoco
{
    [Required]
    [DisplayName("Suggestion.Title")]
    [StringLength(20)]
    public string Title { get; set; }

    [DisplayName("Suggestion.Detail")]
    [StringLength(200)]
    public string Detail { get; set; }

    [DisplayName("Suggestion.QuestionType")]
    public QuestionTypeEnum QuestionType { get; set; }

    [DisplayName("Suggestion.UserName")]
    [StringLength(20)]
    public string UserName { get; set; }

    [DisplayName("Suggestion.Email")]
    [StringLength(50)]
    public string Email { get; set; }

    [DisplayName("Suggestion.IsSolved")]
    public bool  IsSolved { get; set; }

    [DisplayName("Suggestion.Remark")]
    [StringLength(200)]
    public string Remark { get; set; }
}

public enum QuestionTypeEnum
{
    Bug,
    Suggestion,
    Other
}
```

关于 `Model` 创建的更多内容，请参考 `WTM` 中关于模型层的介绍
[https://wtmdoc.walkingtec.cn/#/Model/Poco](https://wtmdoc.walkingtec.cn/#/Model/Poco)

### `DataAccess` 层配置数据库上下文

因为只创建了一个 `Suggestion` 对象，所以增加如下

```csharp
public DbSet<Suggestion> Suggestions { get; set; }
```

![feedback_context](/images/feedback_dbcontext.PNG)


### 配置数据库连接

`appsetting.json` 中配置模块连接字符串

![feedback_conn](/images/feedback_connstr.PNG)


### 编译

编译 `WBBvNext.Feedback.DataAccess`

将如下 Model 和 DataAccess 放入 `WBBvNext` 可执行程序路径下的 `WBBPlugs` 下的 `Feedback` 目录下

如下：

![feedback_model_dll](/images/feedback_model_dll.PNG)


### 代码生成

运行 `WBBvNext`

点击右上角代码生成器

![codegen](/images/gen_code.PNG)

模块配置

- PlugName： 名称保持和模块生成时候输入的名称一致，如Feedback
- 选择模型：下拉列表选择与该模块相关对象，如Suggestion
- Area：建议在PlugName前加下划线，如_Feedback
- 模块名称：

![setting](/images/codegen_module_setting.PNG)

![field](/images/codegen_module_field.PNG)

![code](/images/codegen_module_code.PNG)

![cs](/images/codegen_module_cs.PNG)


### 定义模块信息

![module_info](/images/feedback_module_info.PNG)