using System;
using System.Linq;
using System.Windows.Forms;
using Detective.Models;

namespace Detective.Forms
{
    public partial class Details : Form
    {
        public Details(DetectiveData data, string entityType, Guid id)
        {
            InitializeComponent();
            txtDetails.Text = BuildDetails(data, entityType, id);
        }

        private string BuildDetails(DetectiveData data, string entityType, Guid id)
        {
            return $"{GetRussianName(entityType)}{Environment.NewLine}{Environment.NewLine}{GetEntityDetails(data, entityType, id)}";
        }

        private string GetEntityDetails(DetectiveData data, string entityType, Guid id)
        {
            switch (entityType)
            {
                case "Persons":
                    return GetPersonDetails(data, id);

                case "Cases":
                    return GetCaseDetails(data, id);

                case "Evidences":
                    return GetEvidenceDetails(data, id);

                case "Hypotheses":
                    return GetHypothesisDetails(data, id);

                case "Motives":
                    return GetMotiveDetails(data, id);

                case "InvestigativeActions":
                    return GetActionDetails(data, id);

                case "LocationTimes":
                    return GetLocationTimeDetails(data, id);

                case "Meetings":
                    return GetMeetingDetails(data, id);

                case "Clues":
                    return GetClueDetails(data, id);

                default:
                    return "Неизвестный тип данных";
            }
        }
        private string GetPersonDetails(DetectiveData data, Guid id)
        {
            var p = data.Persons?.FirstOrDefault(x => x.Id == id);
            if (p == null) return "Данные не найдены!";

            return
                $"ID: {p.Id}{Environment.NewLine}" +
                $"Имя: {p.FirstName}{Environment.NewLine}" +
                $"Фамилия: {p.LastName}{Environment.NewLine}" +
                $"Полное имя: {p.FullName}{Environment.NewLine}" +
                $"Роль: {p.Role}{Environment.NewLine}{Environment.NewLine}" +
                $"КОНТАКТЫ{Environment.NewLine}" +
                $"Телефон: {p.Contact?.Phone ?? "—"}{Environment.NewLine}" +
                $"Email: {p.Contact?.Email ?? "—"}{Environment.NewLine}" +
                $"Адрес: {p.Contact?.Address ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"БИОМЕТРИЯ{Environment.NewLine}" +
                $"Фото: {p.Biometrics?.Photo ?? "—"}{Environment.NewLine}" +
                $"Хэш: {p.Biometrics?.FingerprintHash ?? "—"}";
        }
        private string GetCaseDetails(DetectiveData data, Guid id)
        {
            var c = data.Cases?.FirstOrDefault(x => x.Id == id);
            if (c == null) return "Данные не найдены!";

            var moments = c.Timeline?.KeyMoments != null && c.Timeline.KeyMoments.Count > 0
                ? string.Join(Environment.NewLine, c.Timeline.KeyMoments.Select(m => $"• {m.time} — {m.description}"))
                : "—";

            return
                $"ID: {c.Id}{Environment.NewLine}" +
                $"Номер: {c.NumberId}{Environment.NewLine}" +
                $"Название: {c.Title}{Environment.NewLine}" +
                $"Статус: {c.Status?.CurrentStatus ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"ДЕТАЛИ ПРЕСТУПЛЕНИЯ{Environment.NewLine}" +
                $"Тип: {c.CrimeDetails?.CrimeType ?? "—"}{Environment.NewLine}" +
                $"Дата открытия: {c.CrimeDetails?.DateOpened ?? "—"}{Environment.NewLine}" +
                $"Место: {c.CrimeDetails?.CrimeLocation ?? "—"}{Environment.NewLine}" +
                $"Детектив: {c.CrimeDetails?.LeadDetective ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"ХРОНОЛОГИЯ{Environment.NewLine}" +
                $"Начало: {c.Timeline?.Start ?? "—"}{Environment.NewLine}" +
                $"Ключевые моменты:{Environment.NewLine}{moments}";
        }

