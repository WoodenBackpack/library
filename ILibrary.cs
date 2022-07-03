using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    interface ILibrary
    {
        void RentItem(int id, string name, string surname);
        void ReturnItem(int id, string name, string surname);

        void AddNewItem(string title, string extraInfo, string itemGroupName);

        void RemoveItem(int id);

        List<string> GetAllDesc();
        List<string> GetAllRents();

        string GetItemDescAndNumber(int id);

    }
}
