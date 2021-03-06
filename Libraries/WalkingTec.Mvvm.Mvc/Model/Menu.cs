
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WalkingTec.Mvvm.Mvc.Model
{
    /// <summary>
    /// Menu
    /// </summary>
    public class Menu
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// 默认用不上name，但是 v1.2.1 有问题：“默认展开了所有节点，并将所有子节点标蓝”
        /// </summary>
        /// <value></value>
        [JsonPropertyName("name")]
        public string Name => Title;

        /// <summary>
        /// Title
        /// </summary>
        /// <value></value>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        /// <value></value>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// 是否展开节点
        /// </summary>
        /// <value></value>
        [JsonPropertyName("spread")]
        public bool? Expand { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        /// <value></value>
        [JsonPropertyName("jump")]
        public string Url { get; set; }

        [JsonPropertyName("list")]
        public List<Menu> Children { get; set; }

        /// <summary>
        /// order
        /// </summary>
        /// <value></value>
        [JsonIgnore]
        public int? Order { get; set; }

    }
}
