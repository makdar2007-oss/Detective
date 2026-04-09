using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о мотиве
    /// </summary>
    public class MotiveDto
    {
        /// <summary>
        /// Уникальный идентификатор мотива
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя подозреваемого
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Тип мотива 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Сила мотива (от 1 до 10)
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Описание мотива
        /// </summary>
        public string Description { get; set; }
    }
}