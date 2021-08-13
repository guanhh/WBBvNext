# StaticFile

> 模块中加载静态文件

模块通过实现 `WBBvNext.Base` 中的 `IStaticFileProvider` 接口，可以将模块中指定静态文件加载到 `WBBvNext` 中

```csharp
public interface IStaticFileProvider
{
    string GetRequestPath();

    IFileProvider GetFileProvider();
}
```

具体样例可参考 `Doc` 模块和 `PDF` 模块实现

如下：

```csharp
public class DocStaticFileProvider : IStaticFileProvider
{
    public string GetRequestPath()
    {
        return "/images";
    }

    public IFileProvider GetFileProvider()
    {
        var assDir = typeof(DocStaticFileProvider).Assembly.Location;
        var dir = Directory.GetParent(assDir);

        return new PhysicalFileProvider($"{dir}/Doc/Images");
    }
}
```