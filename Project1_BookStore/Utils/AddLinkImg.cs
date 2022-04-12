using Project1_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.Utils
{
    internal class AddLinkImg
    {
        static public List<BookDTO> addLinkstoBook(List<BookDTO> lists)
        {
            foreach (var item in lists)
            {
                item.linkImg = $"/Resource/Images/BookCovers/{item.bookID}.jpg";
            }

            return lists;
        }

    }
}
