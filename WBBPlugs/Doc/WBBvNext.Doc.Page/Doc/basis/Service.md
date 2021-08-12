# Service

`WBBvNext` 对模块中继承了以下接口的服务，会自动注入

```csharp
public interface ITransientService
{
}

public interface IScopedService
{
}

public class ISingletonService
{
}
```


请在模块的 `Extension` 层进行服务编写

`Abstract` 层定义服务接口

例如样例模块 `School` 中：

`WBBvNext.School.Abstract` 层定义服务接口

```csharp
public interface IPinyinService
{
    string ConvertToAllSpell(string strChinese);
}
```

`WBBvNext.School.Extension` 层实现服务

```csharp
public class PinyinService : ISingletonService, IPinyinService
{
    public string ConvertToAllSpell(string strChinese)
    {
        return PinYinHelper.ConvertToAllSpell(strChinese);
    }
}
```


`WBBvNext.School.Page` 中直接使用服务

```csharp
[Inject]
private IPinyinService pinYinService { get; set; }

private string ChineseStr = "你好杭州";

private string PinyinStr;

public void Convert()
{
    PinyinStr = pinYinService.ConvertToAllSpell(ChineseStr);
}
```