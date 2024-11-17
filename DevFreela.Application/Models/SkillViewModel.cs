using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public static SkillViewModel FromEntity(Skill skill)
        {
            return new SkillViewModel(skill.Description);
        }
    }
}
