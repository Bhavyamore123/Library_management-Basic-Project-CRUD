using _1_Library_Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Library_Interface.Interfaces
{
    public interface Library_Book_Interface
    {
        int PostData(Library_Book_Model model);
        DataTable GetLibraryData();
        DataTable LibraryBookViewEdit(int ID);
        void LibraryBookViewDelete(int ID);
    }
}
