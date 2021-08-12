# Module

> `WBBvNext` 模块结构介绍

以 `School` 模块为例

![插件配置](/images/school_module_pro.PNG)

- `WBBvNext.School.Abstrat`

    服务接口定义层，相关常量、配置对象等基础信息

- `WBBvNext.School.DataAccess`

    数据库上下文

- `WBBvNext.School.Extension`

    服务实现，模块基础信息实现，静态文件实现。根据模块需要进行不同实现。

- `WBBvNext.School.Model`

    模型层

- `WBBvNext.School.Page`

    包含 Razor 页面和控制器（自动生成）

- `WBBvNext.School.Test`

    测试（自动生成）

- `WBBvNext.School.ViewModel`

    视图模型层（自动生成）
