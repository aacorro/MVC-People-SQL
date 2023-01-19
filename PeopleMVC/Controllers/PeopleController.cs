using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PeopleMVC.Models;
using PeopleMVC.Services;

namespace PeopleMVC.Controllers
{
    public class PeopleController : Controller
    {
        PeopleDAO repository;


        public IActionResult Index()
        {
            PeopleDAO people = new PeopleDAO();
            return View(people.GetAllPeople());
        }

        public IActionResult SearchResults(string searchTerm) 
        {
            PeopleDAO people = new PeopleDAO();
            List<PeopleModel> peopleList = people.SearchPeople(searchTerm);
            return View("Index", peopleList);
        }

        public IActionResult SearchForm() 
        { 
            return View(); 
        }

        public IActionResult ShowDetails(int id)
        {
            PeopleDAO people = new PeopleDAO();
            PeopleModel foundPerson = people.GetPeopleById(id);
            return View(foundPerson);
        }

        public IActionResult Edit(int id)
        {
            PeopleDAO people = new PeopleDAO();
            PeopleModel foundPerson = people.GetPeopleById(id);
            return View("ShowEdit", foundPerson);
        }

        public IActionResult ProcessEdit(PeopleModel person)
        {
            PeopleDAO people = new PeopleDAO();
            people.Update(person);
            return View("Index", people.GetAllPeople());
        }

        public IActionResult Delete(int Id)
        {
            PeopleDAO people = new PeopleDAO();
            PeopleModel person = people.GetPeopleById(Id);
            people.Delete(person);
            return View("Index", people.GetAllPeople());
        }

        public IActionResult ShowCreateForm()
        {
            return View("ShowCreateForm");
        }

        public IActionResult InsertOne(PeopleModel person)
        {
            PeopleDAO personModel = new PeopleDAO();
            personModel.Insert(person);
            return View("Index", personModel.GetAllPeople());
        }
    }
}
