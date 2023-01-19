using PeopleMVC.Models;

namespace PeopleMVC.Services
{
    public interface IPeopleDataService
    {
        List<PeopleModel> GetAllPeople();
        List<PeopleModel> SearchPeople(string searchTerm);
        PeopleModel GetPeopleById(int id);
        int Insert(PeopleModel person);
        int Update(PeopleModel person);
        int Delete(int id);



    }
}
