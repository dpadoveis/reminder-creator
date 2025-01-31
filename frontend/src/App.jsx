import { useState, useEffect } from "react";
import ReminderForm from "./components/ReminderForm";
import ReminderList from "./components/ReminderList";

const API_URL = "https://localhost:7102/api/reminder";

function App() {
  const [reminders, setReminders] = useState([]);


  useEffect(() => {
    fetch(API_URL)
      .then((response) => response.json())
      .then((data) => setReminders(data))
  }, []);


  const handleAddReminder = (name, date) => {
    const newReminder = { name, date };

    fetch(API_URL, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newReminder),
    })
      .then((response) => response.json())
      .then((data) => setReminders((prev) => [...prev, data]))
      .catch((error) => console.error("Erro ao adicionar lembrete:", error));
  };


  const handleDeleteReminder = (id) => {
    fetch(`${API_URL}/${id}`, {
      method: "DELETE",
    })
      .then(() => setReminders((prev) => prev.filter((reminder) => reminder.id !== id)))
      .catch((error) => console.error("Erro ao deletar lembrete:", error));
  };

  return (
    <div className="reminder-creator">
      <ReminderForm onAddReminder={handleAddReminder} />
      <ReminderList reminders={reminders} onDeleteReminder={handleDeleteReminder} />
    </div>
  );
}

export default App;
