# WBB vNext

### 介绍
`WBBvNext` 是基于 `WTM` 开源项目改造的完全解耦的插件式开发框架

-- `WBBvNext` 在线文档：[https://guanhh.github.io/wbb-vnext-doc/](https://guanhh.github.io/wbb-vnext-doc/)


-- 原始文档：[https://gitee.com/guan2h/wbb-vnext-doc](https://gitee.com/guan2h/wbb-vnext-doc)

文档通过 `mkdocs-material` 工具将 `md` 文件（原始文档）构建为静态站点（在线文档），`mkdocs-material` 具体使用请移步 
[https://squidfunk.github.io/mkdocs-material/](https://squidfunk.github.io/mkdocs-material/)


>WTM 是一个快速开发框架
>
>框架开源地址：https://github.com/dotnetcore/WTM
>
>框架在线文档：https://wtmdoc.walkingtec.cn


### WBBvNext

`WBBvNext` 名称取自 `WTM` 和 `BootstrapBlazor` 的首字母，`VNext` 表示基于 `WTM` 改造后的项目

主要特点：

1. 插件式开发，完全解耦；
2. 低代码；

插件应用
1.  将样例插件 `School` 编译

![插件源码](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/school_code.PNG)

2.  将生成的 `dll` 放置 `WBBPlugs` 目录

![插件放置位置](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/plug.PNG)

3.  运行 `WBBvNext`

![加载插件运行](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/school.PNG)

### 演示截图

![login](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_login.png)

![home](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_home.png)

![user](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_user.png)

![role](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_role.png)

![wbb](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_wbb.png)

![line](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_line.png)

![feedback](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_show_feedback.png)


### 项目结构

项目结构说明

![项目结构](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_project.PNG)

### 开发环境

1. 安装 `.NET5`
2. 安装 `Visual Studio 2019`
3. 安装 `SQL Server 2014` 及以上版本

### 使用说明

1.  编译 `WBB` 插件，置于 `WBBPlugs` 目录下

![插件目录](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/wbb_dll.PNG)

2.  设置 `WBBvNext` 为启用项，运行项目

3.  配置插件参数，生成插件结构

![插件界面](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/plug_codegen.PNG)

4. 生成插件代码后，将工程添加到 `WBBvNext` 中

5. 编辑插件

具体使用请移步在线文档：[https://guanhh.github.io/wbb-vnext-doc/](https://guanhh.github.io/wbb-vnext-doc/)

或 md 文档：[https://gitee.com/guan2h/wbb-vnext-doc](https://gitee.com/guan2h/wbb-vnext-doc)

### 新增

PDF预览

![PDF预览](https://gitee.com/guan2h/WBB-vNext/raw/master/WBBPlugs/Doc/WBBvNext.Doc.Page/Doc/images/pdf_priview.PNG)

### 待办
- [x] `WBB` 模板模块
- [x] 样例模块
- [x] `Doc` 模块
- [x] `PDF` 模块
- [ ] 持续集成更多功能模块

### 引用开源项目

WTM 是一个快速开发框架

—— 框架开源地址：https://github.com/dotnetcore/WTM

—— 框架在线文档：https://wtmdoc.walkingtec.cn

BootstrapBlazor，一套基于 Bootstrap 和 Blazor 的企业级组件库

—— 框架开源地址：https://github.com/dotnetcore/BootstrapBlazor

—— 框架在线文档：https://www.blazor.zone

PDF.js 一个通用的、基于 Web 标准的平台，用于分析和渲染 PDF。

—— 框架开源地址：https://github.com/mozilla/pdf.js

—— 框架在线文档：https://mozilla.github.io/pdf.js/getting_started