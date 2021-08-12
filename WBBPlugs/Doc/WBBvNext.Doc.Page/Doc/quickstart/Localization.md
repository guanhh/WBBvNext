# Localization

> `Feedback` 模块本地化配置

在 `Page` 层的 `Locales` 目录下编辑 `zh.json` 和 `en.json`

zh.json

```json
{
  "WBBvNext.Shared.Program": {
    "_Feedback": "反馈",
    "MenuKey.Suggestion": "反馈中心",
    "Suggestion.Title": "标题",
    "Suggestion.Detail": "详情",
    "Suggestion.QuestionType": "问题类型",
    "Suggestion.UserName": "用户名",
    "Suggestion.Email": "邮箱",
    "Suggestion.IsSolved": "解决",
    "Suggestion.Remark": "备注"
  }
}
```

en.json

```json
{
  "WBBvNext.Shared.Program": {
    "_Feedback": "Suggestion",
    "MenuKey.Suggestion": "Suggestion Manager",
    "Suggestion.Title": "Title",
    "Suggestion.Detail": "Detail",
    "Suggestion.QuestionType": "QuestionType",
    "Suggestion.UserName": "UserName",
    "Suggestion.Email": "Email",
    "Suggestion.IsSolved": "IsSolved",
    "Suggestion.Remark": "Remark"
  }
}
```

### 编译模块

重新编译模块后，运行

![feedback_localization](/images/feedback_localization.PNG)

![feedback_index](/images/feedback_localization_index.PNG)

![feedback_new](/images/feedback_localization_new.PNG)