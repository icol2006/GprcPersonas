namespace MinInt.ModuloWeb.Personas.EventHandlers.Commons.Helpers
{
    public static class Paging
    {
        public static int GetTotalPages(int total, int pageSize)
        {
            return total % pageSize == 0
                ? total / pageSize
                : total / pageSize + 1;
        }
    }
}
