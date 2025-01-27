import { useState } from 'react';

function App() {
  const [reminders, setReminders] = useState([]);
  const [name, setName] = useState('');
  const [date, setDate] = useState('');


  const handleAddReminder = () => {
    if (!name || !date) {
      alert('Preencha todos os campos!');
      return;
    }



    const newReminder = { id: Date.now(), name, date };
    setReminders((x) => [...x, newReminder]);
    setName('');
    setDate('');
  };

  const handleDeleteReminder = (id) => {
    setReminders((x) => x.filter((reminder) => reminder.id !== id));
  };

  // agrupar por data
  const groupRemindersByDate = (reminders) => {
    return reminders.reduce((acc, reminder) => {
      const { date } = reminder;
      if (!acc[date]) {
        acc[date] = [];
      }
      acc[date].push(reminder);
      return acc;
    }, {});
  };

  const groupedReminders = groupRemindersByDate(reminders);

  return (
    <div className="">
      <h1 className="">Crie um lembrete</h1>
      <div className="">
        <input
          type="text"
          placeholder="Nome do lembrete"
          value={name}
          onChange={(e) => setName(e.target.value)}
          className=""
        />
        {/* add data*/}
        <input
          type="date"
          value={date}
          onChange={(e) => setDate(e.target.value)}
          className=""
        />
        {/* criar lembrete*/}
        <button
          onClick={handleAddReminder}
          className=""
        >
          Criar
        </button>
      </div>

      {/* lista */}
      <h2 className="">Lista de lembretes</h2>
      <ul className="">
        {Object.keys(groupedReminders).length === 0 ? (
          <p className="">Nenhum lembrete criado ainda.</p>
        ) : (
          Object.keys(groupedReminders).map((date) => (
            <li key={date} className="">
              <div className="">{date}</div>
              <ul>
                {groupedReminders[date].map((reminder) => (
                  <li key={reminder.id} className="">
                    <div className="reminder">
                      <span>
                         {reminder.name}
                      </span>
                      <button
                        onClick={() => handleDeleteReminder(reminder.id)}
                        className=""
                      >
                        ✖
                      </button>
                    </div>
                  </li>
                ))}
              </ul>
            </li>
          ))
        )}
      </ul>
    </div>
  );
}

export default App;
