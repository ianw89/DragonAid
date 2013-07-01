using System;
using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data.Model;
using DragonAid.WindowsClient.Common;
using Windows.UI.Xaml;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// Viewmodel for a skill. 
    /// Note that top level skills, which can have ranked, have their own view model that extends this.
    /// Also note that magical skills are treated totally seperate right now.
    /// </summary>
    public class SkillViewModel : BindableBase
    {
        private readonly ISkill _skill;
        private readonly IList<SkillViewModel> _subskillViewModels;
        private Visibility _extendedInfoVisibility;

        /// <summary>
        /// Constructs a view model for the given skill and all it's subskills.
        /// </summary>
        public SkillViewModel(ISkill skill)
        {
            this._skill = skill;
            this._extendedInfoVisibility = Visibility.Collapsed;

            if (this._skill.Subskills != null)
            {
                this._subskillViewModels = this._skill.Subskills.Select(s => new SkillViewModel(s)).ToList();
            }
            else
            {
                this._subskillViewModels = new List<SkillViewModel>();
            }
        }

        public string FullName
        {
            get { return this._skill.FullName; }
            set { throw new NotSupportedException();}
        }

        public IList<SkillViewModel> Subskills
        {
            get { return this._subskillViewModels; }
            set { throw new NotSupportedException();}
        }

        public string Description
        {
            get { return this._skill.Description ?? "<No skill description set>"; }
            set { throw new NotSupportedException(); }
        }

        public Visibility ExtendedInfoVisibility
        {
            get { return this._extendedInfoVisibility; }
            set { this.SetProperty(ref this._extendedInfoVisibility, value); }
        }
    }
}