namespace Roznama.Common.Helpers
{
    public static class PaginationHelper
    {
        public static (int Offset, int Fetch) GetPagination(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 25;

            int offset = (pageNumber - 1) * pageSize;

            return (offset, pageSize);
        }
    }
}