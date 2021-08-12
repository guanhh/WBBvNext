# RunProject

### 开发环境准备

1. `.NET5`
2. `Visual Studio 2019`
3. `SQL Server 2014` 及以上版本

### 下载 `WBBvNext`

通过 `git` 下载

```
git clone https://gitee.com/guan2h/WBB-vNext.git
```

直接下载

[https://gitee.com/guan2h/WBB-vNext](https://gitee.com/guan2h/WBB-vNext)


### 编译模块

`WBBvNext` 自带了以下模块

- `Doc` 模块；（说明文档）
- `Feedback` 模块；（反馈中心）
- `PDF` 模块；（集成 `pdf.js` 功能）
- `School` 模块；（样例模块，演示 `WBBvNext` 功能）
- `WBB` 模块；（模块开发代码生成）


![模块](/images/wbb_modules.PNG)


### 模块加载位置


`WBBvNext` 默认从可执行程序所在路径的 `WBBPlugs` 目录下加载模块 dll

将编译好的模块，安装模块名称新建文件夹，并将 dll 放置在对应模块文件夹下

如下：

![模块路径](/images/wbb_module_path.PNG)

例如 `School` 模块文件夹内容：

![School模块](/images/school_all_dll.PNG)


> 注意：模块引用的一些外部库，需要一起放置在模块目录下


### 包含静态资源的模块


`PDF` 模块包含 `pdf.js` 相关静态资源，需要将资源放置在模块目录下。


![PDF模块](/images/pdf_all_dll.PNG)


`Doc` 模块包含了图片和 md 文档。

![Doc模块](/images/doc_all_dll.PNG)

加载运行后的 `Doc模块`

![Doc模块界面](/images/wbb_show_doc.PNG)

### 配置连接字符串

在 `appsetting.json` 文件中，配置相关数据库模块连接字符串

### 运行 WBBvNext

设置 `WBBvNext` 为启动项，运行

### 至此，项目启动已经完成