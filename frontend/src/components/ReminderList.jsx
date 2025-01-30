import Button from "./ui/Button";

function ReminderList({ reminders, onDeleteReminder }) {
  const formatDate = (isoDate) => {
    return new Date(isoDate).toLocaleDateString("pt-BR", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
    });
  };

  const groupRemindersByDate = (reminders) => {
    return reminders.reduce((acc, reminder) => {
      const formattedDate = formatDate(reminder.date);
      if (!acc[formattedDate]) acc[formattedDate] = [];
      acc[formattedDate].push(reminder);
      return acc;
    }, {});
  };

  const groupedReminders = groupRemindersByDate(reminders);

  return (
    <div className="reminder-list">
      <h2>Lista de lembretes</h2>
      {Object.keys(groupedReminders).length === 0 ? (
        <p>Nenhum lembrete criado ainda.</p>
      ) : (
        <ul>
          {Object.keys(groupedReminders).map((date) => (
            <li key={date} className="date-group">
              <strong>{date}</strong>
              <ul>
                {groupedReminders[date].map((reminder) => (
                  <li key={reminder.id} className="reminder-item">
                    <span className="reminder-name">{reminder.name}</span>
                    <Button onClick={() => onDeleteReminder(reminder.id)}>
                      ✖
                    </Button>
                  </li>
                ))}
              </ul>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default ReminderList;

