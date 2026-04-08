namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о местонахождении во времени
    /// </summary>
    public class LocationTimeDto
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя человека
        /// </summary>
        public string Person { get; set; }

        /// <summary>
        /// Название места
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Время входа
        /// </summary>
        public string Enter { get; set; }

        /// <summary>
        /// Время выхода
        /// </summary>
        public string Exit { get; set; }
    }
}