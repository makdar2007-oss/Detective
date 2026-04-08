namespace Detective.Models
{
    /// <summary>
    /// Контактная информация человека
    /// </summary>
    public class Contact
    {
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
    }

    /// <summary>
    /// Биометрические данные человека
    /// </summary>
    public class Biometrics
    {
        /// <summary>
        /// Путь к файлу с фотографией
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Хэш отпечатка пальца (для идентификации)
        /// </summary>
        public string FingerprintHash { get; set; }
    }

    /// <summary>
    /// Модель человека (детектив, подозреваемый, свидетель, потерпевший)
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Уникальный идентификатор человека
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя человека
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Роль в расследовании
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Контактная информация
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Биометрические данные
        /// </summary>
        public Biometrics Biometrics { get; set; }
    }
}