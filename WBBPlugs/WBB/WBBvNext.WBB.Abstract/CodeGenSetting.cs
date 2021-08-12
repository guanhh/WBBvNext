using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using WBBvNext.Base;

namespace WBBvNext.WBB.Abstract
{
    public class CodeGenSetting
    {
        private bool _isDevelop;
        public CodeGenSetting(bool isDevelop)
        {
            _isDevelop = isDevelop;
        }


        [Required]
        [Display(Name = "_WBB.PlugName")]
        [StringLength(20)]
        public string PlugName { get; set; }

        [Required]
        [Display(Name = "_WBB.IsExistDb")]
        public bool IsExistDb { get; set; }

        private string _mainDir;

        private string _projectDir;

        [Required]
        [Display(Name = "_WBB.ProjectDir")]
        public string ProjectDir
        {
            get
            {
                if (!_isDevelop)
                    return null;

                if (!string.IsNullOrWhiteSpace(_projectDir))
                    return _projectDir;

                if (_mainDir == null)
                {
                    var EntryDir = AppDomain.CurrentDomain.BaseDirectory;
                    int? index = EntryDir?.IndexOf($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}Debug{Path.DirectorySeparatorChar}");
                    if (index == null || index < 0)
                    {
                        index = EntryDir?.IndexOf($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}Release{Path.DirectorySeparatorChar}") ?? 0;
                    }

                    _mainDir = EntryDir?.Substring(0, index.Value);
                }

                var rootDir = Directory.GetParent(_mainDir).FullName;
                return $"{rootDir}/{WBBSetting.PLUG_DIR}/{PlugName}";
            }
            set
            {
                _projectDir = value;
            }
        }
    }
}
