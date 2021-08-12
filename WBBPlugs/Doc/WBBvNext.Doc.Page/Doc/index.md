# Intro

### 介绍

`WBBvNext` 是基于 `WTM` 开源项目改造的完全解耦的插件式开发框架

`WBBvNext`

-- 在线文档：[https://github.com/guanhh/wbb-vnext-doc](https://github.com/guanhh/wbb-vnext-doc)

-- 开源地址：[https://gitee.com/guan2h/WBB-vNext](https://gitee.com/guan2h/WBB-vNext)

>WTM 是一个快速开发框架
>
>框架开源地址：[https://github.com/dotnetcore/WTM](https://github.com/dotnetcore/WTM)
>
>框架在线文档：[https://wtmdoc.walkingtec.cn](https://wtmdoc.walkingtec.cn)


### WBBvNext

`WBBvNext` 名称取自 `WTM` 和 `BootstrapBlazor` 的首字母，`VNext` 表示基于 `WTM` 改造后的项目

主要特点：

1. 插件式开发，完全解耦；
2. 低代码；

插件应用
1.  将样例插件 `School` 编译

![插件源码](/images/school_code.PNG)

2.  将生成的 `dll` 放置 `WBBPlugs` 目录

![插件放置位置](/images/plug.PNG)

3.  运行 `WBBvNext`

![加载插件运行](/images/school.PNG)

### 演示截图

![login](/images/wbb_show_login.png)

![home](/images/wbb_show_home.png)

![user](/images/wbb_show_user.png)

![role](/images/wbb_show_role.png)

![wbb](/images/wbb_show_wbb.png)

![line](/images/wbb_show_line.png)

![feedback](/images/wbb_show_feedback.png)


### 项目结构

项目结构说明

![项目结构](/images/wbb_project.PNG)

### 开发环境

1. 安装 `.NET5`
2. 安装 `Visual Studio 2019`
3. 安装 `SQL Server 2014` 及以上版本

### 新增

PDF预览

![PDF预览](/images/pdf_priview.PNG)

### 待办
- [ ] 说明文档
- [ ] 测试用例
- [x] 基础信息可配置
- [x] 模块路由
- [x] 模块页面
- [x] 模块控制器
- [x] 模块本地化资源
- [x] 模块静态资源
- [x] `WBB` 模板模块
- [x] 样例模块
- [ ] `Doc` 模块
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