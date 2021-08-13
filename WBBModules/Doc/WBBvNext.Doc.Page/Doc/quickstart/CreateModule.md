# CreateModule

1.  编译 `WBB` 模块，置于 `WBBPlugs` 目录下

![插件目录](/images/wbb_dll.PNG)

2.  设置 `WBBvNext` 为启用项，运行项目

3.  配置插件参数，生成插件结构

![插件配置](/images/wbb_module.PNG)

- 插件名称：模块简称，后面数据库连接配置参数与之对应
- 包含数据库：勾选 `包含数据库` 表示改模块包含数据库操作，会自动生成数据库相关库
- 项目路径：自动填充，不需要改动。指的是代码生成路径

4. 生成 `Feedback` 模块代码


![插件配置](/images/wbb_gencode.PNG)

5. 将 `Feedback` 模块代码添加到 `WBBvNext` 中


![插件配置](/images/add_gen_module.PNG)

### 至此，一个 `Feedback` 模块的基本结构已经创建完成