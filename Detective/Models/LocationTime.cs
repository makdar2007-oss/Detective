namespace Detective.Models
{
    /// <summary>
    /// Ссылка на человека
    /// </summary>
    public class PersonLocation
    {
        /// <summary>
        /// Идентификатор человека
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Имя человека
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Информация о месте
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Название места
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип места (спальное купе, общественное место, офис)
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Временной интервал
    /// </summary>
    public class TimeInterval
    {
        /// <summary>
        /// Время входа/прибытия
        /// </summary>
        public string Enter { get; set; }

        /// <summary>
        /// Время выхода/отбытия
        /// </summary>
        public string Exit { get; set; }

        /// <summary>
        /// Продолжительность пребывания
        /// </summary>
        public string Duration { get; set; }
    }

    /// <summary>
    /// Источник информации о местонахождении
    /// </summary>
    public class Source
    {
        /// <summary>
        /// Тип источника (показания, камеры, чеки, GPS)
        /// </summary>
        public string Type { get; set; }
    }

    /// <summary>
    /// Модель местонахождения человека во времени
    /// </summary>
    public class LocationTime
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Человек
        /// </summary>
        public PersonLocation Person { get; set; }

        /// <summary>
        /// Место
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Временной интервал
        /// </summary>
        public TimeInterval TimeInterval { get; set; }

        /// <summary>
        /// Источник информации
        /// </summary>
        public Source Source { get; set; }
    }
}