        private string GetEvidenceDetails(DetectiveData data, Guid id)
        {
            var e = data.Evidences?.FirstOrDefault(x => x.Id == id);
            if (e == null) return "Данные не найдены!";

            var custody = e.ChainOfCustody != null && e.ChainOfCustody.Count > 0
                ? string.Join(Environment.NewLine, e.ChainOfCustody.Select(x => $"• {x.date}: {x.person} — {x.action}"))
                : "—";

            return
                $"ID: {e.Id}{Environment.NewLine}" +
                $"Номер: {e.NumberId}{Environment.NewLine}" +
                $"Дело: {e.CaseId}{Environment.NewLine}" +
                $"Категория: {e.EvidenceType?.Category ?? "—"}{Environment.NewLine}" +
                $"Подтип: {e.EvidenceType?.Subtype ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"ОПИСАНИЕ{Environment.NewLine}" +
                $"Кратко: {e.Description?.Short ?? "—"}{Environment.NewLine}" +
                $"Полностью: {e.Description?.Full ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"ОБНАРУЖЕНИЕ{Environment.NewLine}" +
                $"Место: {e.FoundInfo?.Location ?? "—"}{Environment.NewLine}" +
                $"Кто нашёл: {e.FoundInfo?.FoundBy ?? "—"}{Environment.NewLine}" +
                $"Дата: {e.FoundInfo?.DateFound ?? "—"}{Environment.NewLine}{Environment.NewLine}" +
                $"ЦЕПОЧКА ХРАНЕНИЯ{Environment.NewLine}" +
                $"{custody}{Environment.NewLine}{Environment.NewLine}" +
                $"УКАЗЫВАЕТ НА{Environment.NewLine}" +
                $"Подозреваемый: {e.PointsTo?.PersonName ?? "—"}{Environment.NewLine}" +
                $"Уверенность: {(e.PointsTo != null ? $"{e.PointsTo.Confidence:P0}" : "—")}";
        }

        private string GetHypothesisDetails(DetectiveData data, Guid id)
        {
            var h = data.Hypotheses?.FirstOrDefault(x => x.Id == id);
            if (h == null) return "Данные не найдены!";

            return
                $"ID: {h.Id}{Environment.NewLine}" +
                $"Дело: {h.CaseId}{Environment.NewLine}" +
                $"Описание: {h.Description ?? "—"}{Environment.NewLine}" +
                $"Приоритет: {h.Priority?.Level ?? "—"}{Environment.NewLine}" +
                $"Создатель: {h.Creator?.Name ?? "—"} ({h.Creator?.Role ?? "—"}){Environment.NewLine}" +
                $"Подтверждена: {(h.Confirmation?.IsConfirmed == true ? "Да" : "Нет")}{Environment.NewLine}" +
                $"Обновлено: {h.Confirmation?.LastUpdate ?? "—"}";
        }

        private string GetMotiveDetails(DetectiveData data, Guid id)
        {
            var m = data.Motives?.FirstOrDefault(x => x.Id == id);
            if (m == null) return "Данные не найдены!";

            return
                $"ID: {m.Id}{Environment.NewLine}" +
                $"Подозреваемый: {m.Person?.Name ?? "—"}{Environment.NewLine}" +
                $"Тип мотива: {m.MotiveDetails?.Type ?? "—"}{Environment.NewLine}" +
                $"Сила: {m.MotiveDetails?.Strength}/10{Environment.NewLine}" +
                $"Описание: {m.MotiveDetails?.Description ?? "—"}";
        }

