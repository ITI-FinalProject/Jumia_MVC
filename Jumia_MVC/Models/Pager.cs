namespace Jumia_MVC.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
public int CurrentPage{get;private set;}
public int PageSize { get; private set; }
public int TotalPages { get; private set; }
    
public int StartPage { get; private set; }
    
public int EndPage { get; private set; }

        public Pager() { }
        public Pager(int totalItem,int page ,int pageSize=10) {

            int totalPage=(int) Math.Ceiling((decimal)totalItem/(decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if(startPage <= 0)
            {
                endPage=endPage-(startPage-1);
                startPage=1;
            }

            if(endPage > totalPage)
            {
                endPage=totalPage;

                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPage;
            StartPage = startPage;
            EndPage = endPage;
            TotalItems = totalItem;
        }
}
}
