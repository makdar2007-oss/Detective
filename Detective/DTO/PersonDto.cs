using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о человеке
    /// </summary>
    public class PersonDto
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Имя человека
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия человека
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Полное имя человека
        /// </summary>
        public string FullName => $"{FirstName} {LastName}".Trim();
        /// <summary>
        /// Роль (детектив, подозреваемый, свидетель, потерпевший)
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Путь к файлу с фотографией
        /// </summary>
        public string Photo { get; set; }
    }
}