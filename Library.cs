using Newtonsoft.Json;
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
            this.libraryListElements = new List<LibraryItemElement>();
            this.rentList = new List<Rental>();
            this.ids = 0;
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
            for (int i = 0; i < libraryListElements.Count; ++i)
            {
                if (libraryListElements[i].Item.IsSame(item))
                {
                    libraryListElements[i].Num++;
                    return;
                }
            }
            libraryListElements.Add(new LibraryItemElement(item, 1));
            ids++;
        }

        public void RemoveItem(int id)
        {
            for (int i = 0; i < libraryListElements.Count; ++i)
            {
                if (libraryListElements[i].Item.Id == id)
                {
                    if (libraryListElements[i].Num == 0)
                    {
                        throw new LibraryException("W bibliotece nie ma przedmiotu o indeksie " + id + " lub jest juz wypozyczony");
                    }
                    libraryListElements[i].Num--;
                    return;
                }
            }
        }

        public void RentItem(int id, string name, string surname)
        {
            for (int i = 0; i < libraryListElements.Count; ++i)
            {
                if (libraryListElements[i].Item.Id == id)
                {
                    if (libraryListElements[i].Num == 0)
                    {
                        throw new LibraryException("W bibliotece nie ma przedmiotu o indeksie " + id + " lub jest wypozyczony");
                    }
                    libraryListElements[i].Num--;
                    Rental rental = new Rental(libraryListElements[i].Item, name, surname);
                    rentList.Add(rental);
                    return;
                }
            }
        }

        public void ReturnItem(int id, string name, string surname)
        {
            foreach (var it in rentList)
            {
                if (it.Item.Id == id)
                {
                    AddNewItem(it.Item.Title, it.Item.GetExtraInfo(), it.Item.GroupCode);
                    rentList.Remove(it);
                    return;
                }
            }
            throw new Exception("Ten przedmiot nie byl wypozyczony");
        }

        public List<string> GetAllDesc()
        {
            List<string> elements = new List<string>();
            foreach (var it in libraryListElements)
            {
                elements.Add("num: " + it.Num + "," + it.Item.Desc());
            }
            return elements;

        }

        public List<string> GetAllRents()
        {
            List<string> elements = new List<string>();
            foreach (var it in rentList)
            {
                elements.Add(it.Name + " " + it.Surname + " " + it.Item.Desc());
            }
            return elements;

        }
        [JsonProperty]
        public List<LibraryItemElement> libraryListElements { get; }
        [JsonProperty]
        public List<Rental> rentList { get; }
        [JsonProperty]
        public int ids { get; set; }
}
}
