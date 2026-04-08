namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о встрече
    /// </summary>
    public class MeetingDto
    {
        /// <summary>
        /// Уникальный идентификатор встречи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя первого участника
        /// </summary>
        public string PersonA { get; set; }

        /// <summary>
        /// Имя второго участника
        /// </summary>
        public string PersonB { get; set; }

        /// <summary>
        /// Место встречи
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Время встречи
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Была ли встреча тайной
        /// </summary>
        public bool IsSecret { get; set; }
    }
}