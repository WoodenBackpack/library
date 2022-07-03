using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Library : ILibrary
    {

        public Library()
        {
            this.libraryDict = new Dictionary<LibraryItem, int>();
            this.rentList = new List<Rental>();
        }

        public void AddNewItem(string title, string extraInfo, string itemGroupName)
        {
            LibraryItem item;
            switch (itemGroupName) {
                case "MOV":
                    item = new Movie(title, extraInfo, ids);
                    break;
                case "BOOK":
                    item = new Book(title, extraInfo, ids);
                    break;
                case "THESIS":
                    item = new Thesis(title, extraInfo, ids);
                    break;
                case "MAG":
                    item = new Magazine(title, extraInfo, ids);
                    break;
                default:
                    throw new LibraryException("Nie można dodać przedmiotu, wybierz grupę");
            }
            foreach (var it in libraryDict)
            {
                if (it.Key.IsSame(item))
                {
                    libraryDict[it.Key]++;
                    return;
                }
            }
            libraryDict.Add(item, 1);
            ids++;
        }

        public void RemoveItem(int id)
        {
            foreach (var it in libraryDict)
            {
                if (it.Key.Id() == id)
                {
                    if (it.Value == 0)
                    {
                        throw new LibraryException("W bibliotece nie przedmiotu o indeksie" + id + "lub jes wypozyczony");
                    }
                    libraryDict[it.Key]--;
                    return;
                }
            }
        }

        public void RentItem(int id, string name, string surname)
        {
            foreach (var it in libraryDict)
            {
                if (it.Key.Id() == id)
                {
                    if (it.Value == 0)
                    {
                        throw new LibraryException("W bibliotece nie przedmiotu o indeksie" + id + "lub jes wypozyczony");
                    }
                    libraryDict[it.Key]--;
                    Rental rental = new Rental(it.Key, name, surname);
                    rentList.Add(rental);
                    return;
                }
            }
        }

        public void ReturnItem(int id, string name, string surname)
        {
            foreach (var it in rentList)
            {
                if (it.Item().Id() == id)
                {
                    AddNewItem(it.Item().Title(), it.Item().GetExtraInfo(), it.Item().GroupCode());
                    rentList.Remove(it);
                    return;
                }
            }
            throw new Exception("This Item was not rent!");
        }

        public void ShowAll()
        {
            foreach (var it in libraryDict)
            {
                System.Console.WriteLine("num: " + it.Value + " " + it.Key.Desc());
            }
        }

        public string GetItemDescAndNumber(int id)
        {
            foreach (var it in libraryDict)
            {
                if (it.Key.Id() == id)
                {
                    return "num: " + it.Value + " " + it.Key.Desc();
                }
            }
            return "";
        }

        public List<string> GetAllDesc()
        {
            List<string> elements = new List<string>();
            foreach (var it in libraryDict)
            {
                elements.Add("num: " + it.Value + " " + it.Key.Desc());
            }
            return elements;

        }

        public List<string> GetAllRents()
        {
            List<string> elements = new List<string>();
            foreach (var it in rentList)
            {
                elements.Add(it.Name() + " " + it.Surname() + " " + it.Item().Desc());
            }
            return elements;

        }

        Dictionary<LibraryItem, int> libraryDict;
        List<Rental> rentList;
        int ids = 0;
    }
}
