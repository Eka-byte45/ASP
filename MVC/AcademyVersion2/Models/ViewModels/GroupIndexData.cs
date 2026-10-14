namespace AcademyVersion2.Models.ViewModels
{
    public class GroupIndexData
    {
        public PaginatedList<Group> Groups {  get; set; }
       public IEnumerable<Student> Students { get; set; }
    }
}
