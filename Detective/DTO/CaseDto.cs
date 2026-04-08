namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о деле
    /// </summary>
    public class CaseDto
    {
        /// <summary>
        /// Уникальный идентификатор дела
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название дела
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текущий статус дела
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Тип преступления
        /// </summary>
        public string CrimeType { get; set; }

        /// <summary>
        /// Место преступления
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Ведущий детектив по делу
        /// </summary>
        public string Detective { get; set; }
    }
}