        private string GetActionDetails(DetectiveData data, Guid id)
        {
            var a = data.InvestigativeActions?.FirstOrDefault(x => x.Id == id);
            if (a == null) return "Данные не найдены!";

            var evidences = a.NewEvidences != null && a.NewEvidences.Count > 0
                ? string.Join(", ", a.NewEvidences)
                : "—";

            return
                $"ID: {a.Id}{Environment.NewLine}" +
                $"Дело: {a.CaseId}{Environment.NewLine}" +
                $"Действие: {a.ActionType?.Name ?? "—"}{Environment.NewLine}" +
                $"Код: {a.ActionType?.Code ?? "—"}{Environment.NewLine}" +
                $"Цель: {a.Target?.PersonName ?? "—"}{Environment.NewLine}" +
                $"PersonId: {(a.Target?.PersonId?.ToString() ?? "—")}{Environment.NewLine}" +
                $"Результат: {a.Result?.Summary ?? "—"}{Environment.NewLine}" +
                $"Полный текст: {a.Result?.FullText ?? "—"}{Environment.NewLine}" +
                $"Дата: {a.Result?.Date ?? "—"}{Environment.NewLine}" +
                $"Новые улики: {evidences}";
        }

        private string GetLocationTimeDetails(DetectiveData data, Guid id)
        {
            var l = data.LocationTimes?.FirstOrDefault(x => x.Id == id);
            if (l == null) return "Данные не найдены!";

            return
                $"ID: {l.Id}{Environment.NewLine}" +
                $"Человек: {l.Person?.Name ?? "—"}{Environment.NewLine}" +
                $"Место: {l.Location?.Name ?? "—"}{Environment.NewLine}" +
                $"Тип места: {l.Location?.Type ?? "—"}{Environment.NewLine}" +
                $"Вход: {l.TimeInterval?.Enter ?? "—"}{Environment.NewLine}" +
                $"Выход: {l.TimeInterval?.Exit ?? "—"}{Environment.NewLine}" +
                $"Длительность: {l.TimeInterval?.Duration ?? "—"}{Environment.NewLine}" +
                $"Источник: {l.Source?.Type ?? "—"}";
        }

        private string GetMeetingDetails(DetectiveData data, Guid id)
        {
            var m = data.Meetings?.FirstOrDefault(x => x.Id == id);
            if (m == null) return "Данные не найдены!";

            var witnesses = m.Witnesses != null && m.Witnesses.Count > 0
                ? string.Join(", ", m.Witnesses)
                : "—";

            return
                $"ID: {m.Id}{Environment.NewLine}" +
                $"Участник 1: {m.PersonA?.Name ?? "—"}{Environment.NewLine}" +
                $"Участник 2: {m.PersonB?.Name ?? "—"}{Environment.NewLine}" +
                $"Место: {m.MeetingDetails?.Location ?? "—"}{Environment.NewLine}" +
                $"Время: {m.MeetingDetails?.Time ?? "—"}{Environment.NewLine}" +
                $"Тайная: {(m.MeetingDetails?.IsSecret == true ? "Да" : "Нет")}{Environment.NewLine}" +
                $"Свидетели: {witnesses}";
        }

        private string GetClueDetails(DetectiveData data, Guid id)
        {
            var c = data.Clues?.FirstOrDefault(x => x.Id == id);
            if (c == null) return "Данные не найдены!";

            return
                $"ID: {c.Id}{Environment.NewLine}" +
                $"Из улики: {c.FromEvidence?.Description ?? "—"}{Environment.NewLine}" +
                $"К улике: {c.ToEvidence?.Description ?? "—"}{Environment.NewLine}" +
                $"Правило: {c.InferenceRule?.RuleText ?? "—"}{Environment.NewLine}" +
                $"Уверенность: {c.Confidence?.Level ?? "—"}";
        }

        private string GetRussianName(string entityType)
        {
            switch (entityType)
            {
                case "Persons": return "Люди";
                case "Cases": return "Дела";
                case "Evidences": return "Улики";
                case "Hypotheses": return "Версии";
                case "Motives": return "Мотивы";
                case "InvestigativeActions": return "Следственные действия";
                case "LocationTimes": return "Локации";
                case "Meetings": return "Встречи";
                case "Clues": return "Цепочки улик";
                default: return "Детали";
            }
        }
    }
}