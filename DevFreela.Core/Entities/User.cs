namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate, string password, string role)
            : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Password = password;
            Role = role;

            Skills = [];
            OwnedProjects = [];
            FreelanceProjects = [];
            Comments = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string name, string email, DateTime birthdate)
        {
            FullName = name;
            Email = email;
            BirthDate = birthdate;

        }
    }
}
